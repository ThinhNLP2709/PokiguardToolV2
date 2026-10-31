"""Fresh BASIC disabled resource probe; no import of any reasoning module."""
import argparse
import ctypes
from ctypes import wintypes
import hashlib
import json
import os
from pathlib import Path
import sys
import tempfile
import threading
import time

ROOT=Path(__file__).resolve().parents[1]
for directory in (ROOT,ROOT/'src'):
    if str(directory) not in sys.path:sys.path.insert(0,str(directory))
from tests.reasoning_controller_fixture import controller_trace


class Memory(ctypes.Structure):
    _fields_=[('cb',wintypes.DWORD),('PageFaultCount',wintypes.DWORD)]+[(n,ctypes.c_size_t) for n in
        ('PeakWorkingSetSize','WorkingSetSize','QuotaPeakPagedPoolUsage','QuotaPagedPoolUsage',
         'QuotaPeakNonPagedPoolUsage','QuotaNonPagedPoolUsage','PagefileUsage','PeakPagefileUsage','PrivateUsage')]


def resources():
    kernel=ctypes.WinDLL('kernel32',use_last_error=True)
    psapi=ctypes.WinDLL('psapi',use_last_error=True)
    kernel.GetCurrentProcess.restype=wintypes.HANDLE
    psapi.GetProcessMemoryInfo.argtypes=(wintypes.HANDLE,ctypes.POINTER(Memory),wintypes.DWORD)
    kernel.GetProcessTimes.argtypes=(wintypes.HANDLE,)+(ctypes.POINTER(wintypes.FILETIME),)*4
    handle=kernel.GetCurrentProcess();memory=Memory();memory.cb=ctypes.sizeof(memory)
    if not psapi.GetProcessMemoryInfo(handle,ctypes.byref(memory),memory.cb):
        raise ctypes.WinError(ctypes.get_last_error())
    stamps=[wintypes.FILETIME() for _ in range(4)]
    if not kernel.GetProcessTimes(handle,*(ctypes.byref(s) for s in stamps)):
        raise ctypes.WinError(ctypes.get_last_error())
    return dict(private_bytes=memory.PrivateUsage,
        cpu_ns=sum((s.dwHighDateTime<<32)+s.dwLowDateTime for s in stamps[2:])*100)


def main():
    parser=argparse.ArgumentParser();parser.add_argument('--out',type=Path,required=True)
    parser.add_argument('--seconds',type=int,default=30);args=parser.parse_args()
    if args.out.exists():raise SystemExit('Frozen output exists')
    args.out.mkdir(parents=True)
    sources={p.relative_to(ROOT).as_posix():hashlib.sha256(p.read_bytes()).hexdigest()
        for base in ('src','tools','tests') for p in sorted((ROOT/base).rglob('*.py'))}
    def dump(name,value):
        (args.out/name).write_text(json.dumps(value,indent=2)+'\n',encoding='utf-8')
    dump('protocol.json',dict(seconds=args.seconds,cadence_s=.1,workload='actual BASIC controller Stop, shadow_adapter default None',
        interpretation='absolute main CPU upper bounds added cost; memory conservative peak after BASIC imports; no AI modules/resources',
        logical_cpus=os.cpu_count(),source_files=sources,game_attach=False,native_input=False))
    assert not any(n.startswith('pokiguard_v2.reasoning_') for n in sys.modules)
    before=resources();peak=before['private_bytes'];threads=set(threading.enumerate());trials=0
    start=time.perf_counter()
    with tempfile.TemporaryDirectory() as temp,(args.out/'raw.jsonl').open('w',encoding='utf-8',buffering=1) as raw:
        path=Path(temp)/'common.jsonl'
        while time.perf_counter()-start<args.seconds:
            result,calls,rows=controller_trace(path,case='stop');path.unlink()
            assert result==0 and rows[-1]['totalInputs']==0
            assert 'provider.poll' not in calls and 'capture.modal' not in calls and 'FAKE_NORMAL_INPUT' not in calls
            assert set(threading.enumerate())==threads
            assert not any(n.startswith('pokiguard_v2.reasoning_') for n in sys.modules)
            current=resources();peak=max(peak,current['private_bytes']);trials+=1
            raw.write(json.dumps(dict(trial=trials,elapsed_s=time.perf_counter()-start,resources=current,
                calls=calls,AI_modules=0,AI_threads=0,AI_jobs=0,AI_files=0))+'\n')
            time.sleep(max(0,start+trials*.1-time.perf_counter()))
    after=resources();elapsed=time.perf_counter()-start
    cpu=(after['cpu_ns']-before['cpu_ns'])/1e9/elapsed/(os.cpu_count() or 1)*100
    memory=peak-before['private_bytes']
    dump('result.json',dict(trials=trials,elapsed_s=elapsed,main_CPU_host_pp_upper_bound=cpu,
        main_added_private_bytes=memory,AI_modules=0,AI_threads=0,AI_jobs=0,AI_files=0,
        extra_reads=0,extra_captures=0,passed=cpu<=1 and memory<=8*1024**2))


if __name__=='__main__':main()
