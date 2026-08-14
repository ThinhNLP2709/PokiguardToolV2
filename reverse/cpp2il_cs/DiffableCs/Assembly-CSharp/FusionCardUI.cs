//Type is in global namespace

[DisallowMultipleComponent]
public class FusionCardUI : MonoBehaviour
{
	public const string PREFAB_PATH = "Prefabs/UI/CardFusion"; //Field offset: 0x0
	private const float DimUsable = 1; //Field offset: 0x0
	private const float DimLocked = 0.62; //Field offset: 0x0
	private const float DimUsed = 0.42; //Field offset: 0x0
	private static readonly Vector2 CardSize; //Field offset: 0x0
	public const string CARD_NODE = "cardFusion"; //Field offset: 0x0
	[SerializeField]
	private Image imgGlow; //Field offset: 0x20
	[SerializeField]
	private Image imgtCard; //Field offset: 0x28
	[SerializeField]
	private Image imgFusionPet; //Field offset: 0x30
	[SerializeField]
	private Image imgManaBadge; //Field offset: 0x38
	[SerializeField]
	private Text txtMana; //Field offset: 0x40
	[SerializeField]
	private Text txtLabel; //Field offset: 0x48
	[SerializeField]
	private GameObject usedOverlay; //Field offset: 0x50
	private Button _btn; //Field offset: 0x58
	private float _nextRefreshAt; //Field offset: 0x60
	private long _boundPetId; //Field offset: 0x68
	private Color _manaTextBase; //Field offset: 0x70
	private Color _manaBadgeBase; //Field offset: 0x80
	private Color _petBase; //Field offset: 0x90
	private Color _labelBase; //Field offset: 0xA0
	private bool _baseCaptured; //Field offset: 0xB0

	private static FusionCardUI() { }

	public FusionCardUI() { }

	private void AutoFindRefs() { }

	private void Awake() { }

	private void CaptureBaseColors() { }

	private static Color Dimmed(Color baseColor, float factor) { }

	private Transform FindDeep(string nodeName) { }

	private void OnEnable() { }

	private void RefreshState() { }

	public static GameObject Spawn(Transform parent, GameObject baseCardPrefab) { }

	private void Update() { }

}

