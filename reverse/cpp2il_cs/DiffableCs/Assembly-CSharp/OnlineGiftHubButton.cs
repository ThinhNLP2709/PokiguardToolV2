//Type is in global namespace

public class OnlineGiftHubButton : MonoBehaviour
{
	private const float VISIBILITY_POLL = 0.25; //Field offset: 0x0
	private const float FADE_SPEED = 8; //Field offset: 0x0
	private const float REFETCH_COOLDOWN = 5; //Field offset: 0x0
	public GameObject point; //Field offset: 0x20
	public Text txtTimer; //Field offset: 0x28
	private OnlineGiftData _data; //Field offset: 0x30
	private float _fetchAtRealtime; //Field offset: 0x38
	private float _nextUiTick; //Field offset: 0x3C
	private bool _fetched; //Field offset: 0x40
	private float _lastFetchAttempt; //Field offset: 0x44
	private CanvasGroup _canvasGroup; //Field offset: 0x48
	private float _nextVisibilityCheck; //Field offset: 0x50
	private bool _shouldShow; //Field offset: 0x54
	private bool _hasClaimable; //Field offset: 0x55
	private Vector3 _baseScale; //Field offset: 0x58

	public OnlineGiftHubButton() { }

	[CompilerGenerated]
	private void <FetchOnce>b__19_0(string err) { }

	private void Awake() { }

	private void FetchOnce() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnStatus(OnlineGiftData data) { }

	private void OpenPanel() { }

	private void RefreshBadge(float now) { }

	private void Update() { }

}

