# Chinh Phuc island and boss data correction — 2026-10-09

The b6 client and its live server catalog expose 19 islands and 178 bosses.
The old display table incorrectly treated `GroupDTO.id` as the serialized
`btnIsland` number. This mislabeled Khế Ước and omitted island labels for
both Liên Minh groups. Production boss names and levels already come from
`ChinhPhucDataService.Data`; there is no compiled boss-name allowlist to extend.

## Verified island association

| Server group ID | Runtime group index | Scene control | Display name |
|---:|---:|---|---|
| 18 | 16 | `btnIsland17` | Khế Ước |
| 20 | 17 | `btnIsland18` | Đảo Liên Minh |
| 25 | 18 | `btnIsland19` | Đảo Liên Minh II |

`GroupDTO.id` is an identity, while `group_index` is the position used by the
existing `ManagerChinhPhuc.buttons/panels` navigation. The display correction
does not change that association or any input authorization.

## New island boss rows

| Island | Order | Pet ID | Name | Display level |
|---|---:|---:|---|---:|
| Liên Minh | 1 | 2526 | Mumu | 350 |
| Liên Minh | 2 | 2532 | Shivana | 358 |
| Liên Minh | 3 | 2528 | Anie | 366 |
| Liên Minh | 4 | 2514 | Hecarime | 374 |
| Liên Minh | 5 | 2524 | JavIV | 382 |
| Liên Minh | 6 | 2534 | Rivan | 392 |
| Liên Minh II | 1 | 2555 | NightHunter | 358 |
| Liên Minh II | 2 | 2543 | Abysswalker | 366 |
| Liên Minh II | 3 | 2557 | Ghostblade | 374 |
| Liên Minh II | 4 | 2561 | Wukong | 382 |
| Liên Minh II | 5 | 2545 | Judicator | 390 |
| Liên Minh II | 6 | 2422 | Skyflare | 400 |

Names retain exact server spelling. All twelve rows have internal `lever=12`;
the desktop label must use `leverDisplay` instead.

The full reference snapshot is
[chinh_phuc_boss_catalog_b6_20261009.json](data/chinh_phuc_boss_catalog_b6_20261009.json).
It contains two identical independent catalog reads, unique pet IDs, scene
label provenance and the accepted GameAssembly hash. Account-specific lock
and progress fields are omitted. This snapshot is documentation, not runtime
navigation or action authority; production still reads current game data.

## Rivan room diagnosis

The user confirmed that the reported Rivan room belongs to another player.
The read-only live probe independently resolved pet `2534`, name `Rivan`,
display level `392`, group `20`, index `17`, order `6`. Room membership also
reported `is_host=false`.

`read_chinh_phuc_room` currently requires local-host ownership to declare a
clean, actionable boss lobby. A guest room therefore cannot arm the existing
farm Start contract. This is separate from missing island display data.
During the later probe the user had entered combat; destroyed lobby objects
at that point are not evidence of a Rivan-specific layout defect. The earlier
guest-lobby screen was not reproduced by this change.

This update preserves the host gate, room classification, Start, memory-read
order, capture order, navigation, combat and reasoning behavior. Farming in
another player's room is not enabled by this data correction. Phase 5B.3
remains paused.

## Changes and verification

- Correct server IDs for the final three island display names.
- For an unknown group ID, display the current server group name instead of
  leaving the label blank; no inferred ID or navigation target is created.
- Re-read target metadata for all 18 bosses in groups 18/20/25 and island
  metadata at indices 16/17/18: PASS.
- Existing focused map, desktop runtime, room and boss-entry suites: 77/77 PASS.
- No game memory writes, game-method calls or Windows input were performed.
- No release executable was rebuilt or launched.

## Evidence

- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/GroupDTO.cs`: `id +0x10`,
  `name +0x18`, `listPetEnemy +0x20`.
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/PetEnemyDTO.cs`: `id +0x10`,
  `name +0x18`, `lever +0x20`, `leverDisplay +0x24`.
- `reverse/reverse_1.7.4-b6/cs/Assembly-CSharp/ChinhPhucDataService.cs`:
  current server `Data +0x20`.
- Read-only installed `PetPuzzle-1.7.4_Data/level2` inspection: GameObjects
  888/376/759 own `btnIsland17/18/19`; child Text components
  7140/7359/7470 hold the three labels above.
- Scene SHA-256:
  `3bdd240e6896391a23350ee509005c1932a4c06f99fd62e46f4e8be41f70dd4b`.
- Accepted b6 GameAssembly SHA-256:
  `72d10a43fbfdab705e2db7caca1cc2b998b0b8581d56946dc545d87c720ec063`.

## Follow-up — 2026-10-10

The host-only restriction described in this report was subsequently relaxed
for Bú win + Coop at the user's request. See
[guest-room implementation and verification](bu_win_guest_room_20261010.md).
The island/catalog corrections above are unchanged.
