"""B14 native evidence from exact exports, installed files and readonly cache joins."""
import argparse,bisect,json,struct
from pathlib import Path
from tools.reverse_exports import dumper_script,unique
from tools.audit_game_update import sha


def audit(install,reverse,probe_path):
    import pefile
    from capstone import Cs,CS_ARCH_X86,CS_MODE_64
    from capstone.x86 import X86_OP_MEM,X86_OP_IMM,X86_REG_RIP
    install,reverse=Path(install),Path(reverse)
    script=dumper_script(str(reverse));probe=json.loads(Path(probe_path).read_text('utf-8'))
    game=pefile.PE(str(install/'GameAssembly.dll'),fast_load=True);unity=pefile.PE(str(install/'UnityPlayer.dll'),fast_load=True)
    md=Cs(CS_ARCH_X86,CS_MODE_64);md.detail=True
    def instructions(pe,start,size):
        return [dict(rva=i.address,bytes=i.bytes.hex(),mnemonic=i.mnemonic,op=i.op_str,
            rip_targets=[i.address+i.size+o.mem.disp for o in i.operands if o.type==X86_OP_MEM and o.mem.base==X86_REG_RIP],
            targets=[o.imm for o in i.operands if o.type==X86_OP_IMM] if i.mnemonic in ('jmp','call') else [])
            for i in md.disasm(pe.get_data(start,size),start)]
    anchors={}
    for name in ('UnityEngine.Component$$get_gameObject','UnityEngine.Component$$get_gameObject_Injected',
        'UnityEngine.Object.MarshalledUnityObject$$Unmarshal<__Canon>','Active$$get_Instance','Board$$get_Instance',
        'Board$$GetDotMultiplier','ChatService$$OnWebSocketMessage',
        'ChatService.<>c__DisplayClass324_0$$<OnWebSocketMessage>b__0'):
        row=unique(script['ScriptMethod'],name);start=row['Address'];addresses=sorted(set(script['Addresses']))
        end=addresses[bisect.bisect_right(addresses,start)]
        anchors[name]=dict(export=row,instructions=instructions(game,start,end-start))
    component=anchors['UnityEngine.Component$$get_gameObject']['instructions']
    load=next(r for r in component if r['rva']==0x34B714F)
    store=next(r for r in component if r['rva']==0x34B716C)
    if load['rip_targets']!=store['rip_targets'] or len(load['rip_targets'])!=1:raise ValueError('icall load/store mismatch')
    cache=load['rip_targets'][0]
    method='UnityEngine.Component$$get_gameObject_Injected'
    joined={r['unity_rva'] for r in probe['icalls'] if r['method']==method and r['cache_rva']==cache}
    if len(joined)!=1:raise ValueError('readonly component icall join ambiguous')
    component_unity=joined.pop()
    if not any(r['targets']==[unique(script['ScriptMethod'],'UnityEngine.Object.MarshalledUnityObject$$Unmarshal<__Canon>')['Address']]
        for r in component if r['mnemonic']=='jmp'):raise ValueError('managed wrapper tail mismatch')
    native_names=('UnityEngine.GameObject$$GetComponentsInternal','UnityEngine.GameObject$$get_transform_Injected',
        'UnityEngine.GameObject$$get_activeInHierarchy_Injected','UnityEngine.RectTransform$$get_rect_Injected',
        'UnityEngine.Transform$$GetParent_Injected','UnityEngine.Transform$$GetChild_Injected',
        'UnityEngine.Transform$$get_localPosition_Injected','UnityEngine.Transform$$get_localRotation_Injected',
        'UnityEngine.Transform$$get_localScale_Injected','UnityEngine.Canvas$$get_rootCanvas_Injected','UnityEngine.Canvas$$get_renderMode_Injected')
    native={}
    sizes={'UnityEngine.GameObject$$GetComponentsInternal':0x140}
    for name in (method,*native_names):
        candidates={r['unity_rva'] for r in probe['icalls'] if r['method']==name}
        if len(candidates)!=1:raise ValueError('uninitialized/ambiguous readonly native method '+name)
        start=candidates.pop()
        native[name]=dict(rva=start,instructions=instructions(unity,start,sizes.get(name,0xC0)))
    if not any(r['targets']==[0x12C2500] for r in native['UnityEngine.GameObject$$GetComponentsInternal']['instructions']):
        raise ValueError('component traversal helper not reached from exported icall')
    native['GetComponentsInternal.helper']=dict(rva=0x12C2500,instructions=instructions(unity,0x12C2500,0x400))
    active=native['UnityEngine.GameObject$$get_activeInHierarchy_Injected']['instructions'][0]
    if active['mnemonic']!='jmp' or active['targets']!=[0x16E94B0]:raise ValueError('active hierarchy tail mismatch')
    native['GameObject.activeInHierarchy.helper']=dict(rva=0x16E94B0,instructions=instructions(unity,0x16E94B0,0x80))
    signatures=[]
    selections=[
        ('component_owner',method,0x1197506,4,'rbx, qword ptr [rcx + 0x28]'),
        ('component_storage_stride','GetComponentsInternal.helper',0x12C265B,0x13,'rax, qword ptr [rbx + 0x28]'),
        ('component_pointer_entry','GetComponentsInternal.helper',0x12C2723,4,'rax, qword ptr [rdx + 8]'),
        ('managed_scripting_handle','UnityEngine.GameObject$$get_transform_Injected',0x119AF54,4,'rax, qword ptr [rbx + 0x20]'),
        ('first_transform_component','UnityEngine.GameObject$$get_transform_Injected',0x119AF46,14,'dword ptr [rcx + 0x38], 0'),
        ('active_cache','GameObject.activeInHierarchy.helper',0x16E94B6,16,'byte ptr [rcx + 0x4f], 0xff'),
        ('rect_dirty','UnityEngine.RectTransform$$get_rect_Injected',0x11AE12D,7,'byte ptr [rbx + 0xf9], 0'),
        ('rect_cache','UnityEngine.RectTransform$$get_rect_Injected',0x11AE149,7,'xmm0, xmmword ptr [rbx + 0xc0]'),
        ('transform_parent','UnityEngine.Transform$$GetParent_Injected',0x11AFBD6,4,'rbx, qword ptr [rcx + 0x70]'),
        ('transform_children','UnityEngine.Transform$$GetChild_Injected',0x11B1353,0x10,'edx, dword ptr [rcx + 0x60]'),
        ('transform_access','UnityEngine.Transform$$get_localPosition_Injected',0x11AF804,11,'rdi, qword ptr [r8 + 0x40]'),
        ('transform_trs_array_stride','UnityEngine.Transform$$get_localPosition_Injected',0x11AF835,0x1A,'eax, dword ptr [rdi + 8]'),
        ('transform_quaternion','UnityEngine.Transform$$get_localRotation_Injected',0x11AFA5B,5,'xmm0, xmmword ptr [rcx + rdx*8 + 0x10]'),
        ('transform_scale','UnityEngine.Transform$$get_localScale_Injected',0x11AFB4B,5,'xmm2, xmmword ptr [rcx + rdx*8 + 0x20]'),
        ('canvas_root','UnityEngine.Canvas$$get_rootCanvas_Injected',0xC36896,8,'qword ptr [rcx + 0x308], 0'),
        ('canvas_mode','UnityEngine.Canvas$$get_renderMode_Injected',0xC35D4E,3,'eax, dword ptr [rbx + 0x38]')]
    for role,name,rva,size,operand in selections:
        row=next((r for r in native[name]['instructions'] if r['rva']==rva),None)
        if row is None or row['op']!=operand:raise ValueError('native role not proven '+role)
        signatures.append(dict(role=role,method=name,rva=rva,signature=unity.get_data(rva,size).hex()))
    for name,offset in (('Active$$get_Instance',0),('Board$$get_Instance',0x10)):
        rows=anchors[name]['instructions']
        if not any(r['op']=='rax, qword ptr [rax + 0x98]' for r in rows):raise ValueError('static_fields ABI unproven')
    position=native['UnityEngine.Transform$$get_localPosition_Injected']['instructions']
    if not any(r['op']=='rcx, qword ptr [rax + 0x18]' for r in position):raise ValueError('new Transform TRS array offset unproven')
    producer=anchors['ChatService$$OnWebSocketMessage']['instructions']
    for name in ('ChatService.<>c__DisplayClass324_0_TypeInfo',):
        slot=unique(script['ScriptMetadata'],name)['Address']
        if not any(slot in r['rip_targets'] for r in producer):raise ValueError('closure producer missing slot '+name)
    signature_rva=0x1B52D4C;signature=game.get_data(signature_rva,0x18).hex()
    raw=(install/'GameAssembly.dll').read_bytes()
    if raw.count(bytes.fromhex(signature))!=1:raise ValueError('unmarshal signature not unique')
    return dict(mode='FILE_AND_READONLY_CACHE_EVIDENCE_NO_GAME_CALLS',game_sha256=sha(install/'GameAssembly.dll'),
        unity_sha256=sha(install/'UnityPlayer.dll'),component_cache_rva=cache,component_unity_rva=component_unity,
        class_static_fields_offset=0x98,transform_data_local_trs_offset=0x18,
        unmarshal_signature=[signature_rva,signature],native_signatures=signatures,
        anchors=anchors,unity_functions=native,
        caveat='Dumper generic Il2CppClass header is not the live static_fields ABI; native getter and readonly class proof take precedence')


def main():
    p=argparse.ArgumentParser();p.add_argument('--install',type=Path,required=True);p.add_argument('--reverse',type=Path,required=True)
    p.add_argument('--probe',type=Path,required=True);p.add_argument('--output',type=Path,required=True);a=p.parse_args()
    data=audit(a.install,a.reverse,a.probe)
    with a.output.open('x',encoding='utf-8') as stream:json.dump(data,stream,indent=2)
    print(json.dumps({k:v for k,v in data.items() if k not in ('anchors','unity_functions','native_signatures')}))


if __name__=='__main__':main()
