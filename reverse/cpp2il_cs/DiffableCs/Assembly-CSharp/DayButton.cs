//Type is in global namespace

public class DayButton : MonoBehaviour
{
	[Header("UI Components")]
	public Image imgcheck; //Field offset: 0x20
	public Image imgRW; //Field offset: 0x28
	public Text txtCount; //Field offset: 0x30
	public Text txtDay; //Field offset: 0x38
	public Button btnDay; //Field offset: 0x40
	[Header("Sprites")]
	public Sprite goldSprite; //Field offset: 0x48
	public Sprite starWhiteSprite; //Field offset: 0x50
	public Sprite starRedSprite; //Field offset: 0x58
	public Sprite rubySprite; //Field offset: 0x60
	public Sprite energySprite; //Field offset: 0x68
	public Sprite wheelDaySprite; //Field offset: 0x70
	private DailyCheckInData checkInData; //Field offset: 0x78
	private Action<DailyCheckInData> onClaimCallback; //Field offset: 0x80

	public DayButton() { }

	private string FormatNumber(int number) { }

	private void OnButtonClick() { }

	public void Setup(DailyCheckInData data, Action<DailyCheckInData> onClaim) { }

	private void Start() { }

	public void UpdateClaimStatus(bool claimed) { }

	private void UpdateVisualState() { }

}

