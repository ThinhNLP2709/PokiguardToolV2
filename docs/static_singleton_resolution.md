# Pokiguard static singleton resolution (Phase 1.5)

## Scope and build binding

This document describes an **external, read-only** resolution path for the exact
Pokiguard build currently present in `D:\pc`. It does not call IL2CPP exports,
execute game methods, inject code, scan all RAM, or write target memory.

| Artifact | Value |
|---|---|
| Unity | 6000.0.26f1 |
| Architecture | PE32+ x86-64 |
| Preferred PE image base | `0x180000000` |
| `GameAssembly.dll` file size | 61,267,968 bytes |
| `GameAssembly.dll` SHA-256 | `5A993B8AEF2371F6053AA46C692592CE32FF8418071E85357541F7FB504D58B3` |
| `global-metadata.dat` size | 14,576,856 bytes |
| `global-metadata.dat` SHA-256 | `C9EC5627AA074066190BCF1E6F1F592A9C7DFD0ADCDD2A5B1F4B4B7DF5216085` |
| Metadata header / actual layout | 31 / 31.1 |

All RVAs below are build-specific. They must be added to the current runtime
`GameAssembly.dll` base because ASLR changes the base between processes.

## Cpp2IL registration evidence

Cpp2IL 2022.1.0-pre-release.21 analyzed the files in `D:\pc` and reported:

| Structure | Preferred VA | RVA (`VA - 0x180000000`) | Confidence |
|---|---:|---:|---|
| `Il2CppCodeRegistration` | `0x182AD1100` | `0x2AD1100` | HIGH (Cpp2IL binary search) |
| `Il2CppMetadataRegistration` | `0x1830AEC50` | `0x30AEC50` | HIGH (Cpp2IL binary search) |

The Phase 1.5 resolver does not need to traverse either registration structure.
The native singleton accessors expose a shorter and more directly evidenced
anchor: one GameAssembly global type-info slot per target type.

## Proven access pattern

For this build, Cpp2IL's native disassembly of `Board.get_Instance` is equivalent
to:

```text
type_info_slot = GameAssembly.base + 0x3508B28
klass = *(void**)type_info_slot
static_fields = *(void**)(klass + 0xB8)
instance = *(Board**)(static_fields + 0x10)
```

The accessor itself first calls `il2cpp_codegen_initialize_runtime_metadata` and
may call the class initializer. An external reader **must not reproduce those
calls**. It only reads the slot. Before game code initializes that metadata usage,
the slot can contain `NULL` or an encoded/non-pointer value; the resolver treats
that state as unavailable and does not dereference it.

The `+0xB8` value is not guessed from a generic Unity layout. It is the exact
member access emitted in all three target methods in this build. The code labels
it as `Il2CppClass.static_fields` because the next native access is the verified
static field offset from the Cpp2IL model.

## Target anchors

### Board.Instance

| Property | Finding |
|---|---|
| Assembly / namespace / type | `Assembly-CSharp` / global namespace / `Board` |
| Original TypeDef token | `0x020003A5` (Cpp2IL `TokenAttribute`) |
| Dummy DLL TypeDef token | `0x0200019B` (output-only token; not used at runtime) |
| IL2CPP zero-based type-definition index | **UNKNOWN**; no index is needed by the selected anchor strategy |
| Native evidence method | `Board.get_Instance`, original method token `0x06001BE3` |
| Method RVA | `0x5B25C0` (`AddressAttribute`, length `0x4F`) |
| Global type-info preferred VA | `0x183508B28` |
| Global type-info RVA | `0x3508B28` |
| `Il2CppClass -> static_fields` | instance pointer at `+0xB8` |
| Static field | `<Instance>k__BackingField`, original token `0x04001B4C` |
| Offset inside static-fields block | `+0x10` |
| Confidence | **HIGH**, exact native getter, setter, and `Awake` all use this chain |

Evidence:

- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Board.txt`, method
  `Board get_Instance()` (lines 24 onward): loads `[0x183508B28]`, then
  `[klass+0xB8]`, then `[static_fields+0x10]`.
- The same file, `set_Instance(Board value)` and `Awake()`, writes through the
  same slot and offsets.
- `reverse/cpp2il_attributed/Assembly-CSharp.dll`: Cpp2IL injected the original
  token and native `AddressAttribute` values listed above.
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Board.cs`: declares the singleton
  and its `+0x10` static field offset.

### Active.Instance

| Property | Finding |
|---|---|
| Assembly / namespace / type | `Assembly-CSharp` / global namespace / `Active` |
| Original TypeDef token | `0x0200037F` |
| Dummy DLL TypeDef token | `0x02000187` |
| IL2CPP zero-based type-definition index | **UNKNOWN** |
| Native evidence method | `Active.get_Instance`, original method token `0x06001B08` |
| Method RVA | `0x56B350` (`AddressAttribute`, length `0x4E`) |
| Global type-info preferred VA | `0x1834FADB0` |
| Global type-info RVA | `0x34FADB0` |
| `Il2CppClass -> static_fields` | `+0xB8` |
| Static field | `<Instance>k__BackingField`, original token `0x0400199B` |
| Offset inside static-fields block | `+0x00` |
| Cross-check field | `Active.board` at instance `+0x38`; declared type `Board` |
| Confidence | **HIGH**, exact getter, setter, and `Awake` agree |

Evidence:

- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt`, method
  `Active get_Instance()` (lines 1875 onward): `[0x1834FADB0] -> +0xB8 -> +0x00`.
- The same file, `set_Instance` and `Awake`, writes through the same chain.
- `reverse/cpp2il_attributed/Assembly-CSharp.dll` and
  `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Active.cs`.

### ManagerMatch.Instance

`ManagerMatch.Instance` is a public static field rather than a property in the
recovered C# output, so `Awake` is the strongest direct native evidence.

| Property | Finding |
|---|---|
| Assembly / namespace / type | `Assembly-CSharp` / global namespace / `ManagerMatch` |
| Original TypeDef token | `0x02000498` |
| Dummy DLL TypeDef token | `0x020001EC` |
| IL2CPP zero-based type-definition index | **UNKNOWN** |
| Native evidence method | `ManagerMatch.Awake`, original method token `0x060022B3` |
| Method RVA | `0x624DD0` (`AddressAttribute`, length `0xC6`) |
| Global type-info preferred VA | `0x183560A90` |
| Global type-info RVA | `0x3560A90` |
| `Il2CppClass -> static_fields` | `+0xB8` |
| Static field | `ManagerMatch.Instance`, original token `0x0400210D` |
| Offset inside static-fields block | `+0x00` |
| Candidate link to combat | `ManagerMatch.active` instance field `+0x130`, type `Active` |
| Confidence | **HIGH** for Instance resolution; **MEDIUM** as a Board ownership route |

Evidence:

- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ManagerMatch.txt`, `Awake()`
  (lines 399 onward): loads `[0x183560A90]`, gets `[klass+0xB8]`, reads
  `[static_fields+0]`, and later writes `this` to the same location.
- `reverse/cpp2il_attributed/Assembly-CSharp.dll` and
  `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerMatch.cs`.

## Runtime validation result

A full lobby -> combat -> lobby cycle was captured read-only on 2026-08-11. The
initial one-shot sample is in `logs/phase15_live_probe.jsonl`; the complete
winning-match timeline is in `logs/runtime_board_watch_20260811_174818.jsonl`.

| Runtime item | Observed value |
|---|---|
| PID | 28344 |
| Target architecture | x64 |
| `GameAssembly.dll` runtime base | `0x00007FFD443B0000` |
| Runtime module image size | `0x3D2B000` (64,139,264 bytes) |
| Board type-info slot | `0x00007FFD478B8B28` |
| Board class / static fields | `0x00000272D06EAE50` / `0x0000027386E5FA50` |
| `Board.Instance` | `NULL` (expected in lobby) |
| Active type-info slot | `0x00007FFD478AADB0` |
| Active class / static fields | `0x00000272D1E85A70` / `0x00000274E5B7AEC0` |
| `Active.Instance` | `NULL` (expected in lobby) |
| ManagerMatch type-info slot | `0x00007FFD47910A90` |
| ManagerMatch class / static fields | `0x00000272D208D780` / `0x00000274B186D250` |
| `ManagerMatch.Instance` | `NULL` (expected in lobby) |

The watcher then recorded these transitions without any extra combat-time command:

| UTC time | Event | Result |
|---|---|---|
| `10:48:18.742` | `board_absent` | All three singleton instances `NULL` in lobby |
| `10:53:19.695` | `board_found` | Board `0x00000274E5B96540`, dimensions 8x8, non-null `allDots`, all cross-checks true |
| `10:53:19.827` | `board_state` | Same Board changed `isBoardReady: false -> true` |
| `10:58:33.506` | `board_lost` | Board, Active, and ManagerMatch instances returned to `NULL` after the match |

Combat pointers and invariants:

| Runtime item | Observed value |
|---|---|
| `Board.Instance` | `0x00000274E5B96540` |
| `Board.allDots` | `0x00000274E5AB6540` |
| `Active.Instance` | `0x00000274B6873540` |
| `Board.active` | `0x00000274B6873540` (matches `Active.Instance`) |
| `Active.board` | `0x00000274E5B96540` (matches `Board.Instance`) |
| `ManagerMatch.Instance` | `0x0000027385EDA000` |
| Board dimensions | 8x8 |
| Read/candidate errors | none |

This completes the strong Phase 1.5 acceptance criteria for the current hashed
build: all three ASLR-relative anchors, a lobby-null lifecycle, automatic combat
detection, non-null `allDots`, and the bidirectional Board/Active cross-check were
observed live.

## Watcher validation and fail-closed policy

`tools/board_instance_watch.py` polls at 8 Hz by default and validates every
dereference with `VirtualQueryEx` before `ReadProcessMemory`. It requests only
`PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`.

When `Board.Instance` becomes non-null, these exact recovered fields are read:

| Field | Declared type | Instance offset | Acceptance check |
|---|---|---:|---|
| `width` | `System.Int32` | `+0x88` | equals 8 |
| `height` | `System.Int32` | `+0x8C` | equals 8 |
| `allDots` | `UnityEngine.GameObject[,]` | `+0x140` | non-null canonical readable object |
| `active` | `Active` | `+0x158` | if both instances exist, equals `Active.Instance` |
| `isCascadeRunning` | `System.Boolean` | `+0x170` | byte must be exactly 0 or 1 |
| `isBoardReady` | `System.Boolean` | `+0x348` | byte must be exactly 0 or 1 |

If `Active.Instance` is non-null, `*(Active.Instance + 0x38)` must equal the Board
candidate. A mismatch is logged as `board_candidate_rejected`; it is never
published as `board_found`.

The watcher logs only transitions: initial absence, candidate rejection,
`board_found`, changed board state, `board_lost`, read error, and process exit.
Polling itself does not produce repetitive JSONL rows.

## Remaining UNKNOWNs and limitations

- The IL2CPP internal zero-based type-definition indices were not independently
  reconstructed. Original TypeDef tokens are verified, but subtracting one from a
  metadata row was not needed and is deliberately not used as an assumed index.
- The global slot RVAs are tied to the SHA-256 build above. A game update requires
  re-running Cpp2IL and re-verifying all anchors; the watcher currently does not
  hash the remote module automatically.
- No `GameObject[,]` element layout or gem structure is read in Phase 1.5.
- No full-RAM structural Board scanner was implemented because the direct static
  path now has sufficient evidence.

## Phase 1.5 resolution ranking

1. **Board type-info slot -> static fields -> Board.Instance**: selected and
   implemented. Shortest direct chain, high-confidence native getter evidence,
   ASLR-safe module-relative anchor.
2. **Active type-info slot -> Active.Instance -> Active.board**: implemented as an
   independent cross-check. Slightly longer but also backed by an exact native
   getter.
3. **ManagerMatch type-info slot -> ManagerMatch.Instance -> active -> board**:
   retain as a diagnostic fallback. Instance resolution is proven, but the longer
   ownership chain is more scene-lifecycle dependent and is not used to accept a
   Board in Phase 1.5.
