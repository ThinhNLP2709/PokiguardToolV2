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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class Board : MonoBehaviour // TypeDefIndex: 2206
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
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x005F07CD
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
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x005F07DB
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
	private const float CASCADE_WATCHDOG_SECONDS = 12f; // Metadata: 0x005F07DF
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
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x005F07E3
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
	private const string DotPoolRootName = "DotPool"; // Metadata: 0x005F07E7
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
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x005F07EF
	private const float DotSweepIntervalSec = 0.25f; // Metadata: 0x005F07F3
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
	private const float REWARD_REVEAL_STAGGER = 0.12f; // Metadata: 0x005F07F7
	private const float REWARD_REVEAL_DURATION = 0.35f; // Metadata: 0x005F07FB
	private const string RANK_ICON_SHEET = "Image/Common/common_popup_ui"; // Metadata: 0x005F07FF
	private const string RANK_ICON_NAME = "common_popup_ui_77"; // Metadata: 0x005F081C
	private static Sprite _rankIconCache; // 0x48
	private static bool _rankIconLooked; // 0x50
	[SerializeField]
	private float mega1AnimDuration; // 0x46C
	private Coroutine _mega1AnimCoroutine; // 0x470
	internal bool isMega1PanelOpen; // 0x478
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x005F082F
	private Coroutine _megaIcarusAnimCoroutine; // 0x480
	private SpriteRenderer _megaIcarusFxHost; // 0x488
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x005F083E
	private readonly List<GameObject> _megaIcarusMarks; // 0x490
	private readonly List<NudgedMultiplierLabel> _megaIcarusNudgedLabels; // 0x498
	private static readonly Vector3 MegaIcarusNudge; // 0x54
	private const float MegaIcarusNudgeScale = 0.78f; // Metadata: 0x005F084D
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x005F0851
	private Coroutine _galaxyScanCoroutine; // 0x4A0
	private Dot[,] _dotComps; // 0x4A8
	private GameObject[,] _dotCompOwners; // 0x4B0
	[CompilerGenerated]
	private bool _DotsHiddenForPresentation_k__BackingField; // 0x4B8
	public const long FUSION_CARD_ID = -777; // Metadata: 0x005F085C
	private static readonly int[][] SwapDirections; // 0x60
	private HashSet<int> _shownExitNoticeActors; // 0x4C0

	// Properties
	public GameObject ResolvedDotsArea { get; } // 0x0000000180A34D60-0x0000000180A34D70 
	public bool IsBoardReady { get; } // 0x0000000180A34D70-0x0000000180A34D80 
	public static Board Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A34D80-0x0000000180A34DE0 0x0000000180A34DE0-0x0000000180A34EA0
	internal DotPool Dots { get; } // 0x0000000180A38BE0-0x0000000180A39240 
	internal float HandleUIWaitNormal { get; } // 0x0000000180A3F6D0-0x0000000180A3F6F0 
	internal float HandleUIWaitVang { get; } // 0x0000000180A3F6F0-0x0000000180A3F710 
	internal float HandleUIPauseNormal { get; } // 0x0000000180A3F710-0x0000000180A3F730 
	internal float HandleUIPauseVang { get; } // 0x0000000180A3F730-0x0000000180A3F750 
	internal float VangAttackAnimDuration { get; } // 0x0000000180A3F750-0x0000000180A3F760 
	internal float VangAttackPowerAnimDuration { get; } // 0x0000000180A3F760-0x0000000180A3F770 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x0000000180A58C70-0x0000000180A59000 
	internal bool DotsHiddenForPresentation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A62DB0-0x0000000180A62DC0 0x0000000180A62DC0-0x0000000180A62DD0

	// Nested types
	private struct NudgedMultiplierLabel // TypeDefIndex: 2207
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
	public class PetRewardResponse // TypeDefIndex: 2208
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
	public class StoneRewardInfo // TypeDefIndex: 2209
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
	private sealed class __c // TypeDefIndex: 2210
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
		static __c(); // 0x0000000180A8A3E0-0x0000000180A8A480
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _displayDestroy_b__325_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x0000000180A8A480-0x0000000180A8A540
		internal int _DisplayCoopReward_b__329_0(StoneRewardInfo s); // 0x0000000180474AE0-0x0000000180474B00
		internal string _DisplayCoopReward_b__329_1(StoneRewardInfo s); // 0x00000001807A7FF0-0x00000001807A8010
		internal int _DisplayRewardFromServer_b__397_0(StoneRewardInfo s); // 0x0000000180474AE0-0x0000000180474B00
		internal string _DisplayRewardFromServer_b__397_1(StoneRewardInfo s); // 0x00000001807A7FF0-0x00000001807A8010
		internal bool _CalculatePotentialVangDotDestruction_b__427_0(GameObject g); // 0x0000000180A8A540-0x0000000180A8A680
		internal int _ComputeBossSwordLineMetrics_b__429_0(Vector2Int p); // 0x0000000180A8A680-0x0000000180A8A690
		internal int _ComputeBossSwordLineMetrics_b__429_1(Vector2Int p); // 0x0000000180474AD0-0x0000000180474AE0
		internal int _ComputeBossSwordLineMetrics_b__429_2(int v); // 0x0000000180474AD0-0x0000000180474AE0
		internal int _ComputeBossSwordLineMetrics_b__429_3(Vector2Int p); // 0x0000000180474AD0-0x0000000180474AE0
		internal int _ComputeBossSwordLineMetrics_b__429_4(Vector2Int p); // 0x0000000180A8A680-0x0000000180A8A690
		internal int _ComputeBossSwordLineMetrics_b__429_5(int v); // 0x0000000180474AD0-0x0000000180474AE0
		internal bool _LoadSelectedCards_b__432_0(CardData c); // 0x00000001807A8150-0x00000001807A8160
		internal bool _LoadSelectedCards_b__432_1(CardData c); // 0x0000000180A8A690-0x0000000180A8A6F0
	}

	[CompilerGenerated]
	private struct __c__DisplayClass233_0 // TypeDefIndex: 2211
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass255_0 // TypeDefIndex: 2212
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass255_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x0000000180A8A6F0-0x0000000180A8A8E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass327_0 // TypeDefIndex: 2213
	{
		// Fields
		public Animator animator; // 0x10
		public float t; // 0x18
		public float timeout; // 0x1C

		// Constructors
		public __c__DisplayClass327_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ShowGameResultIntegrated_b__2(); // 0x0000000180A8A8E0-0x0000000180A8AA70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass329_0 // TypeDefIndex: 2214
	{
		// Fields
		public GameObject petReward; // 0x10

		// Constructors
		public __c__DisplayClass329_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _DisplayCoopReward_b__2(); // 0x0000000180A8AA70-0x0000000180A8ABD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass344_0 // TypeDefIndex: 2215
	{
		// Fields
		public Transform cell; // 0x10

		// Constructors
		public __c__DisplayClass344_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnTowerRewards_b__0(); // 0x0000000180A8ABD0-0x0000000180A8AD50
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass398_0 // TypeDefIndex: 2216
	{
		// Fields
		public int level; // 0x10
		public Board __4__this; // 0x18

		// Constructors
		public __c__DisplayClass398_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x0000000180A8AD50-0x0000000180A8ADE0
	}

	[CompilerGenerated]
	private sealed class _AnimateDotsWaterfall_d__303 : IEnumerator<object> // TypeDefIndex: 2217
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A8ADE0-0x0000000180A8B250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8B250-0x0000000180A8B290
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__367 : IEnumerator<object> // TypeDefIndex: 2218
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A8B290-0x0000000180A8B3F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8B3F0-0x0000000180A8B430
	}

	[CompilerGenerated]
	private sealed class _BossDeadlineCountdownCoroutine_d__267 : IEnumerator<object> // TypeDefIndex: 2219
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
		private bool MoveNext(); // 0x0000000180A8B430-0x0000000180A8B7D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8B7D0-0x0000000180A8B810
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__320 : IEnumerator<object> // TypeDefIndex: 2220
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A8B810-0x0000000180A8BB90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8BB90-0x0000000180A8BBD0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__255 : IEnumerator<object> // TypeDefIndex: 2221
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
		private bool MoveNext(); // 0x0000000180A8BBD0-0x0000000180A8C3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8C3D0-0x0000000180A8C410
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__254 : IEnumerator<object> // TypeDefIndex: 2222
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A8C410-0x0000000180A8C540
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8C540-0x0000000180A8C580
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__301 : IEnumerator<object> // TypeDefIndex: 2223
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A8C580-0x0000000180A8D2C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A8D2C0-0x0000000180A8D380
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__310 : IEnumerator<object> // TypeDefIndex: 2224
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AB7260-0x0000000180AB7820
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AB7820-0x0000000180AB7860
	}

	[CompilerGenerated]
	private sealed class _DisplayCoopReward_d__329 : IEnumerator<object> // TypeDefIndex: 2225
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AB7860-0x0000000180ABA370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABA370-0x0000000180ABA3B0
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__397 : IEnumerator<object> // TypeDefIndex: 2226
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ABA3B0-0x0000000180ABC220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABC220-0x0000000180ABC260
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__413 : IEnumerator<object> // TypeDefIndex: 2227
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ABC260-0x0000000180ABC720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABC720-0x0000000180ABC760
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__394 : IEnumerator<object> // TypeDefIndex: 2228
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
		void IDisposable.Dispose(); // 0x000000018037B190-0x000000018037B200
		private bool MoveNext(); // 0x0000000180ABC760-0x0000000180ABD1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABD1D0-0x0000000180ABD210
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__284 : IEnumerator<object> // TypeDefIndex: 2229
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ABD210-0x0000000180ABD6C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABD6C0-0x0000000180ABD700
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__256 : IEnumerator<object> // TypeDefIndex: 2230
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
		private bool MoveNext(); // 0x0000000180ABD700-0x0000000180ABEC50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABEC50-0x0000000180ABEC90
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__425 : IEnumerator<object> // TypeDefIndex: 2231
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
		void IDisposable.Dispose(); // 0x00000001807AEF20-0x00000001807AF030
		private bool MoveNext(); // 0x0000000180ABEC90-0x0000000180ABF580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABF580-0x0000000180ABF5C0
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__443 : IEnumerator<object> // TypeDefIndex: 2232
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ABF5C0-0x0000000180ABF8B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180ABF8B0-0x0000000180ABF8F0
	}

	[CompilerGenerated]
	private sealed class _ResetBoardWhenNoMoves_d__451 : IEnumerator<object> // TypeDefIndex: 2233
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180ABF8F0-0x0000000180AC0510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC0510-0x0000000180AC0550
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__326 : IEnumerator<object> // TypeDefIndex: 2234
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
		private bool MoveNext(); // 0x0000000180AC0550-0x0000000180AC0BF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC0BF0-0x0000000180AC0C30
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__327 : IEnumerator<object> // TypeDefIndex: 2235
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
		private bool MoveNext(); // 0x0000000180AC0C30-0x0000000180AC1D70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC1D70-0x0000000180AC1DB0
	}

	[CompilerGenerated]
	private sealed class _ShowMatchAbortedPanel_d__328 : IEnumerator<object> // TypeDefIndex: 2236
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC1DB0-0x0000000180AC29D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC29D0-0x0000000180AC2A10
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__274 : IEnumerator<object> // TypeDefIndex: 2237
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC2A10-0x0000000180AC33D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC33D0-0x0000000180AC3410
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__304 : IEnumerator<object> // TypeDefIndex: 2238
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AC3410-0x0000000180AC3970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AC3970-0x0000000180AC39B0
	}

	// Constructors
	public Board(); // 0x0000000180A6C200-0x0000000180A6CDB0
	static Board(); // 0x0000000180A6CDB0-0x0000000180A6D2F0

	// Methods
	internal void Awake(); // 0x0000000180A34EA0-0x0000000180A355E0
	private void OnEnable(); // 0x0000000180A355E0-0x0000000180A35600
	private void Start(); // 0x0000000180A35600-0x0000000180A35A10
	private void OnValidate(); // 0x0000000180A35A10-0x0000000180A35D50
	private bool HasExplicitDotsParent(); // 0x0000000180A35D50-0x0000000180A35F50
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x0000000180A35F50-0x0000000180A37070
	private void EnsureRuntimeDotsParent(); // 0x0000000180A37070-0x0000000180A37520
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x0000000180A37520-0x0000000180A37B70
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x0000000180A37B70-0x0000000180A38160
	private Transform GetDotsAreaShellTransform(); // 0x0000000180A38160-0x0000000180A381A0
	private Transform GetDotsParent(); // 0x0000000180A381A0-0x0000000180A38380
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180A38380-0x0000000180A384B0
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x0000000180A384B0-0x0000000180A38BD0
	public Transform GetDotsParentTransform(); // 0x0000000180A38BD0-0x0000000180A38BE0
	internal bool TryTakePooledDot(string tag, Vector2 worldPos, out GameObject go); // 0x0000000180A39240-0x0000000180A39310
	internal void ReleaseDot(GameObject dot); // 0x0000000180A39310-0x0000000180A39430
	internal void ClearDotPool(); // 0x0000000180A39430-0x0000000180A39450
	public void PrepareDotsAreaForCoopSync(); // 0x0000000180A39450-0x0000000180A394D0
	internal bool HasFullDotGridSpawned(); // 0x0000000180A394D0-0x0000000180A396B0
	public void ApplyCoopBoardVisualFinishAfterNetworkSync(); // 0x0000000180A396B0-0x0000000180A39A10
	private GameObject ResolveDotsAreaRoot(); // 0x0000000180A39A10-0x0000000180A39B40
	private GameObject GetDotsVisibilityRoot(); // 0x0000000180A34D60-0x0000000180A34D70
	private Vector3 GetGridOriginWorld(); // 0x0000000180A39B40-0x0000000180A39E60
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x0000000180A39E60-0x0000000180A3A8A0
	private void UpdateDotsPlayfieldLayout(); // 0x0000000180A3A8A0-0x0000000180A3B050
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x0000000180610FD0-0x0000000180611390
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x0000000180A3B050-0x0000000180A3B300
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x0000000180A3B300-0x0000000180A3B500
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x0000000180A3B500-0x0000000180A3BAA0
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x0000000180A3BAA0-0x0000000180A3BE10
	private void InvalidateGridLayoutCache(); // 0x0000000180A3BE10-0x0000000180A3BE90
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180A3BE90-0x0000000180A3C0A0
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180A3C0A0-0x0000000180A3C8C0
	private void EnsureDotPrefabSpriteCache(); // 0x0000000180A3C8C0-0x0000000180A3CEE0
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x0000000180A3CEE0-0x0000000180A3CF30
	private void LateUpdate(); // 0x0000000180A3CF30-0x0000000180A3D480
	internal void MarkDotScaleDirty(); // 0x0000000180A3D480-0x0000000180A3D490
	private void Update(); // 0x0000000180A3D490-0x0000000180A3D520
	internal void WakeAllDots(); // 0x0000000180A3D520-0x0000000180A3D6A0
	private void WakeDriftedDots(); // 0x0000000180A3D6A0-0x0000000180A3D880
	private void ApplyDotScaleToFitGridCells(); // 0x0000000180A3D880-0x0000000180A3E220
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x0000000180A3E220-0x0000000180A3E600
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x0000000180A3E600-0x0000000180A3E660
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x0000000180A3E660-0x0000000180A3E6D0
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x0000000180A3E600-0x0000000180A3E660
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x0000000180A3E6D0-0x0000000180A3E760
	public Vector2 GetColyseusSpawnWorldPositionAboveBoard(int column); // 0x0000000180A3E760-0x0000000180A3E830
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x0000000180A3E830-0x0000000180A3E8E0
	private void ApplyDotsAreaBackgroundSprite(); // 0x0000000180A3E8E0-0x0000000180A3EBB0
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x0000000180A3EBB0-0x0000000180A3EE50
	public void RefreshDotsAreaBackgroundVisible(); // 0x0000000180A3EE50-0x0000000180A3EE60
	private void EnsureDotsAreaLayoutAndBackground(); // 0x0000000180A3EE60-0x0000000180A3F070
	private void ReparentStrayDotsIntoPlayfield(); // 0x0000000180A3F070-0x0000000180A3F6D0
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__254))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x0000000180A3F770-0x0000000180A3F890
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__255))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x0000000180A3F890-0x0000000180A3F9A0
	[IteratorStateMachine(typeof(_HandleUIWs_d__256))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, bool bossSide, bool wasFullPower); // 0x0000000180A3F9A0-0x0000000180A3FAD0
	public bool IsPlayerAllowedToMove(); // 0x0000000180A3FAD0-0x0000000180A3FD10
	public void EnsureBoardVisible(); // 0x0000000180A3FD10-0x0000000180A3FF30
	public void OpenInputForLocalTurnOnly(); // 0x0000000180A3FF30-0x0000000180A400F0
	private void HandleTurnStart(int entityIndex); // 0x000000018028A320-0x000000018028A330
	internal void HandleTurnEnd(); // 0x0000000180A400F0-0x0000000180A40240
	private void EnsureBossCountdownText(); // 0x0000000180A40240-0x0000000180A40AA0
	private void EnsureTowerHud(); // 0x0000000180A40AA0-0x0000000180A411D0
	private void HandleTowerTurnsChanged(int left); // 0x0000000180A411D0-0x0000000180A413D0
	private void ReleaseTowerHud(); // 0x0000000180A413D0-0x0000000180A41800
	[IteratorStateMachine(typeof(_BossDeadlineCountdownCoroutine_d__267))]
	private IEnumerator BossDeadlineCountdownCoroutine(); // 0x0000000180A41800-0x0000000180A418A0
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x0000000180A418A0-0x0000000180A41BB0
	public void ReturnToMenuSafely(); // 0x0000000180A41BB0-0x0000000180A41EF0
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x0000000180A41EF0-0x0000000180A42470
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x0000000180A42470-0x0000000180A42B00
	public void LoadGroupBackground(); // 0x0000000180A42B00-0x0000000180A42F30
	public void OnTurnStartNotify(int actorNumber); // 0x0000000180A42F30-0x0000000180A43710
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__274))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x0000000180A43710-0x0000000180A437C0
	internal void LoadAudioSettings(); // 0x0000000180A437C0-0x0000000180A43A80
	private int ResolveAuthoritativeEnemyPetId(); // 0x0000000180A43A80-0x0000000180A43BF0
	public void InitializeCards(); // 0x0000000180A43BF0-0x0000000180A44DE0
	private bool CardsHiddenThisMatch(); // 0x0000000180A44DE0-0x0000000180A45030
	private bool IsGuildBossMatch(); // 0x0000000180A45030-0x0000000180A450F0
	private bool SkillCardsHiddenThisMatch(); // 0x0000000180A450F0-0x0000000180A45120
	public void OnCardDataReady(CardData data); // 0x0000000180A45120-0x0000000180A451D0
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x0000000180A451D0-0x0000000180A45990
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x0000000180A45990-0x0000000180A45CF0
	[IteratorStateMachine(typeof(_HandleNetworkError_d__284))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x0000000180A45CF0-0x0000000180A45D90
	public int CalculateTrapPotential(int x, int y, string tag); // 0x0000000180A45D90-0x0000000180A46440
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x0000000180A46440-0x0000000180A46AF0
	public int GetDotMultiplier(GameObject dot); // 0x0000000180A46AF0-0x0000000180A46C90
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x0000000180A46C90-0x0000000180A472C0
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x0000000180A472C0-0x0000000180A47EC0
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x0000000180A47EC0-0x0000000180A48390
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x0000000180A48390-0x0000000180A48F50
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x0000000180A48F50-0x0000000180A492D0
	public int CountPlayerVangOpportunities(string[,] board); // 0x0000000180A492D0-0x0000000180A49430
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x0000000180A49430-0x0000000180A49800
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x0000000180A49800-0x0000000180A49AA0
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x005F07C2 */); // 0x0000000180A49AA0-0x0000000180A4A3B0
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x0000000180A4A3B0-0x0000000180A4AAC0
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x0000000180A4AAC0-0x0000000180A4B100
	public bool MatchesAt(int column, int row, GameObject piece); // 0x0000000180A4B100-0x0000000180A4B770
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180A4B770-0x0000000180A4BD70
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__301))]
	internal IEnumerator DecreaseRowCo(); // 0x0000000180A4BD70-0x0000000180A4BE10
	internal void ResetDestroyedCounts(); // 0x0000000180A4BE10-0x0000000180A4BE30
	[IteratorStateMachine(typeof(_AnimateDotsWaterfall_d__303))]
	private IEnumerator AnimateDotsWaterfall(); // 0x0000000180A4BE30-0x0000000180A4BED0
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__304))]
	public IEnumerator WaitAndDestroyMatches(); // 0x0000000180A4BED0-0x0000000180A4BF70
	public void DestroyMatches(); // 0x0000000180A4BF70-0x0000000180A4C0F0
	private void StartCascade(IEnumerator routine); // 0x0000000180A4C0F0-0x0000000180A4C1C0
	internal void StopCascadePipeline(); // 0x0000000180A4C1C0-0x0000000180A4C250
	internal void DestroyOrphanDotsUnderDotsParent(bool immediate); // 0x0000000180A4C250-0x0000000180A4CB20
	public void DestroyRandomDots(int count); // 0x0000000180A4CB20-0x0000000180A4CBE0
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__310))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x0000000180A4CBE0-0x0000000180A4CC90
	public void RefillBoard(); // 0x0000000180A4CC90-0x0000000180A4CDD0
	private void RefillBoardNonDeterministic(); // 0x0000000180A4CDD0-0x0000000180A4D460
	private static Font GetMultiplierFont(); // 0x0000000180A4D460-0x0000000180A4D5F0
	private static Color ParseHexOr(string hex, Color fallback); // 0x0000000180A4D5F0-0x0000000180A4D6C0
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x0000000180A4D6C0-0x0000000180A4E730
	public bool MatchesOnBoard(); // 0x0000000180A4E730-0x0000000180A4E910
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__320))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x0000000180A4E910-0x0000000180A4E9B0
	private static int DestroyOrderIndexOf(string tag); // 0x0000000180A4E9B0-0x0000000180A4EB20
	internal void displayDestroy(); // 0x0000000180A4EB20-0x0000000180A4FA80
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__326))]
	internal IEnumerator ResumeAndSyncState(); // 0x0000000180A4FA80-0x0000000180A4FB20
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__327))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool serverAuthoritative = false /* Metadata: 0x005F07C3 */, bool aborted = false /* Metadata: 0x005F07C4 */); // 0x0000000180A4FB20-0x0000000180A4FBF0
	[IteratorStateMachine(typeof(_ShowMatchAbortedPanel_d__328))]
	private IEnumerator ShowMatchAbortedPanel(); // 0x0000000180A4FBF0-0x0000000180A4FC90
	[IteratorStateMachine(typeof(_DisplayCoopReward_d__329))]
	internal IEnumerator DisplayCoopReward(int gold, int exp); // 0x0000000180A4FC90-0x0000000180A4FD50
	private void HookLateRewardPush(); // 0x0000000180A4FD50-0x0000000180A50020
	private void UnhookLateRewardPush(); // 0x0000000180A50020-0x0000000180A501C0
	private void HandleLateRewardPush(string matchId); // 0x0000000180A501C0-0x0000000180A50340
	private void SpawnPetShardReward(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A50340-0x0000000180A51110
	private void SpawnWeaponShardReward(int amount); // 0x0000000180A51110-0x0000000180A518E0
	private void SpawnGuildContribReward(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A518E0-0x0000000180A522E0
	private void SpawnSweepTicketReward(long itemId, int amount, string label); // 0x0000000180A522E0-0x0000000180A52C40
	private void SpawnWeaponReward(WeaponDropDTO drop); // 0x0000000180A52C40-0x0000000180A53B20
	private static Image FindRewardIcon(GameObject item); // 0x0000000180A53B20-0x0000000180A54010
	private static void SetRewardCountText(GameObject item, string text); // 0x0000000180A54010-0x0000000180A54260
	private void SpawnTowerRewards(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180A54260-0x0000000180A54F60
	private void SpawnTowerBundle(TowerGiftBundle g); // 0x0000000180A54F60-0x0000000180A55190
	private void SpawnTowerEntry(RewardDisplayHelper.Entry e); // 0x0000000180A55190-0x0000000180A55780
	private GameObject TowerFrame(string type, out bool exact); // 0x0000000180A55780-0x0000000180A55FA0
	private static string TowerAmountText(RewardDisplayHelper.Entry e); // 0x0000000180A55FA0-0x0000000180A565E0
	private GameObject SpawnRewardItem(GameObject prefab, string text, string tipType = null); // 0x0000000180A565E0-0x0000000180A568D0
	private static void ApplyCtIcon(GameObject item); // 0x0000000180A568D0-0x0000000180A56B40
	private static void ApplyRankIcon(GameObject item); // 0x0000000180A56B40-0x0000000180A57250
	private void AnimateRewardReveal(GameObject item); // 0x0000000180A57250-0x0000000180A574F0
	private float GetRewardRevealTotalSeconds(int itemCount); // 0x0000000180A574F0-0x0000000180A57520
	private void ShowBtnGetWithAnim(); // 0x0000000180A57520-0x0000000180A577E0
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x005F07C5 */); // 0x0000000180A577E0-0x0000000180A57A80
	public void HideMega1Animation(); // 0x0000000180A57A80-0x0000000180A57E50
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x005F07C6 */); // 0x0000000180A57E50-0x0000000180A581D0
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__367))]
	private IEnumerator AutoHideMega1Animation(); // 0x0000000180A581D0-0x0000000180A58270
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x0000000180A58270-0x0000000180A58940
	public void ClearAllMega2Hints(); // 0x0000000180A58940-0x0000000180A58C70
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x0000000180A59000-0x0000000180A59A60
	private void StopMegaIcarusWorldFx(); // 0x0000000180A59A60-0x0000000180A59BE0
	private void RequestHideMegaIcarusWorldFx(); // 0x0000000180A59BE0-0x0000000180A59D60
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x005F07C7 */); // 0x0000000180A59D60-0x0000000180A5A1A0
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x0000000180A5A1A0-0x0000000180A5AD50
	public void ClearAllMegaIcarusHints(); // 0x0000000180A5AD50-0x0000000180A5B090
	public void ShowMegaIcarusMarks(List<MegaIcarusMark> cells); // 0x0000000180A5B090-0x0000000180A5BD50
	private bool NudgeExistingMultiplierLabel(GameObject dot); // 0x0000000180A5BD50-0x0000000180A5C990
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x0000000180A5C990-0x0000000180A5D160
	public void ClearAllMegaIcarusMarks(); // 0x0000000180A5D160-0x0000000180A5D7D0
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x005F07C8 */); // 0x0000000180A5D7D0-0x0000000180A5DCB0
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__394))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x0000000180A5DCB0-0x0000000180A5DDD0
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180A5DDD0-0x0000000180A5E390
	public void ClearAllGalaxyHints(); // 0x0000000180A5E390-0x0000000180A5E830
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__397))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180A5E830-0x0000000180A5E940
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x0000000180A5E940-0x0000000180A5EDC0
	public void ReturnToMenu(); // 0x0000000180A5EDC0-0x0000000180A5F0C0
	private void ClearRoomRestoreFlags(); // 0x0000000180A5F0C0-0x0000000180A5F1E0
	public void ReturnToQuangTruongFromBoss(); // 0x0000000180A5F1E0-0x0000000180A5F3E0
	private bool PrepareTowerReturn(); // 0x0000000180A5F3E0-0x0000000180A5F470
	private bool PrepareGuildRaidReturn(); // 0x0000000180A5F470-0x0000000180A5F4D0
	private void SetupGuildRaidResultPanel(bool playerWon); // 0x0000000180A5F4D0-0x0000000180A60420
	private static void EnsureRaidStyleKey(GameObject go, string key); // 0x0000000180A60420-0x0000000180A60650
	private UnityEngine.UI.Text EnsureRaidResultText(string nodeName, UnityEngine.UI.Text sample, Vector2 pos, int fontSize, string otaKey); // 0x0000000180A60650-0x0000000180A61100
	private void EnsureRaidFightAgainButton(UnityEngine.UI.Text sample); // 0x0000000180A61100-0x0000000180A62180
	internal int CalculateExpByLevel(int level); // 0x0000000180624E30-0x0000000180624E70
	internal int CalculateTotalStones(int turnCount); // 0x0000000180624E70-0x0000000180624EB0
	internal int RollStoneLevel(int turnCount); // 0x0000000180A62180-0x0000000180A62400
	internal Sprite GetStoneSprite(string element, int level); // 0x0000000180A62400-0x0000000180A626D0
	internal bool CheckBoardStable(); // 0x0000000180A626D0-0x0000000180A628C0
	[IteratorStateMachine(typeof(_FadeOut_d__413))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x0000000180A628C0-0x0000000180A62980
	internal Dot DotCompAt(int x, int y); // 0x0000000180A62980-0x0000000180A62DB0
	private void SetDotsRenderVisible(bool visible); // 0x0000000180A62DD0-0x0000000180A62F60
	private void SnapAllDotsToGrid(); // 0x0000000180A62F60-0x0000000180A63460
	public void ShowItems(); // 0x0000000180A63460-0x0000000180A63F10
	public void HideAllItems(); // 0x0000000180A63F10-0x0000000180A64980
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__425))]
	public IEnumerator HideAllItemsEnd(); // 0x0000000180A64980-0x0000000180A64A20
	public void ResetMoveCounters(); // 0x0000000180A400F0-0x0000000180A40240
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x0000000180A64A20-0x0000000180A64D40
	private static int LongestConsecutiveSpanOnAxis(List<int> sortedAsc); // 0x0000000180A64D40-0x0000000180A64E50
	public ValueTuple<int, int, int> ComputeBossSwordLineMetrics(GameObject movedDot, int targetX, int targetY); // 0x0000000180A64E50-0x0000000180A65BA0
	private void LoadCardsFromPlayerPrefs(); // 0x0000000180A65BA0-0x0000000180A65D30
	private void CreateCardHT(CardData cardData); // 0x0000000180A65D30-0x0000000180A66460
	public void LoadSelectedCards(List<CardData> cards); // 0x0000000180A66460-0x0000000180A66850
	private void DisplayCardsOnBoard(); // 0x0000000180A66850-0x0000000180A66930
	public void EnsureFusionCards(); // 0x0000000180A66930-0x0000000180A67140
	private void RemoveFusionCard(); // 0x0000000180A67140-0x0000000180A673E0
	public void AddFusionSkillCard(CardData cardData); // 0x0000000180A673E0-0x0000000180A67BF0
	private CardUI FindWiredSkillCardUI(); // 0x0000000180A67BF0-0x0000000180A680C0
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x0000000180A680C0-0x0000000180A68790
	private void ClearCards(); // 0x0000000180A68790-0x0000000180A68CC0
	public void LeaveMatchAfterGameOver(); // 0x0000000180A68CC0-0x0000000180A68FC0
	public void LeaveMatchMidGame(); // 0x0000000180A68FC0-0x0000000180A69220
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__443))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x0000000180A69220-0x0000000180A692C0
	private void GoToMainScene(); // 0x0000000180A692C0-0x0000000180A69370
	private void FastReturnToRoom(); // 0x0000000180A69370-0x0000000180A69620
	internal void ReturnToQuangTruong(); // 0x0000000180A69620-0x0000000180A697E0
	public bool HasValidMoves(); // 0x0000000180A697E0-0x0000000180A69BD0
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x0000000180A69BD0-0x0000000180A69ED0
	internal bool CheckMatchAt(int col, int row, string tag); // 0x0000000180A69ED0-0x0000000180A6A4A0
	[IteratorStateMachine(typeof(_ResetBoardWhenNoMoves_d__451))]
	public IEnumerator ResetBoardWhenNoMoves(); // 0x0000000180A6A4A0-0x0000000180A6A540
	public void InitializeCardsClientOnly(); // 0x0000000180A6A540-0x0000000180A6B500
	public void SetBoardState(GameState state); // 0x0000000180A6B500-0x0000000180A6B510
	public void GrayOutPlayerAvatar(int actorNumber); // 0x0000000180A6B510-0x0000000180A6B5E0
	public void ShowPlayerExitNotice(string playerName, int actorNumber = 0 /* Metadata: 0x005F07CC */); // 0x0000000180A6B5E0-0x0000000180A6B6A0
	public void RestorePlayerAvatar(int actorNumber); // 0x0000000180A6B6A0-0x0000000180A6B740
	public bool HasLeftMatch(int actorNumber); // 0x0000000180A6B740-0x0000000180A6B7A0
	private void ApplyAvatarTintIfDisplayed(int actorNumber, Color tint, bool isLeft); // 0x0000000180A6B7A0-0x0000000180A6BBB0
	internal void OnMouseDown(); // 0x0000000180A4BE10-0x0000000180A4BE30
	internal void OnDestroy(); // 0x0000000180A6BBB0-0x0000000180A6C110
	internal void OnApplicationQuit(); // 0x0000000180A6C110-0x0000000180A6C200
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_233_0(Transform t, ref __c__DisplayClass233_0 param_00002fac); // 0x0000000180A6D2F0-0x0000000180A6D630
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__327_0(); // 0x0000000180A6D630-0x0000000180A6D640
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__327_1(); // 0x0000000180A6D630-0x0000000180A6D640
	[CompilerGenerated]
	private void _ShowMatchAbortedPanel_b__328_0(); // 0x0000000180A6D630-0x0000000180A6D640
	[CompilerGenerated]
	private void _SetupGuildRaidResultPanel_b__404_0(); // 0x0000000180A6D640-0x0000000180A6D650
	[CompilerGenerated]
	private void _SetupGuildRaidResultPanel_b__404_1(); // 0x0000000180A6D650-0x0000000180A6D7F0
}

