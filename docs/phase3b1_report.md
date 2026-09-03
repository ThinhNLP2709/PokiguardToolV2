# Phase 3B.1 — Production Shadow QTE Observer

**Ngày hoàn tất:** 2026-09-04  
**Base commit:** `d0f5620a3f9d09465f70e89a4825417425301c32`  
**Trạng thái:** **PASS STRONG**

Phase này chỉ tạo hạ tầng quan sát read-only. Không có click Pet Skill, phím
hướng/WASD, Space/Enter, game-memory write, direct gameplay call, network
manipulation, thay đổi BASIC policy, ManaPriority hay Desktop UI.

## Capability architecture

`src/pokiguard_v2/pet_skill_shadow.py` thêm lớp production độc lập với input:

```text
current read-only GameState / active CardUI evidence
    -> LivePetSkillCard (exact CombatSessionKey)
    -> PetSkillCapabilityProvider
    -> immutable PetSkillCapability
```

Provider biểu diễn rõ `NO_CAPABILITY`, `METADATA_ONLY`, `CURRENT`, `STALE`,
`AMBIGUOUS`, `INVALID`. Candidate phải khớp exact `CombatSessionKey` và
`Board.Instance`; candidate khác nhau hoặc live wrapper trùng/không rõ ownership
đều fail closed. Metadata không có current CardUI/Button không được nâng thành
live capability. Button presence/interactable chỉ là evidence, không phải quyền
click.

Capability giữ riêng source `PetUserDTO`, exact runtime CardData/card identity,
raw resource fields, resolved Mana cost, Rage requirement, cooldown,
needPerfection, quality values, family/target mode và current CardUI/Button proof.
Source pet vẫn là `Silas / petId 2306`; `Huyền Thoại 7 / cardId 7` là runtime
skill-card identity riêng sau tiến hóa.

## Resource semantics correction

User rule và live Phase 3B.1 xác nhận ý nghĩa đúng của fixture:

```text
conditionUse = 200  -> Mana bị tiêu hao
power        = 200  -> ngưỡng Nộ tối thiểu để kích hoạt
manaCost     = 0    -> raw field, không dùng làm effective Mana cost ở shape này
powerCost    = 0    -> raw field
```

Resolver không dùng pet ID, card ID, tên card hay literal 200. Rule chỉ áp dụng
cho structural shape đã chứng minh `ATTACK_LEGEND_` với raw cost `0/0`; shape
khác để `UNKNOWN`. Synthetic `175 Mana / 125 Rage requirement` chứng minh không
global hard-code `200/200`.

Đây là correction đối với kết luận Phase 3A.1. Sample 3A.1 thấy Nộ `215 -> 15`
đã nhầm net delta với cost. Production model không còn gọi `power` là cost và
không yêu cầu Nộ giảm 200. Mẫu live sạch 3B.1 có Mana `262 -> 62`, Nộ
`250 -> 250`; điều kiện Nộ đạt và Mana giảm đúng 200. Pet Skill tự phá board và
cascade sau Space, nên tài nguyên sau skill có thể được các gem tự động bổ sung.

## QteSnapshot và generation ownership

`QteObserver` tạo immutable `QteSnapshot` gồm exact MatchId, lifecycle epoch,
Board, local actor, turn, skillCardId, generation identity, raw/typed sequence,
presses, index/correct count, timing window, elapsed, prediction, runtime result,
server result, resource delta và turn semantics.

- Directions được normalize thành `UP/DOWN/LEFT/RIGHT/UNKNOWN`.
- `expected_direction` chỉ tồn tại khi sequence/index/ownership/generation current.
- Mỗi inactive→active edge tạo generation mới; MatchId/session change xóa toàn bộ
  sequence, progress, window, result và resource baseline cũ.
- Current Button và Board/Active/CardData ownership đều được kiểm lại read-only.
- Retained `CardUI.timingText` từ generation trước bị bỏ qua cho tới khi chính
  generation hiện tại có `finished=true`; nó không còn tạo runtime result giả.

Perfect window lấy trực tiếp từ server/runtime challenge. Midpoint chỉ là
diagnostic; observer không sleep, schedule hoặc gửi confirm. Prediction, runtime
display và server result là ba evidence riêng. Generic 1.7.4
`MATCH_SKILL_USE_RES` không echo `timingResult`, nên response có thể được bind
current trong khi `server_resolved_result` vẫn `UNKNOWN`.

## Production result scanning

Observer ưu tiên các vùng `ChatMessageDTO` mà memory provider đã học trước khi
dùng full bounded scan fallback. Điều này sửa lần live đầu nơi ba response ngắn
không được bắt kịp. Correlation vẫn yêu cầu unique completed generation, exact
MatchId, bounded server timestamp, current card khi được echo và no explicit
reject; scan hint không cấp correlation authority.

## Live B1–B5

### B1 capability

Match `M_631e9914` và `M_c2a5fef6` đều resolve runtime card:

- source pet: `Silas`, petId `2306`;
- skill card: `Huyền Thoại 7`, cardId `7`;
- family/target: `AUTOMATIC_DOT_DESTRUCTION / AUTOMATIC`;
- raw `conditionUse/power/manaCost/powerCost = 200/200/0/0`;
- effective Mana cost `200`, source `CONDITION_USE`;
- required Rage `200`, source `POWER`;
- current `CardUI.ActiveDotSkillCard`, exact session/Board and validated Unity
  Button.

### B2–B4 direction, timing và isolation

Production live quan sát bốn manual QTE, hai MatchId, tổng 28 directions:

| Match | Generation | elapsed | Prediction | Runtime | Directions |
|---|---:|---:|---|---|---:|
| `M_631e9914` | 1 | 2.936 s | GOOD | GOOD | 7/7 |
| `M_631e9914` | 2 | 3.055 s | PERFECT | PERFECT | 7/7 |
| `M_631e9914` | 3 | 3.025 s | PERFECT | PERFECT | 7/7 |
| `M_c2a5fef6` | 1 | 3.008 s | PERFECT | PERFECT | 7/7 |

Tất cả dùng runtime Perfect window `[3.000, 3.300]`, midpoint diagnostic `3.150`.
Shadow direction matches `28`, mismatch `0`, complete-sequence disagreement `0`.
Ba generation trong cùng match có sequence độc lập; MatchId mới reset generation.
Có một transient server-challenge read bị fail closed, sau đó cùng generation
rebind đúng; stale generation được dùng làm current bằng `0`.

### B5 response, resource và turn

Supplemental live log `phase3b1_live_retry_20260904_013537.jsonl` bắt current
generic `MATCH_SKILL_USE_RES` bằng exact MatchId `M_c2a5fef6`, unique generation
và bounded server timestamp. Envelope không echo timing result, vì vậy server
result giữ `UNKNOWN`; runtime result riêng là `PERFECT`.

Raw before/after:

```text
turn:  41 local -> 42 boss
Mana:  262 -> 62   (delta -200)
Rage:  250 -> 250  (requirement 200 was met; Rage is not a cost)
HP:    48970 -> 64058
```

User xác nhận sau Space Pet Skill tự ăn board và không cần board input. Do đó HP/
resource effect và turn edge là chính skill resolution, không phải manual swap.
Evidence mới cho thấy `Huyền Thoại 7` **tiêu hao lượt**. Sample Phase 3A.1 đọc
response trước khi automatic board effect/turn edge hoàn tất nên kết luận
non-turn-consuming cũ bị supersede.

Exact số gem/Sword bị phá vẫn `UNKNOWN`: generic response không echo
`dotsToDestroy`, và gravity/refill/cascade không cho phép quy toàn bộ board diff
thành exact skill count.

## Safety counters

```text
automated Pet Skill clicks = 0
automated UP/DOWN/LEFT/RIGHT = 0/0/0/0
automated Space/Enter = 0
WriteProcessMemory = 0
direct gameplay calls = 0
network manipulation = 0
```

## Verification

```text
focused tests: 72/72 PASS
full regression: 869/869 PASS
compileall: PASS
git diff --check: PASS
```

Focused coverage gồm hơn 10 capability cases, hơn 24 QTE/session/resource cases,
exact Phase 3A.1 timing fixture, same-Match N/N+1, Match A/B isolation, stale and
duplicate result rejection, retained-result-text rejection và no-input/no-write
source audit.

## Known UNKNOWN

- Server timing result không được generic 1.7.4 envelope echo.
- Exact `dotsToDestroy`/exact Sword count không được chứng minh.
- Source `PetUserDTO` không đổi thành evolved skill identity; CardUI/CardData là
  current runtime skill identity.
- Legendary pet thứ hai chưa quan sát, không phải điều kiện PASS.
- Semantics của family/card khác chưa được suy rộng từ fixture này.

Nominal next safe phase: **Phase 3B.2 — Automated Direction Sequence**, chỉ sau
khi được review/ra lệnh riêng. Phase 3B.1 không triển khai bất kỳ input tự động
nào.
