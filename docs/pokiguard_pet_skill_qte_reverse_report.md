# Pokiguard – Pet Skill QTE Reverse Report

## Addendum 2026-09-09 — final external completion boundary (v1.0.41)

Current build 1.7.4-b2 native evidence separates the mandatory pre-input
challenge from the post-Space resolution callback:

- `CardUI.<HandleDotSkillSequence>.MoveNext` calls
  `MatchService.SendSkillUse` at RVA `0x6F63D3`, then
  `CardUI.WaitForWsSkillResolution` at RVA `0x6F63F8`.
- `WaitForWsSkillResolution.MoveNext` reads
  `MatchService.get_IsRenderingCombat` at RVAs `0x6FA60E` and `0x6FA664`;
  managed defaults are `resWaitSec=3` and `renderWaitSec=14`.
- `HandleMatchSkillUseRes` RVA `0x395FA0` enters generic
  `HandleResEnvelope` RVA `0x396A70`, which parses ops/combat batches and
  applies server state internally.

Therefore the response remains meaningful to the **game**, but capturing that
short-lived managed envelope is not a valid mandatory acknowledgement for an
external read-only tool. Live logs prove CardUI runtime `PERFECT` and the skill
effect/win can occur with no externally retained callback. The corrected tool
contract is current server challenge -> closed-loop `7/7` -> one in-window
Space -> current CardUI runtime `PERFECT` -> immediate action success.
The game's subsequent board/resource changes and terminal outcome are outside
that input primitive. The one-shot starts no response tap, response heap scan,
transport capture or post-effect board wait. A later gameplay controller still
requires its normal fresh/actionable GameState before sending another input.
This supersedes both v1.0.39's callback requirement and v1.0.40's remaining
post-state requirement, without changing the game's server-authoritative model.

Latest supporting log:
`logs/phase3b3_pet_skill_action_20260909_b2_action1_v1040.jsonl`, ActionId
`530143a332e24f7fb584b7fee275ca11`. The exact generation reached 7/7, one
Space at 3.183324 s in `[3.0, 3.299999952]`, then runtime `PERFECT!`.
The external board publication failed for 30 seconds afterward; that does not
negate the observed successful QTE input. The game advanced source turn 79 to
81/83 during that old wait. The existing callback ownership findings below
remain reverse evidence for diagnostic use, not action completion requirements.

## Addendum build 1.7.4-b2 — 2026-09-07

The new exact reverse output is `reverse/reverse_1.7.4-b2`. It confirms the same
server-owned QTE model and input semantics, but the managed layouts moved.
Production now uses MatchService QTE fields at `+0x220/+0x228/+0x22C` and the
CardUI QTE block at `+0x58..+0x490`; exact field-by-field values are recorded in
[phase3b3_qte_timing_evidence.md](phase3b3_qte_timing_evidence.md). Skill-card
ownership now starts from `Board.cardContainer +0x328` and
`Board.cardsInHand +0x348`, with current native anchors recorded in
[phase3b3_native_card_evidence.md](phase3b3_native_card_evidence.md).

This addendum supersedes build-specific RVAs/offsets in the historical sections
below. It does not change the accepted gameplay rule or authorize direct game
method calls.

### Addendum: short-lived skill-response ownership

The latest B2 retry proved that repeated full heap rediscovery can still miss
`MATCH_SKILL_USE_RES`. The current native/Inspector output provides a direct
read-only owner chain before main-thread dispatch:

```text
UnityMainThreadDispatcher._executionQueue / instance._drainBuffer
  -> PendingAction.Action
  -> System.Action.m_target
  -> ChatService.__c__DisplayClass275_0
       |- json +0x18 -> immutable received websocket JSON
       `- message +0x20 -> deserialized/mutable ChatMessageDTO
```

Relevant current TypeInfo RVAs are dispatcher `0x2DE08F8`, pending-action
queue/list `0x2DE5D48/0x2DDB970`, and closure `0x2D97A60`. The closure's
`json`/`message` fields are `+0x18/+0x20`; native `OnWebSocketMessage` stores
the raw JSON at `0x37CA27`, writes the DTO at `0x37CA8C`, then reaches the
TryEnqueue call at `0x37CCEC`. v1.0.33 pre-arms this chain before card input.
Live evidence then showed some queued DTO payloads had already lost `board`
through pre-parse while the closure-owned JSON remained available. v1.0.35
decodes the raw string only after the DTO proves exact event/current MatchId,
and independently validates event, MatchId, `srvSeq`, 8x8 shape and all cell
semantics before the unchanged ACK/stability gate. It does not invoke
dispatcher/game methods, intercept network traffic or write target memory.
Live action `545efe7efae74f129d3d68f83efed806` then validated this chain:
the closure JSON retained current `MATCH_SKILL_USE_RES`, MatchId
`M_52debf2f`, `srvSeq=146` and a strict 64-cell board while the action resolved
runtime PERFECT. The raw decoder recorded one accepted board and zero semantic
rejections. Publication still remained subject to the independent latest-ACK
and presentation-stability gates.
The following action observed 44 stable callback roots while the mutable DTO
decoder returned no skill response. That evidence closes the ownership nuance:
`json +0x18` can remain usable after `message +0x20` is cleared or reused.
v1.0.37 therefore validates exact event/current MatchId directly from the raw
envelope first; it still requires the existing bounded temporal-generation
correlation and does not treat arbitrary callback JSON as a QTE result.
Live response `0x0000026706BD7000` then confirmed that a valid
`MATCH_SKILL_USE_RES` may omit both `board` and `srvSeq`. The same dispatcher
closure ownership applies to later current-match move/card responses that do
carry board snapshots. v1.0.38 retains those strict callback boards during the
bounded post-result interval; they remain candidates only until separately
confirmed by exact `_ackedSeqs` and presentation stability.

Live action `ef0116e70f014ef3a21cfdd152b98c4f` adds one lifecycle fact: a
lethal HT7 Perfect can close ACTIVE_COMBAT about 0.62 seconds after the QTE
finishes, before an external sample has retained the queued response. This does
not change response ownership or relax correlation. v1.0.39 simply keeps the
already pre-armed read-only tap bound to the original MatchId across that
post-Space terminal edge; a current callback and later same-match terminal
GameState are still mandatory.

**Ngày:** 2026-08-20  
**Phạm vi:** Reverse-engineering client Unity/IL2CPP từ `cpp2il_cs` và các kết quả reverse đã thu thập.

## 1. Kết luận chính

Có bằng chứng mạnh rằng game có một hệ thống skill/QTE riêng cho pet, gồm:
- sinh chuỗi nút/hướng;
- nhận input hướng;
- kiểm tra input;
- đếm input đúng;
- lưu chuỗi input QTE;
- theo dõi thời gian;
- gửi kết quả skill lên server.

Hai class quan trọng nhất là `SkillPetEspect` và `DotSkillManager`. `CardUI` có logic `DotSkillCard`, còn `MatchService`/`WsMatchClient` có protocol dành cho QTE.

Gameplay mô tả “nhấn thẻ skill pet → hiện lên/xuống/trái/phải → nhập chuỗi → hoàn tất để kích hoạt skill” **trùng rất sát với cấu trúc code**.

## 2. SkillPetEspect

Các member/method đáng chú ý:

```csharp
public class SkillPetEspect : MonoBehaviour
{
    public GameObject openBoard;
    public GameObject closeCardEspect;
    public GameObject nutPrefab;
    public Transform parentTransform;
    public Slider timeCombo;

    public int nutCount;
    public float spacing;
    public float scaleFactor;

    private int dem;
    private List<GameObject> nutObjects;
    private List<string> nutNames;
    private string[] keyBindings;
    private Sprite[] nutSpriteComplete;

    private void CreateNuts();
    private void HandleKeyPress(string key);
    private IEnumerator ScrollSlider(float duration);
    private void Update();
    private void UpdateNutSprite(int index);
}
```

Ý nghĩa có thể xác định từ tên/signature:
- `nutPrefab`: prefab nút QTE.
- `nutCount`: số nút.
- `nutObjects`: các UI object.
- `nutNames`: tên/key của nút.
- `keyBindings`: input bindings.
- `timeCombo`: timer/progress.
- `CreateNuts()`: tạo sequence.
- `HandleKeyPress()`: xử lý input.
- `UpdateNutSprite()`: đổi trạng thái hiển thị.
- `ScrollSlider()`: timer/progress.

**Chưa thể xác nhận** mapping key hoặc công thức điểm vì diffable C# không còn native method body đầy đủ.

## 3. DotSkillManager

```csharp
public class DotSkillManager : MonoBehaviour
{
    public GameObject arrowPrefab;
    public int arrowCount;
    public int correctCount;

    private List<Image> currentArrows;
    private string[] directions;
    private int currentIndex;

    private Dictionary<string, Sprite> blueArrows;
    private Dictionary<string, Sprite> purpleArrows;

    private void CheckArrow(string dir);
    public void GenerateArrows();
    private string GetDirectionFromInput();
    public void OnButtonPress(string dir);
    private void ResetCombo();
    private void Update();
}
```

Các identifier `arrowPrefab`, `directions`, `GetDirectionFromInput`, `CheckArrow`, `correctCount`, `currentIndex` là bằng chứng rất rõ cho directional QTE.

Flow ở mức kiến trúc:

```text
GenerateArrows()
 → directions[]
 → currentIndex
 → GetDirectionFromInput()
 → OnButtonPress(dir)
 → CheckArrow(dir)
 → correctCount++
 → next arrow / ResetCombo()
```

## 4. CardUI và Dot Skill

`CardUI` có:

```csharp
IEnumerator HandleDotSkillSequence(int userActorNumber);
bool IsDotSkillCard();
```

và state/data liên quan:
- `isDotSkillActive`
- `hasFinishedDotSkill`
- `currentDotSkillActorNumber`
- `dotSkillDuration`
- `qtePresses : List<string>`

`qtePresses` cho thấy chuỗi input QTE được lưu lại.

## 5. MatchService – QTE

Có:

```csharp
RequestQteChallenge(int skillCardId);
HandleQteChallenge(...);
SendSkillUse(...);
```

Signature đáng chú ý:

```csharp
SendSkillUse(
    int skillCardId,
    int correctDotCount = 0,
    string timingResult = "BAD",
    int dotsToDestroy = 0,
    List<int> selectedRows = null,
    List<List<int>> selectedDots = null,
    List<string> qtePresses = null,
    int? qteElapsedMs = null
);
```

Dữ liệu QTE gồm:
- `skillCardId`
- `correctDotCount`
- `timingResult`
- `qtePresses`
- `qteElapsedMs`

Điều này cho thấy QTE result được đưa vào dữ liệu skill-use, không chỉ là animation local.

## 6. Network/protocol

`WsMatchClient` có các event/action liên quan:
- `OnMatchQteChallenge`
- `SendSkillUse(...)`

`ChatMessageDTO` cũng có:
- `qtePresses`
- `qteElapsedMs`

High-level flow:

```text
Card selected
  ↓
RequestQteChallenge(skillCardId)
  ↓
QTE challenge
  ↓
QTE UI
  ↓
directions / input / correctCount / timing
  ↓
SendSkillUse(...)
  ↓
server resolves skill
```

Đây là kiến trúc suy ra từ các method/field đã reverse; chưa phải reconstruction byte-for-byte.

## 7. UP/DOWN/LEFT/RIGHT

Code có:
- `directions`
- `GetDirectionFromInput()`
- `OnButtonPress(string dir)`
- `CheckArrow(string dir)`
- arrow sprites

Do đó directional QTE được xác nhận ở mức kiến trúc. Native 1.7.4 sau đó đóng
mapping tại `CardUI.GetDirectionFromInput @ RVA 0x5B59A0`: method gọi legacy
`UnityEngine.Input.GetKeyDown` lần lượt với các cặp `DownArrow(274)/S(115)`,
`LeftArrow(276)/A(97)`, `RightArrow(275)/D(100)`, và
`UpArrow(273)/W(119)`. Live Phase 3B.2 xác nhận normal Windows arrow input đi
qua legacy keyboard synthesis làm `currentIndex/correctCount` tăng đúng 21/21.

## 8. Space / phím hoàn tất

Gameplay mô tả nhấn Space sau chuỗi.

Trong source hiện tại **chưa có bằng chứng đủ mạnh để xác nhận literal `KeyCode.Space`**.

Cần tìm trong native body:
```text
Input.GetKey(...)
Input.GetKeyDown(...)
KeyCode.Space
KeyCode.UpArrow
KeyCode.DownArrow
KeyCode.LeftArrow
KeyCode.RightArrow
```

## 9. Timing / Perfect / Good / Bad

`CardData` có:
- `needPerfection`
- `eatPerfect`
- `eatGood`
- `eatBad`

UI có các state:
- `Perfect`
- `Good`
- `Bad`
- `perfectMultiplier`
- `perfectStartTime`
- `perfectEndTime`
- `perfectBonus`

`SendSkillUse()` có:
- `timingResult`
- `qteElapsedMs`

=> có evidence cho timing/QTE evaluation.

**Chưa xác định** threshold và công thức Perfect/Good/Bad.

## 10. Pet Skill Card

`PetUserDTO` có:
```csharp
int petId;
Nullable<int> skillCardId;
int manaSkillCard;
CardData cardDTO;
```

`PetLibDTO` cũng có `skillCardId`.

Kho pet có:
```text
LoadPetSkillCard(int skillCardId, string description)
```

=> pet có skill card riêng và UI có logic hiển thị skill card/description.

## 11. CardData

```csharp
public class CardData
{
    public long id;
    public long cardId;
    public string name;
    public string description;
    public string elementTypeCard;
    public int value;
    public int maxLevel;
    public int count;
    public int level;
    public long conditionUse;
    public long power;
    public string skillType;
    public int manaCost;
    public int powerCost;
    public int cooldownTurns;
    public bool needPerfection;
    public int eatPerfect;
    public int eatGood;
    public int eatBad;
    public float damageMultiplier;
}
```

Đặc biệt đáng chú ý:
`skillType`, `manaCost`, `powerCost`, `cooldownTurns`, `needPerfection`, `damageMultiplier`.

## 12. Các family skill client phân biệt

`CardUI` có:
```text
IsAttackCard()
IsBuffCard()
IsDotSkillCard()
IsSkillCard()
IsMega1Card()
```

PVP có thêm:
```text
IsMega2Card()
```

Đây là danh sách family được evidence bởi method names; chưa phải danh sách đầy đủ `skillType` values.

## 13. Mega skills

### Mega1
Có:
```text
StartMega1Panel()
OpenMega1Panel()
ExecuteMega1RowDestruction()
OnMega1ToggleChanged(...)
Mega1WatchTurnTime(...)
mega1SelectedRows
```

Có vẻ liên quan lựa chọn/phá row; cần native body để xác nhận chi tiết.

### Mega2
Có:
```text
StartMega2Panel()
OpenMega2Panel()
ExecuteMega2DotDestruction()
TriggerMega2Explosion()
AlignMega2TogglesToBoard()
mega2SelectedDots
```

Có vẻ liên quan lựa chọn/phá cell.

## 14. Fusion skill

Có subsystem:
```text
FusionEnabled
FusionManaCost
FusionStatPercent
LocalFusionUsed
LocalFusionLastAttemptTurn
LocalFusionSelectedUserPetId
LocalFusionSelectedPetId
LocalFusionSkillCard
```

và:
```text
SendFusionUse(...)
OnFusionList
OnFusionResolved
```

Board có:
```text
AddFusionSkillCard(CardData cardData)
CreateCardHT(CardData cardData)
EnsureFusionCards()
```

=> Fusion Skill Card là một nhánh runtime card riêng.

## 15. Đã xác nhận

```text
[PASS] Pet có skillCardId
[PASS] Pet có CardData skill
[PASS] CardUI xử lý Dot Skill
[PASS] Có DotSkillManager
[PASS] Có directional arrow/QTE infrastructure
[PASS] Có correctCount
[PASS] Có qtePresses
[PASS] Có qteElapsedMs
[PASS] Có RequestQteChallenge
[PASS] Có SendSkillUse
[PASS] Có timingResult
[PASS] Có Perfect/Good/Bad concept
[PASS] Có Mega1/Mega2 infrastructure
[PASS] Có Fusion Skill infrastructure
```

## 16. Chưa xác nhận

```text
[UNKNOWN] Exact key mapping UP/DOWN/LEFT/RIGHT
[UNKNOWN] Space/confirm implementation
[UNKNOWN] Cách generate/random sequence
[UNKNOWN] Sequence do server hay client tạo
[UNKNOWN] Công thức correctCount
[UNKNOWN] Perfect/Good/Bad threshold
[UNKNOWN] qteElapsedMs được server validate thế nào
[UNKNOWN] Exact skillType string values
[UNKNOWN] Exact effect của từng skillCardId
[UNKNOWN] Danh sách đầy đủ pet skill cards
```

## 17. Reverse task tiếp theo

Ưu tiên:

### SkillPetEspect
```text
CreateNuts()
HandleKeyPress(string key)
Update()
UpdateNutSprite(int index)
ScrollSlider(float duration)
```

### DotSkillManager
```text
GenerateArrows()
GetDirectionFromInput()
CheckArrow(string dir)
OnButtonPress(string dir)
ResetCombo()
Update()
```

### CardUI
```text
HandleDotSkillSequence(int userActorNumber)
IsDotSkillCard()
```

### MatchService
```text
RequestQteChallenge(int skillCardId)
HandleQteChallenge(...)
SendSkillUse(...)
```

Mục tiêu là reconstruct state machine:

```text
CARD_SELECTED
 → QTE_REQUEST
 → QTE_CHALLENGE
 → GENERATE_SEQUENCE
 → WAIT_INPUT
 → CHECK_INPUT
 → UPDATE_PROGRESS
 → QTE_COMPLETE
 → SKILL_USE
 → SERVER_RESULT
```

## 18. Giá trị đối với Auto Tool V2

Sau khi reverse đủ, có thể thiết kế một `PetSkillController` độc lập:

```text
Game State
 ├── Board
 ├── Mana
 ├── Rage
 ├── HP
 ├── Pet
 └── Skill Card
       ↓
Skill Decision
       ↓
QTE Controller
 ├── detect challenge
 ├── obtain sequence
 ├── execute inputs
 ├── measure timing
 └── submit skill
```

Mục tiêu của phần này là tái sử dụng logic gameplay cho auto-play, không cần thay đổi game binary.

## 19. Kết luận

Code đã xác nhận khá rõ một subsystem **pet skill QTE/directional input** riêng.

Các thành phần chính:

```text
SkillPetEspect
DotSkillManager
CardUI
MatchService
WsMatchClient
ChatMessageDTO
CardData
PetUserDTO
```

tạo thành chuỗi từ pet skill card → QTE → input → kết quả skill.

Phần còn thiếu để hiểu chính xác gameplay là native method body của các hàm xử lý input/QTE. Đây nên là mục reverse tiếp theo.

## 20. Phase 3A.1 closure — Pokiguard 1.7.4 (2026-09-03)

Phần 1–19 ở trên là lịch sử evidence từ artifact cũ. Native body của build 1.7.4
trong `reverse/redux_compat` và `D:\pc\GameAssembly.dll` nay đã đóng nhiều UNKNOWN;
không xóa lịch sử để tránh biến giả thuyết cũ thành bằng chứng mới.

### Thay đổi layout cần lưu ý

`PetUserDTO.skillCardId` của build 1.7.4 hiện tại là `int +0x20`, không phải
`Nullable<int>` như artifact cũ. Giá trị 0 được observer giữ là missing; không tự
suy ra card. `PetUserDTO.cardDTO +0x90` phải có `CardData.cardId` khớp
`skillCardId` trước khi dùng làm identity.

### Những điểm đã đóng bằng native body

- `CardUI.IsDotSkillCard 0x1805B6980` và `RequiresDotSkillUI 0x1805B9550`:
  family QTE được chọn bởi `CardData.elementTypeCard == ATTACK_LEGEND` hoặc
  `ATTACK_LEGEND_`. Không được nhầm field này với `CardData.skillType`.
- `MatchService.HandleQteChallenge 0x1803381F0`: chỉ nhận đúng current MatchId,
  lưu server `arrows`, duration và sáu mốc Perfect/Good.
- `CardUI.GenerateDotArrows 0x1805B50F0`: ưu tiên exact server arrow list. Local
  random fallback tồn tại nhưng không đủ authoritative cho future automation.
- `CardUI.NormalizeArrowDir 0x1805B7B30`: trim, bỏ prefix `nut`, map chính xác
  up/down/left/right thành `nutUp/nutDown/nutLeft/nutRight`.
- `CardUI.Update 0x1805BCD10`: Up/Down/Left/Right hoặc W/S/A/D đều được nhận;
  Return hoặc Space đều là confirm.
- `CardUI.CheckDotArrow 0x1805B0E20`: ghi presses, current index và correct count;
  completion UI đạt ở correct count 7.
- `CardUI.GetLastTimingResult 0x1805B5FF0`: Perfect dựa trên runtime elapsed và
  inclusive `[perfectStartTime, perfectEndTime]`, không dựa trên blind sleep.
- `CardUI.CurrentQteElapsedMs 0x1805B4700`: round/clamp elapsed sang ms.
- `CardUI.HandleDotSkillSequence` state machine `0x1805CF430`: request challenge,
  apply server window, pause/resume QTE clock, rồi chuyển exact
  correct/result/dots/presses/elapsed sang `MatchService.SendSkillUse`.
- `ATTACK_LEGEND_` gọi `CalculateDotsToDestroy 0x1805B0430`; nhánh này dùng
  `eatPerfect/eatGood/eatBad` để tính/cap dot count, không dùng selected rows/dots.

### Observer read-only

`tools/pet_qte_observer.py` dùng `CardUI.ActiveDotSkillCard` static backing field,
không heap-pick object mới nhất. Một QTE chỉ được bind sau current-session inactive
edge và phải khớp MatchId, lifecycle epoch, Board, Active, actor, runtime CardData,
server list, currentArrows count, timing window, turn và observer generation.
Midstream/stale/ambiguous/unknown đều bị từ chối.

Tại milestone này static/offline closure và 19 focused tests đã PASS. Các giá trị
còn **UNKNOWN** ở thời điểm đó được đóng dần bởi live B1–B4 bên dưới. Xem
`docs/phase3a1_report.md` và `docs/phase3a1_runbook.md`.

### Runtime correction: skill card materializes after in-combat evolution

Live attempt `20260903_232239` proved `Active.playerPets` can remain the ordinary
source pet (`Silas`, `petId=2306`, no `skillCardId/cardDTO`) even after the player
successfully evolves and opens the Legendary Pet Skill/QTE. Consequently,
`PetUserDTO.cardDTO` is useful when present but is not a mandatory runtime owner
for this in-combat evolution path.

The current authoritative observation boundary is the newly available combat
card followed by exact `CardUI.ActiveDotSkillCard.cardData` at QTE activation.
The existing Board/Active/actor/MatchId/server-sequence/inactive-edge checks are
preserved. This is a correction to observer ownership only; it does not authorize
QTE input or change gameplay policy. Trạng thái pending tại thời điểm correction
này được cập nhật bởi retry bên dưới.

### Runtime closure retry và result hardening (2026-09-04)

`phase3a1_pet_qte_20260904_000854.jsonl` chứng minh exact post-evolution card là
`Huyền Thoại 7`, `CardData.cardId=7`, family `ATTACK_LEGEND_`, level 14,
`conditionUse=200`, `manaCost=0`, `powerCost=0`, `cooldownTurns=0`,
`needPerfection=false`, `eatPerfect/Good/Bad=0/20/12` và multiplier 1.8. Source
`PetUserDTO` vẫn là Silas/petId 2306 không skill; QTE card materializes riêng sau
tiến hóa. Sample mana/power 330/45 của retry này đến từ stable-board snapshot có
thể trễ so với QTE; final direct-participant trace bên dưới thay thế nó cho resource
proof.

Sáu QTE được thấy; năm generation sau bind đầy đủ và hoàn tất với correctCount 7.
Arrow/WASD và Space/Enter đều hoạt động trong live, phù hợp native mapping. Bốn
completion ở Perfect window; một completion khoảng 4.95 giây được native
`GetLastTimingResult` suy ra `GOOD!`, nhưng người dùng báo game hiển thị `BAD`.
Vì observer cũ không đọc UI Text nên classification này là conflict, không phải
evidence đã đóng.

Layout hiện bổ sung `CardUI.timingText +0xF0` và
`UnityEngine.UI.Text.m_Text +0xE8` từ current reverse. Observer giữ raw text và
normalized result để retry tiếp theo lấy chính chữ game render, không OCR và không
đoán. Lỗi inactive edge cũng được sửa: trạng thái singleton `instance_null` là
freshness witness thật và xóa identity generation trước.

Native `HandleMatchSkillUseRes 0x180337B50` đi qua generic response-envelope path.
Live response đúng MatchId/timestamp để các field QTE-specific null, vì vậy exact
echo-only correlation cũ là sai. Correlation mới nhận envelope chỉ khi có unique
completed QTE, exact MatchId, bounded server timestamp và không explicit reject;
old response object vẫn bị loại. Resource/HP được đọc trực tiếp quanh response mà
không đợi board stable. Focused 22/22 và full 819/819 PASS; một direct-result live
retry vẫn bắt buộc trước khi Phase 3A.1 được chốt.

### Final direct-result closure — PASS STRONG

`phase3a1_pet_qte_20260904_003250.jsonl`, match `M_a1cbb4b1`, turn 33 đã bind
generation hiện tại và capture sequence/presses giống hệt nhau:
`Right,Down,Right,Up,Down,Up,Right`. Progress kết thúc ở index/correct 7/7,
elapsed 3.151977 giây trong server Perfect window `[3.000,3.300]`. Native
prediction, exact `CardUI.timingText.m_Text` và visual result do operator báo đều
là `PERFECT!`.

Current generic `MATCH_SKILL_USE_RES` được bind bằng exact MatchId, bounded server
timestamp, unique completed generation và no reject. Direct resources đổi từ
mana/power `274/215` thành `74/15`: deduction chính xác `-200/-200`. Vì raw
`manaCost/powerCost` là `0/0`, effective contract của riêng cardId 7 là
`conditionUse=200` mana và `power=200` nộ. Không suy rộng contract này cho card
khác.

Turn trước/sau đều là turn 33 và owner local, chứng minh skill không tiêu thụ lượt.
Immediate response sample chưa đổi board hash/HP; operator sau đó thấy nhiều Sword
bị ăn. Native family xác định automatic dot destruction và không có manual rows/
dots target. Exact `dotsToDestroy` không được envelope echo nên vẫn UNKNOWN; không
tuyên bố Perfect luôn tối đa Sword. Phase đạt **PASS STRONG**, focused 22/22 và
full 819/819 PASS, không có automated QTE input hay process write.

## 21. Phase 3B.1 production correction — gross/net resource và turn edge

Production live `phase3b1_qte_shadow_20260904_012107.jsonl` quan sát ba manual
QTE generation trong MatchId `M_631e9914`. Ba server sequence đều khớp toàn bộ
ba bộ `qtePresses` 7/7, với kết quả runtime GOOD/PERFECT/PERFECT. Supplemental
live `phase3b1_live_retry_20260904_013537.jsonl`, MatchId `M_c2a5fef6`, quan sát
generation thứ tư 7/7, elapsed 3.008 giây trong Perfect window
`[3.000,3.300]`, runtime result PERFECT và current generic
`MATCH_SKILL_USE_RES`. Envelope vẫn không echo `timingResult`.

Hai immediate-response fixture xác nhận semantics resource đúng:

```text
conditionUse = 200  -> Mana tiêu hao
power        = 200  -> Nộ tiêu hao của Huyền Thoại 7
manaCost     = 0    -> raw field
powerCost    = 0    -> raw field
```

Immediate sample Phase 3A.1 đọc Mana/Nộ `274/215 -> 74/15`, đúng gross delta
`-200/-200`. Sample Phase 3B.1 muộn đọc `262/250 -> 62/250` sau automatic board
effect. User xác nhận skill hấp thụ Kiếm/Máu/Nộ trên board; net Nộ 0 có thể là
gross `-200` rồi được cộng lại từ các viên Nộ/cascade. Vì vậy snapshot muộn là
`AMBIGUOUS` cho cost attribution, không phủ nhận immediate cost. Resolver lấy
giá trị từ exact runtime CardData/structural family, không hard-code pet ID,
card ID, tên hoặc literal cost.

Sau Space, Pet Skill tự phá board/cascade; operator không cần và không thực hiện
manual SWAP cho effect đó. Sample production thấy HP `48970 -> 64058` và turn
local 41 chuyển sang boss 42. Do đó Huyền Thoại 7 tiêu hao lượt. Sample Phase
3A.1 giữ turn 33 đã được đọc trước khi automatic effect/turn edge hoàn tất và
không còn là nguồn production cho turn semantics.

Production observer còn sửa hai freshness/timing vấn đề: vùng ChatMessageDTO đã
học được scan trước full bounded fallback để bắt response ngắn; timingText giữ
lại từ QTE trước bị bỏ qua cho đến khi generation hiện tại có `finished=true`.
Tổng live Phase 3B.1 là 28/28 manual directions, zero mismatch, zero stale
generation được dùng current. Exact `dotsToDestroy` vẫn UNKNOWN vì generic
response không echo và cascade/refill làm board diff không đủ chứng minh exact
skill count.

### Optional Huyền Thoại 2 live fixture

`phase3b1_second_legendary_ht2_20260904_020332.jsonl` quan sát pet chính
`Spectre`, petId `2227`, hệ `METAL`, tiến hóa thành exact runtime
`Huyền Thoại 2`, cardId `2`, element `ATTACK_LEGEND`. CardData đọc
`conditionUse=200`, `power=150`, raw `manaCost/powerCost=0/0`, `value=5000`,
multiplier `1.4`, cooldown 0. Immediate resource đổi `387/246 -> 187/96`, chứng
minh cost `200 Mana + 150 Nộ` cho fixture này.

QTE sequence `Up,Up,Left,Up,Left,Up,Down` khớp 7/7, elapsed 3.091 giây trong
Perfect window và runtime result PERFECT. Generic response current đã correlate,
nhưng observer dừng trước boss damage/final turn edge; exact damage formula và
turn semantics của HT2 vẫn UNKNOWN. Fixture này không được tích hợp gameplay
policy.

## 22. Làm rõ thứ tự thẻ và tái sử dụng luồng cũ (2026-09-04)

Nguồn phần này là **mô tả trực tiếp của user** và live Phase 3B.3, không phải
suy ra offset/thứ tự chỉ từ tên method trong reverse.

- Pet chính có skill: **Skill pet chính -> Tiến hóa -> các thẻ user chọn**.
- Pet chính thường, pet tiến hóa có skill: **Tiến hóa -> các thẻ user chọn ->
  Skill pet tiến hóa**; thẻ cuối chỉ xuất hiện sau tiến hóa thành công.
- Số thẻ user chọn thay đổi; không cố định skill ở slot 0/4 cho mọi loadout.

Case tiến hóa khớp native `Board.AddFusionSkillCard` và live current hand của
`M_bfb931a0`/`M_cf7e3c5a`: skill mới được thêm ở cuối, Evolution vẫn là object
riêng. Chi tiết method RVA/ownership/geometry trong
[phase3b3_native_card_evidence.md](phase3b3_native_card_evidence.md).
Case pet chính có skill là user-confirmed, chưa live-accept trong đợt này.

Luồng skill hiện đã dùng lại `combat_cards` validator, model thẻ, cost resolver,
`transform_for_capture`, visual region metrics và `ForegroundClickExecutor`.
Resolver slot cũ chỉ chấp nhận standard Evolution + selected cards; việc có
Pet Skill không tự mở authority của shortcut đó. Bổ sung hai kiểu bố cục phải
giữ exact current identity/Button/resource checks, không thay bằng phỏng đoán
tọa độ từ cấu hình.

User yêu cầu ở phase sau có Preferences chọn pet chính/loại pet chính và pet
tiến hóa/loại tiến hóa. Đã lưu quy tắc tại [DECISIONS.md](DECISIONS.md).
Chưa thêm UI này và chưa tích hợp Pet Skill vào BASIC ở Phase 3B.3.

## 23. Deadline QTE và timing regression (2026-09-04)

Retry 6 đã tự bấm đúng thẻ HT7 nhưng full board/card polling làm hướng/ACK
cách nhau khoảng một giây: 5/7 khi timeout, BAD, không gửi Space. Đã đối chiếu
`ApplyServerQteWindow`, `HandleDotSkillSequence.MoveNext`, `GetLastTimingResult`
với native code 1.7.4. QTE dùng duration/Perfect window hiện tại; elapsed dựa
trên `Time.deltaTime` và currentTimeValue, không phải 14 s của lượt đấu.

Trong fixture này, tổng thời gian 5 s nhưng Perfect chỉ 3.0–3.3 s. Phải có đủ
7/7 trước confirm trong cửa sổ đó. Không hard-code các số fixture cho mọi skill.
Đã tách control-only poll khỏi full provider, giữ nguyên backend/ACK 3B.2 và
thêm chặn Space nếu RAM chưa thực sự vào Perfect khi Unity bị đứng hình.
Chi tiết evidence/native RVA, test và phần live còn thiếu:
[phase3b3_qte_timing_evidence.md](phase3b3_qte_timing_evidence.md).

## 24. Board hậu Pet Skill trong response envelope (2026-09-05)

Native build 1.7.4 xác nhận `HandleMatchSkillUseRes` RVA `0x337B50` chỉ là
wrapper chuyển `ChatMessageDTO` và kind metadata vào `HandleResEnvelope` RVA
`0x338540`. Hàm envelope kiểm tra exact current MatchId, đọc
`ChatMessageDTO.matchPayload +0xC8`, gọi `ParseOps`, `ApplyStateDelta`, rồi gọi
`ParseCombatBatch` RVA `0x338AE0`. `WsCombatBatch` khai báo `srvSeq +0x10` và
`BoardCellDTO[][] board +0x38`.

Do đó `MATCH_SKILL_USE_RES.matchPayload` là một transport board candidate cùng
pipeline với MOVE/CARD response. Đây không có nghĩa mọi response chắc chắn có
board: external decoder chỉ chấp nhận khi payload thực tế chứa cả bounded
`srvSeq` và strict 8x8 `board`. Sau exact current QTE correlation, snapshot này
được offer vào provider nhưng vẫn chưa publish cho tới khi sequence khớp
`MatchService._ackedSeqs` và tất cả owner/render/stability checks đạt. Payload
thiếu/sai giữ UNKNOWN; bare ACK không được coi là board.

Evidence runtime retry 13: QTE PERFECT và current response correlated, nhưng
decoder cũ không offer event skill nên 37 post-state polls kẹt ở unresolved
latest ACK. Fix offline **1020/1020 tests PASS**; live proof của payload board
và final fresh GameState còn pending.
