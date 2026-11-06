"""Offline cross-export enum, closed ABI and board geometry evidence.

This is an audit, never a source of runtime addresses or live acceptance.
"""
import argparse
import bisect
import json
from pathlib import Path
import re
import struct

from tools.reverse_exports import dumper_types, dumper_script, normalized_type, unique


def scoped_type(owner, value):
    qualifiers = re.match(r'(?:(?:static|readonly|volatile)\s+)*', value)[0]
    value = value[len(qualifiers):]
    value = normalized_type(value)
    value = re.sub(r'(\w+)\?', r'Nullable<\1>', value)
    # These exact spelling pairs are independently checked against named types
    # and C++ field declarations in the export. Never strip arbitrary scopes.
    value = value.replace('UnityEngine.UI.Text', 'Text')
    aliases = {
        'Active': ('PlayerStats', 'DamagePopupStyle'), 'MatchService': ('QteWindow',),
        'RoomStartState': ('Phase',), 'PokiGuard.Audition.AuditionStage': ('ArrowNode',),
        'Newtonsoft.Json.Linq.JProperty': ('JPropertyList',),
        'UnityEngine.UI.Button': ('ButtonClickedEvent',),
        'UnityEngine.UI.Selectable': ('Transition',),
        'TurnAnnouncer': ('Runner', 'View'),
    }
    for short in aliases.get(owner, ()):
        # Dumper uses the nested owner's simple name, e.g. JProperty.JPropertyList.
        qualified = owner.rsplit('.', 1)[-1] + '.' + short
        value = re.sub(r'(?<![\w.])' + re.escape(qualified) + r'(?!\w)', short, value)
    return qualifiers + value


def flat_cpp_layout(header, name, base=0):
    """x64 natural layout of a flat export struct; unknown field types fail."""
    match = re.search(r'\b' + re.escape(name) + r'\s*\{([^}]+)\};', header)
    if not match:
        raise ValueError('missing flat C++ struct ' + name)
    offset = base
    alignment = 1
    fields = {}
    for line in match[1].strip().splitlines():
        found = re.fullmatch(r'\s*(.+?)\s+(\*?\w+);\s*', line)
        if not found:
            raise ValueError('unsupported field declaration ' + line)
        kind, member = found.groups()
        if member.startswith('*'):
            kind += '*'
            member = member[1:]
        if '*' in kind:
            size, align = 8, 8
        else:
            size, align = {'bool': (1, 1), 'uint16_t': (2, 2), 'int32_t': (4, 4),
                           'int64_t': (8, 8)}[kind]
        offset = (offset + align - 1) // align * align
        fields[member] = dict(type=kind, offset=offset)
        offset += size
        alignment = max(alignment, align)
    return dict(fields=fields, size=(offset + alignment - 1) // alignment * alignment,
                declaration=match[0])


def normalized_instructions(rows):
    rows = list(rows)
    while rows and rows[-1]['mnemonic'] == 'int3':
        rows.pop()
    indices = {r['rva']: i for i, r in enumerate(rows)}
    result = []
    for row in rows:
        op, mn = row['op'], row['mnemonic']
        if 'rip' in op:
            value = 'FLOAT:' + row['float'] if row.get('float') and mn in {
                'movss', 'mulss', 'divss', 'comiss', 'subss', 'addss', 'minss', 'maxss'} else 'RIP'
            op = re.sub(r'\[rip[^]]*\]', value, op)
        if mn.startswith('j') and re.fullmatch(r'0x[0-9a-f]+', op):
            address = int(op, 16)
            if address >= 0x180000000:
                address -= 0x180000000
            op = 'INS:' + str(indices.get(address, 'OUTSIDE'))
        if mn == 'call' and re.fullmatch(r'0x[0-9a-f]+', op):
            op = 'EXTERNAL_CALL'
        result.append((mn, re.sub(r'\s+', '', op)))
    return result


def audit(old, new, install, static_path, prior_geometry):
    import pefile
    import capstone
    old, new, install = map(Path, (old, new, install))
    types = dumper_types(str(new))
    script = dumper_script(str(new))
    header = (new / 'il2cpp.h').read_text('utf-8-sig')
    static = json.loads(Path(static_path).read_text('utf-8'))
    for owner, nested in [('Active', 'PlayerStats'), ('MatchService', 'QteWindow'),
                          ('RoomStartState', 'Phase'), ('TurnAnnouncer', 'Runner'),
                          ('TurnAnnouncer', 'View')]:
        if ('Assembly-CSharp', owner + '.' + nested) not in types:
            raise ValueError('nested alias identity missing ' + owner + '.' + nested)
    for owner in ('Board', 'CardUI', 'RoomCoopV2Refs'):
        section = re.search(r'\b' + owner + r'_Fields[^\{]*\{([^}]+)\};', header)
        if not section or 'struct UnityEngine_UI_Text_o*' not in section[1]:
            raise ValueError('UI.Text alias not proven for ' + owner)
    field_types = []
    for row in static['offset_candidates']:
        if row['new'] is None:
            raise ValueError('missing field ' + row['constant'])
        equal = scoped_type(row['klass'], row['old']['type']) == scoped_type(row['klass'], row['new']['type'])
        if not equal:
            raise ValueError('field type changed ' + row['constant'])
        field_types.append(dict(constant=row['constant'], same_type=True,
                                moved=row['old']['offset'] != row['new']['offset']))
    library_changes = []
    for item in static['library_layouts']:
        owner = item['identity'][1]
        if owner.startswith('System.Collections.Generic.'):
            library_changes.append(dict(identity=owner, status='OPEN_GENERIC_OFFSETS_UNKNOWN_USE_CLOSED_HEADER'))
            continue
        differences = {name: row for name, row in item['changes'].items() if row['old'] is None or row['new'] is None
            or row['old']['offset'] != row['new']['offset']
            or scoped_type(owner, row['old']['type']) != scoped_type(owner, row['new']['type'])}
        library_changes.append(dict(identity=owner, changes=differences))
    abi = {}
    for name, base in [
        ('System_Collections_Generic_List_UnityMainThreadDispatcher_PendingAction__Fields', 16),
        ('System_Collections_Generic_Queue_UnityMainThreadDispatcher_PendingAction__Fields', 16),
        ('System_Collections_Generic_Dictionary_string__object__Fields', 16),
        ('System_Collections_Generic_HashSet_long__Fields', 16),
        ('System_Collections_Generic_Dictionary_Entry_TKey__TValue__Fields', 0),
        ('System_Collections_Generic_HashSet_Slot_long__Fields', 0),
        ('System_Nullable_int__Fields', 0), ('System_String_Fields', 16)]:
        abi[name] = flat_cpp_layout(header, name, base)
    array = re.search(r'struct UnityMainThreadDispatcher_PendingAction_array \{([^}]+)\};', header)
    if not array or not re.fullmatch(r'\s*Il2CppObject obj;\s*Il2CppArrayBounds \*bounds;\s*il2cpp_array_size_t max_length;\s*UnityMainThreadDispatcher_PendingAction_o m_Items\[65535\];\s*', array[1]):
        raise ValueError('array ABI header changed')
    enums = []
    for path in sorted((old / 'cs/Assembly-CSharp').rglob('*.cs')):
        text = path.read_text('utf-8-sig')
        owner = '.'.join(path.relative_to(old / 'cs/Assembly-CSharp').with_suffix('').parts)
        for match in re.finditer(r'\benum\s+(\w+)[^{]*\{([^}]+)\}', text):
            name = owner if owner.rsplit('.', 1)[-1] == match[1] else owner + '.' + match[1]
            current = types.get(('Assembly-CSharp', name))
            export_identity = name
            if current is None and name != owner:
                # Dumper emits namespaced nested enums with an empty namespace
                # and a simple declaring owner. Require the exact parent plus
                # an uninterrupted run of its nested declarations in TypeDef order.
                short = owner.rsplit('.', 1)[-1] + '.' + match[1]
                parent = types.get(('Assembly-CSharp', owner))
                candidate = types.get(('Assembly-CSharp', short))
                if parent and candidate and candidate['index'] > parent['index']:
                    middle = [r for r in types.values() if r['image'] == 'Assembly-CSharp'
                              and parent['index'] < r['index'] <= candidate['index']]
                    if all(not r['namespace'] and r['name'].startswith(owner.rsplit('.', 1)[-1] + '.') for r in middle):
                        current, export_identity = candidate, short
            before = re.findall(r'\b(\w+)\s*=\s*([^,\r\n]+)', match[2])
            after = re.findall(r'public const \S+ (\w+) = ([^;]+);', current['text']) if current else None
            enums.append(dict(identity=name, export_identity=export_identity, old=before, new=after, equal=before == after))
    pe = pefile.PE(str(install / 'GameAssembly.dll'), fast_load=True)
    mapped = pe.get_memory_mapped_image()
    md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
    md.detail = True
    addresses = sorted(set(script['Addresses']))
    def body(name):
        row = unique(script['ScriptMethod'], name)
        start = row['Address']
        end = addresses[bisect.bisect_right(addresses, start)]
        rows = []
        for ins in md.disasm(pe.get_data(start, end - start), start):
            value = None
            for operand in ins.operands:
                if operand.type == capstone.CS_OP_MEM and operand.mem.base == capstone.x86.X86_REG_RIP:
                    rva = ins.address + ins.size + operand.mem.disp
                    if 0 <= rva <= len(mapped) - 4:
                        value = f'{struct.unpack_from("<f", mapped, rva)[0]:.6g}'
            rows.append(dict(rva=ins.address, mnemonic=ins.mnemonic, op=ins.op_str, float=value, bytes=ins.bytes.hex()))
        return dict(export=row, instructions=rows)
    previous = json.loads(Path(prior_geometry).read_text('utf-8'))
    geometry = []
    for name, export in [('MatchHudV2.SolveBoard', 'Poki.MatchHud.MatchHudV2$$SolveBoard'),
                         ('Board.GetCellBaseWorldPosition', 'Board$$GetCellBaseWorldPosition')]:
        prior = next(r for r in previous['method_comparisons'] if r['method'] == name)
        current = body(export)
        a, b = normalized_instructions(prior['new_instructions']), normalized_instructions(current['instructions'])
        geometry.append(dict(method=name, normalized_equal=a == b, old_count=len(a), new_count=len(b),
            differences=[dict(index=i, old=a[i] if i < len(a) else None, new=b[i] if i < len(b) else None)
                         for i in range(max(len(a), len(b))) if (a[i] if i < len(a) else None) != (b[i] if i < len(b) else None)],
            **current))
    hud = 'Poki.MatchHud.MatchHudV2'
    def const(text):
        rows = re.findall(r'public const (\w+) (\w+) = ([^;]+);', text)
        return {name: (float(value.rstrip('fFdD')) if kind == 'float' else
                       value.lower() if kind == 'bool' else value) for kind, name, value in rows}
    a = const((old / 'cs/Assembly-CSharp/Poki/MatchHud/MatchHudV2.cs').read_text('utf-8-sig'))
    b = const(types['Assembly-CSharp', hud]['text'])
    multiplier = body('Board$$GetDotMultiplier')
    if not any('[rbx + 0x88]' in r['op'] for r in multiplier['instructions']):
        raise ValueError('multiplier field load missing')
    return dict(mode='FILES_ONLY_NO_GAME_CALLS', consumed_field_types=field_types, libraries=library_changes,
        closed_abi=abi, array_abi=dict(length=24, data=32, declaration=array[0]), enums=enums,
        geometry=geometry, hud_constant_changes={k: dict(old=a.get(k), new=b.get(k)) for k in a.keys() | b.keys() if a.get(k) != b.get(k)},
        multiplier=multiplier, board_pixel_mapping_live_verified=False,
        limitations='Native normalization ignores external call targets; not whole-HUD or screen-pixel live equivalence.')


def main():
    p = argparse.ArgumentParser()
    for name in ('old', 'new', 'install', 'static', 'prior-geometry', 'output'):
        p.add_argument('--' + name, type=Path, required=True)
    args = p.parse_args()
    result = audit(args.old, args.new, args.install, args.static, args.prior_geometry)
    with args.output.open('x', encoding='utf-8') as stream:
        json.dump(result, stream, indent=2)
    print(json.dumps(dict(fields=len(result['consumed_field_types']),
        moved=sum(r['moved'] for r in result['consumed_field_types']), enums=len(result['enums']),
        changed_enums=[r['identity'] for r in result['enums'] if not r['equal']],
        geometry=[{k: r[k] for k in ('method', 'normalized_equal', 'old_count', 'new_count')} for r in result['geometry']],
        hud_constant_changes=result['hud_constant_changes'])))


if __name__ == '__main__':
    main()
