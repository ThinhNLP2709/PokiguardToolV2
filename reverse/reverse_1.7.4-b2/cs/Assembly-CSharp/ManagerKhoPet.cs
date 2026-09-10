/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerKhoPet : MonoBehaviour // TypeDefIndex: 1587
{
	// Fields
	[Header("Pet UI")]
	public GameObject petUIPrefab; // 0x20
	public Transform petListContainer; // 0x28
	public GameObject LoadingPanel; // 0x30
	public UnityEngine.UI.Text txtVang; // 0x38
	public UnityEngine.UI.Text txtCt; // 0x40
	public UnityEngine.UI.Text txtNl; // 0x48
	public Animator animator; // 0x50
	public UnityEngine.UI.Text namePet; // 0x58
	public UnityEngine.UI.Text txtHp; // 0x60
	public UnityEngine.UI.Text txtMana; // 0x68
	public UnityEngine.UI.Text txtDame; // 0x70
	public UnityEngine.UI.Text txtWee; // 0x78
	public UnityEngine.UI.Text txtLv; // 0x80
	public UnityEngine.UI.Text des; // 0x88
	public Image imgAtribute; // 0x90
	public Image imgAtributeOther; // 0x98
	public Animator imgPetAnimator; // 0xA0
	[Header("Stone Upgrade UI")]
	public GameObject panelStone; // 0xA8
	public Transform stoneListContainer; // 0xB0
	public GameObject stonePrefab; // 0xB8
	public GameObject panelUpdate; // 0xC0
	public Transform updateSlotsContainer; // 0xC8
	public UnityEngine.UI.Text txtUpgradePercent; // 0xD0
	public Button btnUpdate; // 0xD8
	[Header("Stone Sprites")]
	public List<Sprite> fireStoneSprites; // 0xE0
	public List<Sprite> waterStoneSprites; // 0xE8
	public List<Sprite> earthStoneSprites; // 0xF0
	public List<Sprite> electricStoneSprites; // 0xF8
	public List<Sprite> woodStoneSprites; // 0x100
	private PetUserDTO firstPet; // 0x108
	private PetUserDTO currentSelectedPet; // 0x110
	private StoneResponse allStones; // 0x118
	private StoneDTO[] selectedStones; // 0x120
	private Dictionary<int, int> tempStoneCount; // 0x128
	[Header("Upgrade Animation")]
	public GameObject anmtUpdatePet; // 0x130
	public UnityEngine.UI.Text txtResultUpdate; // 0x138
	private Color originalResultColor; // 0x140
	public Toggle toggleProtection; // 0x150
	public Toggle toggle15Percent; // 0x158
	public UnityEngine.UI.Text messageText; // 0x160
	private UserDTO currentUser; // 0x168
	[Header("Skill Card UI")]
	public GameObject PanelCardPet; // 0x170
	public Image imgCard; // 0x178
	public UnityEngine.UI.Text txtDescription; // 0x180
	[Header("Stone Upgrade System")]
	public GameObject PanelUpdateStone; // 0x188
	public Button btnOpenStoneUpgrade; // 0x190
	public Button btnCloseStoneUpgrade; // 0x198
	public GameObject PanelHe; // 0x1A0
	public Button btnHeFire; // 0x1A8
	public Button btnHeWater; // 0x1B0
	public Button btnHeEarth; // 0x1B8
	public Button btnHeMetal; // 0x1C0
	public Button btnHeWood; // 0x1C8
	public GameObject PanelStoneUpgrade; // 0x1D0
	public Transform stoneUpgradeListContainer; // 0x1D8
	public GameObject PanelUpdateStone2; // 0x1E0
	public Transform stoneUpgradeSlotsContainer; // 0x1E8
	public GameObject StoneMain; // 0x1F0
	public Image imgStoneMain; // 0x1F8
	public UnityEngine.UI.Text txtStoneMainLevel; // 0x200
	public UnityEngine.UI.Text txtUpgradePercentStone; // 0x208
	public Button btnUpgradeStone; // 0x210
	public UnityEngine.UI.Text txtResultUpdateStone; // 0x218
	public GameObject anmtUpdateStone; // 0x220
	public Toggle toggleUpgradeAll; // 0x228
	public UnityEngine.UI.Text messageTextStone; // 0x230
	private string currentSelectedElement; // 0x238
	private StoneDTO[] selectedStonesForUpgrade; // 0x240
	private Dictionary<int, int> tempStoneCountUpgrade; // 0x248
	private Color originalResultColorStone; // 0x250
	[Header("LeanTween Settings - \u0110\u00C3 T\u1ED0I \u01AFU")]
	public float panelAnimDuration; // 0x260
	public float itemAnimDelay; // 0x264
	public LeanTweenType easeType; // 0x268
	private CanvasGroup panelStoneCanvasGroup; // 0x270
	private CanvasGroup panelUpdateCanvasGroup; // 0x278
	private CanvasGroup panelUpdateStoneCanvasGroup; // 0x280
	private CanvasGroup panelCardPetCanvasGroup; // 0x288
	[Header("Background Music")]
	public AudioSource bgmAudioSource; // 0x290
	public AudioClip bgmClip; // 0x298
	[Range(0f, 1f)]
	public float bgmVolume; // 0x2A0
	public bool loopBGM; // 0x2A4
	[Header("Sound Effects")]
	public AudioClip clickSound; // 0x2A8
	[Range(0f, 1f)]
	public float clickVolume; // 0x2B0
	private List<Coroutine> activeCoroutines; // 0x2B8
	private bool isProcessingUpgrade; // 0x2C0
	private bool _upgradeAwaitingResult; // 0x2C1
	[Header("Pet Pagination - BACKEND API")]
	public Button btnPrevPage; // 0x2C8
	public Button btnNextPage; // 0x2D0
	public UnityEngine.UI.Text txtPageInfo; // 0x2D8
	[Header("N\u00E2ng sao pet (m\u1EA3nh pet)")]
	[Tooltip("N\u00FAt m\u1EDF panel n\u00E2ng sao cho pet \u0111ang ch\u1ECDn.")]
	public Button btnPetStar; // 0x2E0
	[Tooltip("Panel n\u00E2ng sao \u2014 d\u1EF1ng b\u1EDFi Tools/Pokiguard/PetStar/2.")]
	public PetStarPanelController petStarPanel; // 0x2E8
	[Header("Poky \u2014 th\u1EBB \'Th\u00F4ng tin c\u1EA5p ti\u1EBFp theo\' (s\u1ED1 TH\u1EACT do server R23 tr\u1EA3)")]
	[Tooltip("C\u1EA5p k\u1EBF ti\u1EBFp. \u1EA8n c\u1EA3 c\u1ED9t khi server ch\u01B0a tr\u1EA3 (nextHp = 0).")]
	public UnityEngine.UI.Text txtNextLv; // 0x2F0
	public UnityEngine.UI.Text txtNextHp; // 0x2F8
	public UnityEngine.UI.Text txtNextAtk; // 0x300
	public UnityEngine.UI.Text txtNextMana; // 0x308
	[Header("Poky \u2014 b\u1EA3ng t\u00EAn pet")]
	[Tooltip("D\u00F2ng \'c\u1EA5p cao nh\u1EA5t N\' d\u01B0\u1EDBi t\u00EAn pet.")]
	public UnityEngine.UI.Text txtMaxLv; // 0x310
	[Tooltip("Huy hi\u1EC7u LV b\u00EAn ph\u1EA3i b\u1EA3ng t\u00EAn (pop khi l\u00EAn c\u1EA5p).")]
	public UnityEngine.UI.Text txtLvBadge; // 0x318
	[Tooltip("D\u1EA3i sao c\u1EE7a pet \u0110ANG CH\u1ECCN (\u00F4 pet trong l\u01B0\u1EDBi c\u00F3 d\u1EA3i ri\u00EAng).")]
	public PetStarRowUI showcaseStarRow; // 0x320
	[Header("Poky \u2014 t\u00F3m t\u1EAFt ch\u1EC9 s\u1ED1 t\u0103ng sau khi n\u00E2ng c\u1EA5p")]
	public UnityEngine.UI.Text txtGainSummary; // 0x328
	[CompilerGenerated]
	private static Action<PetUserDTO> PetSelected; // 0x00
	private readonly Dictionary<long, int> _petStars; // 0x330
	private int _petStarMax; // 0x338
	private readonly HashSet<long> _upgradablePets; // 0x340
	private bool _upgradableLoaded; // 0x348
	private PetPageResponse currentPageData; // 0x350
	private int currentPage; // 0x358
	private const int PETS_PER_PAGE = 12; // Metadata: 0x0068D523
	private int _dataSeq; // 0x35C
	private int _appliedSeq; // 0x360
	private Coroutine _reloadAfterUpgradeCo; // 0x368
	public const string PANEL_KEY = "PanelKhoPet"; // Metadata: 0x0068D524
	private bool _wired; // 0x370
	private bool _openHandled; // 0x371
	private bool _loadingVisible; // 0x372
	private AudioClip _prevGlobalClickSound; // 0x378
	private const float PET_STAR_DIM_ALPHA = 0.55f; // Metadata: 0x0068D530
	[Header("Mobile Optimization")]
	public bool enableMobileOptimization; // 0x380
	private bool isLoadingPage; // 0x381
	[Header("Object Pooling - OPTIMIZED")]
	private Queue<GameObject> petUIPool; // 0x388
	private const int POOL_SIZE = 15; // Metadata: 0x0068D534
	private const float PET_FRAME_W = 240f; // Metadata: 0x0068D535
	private const float PET_FRAME_H = 160f; // Metadata: 0x0068D539
	private Button _cardTooltipButton; // 0x390
	private bool _cardTooltipResolved; // 0x398
	private string _cardTooltipTitle; // 0x3A0
	private string _cardTooltipBody; // 0x3A8
	private Sprite _cardTooltipIcon; // 0x3B0
	private const float CARD_PULSE_PERIOD = 1.6f; // Metadata: 0x0068D53D
	private bool _cardPulsing; // 0x3B8

	// Properties
	private bool PanelAlive { get; } // 0x00000001804C2690-0x00000001804C26A0 

	// Events
	public static event Action<PetUserDTO> PetSelected {
		add; // 0x000000018061EE70-0x000000018061EF40
		remove; // 0x000000018061EF40-0x000000018061F010
	}

	// Nested types
	[Serializable]
	public class StoneGroupDTO // TypeDefIndex: 1588
	{
		// Fields
		public long stoneId; // 0x10
		public int quantity; // 0x18

		// Constructors
		public StoneGroupDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class StoneBatchUpgradeRequestDTO // TypeDefIndex: 1589
	{
		// Fields
		public int userId; // 0x10
		public StoneGroupDTO[] stoneGroups; // 0x18

		// Constructors
		public StoneBatchUpgradeRequestDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class StoneBatchUpgradeResponseDTO // TypeDefIndex: 1590
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int successCount; // 0x20
		public int failCount; // 0x24
		public string[] details; // 0x28
		public int remainingGold; // 0x30

		// Constructors
		public StoneBatchUpgradeResponseDTO(); // 0x000000018061F010-0x000000018061F020
	}

	[Serializable]
	public class PetUpgradeRequestDTO // TypeDefIndex: 1591
	{
		// Fields
		public long userId; // 0x10
		public long userPetId; // 0x18
		public long[] stoneIds; // 0x20
		public bool preventDowngrade; // 0x28
		public bool boost15Percent; // 0x29

		// Constructors
		public PetUpgradeRequestDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class PetUpgradeResponseDTO // TypeDefIndex: 1592
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public PetUserDTO updatedPet; // 0x20

		// Constructors
		public PetUpgradeResponseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class StoneUpgradeRequestDTO // TypeDefIndex: 1593
	{
		// Fields
		public int userId; // 0x10
		public long[] stoneIds; // 0x18
		public bool upgradeAll; // 0x20

		// Constructors
		public StoneUpgradeRequestDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class StoneUpgradeResponseDTO // TypeDefIndex: 1594
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18

		// Constructors
		public StoneUpgradeResponseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class DeductGoldRequestDTO // TypeDefIndex: 1595
	{
		// Fields
		public int userId; // 0x10
		public int amount; // 0x14
		public string reason; // 0x18

		// Constructors
		public DeductGoldRequestDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class DeductGoldResponseDTO // TypeDefIndex: 1596
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int remainingGold; // 0x20

		// Constructors
		public DeductGoldResponseDTO(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1597
	{
		// Fields
		public PetUserDTO[] content; // 0x10
		public int totalPages; // 0x18
		public int totalElements; // 0x1C
		public int number; // 0x20
		public int size; // 0x24
		public bool first; // 0x28
		public bool last; // 0x29
		public int numberOfElements; // 0x2C

		// Constructors
		public PetPageResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1598
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__123_1; // 0x08
		public static Func<StoneDTO, int> __9__155_0; // 0x10
		public static Predicate<StoneDTO> __9__158_0; // 0x18
		public static Func<StoneDTO, bool> __9__163_0; // 0x20
		public static Func<StoneDTO, bool> __9__168_0; // 0x28
		public static Func<StoneDTO, bool> __9__168_2; // 0x30
		public static Func<StoneDTO, long> __9__168_3; // 0x38
		public static Predicate<StoneDTO> __9__231_1; // 0x40
		public static Predicate<StoneDTO> __9__233_0; // 0x48
		public static Func<StoneDTO, bool> __9__241_0; // 0x50
		public static Func<StoneDTO, bool> __9__241_1; // 0x58
		public static Func<StoneDTO, long> __9__241_2; // 0x60

		// Constructors
		static __c(); // 0x0000000180621500-0x00000001806216E0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPetStars_b__123_1(string err); // 0x0000000180620770-0x00000001806207E0
		internal int _LoadStonesForUpgrade_b__155_0(StoneDTO s); // 0x00000001806207E0-0x0000000180620800
		internal bool _OnStoneUpgradeClicked_b__158_0(StoneDTO s); // 0x0000000180620800-0x0000000180620810
		internal bool _CalculateStoneUpgradePercent_b__163_0(StoneDTO s); // 0x0000000180620760-0x0000000180620770
		internal bool _UpgradeThreeStones_b__168_0(StoneDTO s); // 0x0000000180620760-0x0000000180620770
		internal bool _UpgradeThreeStones_b__168_2(StoneDTO s); // 0x0000000180620760-0x0000000180620770
		internal long _UpgradeThreeStones_b__168_3(StoneDTO s); // 0x0000000180620810-0x0000000180620830
		internal bool _SetupStoneUI_b__231_1(StoneDTO s); // 0x0000000180620800-0x0000000180620810
		internal bool _OnStoneClicked_b__233_0(StoneDTO s); // 0x0000000180620800-0x0000000180620810
		internal bool _OnUpgradeButtonClicked_b__241_0(StoneDTO s); // 0x0000000180620760-0x0000000180620770
		internal bool _OnUpgradeButtonClicked_b__241_1(StoneDTO s); // 0x0000000180620760-0x0000000180620770
		internal long _OnUpgradeButtonClicked_b__241_2(StoneDTO s); // 0x0000000180620810-0x0000000180620830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass147_0 // TypeDefIndex: 1599
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass147_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x0000000180620890-0x0000000180620980
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 1600
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _AnimateStatUpdate_b__0(); // 0x0000000180620980-0x0000000180620A70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1601
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28

		// Constructors
		public __c__DisplayClass157_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupStoneUpgradeUI_b__0(); // 0x0000000180620A70-0x0000000180620AC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1602
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass159_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpdateStoneUpgradeSlotsUI_b__0(); // 0x0000000180620AC0-0x0000000180620C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass163_0 // TypeDefIndex: 1603
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass163_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _CalculateStoneUpgradePercent_b__1(StoneDTO s); // 0x0000000180643E20-0x0000000180643E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1604
	{
		// Fields
		public bool apiSuccess; // 0x10
		public StoneBatchUpgradeResponseDTO response; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpgradeSelectedStoneSequence_b__0(StoneBatchUpgradeResponseDTO res); // 0x0000000180316FC0-0x0000000180316FE0
		internal void _UpgradeSelectedStoneSequence_b__1(string error); // 0x0000000180643E40-0x0000000180643EC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 1605
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass168_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _UpgradeThreeStones_b__1(StoneDTO s); // 0x0000000180643E20-0x0000000180643E40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass184_0 // TypeDefIndex: 1606
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass184_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPetsPage_b__0(PetPageResponse response); // 0x0000000180643EC0-0x0000000180643EF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass187_0 // TypeDefIndex: 1607
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass187_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupPetUISimple_b__0(); // 0x0000000180643EF0-0x0000000180643F20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 1608
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass194_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPage_b__0(PetPageResponse response); // 0x0000000180643EC0-0x0000000180643EF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 1609
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass209_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupPetInfo_b__0(); // 0x0000000180643EF0-0x0000000180643F20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass225_0 // TypeDefIndex: 1610
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass225_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PopBadge_b__0(); // 0x0000000180643F20-0x0000000180644020
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 1611
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28
		public GameObject stoneObj; // 0x30

		// Constructors
		public __c__DisplayClass231_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupStoneUI_b__0(); // 0x0000000180644020-0x0000000180644190
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass234_0 // TypeDefIndex: 1612
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass234_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpdateSelectedStonesUI_b__0(); // 0x0000000180644190-0x00000001806441D0
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__274 : IEnumerator<object> // TypeDefIndex: 1613
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public UnityEngine.UI.Text textComponent; // 0x20
		public float moveDistance; // 0x28
		public float duration; // 0x2C
		private Vector3 _startPos_5__2; // 0x30
		private Vector3 _targetPos_5__3; // 0x3C
		private float _elapsed_5__4; // 0x48
		private Color _originalColor_5__5; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__274(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063E050-0x000000018063E3B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063E3B0-0x000000018063E3F0
	}

	[CompilerGenerated]
	private sealed class _DeductGoldAndUpgradeSelectedStone_d__166 : IEnumerator<object> // TypeDefIndex: 1614
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneDTO selectedStone; // 0x28
		public int totalGroups; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DeductGoldAndUpgradeSelectedStone_d__166(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063F770-0x000000018063F7F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063F7F0-0x000000018063F830
	}

	[CompilerGenerated]
	private sealed class _HideGainSummaryAfterDelay_d__227 : IEnumerator<object> // TypeDefIndex: 1615
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideGainSummaryAfterDelay_d__227(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063F830-0x000000018063F940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063F940-0x000000018063F980
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__181 : IEnumerator<object> // TypeDefIndex: 1616
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideMessageAfterDelay_d__181(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063F980-0x000000018063FA90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063FA90-0x000000018063FAD0
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__248 : IEnumerator<object> // TypeDefIndex: 1617
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__248(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063FC20-0x000000018063FD70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063FD70-0x000000018063FDB0
	}

	[CompilerGenerated]
	private sealed class _HideStoneMessageAfterDelay_d__151 : IEnumerator<object> // TypeDefIndex: 1618
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneMessageAfterDelay_d__151(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063FDB0-0x000000018063FEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063FEC0-0x000000018063FF00
	}

	[CompilerGenerated]
	private sealed class _HideStoneResultAfterDelay_d__176 : IEnumerator<object> // TypeDefIndex: 1619
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneResultAfterDelay_d__176(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063FF00-0x0000000180640050
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180640050-0x0000000180640090
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__194 : IEnumerator<object> // TypeDefIndex: 1620
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPage_d__194(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180640250-0x00000001806404C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806404C0-0x0000000180640500
	}

	[CompilerGenerated]
	private sealed class _LoadPetStars_d__123 : IEnumerator<object> // TypeDefIndex: 1621
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetStars_d__123(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180640500-0x0000000180640730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180640730-0x0000000180640770
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__184 : IEnumerator<object> // TypeDefIndex: 1622
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__184(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180640770-0x00000001806409B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806409B0-0x00000001806409F0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__182 : IEnumerator<object> // TypeDefIndex: 1623
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _stonesRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__182(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806409F0-0x0000000180640DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180640DA0-0x0000000180640DE0
	}

	[CompilerGenerated]
	private sealed class _ReloadAllStonesAfterUpgrade_d__173 : IEnumerator<object> // TypeDefIndex: 1624
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ReloadAllStonesAfterUpgrade_d__173(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180642B40-0x0000000180642CE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180642CE0-0x0000000180642D20
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__249 : IEnumerator<object> // TypeDefIndex: 1625
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _userRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__249(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x0000000180642D20-0x00000001806430E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806430E0-0x0000000180643120
	}

	[CompilerGenerated]
	private sealed class _UpgradePetAPI_d__243 : IEnumerator<object> // TypeDefIndex: 1626
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpgradePetAPI_d__243(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806448E0-0x0000000180644A80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180644A80-0x0000000180644AC0
	}

	[CompilerGenerated]
	private sealed class _UpgradeSelectedStoneSequence_d__167 : IEnumerator<object> // TypeDefIndex: 1627
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int totalGroups; // 0x20
		public StoneDTO selectedStone; // 0x28
		public ManagerKhoPet __4__this; // 0x30
		private __c__DisplayClass167_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeSelectedStoneSequence_d__167(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180644AC0-0x0000000180645350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180645350-0x0000000180645390
	}

	[CompilerGenerated]
	private sealed class _UpgradeStoneAPI_d__169 : IEnumerator<object> // TypeDefIndex: 1628
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeStoneAPI_d__169(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180645390-0x0000000180645530
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180645530-0x0000000180645570
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenReload_d__245 : IEnumerator<object> // TypeDefIndex: 1629
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public PetUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenReload_d__245(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180645570-0x0000000180645770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180645770-0x00000001806457B0
	}

	[CompilerGenerated]
	private sealed class _WaitForStoneAnimationThenReload_d__171 : IEnumerator<object> // TypeDefIndex: 1630
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForStoneAnimationThenReload_d__171(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806457B0-0x00000001806459B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806459B0-0x0000000180645A60
	}

	// Constructors
	public ManagerKhoPet(); // 0x000000018061EAC0-0x000000018061EE70

	// Methods
	private void Awake(); // 0x000000018060CEA0-0x000000018060CEB0
	private void WireOnce(); // 0x000000018061E6E0-0x000000018061EAC0
	private void OpenPetStarPanel(); // 0x0000000180615AD0-0x0000000180615C70
	private bool CanUpgradeStar(long petId); // 0x000000018060D7A0-0x000000018060D810
	private void RefreshPetStarButton(); // 0x0000000180617280-0x0000000180617430
	[IteratorStateMachine(typeof(_LoadPetStars_d__123))]
	private IEnumerator LoadPetStars(int userId); // 0x0000000180611800-0x0000000180611880
	private void RefreshVisibleStarRows(); // 0x0000000180617890-0x0000000180617A20
	private int GetPetStar(long petId); // 0x000000018060FBF0-0x000000018060FC70
	public void OnPetStarChanged(long petId, int newStar); // 0x0000000180613D00-0x0000000180613EF0
	private void Start(); // 0x000000018061B8F0-0x000000018061B910
	public void Open(); // 0x0000000180615D80-0x0000000180616150
	private void EnsurePreviewCamera(); // 0x000000018060F470-0x000000018060F6A0
	private void SetupButtons(); // 0x0000000180619040-0x00000001806194B0
	private void SetupToggles(); // 0x000000018061AA80-0x000000018061AD30
	private void SetupInitialStates(); // 0x0000000180619670-0x0000000180619860
	private Coroutine RunWrite(IEnumerator routine); // 0x00000001806185D0-0x0000000180618660
	private Coroutine StartCoroutineTracked(IEnumerator routine); // 0x000000018061B800-0x000000018061B8F0
	private void LoadAudioSettings(); // 0x0000000180610D30-0x0000000180610E00
	private void PlayBackgroundMusic(); // 0x0000000180616150-0x0000000180616290
	private void ApplyGlobalClickSound(); // 0x000000018060CA70-0x000000018060CB70
	private void RestoreGlobalClickSound(); // 0x0000000180618420-0x00000001806184F0
	private void SetupButtonSoundsOptimized(); // 0x0000000180618EF0-0x0000000180619040
	public void SetBGMVolume(float volume); // 0x0000000180618B90-0x0000000180618C40
	private void SetupCanvasGroups(); // 0x00000001806194B0-0x0000000180619560
	private CanvasGroup GetOrAddCanvasGroup(GameObject obj); // 0x000000018060FB30-0x000000018060FBF0
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x000000018060C750-0x000000018060C7B0
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x000000018060C540-0x000000018060C5A0
	private void AnimateButtonClick(Button button); // 0x000000018060C370-0x000000018060C540
	private void AnimateItemAppear(GameObject item, int index, float baseDelay = 0f /* Metadata: 0x0068D511 */); // 0x000000018060C5A0-0x000000018060C750
	private void AnimateStatUpdate(UnityEngine.UI.Text textComponent, int oldValue, int newValue, float delay = 0f /* Metadata: 0x0068D515 */); // 0x000000018060C7B0-0x000000018060C9D0
	private void OnToggleUpgradeAllChanged(bool isOn); // 0x0000000180614D50-0x0000000180614F70
	[IteratorStateMachine(typeof(_HideStoneMessageAfterDelay_d__151))]
	private IEnumerator HideStoneMessageAfterDelay(float delay); // 0x0000000180610AD0-0x0000000180610B50
	private void OpenStoneUpgradePanel(); // 0x0000000180615C70-0x0000000180615D80
	private void CloseStoneUpgradePanel(); // 0x000000018060EC20-0x000000018060ECF0
	private void SelectElement(string element); // 0x0000000180618660-0x0000000180618850
	private void LoadStonesForUpgrade(string elementType); // 0x0000000180611B50-0x0000000180611DC0
	private void ClearContainer(Transform container); // 0x000000018060E210-0x000000018060E220
	private void SetupStoneUpgradeUI(GameObject stoneObj, StoneDTO stone, int index); // 0x000000018061A740-0x000000018061AA80
	private void OnStoneUpgradeClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x00000001806142D0-0x0000000180614640
	private void UpdateStoneUpgradeSlotsUI(); // 0x000000018061D760-0x000000018061DD20
	private void RemoveStoneFromUpgradeSlot(int slotIndex); // 0x0000000180617C30-0x0000000180617D60
	private void UpdateStoneUpgradeListUI(); // 0x000000018061D250-0x000000018061D760
	private void UpdateStoneMainDisplay(); // 0x000000018061D070-0x000000018061D250
	private void CalculateStoneUpgradePercent(); // 0x000000018060D250-0x000000018060D4F0
	private void OnUpgradeStoneClicked(); // 0x0000000180615680-0x0000000180615790
	private void UpgradeAllStonesOfSelectedType(); // 0x000000018061DD20-0x000000018061DF40
	[IteratorStateMachine(typeof(_DeductGoldAndUpgradeSelectedStone_d__166))]
	private IEnumerator DeductGoldAndUpgradeSelectedStone(StoneDTO selectedStone, int totalGroups); // 0x000000018060EEE0-0x000000018060EF80
	[IteratorStateMachine(typeof(_UpgradeSelectedStoneSequence_d__167))]
	private IEnumerator UpgradeSelectedStoneSequence(StoneDTO selectedStone, int totalGroups); // 0x000000018061DFD0-0x000000018061E070
	private void UpgradeThreeStones(); // 0x000000018061E100-0x000000018061E5C0
	[IteratorStateMachine(typeof(_UpgradeStoneAPI_d__169))]
	private IEnumerator UpgradeStoneAPI(EncryptedBody payload); // 0x000000018061E070-0x000000018061E100
	private void OnStoneUpgradeSuccess(StoneUpgradeResponseDTO response); // 0x00000001806147F0-0x0000000180614920
	[IteratorStateMachine(typeof(_WaitForStoneAnimationThenReload_d__171))]
	private IEnumerator WaitForStoneAnimationThenReload(StoneUpgradeResponseDTO response); // 0x000000018061E650-0x000000018061E6E0
	private void HandleStoneUpgradeResult(StoneUpgradeResponseDTO response); // 0x0000000180610290-0x00000001806104D0
	[IteratorStateMachine(typeof(_ReloadAllStonesAfterUpgrade_d__173))]
	private IEnumerator ReloadAllStonesAfterUpgrade(); // 0x0000000180617A20-0x0000000180617A90
	private void OnAllStonesReloadedAfterUpgrade(StoneResponse stones); // 0x0000000180612350-0x00000001806123C0
	private void OnStoneUpgradeError(string error); // 0x0000000180614640-0x00000001806147F0
	[IteratorStateMachine(typeof(_HideStoneResultAfterDelay_d__176))]
	private IEnumerator HideStoneResultAfterDelay(float delay); // 0x0000000180610B50-0x0000000180610BD0
	private void ShowStoneErrorMessage(string message); // 0x000000018061B2E0-0x000000018061B400
	private void ResetStoneUpgradeUI(); // 0x0000000180617D60-0x0000000180617ED0
	private void OnToggleProtectionChanged(bool isOn); // 0x0000000180614AD0-0x0000000180614D50
	private void OnToggle15PercentChanged(bool isOn); // 0x0000000180614990-0x0000000180614AD0
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__181))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x00000001806109D0-0x0000000180610A50
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__182))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180611910-0x0000000180611980
	private void ShowLocalLoading(bool show); // 0x000000018061AF80-0x000000018061B010
	[IteratorStateMachine(typeof(_LoadPetsPage_d__184))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180611880-0x0000000180611910
	private void OnPetsPageReceived(PetPageResponse response, int seq); // 0x0000000180613EF0-0x0000000180614000
	private void DisplayCurrentPage(); // 0x000000018060F1A0-0x000000018060F470
	private void SetupPetUISimple(GameObject petUIObject, PetUserDTO pet); // 0x0000000180619B80-0x000000018061A010
	private bool IsCurrentPetOnPage(); // 0x0000000180610BD0-0x0000000180610C50
	private void UpdatePaginationButtons(); // 0x000000018061C3E0-0x000000018061C590
	private void ShowPreviousPage(); // 0x000000018061B0A0-0x000000018061B130
	private void ShowNextPage(); // 0x000000018061B010-0x000000018061B0A0
	[IteratorStateMachine(typeof(_LoadPage_d__194))]
	private IEnumerator LoadPage(int userId, int page); // 0x0000000180610E00-0x0000000180610E90
	private void ClearPetListSimple(); // 0x000000018060E730-0x000000018060EC20
	private void ReturnPetUIToPoolSimple(GameObject obj); // 0x00000001806184F0-0x00000001806185D0
	private void ClearPetListNoPool(); // 0x000000018060E220-0x000000018060E730
	private void DisplayCurrentPageNoPool(); // 0x000000018060EF80-0x000000018060F1A0
	private void SetPaginationButtonsState(bool interactable); // 0x0000000180618D10-0x0000000180618E60
	private void OnPageLoadError(string error); // 0x0000000180612DE0-0x0000000180612F60
	private void ClearContainerSafe(Transform container); // 0x000000018060DB30-0x000000018060E210
	private void OnStonesReceived(StoneResponse stones); // 0x0000000180614920-0x0000000180614940
	private void SetupPetUI(GameObject petUIObject, PetUserDTO pet); // 0x000000018061A010-0x000000018061A3E0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x000000018061BA10-0x000000018061BBB0
	private GameObject GetPetUIFromPool(); // 0x000000018060FC70-0x000000018060FD30
	private void SetupFallbackImage(Image petIcon, string petID, Animator petAnimator); // 0x0000000180619560-0x0000000180619670
	private void SetupPetInfo(GameObject petUIObject, PetUserDTO pet, string petID); // 0x0000000180619860-0x0000000180619B80
	private void SelectPet(PetUserDTO pet, bool fromPetList = false /* Metadata: 0x0068D519 */); // 0x0000000180618A70-0x0000000180618B90
	private float EvoScale(PetUserDTO pet); // 0x000000018060F6A0-0x000000018060F980
	private void OnPetClicked(string petId, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes, PetUserDTO pet, int skillCardId, bool fromPetList = false /* Metadata: 0x0068D51A */); // 0x0000000180612F60-0x0000000180613D00
	private void ApplyNextLevelInfo(PetUserDTO pet); // 0x000000018060CB70-0x000000018060CD80
	private PetUserDTO Canonical(PetUserDTO pet); // 0x000000018060D810-0x000000018060D890
	private void ApplyUpgradedPet(PetUpgradeResponseDTO response); // 0x000000018060CD80-0x000000018060CEA0
	private static void CopyPetInto(PetUserDTO dst, PetUserDTO src); // 0x000000018060ECF0-0x000000018060EEE0
	private void RefreshVisiblePetCells(); // 0x0000000180617430-0x0000000180617890
	private static void SetNextCell(UnityEngine.UI.Text t, bool show, string value); // 0x0000000180618C40-0x0000000180618D10
	public void SelectNeighbor(int dir); // 0x0000000180618850-0x0000000180618A70
	public void QuickFill(); // 0x0000000180616FB0-0x0000000180617280
	private void PlayStoneFly(GameObject stoneObj, int slotIndex); // 0x0000000180616B20-0x0000000180616D00
	private void PlayPokyUpgradeFx(PetUpgradeResponseDTO response); // 0x0000000180616690-0x0000000180616B20
	private void PopBadge(Color tint); // 0x0000000180616D00-0x0000000180616FB0
	private void ShowGainSummary(string text); // 0x000000018061AE50-0x000000018061AF80
	[IteratorStateMachine(typeof(_HideGainSummaryAfterDelay_d__227))]
	private IEnumerator HideGainSummaryAfterDelay(float delay); // 0x0000000180610950-0x00000001806109D0
	public static string FormatVND(long amount); // 0x000000018060FAB0-0x000000018060FB30
	private void LoadStonesForElement(string elementType); // 0x0000000180611980-0x0000000180611B50
	private StoneDTO[] GetStonesForElement(string element); // 0x000000018060FE90-0x0000000180610020
	private void SetupStoneUI(GameObject stoneObj, StoneDTO stone, int index); // 0x000000018061A3E0-0x000000018061A740
	private Sprite GetStoneSpriteByElement(string elementType, int level); // 0x000000018060FD30-0x000000018060FE90
	private void OnStoneClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180614000-0x00000001806142D0
	private void UpdateSelectedStonesUI(); // 0x000000018061C590-0x000000018061CB40
	private void RemoveStoneFromSlot(int slotIndex); // 0x0000000180617B00-0x0000000180617C30
	private void UpdateStoneListUI(); // 0x000000018061CB40-0x000000018061D070
	private void CalculateUpgradePercent(); // 0x000000018060D4F0-0x000000018060D7A0
	private float CalculateStoneRate(int petLevel, int stoneLevel); // 0x000000018060D200-0x000000018060D250
	private void LockStoneInteraction(); // 0x0000000180611DC0-0x0000000180612350
	private void UnlockStoneInteraction(); // 0x000000018061BF50-0x000000018061C3E0
	private void OnUpgradeButtonClicked(); // 0x0000000180614F70-0x00000001806154A0
	private void ShowErrorMessage(string message); // 0x000000018061AD30-0x000000018061AE50
	[IteratorStateMachine(typeof(_UpgradePetAPI_d__243))]
	private IEnumerator UpgradePetAPI(EncryptedBody payload); // 0x000000018061DF40-0x000000018061DFD0
	private void OnUpgradeSuccess(PetUpgradeResponseDTO response); // 0x0000000180615790-0x00000001806158C0
	[IteratorStateMachine(typeof(_WaitForAnimationThenReload_d__245))]
	private IEnumerator WaitForAnimationThenReload(PetUpgradeResponseDTO response); // 0x000000018061E5C0-0x000000018061E650
	private void HandleUpgradeResult(PetUpgradeResponseDTO response); // 0x00000001806104D0-0x0000000180610950
	private void OnUpgradeError(string error); // 0x00000001806154A0-0x0000000180615680
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__248))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x0000000180610A50-0x0000000180610AD0
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__249))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x0000000180617A90-0x0000000180617B00
	private void OnStonesReloaded(StoneResponse stones); // 0x0000000180614940-0x0000000180614990
	private float GetUpgradeSuccessRate(); // 0x0000000180610190-0x0000000180610290
	private float GetUpgradeSuccessRateWithBoost(); // 0x0000000180610020-0x0000000180610190
	private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x0000000180618E60-0x0000000180618EF0
	private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x0000000180610C50-0x0000000180610D30
	private void OnUserReceived(UserDTO user); // 0x00000001806158C0-0x0000000180615AD0
	public void BackScene(); // 0x000000018060CEB0-0x000000018060D200
	private void OnError(string error); // 0x0000000180612D50-0x0000000180612DE0
	private Button ResolveCardTooltipButton(); // 0x0000000180617ED0-0x0000000180618420
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x000000018060F980-0x000000018060FAB0
	public void ShowSkillCardTooltip(); // 0x000000018061B130-0x000000018061B2E0
	private void PlayCardShowFx(); // 0x00000001806164A0-0x0000000180616690
	private void StartCardPulse(); // 0x000000018061B600-0x000000018061B800
	private void StopCardFx(); // 0x000000018061B910-0x000000018061BA10
	private void PlayCardPunch(); // 0x0000000180616290-0x00000001806164A0
	private static string SkillCardCostLine(PetUserDTO pet); // 0x000000018061B400-0x000000018061B600
	private void LoadPetSkillCard(int skillCardId, string description, string cardName, PetUserDTO pet = null); // 0x0000000180610E90-0x0000000180611800
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__274))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x0068D51B */, float moveDistance = 50f /* Metadata: 0x0068D51F */); // 0x000000018060C9D0-0x000000018060CA70
	private void OnDestroy(); // 0x00000001806123C0-0x00000001806128B0
	private void CleanupPetUIComplete(GameObject petUI); // 0x000000018060D890-0x000000018060DB30
	private void OnDisable(); // 0x00000001806128B0-0x0000000180612D50
	[CompilerGenerated]
	private void _LoadPetStars_b__123_0(PetStarListResponse resp); // 0x000000018061BBB0-0x000000018061BD20
	[CompilerGenerated]
	private void _SetupButtons_b__130_0(); // 0x000000018061BE10-0x000000018061BE50
	[CompilerGenerated]
	private void _SetupButtons_b__130_1(); // 0x000000018061BE50-0x000000018061BE90
	[CompilerGenerated]
	private void _SetupButtons_b__130_2(); // 0x000000018061BE90-0x000000018061BED0
	[CompilerGenerated]
	private void _SetupButtons_b__130_3(); // 0x000000018061BED0-0x000000018061BF10
	[CompilerGenerated]
	private void _SetupButtons_b__130_4(); // 0x000000018061BF10-0x000000018061BF50
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__249_0(PetUserDTO p); // 0x000000018061BDE0-0x000000018061BE10
	[CompilerGenerated]
	private void _PlayCardPunch_b__271_0(); // 0x000000018061BD20-0x000000018061BDE0
}

