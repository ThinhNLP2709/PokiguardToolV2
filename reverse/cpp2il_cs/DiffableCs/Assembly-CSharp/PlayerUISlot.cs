//Type is in global namespace

public class PlayerUISlot : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public string capturedKickName; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal void <SetData>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public PlayerUISlot <>4__this; //Field offset: 0x10
		public int token; //Field offset: 0x18
		public string petId; //Field offset: 0x20

		public <>c__DisplayClass36_0() { }

		internal void <ReplacePetAnimations>b__0(AnimationClip[] clips) { }

	}

	private const int IDX_AVATAR = 0; //Field offset: 0x0
	private const int IDX_USERNAME = 2; //Field offset: 0x0
	private const int IDX_ENERGY = 3; //Field offset: 0x0
	private const int IDX_PASS_COUNT = 4; //Field offset: 0x0
	private const int IDX_PET = 5; //Field offset: 0x0
	private const int IDX_CARDS = 6; //Field offset: 0x0
	private const int IDX_LEVEL_FRAME = 1; //Field offset: 0x0
	[Header("UI References — gán sẵn, tự tìm khi null")]
	[SerializeField]
	private SpriteRenderer sprAvatar; //Field offset: 0x20
	[SerializeField]
	private Image imgLevelFrame; //Field offset: 0x28
	[SerializeField]
	private Text txtLevel; //Field offset: 0x30
	[SerializeField]
	private Text txtUserName; //Field offset: 0x38
	[SerializeField]
	private Text txtEnergyUI; //Field offset: 0x40
	[SerializeField]
	private Text txtPassUI; //Field offset: 0x48
	[SerializeField]
	private Text txtSansang; //Field offset: 0x50
	[SerializeField]
	internal SpriteRenderer imgSlotPet; //Field offset: 0x58
	public Button btnKick; //Field offset: 0x60
	public Image LeaderStar; //Field offset: 0x68
	[SerializeField]
	private WeaponBadgeUI weaponBadge; //Field offset: 0x70
	[Header("Voice Chat (đã gỡ voice — 4 nút luôn ẩn, giữ ref Inspector)")]
	public Button btnmic; //Field offset: 0x78
	public Button btnoffmic; //Field offset: 0x80
	public Button btnloa; //Field offset: 0x88
	public Button btnoffloa; //Field offset: 0x90
	[Header("Pet Animation")]
	[SerializeField]
	public Animator petAnimator; //Field offset: 0x98
	[Header("Selected Cards Container")]
	[SerializeField]
	public Transform cardsContainer; //Field offset: 0xA0
	[Header("Default Sprites")]
	public Sprite defAvt; //Field offset: 0xA8
	internal PlayerUIModel usersInfo; //Field offset: 0xB0
	private bool showDebugGUI; //Field offset: 0xB8
	internal int actorNumber; //Field offset: 0xBC
	private Color _sansangColorDefault; //Field offset: 0xC0
	private bool _sansangColorCaptured; //Field offset: 0xD0
	private int _petAnimToken; //Field offset: 0xD4

	public PlayerUISlot() { }

	private void ApplyPetClips(string petId, AnimationClip[] clips) { }

	private void AutoFillMissingRefs() { }

	private void Awake() { }

	private Button FindChildButton(string name) { }

	private void HideAllVoiceButtons() { }

	private void RenderSelectedCards(Int32[] cardIds) { }

	public void ReplacePetAnimations(string petId) { }

	public void SetData(PlayerUIModel model, int petId = -1) { }

	private void SetEmpty() { }

}

