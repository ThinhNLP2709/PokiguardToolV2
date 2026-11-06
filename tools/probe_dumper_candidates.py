"""Bounded read-only verification of new export candidates before activation.

This never creates RuntimeTarget/input authority or calls any game method.
The installed file hashes, loaded PE header and selected method bytes must agree
before reading the named candidate slots. Only QUERY_INFORMATION|VM_READ.
"""
import argparse,bisect,json,struct
from pathlib import Path
from tools.audit_game_update import sha
from tools.reverse_exports import dumper_script,unique


def probe(pid,install,reverse,audit_path):
    import pefile
    from capstone import Cs,CS_ARCH_X86,CS_MODE_64
    from capstone.x86 import X86_OP_MEM,X86_REG_RIP
    from tools.process_probe import (kernel32,enumerate_modules,find_named_module,target_architecture,
        PROCESS_QUERY_INFORMATION,PROCESS_VM_READ,_close_handle)
    from pokiguard_v2.il2cpp_external import Win32RemoteMemory,is_canonical_user_pointer
    audit=json.loads(Path(audit_path).read_text('utf-8'));install=Path(install).resolve()
    for identity in audit['identities'][:4]:
        if sha(Path(identity['path']))!=identity['sha256']:raise ValueError('installed file changed')
    modules=enumerate_modules(pid);game=find_named_module(modules,'GameAssembly.dll');unity=find_named_module(modules,'UnityPlayer.dll')
    if game is None or unity is None or Path(game.path).resolve()!=install/'GameAssembly.dll':raise ValueError('wrong process modules')
    pe=pefile.PE(str(install/'GameAssembly.dll'),fast_load=True);script=dumper_script(str(reverse));addresses=sorted(set(script['Addresses']))
    access=PROCESS_QUERY_INFORMATION|PROCESS_VM_READ;handle=kernel32.OpenProcess(access,False,pid)
    if not handle:raise OSError('query/read-only OpenProcess failed')
    memory=Win32RemoteMemory(handle);md=Cs(CS_ARCH_X86,CS_MODE_64);md.detail=True
    try:
        header=memory.read(game.base,0x1000)
        loaded=pefile.PE(data=header,fast_load=True)
        if (loaded.FILE_HEADER.TimeDateStamp!=pe.FILE_HEADER.TimeDateStamp
            or loaded.OPTIONAL_HEADER.SizeOfImage!=pe.OPTIONAL_HEADER.SizeOfImage
            or game.size!=pe.OPTIONAL_HEADER.SizeOfImage):raise ValueError('loaded build differs from installed binary')
        for name in ('Active$$get_Instance','Board$$get_Instance','UnityEngine.Component$$get_gameObject'):
            rva=unique(script['ScriptMethod'],name)['Address']
            if memory.read(game.base+rva,64)!=pe.get_data(rva,64):raise ValueError('loaded method differs '+name)
        def cstring(pointer):
            if not is_canonical_user_pointer(pointer):return None
            return memory.read(pointer,128).split(b'\0')[0].decode('utf-8',errors='replace')
        roots=[]
        for row in audit['typeinfo']:
            value=struct.unpack('<Q',memory.read(game.base+row['new'],8))[0]
            item=dict(constant=row['constant'],rva=row['new'],value=value,status='UNINITIALIZED_OR_ENCODED')
            if is_canonical_user_pointer(value) and memory.is_readable(value,0xA0):
                raw=memory.read(value,0xA0)
                item.update(status='READABLE_CLASS',name=cstring(struct.unpack_from('<Q',raw,0x10)[0]),
                    namespace=cstring(struct.unpack_from('<Q',raw,0x18)[0]),static_fields=struct.unpack_from('<Q',raw,0x98)[0])
            roots.append(item)
        icalls=[]
        prefixes=('UnityEngine.Component$$','UnityEngine.GameObject$$','UnityEngine.Transform$$','UnityEngine.RectTransform$$','UnityEngine.Canvas$$','UnityEngine.Behaviour$$')
        for method in script['ScriptMethod']:
            if not method['Name'].startswith(prefixes):continue
            start=method['Address'];end=addresses[bisect.bisect_right(addresses,start)]
            code=pe.get_data(start,min(end-start,512))
            for instruction in md.disasm(code,start):
                if instruction.mnemonic!='mov':continue
                for operand in instruction.operands:
                    if operand.type!=X86_OP_MEM or operand.mem.base!=X86_REG_RIP or operand.size!=8:continue
                    slot=instruction.address+instruction.size+operand.mem.disp
                    if not 0<=slot<game.size-8:continue
                    pointer=struct.unpack('<Q',memory.read(game.base+slot,8))[0]
                    if unity.base<=pointer<unity.end:
                        icalls.append(dict(method=method['Name'],cache_rva=slot,load_rva=instruction.address,
                            unity_rva=pointer-unity.base,code=memory.read(pointer,96).hex()))
        return dict(mode='CANDIDATE_VERIFICATION_QUERY_READ_ONLY_NO_ACTION_AUTHORITY',pid=pid,access=access,
            architecture=target_architecture(handle),game=dict(path=game.path,base=game.base,size=game.size),
            unity=dict(path=unity.path,base=unity.base,size=unity.size),loaded_header_matches=True,roots=roots,icalls=icalls,
            input_sent=False,game_method_invoked=False,game_files_written=False)
    finally:_close_handle(handle)


def main():
    parser=argparse.ArgumentParser();parser.add_argument('--pid',type=int,required=True)
    parser.add_argument('--install',type=Path,required=True);parser.add_argument('--reverse',type=Path,required=True)
    parser.add_argument('--audit',type=Path,required=True);parser.add_argument('--output',type=Path,required=True)
    args=parser.parse_args();result=probe(args.pid,args.install,args.reverse,args.audit)
    with args.output.open('x',encoding='utf-8') as stream:json.dump(result,stream,indent=2)
    print(json.dumps(dict(pid=result['pid'],readable_classes=sum(r['status']=='READABLE_CLASS' for r in result['roots']),
        icalls=len(result['icalls']),input_sent=False)))


if __name__=='__main__':main()
