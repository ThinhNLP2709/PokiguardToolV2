//Type is in global namespace

[DisallowMultipleComponent]
public class WeaponBadgeUI : MonoBehaviour
{
	public const string NODE = "weaponBadge"; //Field offset: 0x0
	public const string BG_PREFIX = "weaponBg_"; //Field offset: 0x0
	public const float BG_ALPHA = 0.92; //Field offset: 0x0
	[Header("Refs — để trống sẽ tự tìm theo tên trong Awake")]
	[SerializeField]
	private Image imgIcon; //Field offset: 0x20
	[SerializeField]
	private Text txtStar; //Field offset: 0x28
	[Header("Tùy chọn")]
	[Tooltip("Bấm badge để mở tooltip xem nhanh thông số.")]
	public bool clickable; //Field offset: 0x30
	[Header("Chế độ NỀN — ảnh vũ khí vẽ SAU avatar thay vì badge góc")]
	[SerializeField]
	[Tooltip("Bật khi node này là NỀN phía sau avatar: alpha dịu lại và (nếu có sortingCanvas) lớp vẽ = avatar − 1 thay vì + 2.")]
	private bool backgroundMode; //Field offset: 0x31
	[Header("Sorting — CHỈ dùng khi badge nằm cạnh avatar SpriteRenderer (slot phòng chờ coop/PVP)")]
	[SerializeField]
	[Tooltip("Canvas riêng trên node badge (overrideSorting). Trống = không đụng gì tới sorting.")]
	private Canvas sortingCanvas; //Field offset: 0x38
	[SerializeField]
	[Tooltip("SpriteRenderer avatar để bám sorting layer/order. Trống = không đụng gì tới sorting.")]
	private SpriteRenderer avatarRenderer; //Field offset: 0x40
	private Button _button; //Field offset: 0x48
	private Outline _outline; //Field offset: 0x50
	private long _ownerUserId; //Field offset: 0x58
	private UserWeaponDTO _cachedData; //Field offset: 0x60
	private int _lastImageId; //Field offset: 0x68
	private string _lastRarity; //Field offset: 0x70
	private int _lastStar; //Field offset: 0x78

	public WeaponBadgeUI() { }

	public static void Apply(WeaponBadgeUI badge, int imageId, string rarity, int star = 0, long ownerUserId = 0) { }

	private void ApplyRarityOutline(string rarity) { }

	private void ApplySorting() { }

	private void AutoWire() { }

	private void Awake() { }

	public static WeaponBadgeUI FindUnder(Component avatarNode) { }

	public void Hide() { }

	private void OpenTooltip() { }

	private static WeaponBadgeUI Pick(Transform t) { }

	public void SetData(int imageId, string rarity, int star = 0) { }

	public void SetFullData(UserWeaponDTO data) { }

	public void SetOwner(long userId) { }

	private void SetupClick() { }

}

