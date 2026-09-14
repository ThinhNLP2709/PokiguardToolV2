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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class Board : MonoBehaviour // TypeDefIndex: 2213
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
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x005F1BE4
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
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x005F1BF2
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
	private const float CASCADE_WATCHDOG_SECONDS = 12f; // Metadata: 0x005F1BF6
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
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x005F1BFA
	internal bool isBossBattle; // 0x308
	internal bool isTowerBattle; // 0x309
	internal bool isGuildBossBattle; // 0x30A
	private Button _raidFightAgainBtn; // 0x310
	private TowerTurnHud _towerHud; // 0x318
	private bool _towerHudHooked; // 0x320
	public GameObject cardPrefab; // 0x328
	public Transform cardContainer; // 0x330
	public int maxCardsInHand; // 0x338
	public float cardSpacing; // 0x33C
	public float cardYPosition; // 0x340
	public float cardAnimDuration; // 0x344
	internal List<CardData> selectedCards; // 0x348
	internal List<GameObject> cardsInHand; // 0x350
	public CardData cardData; // 0x358
	internal int HOTTURN; // 0x360
	internal int SUBHOTTURN; // 0x364
	public GameObject energyWarningPanel; // 0x368
	public UnityEngine.UI.Text energyWarningText; // 0x370
	public Button energyWarningButton; // 0x378
	internal bool hasShownEnergyWarning; // 0x380
	internal int lastCheckedEnergy; // 0x384
	internal AudioSettingsManager audioSettingsManager; // 0x388
	public Image boardBackground; // 0x390
	internal bool isBoardReady; // 0x398
	internal bool isUsingLegendCard; // 0x399
	internal float legendDamageMultiplier; // 0x39C
	internal bool isUsingMega; // 0x3A0
	internal int currentDamageMultiplier; // 0x3A4
	public GameObject imgPDef; // 0x3A8
	public GameObject imgEDef; // 0x3B0
	internal bool isResuming; // 0x3B8
	internal Coroutine resumeSyncCoroutine; // 0x3C0
	[CompilerGenerated]
	private static Board _Instance_k__BackingField; // 0x10
	private DotPool _dotPool; // 0x3C8
	private Transform _dotPoolRoot; // 0x3D0
	private const string DotPoolRootName = "DotPool"; // Metadata: 0x005F1BFE
	private RectTransform _cachedPlayfieldMaskOwner; // 0x3D8
	private RectMask2D _cachedPlayfieldMask; // 0x3E0
	private RectTransform _cachedDotsAreaFrameImageOwner; // 0x3E8
	private Image _cachedDotsAreaFrameImage; // 0x3F0
	private int _gridLayoutCacheFrame; // 0x3F8
	private bool _gridLayoutCacheOk; // 0x3FC
	private RectTransform _gridLayoutCacheArea; // 0x400
	private float _gridLayoutCacheCellW; // 0x408
	private float _gridLayoutCacheCellH; // 0x40C
	private Rect _gridLayoutCacheRect; // 0x410
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x005F1C06
	private const float DotSweepIntervalSec = 0.25f; // Metadata: 0x005F1C0A
	private float _lastDotSweepAt; // 0x420
	private float _lastAppliedDotScaleU; // 0x424
	private bool _dotScaleDirty; // 0x428
	private bool _lastInputOpen; // 0x429
	[Header("T\u1ED1c \u0111\u1ED9 x\u1EED l\u00FD vi\u00EAn (HandleUI)")]
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD m\u1ED7i lo\u1EA1i vi\u00EAn th\u01B0\u1EDDng (sau animation damage).")]
	private float handleUI_waitPerNormalGem; // 0x42C
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD vi\u00EAn v\u00E0ng (s).")]
	private float handleUI_waitPerVangGem; // 0x430
	[SerializeField]
	[Tooltip("Kho\u1EA3ng ngh\u1EC9 ng\u1EAFn sau c\u1EADp nh\u1EADt slider, tr\u01B0\u1EDBc b\u01B0\u1EDBc ti\u1EBFp.")]
	private float handleUI_pauseAfterSliderNormal; // 0x434
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; // 0x438
	[Header("Pet animation duration cho vi\u00EAn ki\u1EBFm (vang Dot)")]
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation Attack b\u00ECnh th\u01B0\u1EDDng (key=1). Ch\u1EDD \u0111\u1EE7 tr\u01B0\u1EDBc khi reset animator.")]
	private float vangAttackAnimDuration; // 0x43C
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation AttackPower khi \u0111\u1EE7 n\u1ED9 (key=2).")]
	private float vangAttackPowerAnimDuration; // 0x440
	[SerializeField]
	private float destructionEntryPulseSeconds; // 0x444
	[SerializeField]
	private float destructionEntryShrinkSeconds; // 0x448
	private Coroutine _bossDeadlineCo; // 0x450
	private static Font _multiplierFont; // 0x18
	private static readonly Color MultiplierOutlineColor; // 0x20
	private static readonly Color MultiplierMainColor; // 0x30
	private static readonly string[] DestroyDisplayOrder; // 0x40
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x458
	private readonly List<GameObject> _destroyEntryPool; // 0x460
	private bool _rewardPanelBuilt; // 0x468
	private bool _weaponRewardShown; // 0x469
	private bool _petShardRewardShown; // 0x46A
	private bool _lateRewardHooked; // 0x46B
	private const float REWARD_REVEAL_STAGGER = 0.12f; // Metadata: 0x005F1C0E
	private const float REWARD_REVEAL_DURATION = 0.35f; // Metadata: 0x005F1C12
	private const string RANK_ICON_SHEET = "Image/Common/common_popup_ui"; // Metadata: 0x005F1C16
	private const string RANK_ICON_NAME = "common_popup_ui_77"; // Metadata: 0x005F1C33
	private static Sprite _rankIconCache; // 0x48
	private static bool _rankIconLooked; // 0x50
	[SerializeField]
	private float mega1AnimDuration; // 0x46C
	private Coroutine _mega1AnimCoroutine; // 0x470
	internal bool isMega1PanelOpen; // 0x478
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x005F1C46
	private Coroutine _megaIcarusAnimCoroutine; // 0x480
	private SpriteRenderer _megaIcarusFxHost; // 0x488
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x005F1C55
	private readonly List<GameObject> _megaIcarusMarks; // 0x490
	private readonly List<NudgedMultiplierLabel> _megaIcarusNudgedLabels; // 0x498
	private static readonly Vector3 MegaIcarusNudge; // 0x54
	private const float MegaIcarusNudgeScale = 0.78f; // Metadata: 0x005F1C64
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x005F1C68
	private Coroutine _galaxyScanCoroutine; // 0x4A0
	private Dot[,] _dotComps; // 0x4A8
	private GameObject[,] _dotCompOwners; // 0x4B0
	[CompilerGenerated]
	private bool _DotsHiddenForPresentation_k__BackingField; // 0x4B8
	public const long FUSION_CARD_ID = -777; // Metadata: 0x005F1C73
	private static readonly int[][] SwapDirections; // 0x60
	private HashSet<int> _shownExitNoticeActors; // 0x4C0

	// Properties
	public GameObject ResolvedDotsArea { get; } // 0x0000000180A5AA00-0x0000000180A5AA10 
	public bool IsBoardReady { get; } // 0x0000000180A5AA10-0x0000000180A5AA20 
	public static Board Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5AA20-0x0000000180A5AA80 0x0000000180A5AA80-0x0000000180A5AB40
	internal DotPool Dots { get; } // 0x0000000180A5E880-0x0000000180A5EEE0 
	internal float HandleUIWaitNormal { get; } // 0x0000000180A65370-0x0000000180A65390 
	internal float HandleUIWaitVang { get; } // 0x0000000180A65390-0x0000000180A653B0 
	internal float HandleUIPauseNormal { get; } // 0x0000000180A653B0-0x0000000180A653D0 
	internal float HandleUIPauseVang { get; } // 0x0000000180A653D0-0x0000000180A653F0 
	internal float VangAttackAnimDuration { get; } // 0x0000000180A653F0-0x0000000180A65400 
	internal float VangAttackPowerAnimDuration { get; } // 0x0000000180A65400-0x0000000180A65410 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x0000000180A7E960-0x0000000180A7ECF0 
	internal bool DotsHiddenForPresentation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A88AA0-0x0000000180A88AB0 0x0000000180A88AB0-0x0000000180A88AC0

	// Nested types
	private struct NudgedMultiplierLabel // TypeDefIndex: 2214
	{
		// Fields
		public Transform Tr; // 0x00
		public Vector3 LocalPosition; // 0x08
		public Vector3 LocalScale; // 0x14
		public MeshRenderer Renderer; // 0x20
		public int SortingOrder; // 0x28
		public MultiplierTextSparkleEffect Sparkle; // 0x30
		public float SparkleExternalScale; // 0x38
	}

	[Serializable]
	public class PetRewardResponse // TypeDefIndex: 2215
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
		public PetRewardResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class StoneRewardInfo // TypeDefIndex: 2216
	{
		// Fields
		public string element; // 0x10
		public int level; // 0x18
		public int quantity; // 0x1C

		// Constructors
		public StoneRewardInfo(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2217
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__325_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__329_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__329_1; // 0x18
		public static Func<StoneRewardInfo, int> __9__397_0; // 0x20
		public static Func<StoneRewardInfo, string> __9__397_1; // 0x28
		public static Func<GameObject, bool> __9__427_0; // 0x30
		public static Func<Vector2Int, int> __9__429_0; // 0x38
		public static Func<Vector2Int, int> __9__429_1; // 0x40
		public static Func<int, int> __9__429_2; // 0x48
		public static Func<Vector2Int, int> __9__429_3; // 0x50
		public static Func<Vector2Int, int> __9__429_4; // 0x58
		public static Func<int, int> __9__429_5; // 0x60
		public static Func<CardData, bool> __9__432_0; // 0x68
		public static Func<CardData, bool> __9__432_1; // 0x70

		// Constructors
		static __c(); // 0x0000000180AC1200-0x0000000180AC12A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _displayDestroy_b__325_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x0000000180AC12A0-0x0000000180AC1360
		internal int _DisplayCoopReward_b__329_0(StoneRewardInfo s); // 0x0000000180475D50-0x0000000180475D70
		internal string _DisplayCoopReward_b__329_1(StoneRewardInfo s); // 0x00000001807AA060-0x00000001807AA080
		internal int _DisplayRewardFromServer_b__397_0(StoneRewardInfo s); // 0x0000000180475D50-0x0000000180475D70
		internal string _DisplayRewardFromServer_b__397_1(StoneRewardInfo s); // 0x00000001807AA060-0x00000001807AA080
		internal bool _CalculatePotentialVangDotDestruction_b__427_0(GameObject g); // 0x0000000180AC1360-0x0000000180AC14A0
		internal int _ComputeBossSwordLineMetrics_b__429_0(Vector2Int p); // 0x0000000180AC14A0-0x0000000180AC14B0
		internal int _ComputeBossSwordLineMetrics_b__429_1(Vector2Int p); // 0x0000000180475D40-0x0000000180475D50
		internal int _ComputeBossSwordLineMetrics_b__429_2(int v); // 0x0000000180475D40-0x0000000180475D50
		internal int _ComputeBossSwordLineMetrics_b__429_3(Vector2Int p); // 0x0000000180475D40-0x0000000180475D50
		internal int _ComputeBossSwordLineMetrics_b__429_4(Vector2Int p); // 0x0000000180AC14A0-0x0000000180AC14B0
		internal int _ComputeBossSwordLineMetrics_b__429_5(int v); // 0x0000000180475D40-0x0000000180475D50
		internal bool _LoadSelectedCards_b__432_0(CardData c); // 0x00000001807AA1C0-0x00000001807AA1D0
		internal bool _LoadSelectedCards_b__432_1(CardData c); // 0x0000000180AC14B0-0x0000000180AC1510
	}

	[CompilerGenerated]
	private struct __c__DisplayClass233_0 // TypeDefIndex: 2218
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass255_0 // TypeDefIndex: 2219
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass255_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x0000000180AC1510-0x0000000180AC1700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass327_0 // TypeDefIndex: 2220
	{
		// Fields
		public Animator animator; // 0x10
		public float t; // 0x18
		public float timeout; // 0x1C

		// Constructors
		public __c__DisplayClass327_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ShowGameResultIntegrated_b__2(); // 0x0000000180AC1700-0x0000000180AC1890
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass329_0 // TypeDefIndex: 2221
	{
		// Fields
		public GameObject petReward; // 0x10

		// Constructors
		public __c__DisplayClass329_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCoopReward_b__2(); // 0x0000000180AC1890-0x0000000180AC19F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass344_0 // TypeDefIndex: 2222
	{
		// Fields
		public Transform cell; // 0x10

		// Constructors
		public __c__DisplayClass344_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnTowerRewards_b__0(); // 0x0000000180AC19F0-0x0000000180AC1B70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass398_0 // TypeDefIndex: 2223
	{
		// Fields
		public int level; // 0x10
		public Board __4__this; // 0x18

		// Constructors
		public __c__DisplayClass398_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x0000000180AC1B70-0x0000000180AC1C00
	}

	[CompilerGenerated]
	private sealed class _AnimateDotsWaterfall_d__303 : IEnumerator<object> // TypeDefIndex: 2224
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private float _maxDur_5__2; // 0x28
		private float _maxColDelay_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnimateDotsWaterfall_d__303(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC1C00-0x0000000180AC2070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC2070-0x0000000180AC20B0
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__367 : IEnumerator<object> // TypeDefIndex: 2225
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__367(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC20B0-0x0000000180AC2210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC2210-0x0000000180AC2250
	}

	[CompilerGenerated]
	private sealed class _BossDeadlineCountdownCoroutine_d__267 : IEnumerator<object> // TypeDefIndex: 2226
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private bool _timeoutToastShown_5__2; // 0x28
		private WaitForSecondsRealtime _wait_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BossDeadlineCountdownCoroutine_d__267(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180AC2250-0x0000000180AC25F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC25F0-0x0000000180AC2630
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__320 : IEnumerator<object> // TypeDefIndex: 2227
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__320(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC2630-0x0000000180AC29B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC29B0-0x0000000180AC29F0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__255 : IEnumerator<object> // TypeDefIndex: 2228
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass255_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__255(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x0000000180AC29F0-0x0000000180AC31F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC31F0-0x0000000180AC3230
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__254 : IEnumerator<object> // TypeDefIndex: 2229
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Board __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__254(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC3230-0x0000000180AC3360
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC3360-0x0000000180AC33A0
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__301 : IEnumerator<object> // TypeDefIndex: 2230
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__301(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC33A0-0x0000000180AC40E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC40E0-0x0000000180AC4120
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__310 : IEnumerator<object> // TypeDefIndex: 2231
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__310(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC4120-0x0000000180AC46E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC46E0-0x0000000180AC4720
	}

	[CompilerGenerated]
	private sealed class _DisplayCoopReward_d__329 : IEnumerator<object> // TypeDefIndex: 2232
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int gold; // 0x28
		public int exp; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCoopReward_d__329(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC4720-0x0000000180AC7230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC7230-0x0000000180AC7270
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__397 : IEnumerator<object> // TypeDefIndex: 2233
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__397(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC7270-0x0000000180AC90E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC90E0-0x0000000180AC9120
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__413 : IEnumerator<object> // TypeDefIndex: 2234
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CanvasGroup canvasGroup; // 0x20
		public float duration; // 0x28
		private float _elapsedTime_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__413(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AC9120-0x0000000180AC95E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC95E0-0x0000000180AC9620
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__394 : IEnumerator<object> // TypeDefIndex: 2235
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__394(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x0000000180AC9620-0x0000000180ACA090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACA090-0x0000000180ACA0D0
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__284 : IEnumerator<object> // TypeDefIndex: 2236
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__284(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180ACA0D0-0x0000000180ACA580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACA580-0x0000000180ACA5C0
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__256 : IEnumerator<object> // TypeDefIndex: 2237
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HandleUIWs_d__256(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180ACA5C0-0x0000000180ACBB10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACBB10-0x0000000180ACBB50
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__425 : IEnumerator<object> // TypeDefIndex: 2238
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HideAllItemsEnd_d__425(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807B0F90-0x00000001807B10A0
		private bool MoveNext(); // 0x0000000180ACBB50-0x0000000180ACC440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACC440-0x0000000180ACC480
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__443 : IEnumerator<object> // TypeDefIndex: 2239
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__443(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180ACC480-0x0000000180ACC770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACC770-0x0000000180ACC7B0
	}

	[CompilerGenerated]
	private sealed class _ResetBoardWhenNoMoves_d__451 : IEnumerator<object> // TypeDefIndex: 2240
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResetBoardWhenNoMoves_d__451(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180ACC7B0-0x0000000180ACD3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACD3D0-0x0000000180ACD410
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__326 : IEnumerator<object> // TypeDefIndex: 2241
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private MatchService _msvc_5__2; // 0x28
		private float _wsTimeout_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__326(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180ACD410-0x0000000180ACDAB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACDAB0-0x0000000180ACDAF0
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__327 : IEnumerator<object> // TypeDefIndex: 2242
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public bool aborted; // 0x28
		public bool serverAuthoritative; // 0x29
		public bool playerWon; // 0x2A
		private long _earlyEnemyPetId_5__2; // 0x30
		private Coroutine _submitCo_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__327(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180ACDAF0-0x0000000180ACEC30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACEC30-0x0000000180ACEC70
	}

	[CompilerGenerated]
	private sealed class _ShowMatchAbortedPanel_d__328 : IEnumerator<object> // TypeDefIndex: 2243
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowMatchAbortedPanel_d__328(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180ACEC70-0x0000000180ACF890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ACF890-0x0000000180ACF8D0
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__274 : IEnumerator<object> // TypeDefIndex: 2244
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int currentTurnActor; // 0x20
		public Board __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__274(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180ACF8D0-0x0000000180AD0290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD0290-0x0000000180AD02D0
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__304 : IEnumerator<object> // TypeDefIndex: 2245
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__304(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AD02D0-0x0000000180AD0830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AD0830-0x0000000180AD0870
	}

	// Constructors
	public Board(); // 0x0000000180A91EF0-0x0000000180A92AA0
	static Board(); // 0x0000000180A92AA0-0x0000000180A92FE0

	// Methods
	internal void Awake(); // 0x0000000180A5AB40-0x0000000180A5B280
	private void OnEnable(); // 0x0000000180A5B280-0x0000000180A5B2A0
	private void Start(); // 0x0000000180A5B2A0-0x0000000180A5B6B0
	private void OnValidate(); // 0x0000000180A5B6B0-0x0000000180A5B9F0
	private bool HasExplicitDotsParent(); // 0x0000000180A5B9F0-0x0000000180A5BBF0
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x0000000180A5BBF0-0x0000000180A5CD10
	private void EnsureRuntimeDotsParent(); // 0x0000000180A5CD10-0x0000000180A5D1C0
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x0000000180A5D1C0-0x0000000180A5D810
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x0000000180A5D810-0x0000000180A5DE00
	private Transform GetDotsAreaShellTransform(); // 0x0000000180A5DE00-0x0000000180A5DE40
	private Transform GetDotsParent(); // 0x0000000180A5DE40-0x0000000180A5E020
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180A5E020-0x0000000180A5E150
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x0000000180A5E150-0x0000000180A5E870
	public Transform GetDotsParentTransform(); // 0x0000000180A5E870-0x0000000180A5E880
	internal bool TryTakePooledDot(string tag, Vector2 worldPos, out GameObject go); // 0x0000000180A5EEE0-0x0000000180A5EFB0
	internal void ReleaseDot(GameObject dot); // 0x0000000180A5EFB0-0x0000000180A5F0D0
	internal void ClearDotPool(); // 0x0000000180A5F0D0-0x0000000180A5F0F0
	public void PrepareDotsAreaForCoopSync(); // 0x0000000180A5F0F0-0x0000000180A5F170
	internal bool HasFullDotGridSpawned(); // 0x0000000180A5F170-0x0000000180A5F350
	public void ApplyCoopBoardVisualFinishAfterNetworkSync(); // 0x0000000180A5F350-0x0000000180A5F6B0
	private GameObject ResolveDotsAreaRoot(); // 0x0000000180A5F6B0-0x0000000180A5F7E0
	private GameObject GetDotsVisibilityRoot(); // 0x0000000180A5AA00-0x0000000180A5AA10
	private Vector3 GetGridOriginWorld(); // 0x0000000180A5F7E0-0x0000000180A5FB00
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x0000000180A5FB00-0x0000000180A60540
	private void UpdateDotsPlayfieldLayout(); // 0x0000000180A60540-0x0000000180A60CF0
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x00000001806129C0-0x0000000180612D80
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x0000000180A60CF0-0x0000000180A60FA0
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x0000000180A60FA0-0x0000000180A611A0
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x0000000180A611A0-0x0000000180A61740
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x0000000180A61740-0x0000000180A61AB0
	private void InvalidateGridLayoutCache(); // 0x0000000180A61AB0-0x0000000180A61B30
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180A61B30-0x0000000180A61D40
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180A61D40-0x0000000180A62560
	private void EnsureDotPrefabSpriteCache(); // 0x0000000180A62560-0x0000000180A62B80
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x0000000180A62B80-0x0000000180A62BD0
	private void LateUpdate(); // 0x0000000180A62BD0-0x0000000180A63120
	internal void MarkDotScaleDirty(); // 0x0000000180A63120-0x0000000180A63130
	private void Update(); // 0x0000000180A63130-0x0000000180A631C0
	internal void WakeAllDots(); // 0x0000000180A631C0-0x0000000180A63340
	private void WakeDriftedDots(); // 0x0000000180A63340-0x0000000180A63520
	private void ApplyDotScaleToFitGridCells(); // 0x0000000180A63520-0x0000000180A63EC0
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x0000000180A63EC0-0x0000000180A642A0
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x0000000180A642A0-0x0000000180A64300
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x0000000180A64300-0x0000000180A64370
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x0000000180A642A0-0x0000000180A64300
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x0000000180A64370-0x0000000180A64400
	public Vector2 GetColyseusSpawnWorldPositionAboveBoard(int column); // 0x0000000180A64400-0x0000000180A644D0
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x0000000180A644D0-0x0000000180A64580
	private void ApplyDotsAreaBackgroundSprite(); // 0x0000000180A64580-0x0000000180A64850
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x0000000180A64850-0x0000000180A64AF0
	public void RefreshDotsAreaBackgroundVisible(); // 0x0000000180A64AF0-0x0000000180A64B00
	private void EnsureDotsAreaLayoutAndBackground(); // 0x0000000180A64B00-0x0000000180A64D10
	private void ReparentStrayDotsIntoPlayfield(); // 0x0000000180A64D10-0x0000000180A65370
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__254))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x0000000180A65410-0x0000000180A65530
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__255))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x0000000180A65530-0x0000000180A65640
	[IteratorStateMachine(typeof(_HandleUIWs_d__256))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, bool bossSide, bool wasFullPower); // 0x0000000180A65640-0x0000000180A65770
	public bool IsPlayerAllowedToMove(); // 0x0000000180A65770-0x0000000180A659B0
	public void EnsureBoardVisible(); // 0x0000000180A659B0-0x0000000180A65BD0
	public void OpenInputForLocalTurnOnly(); // 0x0000000180A65BD0-0x0000000180A65D90
	private void HandleTurnStart(int entityIndex); // 0x000000018028A320-0x000000018028A330
	internal void HandleTurnEnd(); // 0x0000000180A65D90-0x0000000180A65EE0
	private void EnsureBossCountdownText(); // 0x0000000180A65EE0-0x0000000180A66740
	private void EnsureTowerHud(); // 0x0000000180A66740-0x0000000180A66D70
	private void HandleTowerTurnsChanged(int left); // 0x0000000180A66D70-0x0000000180A67060
	private void ReleaseTowerHud(); // 0x0000000180A67060-0x0000000180A67490
	[IteratorStateMachine(typeof(_BossDeadlineCountdownCoroutine_d__267))]
	private IEnumerator BossDeadlineCountdownCoroutine(); // 0x0000000180A67490-0x0000000180A67530
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x0000000180A67530-0x0000000180A67840
	public void ReturnToMenuSafely(); // 0x0000000180A67840-0x0000000180A67B80
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x0000000180A67B80-0x0000000180A68100
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x0000000180A68100-0x0000000180A68790
	public void LoadGroupBackground(); // 0x0000000180A68790-0x0000000180A68BC0
	public void OnTurnStartNotify(int actorNumber); // 0x0000000180A68BC0-0x0000000180A693A0
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__274))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x0000000180A693A0-0x0000000180A69450
	internal void LoadAudioSettings(); // 0x0000000180A69450-0x0000000180A69710
	private int ResolveAuthoritativeEnemyPetId(); // 0x0000000180A69710-0x0000000180A69880
	public void InitializeCards(); // 0x0000000180A69880-0x0000000180A6AAD0
	private bool CardsHiddenThisMatch(); // 0x0000000180A6AAD0-0x0000000180A6AD20
	private bool IsGuildBossMatch(); // 0x0000000180A6AD20-0x0000000180A6ADE0
	private bool SkillCardsHiddenThisMatch(); // 0x0000000180A6ADE0-0x0000000180A6AE10
	public void OnCardDataReady(CardData data); // 0x0000000180A6AE10-0x0000000180A6AEC0
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x0000000180A6AEC0-0x0000000180A6B680
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x0000000180A6B680-0x0000000180A6B9E0
	[IteratorStateMachine(typeof(_HandleNetworkError_d__284))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x0000000180A6B9E0-0x0000000180A6BA80
	public int CalculateTrapPotential(int x, int y, string tag); // 0x0000000180A6BA80-0x0000000180A6C130
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x0000000180A6C130-0x0000000180A6C7E0
	public int GetDotMultiplier(GameObject dot); // 0x0000000180A6C7E0-0x0000000180A6C980
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x0000000180A6C980-0x0000000180A6CFB0
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x0000000180A6CFB0-0x0000000180A6DBB0
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x0000000180A6DBB0-0x0000000180A6E080
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x0000000180A6E080-0x0000000180A6EC40
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x0000000180A6EC40-0x0000000180A6EFC0
	public int CountPlayerVangOpportunities(string[,] board); // 0x0000000180A6EFC0-0x0000000180A6F120
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x0000000180A6F120-0x0000000180A6F4F0
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x0000000180A6F4F0-0x0000000180A6F790
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x005F1BD9 */); // 0x0000000180A6F790-0x0000000180A700A0
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x0000000180A700A0-0x0000000180A707B0
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x0000000180A707B0-0x0000000180A70DF0
	public bool MatchesAt(int column, int row, GameObject piece); // 0x0000000180A70DF0-0x0000000180A71460
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180A71460-0x0000000180A71A60
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__301))]
	internal IEnumerator DecreaseRowCo(); // 0x0000000180A71A60-0x0000000180A71B00
	internal void ResetDestroyedCounts(); // 0x0000000180A71B00-0x0000000180A71B20
	[IteratorStateMachine(typeof(_AnimateDotsWaterfall_d__303))]
	private IEnumerator AnimateDotsWaterfall(); // 0x0000000180A71B20-0x0000000180A71BC0
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__304))]
	public IEnumerator WaitAndDestroyMatches(); // 0x0000000180A71BC0-0x0000000180A71C60
	public void DestroyMatches(); // 0x0000000180A71C60-0x0000000180A71DE0
	private void StartCascade(IEnumerator routine); // 0x0000000180A71DE0-0x0000000180A71EB0
	internal void StopCascadePipeline(); // 0x0000000180A71EB0-0x0000000180A71F40
	internal void DestroyOrphanDotsUnderDotsParent(bool immediate); // 0x0000000180A71F40-0x0000000180A72810
	public void DestroyRandomDots(int count); // 0x0000000180A72810-0x0000000180A728D0
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__310))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x0000000180A728D0-0x0000000180A72980
	public void RefillBoard(); // 0x0000000180A72980-0x0000000180A72AC0
	private void RefillBoardNonDeterministic(); // 0x0000000180A72AC0-0x0000000180A73150
	private static Font GetMultiplierFont(); // 0x0000000180A73150-0x0000000180A732E0
	private static Color ParseHexOr(string hex, Color fallback); // 0x0000000180A732E0-0x0000000180A733B0
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x0000000180A733B0-0x0000000180A74420
	public bool MatchesOnBoard(); // 0x0000000180A74420-0x0000000180A74600
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__320))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x0000000180A74600-0x0000000180A746A0
	private static int DestroyOrderIndexOf(string tag); // 0x0000000180A746A0-0x0000000180A74810
	internal void displayDestroy(); // 0x0000000180A74810-0x0000000180A75770
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__326))]
	internal IEnumerator ResumeAndSyncState(); // 0x0000000180A75770-0x0000000180A75810
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__327))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool serverAuthoritative = false /* Metadata: 0x005F1BDA */, bool aborted = false /* Metadata: 0x005F1BDB */); // 0x0000000180A75810-0x0000000180A758E0
	[IteratorStateMachine(typeof(_ShowMatchAbortedPanel_d__328))]
	private IEnumerator ShowMatchAbortedPanel(); // 0x0000000180A758E0-0x0000000180A75980
	[IteratorStateMachine(typeof(_DisplayCoopReward_d__329))]
	internal IEnumerator DisplayCoopReward(int gold, int exp); // 0x0000000180A75980-0x0000000180A75A40
	private void HookLateRewardPush(); // 0x0000000180A75A40-0x0000000180A75D10
	private void UnhookLateRewardPush(); // 0x0000000180A75D10-0x0000000180A75EB0
	private void HandleLateRewardPush(string matchId); // 0x0000000180A75EB0-0x0000000180A76030
	private void SpawnPetShardReward(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A76030-0x0000000180A76E00
	private void SpawnWeaponShardReward(int amount); // 0x0000000180A76E00-0x0000000180A775D0
	private void SpawnGuildContribReward(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A775D0-0x0000000180A77FD0
	private void SpawnSweepTicketReward(long itemId, int amount, string label); // 0x0000000180A77FD0-0x0000000180A78930
	private void SpawnWeaponReward(WeaponDropDTO drop); // 0x0000000180A78930-0x0000000180A79810
	private static Image FindRewardIcon(GameObject item); // 0x0000000180A79810-0x0000000180A79D00
	private static void SetRewardCountText(GameObject item, string text); // 0x0000000180A79D00-0x0000000180A79F50
	private void SpawnTowerRewards(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A79F50-0x0000000180A7AC50
	private void SpawnTowerBundle(TowerGiftBundle g); // 0x0000000180A7AC50-0x0000000180A7AE80
	private void SpawnTowerEntry(RewardDisplayHelper.Entry e); // 0x0000000180A7AE80-0x0000000180A7B470
	private GameObject TowerFrame(string type, out bool exact); // 0x0000000180A7B470-0x0000000180A7BC90
	private static string TowerAmountText(RewardDisplayHelper.Entry e); // 0x0000000180A7BC90-0x0000000180A7C2D0
	private GameObject SpawnRewardItem(GameObject prefab, string text, string tipType = null); // 0x0000000180A7C2D0-0x0000000180A7C5C0
	private static void ApplyCtIcon(GameObject item); // 0x0000000180A7C5C0-0x0000000180A7C830
	private static void ApplyRankIcon(GameObject item); // 0x0000000180A7C830-0x0000000180A7CF40
	private void AnimateRewardReveal(GameObject item); // 0x0000000180A7CF40-0x0000000180A7D1E0
	private float GetRewardRevealTotalSeconds(int itemCount); // 0x0000000180A7D1E0-0x0000000180A7D210
	private void ShowBtnGetWithAnim(); // 0x0000000180A7D210-0x0000000180A7D4D0
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x005F1BDC */); // 0x0000000180A7D4D0-0x0000000180A7D770
	public void HideMega1Animation(); // 0x0000000180A7D770-0x0000000180A7DB40
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x005F1BDD */); // 0x0000000180A7DB40-0x0000000180A7DEC0
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__367))]
	private IEnumerator AutoHideMega1Animation(); // 0x0000000180A7DEC0-0x0000000180A7DF60
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x0000000180A7DF60-0x0000000180A7E630
	public void ClearAllMega2Hints(); // 0x0000000180A7E630-0x0000000180A7E960
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x0000000180A7ECF0-0x0000000180A7F750
	private void StopMegaIcarusWorldFx(); // 0x0000000180A7F750-0x0000000180A7F8D0
	private void RequestHideMegaIcarusWorldFx(); // 0x0000000180A7F8D0-0x0000000180A7FA50
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x005F1BDE */); // 0x0000000180A7FA50-0x0000000180A7FE90
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x0000000180A7FE90-0x0000000180A80A40
	public void ClearAllMegaIcarusHints(); // 0x0000000180A80A40-0x0000000180A80D80
	public void ShowMegaIcarusMarks(List<MegaIcarusMark> cells); // 0x0000000180A80D80-0x0000000180A81A40
	private bool NudgeExistingMultiplierLabel(GameObject dot); // 0x0000000180A81A40-0x0000000180A82680
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x0000000180A82680-0x0000000180A82E50
	public void ClearAllMegaIcarusMarks(); // 0x0000000180A82E50-0x0000000180A834C0
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x005F1BDF */); // 0x0000000180A834C0-0x0000000180A839A0
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__394))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x0000000180A839A0-0x0000000180A83AC0
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180A83AC0-0x0000000180A84080
	public void ClearAllGalaxyHints(); // 0x0000000180A84080-0x0000000180A84520
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__397))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180A84520-0x0000000180A84630
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x0000000180A84630-0x0000000180A84AB0
	public void ReturnToMenu(); // 0x0000000180A84AB0-0x0000000180A84DB0
	private void ClearRoomRestoreFlags(); // 0x0000000180A84DB0-0x0000000180A84ED0
	public void ReturnToQuangTruongFromBoss(); // 0x0000000180A84ED0-0x0000000180A850D0
	private bool PrepareTowerReturn(); // 0x0000000180A850D0-0x0000000180A85160
	private bool PrepareGuildRaidReturn(); // 0x0000000180A85160-0x0000000180A851C0
	private void SetupGuildRaidResultPanel(bool playerWon); // 0x0000000180A851C0-0x0000000180A86110
	private static void EnsureRaidStyleKey(GameObject go, string key); // 0x0000000180A86110-0x0000000180A86340
	private UnityEngine.UI.Text EnsureRaidResultText(string nodeName, UnityEngine.UI.Text sample, Vector2 pos, int fontSize, string otaKey); // 0x0000000180A86340-0x0000000180A86DF0
	private void EnsureRaidFightAgainButton(UnityEngine.UI.Text sample); // 0x0000000180A86DF0-0x0000000180A87E70
	internal int CalculateExpByLevel(int level); // 0x0000000180626820-0x0000000180626860
	internal int CalculateTotalStones(int turnCount); // 0x0000000180626860-0x00000001806268A0
	internal int RollStoneLevel(int turnCount); // 0x0000000180A87E70-0x0000000180A880F0
	internal Sprite GetStoneSprite(string element, int level); // 0x0000000180A880F0-0x0000000180A883C0
	internal bool CheckBoardStable(); // 0x0000000180A883C0-0x0000000180A885B0
	[IteratorStateMachine(typeof(_FadeOut_d__413))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x0000000180A885B0-0x0000000180A88670
	internal Dot DotCompAt(int x, int y); // 0x0000000180A88670-0x0000000180A88AA0
	private void SetDotsRenderVisible(bool visible); // 0x0000000180A88AC0-0x0000000180A88C50
	private void SnapAllDotsToGrid(); // 0x0000000180A88C50-0x0000000180A89150
	public void ShowItems(); // 0x0000000180A89150-0x0000000180A89C00
	public void HideAllItems(); // 0x0000000180A89C00-0x0000000180A8A670
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__425))]
	public IEnumerator HideAllItemsEnd(); // 0x0000000180A8A670-0x0000000180A8A710
	public void ResetMoveCounters(); // 0x0000000180A65D90-0x0000000180A65EE0
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x0000000180A8A710-0x0000000180A8AA30
	private static int LongestConsecutiveSpanOnAxis(List<int> sortedAsc); // 0x0000000180A8AA30-0x0000000180A8AB40
	public ValueTuple<int, int, int> ComputeBossSwordLineMetrics(GameObject movedDot, int targetX, int targetY); // 0x0000000180A8AB40-0x0000000180A8B890
	private void LoadCardsFromPlayerPrefs(); // 0x0000000180A8B890-0x0000000180A8BA20
	private void CreateCardHT(CardData cardData); // 0x0000000180A8BA20-0x0000000180A8C150
	public void LoadSelectedCards(List<CardData> cards); // 0x0000000180A8C150-0x0000000180A8C540
	private void DisplayCardsOnBoard(); // 0x0000000180A8C540-0x0000000180A8C620
	public void EnsureFusionCards(); // 0x0000000180A8C620-0x0000000180A8CE30
	private void RemoveFusionCard(); // 0x0000000180A8CE30-0x0000000180A8D0D0
	public void AddFusionSkillCard(CardData cardData); // 0x0000000180A8D0D0-0x0000000180A8D8E0
	private CardUI FindWiredSkillCardUI(); // 0x0000000180A8D8E0-0x0000000180A8DDB0
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x0000000180A8DDB0-0x0000000180A8E480
	private void ClearCards(); // 0x0000000180A8E480-0x0000000180A8E9B0
	public void LeaveMatchAfterGameOver(); // 0x0000000180A8E9B0-0x0000000180A8ECB0
	public void LeaveMatchMidGame(); // 0x0000000180A8ECB0-0x0000000180A8EF10
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__443))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x0000000180A8EF10-0x0000000180A8EFB0
	private void GoToMainScene(); // 0x0000000180A8EFB0-0x0000000180A8F060
	private void FastReturnToRoom(); // 0x0000000180A8F060-0x0000000180A8F310
	internal void ReturnToQuangTruong(); // 0x0000000180A8F310-0x0000000180A8F4D0
	public bool HasValidMoves(); // 0x0000000180A8F4D0-0x0000000180A8F8C0
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x0000000180A8F8C0-0x0000000180A8FBC0
	internal bool CheckMatchAt(int col, int row, string tag); // 0x0000000180A8FBC0-0x0000000180A90190
	[IteratorStateMachine(typeof(_ResetBoardWhenNoMoves_d__451))]
	public IEnumerator ResetBoardWhenNoMoves(); // 0x0000000180A90190-0x0000000180A90230
	public void InitializeCardsClientOnly(); // 0x0000000180A90230-0x0000000180A911F0
	public void SetBoardState(GameState state); // 0x0000000180A911F0-0x0000000180A91200
	public void GrayOutPlayerAvatar(int actorNumber); // 0x0000000180A91200-0x0000000180A912D0
	public void ShowPlayerExitNotice(string playerName, int actorNumber = 0 /* Metadata: 0x005F1BE3 */); // 0x0000000180A912D0-0x0000000180A91390
	public void RestorePlayerAvatar(int actorNumber); // 0x0000000180A91390-0x0000000180A91430
	public bool HasLeftMatch(int actorNumber); // 0x0000000180A91430-0x0000000180A91490
	private void ApplyAvatarTintIfDisplayed(int actorNumber, Color tint, bool isLeft); // 0x0000000180A91490-0x0000000180A918A0
	internal void OnMouseDown(); // 0x0000000180A71B00-0x0000000180A71B20
	internal void OnDestroy(); // 0x0000000180A918A0-0x0000000180A91E00
	internal void OnApplicationQuit(); // 0x0000000180A91E00-0x0000000180A91EF0
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_233_0(Transform t, ref __c__DisplayClass233_0 param_00002feb); // 0x0000000180A92FE0-0x0000000180A93320
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__327_0(); // 0x0000000180A93320-0x0000000180A93330
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__327_1(); // 0x0000000180A93320-0x0000000180A93330
	[CompilerGenerated]
	private void _ShowMatchAbortedPanel_b__328_0(); // 0x0000000180A93320-0x0000000180A93330
	[CompilerGenerated]
	private void _SetupGuildRaidResultPanel_b__404_0(); // 0x0000000180A93330-0x0000000180A93340
	[CompilerGenerated]
	private void _SetupGuildRaidResultPanel_b__404_1(); // 0x0000000180A93340-0x0000000180A934E0
}

