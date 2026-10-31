# PetPuzzle b10 compatibility update — 2026-10-22

Latest successor: [v1.2.7 released](v1.2.7_release_report.md), including b10
adaptation, configurable Demon target and effective Sword threshold. Its
separate latest live2 completed WIN2/2 on Darksoul lv100, Health/BASIC. The
B1/B2/source and unbuilt-package statements below describe the original
migration checkpoint, not the successor release or E1 acceptance.

This report and B1 evidence describe migration source `b338383…`. The subsequent
user-requested [Demon Farm target setting](demon_target_gem_update_20261022.md)
is a separate intentional gameplay change; the constant-only claims below do
not describe that later source or grant it the B1 historical source identity.

**Source migration complete;95 focused tests PASS; full regression executed;
4 historical assertion repairs retested111/111 PASS; live B1 WIN1/1, B2 PENDING.**
User asked to adapt b10 after the old v1.2.6 package reported INCOMPATIBLE_BUILD.
This side branch leaves the main E1 holdout at0 attempts. One user-started
BASIC compatibility match completed; no package build or release performed.

## Cause and exact change

GameAssembly changed from1.7.4.9 SHA4a8925ce... to
`9bedce81bfdeae1d3f749a5244c0288f1891e658f992eb27c31ee874a9b79777`;
metadata also changed. Launcher/UnityPlayer remain byte-identical. Full
identity and reverse hashes: [static_audit.json](artifacts/game_1_7_4_b10_audit_20261022/static_audit.json).
The previous hash gate correctly blocked this new binary.

All38 production TypeInfo slots moved (different deltas). Migrated exact
symbol/type matches in il2cpp_external, boss_lobby_runtime, chinh_phuc_map,
opening_snapshot. Updated native_card_ui cache0x3F72288 and26B unmarshal
signature at0x191413F. game_location admits only the new verified hash; it
rejects both1.7.4.9 andb6 rather than mixing different tables under one gate.

Only6 production modules changed, and their executable functions/classes are
AST-identical except the reviewed constant values. No other src/tools file
changed. In particular solver,PlayStyle/reasoning,provider,normal input,
calibration,jitter,ACK,QTE,Stop,farm,recovery and preferences remain intact.
App version staysv1.2.6. Old packaged ZIP/EXE still contains1.7.4.9 tables;
source changes do not modify that package or files in the game installation.

## Verified evidence and limits

- 38 Inspector symbols matched;256 mapped read-field candidates keep offsets.
- 28 library layout comparisons equal, including collections/Newtonsoft/UnityUI.
- Nested Active.PlayerStats and ChatService closure321_0 fields remain equal.
- 7 game classes have top-level field changes:ChinhPhucArenaHud,ManagerGame,
 ManagerRoom,CupFlow,CupMatchGo,RemoteFlags,WsRoomService. Changed event and map
 HUD fields are not read by the current reader; do not claim all game logic
 or all fields unchanged. ManagerRoom energy changed name at the same+0xF8;
 this is not a verified primary energy telemetry source for E1.
- Native file disassembly ties getter cache load/store to0x3F72288; its tail
 reaches the exact exported unmarshal function. New prefix retains26-byte
 coverage and GCHandle branch semantics. Old signature at old RVA fails.
- UnityPlayer hash unchanged,15/15 native code signatures pass. Live readonly
 NativeCardUiReader constructor also validated the module and signatures.
- Read-only narrow slot inspection resolved37class names; AuditionChallenge
 remained uninitialized (not forced). No heap scan or method invocation.
- Existing read-only desktop adapter read3 error-free BOSS_LOBBY observations:
 Pharapo2597/lv432,Đảo Cổ Đại,guest Coop_375557. A later separate snapshot
 reported no room/lobby-other; it is preserved separately, not relabelled as
 another successful room observation. No Stop/Start/focus or gameplay input.

Current b10 B1 exercised entry, a complete64-cell opening, one swap, strong
terminal WIN, one result confirm and normal return to BOSS_LOBBY. Keep the
accepted board mapping and +-10% jitter. One-turn victory does not cover
nonterminal ACK/next-turn board, skill/QTE, pass or error re-entry. Historical
geometry fixtures remain historical; this is not exhaustive gameplay proof.

## Tests and next gate

[95 focused tests](artifacts/game_1_7_4_b10_audit_20261022/focused_tests.log) PASS.
Tests pin38 symbols,256 fields,independent native bytes,fail-closed build,
production constant-only scope,exact other runtime bytes,and historical gate
rejection. Full regression ran2578tests in860.989s with3failures/1error,
all in historical source assertions. Four test-only repairs select the exact
hash-pinned historical snapshot under an explicit historical context;
production runtime was not changed. The111 relevant tests then passed in
77.436s. Preserve [initial full log](artifacts/game_1_7_4_b10_audit_20261022/full_tests.log)
and [repair retest](artifacts/game_1_7_4_b10_audit_20261022/historical_regression_retest.log).
No second full-suite run is claimed. Final source347files SHA
`b338383abe567d474c849ec157e0ad12338ccf07f2cb21d638b175004958fc77`.

Old source/reverse snapshots and historical fixture gates are preserved with
exact before/after byte pins. A test-only explicit historical view tests old
facts against old source. Default qualification and old E1/native loaders still
reject the changed current source/build; no fake activation or rebind.

## B1 live closure — 2026-10-22, about00:55 Asia/Saigon

[Pinned closure and raw evidence](artifacts/game_1_7_4_b10_audit_20261022/b1_basic1_live_20261022_005137/closure.json):
farm `383e8d94d4a4417a941eeae4c9b34fbf`, match `M_28621233`.
Solo Lieyun77/pet560, Demon Farm BASIC, normal/no evolution/passive,
4Sword, AI/shadow OFF. User manually clicked Start in the tool; cap1/attempt1.

- WIN1/1;0 technical abort/recovery/pass/read error/input-safety violation.
- Entry1, swap1 (2clicks), result confirm1; no duplicate/retry entry.
- Terminal bossHP0/localHP89334, UI Thắng; CONSISTENT, confidence STRONG.
- Normal BOSS_LOBBY return; first STOPPED snapshot at00:55:46+07,
  FARM_TARGET_COMPLETED, exit0. Subsequent idle observations have no new inputs.
- Ordinary preferences, game files and old release ZIP hashes remain unchanged.

The swap closed ACTION_ABORTED_STATE_CHANGED on combat end, not a normal ACK.
One raw MATCH_MOVE_RES seq4 board was rejected as non-8x8; prior b9 one-turn
kills record the same diagnostic. Its payload shape/cause remains unproven;
do not count it as decoded/acknowledged. The combat1s postmatch observation
timeout handed control back to farm, which successfully confirmed and returned.
Local turn count1 is a proxy; actual account energy remains UNKNOWN.

Later idle UI observations report LOBBY_OTHER after the successful return;
cause UNKNOWN. New live setup must verify the room again. Current player stats
also differ from the old E1 timing cohort; old calibration is not transferable.

B1 PASS with the coverage limits above. Next B2: maximum3 user-authorized
BASIC matches to check repeated cycles and, if present, nonterminal turns.
Do not auto-run B2, re-use old claims or start the20 E1 comparison. No package
has been rebuilt; the old v1.2.6 EXE remains incompatible with b10.

All artifacts: [audit directory](artifacts/game_1_7_4_b10_audit_20261022/).
