# Player stats resolution — Phase 2B

## Result

`ObfuscatedInt.Value` is now reconstructable from direct native evidence. A
read-only decoder is implemented in `src/pokiguard_v2/obfuscated_int.py` and is
used by the structurally validated `Active.playerStatsList` observer in
`src/pokiguard_v2/player_stats.py`.

No key, offset, rotate direction, or arithmetic operation is guessed.

## Exact layout

`ObfuscatedInt` is a 16-byte value type in `Assembly-CSharp`, global namespace:

| Field | Declared type | Inline offset |
|---|---|---:|
| `_stored` | `System.Int32` | `+0x0` |
| `_keyA` | `System.Int32` | `+0x4` |
| `_keyB` | `System.Int32` | `+0x8` |
| `_noise` | `System.Int32` | `+0xC` |

Declaration evidence:
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ObfuscatedInt.cs`.

## Proven getter and setter

The Cpp2IL ISIL/native body of `get_Value` reads `_stored`, rotates it right by
`_keyA & 31`, XORs `_keyB`, and subtracts `_keyA`, all with 32-bit wrapping:

```text
mixed = RotateRight32(_stored, _keyA & 31)
Value = int32((mixed XOR _keyB) - _keyA)
```

The constructor and setter independently prove the inverse:

```text
mixed = uint32(_keyA + value) XOR uint32(_keyB)
_stored = RotateLeft32(mixed, _keyA & 31)
```

Both generate fresh random `_keyA`, `_keyB`, and `_noise`. The getter never
reads `_noise`; the decoder therefore retains it for evidence/debugging but
does not use it.

Primary evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/ObfuscatedInt.txt`, methods
`.ctor(Int32)`, `get_Value`, `set_Value`, `RotateLeft`, `RotateRight`, and both
implicit conversions. The direct native call target for the getter is preferred
VA `0x18052FC80` (build RVA `0x52FC80`).

## Active.PlayerStats fields

`Active.playerStatsList : List<Active.PlayerStats>` is at `Active +0x28`.
`Active.SyncStatsListForInspector` directly proves this concrete list's native
layout in the current build: list `_items +0x10`, `_size +0x18`, `_version
+0x1C`; backing array length `+0x18` and first reference `+0x20`. The
`Active.PlayerStats` type-info global slot used by its allocation path is
preferred VA `0x18354A9B0`, build RVA `0x354A9B0`. The reader resolves that
slot ASLR-relatively and requires every list entry's exact class pointer to
match.

Each `Active.PlayerStats` object contains:

| Field | Type | Object offset | Decoded in Phase 2B |
|---|---|---:|---|
| `actorNumber` | `Int32` | `+0x10` | yes, plain |
| `currentHP` | `ObfuscatedInt` | `+0x14` | yes |
| `maxHP` | `ObfuscatedInt` | `+0x24` | yes |
| `currentMana` | `ObfuscatedInt` | `+0x34` | yes |
| `maxMana` | `ObfuscatedInt` | `+0x44` | yes |
| `currentPower` | `ObfuscatedInt` | `+0x54` | yes |
| `maxPower` | `ObfuscatedInt` | `+0x64` | yes |
| `attack` | `ObfuscatedInt` | `+0x74` | yes |
| `shield` | `ObfuscatedInt` | `+0x84` | yes |

Declaration evidence:
`reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/Active.cs`.
Native evidence:
`reverse/cpp2il_isil/IsilDump/Assembly-CSharp/Active.txt`,
`SyncStatsListForInspector` and `InitializeStatsFromWsSnapshot`.

The list reader validates canonical/readable pointers, size/capacity/version,
unique object pointers, stable list header across the read, unique actor
numbers, decoded maxima/ranges, and the PlayerStats class pointer. Any failure
returns no stats to `GameState`; it never substitutes zero.

## Ownership

The server boss actor is the exact declared constant `Active.WS_BOSS_ACTOR =
99`. In a match with exactly one non-boss `PlayerStats`, Phase 2B marks that
record local. If two or more non-boss actors exist, local ownership remains
`None`; the reader does not guess which co-op player is this account.

`MatchService.CurrentTurnPlayer` is a username string and is also read, but no
externally proven local-username anchor is available yet. Therefore the current
turn cannot authorize V2 input in Phase 2B.

## Tests and live validation

The unit suite covers signed/wrapping rotate/XOR/subtract behavior, independence
from `_noise`, single-player/boss decoding, and fail-safe co-op ownership.

The Phase 2B shadow capture in
`logs/phase2b_acceptance_v3.jsonl` produced 13 stable states through a complete
solo combat lifecycle. It observed player HP `32563/105228` at the end, exactly
matching the user's independent visible reading, and boss HP `0/84180`.
Fusion changed from unused to used, reported a 70% stat bonus and 160 Mana
cost, while player `maxHP` changed from `83385` to `105228`.

This validates the decoder and solo actor ownership for the captured build and
match type. Co-op ownership remains deliberately unresolved unless a future
external local-player identity anchor is proven.
