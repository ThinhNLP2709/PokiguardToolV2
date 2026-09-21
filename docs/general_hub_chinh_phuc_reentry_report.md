# General hub → Chinh Phuc exact-target re-entry

Status: **offline PASS after b4 run-48 repair; live recurrence pending**.

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
