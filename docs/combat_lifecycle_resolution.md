# Phase 2C.2A.3 — Combat lifecycle resolution

## Kết luận

`MatchService.CurrentMatchId` không phải tín hiệu local combat đủ mạnh. V2 chỉ
phân loại `ACTIVE` khi local Unity rig, loader/Hub và ownership cycle của combat
đồng thuận. Mọi tổ hợp thiếu hoặc mâu thuẫn đều fail closed.

Các state production:

```text
LOBBY
ENTERING
ACTIVE
LEAVING
POSTMATCH
STALE_SERVER_MATCH
UNKNOWN
```

## Exact reverse evidence

Tất cả địa chỉ dưới đây là RVA theo build hiện tại; runtime luôn tính
`GameAssembly base + RVA`, không dùng absolute VA.

| Signal | Type-info RVA / field | Evidence | Confidence |
|---|---:|---|---|
| `MatchHost.State` | `0x3562040`, static `+0x00` | `MatchHost.cs`; `MatchHost.txt` getter reads `Il2CppClass+0xB8 -> static_fields +0` | CONFIRMED |
| `MatchHost.CurrentRig` | same, static `+0x10` | `MatchHost.cs`; native `get_IsInMatch` reads static `+0x10` and requires a non-destroyed Unity object | CONFIRMED |
| enum values | Idle 0, Preparing 1, Building 2, Running 3, Releasing 4 | `MatchState.cs` | CONFIRMED |
| loader flags | type-info RVA `0x3562280`, static `+0x00/+0x01` | `MatchSceneLoader.cs`; native `get_IsBusy` reads both bytes | CONFIRMED |
| Hub suspended | type-info RVA `0x353BF90`, static `+0x08` | `HubSuspendManager.cs`; getter/SuspendAll/ResumeAll native bodies | CONFIRMED |
| Manager ownership | `ManagerMatch.Instance`; `active +0x130`; `isBossBattle +0x138` | `ManagerMatch.cs` plus existing singleton proof | CONFIRMED |
| Board/Active cycle | `Board.active`, `Active.board`, both singleton instances | `docs/static_singleton_resolution.md` and existing runtime hardening | CONFIRMED |

Primary sources:

- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchHost.cs`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchHost.txt`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/MatchSceneLoader.cs`
- `reverse/cpp2il_isil/IsilDump/Assembly-CSharp/MatchSceneLoader.txt`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/HubSuspendManager.cs`
- `reverse/cpp2il_cs/DiffableCs/Assembly-CSharp/ManagerMatch.cs`

`MatchHost.get_IsInMatch()` accepts a non-null/non-destroyed `CurrentRig` while
state is `Building` or `Running`. V2 is stricter for input: `Building` remains
`ENTERING`; only `Running` may become `ACTIVE`.

## Classifier

`ACTIVE` requires all of:

```text
MatchHost.State == Running
CurrentRig wrapper exists and its Unity cached native pointer is alive
MatchSceneLoader._isLoading == false
MatchSceneLoader._isUnloading == false
HubSuspendManager.IsSuspended == true
Board.Instance != null
Active.Instance != null
ManagerMatch.Instance != null
Board.active == Active.Instance
Active.board == Board.Instance
ManagerMatch.active == Active.Instance
CurrentMatchId is non-empty
Board.isBoardReady == true
no Board/MatchService end flag
```

Priority of terminal/transition evidence:

1. Board/MatchService end flag with local rig/objects -> `POSTMATCH`.
2. loader unloading or Host Releasing -> `LEAVING`.
3. loader loading or Host Preparing/Building -> `ENTERING`.
4. all ACTIVE predicates -> `ACTIVE`.
5. server match ID exists while Host Idle, rig/Hub/local objects absent ->
   `STALE_SERVER_MATCH`.
6. same local absence and no match ID -> `LOBBY`.
7. anything else -> `UNKNOWN`.

`Board.Instance != null` alone is intentionally insufficient.

## Session identity and invalidation

`CombatSessionKey` remains the correct three-part identity:

```text
(lifecycle_epoch, Board.Instance, matchId)
```

`CombatSessionTracker` issues this key only in `ACTIVE`. The first observation
of `ENTERING`, `LEAVING`, `POSTMATCH`, `LOBBY`, `STALE_SERVER_MATCH` or
`UNKNOWN` invalidates the current key immediately. A later ACTIVE match gets a
new monotonically increasing local epoch even if Unity reuses a Board address.

`MemoryBoardStateProvider` now performs this lifecycle check before starting a
combat cache/session or publishing a board. It rechecks lifecycle around the
stable-board sample. `ActionabilityGate` rejects every non-ACTIVE state with a
specific reason.

## Runtime validation at lobby

Read-only probe:

`logs/lifecycle_idle_watch_20260812_174531.jsonl`

Observed on PID 6284, GameAssembly base `0x00007FFB46330000`:

```text
MatchHost.State         Idle (0)
CurrentRig              null / not alive
scene loading/unloading false / false
Hub suspended           false
Board/Active/Manager    null / null / null
CurrentMatchId          null
lifecycle               LOBBY
```

At the same time the old MatchService object still exposed `turn=28` and
`srvSeq=60`. This is direct runtime proof that residual MatchService turn/seq
cannot grant actionability.

## `M_6630bd6e` audit correction

The older recovery log does **not** prove that `M_6630bd6e` was a hidden match
continuing after local exit:

```text
10:21:43.190Z  Board 0x...13A80 lost; M_02d685fa ended at turn 50
10:21:45.297Z  new Board 0x...13540; new M_6630bd6e began at turn 1
```

The Board pointer and match ID both changed after a 2.107-second gap. The most
defensible classification is a distinct new local match lifecycle. Why the UI
appeared to the user as already exited is `UNKNOWN` because the old watcher did
not record rig/loader/Hub state. The new watcher records those fields and can
reproduce or reject the hidden-match hypothesis precisely.

