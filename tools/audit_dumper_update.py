"""File-only Inspector -> Il2CppDumper compatibility audit, no activation."""
import argparse,ast,bisect,json,re,struct
from pathlib import Path
from tools.audit_game_update import address_map,PREFIXES,sha
from tools.reverse_exports import (dumper_types,dumper_script,inspector_fields,inspector_type_name,
    normalized_type,unique,field_name)


def compare_fields(a,b):
    if a is None or b is None:return dict(equal=False,error='EXPORT_FIELD_NAMES_AMBIGUOUS')
    diff={name:dict(old=a.get(name),new=b.get(name)) for name in a.keys()|b.keys()
        if name not in a or name not in b or a[name]['offset']!=b[name]['offset']
        or normalized_type(a[name]['type'])!=normalized_type(b[name]['type'])}
    return dict(equal=not diff,changes=diff)


def audit(old,new,source,install):
    import pefile
    old,new,source,install=map(Path,(old,new,source,install))
    script=dumper_script(str(new));types=dumper_types(str(new));prior=address_map(old)
    old_roots={int(r['virtualAddress'],16)-0x180000000:r for r in prior['typeInfoPointers']}
    callback=[r for r in script['ScriptMethod'] if re.fullmatch(r'ChatService\.<>c__DisplayClass\d+_0\$\$<OnWebSocketMessage>b__0',r['Name'])]
    if len(callback)!=1:raise ValueError('websocket closure role is ambiguous')
    closure=callback[0]['Name'].split('$$')[0]
    roots=[];offsets=[]
    for path in sorted(source.glob('*.py')):
        for node in ast.walk(ast.parse(path.read_bytes())):
            if not isinstance(node,ast.Assign) or not isinstance(node.value,ast.Constant) or type(node.value.value)is not int:continue
            name,value=ast.unparse(node.targets[0]),node.value.value
            if value in old_roots:
                symbol=old_roots[value];full=inspector_type_name(symbol)
                renamed=full=='ChatService.<>c__DisplayClass321_0'
                target=closure if renamed else full
                meta_name={'System.Int32':'int','System.Int64':'long','System.String':'string'}.get(target,target)+'_TypeInfo'
                row=unique(script['ScriptMetadata'],meta_name)
                roots.append(dict(module=path.name,constant=name,old=value,new=row['Address'],
                    old_identity=full,new_identity=target,export=row,closure_role_changed=renamed))
            if not name.endswith('_OFFSET'):continue
            prefix=next((p for p in sorted(PREFIXES,key=len,reverse=True) if name.startswith(p)),None)
            if not prefix:continue
            cls=PREFIXES[prefix];prior_path=old/'cs/Assembly-CSharp'/(cls+'.cs')
            key=('Assembly-CSharp',cls.replace('/','.'))
            if not prior_path.exists() or key not in types:continue
            a=inspector_fields(prior_path);b=types[key]['fields']
            candidates=[n for n,v in a.items() if v['offset']==value and 'static 'not in v['type']]
            if len(candidates)!=1:continue
            member=candidates[0];v=None if b is None else b.get(member)
            offsets.append(dict(module=path.name,constant=name,klass=key[1],field=member,old=a[member],new=v,
                equal=v is not None and v['offset']==value and normalized_type(v['type'])==normalized_type(a[member]['type'])))
    libraries=[]
    # The reviewed b12 coverage list is input provenance, not b14 authority.
    liblist=json.loads((old.parent.parent/'docs/artifacts/game_1_7_4_b12_20261026/native_layout_evidence.json').read_text('utf-8'))['library_layouts']
    for item in liblist:
        rel=Path(item['file']);image=rel.parts[0]
        full='.'.join(rel.with_suffix('').parts[1:]).replace('[','<').replace(']','>')
        keys=[k for k in types if k[0]==image and normalized_type(k[1])==normalized_type(full)]
        if len(keys)!=1:raise ValueError('library type not unique '+str(rel))
        row=types[keys[0]];libraries.append(dict(file=rel.as_posix(),identity=keys[0],
            **compare_fields(inspector_fields(old/'cs'/rel),row['fields'])))
    nested=[]
    for old_file,old_class,new_class in [('Active.cs','PlayerStats','Active.PlayerStats'),
        ('ChatService.cs','__c__DisplayClass321_0',closure)]:
        nested.append(dict(old_file=old_file,old_class=old_class,new_identity=new_class,
            **compare_fields(inspector_fields(old/'cs/Assembly-CSharp'/old_file,nested=old_class),types[('Assembly-CSharp',new_class)]['fields'])))
    changes=[]
    for path in sorted((old/'cs/Assembly-CSharp').rglob('*.cs')):
        full='.'.join(path.relative_to(old/'cs/Assembly-CSharp').with_suffix('').parts)
        row=types.get(('Assembly-CSharp',full))
        if row is None:continue
        comparison=compare_fields(inspector_fields(path),row['fields'])
        if not comparison['equal']:changes.append(dict(identity=full,**comparison))
    pe=pefile.PE(str(install/'GameAssembly.dll'))
    files=[install/'GameAssembly.dll',install/'UnityPlayer.dll',install/'PetPuzzle-1.7.4.exe',
        install/'PetPuzzle-1.7.4_Data/il2cpp_data/Metadata/global-metadata.dat',new/'dump.cs',new/'script.json',new/'il2cpp.h']
    identity=[dict(path=str(p.resolve()),bytes=p.stat().st_size,sha256=sha(p)) for p in files]
    metadata=files[3].read_bytes()[:8]
    return dict(mode='FILES_ONLY_NO_INPUT_NO_GAME_WRITES',format='Il2CppDumper',identities=identity,
        pe=dict(machine=pe.FILE_HEADER.Machine,timestamp=pe.FILE_HEADER.TimeDateStamp,
            image_base=pe.OPTIONAL_HEADER.ImageBase,size_of_image=pe.OPTIONAL_HEADER.SizeOfImage),
        metadata_header=list(struct.unpack('<II',metadata)),
        app_info=(install/'PetPuzzle-1.7.4_Data/app.info').read_text('utf-8'),
        typeinfo=roots,offset_candidates=offsets,library_layouts=libraries,nested=nested,
        closure_callback=callback[0],top_level_layout_changes=changes,
        opaque_export_types=[dict(image=r['image'],name=r['name'],error=r['fields_error']) for r in types.values() if r['fields_error']],
        imports=[dict(dll=i.dll.decode(),names=[v.name.decode() if v.name else str(v.ordinal) for v in i.imports]) for i in getattr(pe,'DIRECTORY_ENTRY_IMPORT',[])])


def main():
    parser=argparse.ArgumentParser();parser.add_argument('--old',type=Path,required=True);parser.add_argument('--new',type=Path,required=True)
    parser.add_argument('--source',type=Path,default=Path('src/pokiguard_v2'));parser.add_argument('--install',type=Path,required=True)
    parser.add_argument('--output',type=Path,required=True);a=parser.parse_args()
    result=audit(a.old,a.new,a.source,a.install);a.output.parent.mkdir(parents=True,exist_ok=True)
    with a.output.open('x',encoding='utf-8') as stream:json.dump(result,stream,indent=2,ensure_ascii=False)
    print(json.dumps(dict(typeinfo=len(result['typeinfo']),fields=len(result['offset_candidates']),
        moved_fields=sum(r['new'] is not None and r['old']['offset']!=r['new']['offset'] for r in result['offset_candidates']),
        changed_library_count=sum(not r['equal'] for r in result['library_layouts']),
        opaque_types=len(result['opaque_export_types']),metadata=result['metadata_header']),ensure_ascii=False))


if __name__=='__main__':main()
