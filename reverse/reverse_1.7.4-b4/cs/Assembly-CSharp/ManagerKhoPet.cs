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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerKhoPet : MonoBehaviour // TypeDefIndex: 1973
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
	private const int PETS_PER_PAGE = 12; // Metadata: 0x005F17A1
	private int _dataSeq; // 0x35C
	private int _appliedSeq; // 0x360
	private Coroutine _reloadAfterUpgradeCo; // 0x368
	public const string PANEL_KEY = "PanelKhoPet"; // Metadata: 0x005F17A2
	private bool _wired; // 0x370
	private bool _openHandled; // 0x371
	private bool _loadingVisible; // 0x372
	private AudioClip _prevGlobalClickSound; // 0x378
	private const float PET_STAR_DIM_ALPHA = 0.55f; // Metadata: 0x005F17AE
	[Header("Mobile Optimization")]
	public bool enableMobileOptimization; // 0x380
	private bool isLoadingPage; // 0x381
	[Header("Object Pooling - OPTIMIZED")]
	private Queue<GameObject> petUIPool; // 0x388
	private const int POOL_SIZE = 15; // Metadata: 0x005F17B2
	private const float PET_FRAME_W = 240f; // Metadata: 0x005F17B3
	private const float PET_FRAME_H = 160f; // Metadata: 0x005F17B7
	private Button _cardTooltipButton; // 0x390
	private bool _cardTooltipResolved; // 0x398
	private string _cardTooltipTitle; // 0x3A0
	private string _cardTooltipBody; // 0x3A8
	private Sprite _cardTooltipIcon; // 0x3B0
	private const float CARD_PULSE_PERIOD = 1.6f; // Metadata: 0x005F17BB
	private bool _cardPulsing; // 0x3B8

	// Properties
	private bool PanelAlive { get; } // 0x0000000180985A80-0x0000000180985AD0 

	// Events
	public static event Action<PetUserDTO> PetSelected {
		add; // 0x0000000180982A60-0x0000000180982B90
		remove; // 0x0000000180982B90-0x0000000180982CC0
	}

	// Nested types
	[Serializable]
	public class StoneBatchUpgradeResponseDTO // TypeDefIndex: 1974
	{
		// Fields
		public string message; // 0x10
		public int successCount; // 0x18
		public int remainingGold; // 0x1C

		// Constructors
		public StoneBatchUpgradeResponseDTO(); // 0x00000001809A1E20-0x00000001809A1E30
	}

	[Serializable]
	public class PetUpgradeResponseDTO // TypeDefIndex: 1975
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public PetUserDTO updatedPet; // 0x20

		// Constructors
		public PetUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class StoneUpgradeResponseDTO // TypeDefIndex: 1976
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18

		// Constructors
		public StoneUpgradeResponseDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class PetPageResponse // TypeDefIndex: 1977
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
	private sealed class __c // TypeDefIndex: 1978
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
		static __c(); // 0x00000001809A1E30-0x00000001809A1ED0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetStars_b__123_1(string err); // 0x00000001809A1ED0-0x00000001809A1F50
		internal int _LoadStonesForUpgrade_b__155_0(StoneDTO s); // 0x00000001809A1F50-0x00000001809A1F70
		internal bool _OnStoneUpgradeClicked_b__158_0(StoneDTO s); // 0x00000001809A1F70-0x00000001809A1F80
		internal bool _CalculateStoneUpgradePercent_b__163_0(StoneDTO s); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal bool _UpgradeThreeStones_b__168_0(StoneDTO s); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal bool _UpgradeThreeStones_b__168_2(StoneDTO s); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal long _UpgradeThreeStones_b__168_3(StoneDTO s); // 0x00000001809A1F80-0x00000001809A1FA0
		internal bool _SetupStoneUI_b__231_1(StoneDTO s); // 0x00000001809A1F70-0x00000001809A1F80
		internal bool _OnStoneClicked_b__233_0(StoneDTO s); // 0x00000001809A1F70-0x00000001809A1F80
		internal bool _OnUpgradeButtonClicked_b__241_0(StoneDTO s); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal bool _OnUpgradeButtonClicked_b__241_1(StoneDTO s); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal long _OnUpgradeButtonClicked_b__241_2(StoneDTO s); // 0x00000001809A1F80-0x00000001809A1FA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass147_0 // TypeDefIndex: 1979
	{
		// Fields
		public Button button; // 0x10

		// Constructors
		public __c__DisplayClass147_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateButtonClick_b__0(); // 0x00000001809A1FA0-0x00000001809A2120
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass149_0 // TypeDefIndex: 1980
	{
		// Fields
		public UnityEngine.UI.Text textComponent; // 0x10

		// Constructors
		public __c__DisplayClass149_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AnimateStatUpdate_b__0(); // 0x00000001809A2120-0x00000001809A22A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass157_0 // TypeDefIndex: 1981
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public Button btnStone; // 0x18
		public StoneDTO stone; // 0x20
		public UnityEngine.UI.Text txtCount; // 0x28

		// Constructors
		public __c__DisplayClass157_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupStoneUpgradeUI_b__0(); // 0x00000001809A22A0-0x00000001809A22F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass159_0 // TypeDefIndex: 1982
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass159_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateStoneUpgradeSlotsUI_b__0(); // 0x00000001809A22F0-0x00000001809A2480
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass163_0 // TypeDefIndex: 1983
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass163_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _CalculateStoneUpgradePercent_b__1(StoneDTO s); // 0x00000001809A2480-0x00000001809A24A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass167_0 // TypeDefIndex: 1984
	{
		// Fields
		public bool apiSuccess; // 0x10
		public StoneBatchUpgradeResponseDTO response; // 0x18

		// Constructors
		public __c__DisplayClass167_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpgradeSelectedStoneSequence_b__0(StoneBatchUpgradeResponseDTO res); // 0x00000001802B9440-0x00000001802B94A0
		internal void _UpgradeSelectedStoneSequence_b__1(string error); // 0x00000001809A24A0-0x00000001809A2530
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass168_0 // TypeDefIndex: 1985
	{
		// Fields
		public int firstLevel; // 0x10

		// Constructors
		public __c__DisplayClass168_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _UpgradeThreeStones_b__1(StoneDTO s); // 0x00000001809A2480-0x00000001809A24A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass184_0 // TypeDefIndex: 1986
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass184_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPetsPage_b__0(PetPageResponse response); // 0x00000001809A2530-0x00000001809A2560
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass187_0 // TypeDefIndex: 1987
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass187_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupPetUISimple_b__0(); // 0x00000001809A2560-0x00000001809A2590
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 1988
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public int seq; // 0x18

		// Constructors
		public __c__DisplayClass194_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPage_b__0(PetPageResponse response); // 0x00000001809A2530-0x00000001809A2560
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass209_0 // TypeDefIndex: 1989
	{
		// Fields
		public ManagerKhoPet __4__this; // 0x10
		public PetUserDTO pet; // 0x18

		// Constructors
		public __c__DisplayClass209_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupPetInfo_b__0(); // 0x00000001809A2560-0x00000001809A2590
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass225_0 // TypeDefIndex: 1990
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass225_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PopBadge_b__0(); // 0x00000001809A2590-0x00000001809A2710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 1991
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
		internal void _SetupStoneUI_b__0(); // 0x00000001809A2710-0x00000001809A2950
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass234_0 // TypeDefIndex: 1992
	{
		// Fields
		public Button btn; // 0x10
		public int slotIndex; // 0x18
		public ManagerKhoPet __4__this; // 0x20

		// Constructors
		public __c__DisplayClass234_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateSelectedStonesUI_b__0(); // 0x00000001809A2950-0x00000001809A2AE0
	}

	[CompilerGenerated]
	private sealed class _AnimateTextFlyUp_d__274 : IEnumerator<object> // TypeDefIndex: 1993
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A2AE0-0x00000001809A2F80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A2F80-0x00000001809A2FC0
	}

	[CompilerGenerated]
	private sealed class _DeductGoldAndUpgradeSelectedStone_d__166 : IEnumerator<object> // TypeDefIndex: 1994
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A2FC0-0x00000001809A3170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A3170-0x00000001809A31B0
	}

	[CompilerGenerated]
	private sealed class _HideGainSummaryAfterDelay_d__227 : IEnumerator<object> // TypeDefIndex: 1995
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A31B0-0x00000001809A33D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A33D0-0x00000001809A3410
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__181 : IEnumerator<object> // TypeDefIndex: 1996
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A3410-0x00000001809A3630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A3630-0x00000001809A3670
	}

	[CompilerGenerated]
	private sealed class _HideResultAfterDelay_d__248 : IEnumerator<object> // TypeDefIndex: 1997
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A3670-0x00000001809A38D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A38D0-0x00000001809A3910
	}

	[CompilerGenerated]
	private sealed class _HideStoneMessageAfterDelay_d__151 : IEnumerator<object> // TypeDefIndex: 1998
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A3910-0x00000001809A3B30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A3B30-0x00000001809A3B70
	}

	[CompilerGenerated]
	private sealed class _HideStoneResultAfterDelay_d__176 : IEnumerator<object> // TypeDefIndex: 1999
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A3B70-0x00000001809A3DD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A3DD0-0x00000001809A3E10
	}

	[CompilerGenerated]
	private sealed class _LoadPage_d__194 : IEnumerator<object> // TypeDefIndex: 2000
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A3E10-0x00000001809A41F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A41F0-0x00000001809A4230
	}

	[CompilerGenerated]
	private sealed class _LoadPetStars_d__123 : IEnumerator<object> // TypeDefIndex: 2001
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A4230-0x00000001809A4670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A4670-0x00000001809A46B0
	}

	[CompilerGenerated]
	private sealed class _LoadPetsPage_d__184 : IEnumerator<object> // TypeDefIndex: 2002
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A46B0-0x00000001809A4A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A4A60-0x00000001809A4AA0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__182 : IEnumerator<object> // TypeDefIndex: 2003
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
		private bool MoveNext(); // 0x00000001809A4AA0-0x00000001809A4F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A4F40-0x00000001809A4F80
	}

	[CompilerGenerated]
	private sealed class _ReloadAllStonesAfterUpgrade_d__173 : IEnumerator<object> // TypeDefIndex: 2004
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A4F80-0x00000001809A51B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A51B0-0x00000001809A51F0
	}

	[CompilerGenerated]
	private sealed class _ReloadDataAfterUpgrade_d__249 : IEnumerator<object> // TypeDefIndex: 2005
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
		private bool MoveNext(); // 0x00000001809A51F0-0x00000001809A5790
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A5790-0x00000001809A57D0
	}

	[CompilerGenerated]
	private sealed class _UpgradePetAPI_d__243 : IEnumerator<object> // TypeDefIndex: 2006
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A57D0-0x00000001809A5A90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A5A90-0x00000001809A5AD0
	}

	[CompilerGenerated]
	private sealed class _UpgradeSelectedStoneSequence_d__167 : IEnumerator<object> // TypeDefIndex: 2007
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
		private bool MoveNext(); // 0x00000001809A5AD0-0x00000001809A67A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A67A0-0x00000001809A67E0
	}

	[CompilerGenerated]
	private sealed class _UpgradeStoneAPI_d__169 : IEnumerator<object> // TypeDefIndex: 2008
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A67E0-0x00000001809A6AA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A6AA0-0x00000001809A6AE0
	}

	[CompilerGenerated]
	private sealed class _WaitForAnimationThenReload_d__245 : IEnumerator<object> // TypeDefIndex: 2009
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A6AE0-0x00000001809A6E70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A6E70-0x00000001809A6EB0
	}

	[CompilerGenerated]
	private sealed class _WaitForStoneAnimationThenReload_d__171 : IEnumerator<object> // TypeDefIndex: 2010
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809A6EB0-0x00000001809A7240
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809A7240-0x00000001809A7280
	}

	// Constructors
	public ManagerKhoPet(); // 0x00000001809A1190-0x00000001809A1900

	// Methods
	private void Awake(); // 0x0000000180982CC0-0x0000000180982CD0
	private void WireOnce(); // 0x0000000180982CD0-0x0000000180983210
	private void OpenPetStarPanel(); // 0x0000000180983210-0x0000000180983450
	private bool CanUpgradeStar(long petId); // 0x0000000180983450-0x00000001809834D0
	private void RefreshPetStarButton(); // 0x00000001809834D0-0x0000000180983920
	[IteratorStateMachine(typeof(_LoadPetStars_d__123))]
	private IEnumerator LoadPetStars(int userId); // 0x0000000180983920-0x00000001809839D0
	private void RefreshVisibleStarRows(); // 0x00000001809839D0-0x0000000180983D40
	private int GetPetStar(long petId); // 0x0000000180983D40-0x0000000180983DE0
	public void OnPetStarChanged(long petId, int newStar); // 0x0000000180983DE0-0x0000000180983EA0
	private void Start(); // 0x0000000180983EA0-0x0000000180983EC0
	public void Open(); // 0x0000000180983EC0-0x00000001809840D0
	private void EnsurePreviewCamera(); // 0x00000001809840D0-0x00000001809845B0
	private void SetupButtons(); // 0x00000001809845B0-0x0000000180984E50
	private void SetupToggles(); // 0x0000000180984E50-0x0000000180985400
	private void SetupInitialStates(); // 0x0000000180985400-0x0000000180985A80
	private Coroutine RunWrite(IEnumerator routine); // 0x0000000180985AD0-0x0000000180985C00
	private Coroutine StartCoroutineTracked(IEnumerator routine); // 0x0000000180985C00-0x0000000180985D10
	private void LoadAudioSettings(); // 0x0000000180985D10-0x0000000180985D50
	private void PlayBackgroundMusic(); // 0x0000000180985D50-0x0000000180986130
	private void ApplyGlobalClickSound(); // 0x0000000180986130-0x0000000180986430
	private void RestoreGlobalClickSound(); // 0x0000000180986430-0x0000000180986610
	private void SetupButtonSoundsOptimized(); // 0x0000000180986610-0x00000001809868A0
	public void SetBGMVolume(float volume); // 0x00000001809868A0-0x0000000180986A20
	private void SetupCanvasGroups(); // 0x0000000180986A20-0x0000000180986BF0
	private CanvasGroup GetOrAddCanvasGroup(GameObject obj); // 0x0000000180986BF0-0x0000000180986DB0
	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180986DB0-0x0000000180986E10
	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup); // 0x0000000180986E10-0x0000000180986E80
	private void AnimateButtonClick(Button button); // 0x0000000180986E80-0x0000000180987170
	private void AnimateItemAppear(GameObject item, int index, float baseDelay = 0f /* Metadata: 0x005F178F */); // 0x0000000180987170-0x0000000180987440
	private void AnimateStatUpdate(UnityEngine.UI.Text textComponent, int oldValue, int newValue, float delay = 0f /* Metadata: 0x005F1793 */); // 0x0000000180987440-0x00000001809877C0
	private void OnToggleUpgradeAllChanged(bool isOn); // 0x00000001809877C0-0x0000000180987B40
	[IteratorStateMachine(typeof(_HideStoneMessageAfterDelay_d__151))]
	private IEnumerator HideStoneMessageAfterDelay(float delay); // 0x0000000180987B40-0x0000000180987C00
	private void OpenStoneUpgradePanel(); // 0x0000000180987C00-0x0000000180987EC0
	private void CloseStoneUpgradePanel(); // 0x0000000180987EC0-0x0000000180988010
	private void SelectElement(string element); // 0x0000000180988010-0x0000000180988410
	private void LoadStonesForUpgrade(string elementType); // 0x0000000180988410-0x0000000180988770
	private void ClearContainer(Transform container); // 0x0000000180988770-0x0000000180988780
	private void SetupStoneUpgradeUI(GameObject stoneObj, StoneDTO stone, int index); // 0x0000000180988780-0x0000000180988EC0
	private void OnStoneUpgradeClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180988EC0-0x0000000180989480
	private void UpdateStoneUpgradeSlotsUI(); // 0x0000000180989480-0x000000018098A160
	private void RemoveStoneFromUpgradeSlot(int slotIndex); // 0x000000018098A160-0x000000018098A2C0
	private void UpdateStoneUpgradeListUI(); // 0x000000018098A2C0-0x000000018098AB80
	private void UpdateStoneMainDisplay(); // 0x000000018098AB80-0x000000018098AFF0
	private void CalculateStoneUpgradePercent(); // 0x000000018098AFF0-0x000000018098B390
	private void OnUpgradeStoneClicked(); // 0x000000018098B390-0x000000018098B5B0
	private void UpgradeAllStonesOfSelectedType(); // 0x000000018098B5B0-0x000000018098B8F0
	[IteratorStateMachine(typeof(_DeductGoldAndUpgradeSelectedStone_d__166))]
	private IEnumerator DeductGoldAndUpgradeSelectedStone(StoneDTO selectedStone, int totalGroups); // 0x000000018098B8F0-0x000000018098BA00
	[IteratorStateMachine(typeof(_UpgradeSelectedStoneSequence_d__167))]
	private IEnumerator UpgradeSelectedStoneSequence(StoneDTO selectedStone, int totalGroups); // 0x000000018098BA00-0x000000018098BB10
	private void UpgradeThreeStones(); // 0x000000018098BB10-0x000000018098C1C0
	[IteratorStateMachine(typeof(_UpgradeStoneAPI_d__169))]
	private IEnumerator UpgradeStoneAPI(EncryptedBody payload); // 0x000000018098C1C0-0x000000018098C2D0
	private void OnStoneUpgradeSuccess(StoneUpgradeResponseDTO response); // 0x000000018098C2D0-0x000000018098C5A0
	[IteratorStateMachine(typeof(_WaitForStoneAnimationThenReload_d__171))]
	private IEnumerator WaitForStoneAnimationThenReload(StoneUpgradeResponseDTO response); // 0x000000018098C5A0-0x000000018098C6B0
	private void HandleStoneUpgradeResult(StoneUpgradeResponseDTO response); // 0x000000018098C6B0-0x000000018098CA40
	[IteratorStateMachine(typeof(_ReloadAllStonesAfterUpgrade_d__173))]
	private IEnumerator ReloadAllStonesAfterUpgrade(); // 0x000000018098CA40-0x000000018098CAE0
	private void OnAllStonesReloadedAfterUpgrade(StoneResponse stones); // 0x000000018098CAE0-0x000000018098CB90
	private void OnStoneUpgradeError(string error); // 0x000000018098CB90-0x000000018098CEB0
	[IteratorStateMachine(typeof(_HideStoneResultAfterDelay_d__176))]
	private IEnumerator HideStoneResultAfterDelay(float delay); // 0x000000018098CEB0-0x000000018098CF70
	private void ShowStoneErrorMessage(string message); // 0x000000018098CF70-0x000000018098D170
	private void ResetStoneUpgradeUI(); // 0x000000018098D170-0x000000018098D570
	private void OnToggleProtectionChanged(bool isOn); // 0x000000018098D570-0x000000018098D9C0
	private void OnToggle15PercentChanged(bool isOn); // 0x000000018098D9C0-0x000000018098DB90
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__181))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x000000018098DB90-0x000000018098DC50
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__182))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018098DC50-0x000000018098DCF0
	private void ShowLocalLoading(bool show); // 0x000000018098DCF0-0x000000018098DE50
	[IteratorStateMachine(typeof(_LoadPetsPage_d__184))]
	private IEnumerator LoadPetsPage(int userId, int page); // 0x000000018098DE50-0x000000018098DF10
	private void OnPetsPageReceived(PetPageResponse response, int seq); // 0x000000018098DF10-0x000000018098E0A0
	private void DisplayCurrentPage(); // 0x000000018098E0A0-0x000000018098E700
	private void SetupPetUISimple(GameObject petUIObject, PetUserDTO pet); // 0x000000018098E700-0x000000018098F180
	private bool IsCurrentPetOnPage(); // 0x000000018098F180-0x000000018098F200
	private void UpdatePaginationButtons(); // 0x000000018098F200-0x000000018098F540
	private void ShowPreviousPage(); // 0x000000018098F540-0x000000018098F5D0
	private void ShowNextPage(); // 0x000000018098F5D0-0x000000018098F660
	[IteratorStateMachine(typeof(_LoadPage_d__194))]
	private IEnumerator LoadPage(int userId, int page); // 0x000000018098F660-0x000000018098F720
	private void ClearPetListSimple(); // 0x000000018098F720-0x000000018098FEA0
	private void ReturnPetUIToPoolSimple(GameObject obj); // 0x000000018098FEA0-0x00000001809900C0
	private void ClearPetListNoPool(); // 0x00000001809900C0-0x0000000180990850
	private void DisplayCurrentPageNoPool(); // 0x0000000180990850-0x0000000180990CD0
	private void SetPaginationButtonsState(bool interactable); // 0x0000000180990CD0-0x0000000180990FD0
	private void OnPageLoadError(string error); // 0x0000000180990FD0-0x0000000180991240
	private void ClearContainerSafe(Transform container); // 0x0000000180991240-0x0000000180991C80
	private void OnStonesReceived(StoneResponse stones); // 0x0000000180991C80-0x0000000180991CE0
	private void SetupPetUI(GameObject petUIObject, PetUserDTO pet); // 0x0000000180991CE0-0x0000000180991FA0
	private bool TrySetupPetAnimation(Animator petAnimator, string petID); // 0x0000000180991FA0-0x00000001809921E0
	private GameObject GetPetUIFromPool(); // 0x00000001809921E0-0x0000000180992300
	private void SetupFallbackImage(Image petIcon, string petID, Animator petAnimator); // 0x0000000180992300-0x00000001809925C0
	private void SetupPetInfo(GameObject petUIObject, PetUserDTO pet, string petID); // 0x00000001809925C0-0x0000000180992C50
	private void SelectPet(PetUserDTO pet, bool fromPetList = false /* Metadata: 0x005F1797 */); // 0x0000000180992C50-0x0000000180992D70
	private float EvoScale(PetUserDTO pet); // 0x0000000180992D70-0x00000001809930A0
	private void OnPetClicked(string petId, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes, PetUserDTO pet, int skillCardId, bool fromPetList = false /* Metadata: 0x005F1798 */); // 0x00000001809930A0-0x0000000180993FD0
	private void ApplyNextLevelInfo(PetUserDTO pet); // 0x0000000180993FD0-0x00000001809942C0
	private PetUserDTO Canonical(PetUserDTO pet); // 0x00000001809942C0-0x0000000180994340
	private void ApplyUpgradedPet(PetUpgradeResponseDTO response); // 0x0000000180994340-0x0000000180994450
	private static void CopyPetInto(PetUserDTO dst, PetUserDTO src); // 0x0000000180994450-0x0000000180994690
	private void RefreshVisiblePetCells(); // 0x0000000180994690-0x0000000180995300
	private static void SetNextCell(UnityEngine.UI.Text t, bool show, string value); // 0x0000000180995300-0x0000000180995500
	public void SelectNeighbor(int dir); // 0x0000000180995500-0x0000000180995730
	public void QuickFill(); // 0x0000000180995730-0x0000000180995A50
	private void PlayStoneFly(GameObject stoneObj, int slotIndex); // 0x0000000180995A50-0x0000000180995EE0
	private void PlayPokyUpgradeFx(PetUpgradeResponseDTO response); // 0x0000000180995EE0-0x0000000180996330
	private void PopBadge(Color tint); // 0x0000000180996330-0x00000001809967B0
	private void ShowGainSummary(string text); // 0x00000001809967B0-0x00000001809969F0
	[IteratorStateMachine(typeof(_HideGainSummaryAfterDelay_d__227))]
	private IEnumerator HideGainSummaryAfterDelay(float delay); // 0x00000001809969F0-0x0000000180996AB0
	public static string FormatVND(long amount); // 0x0000000180996AB0-0x0000000180996BC0
	private void LoadStonesForElement(string elementType); // 0x0000000180996BC0-0x0000000180996EB0
	private StoneDTO[] GetStonesForElement(string element); // 0x0000000180996EB0-0x0000000180997120
	private void SetupStoneUI(GameObject stoneObj, StoneDTO stone, int index); // 0x0000000180997120-0x00000001809978E0
	private Sprite GetStoneSpriteByElement(string elementType, int level); // 0x00000001809978E0-0x0000000180997B50
	private void OnStoneClicked(StoneDTO stone, UnityEngine.UI.Text txtCount); // 0x0000000180997B50-0x0000000180997FE0
	private void UpdateSelectedStonesUI(); // 0x0000000180997FE0-0x0000000180998CB0
	private void RemoveStoneFromSlot(int slotIndex); // 0x0000000180998CB0-0x0000000180998E10
	private void UpdateStoneListUI(); // 0x0000000180998E10-0x00000001809996E0
	private void CalculateUpgradePercent(); // 0x00000001809996E0-0x0000000180999B40
	private float CalculateStoneRate(int petLevel, int stoneLevel); // 0x0000000180999B40-0x0000000180999B90
	private void LockStoneInteraction(); // 0x0000000180999B90-0x000000018099A350
	private void UnlockStoneInteraction(); // 0x000000018099A350-0x000000018099AB70
	private void OnUpgradeButtonClicked(); // 0x000000018099AB70-0x000000018099B360
	private void ShowErrorMessage(string message); // 0x000000018099B360-0x000000018099B550
	[IteratorStateMachine(typeof(_UpgradePetAPI_d__243))]
	private IEnumerator UpgradePetAPI(EncryptedBody payload); // 0x000000018099B550-0x000000018099B660
	private void OnUpgradeSuccess(PetUpgradeResponseDTO response); // 0x000000018099B660-0x000000018099B930
	[IteratorStateMachine(typeof(_WaitForAnimationThenReload_d__245))]
	private IEnumerator WaitForAnimationThenReload(PetUpgradeResponseDTO response); // 0x000000018099B930-0x000000018099BA40
	private void HandleUpgradeResult(PetUpgradeResponseDTO response); // 0x000000018099BA40-0x000000018099C3E0
	private void OnUpgradeError(string error); // 0x000000018099C3E0-0x000000018099C720
	[IteratorStateMachine(typeof(_HideResultAfterDelay_d__248))]
	private IEnumerator HideResultAfterDelay(float delay); // 0x000000018099C720-0x000000018099C7E0
	[IteratorStateMachine(typeof(_ReloadDataAfterUpgrade_d__249))]
	private IEnumerator ReloadDataAfterUpgrade(); // 0x000000018099C7E0-0x000000018099C880
	private void OnStonesReloaded(StoneResponse stones); // 0x000000018099C880-0x000000018099C900
	private float GetUpgradeSuccessRate(); // 0x000000018099C900-0x000000018099CA00
	private float GetUpgradeSuccessRateWithBoost(); // 0x000000018099CA00-0x000000018099CC00
	private void SetTextIfNotNull(UnityEngine.UI.Text textComponent, string value); // 0x000000018099CC00-0x000000018099CD00
	private void LoadAttributeImage(Image imageComponent, string attributeName); // 0x000000018099CD00-0x000000018099CEE0
	private void OnUserReceived(UserDTO user); // 0x000000018099CEE0-0x000000018099D080
	public void BackScene(); // 0x000000018099D080-0x000000018099D270
	private void OnError(string error); // 0x000000018099D270-0x000000018099D310
	private Button ResolveCardTooltipButton(); // 0x000000018099D310-0x000000018099DED0
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x000000018099DED0-0x000000018099E150
	public void ShowSkillCardTooltip(); // 0x000000018099E150-0x000000018099E480
	private void PlayCardShowFx(); // 0x000000018099E480-0x000000018099E7A0
	private void StartCardPulse(); // 0x000000018099E7A0-0x000000018099EAE0
	private void StopCardFx(); // 0x000000018099EAE0-0x000000018099ED10
	private void PlayCardPunch(); // 0x000000018099ED10-0x000000018099F040
	private static string SkillCardCostLine(PetUserDTO pet); // 0x000000018099F040-0x000000018099F2C0
	private void LoadPetSkillCard(int skillCardId, string description, string cardName, PetUserDTO pet = null); // 0x000000018099F2C0-0x000000018099FC00
	[IteratorStateMachine(typeof(_AnimateTextFlyUp_d__274))]
	private IEnumerator AnimateTextFlyUp(UnityEngine.UI.Text textComponent, float duration = 1f /* Metadata: 0x005F1799 */, float moveDistance = 50f /* Metadata: 0x005F179D */); // 0x000000018099FC00-0x000000018099FCC0
	private void OnDestroy(); // 0x000000018099FCC0-0x00000001809A04B0
	private void CleanupPetUIComplete(GameObject petUI); // 0x00000001809A04B0-0x00000001809A0950
	private void OnDisable(); // 0x00000001809A0950-0x00000001809A1190
	[CompilerGenerated]
	private void _LoadPetStars_b__123_0(PetStarListResponse resp); // 0x00000001809A1900-0x00000001809A1AD0
	[CompilerGenerated]
	private void _SetupButtons_b__130_0(); // 0x00000001809A1AD0-0x00000001809A1B20
	[CompilerGenerated]
	private void _SetupButtons_b__130_1(); // 0x00000001809A1B20-0x00000001809A1B70
	[CompilerGenerated]
	private void _SetupButtons_b__130_2(); // 0x00000001809A1B70-0x00000001809A1BC0
	[CompilerGenerated]
	private void _SetupButtons_b__130_3(); // 0x00000001809A1BC0-0x00000001809A1C10
	[CompilerGenerated]
	private void _SetupButtons_b__130_4(); // 0x00000001809A1C10-0x00000001809A1C60
	[CompilerGenerated]
	private bool _ReloadDataAfterUpgrade_b__249_0(PetUserDTO p); // 0x00000001809A1C60-0x00000001809A1C90
	[CompilerGenerated]
	private void _PlayCardPunch_b__271_0(); // 0x00000001809A1C90-0x00000001809A1E20
}

