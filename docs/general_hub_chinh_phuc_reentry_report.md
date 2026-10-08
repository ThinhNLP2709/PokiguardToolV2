# General hub → Chinh Phuc exact-target re-entry

Status: **offline PASS after 2026-09-24 run-28 repair; live recurrence pending**.

## Incident evidence

Farm run `de3987ec515c4f7db3993990f0a5bc77` completed 44/50 clean wins. After
attempt 44, the server room owner was already empty while Unity still rendered
the stale Chinh Phuc room shell. FarmRunner correctly sent the single normal
top-left `X` click, but the game returned to the general game lobby instead of
the Chinh Phuc island map. The old route waited only for a map badge or a leave
confirmation and eventually stopped `FOREGROUND_LOST`; attempt 45 never began.

## Added route

The bounded route for that one return transition is now:

```text
proven detached empty-room shell
  → one normal X click
  → exact owner-free QuangTruong proof
  → one exact ManagerQuangTruong.btnChinhPhuc click
  → exact cached group/panel proof for the farm-session pet_id
  → exact pet map selection in that derived group
  → exact Chinh Phuc boss room
```

`LOBBY_OTHER` alone cannot authorize the new click. Two consecutive samples
must agree on the `ManagerQuangTruong` instance, inactive `panelChinhPhuc`,
active/interactable `btnChinhPhuc`, Button native identity, owning GameObject,
RectTransform, root Canvas aspect and rectangle. A capture sanity check maps
that native rectangle to the current client viewport. Input remains a normal
foreground Windows click.

After Chinh Phuc opens, the resolver walks cached `GroupDTO` and `PetEnemyDTO`
data for the immutable farm-session pet ID. It derives `group_index`,
`group_name`, `pet_index` and hunt order from those DTOs, then requires
`SelectedGroupIndex`, `ActivePanelIndex` and the visible hunt-order badge to
agree before clicking. There is no island-name or Dragon-Island constant in
this route. Starburst currently resolves to cached group index 5; another pet
started by the user must resolve to its own cached group and saved panel.

## Run 48 b4 evidence and repair

Farm run `81fa84f56c7a45a7b6d2c0e7721309d7` completed **48/50**, all 48 wins,
then hit another empty room. The tool sent exactly one room-shell `X` and
stopped `RETURN_LOBBY_TIMEOUT`. A read-only post-stop probe proved the actual
destination was the owner-free general hub.

Two b4-specific causes were verified:

1. `btnChinhPhuc` has a continuous idle bob. During one native ownership walk,
   only its TRS translation changed, by about **0.29 px**; the old byte-exact
   final fence therefore rejected every sample. The hub reader now accepts at
   most **1 px** of translation jitter while still requiring identical owner,
   active state, RectTransform path, rotation and scale. Two independent
   controls must still agree within the existing normalized-rectangle bound.
2. b4 inserted `islandLockMsg` in
   `ManagerChinhPhuc.<>c__DisplayClass41_0`. The exact pet payload moved:
   `lockedOrder +0x20`, `requiredAttack +0x24`, `petId +0x28`, `reA +0x30`,
   and manager `+0x38`. The map resolver now reads the verified b4 layout and
   a complete `0x40`-byte closure instead of the pre-b4 offsets.

The new hub-open capability is single-use per completed-match return and is
available only after exactly one detached-shell exit. Starting or resuming a
farm from the general lobby is unchanged and still requires the user to enter
the exact boss room first.

## Verification

- focused native UI, hub navigation, map and FarmRunner suite: 110/110 PASS;
- full regression after the b4 repair: 1366/1366 PASS;
- integration coverage proves the exact input order
  `BOSS_ROOM_SHELL_EXIT → BOSS_HUB_CHINH_PHUC_OPEN → BOSS_TARGET_SELECT`;
- no memory write, game method call, packet manipulation or direct game API was
  added.

Live acceptance still requires one real recurrence of the empty-room route.
Expected artifacts are `general_hub_chinh_phuc_before.png`,
`general_hub_chinh_phuc_open_sent`, `chinh_phuc_map_after_shell_exit.png` and
`chinh_phuc_map_target_selected` before the exact room is restored.

## 2026-09-24 run-28 incident and repair

Farm run `d63f9c6ade4945289d9f4c969e13f00a` completed **28/88**, all 28
wins, then stopped `RETURN_LOBBY_TIMEOUT / BOSS_LOBBY_TIMEOUT`. The return
record had `lobby=null` and `stable_frames=0`, so the existing detached-shell
and map re-entry classifier was never reached. The final combat provider
metrics also contained one board read error.

A read-only probe of the unchanged stopped screen proved the actual state:

```text
lifecycle=lobby; lifecycle_errors=[]
state=LOBBY_OTHER; branch=CHINH_PHUC_ISLAND
current_room_id=None; current_room_type=None; is_host=false
stale enemy_pet_id=1289; Start interactable=true
clean_for_chinh_phuc_map=true; active island panel=5
```

Two compatible b4 behaviors caused the miss:

1. `MemoryBoardStateProvider.poll()` resolves Board before publishing its
   lifecycle. During postmatch teardown a destroyed Board can therefore make
   that poll publish no lifecycle, although the independent MatchHost/scene
   state already proves a clean lobby. `_wait_boss_lobby` used to skip the
   lobby reader for the full timeout in this case.
2. The updated lobby classifier can positively report
   `CHINH_PHUC_ISLAND/CHINH_PHUC_MAP` while the stale empty-room visual layer
   is still present. The detached-shell gate previously accepted only the
   older `branch=None` shape.

The repair adds an owner-free fallback lifecycle read with `board=None`. It is
accepted only for a clean `LOBBY` sample with zero read errors; ACTIVE,
UNKNOWN, an existing combat session, or any lifecycle read error still fails
closed. The stale shell classifier now also accepts the two named map branches
only when `clean_for_chinh_phuc_map` is positively proven. Every downstream
two-frame visual proof, exact pet identity check, single-use input capability,
and atomic pre-click reread remains required. The same fallback is used by
those atomic re-entry rereads so a destroyed Board cannot block the route a
second time.

Verification after the repair:

- stopped-screen live read-only probe: exact Starburst `1289` detached-shell
  candidate recognized;
- focused farm-cycle/FarmRunner suite: 106/106 PASS;
- full regression at repair point: 1495/1495 PASS; subsequent Phase 4B.2
  source-selector coverage raises the clean repository suite to 1496/1496;
- `git diff --check`: PASS.

This closes the proven detection gap. A future natural empty-room recurrence
is still required to promote the route from offline PASS to live PASS.

## 2026-09-27 direct-island X incident and runtime-authority repair

Run `7335ce37dddd4e18b34f79eb4a5ff561` reached the correctly classified clean
`CHINH_PHUC_ISLAND` after the user closed the completed room, but target
discovery returned null before any navigation input. Read-only inspection of
the unchanged screen found the exact Starburst `1289` Button closure in the
same 16 MiB private writable allocation as live `ManagerChinhPhuc`. The old
unanchored 8 MiB filter excluded that allocation. Registry PlayerPrefs were
also stale (`SelectedPetId=650`, group 0, no active panel) while live memory
proved manager `2647914532096`, active panel 5 and the target cached-data group
5.

Map discovery now accepts a current manager/panel hint from the lobby snapshot,
scans only the exact OS allocation containing that manager with a hard 16 MiB
ceiling, requires the closure manager to equal the hint, and requires the live
panel to equal the target group. PlayerPrefs remain telemetry and legacy
fallback evidence; they cannot override a complete current runtime pair.
Atomic and post-focus checks bind the same manager, panel, managed/native
Button and pet identity. Live read-only verification resolved the target clean
in about 0.58 seconds, scanning one 16 MiB allocation. Full regression after
the repair: 1552/1552 PASS. A clean live retry is still pending.

The next live retry exposed one additional loading boundary. Immediately after
the result-room X, ManagerChinhPhuc existed while the main island panel was
inactive and `active_panel_index` was null. The helper treated that incomplete
pair like an old snapshot and performed a 432 MB legacy scan. It found the
correct Starburst target, but the scan consumed the eight-second stability
window, so only one clean sample was recorded. The same stopped screen later
reported active panel 5 (Dragon Island).

An incomplete live manager/panel pair now waits without scanning or input.
Once both values are present, the anchored 16 MiB resolver collects the two
stable target samples. The bounded runtime wait is 15 seconds. Regression
covers the exact `CHINH_PHUC_MAP/null -> CHINH_PHUC_ISLAND/5` sequence; full
suite: 1553/1553 PASS. Live acceptance remains pending.

A fourth live retry showed that the map-to-island data load can exceed the
temporary 15-second stabilization window. All 15 samples retained the same
ManagerChinhPhuc while `active_panel_index` remained null; no scan or input was
issued. After the safe stop, the same manager exposed active panel 5 and the
exact Dragon Island/Starburst metadata. Runtime stabilization now uses the
configured return-lobby timeout with a hard 120-second ceiling. An incomplete
manager/panel pair remains zero-scan and zero-input, and transition shape
changes are logged once for diagnosis. Full regression remains 1553/1553 PASS.

A fifth live retry exposed a later race rather than another map-loading miss.
The return watcher proved the exact Starburst room, then the operator closed it
before Boss Start's atomic preflight. The preflight correctly rejected the
changed runtime with zero Start clicks, but FarmRunner treated that rejection
as a terminal opening invariant. A zero-input
`ENTRY_PREFLIGHT_RUNTIME_CHANGED` now returns `ENTRY_READY` to
`WAIT_BOSS_LOBBY` and reuses the bounded lobby/map router. It does not count a
match attempt, and all existing runtime, target, visual, post-focus and input
capability fences remain mandatory. Entry evidence is retained in independent
retry artifact directories, with at most three reroutes for one not-yet-counted
attempt. Full regression after this repair is 1555/1555 PASS; live acceptance
remains pending.

A sixth live retry completed two wins and reached the visible Dragon Island
map, but spent the full 90-second bounded return wait before stopping. The log
recorded 101 runtime probes/scans and zero navigation input. Read-only
inspection proved the current ManagerChinhPhuc, active panel 5 and its unique
cached Starburst/1289 row were all valid and stable. The manager allocation
contained only destroyed historical pet-button closures with null native
pointers; no live Starburst closure referred to the current manager.

Map discovery now keeps a live Button closure as its preferred proof, while
also accepting the exact current manager, active panel and unique unlocked
cached target when no live target closure exists. Destroyed null-native history
cannot block this fallback. A live contradictory target closure still rejects
it. The fallback supplies identity and hunt order only: selection continues to
require one unique badge in two stable captures plus fresh atomic and
post-focus rereads of manager, panel, cached pet, lifecycle and room ownership.
Focused map/FarmRunner verification is 92/92 PASS and the full repository is
1558/1558 PASS. Live acceptance remains pending.

A seventh live retry exposed the same room-to-map transition at a narrower
boundary. The exact Starburst room and Start button were valid before the
pinned entry lease. While its guarded transport scan ran, the room disappeared.
The post-focus preflight correctly returned `STALE_ACTION` with
`action_attempted=false`, `click=null` and zero Start inputs, but Boss Entry
collapsed the specific runtime-change reason to `FARM_ENTRY_CAPABILITY_DENIED`.
FarmRunner therefore could not invoke the zero-input navigation reroute added
after attempt 5.

Boss Entry now preserves a post-focus reason only when the pinned lease proves
the action never began and there is no lease error. A proven room/runtime
change returns `ENTRY_PREFLIGHT_RUNTIME_CHANGED` and reuses the bounded
lobby/map router without incrementing match attempts or sending a blind Start
click. Geometry, transport, capability, emergency-stop and after-action errors
remain terminal. Focused Boss Entry/FarmRunner verification is 104/104 PASS;
the full repository is 1560/1560 PASS. Live acceptance remains pending.
A regression audit on 2026-10-07 found one missing intermediate action in the
general-hub route. Runs `64dc13f47d9240d1a16d3fa490cdaa21` (43/500),
`dd3dd1c10ea44b15bf9e267495afb639` (18/500),
`77106b46bf1e4870aaeb36e71b7320fd` (35/500),
`4d549961c3c2402db11a92a697e2c2d9` (66/500),
`fc23e471b4d646a59c45eda8fb34f872` (69/500), and
`c9cd5d9751ba45f9970c42f9eaab2767` (102/500) all stopped with the same
`RECOVERY_FAILED` shape. The exact Chinh Phuc hub click was sent, then the game
settled on `CHINH_PHUC_MAP` with a live `ManagerChinhPhuc`, no active island
panel, and `panelMainActive=false`. The runner incorrectly treated that stable
main-map state as a construction race and waited 90 seconds for an island to
open itself.

The recovery route now resolves the configured boss through cached
`GroupDTO/PetEnemyDTO`, selects `ManagerChinhPhuc.buttons[group_index]` using
its live native `Button`/`RectTransform`, and only then reuses the existing
active-panel boss selector. Island selection has its own one-shot FarmRun
capability, so it cannot consume or duplicate the boss-cell capability. Both
normal foreground and pinned input modes perform two stable reads plus a final
fresh preflight before the click. No island name or coordinate is fixed in the
executor.
