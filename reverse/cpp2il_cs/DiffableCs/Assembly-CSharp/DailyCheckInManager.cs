//Type is in global namespace

public class DailyCheckInManager : MonoBehaviour
{
	[Header("Panel References")]
	public GameObject PanelDiemDanh; //Field offset: 0x20
	public GameObject bg; //Field offset: 0x28
	public Transform list; //Field offset: 0x30
	public GameObject Day; //Field offset: 0x38
	public Text txtDiemdanh; //Field offset: 0x40
	public Button btnBack; //Field offset: 0x48
	[Header("Sprites")]
	public Sprite goldSprite; //Field offset: 0x50
	public Sprite starWhiteSprite; //Field offset: 0x58
	public Sprite starRedSprite; //Field offset: 0x60
	public Sprite rubySprite; //Field offset: 0x68
	public Sprite energySprite; //Field offset: 0x70
	public Sprite wheelDaySprite; //Field offset: 0x78
	[Header("Notification")]
	public GameObject notificationPanel; //Field offset: 0x80
	public Text txtNotificationMessage; //Field offset: 0x88
	public Button btnCloseNotification; //Field offset: 0x90
	[Header("Loading")]
	public GameObject loadingPanel; //Field offset: 0x98
	[Header("Debug")]
	public bool debugMode; //Field offset: 0xA0
	private List<DayButton> dayButtons; //Field offset: 0xA8

	public DailyCheckInManager() { }

	private void Awake() { }

	private void CloseNotification() { }

	private string FormatNumber(int number) { }

	private int GetUserId() { }

	private void LoadCheckInData(int userId) { }

	private void OnCheckInDataError(string error) { }

	private void OnCheckInDataLoaded(List<DailyCheckInData> checkIns) { }

	private void OnClaimButtonClicked(DailyCheckInData checkInData) { }

	private void OnClaimError(string error) { }

	private void OnClaimSuccess(ClaimDailyRewardResponse response) { }

	private void OnDestroy() { }

	public void OpenPanel() { }

	private void ShowNotification(string message) { }

}

