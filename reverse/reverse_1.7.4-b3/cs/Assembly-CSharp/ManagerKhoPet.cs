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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerKhoPet : MonoBehaviour // TypeDefIndex: 1971
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
	private const int PETS_PER_PAGE = 12; // Metadata: 0x005F03D0
	private int _dataSeq; // 0x35C
	private int _appliedSeq; // 0x360
	private Coroutine _reloadAfterUpgradeCo; // 0x368
	public const string PANEL_KEY = "PanelKhoPet"; // Metadata: 0x005F03D1
	private bool _wired; // 0x370
	private bool _openHandled; // 0x371
	private bool _loadingVisible; // 0x372
	private AudioClip _prevGlobalClickSound; // 0x378
	private const float PET_STAR_DIM_ALPHA = 0.55f; // Metadata: 0x005F03DD
	[Header("Mobile Optimization")]
	public bool enableMobileOptimization; // 0x380
	private bool isLoadingPage; // 0x381
	[Header("Object Pooling - OPTIMIZED")]
	private Queue<GameObject> petUIPool; // 0x388
	private const int POOL_SIZE = 15; // Metadata: 0x005F03E1
	private const float PET_FRAME_W = 240f; // Metadata: 0x005F03E2
	private const float PET_FRAME_H = 160f; // Metadata: 0x005F03E6
	private Button _cardTooltipButton; // 0x390
	private bool _cardTooltipResolved; // 0x398
	private string _cardTooltipTitle; // 0x3A0
	private string _cardTooltipBody; // 0x3A8
	private Sprite _cardTooltipIcon; // 0x3B0
	private const float CARD_PULSE_PERIOD = 1.6f; // Metadata: 0x005F03EA
	private bool _cardPulsing; // 0x3B8

	// Properties
	private bool PanelAlive { get; } // 0x0000000180698A80-0x0000000180698A90 

	// Events
	public static event Action<PetUserDTO> PetSelected {
		add; // 0x000000018097F410-0x000000018097F540
		remove; // 0x000000018097F540-0x000000018097F670
	}

	// Nested types
	[Serializable]
	public class StoneBatchUpgradeResponseDTO // TypeDefIndex: 1972
	{
		// Fields
		public string message; // 0x10
		public int successCount; // 0x18
		public int remainingGold; // 0x1C

		// Constructors
		public StoneBatchUpgradeResponseDTO(); // 0x000000018099E6B0-0x000000018099E6C0
	}

	[Serializable]
	public class PetUpgradeResponseDTO // TypeDefIndex: 1973
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public PetUserDTO updatedPet; // 0x20

		// Constructors
		public PetUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class StoneUpgradeResponseDTO // TypeDefIndex: 1974
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18

		// Constructors
		public StoneUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1975
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
		public PetPageResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1976
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
		static __c(); // 0x000000018099E6C0-0x000000018099E760
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetStars_b__123_1(string err); // 0x000000018099E760-0x000000018099E7E0
		internal int _LoadStonesForUpgrade_b__155_0(StoneDTO s); // 0x000000018099E7E0-0x000000018099E800
		internal bool _OnStoneUpgradeClicked_b__158_0(StoneDTO s); // 0x000000018099E800-0x000000018099E810
		internal bool _CalculateStoneUpgradePercent_b__163_0(StoneDTO s); // 0x00000001807A8150-0x00000001807A8160
		internal bool _UpgradeThreeStones_b__168_0(StoneDTO s); // 0x00000001807A8150-0x00000001807A8160
		internal bool _UpgradeThreeStones_b__168_2(StoneDTO s); // 0x00000001807A8150-0x00000001807A8160
		internal long _UpgradeThreeStones_b__168_3(StoneDTO s); // 0x000000018099E810-0x000000018099E830
		internal bool _SetupStoneUI_b__231_1(StoneDTO s); // 0x000000018099E800-0x000000018099E810
		internal bool _OnStoneClicked_b__233_0(StoneDTO s); // 0x000000018099E800-0x000000018099E810
		internal bool _OnUpgradeButtonClicked_b__241_0(StoneDTO s); // 0x00000001807A8150-0x00000001807A8160
		internal bool _OnUpgradeButtonClicked_b__241_1(StoneDTO s); // 0x00000001807A8150-0x00000001807A8160
		internal long _OnUpgradeButtonClicked_b__241_2(StoneDTO s); // 0x000000018099E810-0x000000018099E830
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass147_0 // TypeDefIndex: 1977
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass147_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x000000018099E830-0x000000018099E9B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 1978
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateStatUpdate_b__0(); // 0x000000018099E9B0-0x000000018099EB30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1979
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupStoneUpgradeUI_b__0(); // 0x000000018099EB30-0x000000018099EB80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1980
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass159_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateStoneUpgradeSlotsUI_b__0(); // 0x000000018099EB80-0x000000018099ED10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass163_0 // TypeDefIndex: 1981
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass163_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _CalculateStoneUpgradePercent_b__1(StoneDTO s); // 0x000000018099ED10-0x000000018099ED30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1982
	{
		// Fields
		public bool apiSuccess; // 0x10
		public StoneBatchUpgradeResponseDTO response; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpgradeSelectedStoneSequence_b__0(StoneBatchUpgradeResponseDTO res); // 0x00000001802B9410-0x00000001802B9470
		internal void _UpgradeSelectedStoneSequence_b__1(string error); // 0x000000018099ED30-0x000000018099EDC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 1983
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass168_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpgradeThreeStones_b__1(StoneDTO s); // 0x000000018099ED10-0x000000018099ED30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass184_0 // TypeDefIndex: 1984
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass184_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetsPage_b__0(PetPageResponse response); // 0x000000018099EDC0-0x000000018099EDF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass187_0 // TypeDefIndex: 1985
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass187_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupPetUISimple_b__0(); // 0x000000018099EDF0-0x000000018099EE20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 1986
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass194_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPage_b__0(PetPageResponse response); // 0x000000018099EDC0-0x000000018099EDF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 1987
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass209_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupPetInfo_b__0(); // 0x000000018099EDF0-0x000000018099EE20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass225_0 // TypeDefIndex: 1988
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass225_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopBadge_b__0(); // 0x000000018099EE20-0x000000018099EFA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 1989
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28
		public GameObject stoneObj; // 0x30

		// Constructors
		public __c__DisplayClass231_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupStoneUI_b__0(); // 0x000000018099EFA0-0x000000018099F1E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass234_0 // TypeDefIndex: 1990
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass234_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateSelectedStonesUI_b__0(); // 0x000000018099F1E0-0x000000018099F370
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__274 : IEnumerator<object> // TypeDefIndex: 1991
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnimateTextFlyUp_d__274(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018099F370-0x000000018099F810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018099F810-0x000000018099F850
	}

	[CompilerGenerated]
	private sealed class _DeductGoldAndUpgradeSelectedStone_d__166 : IEnumerator<object> // TypeDefIndex: 1992
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneDTO selectedStone; // 0x28
		public int totalGroups; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DeductGoldAndUpgradeSelectedStone_d__166(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018099F850-0x000000018099FA00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018099FA00-0x000000018099FA40
	}

	[CompilerGenerated]
	private sealed class _HideGainSummaryAfterDelay_d__227 : IEnumerator<object> // TypeDefIndex: 1993
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideGainSummaryAfterDelay_d__227(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018099FA40-0x000000018099FC60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018099FC60-0x000000018099FCA0
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__181 : IEnumerator<object> // TypeDefIndex: 1994
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideMessageAfterDelay_d__181(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018099FCA0-0x000000018099FEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018099FEC0-0x000000018099FF00
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__248 : IEnumerator<object> // TypeDefIndex: 1995
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideResultAfterDelay_d__248(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018099FF00-0x00000001809A0160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A0160-0x00000001809A01A0
	}

	[CompilerGenerated]
	private sealed class _HideStoneMessageAfterDelay_d__151 : IEnumerator<object> // TypeDefIndex: 1996
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneMessageAfterDelay_d__151(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A01A0-0x00000001809A03C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A03C0-0x00000001809A0400
	}

	[CompilerGenerated]
	private sealed class _HideStoneResultAfterDelay_d__176 : IEnumerator<object> // TypeDefIndex: 1997
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideStoneResultAfterDelay_d__176(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A0400-0x00000001809A0660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A0660-0x00000001809A06A0
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__194 : IEnumerator<object> // TypeDefIndex: 1998
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPage_d__194(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A06A0-0x00000001809A0A50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A0A50-0x00000001809A0A90
	}

	[CompilerGenerated]
	private sealed class _LoadPetStars_d__123 : IEnumerator<object> // TypeDefIndex: 1999
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetStars_d__123(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A0A90-0x00000001809A0EB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A0EB0-0x00000001809A0EF0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__184 : IEnumerator<object> // TypeDefIndex: 2000
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public int userId; // 0x28
		public int page; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadPetsPage_d__184(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A0EF0-0x00000001809A1280
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A1280-0x00000001809A12C0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__182 : IEnumerator<object> // TypeDefIndex: 2001
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _stonesRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__182(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001809A12C0-0x00000001809A1730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A1730-0x00000001809A1770
	}

	[CompilerGenerated]
	private sealed class _ReloadAllStonesAfterUpgrade_d__173 : IEnumerator<object> // TypeDefIndex: 2002
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ReloadAllStonesAfterUpgrade_d__173(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A1770-0x00000001809A1980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A1980-0x00000001809A19C0
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__249 : IEnumerator<object> // TypeDefIndex: 2003
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		private int _userId_5__2; // 0x28
		private IEnumerator _userRequest_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ReloadDataAfterUpgrade_d__249(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001809A19C0-0x00000001809A1F30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A1F30-0x00000001809A1F70
	}

	[CompilerGenerated]
	private sealed class _UpgradePetAPI_d__243 : IEnumerator<object> // TypeDefIndex: 2004
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpgradePetAPI_d__243(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A1F70-0x00000001809A21E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A21E0-0x00000001809A2220
	}

	[CompilerGenerated]
	private sealed class _UpgradeSelectedStoneSequence_d__167 : IEnumerator<object> // TypeDefIndex: 2005
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int totalGroups; // 0x20
		public StoneDTO selectedStone; // 0x28
		public ManagerKhoPet __4__this; // 0x30
		private __c__DisplayClass167_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeSelectedStoneSequence_d__167(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001809A2220-0x00000001809A2F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A2F40-0x00000001809A2F80
	}

	[CompilerGenerated]
	private sealed class _UpgradeStoneAPI_d__169 : IEnumerator<object> // TypeDefIndex: 2006
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EncryptedBody payload; // 0x20
		public ManagerKhoPet __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpgradeStoneAPI_d__169(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A2F80-0x00000001809A31F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A31F0-0x00000001809A3230
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenReload_d__245 : IEnumerator<object> // TypeDefIndex: 2007
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public PetUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForAnimationThenReload_d__245(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A3230-0x00000001809A35C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A35C0-0x00000001809A3600
	}

	[CompilerGenerated]
	private sealed class _WaitForStoneAnimationThenReload_d__171 : IEnumerator<object> // TypeDefIndex: 2008
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerKhoPet __4__this; // 0x20
		public StoneUpgradeResponseDTO response; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForStoneAnimationThenReload_d__171(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809A3600-0x00000001809A3990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A3990-0x00000001809A39D0
	}

	// Constructors
	public ManagerKhoPet(); // 0x000000018099DA20-0x000000018099E190

	// Methods
	private void Awake(); // 0x000000018097F670-0x000000018097F680
	private void WireOnce(); // 0x000000018097F680-0x000000018097FBC0
	private void OpenPetStarPanel(); // 0x000000018097FBC0-0x000000018097FE00
	private bool CanUpgradeStar(long petId); // 0x000000018097FE00-0x000000018097FE80
	private void RefreshPetStarButton(); // 0x000000018097FE80-0x00000001809802D0
	[IteratorStateMachine(typeof(_LoadPetStars_d__123))]
	private IEnumerator LoadPetStars(int userId); // 0x00000001809802D0-0x0000000180980380
	private void RefreshVisibleStarRows(); // 0x0000000180980380-0x00000001809806F0
	private int GetPetStar(long petId); // 0x00000001809806F0-0x0000000180980790
	public void OnPetStarChanged(long petId, int newStar); // 0x0000000180980790-0x0000000180980850
	private void Start(); // 0x0000000180980850-0x0000000180980870
	public void Open(); // 0x0000000180980870-0x0000000180980A80
	private void EnsurePreviewCamera(); // 0x0000000180980A80-0x0000000180980F60
	private void SetupButtons(); // 0x0000000180980F60-0x0000000180981800
	private void SetupToggles(); // 0x0000000180981800-0x0000000180981DB0
	private void SetupInitialStates(); // 0x0000000180981DB0-0x0000000180982430
	private Coroutine RunWrite(IEnumerator routine); // 0x0000000180982430-0x0000000180982540
	private Coroutine StartCoroutineTracked(IEnumerator routine); // 0x0000000180982540-0x0000000180982620
	private void LoadAudioSettings(); // 0x0000000180982620-0x0000000180982660
	private void PlayBackgroundMusic(); // 0x0000000180982660-0x0000000180982A40
	private void ApplyGlobalClickSound(); // 0x0000000180982A40-0x0000000180982D40
	private void RestoreGlobalClickSound(); // 0x0000000180982D40-0x0000000180982F20
	private void SetupButtonSoundsOptimized(); // 0x0000000180982F20-0x00000001809831B0
	public void SetBGMVolume(float volume); // 0x00000001809831B0-0x0000000180983330
	private void SetupCanvasGroups(); // 0x0000000180983330-0x0000000180983500
	private CanvasGroup GetOrAddCanvasGroup(GameObject obj); // 0x0000000180983500-0x00000001809836C0
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x00000001809836C0-0x0000000180983720
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180983720-0x0000000180983790
	private void AnimateButtonClick(Button button); // 0x0000000180983790-0x0000000180983A80
	private void AnimateItemAppear(GameObject item, int index, float baseDelay = 0f /* Metadata: 0x005F03BE */); // 0x0000000180983A80-0x0000000180983D50
	private void AnimateStatUpdate(UnityEngine.UI.Text textComponent, int oldValue, int newValue, float delay = 0f /* Metadata: 0x005F03C2 */); // 0x0000000180983D50-0x00000001809840D0
	private void OnToggleUpgradeAllChanged(bool isOn); // 0x00000001809840D0-0x0000000180984450
	[IteratorStateMachine(typeof(_HideStoneMessageAfterDelay_d__151))]
	private IEnumerator HideStoneMessageAfterDelay(float delay); // 0x0000000180984450-0x0000000180984510
	private void OpenStoneUpgradePanel(); // 0x0000000180984510-0x00000001809847D0
	private void CloseStoneUpgradePanel(); // 0x00000001809847D0-0x0000000180984920
	private void SelectElement(string element); // 0x0000000180984920-0x0000000180984D20
	private void LoadStonesForUpgrade(string elementType); // 0x0000000180984D20-0x0000000180985080
	private void ClearContainer(Transform container); // 0x0000000180985080-0x0000000180985090
	private void SetupStoneUpgradeUI(GameObject stoneObj, StoneDTO stone, int index); // 0x0000000180985090-0x00000001809857D0
	private void OnStoneUpgradeClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x00000001809857D0-0x0000000180985D90
	private void UpdateStoneUpgradeSlotsUI(); // 0x0000000180985D90-0x0000000180986A70
	private void RemoveStoneFromUpgradeSlot(int slotIndex); // 0x0000000180986A70-0x0000000180986BD0
	private void UpdateStoneUpgradeListUI(); // 0x0000000180986BD0-0x0000000180987490
	private void UpdateStoneMainDisplay(); // 0x0000000180987490-0x0000000180987900
	private void CalculateStoneUpgradePercent(); // 0x0000000180987900-0x0000000180987CA0
	private void OnUpgradeStoneClicked(); // 0x0000000180987CA0-0x0000000180987EC0
	private void UpgradeAllStonesOfSelectedType(); // 0x0000000180987EC0-0x0000000180988200
	[IteratorStateMachine(typeof(_DeductGoldAndUpgradeSelectedStone_d__166))]
	private IEnumerator DeductGoldAndUpgradeSelectedStone(StoneDTO selectedStone, int totalGroups); // 0x0000000180988200-0x0000000180988310
	[IteratorStateMachine(typeof(_UpgradeSelectedStoneSequence_d__167))]
	private IEnumerator UpgradeSelectedStoneSequence(StoneDTO selectedStone, int totalGroups); // 0x0000000180988310-0x0000000180988420
	private void UpgradeThreeStones(); // 0x0000000180988420-0x0000000180988AD0
	[IteratorStateMachine(typeof(_UpgradeStoneAPI_d__169))]
	private IEnumerator UpgradeStoneAPI(EncryptedBody payload); // 0x0000000180988AD0-0x0000000180988BE0
	private void OnStoneUpgradeSuccess(StoneUpgradeResponseDTO response); // 0x0000000180988BE0-0x0000000180988E70
	[IteratorStateMachine(typeof(_WaitForStoneAnimationThenReload_d__171))]
	private IEnumerator WaitForStoneAnimationThenReload(StoneUpgradeResponseDTO response); // 0x0000000180988E70-0x0000000180988F80
	private void HandleStoneUpgradeResult(StoneUpgradeResponseDTO response); // 0x0000000180988F80-0x0000000180989310
	[IteratorStateMachine(typeof(_ReloadAllStonesAfterUpgrade_d__173))]
	private IEnumerator ReloadAllStonesAfterUpgrade(); // 0x0000000180989310-0x00000001809893B0
	private void OnAllStonesReloadedAfterUpgrade(StoneResponse stones); // 0x00000001809893B0-0x0000000180989460
	private void OnStoneUpgradeError(string error); // 0x0000000180989460-0x0000000180989780
	[IteratorStateMachine(typeof(_HideStoneResultAfterDelay_d__176))]
	private IEnumerator HideStoneResultAfterDelay(float delay); // 0x0000000180989780-0x0000000180989840
	private void ShowStoneErrorMessage(string message); // 0x0000000180989840-0x0000000180989A40
	private void ResetStoneUpgradeUI(); // 0x0000000180989A40-0x0000000180989E40
	private void OnToggleProtectionChanged(bool isOn); // 0x0000000180989E40-0x000000018098A290
	private void OnToggle15PercentChanged(bool isOn); // 0x000000018098A290-0x000000018098A460
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__181))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x000000018098A460-0x000000018098A520
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__182))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018098A520-0x000000018098A5C0
	private void ShowLocalLoading(bool show); // 0x000000018098A5C0-0x000000018098A720
	[IteratorStateMachine(typeof(_LoadPetsPage_d__184))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x000000018098A720-0x000000018098A7E0
	private void OnPetsPageReceived(PetPageResponse response, int seq); // 0x000000018098A7E0-0x000000018098A970
	private void DisplayCurrentPage(); // 0x000000018098A970-0x000000018098AFD0
	private void SetupPetUISimple(GameObject petUIObject, PetUserDTO pet); // 0x000000018098AFD0-0x000000018098BA50
	private bool IsCurrentPetOnPage(); // 0x000000018098BA50-0x000000018098BAD0
	private void UpdatePaginationButtons(); // 0x000000018098BAD0-0x000000018098BE10
	private void ShowPreviousPage(); // 0x000000018098BE10-0x000000018098BEA0
	private void ShowNextPage(); // 0x000000018098BEA0-0x000000018098BF30
	[IteratorStateMachine(typeof(_LoadPage_d__194))]
	private IEnumerator LoadPage(int userId, int page); // 0x000000018098BF30-0x000000018098BFF0
	private void ClearPetListSimple(); // 0x000000018098BFF0-0x000000018098C770
	private void ReturnPetUIToPoolSimple(GameObject obj); // 0x000000018098C770-0x000000018098C990
	private void ClearPetListNoPool(); // 0x000000018098C990-0x000000018098D120
	private void DisplayCurrentPageNoPool(); // 0x000000018098D120-0x000000018098D5A0
	private void SetPaginationButtonsState(bool interactable); // 0x000000018098D5A0-0x000000018098D8A0
	private void OnPageLoadError(string error); // 0x000000018098D8A0-0x000000018098DB10
	private void ClearContainerSafe(Transform container); // 0x000000018098DB10-0x000000018098E550
	private void OnStonesReceived(StoneResponse stones); // 0x000000018098E550-0x000000018098E5B0
	private void SetupPetUI(GameObject petUIObject, PetUserDTO pet); // 0x000000018098E5B0-0x000000018098E870
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x000000018098E870-0x000000018098EAB0
	private GameObject GetPetUIFromPool(); // 0x000000018098EAB0-0x000000018098EBD0
	private void SetupFallbackImage(Image petIcon, string petID, Animator petAnimator); // 0x000000018098EBD0-0x000000018098EE90
	private void SetupPetInfo(GameObject petUIObject, PetUserDTO pet, string petID); // 0x000000018098EE90-0x000000018098F520
	private void SelectPet(PetUserDTO pet, bool fromPetList = false /* Metadata: 0x005F03C6 */); // 0x000000018098F520-0x000000018098F640
	private float EvoScale(PetUserDTO pet); // 0x000000018098F640-0x000000018098F970
	private void OnPetClicked(string petId, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes, PetUserDTO pet, int skillCardId, bool fromPetList = false /* Metadata: 0x005F03C7 */); // 0x000000018098F970-0x00000001809908A0
	private void ApplyNextLevelInfo(PetUserDTO pet); // 0x00000001809908A0-0x0000000180990B90
	private PetUserDTO Canonical(PetUserDTO pet); // 0x0000000180990B90-0x0000000180990C10
	private void ApplyUpgradedPet(PetUpgradeResponseDTO response); // 0x0000000180990C10-0x0000000180990D20
	private static void CopyPetInto(PetUserDTO dst, PetUserDTO src); // 0x0000000180990D20-0x0000000180990F60
	private void RefreshVisiblePetCells(); // 0x0000000180990F60-0x0000000180991BD0
	private static void SetNextCell(UnityEngine.UI.Text t, bool show, string value); // 0x0000000180991BD0-0x0000000180991DD0
	public void SelectNeighbor(int dir); // 0x0000000180991DD0-0x0000000180992000
	public void QuickFill(); // 0x0000000180992000-0x0000000180992320
	private void PlayStoneFly(GameObject stoneObj, int slotIndex); // 0x0000000180992320-0x00000001809927B0
	private void PlayPokyUpgradeFx(PetUpgradeResponseDTO response); // 0x00000001809927B0-0x0000000180992C00
	private void PopBadge(Color tint); // 0x0000000180992C00-0x0000000180993080
	private void ShowGainSummary(string text); // 0x0000000180993080-0x00000001809932C0
	[IteratorStateMachine(typeof(_HideGainSummaryAfterDelay_d__227))]
	private IEnumerator HideGainSummaryAfterDelay(float delay); // 0x00000001809932C0-0x0000000180993380
	public static string FormatVND(long amount); // 0x0000000180993380-0x0000000180993490
	private void LoadStonesForElement(string elementType); // 0x0000000180993490-0x0000000180993780
	private StoneDTO[] GetStonesForElement(string element); // 0x0000000180993780-0x00000001809939F0
	private void SetupStoneUI(GameObject stoneObj, StoneDTO stone, int index); // 0x00000001809939F0-0x00000001809941B0
	private Sprite GetStoneSpriteByElement(string elementType, int level); // 0x00000001809941B0-0x0000000180994420
	private void OnStoneClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180994420-0x00000001809948B0
	private void UpdateSelectedStonesUI(); // 0x00000001809948B0-0x0000000180995580
	private void RemoveStoneFromSlot(int slotIndex); // 0x0000000180995580-0x00000001809956E0
	private void UpdateStoneListUI(); // 0x00000001809956E0-0x0000000180995FB0
	private void CalculateUpgradePercent(); // 0x0000000180995FB0-0x0000000180996410
	private float CalculateStoneRate(int petLevel, int stoneLevel); // 0x0000000180996410-0x0000000180996460
	private void LockStoneInteraction(); // 0x0000000180996460-0x0000000180996C20
	private void UnlockStoneInteraction(); // 0x0000000180996C20-0x0000000180997440
	private void OnUpgradeButtonClicked(); // 0x0000000180997440-0x0000000180997C30
	private void ShowErrorMessage(string message); // 0x0000000180997C30-0x0000000180997E20
	[IteratorStateMachine(typeof(_UpgradePetAPI_d__243))]
	private IEnumerator UpgradePetAPI(EncryptedBody payload); // 0x0000000180997E20-0x0000000180997F30
	private void OnUpgradeSuccess(PetUpgradeResponseDTO response); // 0x0000000180997F30-0x00000001809981C0
	[IteratorStateMachine(typeof(_WaitForAnimationThenReload_d__245))]
	private IEnumerator WaitForAnimationThenReload(PetUpgradeResponseDTO response); // 0x00000001809981C0-0x00000001809982D0
	private void HandleUpgradeResult(PetUpgradeResponseDTO response); // 0x00000001809982D0-0x0000000180998C70
	private void OnUpgradeError(string error); // 0x0000000180998C70-0x0000000180998FB0
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__248))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x0000000180998FB0-0x0000000180999070
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__249))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x0000000180999070-0x0000000180999110
	private void OnStonesReloaded(StoneResponse stones); // 0x0000000180999110-0x0000000180999190
	private float GetUpgradeSuccessRate(); // 0x0000000180999190-0x0000000180999290
	private float GetUpgradeSuccessRateWithBoost(); // 0x0000000180999290-0x0000000180999490
	private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x0000000180999490-0x0000000180999590
	private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x0000000180999590-0x0000000180999770
	private void OnUserReceived(UserDTO user); // 0x0000000180999770-0x0000000180999910
	public void BackScene(); // 0x0000000180999910-0x0000000180999B00
	private void OnError(string error); // 0x0000000180999B00-0x0000000180999BA0
	private Button ResolveCardTooltipButton(); // 0x0000000180999BA0-0x000000018099A760
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x000000018099A760-0x000000018099A9E0
	public void ShowSkillCardTooltip(); // 0x000000018099A9E0-0x000000018099AD10
	private void PlayCardShowFx(); // 0x000000018099AD10-0x000000018099B030
	private void StartCardPulse(); // 0x000000018099B030-0x000000018099B370
	private void StopCardFx(); // 0x000000018099B370-0x000000018099B5A0
	private void PlayCardPunch(); // 0x000000018099B5A0-0x000000018099B8D0
	private static string SkillCardCostLine(PetUserDTO pet); // 0x000000018099B8D0-0x000000018099BB50
	private void LoadPetSkillCard(int skillCardId, string description, string cardName, PetUserDTO pet = null); // 0x000000018099BB50-0x000000018099C490
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__274))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x005F03C8 */, float moveDistance = 50f /* Metadata: 0x005F03CC */); // 0x000000018099C490-0x000000018099C550
	private void OnDestroy(); // 0x000000018099C550-0x000000018099CD40
	private void CleanupPetUIComplete(GameObject petUI); // 0x000000018099CD40-0x000000018099D1E0
	private void OnDisable(); // 0x000000018099D1E0-0x000000018099DA20
	[CompilerGenerated]
	private void _LoadPetStars_b__123_0(PetStarListResponse resp); // 0x000000018099E190-0x000000018099E360
	[CompilerGenerated]
	private void _SetupButtons_b__130_0(); // 0x000000018099E360-0x000000018099E3B0
	[CompilerGenerated]
	private void _SetupButtons_b__130_1(); // 0x000000018099E3B0-0x000000018099E400
	[CompilerGenerated]
	private void _SetupButtons_b__130_2(); // 0x000000018099E400-0x000000018099E450
	[CompilerGenerated]
	private void _SetupButtons_b__130_3(); // 0x000000018099E450-0x000000018099E4A0
	[CompilerGenerated]
	private void _SetupButtons_b__130_4(); // 0x000000018099E4A0-0x000000018099E4F0
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__249_0(PetUserDTO p); // 0x000000018099E4F0-0x000000018099E520
	[CompilerGenerated]
	private void _PlayCardPunch_b__271_0(); // 0x000000018099E520-0x000000018099E6B0
}

