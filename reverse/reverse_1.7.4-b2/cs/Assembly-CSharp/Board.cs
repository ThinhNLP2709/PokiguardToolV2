/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class Board : MonoBehaviour // TypeDefIndex: 1840
{
	// Fields
	public GameObject bossTimeoutPanel; // 0x20
	public UnityEngine.UI.Text bossTimeoutText; // 0x28
	public Button bossTimeoutButton; // 0x30
	public UnityEngine.UI.Text txtBossCountdown; // 0x38
	internal DateTime bossEndTime; // 0x40
	internal DateTime bossEndTimeUtc; // 0x48
	internal bool useUtcCountdown; // 0x50
	internal long serverClockOffsetMs; // 0x58
	internal bool isBossTimeValid; // 0x60
	internal bool isBossTimeout; // 0x61
	internal Coroutine bossCountdownCoroutine; // 0x68
	public GameObject[] dots; // 0x70
	public GameState currentState; // 0x78
	public GameObject destructionEntryPrefab; // 0x80
	public int width; // 0x88
	public int height; // 0x8C
	public int offSet; // 0x90
	[Header("Dot grid / DotsArea")]
	[SerializeField]
	[Tooltip("V\u1ECB tr\u00ED \u00F4 t\u1EEB slot transforms (index = row*width+col).")]
	private bool useSlotPositions; // 0x94
	[SerializeField]
	private Transform slotsRoot; // 0x98
	[SerializeField]
	private bool autoSyncSlotsFromRoot; // 0xA0
	[SerializeField]
	private List<Transform> slots; // 0xA8
	[SerializeField]
	private float dotYOffset; // 0xB0
	[SerializeField]
	[Tooltip("Khi kh\u00F4ng d\u00F9ng slot: c\u0103n l\u01B0\u1EDBi quanh t\u00E2m Board/DotsArea.")]
	private bool centerBoardOnTransform; // 0xB4
	[SerializeField]
	private Vector2 cellSpacing; // 0xB8
	[SerializeField]
	[Tooltip("B\u1EADt: chia \u0111\u1EC1u \u00F4 theo rect DotsArea. T\u1EAFt: d\u00F9ng cellSpacing / c\u0103n t\u00E2m \u2014 dot v\u1EABn spawn d\u01B0\u1EDBi DotsPlayfield n\u1EBFu b\u1EADt Use Dots Playfield.")]
	private bool useEvenSpacingFromDotsArea; // 0xC0
	[FormerlySerializedAs("dotGridPadding")]
	[SerializeField]
	private float dotsAreaPadding; // 0xC4
	[SerializeField]
	private float dotsAreaExtraFrameGap; // 0xC8
	[SerializeField]
	private bool insetGridFromSlicedImageBorder; // 0xCC
	[SerializeField]
	private bool autoScaleDotsToFitGridCells; // 0xCD
	[Range(0f, 0.45f)]
	[SerializeField]
	private float dotVisualFillPadding; // 0xD0
	[SerializeField]
	[Tooltip("T\u1EA1o child DotsPlayfield d\u01B0\u1EDBi DotsArea (Board \u2192 DotsArea \u2192 DotsPlayfield \u2192 dot). Kh\u00F4ng ph\u1EE5 thu\u1ED9c Use Even Spacing \u2014 khi t\u1EAFt Even Spacing, playfield full stretch trong DotsArea.")]
	private bool useDotsPlayfieldUnderDotsArea; // 0xD4
	[SerializeField]
	private bool clipDotsInsidePlayfield; // 0xD5
	[FormerlySerializedAs("dotsRoot")]
	[Header("Dots hierarchy")]
	[SerializeField]
	[Tooltip("T\u00F9y ch\u1ECDn: k\u00E9o object cha ch\u1EE9a dot. \u0110\u1EC3 tr\u1ED1ng ho\u1EB7c k\u00E9o nh\u1EA7m ch\u00EDnh Board: t\u1EF1 t\u1EA1o child \"DotsArea\" d\u01B0\u1EDBi Board \u0111\u1EC3 spawn + \u1EA9n/hi\u1EC7n an to\u00E0n.")]
	public Transform dotsParent; // 0xD8
	private Transform runtimeDotsParent; // 0xE0
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x0068D967
	private Transform runtimeDotsPlayfield; // 0xE8
	[SerializeField]
	private Sprite dotsAreaBackgroundSprite; // 0xF0
	[SerializeField]
	private float spawnLiftY; // 0xF8
	private Vector2 _cachedDotPrefabSpriteSize; // 0xFC
	private bool _cachedDotPrefabSpriteSizeValid; // 0x104
	private Vector3 _dotPrefabRootScale; // 0x108
	private Vector2 _lastDotsShellRectSize; // 0x114
	private float _lastCanvasForceUnscaledTime; // 0x11C
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x0068D975
	internal int destroyedCount; // 0x120
	internal bool isDestroyingMatches; // 0x124
	public bool hasDestroyedThisTurn; // 0x125
	public bool playerMovedThisTurn; // 0x126
	public bool hasMega1BuffThisTurn; // 0x127
	public bool hasMega2BuffThisTurn; // 0x128
	internal bool isMega2PanelOpen; // 0x129
	[HideInInspector]
	public CardUI activeMega2CardUI; // 0x130
	internal bool isMegaIcarusPanelOpen; // 0x138
	[HideInInspector]
	public CardUI activeMegaIcarusCardUI; // 0x140
	internal BackGroundTitle[,] allTiles; // 0x148
	public GameObject[,] allDots; // 0x150
	internal FindMatches findMaches; // 0x158
	internal Dictionary<string, int> destroyedCountByTag; // 0x160
	public Active active; // 0x168
	internal Coroutine stableBoardCheckCoroutine; // 0x170
	internal Coroutine cascadeCoroutine; // 0x178
	internal bool isCascadeRunning; // 0x180
	private bool cascadeRerunPending; // 0x181
	private int cascadeRerunCount; // 0x184
	private float cascadeStartedRealtime; // 0x188
	private const float CASCADE_WATCHDOG_SECONDS = 12f; // Metadata: 0x0068D979
	private int stableHealAttempts; // 0x18C
	public GameObject destructionCountPanel; // 0x190
	internal Dictionary<string, Sprite> itemIcons; // 0x198
	public Sprite[] pieces; // 0x1A0
	public GameObject loading; // 0x1A8
	public Api api; // 0x1B0
	public NotifyWin notifyWin; // 0x1B8
	public GameObject load; // 0x1C0
	public bool enableAutoMove; // 0x1C8
	public GameObject imgTurnE; // 0x1D0
	public GameObject imgTurnP; // 0x1D8
	internal bool isProcessingUI; // 0x1E0
	internal bool isAutoMoveInProgress; // 0x1E1
	public GameObject panelResult; // 0x1E8
	public GameObject resultBackground; // 0x1F0
	public GameObject rewards; // 0x1F8
	public GameObject anmtRW; // 0x200
	public GameObject listReward; // 0x208
	public GameObject itemRewardStone; // 0x210
	public GameObject itemRewardPet; // 0x218
	public GameObject itemRewardCT; // 0x220
	public GameObject itemRewardGold; // 0x228
	public GameObject itemRewardEXP; // 0x230
	[Header("Special Drop Prefabs (Coop Reward)")]
	public GameObject itemE1RW; // 0x238
	public GameObject itemE2RW; // 0x240
	public GameObject itemE3RW; // 0x248
	public GameObject itemEItem1RW; // 0x250
	public GameObject itemEItem2RW; // 0x258
	public GameObject itemEItem3RW; // 0x260
	public GameObject itemEItem4RW; // 0x268
	public GameObject itemCrystalRW; // 0x270
	public GameObject itemStoneCardRW; // 0x278
	[Header("Tower Reward Prefabs (Th\u00E1p Th\u1EED Luy\u1EC7n)")]
	public GameObject itemRubyRW; // 0x280
	public GameObject itemEnergyRW; // 0x288
	public GameObject itemWhiteStarRW; // 0x290
	public GameObject itemBlueStarRW; // 0x298
	public GameObject itemRedStarRW; // 0x2A0
	public UnityEngine.UI.Text txtResultTitle; // 0x2A8
	public Button btnGet; // 0x2B0
	public Sprite[] fireStones; // 0x2B8
	public Sprite[] waterStones; // 0x2C0
	public Sprite[] earthStones; // 0x2C8
	public Sprite[] windStones; // 0x2D0
	public Sprite[] electricStones; // 0x2D8
	internal bool isGameOver; // 0x2E0
	internal readonly HashSet<int> _leftActorNumbers; // 0x2E8
	private static readonly Color GRAY_TINT; // 0x00
	internal string enemyPetElement; // 0x2F0
	internal int enemyPetId; // 0x2F8
	internal int currentCount; // 0x2FC
	internal int requestPass; // 0x300
	internal float lastAutoMoveTime; // 0x304
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x0068D97D
	internal bool isBossBattle; // 0x308
	internal bool isTowerBattle; // 0x309
	private TowerTurnHud _towerHud; // 0x310
	private bool _towerHudHooked; // 0x318
	public GameObject cardPrefab; // 0x320
	public Transform cardContainer; // 0x328
	public int maxCardsInHand; // 0x330
	public float cardSpacing; // 0x334
	public float cardYPosition; // 0x338
	public float cardAnimDuration; // 0x33C
	internal List<CardData> selectedCards; // 0x340
	internal List<GameObject> cardsInHand; // 0x348
	public CardData cardData; // 0x350
	internal int HOTTURN; // 0x358
	internal int SUBHOTTURN; // 0x35C
	public GameObject energyWarningPanel; // 0x360
	public UnityEngine.UI.Text energyWarningText; // 0x368
	public Button energyWarningButton; // 0x370
	internal bool hasShownEnergyWarning; // 0x378
	internal int lastCheckedEnergy; // 0x37C
	internal AudioSettingsManager audioSettingsManager; // 0x380
	public Image boardBackground; // 0x388
	internal bool isBoardReady; // 0x390
	internal bool isUsingLegendCard; // 0x391
	internal float legendDamageMultiplier; // 0x394
	internal bool isUsingMega; // 0x398
	internal int currentDamageMultiplier; // 0x39C
	public GameObject imgPDef; // 0x3A0
	public GameObject imgEDef; // 0x3A8
	internal bool isResuming; // 0x3B0
	internal Coroutine resumeSyncCoroutine; // 0x3B8
	[CompilerGenerated]
	private static Board _Instance_k__BackingField; // 0x10
	private DotPool _dotPool; // 0x3C0
	private Transform _dotPoolRoot; // 0x3C8
	private const string DotPoolRootName = "DotPool"; // Metadata: 0x0068D981
	private RectTransform _cachedPlayfieldMaskOwner; // 0x3D0
	private RectMask2D _cachedPlayfieldMask; // 0x3D8
	private RectTransform _cachedDotsAreaFrameImageOwner; // 0x3E0
	private Image _cachedDotsAreaFrameImage; // 0x3E8
	private int _gridLayoutCacheFrame; // 0x3F0
	private bool _gridLayoutCacheOk; // 0x3F4
	private RectTransform _gridLayoutCacheArea; // 0x3F8
	private float _gridLayoutCacheCellW; // 0x400
	private float _gridLayoutCacheCellH; // 0x404
	private Rect _gridLayoutCacheRect; // 0x408
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x0068D989
	private const float DotSweepIntervalSec = 0.25f; // Metadata: 0x0068D98D
	private float _lastDotSweepAt; // 0x418
	private float _lastAppliedDotScaleU; // 0x41C
	private bool _dotScaleDirty; // 0x420
	private bool _lastInputOpen; // 0x421
	[Header("T\u1ED1c \u0111\u1ED9 x\u1EED l\u00FD vi\u00EAn (HandleUI)")]
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD m\u1ED7i lo\u1EA1i vi\u00EAn th\u01B0\u1EDDng (sau animation damage).")]
	private float handleUI_waitPerNormalGem; // 0x424
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD vi\u00EAn v\u00E0ng (s).")]
	private float handleUI_waitPerVangGem; // 0x428
	[SerializeField]
	[Tooltip("Kho\u1EA3ng ngh\u1EC9 ng\u1EAFn sau c\u1EADp nh\u1EADt slider, tr\u01B0\u1EDBc b\u01B0\u1EDBc ti\u1EBFp.")]
	private float handleUI_pauseAfterSliderNormal; // 0x42C
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; // 0x430
	[Header("Pet animation duration cho vi\u00EAn ki\u1EBFm (vang Dot)")]
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation Attack b\u00ECnh th\u01B0\u1EDDng (key=1). Ch\u1EDD \u0111\u1EE7 tr\u01B0\u1EDBc khi reset animator.")]
	private float vangAttackAnimDuration; // 0x434
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation AttackPower khi \u0111\u1EE7 n\u1ED9 (key=2).")]
	private float vangAttackPowerAnimDuration; // 0x438
	[SerializeField]
	private float destructionEntryPulseSeconds; // 0x43C
	[SerializeField]
	private float destructionEntryShrinkSeconds; // 0x440
	private Coroutine _bossDeadlineCo; // 0x448
	private static Font _multiplierFont; // 0x18
	private static readonly Color MultiplierOutlineColor; // 0x20
	private static readonly Color MultiplierMainColor; // 0x30
	private static readonly string[] DestroyDisplayOrder; // 0x40
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x450
	private readonly List<GameObject> _destroyEntryPool; // 0x458
	private bool _rewardPanelBuilt; // 0x460
	private bool _weaponRewardShown; // 0x461
	private bool _petShardRewardShown; // 0x462
	private bool _lateRewardHooked; // 0x463
	private const float REWARD_REVEAL_STAGGER = 0.12f; // Metadata: 0x0068D991
	private const float REWARD_REVEAL_DURATION = 0.35f; // Metadata: 0x0068D995
	private const string RANK_ICON_SHEET = "Image/Common/common_popup_ui"; // Metadata: 0x0068D999
	private const string RANK_ICON_NAME = "common_popup_ui_77"; // Metadata: 0x0068D9B6
	private static Sprite _rankIconCache; // 0x48
	private static bool _rankIconLooked; // 0x50
	[SerializeField]
	private float mega1AnimDuration; // 0x464
	private Coroutine _mega1AnimCoroutine; // 0x468
	internal bool isMega1PanelOpen; // 0x470
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x0068D9C9
	private Coroutine _megaIcarusAnimCoroutine; // 0x478
	private SpriteRenderer _megaIcarusFxHost; // 0x480
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x0068D9D8
	private readonly List<GameObject> _megaIcarusMarks; // 0x488
	private readonly List<GameObject> _megaIcarusHiddenLabels; // 0x490
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x0068D9E7
	private Coroutine _galaxyScanCoroutine; // 0x498
	private Dot[,] _dotComps; // 0x4A0
	private GameObject[,] _dotCompOwners; // 0x4A8
	[CompilerGenerated]
	private bool _DotsHiddenForPresentation_k__BackingField; // 0x4B0
	public const long FUSION_CARD_ID = -777; // Metadata: 0x0068D9F2
	private static readonly int[][] SwapDirections; // 0x58
	private HashSet<int> _shownExitNoticeActors; // 0x4B8

	// Properties
	public GameObject ResolvedDotsArea { get; } // 0x00000001806AA690-0x00000001806AA6A0 
	public bool IsBoardReady { get; } // 0x0000000180540640-0x0000000180540650 
	public static Board Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806BB620-0x00000001806BB670 0x00000001806BB7F0-0x00000001806BB990
	internal DotPool Dots { get; } // 0x00000001806BB300-0x00000001806BB5A0 
	internal float HandleUIWaitNormal { get; } // 0x00000001806BB5E0-0x00000001806BB600 
	internal float HandleUIWaitVang { get; } // 0x00000001806BB600-0x00000001806BB620 
	internal float HandleUIPauseNormal { get; } // 0x00000001806BB5A0-0x00000001806BB5C0 
	internal float HandleUIPauseVang { get; } // 0x00000001806BB5C0-0x00000001806BB5E0 
	internal float VangAttackAnimDuration { get; } // 0x00000001806BB7C0-0x00000001806BB7D0 
	internal float VangAttackPowerAnimDuration { get; } // 0x00000001806BB7D0-0x00000001806BB7E0 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x00000001806BB670-0x00000001806BB7C0 
	internal bool DotsHiddenForPresentation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806BB2F0-0x00000001806BB300 0x00000001806BB7E0-0x00000001806BB7F0

	// Nested types
	[Serializable]
	public class PetRewardRequest // TypeDefIndex: 1841
	{
		// Fields
		public int petId; // 0x10
		public bool victory; // 0x14

		// Constructors
		public PetRewardRequest(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class PetRewardResponse // TypeDefIndex: 1842
	{
		// Fields
		public int petId; // 0x10
		public int levelDisplay; // 0x14
		public int requestAttack; // 0x18
		public int expGain; // 0x1C
		public int? goldBonus; // 0x20
		public List<StoneRewardInfo> stoneRewards; // 0x28
		public bool receivedPet; // 0x30
		public int newLevel; // 0x34
		public int currentExp; // 0x38
		public int expToNextLevel; // 0x3C

		// Constructors
		public PetRewardResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class StoneRewardInfo // TypeDefIndex: 1843
	{
		// Fields
		public string element; // 0x10
		public int level; // 0x18
		public int quantity; // 0x1C

		// Constructors
		public StoneRewardInfo(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class ApiResponse<T> // TypeDefIndex: 1844
	{
		// Fields
		public bool success;
		public string message;
		public T data;

		// Constructors
		public ApiResponse();
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1845
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__321_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__324_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__324_1; // 0x18
		public static Func<StoneRewardInfo, int> __9__387_0; // 0x20
		public static Func<StoneRewardInfo, string> __9__387_1; // 0x28
		public static Func<GameObject, bool> __9__412_0; // 0x30
		public static Func<Vector2Int, int> __9__414_0; // 0x38
		public static Func<Vector2Int, int> __9__414_1; // 0x40
		public static Func<int, int> __9__414_2; // 0x48
		public static Func<Vector2Int, int> __9__414_3; // 0x50
		public static Func<Vector2Int, int> __9__414_4; // 0x58
		public static Func<int, int> __9__414_5; // 0x60
		public static Func<CardData, bool> __9__417_0; // 0x68

		// Constructors
		static __c(); // 0x00000001806E68B0-0x00000001806E6920
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _displayDestroy_b__321_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x00000001806E5B20-0x00000001806E5BD0
		internal int _DisplayCoopReward_b__324_0(StoneRewardInfo s); // 0x0000000180425510-0x0000000180425530
		internal string _DisplayCoopReward_b__324_1(StoneRewardInfo s); // 0x000000018065AD90-0x000000018065ADB0
		internal int _DisplayRewardFromServer_b__387_0(StoneRewardInfo s); // 0x0000000180425510-0x0000000180425530
		internal string _DisplayRewardFromServer_b__387_1(StoneRewardInfo s); // 0x000000018065AD90-0x000000018065ADB0
		internal bool _CalculatePotentialVangDotDestruction_b__412_0(GameObject g); // 0x00000001806E5A80-0x00000001806E5B10
		internal int _ComputeBossSwordLineMetrics_b__414_0(Vector2Int p); // 0x00000001806E5B10-0x00000001806E5B20
		internal int _ComputeBossSwordLineMetrics_b__414_1(Vector2Int p); // 0x0000000180425500-0x0000000180425510
		internal int _ComputeBossSwordLineMetrics_b__414_2(int v); // 0x0000000180425500-0x0000000180425510
		internal int _ComputeBossSwordLineMetrics_b__414_3(Vector2Int p); // 0x0000000180425500-0x0000000180425510
		internal int _ComputeBossSwordLineMetrics_b__414_4(Vector2Int p); // 0x00000001806E5B10-0x00000001806E5B20
		internal int _ComputeBossSwordLineMetrics_b__414_5(int v); // 0x0000000180425500-0x0000000180425510
		internal bool _LoadSelectedCards_b__417_0(CardData c); // 0x0000000180620760-0x0000000180620770
	}

	[CompilerGenerated]
	private struct __c__DisplayClass231_0 // TypeDefIndex: 1846
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass253_0 // TypeDefIndex: 1847
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass253_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x00000001806E5FC0-0x00000001806E6090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass323_0 // TypeDefIndex: 1848
	{
		// Fields
		public Animator animator; // 0x10
		public float t; // 0x18
		public float timeout; // 0x1C

		// Constructors
		public __c__DisplayClass323_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _ShowGameResultIntegrated_b__2(); // 0x00000001806E6570-0x00000001806E6610
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass324_0 // TypeDefIndex: 1849
	{
		// Fields
		public GameObject petReward; // 0x10

		// Constructors
		public __c__DisplayClass324_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _DisplayCoopReward_b__2(); // 0x00000001806E6610-0x00000001806E66F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass337_0 // TypeDefIndex: 1850
	{
		// Fields
		public Transform cell; // 0x10

		// Constructors
		public __c__DisplayClass337_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SpawnTowerRewards_b__0(); // 0x00000001806E6720-0x00000001806E6810
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass388_0 // TypeDefIndex: 1851
	{
		// Fields
		public int level; // 0x10
		public Board __4__this; // 0x18

		// Constructors
		public __c__DisplayClass388_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x00000001806E6850-0x00000001806E68B0
	}

	[CompilerGenerated]
	private sealed class _AnimateDotsWaterfall_d__299 : IEnumerator<object> // TypeDefIndex: 1852
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private float _maxDur_5__2; // 0x28
		private float _maxColDelay_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnimateDotsWaterfall_d__299(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DAB10-0x00000001806DAE70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DAE70-0x00000001806DAEB0
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__360 : IEnumerator<object> // TypeDefIndex: 1853
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__360(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DAEB0-0x00000001806DAF90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DAF90-0x00000001806DAFD0
	}

	[CompilerGenerated]
	private sealed class _BossDeadlineCountdownCoroutine_d__265 : IEnumerator<object> // TypeDefIndex: 1854
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private bool _timeoutToastShown_5__2; // 0x28
		private WaitForSecondsRealtime _wait_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BossDeadlineCountdownCoroutine_d__265(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806DAFD0-0x00000001806DB1C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DB1C0-0x00000001806DB200
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__316 : IEnumerator<object> // TypeDefIndex: 1855
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private float _checkInterval_5__2; // 0x28
		private float _maxWaitTime_5__3; // 0x2C
		private float _elapsedTime_5__4; // 0x30
		private float _unstableNoCascadeTime_5__5; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__316(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DB200-0x00000001806DB4A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DB4A0-0x00000001806DB4E0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__253 : IEnumerator<object> // TypeDefIndex: 1856
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass253_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__253(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806DB4E0-0x00000001806DBA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DBA10-0x00000001806DBA50
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__252 : IEnumerator<object> // TypeDefIndex: 1857
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Board __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__252(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DBA50-0x00000001806DBB50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DBB50-0x00000001806DBB90
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__297 : IEnumerator<object> // TypeDefIndex: 1858
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__297(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DBB90-0x00000001806DC830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DC830-0x00000001806DC870
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__306 : IEnumerator<object> // TypeDefIndex: 1859
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__306(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DC870-0x00000001806DCB80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DCB80-0x00000001806DCBC0
	}

	[CompilerGenerated]
	private sealed class _DisplayCoopReward_d__324 : IEnumerator<object> // TypeDefIndex: 1860
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int gold; // 0x28
		public int exp; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCoopReward_d__324(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DCCC0-0x00000001806DEB40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806DEB40-0x00000001806DEB80
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__387 : IEnumerator<object> // TypeDefIndex: 1861
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__387(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806DEB80-0x00000001806E0120
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E0120-0x00000001806E0160
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__398 : IEnumerator<object> // TypeDefIndex: 1862
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CanvasGroup canvasGroup; // 0x20
		public float duration; // 0x28
		private float _elapsedTime_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__398(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E0160-0x00000001806E03B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E03B0-0x00000001806E03F0
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__384 : IEnumerator<object> // TypeDefIndex: 1863
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float duration; // 0x20
		public Board __4__this; // 0x28
		public string tagToHighlight; // 0x30
		private float _perColumn_5__2; // 0x38
		private List<Transform> _faded_5__3; // 0x40
		private int _c_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__384(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001806E03F0-0x00000001806E0AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E0AF0-0x00000001806E0B30
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__280 : IEnumerator<object> // TypeDefIndex: 1864
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__280(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E0C00-0x00000001806E0E90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E0E90-0x00000001806E0ED0
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__254 : IEnumerator<object> // TypeDefIndex: 1865
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public WsCombatBatch batch; // 0x28
		public bool bossSide; // 0x30
		public bool wasFullPower; // 0x31
		private Dictionary<string, int> _byTag_5__2; // 0x38
		private bool _hasTags_5__3; // 0x40
		private float _waitFree_5__4; // 0x44
		private bool _showPanel_5__5; // 0x48
		private int _boardDot_5__6; // 0x4C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleUIWs_d__254(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001806E0ED0-0x00000001806E2000
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E2000-0x00000001806E2040
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__410 : IEnumerator<object> // TypeDefIndex: 1866
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private GameObject _root_5__2; // 0x28
		private GameObject[,] __7__wrap2; // 0x30
		private int __7__wrap3; // 0x38
		private int __7__wrap4; // 0x3C
		private int __7__wrap5; // 0x40
		private int __7__wrap6; // 0x44
		private GameObject _item_5__8; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideAllItemsEnd_d__410(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180657910-0x0000000180657960
		private bool MoveNext(); // 0x00000001806E2040-0x00000001806E2410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E2410-0x00000001806E2450
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__428 : IEnumerator<object> // TypeDefIndex: 1867
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__428(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E2450-0x00000001806E2670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E2670-0x00000001806E26B0
	}

	[CompilerGenerated]
	private sealed class _ResetBoardWhenNoMoves_d__436 : IEnumerator<object> // TypeDefIndex: 1868
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResetBoardWhenNoMoves_d__436(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E2EC0-0x00000001806E3800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E3800-0x00000001806E3840
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__322 : IEnumerator<object> // TypeDefIndex: 1869
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private MatchService _msvc_5__2; // 0x28
		private float _wsTimeout_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__322(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001806E3950-0x00000001806E3CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E3CF0-0x00000001806E3D30
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__323 : IEnumerator<object> // TypeDefIndex: 1870
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public bool serverAuthoritative; // 0x28
		public bool playerWon; // 0x29
		private long _earlyEnemyPetId_5__2; // 0x30
		private Coroutine _submitCo_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__323(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001806E4910-0x00000001806E5990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E5990-0x00000001806E59D0
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__272 : IEnumerator<object> // TypeDefIndex: 1871
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int currentTurnActor; // 0x20
		public Board __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__272(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E69D0-0x00000001806E7100
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E7100-0x00000001806E7140
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__300 : IEnumerator<object> // TypeDefIndex: 1872
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__300(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E7140-0x00000001806E7480
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E7480-0x00000001806E74C0
	}

	// Constructors
	public Board(); // 0x00000001806BA4E0-0x00000001806BAA90
	static Board(); // 0x00000001806BA130-0x00000001806BA4E0

	// Methods
	internal void Awake(); // 0x000000018069E200-0x000000018069E730
	private void OnEnable(); // 0x00000001806AFA80-0x00000001806AFAA0
	private void Start(); // 0x00000001806B82B0-0x00000001806B8590
	private void OnValidate(); // 0x00000001806B0130-0x00000001806B02F0
	private bool HasExplicitDotsParent(); // 0x00000001806AB1F0-0x00000001806AB280
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x00000001806AED70-0x00000001806AF610
	private void EnsureRuntimeDotsParent(); // 0x00000001806A8920-0x00000001806A8B30
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x00000001806B1310-0x00000001806B1510
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x000000018069C9C0-0x000000018069CCA0
	private Transform GetDotsAreaShellTransform(); // 0x00000001806AA560-0x00000001806AA5A0
	private Transform GetDotsParent(); // 0x00000001806AA5B0-0x00000001806AA690
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x00000001806A7610-0x00000001806A76D0
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x00000001806A8E50-0x00000001806A9110
	public Transform GetDotsParentTransform(); // 0x00000001806AA5A0-0x00000001806AA5B0
	internal bool TryTakePooledDot(string tag, Vector2 worldPos, out GameObject go); // 0x00000001806B90C0-0x00000001806B9150
	internal void ReleaseDot(GameObject dot); // 0x00000001806B0C80-0x00000001806B0D20
	internal void ClearDotPool(); // 0x00000001806A2650-0x00000001806A2670
	public void PrepareDotsAreaForCoopSync(); // 0x00000001806B04C0-0x00000001806B0570
	internal bool HasFullDotGridSpawned(); // 0x00000001806AB280-0x00000001806AB3C0
	public void ApplyCoopBoardVisualFinishAfterNetworkSync(); // 0x000000018069D0C0-0x000000018069D1E0
	private GameObject ResolveDotsAreaRoot(); // 0x00000001806B1760-0x00000001806B1810
	private GameObject GetDotsVisibilityRoot(); // 0x00000001806AA690-0x00000001806AA6A0
	private Vector3 GetGridOriginWorld(); // 0x00000001806AA6A0-0x00000001806AA7A0
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x00000001806A76D0-0x00000001806A7A60
	private void UpdateDotsPlayfieldLayout(); // 0x00000001806B9520-0x00000001806B9970
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x00000001805293E0-0x00000001805296F0
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x00000001806AA870-0x00000001806AA980
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x00000001806AA170-0x00000001806AA240
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x00000001806AA240-0x00000001806AA560
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x000000018069DFB0-0x000000018069E190
	private void InvalidateGridLayoutCache(); // 0x00000001806AD2F0-0x00000001806AD340
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x00000001806B8FC0-0x00000001806B90C0
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x00000001806A3CD0-0x00000001806A4180
	private void EnsureDotPrefabSpriteCache(); // 0x00000001806A7100-0x00000001806A73A0
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x00000001806B8F70-0x00000001806B8FC0
	private void LateUpdate(); // 0x00000001806AD900-0x00000001806ADBE0
	internal void MarkDotScaleDirty(); // 0x00000001806AE820-0x00000001806AE830
	private void Update(); // 0x00000001806B99F0-0x00000001806B9BC0
	internal void WakeAllDots(); // 0x00000001806B9C30-0x00000001806B9D30
	private void WakeDriftedDots(); // 0x00000001806B9D30-0x00000001806B9E80
	private void ApplyDotScaleToFitGridCells(); // 0x000000018069D2F0-0x000000018069DA80
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x00000001806A9A60-0x00000001806A9E90
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x00000001806AA110-0x00000001806AA170
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x00000001806AA0A0-0x00000001806AA110
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x00000001806AA110-0x00000001806AA170
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x00000001806AA010-0x00000001806AA0A0
	public Vector2 GetColyseusSpawnWorldPositionAboveBoard(int column); // 0x00000001806A9E90-0x00000001806A9F60
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x00000001806AA9B0-0x00000001806AAA60
	private void ApplyDotsAreaBackgroundSprite(); // 0x000000018069DA80-0x000000018069DBF0
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x00000001806B21A0-0x00000001806B22A0
	public void RefreshDotsAreaBackgroundVisible(); // 0x00000001806B0C70-0x00000001806B0C80
	private void EnsureDotsAreaLayoutAndBackground(); // 0x00000001806A73A0-0x00000001806A7610
	private void ReparentStrayDotsIntoPlayfield(); // 0x00000001806B1050-0x00000001806B1310
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__252))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x00000001806A4210-0x00000001806A42B0
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__253))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x00000001806A4180-0x00000001806A4210
	[IteratorStateMachine(typeof(_HandleUIWs_d__254))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, bool bossSide, bool wasFullPower); // 0x00000001806AB130-0x00000001806AB1F0
	public bool IsPlayerAllowedToMove(); // 0x00000001806AD340-0x00000001806AD4C0
	public void EnsureBoardVisible(); // 0x00000001806A6AB0-0x00000001806A6C10
	public void OpenInputForLocalTurnOnly(); // 0x00000001806B02F0-0x00000001806B0460
	private void HandleTurnStart(int entityIndex); // 0x00000001802EB6C0-0x00000001802EB6D0
	internal void HandleTurnEnd(); // 0x00000001806AB080-0x00000001806AB130
	private void EnsureBossCountdownText(); // 0x00000001806A6C10-0x00000001806A7100
	private void EnsureTowerHud(); // 0x00000001806A8B30-0x00000001806A8E50
	private void HandleTowerTurnsChanged(int left); // 0x00000001806AAF30-0x00000001806AB080
	private void ReleaseTowerHud(); // 0x00000001806B0D20-0x00000001806B0F50
	[IteratorStateMachine(typeof(_BossDeadlineCountdownCoroutine_d__265))]
	private IEnumerator BossDeadlineCountdownCoroutine(); // 0x000000018069E730-0x000000018069E7A0
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x00000001806B9330-0x00000001806B9520
	public void ReturnToMenuSafely(); // 0x00000001806B1920-0x00000001806B1B10
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x000000018069E7A0-0x000000018069EC10
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x000000018069FD80-0x00000001806A0260
	public void LoadGroupBackground(); // 0x00000001806AE3E0-0x00000001806AE5D0
	public void OnTurnStartNotify(int actorNumber); // 0x00000001806AFAD0-0x00000001806B0130
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__272))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x00000001806B9970-0x00000001806B99F0
	internal void LoadAudioSettings(); // 0x00000001806AE030-0x00000001806AE1A0
	private int ResolveAuthoritativeEnemyPetId(); // 0x00000001806B1630-0x00000001806B1760
	public void InitializeCards(); // 0x00000001806AC8A0-0x00000001806AD2F0
	private bool CardsHiddenThisMatch(); // 0x00000001806A0650-0x00000001806A07A0
	public void OnCardDataReady(CardData data); // 0x00000001806AF6B0-0x00000001806AF710
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x00000001806A5460-0x00000001806A59F0
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x000000018069FAD0-0x000000018069FD80
	[IteratorStateMachine(typeof(_HandleNetworkError_d__280))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x00000001806AAEC0-0x00000001806AAF30
	public int CalculateTrapPotential(int x, int y, string tag); // 0x000000018069F400-0x000000018069FAD0
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x00000001806B48E0-0x00000001806B4DA0
	public int GetDotMultiplier(GameObject dot); // 0x00000001806A9F60-0x00000001806AA010
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x000000018069EF50-0x000000018069F400
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x00000001806A2730-0x00000001806A3030
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x00000001806AD4C0-0x00000001806AD900
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x00000001806B4DA0-0x00000001806B5590
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x00000001806B45A0-0x00000001806B48E0
	public int CountPlayerVangOpportunities(string[,] board); // 0x00000001806A42B0-0x00000001806A43E0
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x00000001806A0260-0x00000001806A0650
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x00000001806A0DD0-0x00000001806A0FF0
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x0068D95D */); // 0x00000001806B5590-0x00000001806B5D60
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x00000001806A0920-0x00000001806A0D60
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x00000001806A13F0-0x00000001806A19C0
	public bool MatchesAt(int column, int row, GameObject piece); // 0x00000001806AE830-0x00000001806AEBF0
	internal void DestroyMatchesAt(int column, int row); // 0x00000001806A59F0-0x00000001806A5D70
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__297))]
	internal IEnumerator DecreaseRowCo(); // 0x00000001806A53F0-0x00000001806A5460
	internal void ResetDestroyedCounts(); // 0x00000001806AFAA0-0x00000001806AFAD0
	[IteratorStateMachine(typeof(_AnimateDotsWaterfall_d__299))]
	private IEnumerator AnimateDotsWaterfall(); // 0x000000018069CCA0-0x000000018069CD10
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__300))]
	public IEnumerator WaitAndDestroyMatches(); // 0x00000001806B9BC0-0x00000001806B9C30
	public void DestroyMatches(); // 0x00000001806A5D70-0x00000001806A5EE0
	private void StartCascade(IEnumerator routine); // 0x00000001806B8250-0x00000001806B82B0
	internal void StopCascadePipeline(); // 0x00000001806B8590-0x00000001806B85F0
	internal void DestroyOrphanDotsUnderDotsParent(bool immediate); // 0x00000001806A5FE0-0x00000001806A64F0
	public void DestroyRandomDots(int count); // 0x00000001806A6570-0x00000001806A6600
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__306))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x00000001806A64F0-0x00000001806A6570
	public void RefillBoard(); // 0x00000001806B0B30-0x00000001806B0C70
	private void RefillBoardNonDeterministic(); // 0x00000001806B05B0-0x00000001806B0B30
	private static Font GetMultiplierFont(); // 0x00000001806AA7A0-0x00000001806AA870
	private static Color ParseHexOr(string hex, Color fallback); // 0x00000001806B0460-0x00000001806B04C0
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x00000001806A4D90-0x00000001806A53F0
	public bool MatchesOnBoard(); // 0x00000001806AEBF0-0x00000001806AED70
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__316))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x00000001806A0D60-0x00000001806A0DD0
	private static int DestroyOrderIndexOf(string tag); // 0x00000001806A5EE0-0x00000001806A5FE0
	internal void displayDestroy(); // 0x00000001806BAA90-0x00000001806BB2F0
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__322))]
	internal IEnumerator ResumeAndSyncState(); // 0x00000001806B18B0-0x00000001806B1920
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__323))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool serverAuthoritative = false /* Metadata: 0x0068D95E */); // 0x00000001806B2890-0x00000001806B2930
	[IteratorStateMachine(typeof(_DisplayCoopReward_d__324))]
	internal IEnumerator DisplayCoopReward(int gold, int exp); // 0x00000001806A66B0-0x00000001806A6740
	private void HookLateRewardPush(); // 0x00000001806ABF90-0x00000001806AC0E0
	private void UnhookLateRewardPush(); // 0x00000001806B9230-0x00000001806B9330
	private void HandleLateRewardPush(string matchId); // 0x00000001806AADC0-0x00000001806AAEC0
	private void SpawnPetShardReward(CoopMatchResultHelper.MatchRewardData reward); // 0x00000001806B60E0-0x00000001806B66F0
	private void SpawnWeaponShardReward(int amount); // 0x00000001806B7F60-0x00000001806B8250
	private void SpawnSweepTicketReward(long itemId, int amount, string label); // 0x00000001806B6860-0x00000001806B6CA0
	private void SpawnWeaponReward(WeaponDropDTO drop); // 0x00000001806B7920-0x00000001806B7F60
	private static Image FindRewardIcon(GameObject item); // 0x00000001806A9410-0x00000001806A96C0
	private void SpawnTowerRewards(CoopMatchResultHelper.MatchRewardData reward); // 0x00000001806B7260-0x00000001806B7920
	private void SpawnTowerBundle(TowerGiftBundle g); // 0x00000001806B6CA0-0x00000001806B6E00
	private void SpawnTowerEntry(RewardDisplayHelper.Entry e); // 0x00000001806B6E00-0x00000001806B7260
	private GameObject TowerFrame(string type, out bool exact); // 0x00000001806B8A90-0x00000001806B8F70
	private static string TowerAmountText(RewardDisplayHelper.Entry e); // 0x00000001806B86A0-0x00000001806B8A90
	private GameObject SpawnRewardItem(GameObject prefab, string text); // 0x00000001806B66F0-0x00000001806B6860
	private static void ApplyCtIcon(GameObject item); // 0x000000018069D1E0-0x000000018069D2F0
	private static void ApplyRankIcon(GameObject item); // 0x000000018069DBF0-0x000000018069DFB0
	private void AnimateRewardReveal(GameObject item); // 0x000000018069CD10-0x000000018069CE90
	private float GetRewardRevealTotalSeconds(int itemCount); // 0x00000001806AA980-0x00000001806AA9B0
	private void ShowBtnGetWithAnim(); // 0x00000001806B23B0-0x00000001806B2540
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x0068D95F */); // 0x00000001806B2DB0-0x00000001806B2EE0
	public void HideMega1Animation(); // 0x00000001806ABE00-0x00000001806ABF90
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x0068D960 */); // 0x00000001806B2EE0-0x00000001806B3080
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__360))]
	private IEnumerator AutoHideMega1Animation(); // 0x000000018069E190-0x000000018069E200
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x00000001806B3080-0x00000001806B3460
	public void ClearAllMega2Hints(); // 0x00000001806A1C90-0x00000001806A1E90
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x00000001806A8250-0x00000001806A8920
	private void StopMegaIcarusWorldFx(); // 0x00000001806B85F0-0x00000001806B86A0
	private void RequestHideMegaIcarusWorldFx(); // 0x00000001806B1510-0x00000001806B15C0
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x0068D961 */); // 0x00000001806B3460-0x00000001806B3660
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x00000001806B3D80-0x00000001806B4500
	public void ClearAllMegaIcarusHints(); // 0x00000001806A1E90-0x00000001806A20A0
	public void ShowMegaIcarusMarks(List<Vector3Int> cells); // 0x00000001806B3660-0x00000001806B3D80
	private void HideExistingMultiplierLabel(GameObject dot); // 0x00000001806ABC80-0x00000001806ABE00
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x000000018069C6F0-0x000000018069C9C0
	public void ClearAllMegaIcarusMarks(); // 0x00000001806A20A0-0x00000001806A2320
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x0068D962 */); // 0x00000001806B2540-0x00000001806B2890
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__384))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x00000001806A99C0-0x00000001806A9A60
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x00000001806A7F50-0x00000001806A8250
	public void ClearAllGalaxyHints(); // 0x00000001806A19C0-0x00000001806A1C90
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__387))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x00000001806A6740-0x00000001806A67D0
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x00000001806A49F0-0x00000001806A4D90
	public void ReturnToMenu(); // 0x00000001806B1B10-0x00000001806B1D00
	private void ClearRoomRestoreFlags(); // 0x00000001806A2670-0x00000001806A2730
	public void ReturnToQuangTruongFromBoss(); // 0x00000001806B1D00-0x00000001806B1E10
	private bool PrepareTowerReturn(); // 0x00000001806B0570-0x00000001806B05B0
	internal int CalculateExpByLevel(int level); // 0x000000018052A130-0x000000018052A170
	internal int CalculateTotalStones(int turnCount); // 0x000000018052ADB0-0x000000018052AE40
	internal int RollStoneLevel(int turnCount); // 0x00000001806B1F50-0x00000001806B2190
	internal Sprite GetStoneSprite(string element, int level); // 0x00000001806AAA60-0x00000001806AAC40
	internal bool CheckBoardStable(); // 0x00000001806A07A0-0x00000001806A0920
	[IteratorStateMachine(typeof(_FadeOut_d__398))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x00000001806A9110-0x00000001806A9190
	internal Dot DotCompAt(int x, int y); // 0x00000001806A67D0-0x00000001806A6AB0
	private void SetDotsRenderVisible(bool visible); // 0x00000001806B22A0-0x00000001806B23B0
	private void SnapAllDotsToGrid(); // 0x00000001806B5D60-0x00000001806B60E0
	public void ShowItems(); // 0x00000001806B2930-0x00000001806B2DB0
	public void HideAllItems(); // 0x00000001806AB790-0x00000001806ABC80
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__410))]
	public IEnumerator HideAllItemsEnd(); // 0x00000001806AB720-0x00000001806AB790
	public void ResetMoveCounters(); // 0x00000001806AB080-0x00000001806AB130
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x000000018069EC10-0x000000018069EF50
	private static int LongestConsecutiveSpanOnAxis(List<int> sortedAsc); // 0x00000001806AE750-0x00000001806AE820
	public ValueTuple<int, int, int> ComputeBossSwordLineMetrics(GameObject movedDot, int targetX, int targetY); // 0x00000001806A3030-0x00000001806A3CD0
	private void LoadCardsFromPlayerPrefs(); // 0x00000001806AE1A0-0x00000001806AE3E0
	private void CreateCardHT(CardData cardData); // 0x00000001806A43E0-0x00000001806A46F0
	public void LoadSelectedCards(List<CardData> cards); // 0x00000001806AE5D0-0x00000001806AE750
	private void DisplayCardsOnBoard(); // 0x00000001806A6600-0x00000001806A66B0
	public void EnsureFusionCards(); // 0x00000001806A7A60-0x00000001806A7F50
	private void RemoveFusionCard(); // 0x00000001806B0F50-0x00000001806B1050
	public void AddFusionSkillCard(CardData cardData); // 0x000000018069C3A0-0x000000018069C6F0
	private CardUI FindWiredSkillCardUI(); // 0x00000001806A96C0-0x00000001806A99C0
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x00000001806A46F0-0x00000001806A49F0
	private void ClearCards(); // 0x00000001806A2320-0x00000001806A2650
	public void LeaveMatchAfterGameOver(); // 0x00000001806ADBE0-0x00000001806ADE30
	public void LeaveMatchMidGame(); // 0x00000001806ADEA0-0x00000001806AE030
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__428))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x00000001806ADE30-0x00000001806ADEA0
	private void GoToMainScene(); // 0x00000001806AAC40-0x00000001806AAD10
	private void FastReturnToRoom(); // 0x00000001806A9190-0x00000001806A9410
	internal void ReturnToQuangTruong(); // 0x00000001806B1E10-0x00000001806B1F50
	public bool HasValidMoves(); // 0x00000001806AB420-0x00000001806AB720
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x00000001806B9E80-0x00000001806BA130
	internal bool CheckMatchAt(int col, int row, string tag); // 0x00000001806A0FF0-0x00000001806A13F0
	[IteratorStateMachine(typeof(_ResetBoardWhenNoMoves_d__436))]
	public IEnumerator ResetBoardWhenNoMoves(); // 0x00000001806B15C0-0x00000001806B1630
	public void InitializeCardsClientOnly(); // 0x00000001806AC0E0-0x00000001806AC8A0
	public void SetBoardState(GameState state); // 0x00000001806B2190-0x00000001806B21A0
	public void GrayOutPlayerAvatar(int actorNumber); // 0x00000001806AAD10-0x00000001806AADC0
	public void ShowPlayerExitNotice(string playerName, int actorNumber = 0 /* Metadata: 0x0068D966 */); // 0x00000001806B4500-0x00000001806B45A0
	public void RestorePlayerAvatar(int actorNumber); // 0x00000001806B1810-0x00000001806B18B0
	public bool HasLeftMatch(int actorNumber); // 0x00000001806AB3C0-0x00000001806AB420
	private void ApplyAvatarTintIfDisplayed(int actorNumber, Color tint, bool isLeft); // 0x000000018069CE90-0x000000018069D0C0
	internal void OnMouseDown(); // 0x00000001806AFAA0-0x00000001806AFAD0
	internal void OnDestroy(); // 0x00000001806AF710-0x00000001806AFA80
	internal void OnApplicationQuit(); // 0x00000001806AF610-0x00000001806AF6B0
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_231_0(Transform t, ref __c__DisplayClass231_0 param_000024d5); // 0x00000001806B9150-0x00000001806B9220
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__323_0(); // 0x00000001806B9220-0x00000001806B9230
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__323_1(); // 0x00000001806B9220-0x00000001806B9230
}

