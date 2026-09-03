# Pokiguard – Pet Skill QTE Reverse Report

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

Do đó directional QTE được xác nhận ở mức kiến trúc.

Tuy nhiên chưa thể khẳng định literal mapping `UP/DOWN/LEFT/RIGHT` hoặc key code cụ thể từ diffable C#.

Cần reverse native:
```text
SkillPetEspect.Update()
SkillPetEspect.HandleKeyPress()
DotSkillManager.Update()
DotSkillManager.GetDirectionFromInput()
DotSkillManager.CheckArrow()
```

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
