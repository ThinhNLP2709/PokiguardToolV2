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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerKhoPet : MonoBehaviour // TypeDefIndex: 1343
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
	private const int PETS_PER_PAGE = 12; // Metadata: 0x0064D63A
	private int _dataSeq; // 0x35C
	private int _appliedSeq; // 0x360
	private Coroutine _reloadAfterUpgradeCo; // 0x368
	public const string PANEL_KEY = "PanelKhoPet"; // Metadata: 0x0064D63B
	private bool _wired; // 0x370
	private bool _openHandled; // 0x371
	private bool _loadingVisible; // 0x372
	private AudioClip _prevGlobalClickSound; // 0x378
	private const float PET_STAR_DIM_ALPHA = 0.55f; // Metadata: 0x0064D647
	[Header("Mobile Optimization")]
	public bool enableMobileOptimization; // 0x380
	private bool isLoadingPage; // 0x381
	[Header("Object Pooling - OPTIMIZED")]
	private Queue<GameObject> petUIPool; // 0x388
	private const int POOL_SIZE = 15; // Metadata: 0x0064D64B
	private const float PET_FRAME_W = 240f; // Metadata: 0x0064D64C
	private const float PET_FRAME_H = 160f; // Metadata: 0x0064D650
	private Button _cardTooltipButton; // 0x390
	private bool _cardTooltipResolved; // 0x398
	private string _cardTooltipTitle; // 0x3A0
	private string _cardTooltipBody; // 0x3A8
	private Sprite _cardTooltipIcon; // 0x3B0
	private const float CARD_PULSE_PERIOD = 1.6f; // Metadata: 0x0064D654
	private bool _cardPulsing; // 0x3B8

	// Properties
	private bool PanelAlive { get; } // 0x00000001803E4F50-0x00000001803E4F60 

	// Events
	public static event Action<PetUserDTO> PetSelected {
		add; // 0x000000018050F3D0-0x000000018050F4A0
		remove; // 0x000000018050F4A0-0x000000018050F570
	}

	// Nested types
	[Serializable]
	public class StoneGroupDTO // TypeDefIndex: 1344
	{
		// Fields
		public long stoneId; // 0x10
		public int quantity; // 0x18

		// Constructors
		public StoneGroupDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class StoneBatchUpgradeRequestDTO // TypeDefIndex: 1345
	{
		// Fields
		public int userId; // 0x10
		public StoneGroupDTO[] stoneGroups; // 0x18

		// Constructors
		public StoneBatchUpgradeRequestDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class StoneBatchUpgradeResponseDTO // TypeDefIndex: 1346
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int successCount; // 0x20
		public int failCount; // 0x24
		public string[] details; // 0x28
		public int remainingGold; // 0x30

		// Constructors
		public StoneBatchUpgradeResponseDTO(); // 0x00000001805485A0-0x00000001805485B0
	}

	[Serializable]
	public class PetUpgradeRequestDTO // TypeDefIndex: 1347
	{
		// Fields
		public long userId; // 0x10
		public long userPetId; // 0x18
		public long[] stoneIds; // 0x20
		public bool preventDowngrade; // 0x28
		public bool boost15Percent; // 0x29

		// Constructors
		public PetUpgradeRequestDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class PetUpgradeResponseDTO // TypeDefIndex: 1348
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public PetUserDTO updatedPet; // 0x20

		// Constructors
		public PetUpgradeResponseDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class StoneUpgradeRequestDTO // TypeDefIndex: 1349
	{
		// Fields
		public int userId; // 0x10
		public long[] stoneIds; // 0x18
		public bool upgradeAll; // 0x20

		// Constructors
		public StoneUpgradeRequestDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class StoneUpgradeResponseDTO // TypeDefIndex: 1350
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18

		// Constructors
		public StoneUpgradeResponseDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class DeductGoldRequestDTO // TypeDefIndex: 1351
	{
		// Fields
		public int userId; // 0x10
		public int amount; // 0x14
		public string reason; // 0x18

		// Constructors
		public DeductGoldRequestDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class DeductGoldResponseDTO // TypeDefIndex: 1352
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public int remainingGold; // 0x20

		// Constructors
		public DeductGoldResponseDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1353
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
		public PetPageResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1354
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
		static __c(); // 0x000000018054EEB0-0x000000018054EF20
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetStars_b__123_1(string err); // 0x000000018054DEE0-0x000000018054DF50
		internal int _LoadStonesForUpgrade_b__155_0(StoneDTO s); // 0x000000018054DF50-0x000000018054DF70
		internal bool _OnStoneUpgradeClicked_b__158_0(StoneDTO s); // 0x000000018054DF70-0x000000018054DF80
		internal bool _CalculateStoneUpgradePercent_b__163_0(StoneDTO s); // 0x000000018052BB00-0x000000018052BB10
		internal bool _UpgradeThreeStones_b__168_0(StoneDTO s); // 0x000000018052BB00-0x000000018052BB10
		internal bool _UpgradeThreeStones_b__168_2(StoneDTO s); // 0x000000018052BB00-0x000000018052BB10
		internal long _UpgradeThreeStones_b__168_3(StoneDTO s); // 0x000000018054DF80-0x000000018054DFA0
		internal bool _SetupStoneUI_b__231_1(StoneDTO s); // 0x000000018054DF70-0x000000018054DF80
		internal bool _OnStoneClicked_b__233_0(StoneDTO s); // 0x000000018054DF70-0x000000018054DF80
		internal bool _OnUpgradeButtonClicked_b__241_0(StoneDTO s); // 0x000000018052BB00-0x000000018052BB10
		internal bool _OnUpgradeButtonClicked_b__241_1(StoneDTO s); // 0x000000018052BB00-0x000000018052BB10
		internal long _OnUpgradeButtonClicked_b__241_2(StoneDTO s); // 0x000000018054DF80-0x000000018054DFA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass147_0 // TypeDefIndex: 1355
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass147_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x000000018054E180-0x000000018054E270
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 1356
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _AnimateStatUpdate_b__0(); // 0x000000018054E270-0x000000018054E360
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1357
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28

		// Constructors
		public __c__DisplayClass157_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupStoneUpgradeUI_b__0(); // 0x000000018054E360-0x000000018054E3B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1358
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass159_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpdateStoneUpgradeSlotsUI_b__0(); // 0x000000018054E3B0-0x000000018054E3F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass163_0 // TypeDefIndex: 1359
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass163_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _CalculateStoneUpgradePercent_b__1(StoneDTO s); // 0x000000018054E3F0-0x000000018054E410
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1360
	{
		// Fields
		public bool apiSuccess; // 0x10
		public StoneBatchUpgradeResponseDTO response; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpgradeSelectedStoneSequence_b__0(StoneBatchUpgradeResponseDTO res); // 0x00000001802FACB0-0x00000001802FACD0
		internal void _UpgradeSelectedStoneSequence_b__1(string error); // 0x000000018054E410-0x000000018054E490
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 1361
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass168_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _UpgradeThreeStones_b__1(StoneDTO s); // 0x000000018054E3F0-0x000000018054E410
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass184_0 // TypeDefIndex: 1362
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass184_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPetsPage_b__0(PetPageResponse response); // 0x000000018054E490-0x000000018054E4C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass187_0 // TypeDefIndex: 1363
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass187_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupPetUISimple_b__0(); // 0x000000018054E4C0-0x000000018054E4F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 1364
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass194_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadPage_b__0(PetPageResponse response); // 0x000000018054E490-0x000000018054E4C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 1365
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass209_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupPetInfo_b__0(); // 0x000000018054E4C0-0x000000018054E4F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass225_0 // TypeDefIndex: 1366
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass225_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PopBadge_b__0(); // 0x000000018054E4F0-0x000000018054E5F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 1367
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28
		public GameObject stoneObj; // 0x30

		// Constructors
		public __c__DisplayClass231_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupStoneUI_b__0(); // 0x000000018054E5F0-0x000000018054E760
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass234_0 // TypeDefIndex: 1368
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass234_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpdateSelectedStonesUI_b__0(); // 0x000000018054E760-0x000000018054E7A0
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__274 : IEnumerator<object> // TypeDefIndex: 1369
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__274(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805485B0-0x0000000180548910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180548910-0x0000000180548950
	}

	[CompilerGenerated]
	private sealed class _DeductGoldAndUpgradeSelectedStone_d__166 : IEnumerator<object> // TypeDefIndex: 1370
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneDTO selectedStone; // 0x28
		public int totalGroups; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DeductGoldAndUpgradeSelectedStone_d__166(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180549BD0-0x0000000180549C50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549C50-0x0000000180549C90
	}

	[CompilerGenerated]
	private sealed class _HideGainSummaryAfterDelay_d__227 : IEnumerator<object> // TypeDefIndex: 1371
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideGainSummaryAfterDelay_d__227(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180549C90-0x0000000180549DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549DA0-0x0000000180549DE0
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__181 : IEnumerator<object> // TypeDefIndex: 1372
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideMessageAfterDelay_d__181(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180549DE0-0x0000000180549EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549EF0-0x0000000180549F30
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__248 : IEnumerator<object> // TypeDefIndex: 1373
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__248(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054A080-0x000000018054A1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A1D0-0x000000018054A210
	}

	[CompilerGenerated]
	private sealed class _HideStoneMessageAfterDelay_d__151 : IEnumerator<object> // TypeDefIndex: 1374
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneMessageAfterDelay_d__151(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054A210-0x000000018054A320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A320-0x000000018054A360
	}

	[CompilerGenerated]
	private sealed class _HideStoneResultAfterDelay_d__176 : IEnumerator<object> // TypeDefIndex: 1375
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneResultAfterDelay_d__176(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054A360-0x000000018054A4B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A4B0-0x000000018054A4F0
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__194 : IEnumerator<object> // TypeDefIndex: 1376
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPage_d__194(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054A6B0-0x000000018054A920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A920-0x000000018054A960
	}

	[CompilerGenerated]
	private sealed class _LoadPetStars_d__123 : IEnumerator<object> // TypeDefIndex: 1377
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetStars_d__123(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054A960-0x000000018054AB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054AB90-0x000000018054ABD0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__184 : IEnumerator<object> // TypeDefIndex: 1378
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__184(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054ABD0-0x000000018054AE10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054AE10-0x000000018054AE50
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__182 : IEnumerator<object> // TypeDefIndex: 1379
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _stonesRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__182(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018054AE50-0x000000018054B200
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054B200-0x000000018054B240
	}

	[CompilerGenerated]
	private sealed class _ReloadAllStonesAfterUpgrade_d__173 : IEnumerator<object> // TypeDefIndex: 1380
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ReloadAllStonesAfterUpgrade_d__173(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054CDE0-0x000000018054CF80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054CF80-0x000000018054CFC0
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__249 : IEnumerator<object> // TypeDefIndex: 1381
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _userRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__249(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018054CFC0-0x000000018054D380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054D380-0x000000018054D3C0
	}

	[CompilerGenerated]
	private sealed class _UpgradePetAPI_d__243 : IEnumerator<object> // TypeDefIndex: 1382
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpgradePetAPI_d__243(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054EF20-0x000000018054F0C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054F0C0-0x000000018054F100
	}

	[CompilerGenerated]
	private sealed class _UpgradeSelectedStoneSequence_d__167 : IEnumerator<object> // TypeDefIndex: 1383
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int totalGroups; // 0x20
		public StoneDTO selectedStone; // 0x28
		public ManagerKhoPet __4__this; // 0x30
		private __c__DisplayClass167_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeSelectedStoneSequence_d__167(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x000000018054F100-0x000000018054F990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054F990-0x000000018054F9D0
	}

	[CompilerGenerated]
	private sealed class _UpgradeStoneAPI_d__169 : IEnumerator<object> // TypeDefIndex: 1384
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeStoneAPI_d__169(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054F9D0-0x000000018054FB70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054FB70-0x000000018054FBB0
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenReload_d__245 : IEnumerator<object> // TypeDefIndex: 1385
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public PetUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenReload_d__245(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054FBB0-0x000000018054FDB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054FDB0-0x000000018054FDF0
	}

	[CompilerGenerated]
	private sealed class _WaitForStoneAnimationThenReload_d__171 : IEnumerator<object> // TypeDefIndex: 1386
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForStoneAnimationThenReload_d__171(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054FDF0-0x000000018054FFF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054FFF0-0x00000001805500A0
	}

	// Constructors
	public ManagerKhoPet(); // 0x000000018050F020-0x000000018050F3D0

	// Methods
	private void Awake(); // 0x00000001804FD440-0x00000001804FD450
	private void WireOnce(); // 0x000000018050EC40-0x000000018050F020
	private void OpenPetStarPanel(); // 0x0000000180506050-0x00000001805061F0
	private bool CanUpgradeStar(long petId); // 0x00000001804FDD40-0x00000001804FDDB0
	private void RefreshPetStarButton(); // 0x00000001805077F0-0x00000001805079A0
	[IteratorStateMachine(typeof(_LoadPetStars_d__123))]
	private IEnumerator LoadPetStars(int userId); // 0x0000000180501DA0-0x0000000180501E20
	private void RefreshVisibleStarRows(); // 0x0000000180507E00-0x0000000180507F90
	private int GetPetStar(long petId); // 0x0000000180500190-0x0000000180500210
	public void OnPetStarChanged(long petId, int newStar); // 0x0000000180504280-0x0000000180504470
	private void Start(); // 0x000000018050BE50-0x000000018050BE70
	public void Open(); // 0x0000000180506300-0x00000001805066C0
	private void EnsurePreviewCamera(); // 0x00000001804FFA10-0x00000001804FFC40
	private void SetupButtons(); // 0x00000001805095A0-0x0000000180509A10
	private void SetupToggles(); // 0x000000018050AFE0-0x000000018050B290
	private void SetupInitialStates(); // 0x0000000180509BD0-0x0000000180509DC0
	private Coroutine RunWrite(IEnumerator routine); // 0x0000000180508B30-0x0000000180508BC0
	private Coroutine StartCoroutineTracked(IEnumerator routine); // 0x000000018050BD60-0x000000018050BE50
	private void LoadAudioSettings(); // 0x00000001805012D0-0x00000001805013A0
	private void PlayBackgroundMusic(); // 0x00000001805066C0-0x0000000180506800
	private void ApplyGlobalClickSound(); // 0x00000001804FD030-0x00000001804FD110
	private void RestoreGlobalClickSound(); // 0x0000000180508990-0x0000000180508A50
	private void SetupButtonSoundsOptimized(); // 0x0000000180509450-0x00000001805095A0
	public void SetBGMVolume(float volume); // 0x00000001805090F0-0x00000001805091A0
	private void SetupCanvasGroups(); // 0x0000000180509A10-0x0000000180509AC0
	private CanvasGroup GetOrAddCanvasGroup(GameObject obj); // 0x00000001805000D0-0x0000000180500190
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x00000001804FCD10-0x00000001804FCD70
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x00000001804FCB00-0x00000001804FCB60
	private void AnimateButtonClick(Button button); // 0x00000001804FC930-0x00000001804FCB00
	private void AnimateItemAppear(GameObject item, int index, float baseDelay = 0f /* Metadata: 0x0064D628 */); // 0x00000001804FCB60-0x00000001804FCD10
	private void AnimateStatUpdate(UnityEngine.UI.Text textComponent, int oldValue, int newValue, float delay = 0f /* Metadata: 0x0064D62C */); // 0x00000001804FCD70-0x00000001804FCF90
	private void OnToggleUpgradeAllChanged(bool isOn); // 0x00000001805052D0-0x00000001805054F0
	[IteratorStateMachine(typeof(_HideStoneMessageAfterDelay_d__151))]
	private IEnumerator HideStoneMessageAfterDelay(float delay); // 0x0000000180501070-0x00000001805010F0
	private void OpenStoneUpgradePanel(); // 0x00000001805061F0-0x0000000180506300
	private void CloseStoneUpgradePanel(); // 0x00000001804FF1C0-0x00000001804FF290
	private void SelectElement(string element); // 0x0000000180508BC0-0x0000000180508DB0
	private void LoadStonesForUpgrade(string elementType); // 0x00000001805020F0-0x0000000180502360
	private void ClearContainer(Transform container); // 0x00000001804FE7B0-0x00000001804FE7C0
	private void SetupStoneUpgradeUI(GameObject stoneObj, StoneDTO stone, int index); // 0x000000018050ACA0-0x000000018050AFE0
	private void OnStoneUpgradeClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180504850-0x0000000180504BC0
	private void UpdateStoneUpgradeSlotsUI(); // 0x000000018050DCC0-0x000000018050E280
	private void RemoveStoneFromUpgradeSlot(int slotIndex); // 0x00000001805081A0-0x00000001805082D0
	private void UpdateStoneUpgradeListUI(); // 0x000000018050D7B0-0x000000018050DCC0
	private void UpdateStoneMainDisplay(); // 0x000000018050D5D0-0x000000018050D7B0
	private void CalculateStoneUpgradePercent(); // 0x00000001804FD7F0-0x00000001804FDA90
	private void OnUpgradeStoneClicked(); // 0x0000000180505C00-0x0000000180505D10
	private void UpgradeAllStonesOfSelectedType(); // 0x000000018050E280-0x000000018050E4A0
	[IteratorStateMachine(typeof(_DeductGoldAndUpgradeSelectedStone_d__166))]
	private IEnumerator DeductGoldAndUpgradeSelectedStone(StoneDTO selectedStone, int totalGroups); // 0x00000001804FF480-0x00000001804FF520
	[IteratorStateMachine(typeof(_UpgradeSelectedStoneSequence_d__167))]
	private IEnumerator UpgradeSelectedStoneSequence(StoneDTO selectedStone, int totalGroups); // 0x000000018050E530-0x000000018050E5D0
	private void UpgradeThreeStones(); // 0x000000018050E660-0x000000018050EB20
	[IteratorStateMachine(typeof(_UpgradeStoneAPI_d__169))]
	private IEnumerator UpgradeStoneAPI(EncryptedBody payload); // 0x000000018050E5D0-0x000000018050E660
	private void OnStoneUpgradeSuccess(StoneUpgradeResponseDTO response); // 0x0000000180504D70-0x0000000180504EA0
	[IteratorStateMachine(typeof(_WaitForStoneAnimationThenReload_d__171))]
	private IEnumerator WaitForStoneAnimationThenReload(StoneUpgradeResponseDTO response); // 0x000000018050EBB0-0x000000018050EC40
	private void HandleStoneUpgradeResult(StoneUpgradeResponseDTO response); // 0x0000000180500830-0x0000000180500A70
	[IteratorStateMachine(typeof(_ReloadAllStonesAfterUpgrade_d__173))]
	private IEnumerator ReloadAllStonesAfterUpgrade(); // 0x0000000180507F90-0x0000000180508000
	private void OnAllStonesReloadedAfterUpgrade(StoneResponse stones); // 0x00000001805028F0-0x0000000180502960
	private void OnStoneUpgradeError(string error); // 0x0000000180504BC0-0x0000000180504D70
	[IteratorStateMachine(typeof(_HideStoneResultAfterDelay_d__176))]
	private IEnumerator HideStoneResultAfterDelay(float delay); // 0x00000001805010F0-0x0000000180501170
	private void ShowStoneErrorMessage(string message); // 0x000000018050B840-0x000000018050B960
	private void ResetStoneUpgradeUI(); // 0x00000001805082D0-0x0000000180508440
	private void OnToggleProtectionChanged(bool isOn); // 0x0000000180505050-0x00000001805052D0
	private void OnToggle15PercentChanged(bool isOn); // 0x0000000180504F10-0x0000000180505050
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__181))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x0000000180500F70-0x0000000180500FF0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__182))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180501EB0-0x0000000180501F20
	private void ShowLocalLoading(bool show); // 0x000000018050B4E0-0x000000018050B570
	[IteratorStateMachine(typeof(_LoadPetsPage_d__184))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x0000000180501E20-0x0000000180501EB0
	private void OnPetsPageReceived(PetPageResponse response, int seq); // 0x0000000180504470-0x0000000180504580
	private void DisplayCurrentPage(); // 0x00000001804FF740-0x00000001804FFA10
	private void SetupPetUISimple(GameObject petUIObject, PetUserDTO pet); // 0x000000018050A0E0-0x000000018050A570
	private bool IsCurrentPetOnPage(); // 0x0000000180501170-0x00000001805011F0
	private void UpdatePaginationButtons(); // 0x000000018050C940-0x000000018050CAF0
	private void ShowPreviousPage(); // 0x000000018050B600-0x000000018050B690
	private void ShowNextPage(); // 0x000000018050B570-0x000000018050B600
	[IteratorStateMachine(typeof(_LoadPage_d__194))]
	private IEnumerator LoadPage(int userId, int page); // 0x00000001805013A0-0x0000000180501430
	private void ClearPetListSimple(); // 0x00000001804FECD0-0x00000001804FF1C0
	private void ReturnPetUIToPoolSimple(GameObject obj); // 0x0000000180508A50-0x0000000180508B30
	private void ClearPetListNoPool(); // 0x00000001804FE7C0-0x00000001804FECD0
	private void DisplayCurrentPageNoPool(); // 0x00000001804FF520-0x00000001804FF740
	private void SetPaginationButtonsState(bool interactable); // 0x0000000180509270-0x00000001805093C0
	private void OnPageLoadError(string error); // 0x0000000180503360-0x00000001805034E0
	private void ClearContainerSafe(Transform container); // 0x00000001804FE0D0-0x00000001804FE7B0
	private void OnStonesReceived(StoneResponse stones); // 0x0000000180504EA0-0x0000000180504EC0
	private void SetupPetUI(GameObject petUIObject, PetUserDTO pet); // 0x000000018050A570-0x000000018050A940
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x000000018050BF70-0x000000018050C110
	private GameObject GetPetUIFromPool(); // 0x0000000180500210-0x00000001805002D0
	private void SetupFallbackImage(Image petIcon, string petID, Animator petAnimator); // 0x0000000180509AC0-0x0000000180509BD0
	private void SetupPetInfo(GameObject petUIObject, PetUserDTO pet, string petID); // 0x0000000180509DC0-0x000000018050A0E0
	private void SelectPet(PetUserDTO pet, bool fromPetList = false /* Metadata: 0x0064D630 */); // 0x0000000180508FD0-0x00000001805090F0
	private float EvoScale(PetUserDTO pet); // 0x00000001804FFC40-0x00000001804FFF20
	private void OnPetClicked(string petId, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes, PetUserDTO pet, int skillCardId, bool fromPetList = false /* Metadata: 0x0064D631 */); // 0x00000001805034E0-0x0000000180504280
	private void ApplyNextLevelInfo(PetUserDTO pet); // 0x00000001804FD110-0x00000001804FD320
	private PetUserDTO Canonical(PetUserDTO pet); // 0x00000001804FDDB0-0x00000001804FDE30
	private void ApplyUpgradedPet(PetUpgradeResponseDTO response); // 0x00000001804FD320-0x00000001804FD440
	private static void CopyPetInto(PetUserDTO dst, PetUserDTO src); // 0x00000001804FF290-0x00000001804FF480
	private void RefreshVisiblePetCells(); // 0x00000001805079A0-0x0000000180507E00
	private static void SetNextCell(UnityEngine.UI.Text t, bool show, string value); // 0x00000001805091A0-0x0000000180509270
	public void SelectNeighbor(int dir); // 0x0000000180508DB0-0x0000000180508FD0
	public void QuickFill(); // 0x0000000180507520-0x00000001805077F0
	private void PlayStoneFly(GameObject stoneObj, int slotIndex); // 0x0000000180507090-0x0000000180507270
	private void PlayPokyUpgradeFx(PetUpgradeResponseDTO response); // 0x0000000180506C00-0x0000000180507090
	private void PopBadge(Color tint); // 0x0000000180507270-0x0000000180507520
	private void ShowGainSummary(string text); // 0x000000018050B3B0-0x000000018050B4E0
	[IteratorStateMachine(typeof(_HideGainSummaryAfterDelay_d__227))]
	private IEnumerator HideGainSummaryAfterDelay(float delay); // 0x0000000180500EF0-0x0000000180500F70
	public static string FormatVND(long amount); // 0x0000000180500050-0x00000001805000D0
	private void LoadStonesForElement(string elementType); // 0x0000000180501F20-0x00000001805020F0
	private StoneDTO[] GetStonesForElement(string element); // 0x0000000180500430-0x00000001805005C0
	private void SetupStoneUI(GameObject stoneObj, StoneDTO stone, int index); // 0x000000018050A940-0x000000018050ACA0
	private Sprite GetStoneSpriteByElement(string elementType, int level); // 0x00000001805002D0-0x0000000180500430
	private void OnStoneClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180504580-0x0000000180504850
	private void UpdateSelectedStonesUI(); // 0x000000018050CAF0-0x000000018050D0A0
	private void RemoveStoneFromSlot(int slotIndex); // 0x0000000180508070-0x00000001805081A0
	private void UpdateStoneListUI(); // 0x000000018050D0A0-0x000000018050D5D0
	private void CalculateUpgradePercent(); // 0x00000001804FDA90-0x00000001804FDD40
	private float CalculateStoneRate(int petLevel, int stoneLevel); // 0x00000001804FD7A0-0x00000001804FD7F0
	private void LockStoneInteraction(); // 0x0000000180502360-0x00000001805028F0
	private void UnlockStoneInteraction(); // 0x000000018050C4B0-0x000000018050C940
	private void OnUpgradeButtonClicked(); // 0x00000001805054F0-0x0000000180505A20
	private void ShowErrorMessage(string message); // 0x000000018050B290-0x000000018050B3B0
	[IteratorStateMachine(typeof(_UpgradePetAPI_d__243))]
	private IEnumerator UpgradePetAPI(EncryptedBody payload); // 0x000000018050E4A0-0x000000018050E530
	private void OnUpgradeSuccess(PetUpgradeResponseDTO response); // 0x0000000180505D10-0x0000000180505E40
	[IteratorStateMachine(typeof(_WaitForAnimationThenReload_d__245))]
	private IEnumerator WaitForAnimationThenReload(PetUpgradeResponseDTO response); // 0x000000018050EB20-0x000000018050EBB0
	private void HandleUpgradeResult(PetUpgradeResponseDTO response); // 0x0000000180500A70-0x0000000180500EF0
	private void OnUpgradeError(string error); // 0x0000000180505A20-0x0000000180505C00
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__248))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x0000000180500FF0-0x0000000180501070
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__249))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x0000000180508000-0x0000000180508070
	private void OnStonesReloaded(StoneResponse stones); // 0x0000000180504EC0-0x0000000180504F10
	private float GetUpgradeSuccessRate(); // 0x0000000180500730-0x0000000180500830
	private float GetUpgradeSuccessRateWithBoost(); // 0x00000001805005C0-0x0000000180500730
	private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x00000001805093C0-0x0000000180509450
	private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x00000001805011F0-0x00000001805012D0
	private void OnUserReceived(UserDTO user); // 0x0000000180505E40-0x0000000180506050
	public void BackScene(); // 0x00000001804FD450-0x00000001804FD7A0
	private void OnError(string error); // 0x00000001805032D0-0x0000000180503360
	private Button ResolveCardTooltipButton(); // 0x0000000180508440-0x0000000180508990
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x00000001804FFF20-0x0000000180500050
	public void ShowSkillCardTooltip(); // 0x000000018050B690-0x000000018050B840
	private void PlayCardShowFx(); // 0x0000000180506A10-0x0000000180506C00
	private void StartCardPulse(); // 0x000000018050BB60-0x000000018050BD60
	private void StopCardFx(); // 0x000000018050BE70-0x000000018050BF70
	private void PlayCardPunch(); // 0x0000000180506800-0x0000000180506A10
	private static string SkillCardCostLine(PetUserDTO pet); // 0x000000018050B960-0x000000018050BB60
	private void LoadPetSkillCard(int skillCardId, string description, string cardName, PetUserDTO pet = null); // 0x0000000180501430-0x0000000180501DA0
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__274))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x0064D632 */, float moveDistance = 50f /* Metadata: 0x0064D636 */); // 0x00000001804FCF90-0x00000001804FD030
	private void OnDestroy(); // 0x0000000180502960-0x0000000180502E50
	private void CleanupPetUIComplete(GameObject petUI); // 0x00000001804FDE30-0x00000001804FE0D0
	private void OnDisable(); // 0x0000000180502E50-0x00000001805032D0
	[CompilerGenerated]
	private void _LoadPetStars_b__123_0(PetStarListResponse resp); // 0x000000018050C110-0x000000018050C280
	[CompilerGenerated]
	private void _SetupButtons_b__130_0(); // 0x000000018050C370-0x000000018050C3B0
	[CompilerGenerated]
	private void _SetupButtons_b__130_1(); // 0x000000018050C3B0-0x000000018050C3F0
	[CompilerGenerated]
	private void _SetupButtons_b__130_2(); // 0x000000018050C3F0-0x000000018050C430
	[CompilerGenerated]
	private void _SetupButtons_b__130_3(); // 0x000000018050C430-0x000000018050C470
	[CompilerGenerated]
	private void _SetupButtons_b__130_4(); // 0x000000018050C470-0x000000018050C4B0
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__249_0(PetUserDTO p); // 0x000000018050C340-0x000000018050C370
	[CompilerGenerated]
	private void _PlayCardPunch_b__271_0(); // 0x000000018050C280-0x000000018050C340
}

