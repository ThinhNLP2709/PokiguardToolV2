//Type is in global namespace

public class PlayerUISlotPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public PlayerUISlotPVP <>4__this; //Field offset: 0x10
		public string capturedUsername; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <SetData>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public PlayerUISlotPVP <>4__this; //Field offset: 0x10
		public int token; //Field offset: 0x18
		public string petId; //Field offset: 0x20

		public <>c__DisplayClass42_0() { }

		internal void <ReplacePetAnimations>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public int userId; //Field offset: 0x10
		public PlayerUISlotPVP <>4__this; //Field offset: 0x18

		public <>c__DisplayClass50_0() { }

		internal void <LoadRankPositionForSlot>b__0(PvpProfileDTO data) { }

		internal void <LoadRankPositionForSlot>b__1(string err) { }

	}

	private const float RANK_POS_FAIL_BACKOFF = 30; //Field offset: 0x0
	private static readonly Dictionary<Int32, Int32> _rankPosCache; //Field offset: 0x0
	private const int LEGACY_IDX_PASS = 6; //Field offset: 0x0
	private const int LEGACY_IDX_ENERGY = 5; //Field offset: 0x0
	private const int LEGACY_IDX_PET = 4; //Field offset: 0x0
	private const int LEGACY_IDX_USERNAME = 3; //Field offset: 0x0
	private const int LEGACY_IDX_LEVEL = 2; //Field offset: 0x0
	private const int LEGACY_IDX_IMAGE_AVT = 1; //Field offset: 0x0
	private const float RANK_POS_TTL = 120; //Field offset: 0x0
	private static readonly Dictionary<Int32, Single> _rankPosCacheTime; //Field offset: 0x8
	private static readonly Dictionary<Int32, Single> _rankPosRetryAt; //Field offset: 0x10
	private static readonly HashSet<Int32> _rankPosInflight; //Field offset: 0x18
	[Header("UI — gán Inspector hoặc để trống để tự Find theo tên")]
	[SerializeField]
	private SpriteRenderer sprAvatar; //Field offset: 0x20
	[SerializeField]
	private Image imgLogo; //Field offset: 0x28
	[SerializeField]
	private Image imgLevelFrame; //Field offset: 0x30
	[SerializeField]
	private Text txtLevel; //Field offset: 0x38
	[SerializeField]
	private Text txtUserName; //Field offset: 0x40
	[SerializeField]
	private Text txtEnergy; //Field offset: 0x48
	[SerializeField]
	private Text txtPassCount; //Field offset: 0x50
	[SerializeField]
	private Text txtSansang; //Field offset: 0x58
	[SerializeField]
	private Transform anmtPetRoot; //Field offset: 0x60
	internal SpriteRenderer imgPet; //Field offset: 0x68
	[SerializeField]
	public Button btnKick; //Field offset: 0x70
	[SerializeField]
	private Image imgRankIcon; //Field offset: 0x78
	[SerializeField]
	public Image leaderIcon; //Field offset: 0x80
	[SerializeField]
	private WeaponBadgeUI weaponBadge; //Field offset: 0x88
	[Header("PVP Stats")]
	[SerializeField]
	private Text txtWinLoss; //Field offset: 0x90
	[SerializeField]
	private Text txtWinRate; //Field offset: 0x98
	[SerializeField]
	private Text txtBestStreak; //Field offset: 0xA0
	[SerializeField]
	private Text txtRankName; //Field offset: 0xA8
	[SerializeField]
	private Text txtRankPosition; //Field offset: 0xB0
	[Header("Default Sprites")]
	public Sprite defAvt; //Field offset: 0xB8
	[Header("Pet Animation")]
	public Animator petAnimator; //Field offset: 0xC0
	private RuntimeAnimatorController baseController; //Field offset: 0xC8
	private Color _sansangColorDefault; //Field offset: 0xD0
	private bool _sansangColorCaptured; //Field offset: 0xE0
	internal PlayerUIModel usersInfo; //Field offset: 0xE8
	internal int actorNumber; //Field offset: 0xF0
	private string _lastAppliedPetId; //Field offset: 0xF8
	private int _lastLoadedRankUserId; //Field offset: 0x100
	private RuntimeAnimatorController _lastAppliedController; //Field offset: 0x108
	private int _petAnimToken; //Field offset: 0x110
	private string _petAnimLoadingId; //Field offset: 0x118

	private static PlayerUISlotPVP() { }

	public PlayerUISlotPVP() { }

	private void ApplyPetClipsPvp(string petId, AnimationClip[] clips) { }

	private void AutoFillMissingRefs() { }

	private void Awake() { }

	private static bool IsWsOwner(string userName) { }

	private void LoadRankPositionForSlot(int userId) { }

	public void ReplacePetAnimations(string petId) { }

	public void SetData(PlayerUIModel model) { }

	private void Start() { }

}

