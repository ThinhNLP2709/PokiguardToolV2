# PokiguardToolV2

## Mở tool trên Windows

### Bản portable Release Candidate Phase 2F.2

Build chuẩn tạo một bundle Windows x64 không cần cài Python:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

Artifact build mặc định:

```text
%LOCALAPPDATA%\PokiguardToolV2\package-builds\v1.0.0+15\
PokiguardToolV2-v1.0.0+15-win-x64.zip
```

Giải nén toàn bộ ZIP rồi chạy `PokiguardToolV2.exe`. Không tách riêng EXE ra
khỏi thư mục `_internal`. Runtime data được ghi dưới
`%LOCALAPPDATA%\PokiguardToolV2`, không ghi cạnh EXE, vào source repository hay
thư mục game. Release Candidate đã được clean-build và live-validate từ commit
`1dd53340e20ca405c0bf446682b3fcbf823afe62`. SHA-256 của RC được chấp nhận:

```text
e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69
```

The current source compatibility version is `v1.0.49`. The accepted packaged
Phase 2F.2 artifact above remains `v1.0.0+15`; rebuild packaging before
distributing the maintenance version.

The current Pokiguard 1.7.4-b4 build uses Unity IL2CPP metadata 110. Its
verified symbols, exact binary hashes, implemented default paths, and remaining
live-combat boundary are recorded in
[docs/pokiguard_1.7.4_b4_compatibility_report.md](docs/pokiguard_1.7.4_b4_compatibility_report.md).
Unknown future `GameAssembly.dll` hashes fail closed even when their versioned
launcher path is valid.

### Chạy source/developer

Chạy [run_tool.bat](run_tool.bat) từ thư mục gốc project. Launcher sẽ:

- chạy đúng từ thư mục `PokiguardToolV2`;
- ưu tiên Python x64 trong `.venv`, sau đó dùng Python đã cài trên máy;
- chặn mở hai Desktop UI/controller cùng lúc;
- tạo artifact riêng theo thời gian cho mỗi lần mở;
- chỉ mở UI, không tự động Start hoặc Resume farm.

Game phải được mở sẵn. Để Start một farm session mới, user vẫn phải ở đúng
boss lobby; UI sẽ tự xác minh lại lifecycle và target trước khi cho phép Start.
Trong tab **Settings**, ô **Game executable** lưu full path chính xác, ví dụ
`D:\pc\Pokiguard-1.7.4.exe`. Khi game đổi phiên bản và tên EXE thay đổi, dùng
nút **File...** để chọn launcher mới. `GameAssembly.dll` phải nằm cùng folder.

PokiguardToolV2 is the second-generation automation research project for the
Windows x64 Unity IL2CPP game Pokiguard.

The current architecture reads client state externally and read-only, adapts it
to the established V1 solver, and uses normal foreground Windows input. The V1
computer-vision path remains available as a fallback.

## Safety boundary

- no game-file modification or binary patching;
- no `WriteProcessMemory`, injection, remote thread, or hook;
- no direct Unity gameplay-method invocation;
- no packet or network manipulation;
- no HP, damage, reward, or server-authoritative state modification.

See [AGENTS.md](AGENTS.md) for workspace rules, the
[Phase 3D.1-R1 report](docs/phase3d1_r1_report.md),
[Phase 3D.1-R1 runbook](docs/phase3d1_r1_runbook.md),
[Phase 3C.3 report](docs/phase3c3_report.md),
[Phase 3C.3 runbook](docs/phase3c3_runbook.md),
[Phase 3C.2 report](docs/phase3c2_report.md),
[Phase 3C.2 runbook](docs/phase3c2_runbook.md),
[Phase 3A.2 report](docs/phase3a2_report.md),
[Phase 3A.2 runbook](docs/phase3a2_runbook.md),
[Phase 3A.0 report](docs/phase3a0_report.md),
[Phase 3A.0 runbook](docs/phase3a0_runbook.md),
[Phase 2F.2 report](docs/phase2f2_report.md),
[Phase 2F.2 runbook](docs/phase2f2_runbook.md), and
[release manifest](release/phase2f2_manifest.json) for final RC evidence.

## Current status

The active work is Phase 3D.1-R1 at source version `v1.0.49`. The optional
`Chịu đấm ăn xôi` policy now uses the generic `Điều kiện ra skill` preference:
runtime skill-resource readiness, or inclusive current-board counts for Sword,
Mana, Rage, Drain or Shield. Count values accept `0..256`; the default is
`Kiếm đủ / 10`, meaning current known effective Sword value, including x2–x4,
is `>= 10`. Actual runtime
skill resources remain mandatory for every condition. Boss HP cannot shortcut
the first skill. Distance-two,
Sword-preserving setup remains preferred; `SETUP_BLOCKED` only relaxes soft
setup constraints, and intentional pre-skill Sword damage is removed. The
match-scoped post-skill finisher uses fresh boss HP ratio `<=30%`.
Phase 3C.3 remains accepted as **PASS STRONG** at `v1.0.48`. Phase 3D.1-R1 is
now **PASS STRONG**: refreshed Mode A and Mode B each passed 10/10; Mode B
recorded 10/10 PERFECT immediate first-skill kills, zero PASS/EVOLVE and zero
critical safety violation. Against Mode A it reduced mean combat duration by
36.129% and mean primary gameplay actions by 41.045%. Earlier Phase 3D.1
evidence remains historical because it used the superseded `SETUP_BLOCKED`
fire path.
The exact b4 hash, all moved TypeInfo roots, GameAssembly native bindings, and
shifted Dot tail fields are implemented. Managed Board/turn/ACK/card/Fusion/
pet/lifecycle fields used by default mode remain stable from b3. Offline
verification and the bounded default live run are complete: the repaired b4
path finished a strong 1/1 win with 18/18 native board reads and zero PASS.

The normal Desktop UI now supports the exact
`LEGENDARY/NONE/PET_SKILL/BASIC` profile through the existing immutable
controller and FarmRunner path. V3 two-direction `LR` is the default, while V2
four-direction remains an explicit compatibility option. Unsupported and
ambiguous multi-source profiles remain blocked. User-operated live acceptance
completed exactly 5/5 Pet Skill-profile wins, with four runtime Perfects,
28/28 confirmed directions, four valid Space presses, no extra attempt and no
QTE/gameplay safety violation. Graceful stop completed the current match and
prevented the next entry. The default
`NORMAL/NORMAL/DEFAULT_ATTACK/BASIC` regression completed 1/1 win with
PetSkillAction zero. The final Desktop UI closed cleanly with its poller and
workers stopped while the game remained running.

Phase 3A.2 introduced the typed Desktop pet model. It replaced the Desktop
`ManaPriority` setting with typed **Pet của tôi**, **Tiến hóa**, and **Thẻ sát
thương** fields. `NORMAL/NORMAL/DEFAULT_ATTACK` and
`NORMAL/NONE/DEFAULT_ATTACK` retain the two old BASIC behaviors through a
temporary internal adapter. Other Pet Skill profiles remain fail-closed until
their source selection and gameplay behavior are implemented.
See the [Phase 3A.2 report](docs/phase3a2_report.md) and
[runbook](docs/phase3a2_runbook.md).

The Phase 3A.2 live UI, migration, gate, input audit, and clean shutdown passed.
Its single default-profile match exercised the existing BASIC branches without
Pet Skill, then failed closed as `COMBAT_TERMINAL_UNPROVEN` after the game moved
directly to the main lobby before a terminal result was observable. The report
keeps this B3 limitation explicit; no second match was launched.

Phase 2F.2 remains the latest accepted packaged RC
(**PASS STRONG / BASIC COMPLETE**) and passed all packaged-live stages B1-B6,
including:

```text
read-only attach smoke
-> bounded 10-WIN farm with evidence-backed technical recovery
-> graceful stop
-> checkpoint resume
-> immediate Emergency stop with zero post-ACK input
-> clean shutdown and unchanged game/package hashes
```

Phase 2F.2 has reached **PASS STRONG** and the finite BASIC scope is complete.
The previously untracked QTE reverse report was preserved byte-for-byte in a
separate documentation commit with explicit user authorization before the
release boundary; it was not mixed into the RC artifact or runtime graph.
Canonical release tag: `v1.0.0+15`.

Supported scope remains finite BASIC farming, exact-room session pinning,
read-only state acquisition, normal foreground input, bounded technical
recovery, graceful checkpoint resume, and Emergency stop. REASONING,
unbounded farming, automatic game launch/restart or login, target rotation,
memory writes, and network manipulation remain unsupported.

Runtime logs and screenshots under `logs/` are intentionally excluded from Git
because they are large, machine/session-specific diagnostic artifacts.

## Tests

From the project root:

```powershell
python -m unittest discover -s tests -v
```

The accepted Phase 2F.2 RC baseline passes 740 tests. The `v1.0.47` accepted
source baseline passes **1236 tests**; the `v1.0.48` Phase 3C.3 Final Revision
passes **1281 tests**. The current `v1.0.49` Phase 3D.1-R1 generic-condition
revision with the final benchmark analyzer passes **1,354 tests** and adds focused
Pet-Skill-rush coverage, including all six fire conditions, plus regression coverage
for the Pet configuration/capability matrix, preference and checkpoint
migrations, UI visibility/locking, safe future-profile gates, and the unchanged
Phase 3B.3 Pet Skill primitive. Exact stopped-run boards verify that an unsafe
Mana/Rage collection remains first while HP is above 30%, even when the best
Sword-preserving resource move leaves a boss Sword opportunity; Drain and
Shield follow only after no missing-resource move exists. Setup keeps its hard
Sword-safe boundary. It also
retains coverage for the raised card click point, faster fail-closed result confirmation,
direct/indirect opponent Sword replies, the unique-adverse-Sword policy, and
versioned game-location resolution, build-fingerprint gating, the corrected
independent board/lobby/combat-card mappings for the 1.7.4 2:1 viewport, and
both legacy and current 1.7.4 postmatch layouts. It also retains
`VirtualQueryEx.AllocationBase` so live combat-card discovery can cover split
regions of the exact `Board.cardsInHand` allocation under a strict 16 MiB cap.
The standard card strip now uses direct `Board.selectedCards/cardsInHand` plus
`MatchService` ownership after the opening turn; live `CardUI` remains preferred
when available, while a current visual tile proof is still mandatory before a
normal click. This removes late heap-wrapper discovery from the common card
path. The Control tab reports distinct local turns per completed match, the
live current-match count, and total energy on separate lines; EVOLVE plus SWAP
on one local turn counts once. This projection reuses already-deduplicated
TurnNumber observations and performs no extra memory scan or capture.
The Preferences tab now selects `two_click` or the short overshooting `drag`
flick for board SWAPs; cards and UI controls remain ordinary clicks. Exact
Redux 1.7.4 Board ownership now keeps the opening turn board-only, discovers
cards from `selectedCards/cardsInHand` during the first boss turn, and caches
immutable CardData plus validated CardUI addresses for later turns. Periodic
transport maintenance is allocator-neighbour bounded instead of a timer-only
full heap scan; exact unresolved ACK evidence still retains the fail-closed
broad fallback.

Current source reproduction steps are in the
[Phase 3D.1-R1 runbook](docs/phase3d1_r1_runbook.md). Build and acceptance steps for
the accepted RC are in the
[Phase 2F.2 runbook](docs/phase2f2_runbook.md).
