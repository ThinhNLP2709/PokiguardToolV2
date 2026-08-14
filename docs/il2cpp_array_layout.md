# `Board.allDots` IL2CPP array layout — Phase 2A

## Build-specific native evidence

`Board.allDots` is declared as `UnityEngine.GameObject[,]` at `Board + 0x140`.
Cpp2IL's native ISIL for `Dot.GetAllDots(col,row)` proves these accesses for the
current `GameAssembly.dll`:

| Array-relative offset | Native use | Status |
|---:|---|---|
| `+0x00` | managed object `Il2CppClass*` | standard header interpretation; runtime validated before use |
| `+0x08` | monitor pointer | standard header interpretation; dumped, never dereferenced |
| `+0x10` | bounds pointer | **CONFIRMED by native method** |
| `+0x18` | total/max length | **CONFIRMED by one-dimensional native array iteration and runtime probe requirement** |
| `+0x20` | first reference element | **CONFIRMED by native method** |

For a rectangular array, native `GetAllDots` reads:

```text
first_length  = *(uint64*)(bounds + 0x00)
second_length = *(uint64*)(bounds + 0x10)
linear_index  = col * second_length + row
element       = *(GameObject**)(array + 0x20 + linear_index * 8)
```

Therefore index order is no longer UNKNOWN for this build:
`index = column * 8 + row`. This is not inferred from parameter names; it is the
actual native address calculation at method RVA `0x5DBB40` (original token
`0x06001E4B`).

`BoardWsApplier.FindDotPrefabByTag` independently iterates the one-dimensional
`Board.dots` reference array using length at `+0x18` and element data at `+0x20`.

## Bounds records

The probe dumps the full 32 bytes addressed by the bounds pointer as four raw
qwords. Native code proves the dimension length qwords at `+0x00` and `+0x10`.
The helper interprets the intervening signed 32-bit values at `+0x08` and `+0x18`
as lower-bound candidates and records the padding words at `+0x0C/+0x1C`.

It only marks the runtime layout verified when all of these hold:

- array and bounds pointers are canonical, committed, and readable;
- dimension lengths are exactly `(8, 8)`;
- observed lower-bound candidates are `(0, 0)` and padding is zero;
- `max_length` is exactly `64`;
- all 64 element slots can be read from `+0x20`;
- every non-null element is a readable managed-object candidate.

Before those runtime checks pass, element enumeration is withheld (`elements:
null`) and the probe fails closed.

## Runtime evidence

`tools/all_dots_probe.py` writes:

- the 17 qwords from array offsets `0x00` through `0x80`;
- raw and interpreted bounds values;
- `max_length`;
- 64 indexed element pointers only after verification;
- NULL/readability status per pointer.

The 2026-08-11 capture is recorded in
`logs/phase2a_live_20260811.jsonl`. The array remained readable after combat, so
the exact same pointer was inspected again to retain the raw header evidence:

| Runtime item | Observed value |
|---|---|
| PID | `22260` |
| GameAssembly base | `0x00007FF810D90000` |
| Board during combat | `0x000001B07C71F000` |
| `Board.allDots` | `0x000001AF1C6FD2A0` |
| array class | `0x000001AE257F0F28` |
| bounds pointer | `0x000001AF1C6FD4C0` |
| max length at `+0x18` | `64` |
| bounds raw qwords | `[8, 0, 8, 0]` |
| interpreted dimensions | `(8, 8)` |
| interpreted lower bounds / padding | `(0,0)` / `(0,0)` |
| element slots | `64/64` non-null and `64/64` unique |

Raw array qwords `0x00..0x80` from that object:

```text
+0x00  0x000001AE257F0F28    +0x08  0x0000000000000000
+0x10  0x000001AF1C6FD4C0    +0x18  0x0000000000000040
+0x20  0x000001B07CD267C0    +0x28  0x000001B07CD26740
+0x30  0x000001AE673C5F00    +0x38  0x000001AE675B0300
+0x40  0x000001B07CF29C40    +0x48  0x000001AE678561C0
+0x50  0x000001AE674A7E60    +0x58  0x000001AE674A7E00
+0x60  0x000001B07CD263C0    +0x68  0x000001B07CD26320
+0x70  0x000001B07C1037E0    +0x78  0x000001AE673C5CC0
+0x80  0x000001AE673FC0E0
```

The first four qwords are the verified header. Qwords from `+0x20` onward are
element pointers, as independently proven by native code. This completes Phase
2A PASS 1 for the current build.

Primary evidence:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs:1013`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Dot.txt`, `GetAllDots`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/BoardWsApplier.txt`,
  `FindDotPrefabByTag`, `SpawnDotByTag`, and `VerifyBoardAgainstServer`
