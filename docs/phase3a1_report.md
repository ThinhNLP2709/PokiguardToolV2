# Phase 3A.1 — Pet Skill / QTE Reverse Closure

**Ngày:** 2026-09-04
**Trạng thái hiện tại:** **PASS STRONG**

Phase 3A.1 đã đóng đủ foundation để thiết kế Phase 3B.1 mà không đoán sequence,
input mapping, Perfect window, card identity, resource requirement hay turn
semantics. Không có input QTE tự động nào được thêm.

### Live attempt 20260903_232239 — REJECTED, observer boundary corrected

Attempt instrumented đầu tiên đi từ match `M_197de870`, turn 1 tới turn 87. Người
dùng quan sát bốn QTE sau khi tiến hóa (Arrow+Space PERFECT, WASD+Enter GOOD khi
game lag, WASD+Enter PERFECT, Arrow+Space PERFECT), nhưng observer ghi 0 QTE nên
các kết quả UI này chỉ là đối chứng, chưa phải memory evidence.

Log chứng minh `Active.playerPets` vẫn là pet nguồn `Silas`, `petId=2306`,
`skillCardId=null`, `evoStage=0`, `cardDTO=null`. Code cũ đã `continue` tại đây và
không bao giờ đọc `CardUI.ActiveDotSkillCard`, mặc dù thẻ skill chỉ được tạo/mở khóa
sau tiến hóa. Đây là lỗi observer, không phải thao tác của người dùng.

Boundary đã được sửa theo đúng lifecycle runtime:

- source pet không có skill chỉ được log là thông tin **non-blocking**;
- observer theo dõi card family `ATTACK_LEGEND`/`ATTACK_LEGEND_` xuất hiện trong
  current combat ngay sau tiến hóa;
- khi QTE mở, exact identity được lấy từ chính
  `CardUI.ActiveDotSkillCard.cardData`, có kiểm tra class, Board, Active, actor,
  current MatchId và server challenge;
- chỉ singleton null đã xác minh mới tạo inactive edge; read lỗi/torn không được
  phép giả lập một edge mới giữa QTE;
- regression mới đóng case “pet gốc không skill → tiến hóa → runtime QTE card”.

Attempt này **không** nâng Phase lên PASS. Cần một live retry ngắn bằng observer đã
sửa để thu identity/result/resource/turn.

### Live retry 20260904_000854 — runtime card/QTE proven, result conflict retained

Match `M_184f52c1` đã capture sáu lần mở QTE. Lần đầu bị observer từ chối
`UNBOUND_MIDSTREAM` do điều kiện kiểm tra singleton-null bất khả thi; năm lần sau
được bind và hoàn tất theo đúng current session. Đây là lỗi freshness của observer,
không phải lỗi QTE của người dùng.

Exact runtime card sau tiến hóa:

```text
CardData.cardId       = 7
CardData.name         = Huyền Thoại 7
elementTypeCard       = ATTACK_LEGEND_
skillType             = null
level                 = 14
conditionUse          = 200
manaCost / powerCost  = 0 / 0
cooldownTurns         = 0
needPerfection        = false
eatPerfect/Good/Bad   = 0 / 20 / 12
damageMultiplier      = 1.8
```

Source `Active.playerPets` vẫn là `Silas`, `petId=2306`, không có skill/cardDTO.
Vì vậy identity authoritative sau tiến hóa là exact runtime `CardData` của
`CardUI.ActiveDotSkillCard`, không phải pet nguồn. Sample mana/power cũ lấy từ
stable-board snapshot có thể trễ so với QTE và không đủ làm resource proof. Final
retry bên dưới thay nó bằng direct participant read quanh exact server response.

Năm completion bound có `correctCount=7`; bốn lần kết thúc khoảng 3.04–3.13 giây
trong Perfect interval, một lần khoảng 4.95 giây ngoài Perfect interval. Arrow +
Space và WASD + Enter đều đã vận hành thành công bằng tay, phù hợp native mapping.
Người dùng sau đó sửa báo cáo rằng một kết quả thực tế là `BAD`, không phải `GOOD`.
Native `GetLastTimingResult` lại phân loại `ATTACK_LEGEND_` có correct >= 7 ngoài
Perfect thành `GOOD!`; do log cũ không capture Unity Text nên đây là **CONFLICT**,
không được nâng thành proven.

Hai object `MATCH_SKILL_USE_RES` đã được thấy. Object current có đúng MatchId và
timestamp ngay sau completion nhưng để các field QTE-specific null, chứng minh
1.7.4 dùng generic response envelope. Quanh sample cũ ở turn 49, lượt vẫn thuộc
người chơi; sample này đã gợi ý non-consuming nhưng chưa đủ đóng resource vì
deduction có thể đến muộn.

Observer đã được harden tiếp:

- `instance_null` thật sự tạo inactive edge; mỗi null edge xóa identity cũ để một
  `CardUI` tái sử dụng vẫn tạo generation mới;
- đọc trực tiếp `CardUI.timingText +0xF0 -> UnityEngine.UI.Text.m_Text +0xE8`, giữ
  cả raw text lẫn normalized `PERFECT!/GOOD!/BAD`;
- correlation hỗ trợ generic response envelope bằng exact MatchId, unique completed
  QTE, explicit reject/success nếu có và server timestamp trong bounded window;
- participant resource/HP được đọc trực tiếp quanh response, không phụ thuộc board
  phải stable ở đúng frame đó.

### Final closure live 20260904_003250 — PASS STRONG

Observer mới bind đúng một generation của match `M_a1cbb4b1`, turn 33, local actor
1. Server sequence và exact recorded presses đều là:

```text
Right, Down, Right, Up, Down, Up, Right
```

`currentIndex=7`, `correctCount=7`, elapsed `3.151977s` nằm trong server window
inclusive `[3.000, 3.300]s`. Ba nguồn độc lập đồng ý:

```text
native prediction       = PERFECT!
CardUI.timingText RAM   = PERFECT!
operator visual result  = PERFECT!
```

Current `MATCH_SKILL_USE_RES` có exact MatchId, timestamp trong response window,
không reject và được correlate bằng provenance
`CURRENT_ENVELOPE_TEMPORAL_SESSION`. Resource trực tiếp tại cùng action:

```text
before: mana=274, power=215
after:  mana=74,  power=15
delta:  mana=-200, power=-200
```

Điều này đóng một discrepancy quan trọng: raw `manaCost/powerCost` của card đều 0,
nhưng effective requirement/deduction của chính `Huyền Thoại 7` là
`conditionUse=200` mana và `power=200` nộ. Hai nguồn raw phải được giữ riêng; không
được dùng generic cost fields 0 như bằng chứng “skill miễn phí”, và không được suy
rộng 200/200 cho pet skill khác.

Turn trước/sau response đều là turn 33 và owner vẫn `happi`, nên skill này là
functional/non-consuming action. Board hash và HP chưa đổi ngay tại response vì
effect/cascade diễn ra sau đó; người dùng quan sát skill ăn nhiều Sword. Kết hợp
với native `ATTACK_LEGEND_ -> CalculateDotsToDestroy` và không có selectedRows/
selectedDots, effect được đóng ở mức automatic dot destruction, không manual
targeting. Exact số dot server áp dụng cho lần này vẫn UNKNOWN vì response envelope
không echo `dotsToDestroy`; không được tuyên bố `PERFECT = max Sword`.

Discrepancy lịch sử về một lần user thấy `BAD` trong retry trước vẫn được ghi lại,
nhưng không còn là advance blocker: current authoritative PERFECT result đã được
đọc trực tiếp và correlate; Phase 3B.1 có thể nhắm exact Perfect predicate thay vì
dựa vào nhánh late-result chưa cần dùng.

## 1. Accepted base và phạm vi

- `HEAD == origin/main == 415e97dcaddd29e23a78febb7a20d562cf9165af` trước khi sửa.
- Worktree sạch trước Phase 3A.1.
- Repository hiện khai báo source version `v1.0.23`; con số `v1.0.1` trong prompt
  cũ hơn repository truth nên không bị hạ version.
- Chỉ đọc `D:\pc\GameAssembly.dll` và `reverse/redux_compat`.
- Runtime smoke attach thành công PID `8332`, x64, chỉ dùng
  `PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`.
- Không có `WriteProcessMemory`, IL2CPP invocation, click, phím, network call hay
  thay đổi BASIC policy.

## 2. Static/native closure

| Class | Member | VA bản 1.7.4 | Caller/callee và state transition chính | Mức chứng cứ |
|---|---|---:|---|---|
| `PetUserDTO` | `petId`, `skillCardId`, `manaSkillCard`, `cardDTO` | fields `+0x1C`, `+0x20`, `+0x70`, `+0x90` | `Active.playerPets +0x300` sở hữu pet chính; `cardDTO` trỏ tới `CardData` | PROVEN_STATIC |
| `CardUI` | `IsDotSkillCard` | `0x1805B6980` | So sánh `CardData.elementTypeCard` với `ATTACK_LEGEND`/`ATTACK_LEGEND_` | PROVEN_STATIC |
| `CardUI` | `RequiresDotSkillUI` | `0x1805B9550` | Cùng predicate family ở trên | PROVEN_STATIC |
| `CardUI` | `HandleDotSkillSequence` / state machine | `0x1805B6410` / `0x1805CF430` | Request challenge → đợi server arrows → apply window → hiện QTE → pause clock → nhận input/confirm → resume → `SendSkillUse` | PROVEN_STATIC |
| `CardUI` | `NormalizeArrowDir` | `0x1805B7B30` | Trim, bỏ prefix `nut` không phân biệt hoa thường, chỉ nhận up/down/left/right | PROVEN_STATIC |
| `CardUI` | `GenerateDotArrows` | `0x1805B50F0` | Ưu tiên `MatchService.ServerQteArrows`; chỉ dùng random/local fallback khi list server vắng | PROVEN_STATIC |
| `CardUI` | `CheckDotArrow` | `0x1805B0E20` | Append `qtePresses` (cap 64), so sánh hướng hiện tại, tăng index/correct; sai thì reset index | PROVEN_STATIC |
| `CardUI` | `Update` | `0x1805BCD10` | Arrow/WASD gọi `CheckDotArrow`; Return/Space gọi timing completion | PROVEN_STATIC |
| `CardUI` | `OnEnterButtonPress` | `0x1805B7E80` | Chỉ có hiệu lực khi active và chưa finished; set finished đúng một lần | PROVEN_STATIC |
| `CardUI` | `ApplyServerQteWindow` | `0x1805B0100` | Copy `MatchService.ServerQteWindow` từ ms sang giây vào CardUI | PROVEN_STATIC |
| `CardUI` | `CurrentQteElapsedMs` | `0x1805B4700` | Round/clamp `duration * (1-currentTimeValue) * 1000` | PROVEN_STATIC |
| `CardUI` | `GetLastTimingResult` | `0x1805B5FF0` | Phân loại `PERFECT!`/`GOOD!`/`BAD` bằng current runtime window | PROVEN_STATIC |
| `CardUI` | `timingText` / `Text.m_Text` | fields `+0xF0` / `+0xE8` | Exact text mà game render sau confirm; observer mới đọc trực tiếp qua RAM | PROVEN_STATIC |
| `CardUI` | `CalculateDotsToDestroy` | `0x1805B0430` | Nhánh `ATTACK_LEGEND_` dùng correct/timing và `eatPerfect/eatGood/eatBad` | PROVEN_STATIC |
| `MatchService.QteWindow` | `Valid` | `0x180340060` | `durationMs > 0 && perfectEndMs > perfectStartMs` | PROVEN_STATIC |
| `MatchService` | `RequestQteChallenge` | `0x18033A5D0` | Clear server arrows rồi gửi start cho `CurrentMatchId + skillCardId` | PROVEN_STATIC |
| `MatchService` | `HandleQteChallenge` | `0x1803381F0` | Chỉ nhận DTO có `matchId == CurrentMatchId`; lưu 7 timing fields và arrows | PROVEN_STATIC |
| `MatchService` | `SendSkillUse` | `0x18033AD20` | Chuyển correct/result/dots/presses/elapsed sang `WsMatchClient`; sau đó clear arrows | PROVEN_STATIC |
| `MatchService` | `HandleMatchSkillUseRes` | `0x180337B50` | Chuyển `MATCH_SKILL_USE_RES` vào response-envelope/server resolution | PROVEN_STATIC |

### Exact PC mapping

Native `CardUI.Update` chứng minh hai binding song song:

| Hướng canonical | Unity `KeyCode` | Alternative | Mức chứng cứ |
|---|---:|---:|---|
| `nutUp` | `UpArrow = 0x111` | `W = 0x77` | PROVEN_STATIC |
| `nutDown` | `DownArrow = 0x112` | `S = 0x73` | PROVEN_STATIC |
| `nutLeft` | `LeftArrow = 0x114` | `A = 0x61` | PROVEN_STATIC |
| `nutRight` | `RightArrow = 0x113` | `D = 0x64` | PROVEN_STATIC |

Confirm là **Return/Enter (`0x0D`) hoặc Space (`0x20`)**. Cả hai đi vào cùng
nhánh khi `isDotSkillActive == true && hasFinishedDotSkill == false`. Confirm
sớm vẫn kết thúc QTE và vì vậy có thể cho kết quả thấp; không có cơ chế tự động
confirm trong phase này.

### Authoritative sequence và progress

`HandleQteChallenge` chỉ nhận challenge đúng `CurrentMatchId`, sau đó ghi:

- `ServerQteArrows +0x200`;
- `ServerQteDurationMs +0x208`;
- `ServerQteWindow +0x20C..+0x224`.

`HandleDotSkillSequence` đợi list này rồi `GenerateDotArrows` dựng UI từ chính
list server. Có local fallback nếu server list vắng, nhưng hợp đồng observer mới
**từ chối fallback**: future automation chỉ được coi sequence là current khi list
server, QTE UI và session cùng khớp.

Progress runtime:

- `currentDotIndex +0x148`;
- `correctDotCount +0x14C`;
- `isDotSkillActive +0x150`;
- `hasFinishedDotSkill +0x170`;
- `qtePresses +0x320`.

Mỗi direction được append vào `qtePresses` trước khi so sánh. Direction đúng tăng
index và correct count; direction sai reset index. UI bắt đầu nhấp nháy confirm
khi `correctDotCount >= 7`, nhưng native confirm vẫn có thể được nhấn sớm.

### Perfect predicate

CardUI dùng:

```text
elapsedSeconds = dotSkillDuration * (1 - currentTimeValue)
qteElapsedMs   = clamp(round(elapsedSeconds * 1000), 0, round(duration * 1000))
```

Với `elementTypeCard == ATTACK_LEGEND_`:

```text
correctDotCount < 7                              => BAD
correctDotCount >= 7 và start <= elapsed <= end => PERFECT!
correctDotCount >= 7 ngoài Perfect interval      => GOOD!
```

Perfect dùng inclusive boundary. Với family khác, native còn dùng Good window 1
`[start1,end1)` và Good window 2 `(start2,end2]`. Observer không dùng hard-coded
sleep; nó đòi CardUI window bằng server window (sai số float tối đa 2 ms).

### Effect family conditional, chưa gán cho pet hiện tại

- `ATTACK_LEGEND_`: gọi `CalculateDotsToDestroy`, gửi `dotsToDestroy`, không gửi
  `selectedRows` hay `selectedDots`; đây là automatic dot-destruction family.
  Live B1 chứng minh card đang dùng thuộc đúng family này với
  `eatPerfect/eatGood/eatBad = 0/20/12`.
- `ATTACK_LEGEND` (không underscore): gửi `dotsToDestroy = 0`, selected rows/dots
  null; có nhánh presentation/damage riêng. Exact server effect vẫn cần live result.

## 3. Stale-QTE rejection contract

Observer chỉ đánh dấu `BOUND_CURRENT` sau khi tất cả điều kiện sau đúng:

```text
current MatchId
+ CombatSessionKey(lifecycle epoch, Board.Instance, MatchId)
+ local actor
+ exact post-evolution runtime CardData
+ CardUI.ActiveDotSkillCard
+ Active/Board ownership equality
+ inactive -> active edge trong chính session này
+ ServerQteArrows object + normalized sequence
+ currentArrows count
+ exact server/CardUI timing-window equality
+ current turn
+ observer generation
```

QTE được thấy giữa chừng, đổi MatchId, sai actor/card, nhiều candidate, unknown
direction, index vượt sequence, timing thiếu/đảo hoặc object/list đổi sau bind đều
fail closed. `currentArrowSeed` chỉ là identity bổ sung; không bị coi là RNG truth.

## 4. Read-only observer đã thêm

- `src/pokiguard_v2/pet_qte_observer.py`: decoder snapshot bất biến, timing
  classifier, result correlation và session tracker.
- `tools/pet_qte_observer.py`: CLI JSONL observer. Không import input executor.
- Khi response có full echo, correlation đòi cùng MatchId/card/progress/presses.
  Với envelope 1.7.4 không echo, correlation đòi unique completed generation,
  exact MatchId, bounded server timestamp và không có explicit reject.
- Smoke test attach-only 5 giây thành công; không có combat/QTE nên ghi 0 result,
  đúng kỳ vọng.

## 5. Required evidence status

| Finding | Hiện trạng | Phân loại |
|---|---|---|
| Main pet identity / category-rank | Source Silas `petId=2306`; sau tiến hóa mở `Huyền Thoại 7` | PROVEN_RUNTIME |
| `petId` | Source runtime `2306`; evolved card không thay PetUserDTO nguồn | STATIC_AND_RUNTIME |
| `skillCardId` | Source field 0/missing; post-evolution exact `CardData.cardId=7` | STATIC_AND_RUNTIME |
| Exact skill `CardData` | `Huyền Thoại 7`, level 14, multiplier 1.8 | PROVEN_RUNTIME |
| `skillType` | Runtime null; family dùng `elementTypeCard` | STATIC_AND_RUNTIME |
| `manaCost` | Raw runtime `0`; actual mana delta theo `conditionUse=200` | STATIC_AND_RUNTIME |
| `powerCost` | Raw runtime `0`; actual power delta theo `power=200` | STATIC_AND_RUNTIME |
| cooldown / condition / perfection | `0 / 200 / false` | STATIC_AND_RUNTIME |
| Current usability | Nhiều activation tay thành công; exact pre-click Button state chưa cần cho observer | PROVEN_RUNTIME |
| Actual QTE family | `ATTACK_LEGEND_` / CardUI Dot-QTE | STATIC_AND_RUNTIME |
| QTE activation | Active static field + flags + inactive edge | PROVEN_STATIC |
| Sequence source/representation | Current-match server `List<string>` → CardUI arrows | PROVEN_STATIC |
| Sequence session binding | Sáu generation current đã bind; QTE đầu cũ lộ/fix inactive-edge bug | STATIC_AND_RUNTIME |
| Direction mapping | Arrow/WASD đều đạt progress 7 và completion trong live | STATIC_AND_RUNTIME |
| Confirm input | Enter/Space đều hoàn tất live QTE; one-shot guard static | STATIC_AND_RUNTIME |
| currentIndex / correctCount / completion | Sáu completion bound, mỗi lần correct 7 | STATIC_AND_RUNTIME |
| Timing origin / Perfect window | Server ms → CardUI seconds, runtime windows khớp | STATIC_AND_RUNTIME |
| Runtime current timing / elapsed | Sáu full progression/timeline đã capture | STATIC_AND_RUNTIME |
| `qteElapsedMs` | Formula proven; runtime value tính được từ snapshot | STATIC_AND_RUNTIME |
| `timingResult` | Final live: predicted/RAM text/operator đều `PERFECT!`; một late historical conflict được giữ | STATIC_AND_RUNTIME |
| Turn consumption của skill đang sở hữu | Turn 33/local trước và sau current response | PROVEN_RUNTIME |
| Mana deduction | `274 -> 74`, exact `-200 == conditionUse` | PROVEN_RUNTIME |
| Rage/Power deduction | `215 -> 15`, exact `-200 == power` | PROVEN_RUNTIME |
| Actual effect / targetability | Owned card là automatic dot-destruction, không selected rows/dots | STATIC_AND_RUNTIME |
| `eatPerfect` semantics | Actual card `0/20/12`; automatic-dot branch proven, exact resolved count UNKNOWN | STATIC_AND_RUNTIME / partial |

## 6. Offline verification

- Focused Phase 3A.1 sau hardening: **22/22 PASS**.
- Bao phủ missing card, zero/negative cost, missing/stale/wrong-session/ambiguous
  QTE, sequence, unknown direction, timing invalid, progress invalid, completed
  QTE, old MatchId, exact result correlation, zero input và zero process-write path.
- Full regression sau hardening: **819/819 PASS**.
- `python -m compileall -q src tools tests`: **PASS**.
- `git diff --check`: **PASS** (chỉ có cảnh báo Git sẽ chuẩn hóa LF/CRLF trên
  một số file đã tồn tại; không có whitespace error).
- Smoke attach read-only sau hardening: **PASS**, lobby timeout 3 giây, không
  input/write/IL2CPP invocation và không có QTE giả.

## 7. Remaining UNKNOWN, không phải advance blocker

- Exact số dot/Sword server resolve trong một Perfect không được echo trong generic
  response; chỉ family automatic-dot và việc người dùng quan sát nhiều Sword bị ăn
  đã rõ. Không thiết kế Sword target solver ở phase này.
- Lần late completion lịch sử được user nhớ là `BAD` trong khi native prediction là
  `GOOD!` không có direct Text snapshot. Future controller không cần nhắm nhánh này;
  nó phải dùng authoritative Perfect interval.
- Quy tắc `conditionUse/power` hiện chỉ proven cho cardId 7 `Huyền Thoại 7`; pet
  skill khác phải đọc và live-validate CardData riêng, không hard-code 200/200.

Không còn UNKNOWN nào trong danh sách advance blocker của prompt. Phase 3A.1 đạt
**PASS STRONG**.
