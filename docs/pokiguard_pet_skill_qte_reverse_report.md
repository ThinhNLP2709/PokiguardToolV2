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
