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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class Board : MonoBehaviour // TypeDefIndex: 1576
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
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x0064D776
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
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x0064D784
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
	private const float CASCADE_WATCHDOG_SECONDS = 12f; // Metadata: 0x0064D788
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
	public UnityEngine.UI.Text txtResultTitle; // 0x280
	public Button btnGet; // 0x288
	public Sprite[] fireStones; // 0x290
	public Sprite[] waterStones; // 0x298
	public Sprite[] earthStones; // 0x2A0
	public Sprite[] windStones; // 0x2A8
	public Sprite[] electricStones; // 0x2B0
	internal bool isGameOver; // 0x2B8
	internal readonly HashSet<int> _leftActorNumbers; // 0x2C0
	private static readonly Color GRAY_TINT; // 0x00
	internal string enemyPetElement; // 0x2C8
	internal int enemyPetId; // 0x2D0
	internal int currentCount; // 0x2D4
	internal int requestPass; // 0x2D8
	internal float lastAutoMoveTime; // 0x2DC
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x0064D78C
	internal bool isBossBattle; // 0x2E0
	internal bool isTowerBattle; // 0x2E1
	private TowerTurnHud _towerHud; // 0x2E8
	private bool _towerHudHooked; // 0x2F0
	public GameObject cardPrefab; // 0x2F8
	public Transform cardContainer; // 0x300
	public int maxCardsInHand; // 0x308
	public float cardSpacing; // 0x30C
	public float cardYPosition; // 0x310
	public float cardAnimDuration; // 0x314
	internal List<CardData> selectedCards; // 0x318
	internal List<GameObject> cardsInHand; // 0x320
	public CardData cardData; // 0x328
	internal int HOTTURN; // 0x330
	internal int SUBHOTTURN; // 0x334
	public GameObject energyWarningPanel; // 0x338
	public UnityEngine.UI.Text energyWarningText; // 0x340
	public Button energyWarningButton; // 0x348
	internal bool hasShownEnergyWarning; // 0x350
	internal int lastCheckedEnergy; // 0x354
	internal AudioSettingsManager audioSettingsManager; // 0x358
	public Image boardBackground; // 0x360
	internal bool isBoardReady; // 0x368
	internal bool isUsingLegendCard; // 0x369
	internal float legendDamageMultiplier; // 0x36C
	internal bool isUsingMega; // 0x370
	internal int currentDamageMultiplier; // 0x374
	public GameObject imgPDef; // 0x378
	public GameObject imgEDef; // 0x380
	internal bool isResuming; // 0x388
	internal Coroutine resumeSyncCoroutine; // 0x390
	[CompilerGenerated]
	private static Board _Instance_k__BackingField; // 0x10
	private RectTransform _cachedPlayfieldMaskOwner; // 0x398
	private RectMask2D _cachedPlayfieldMask; // 0x3A0
	private RectTransform _cachedDotsAreaFrameImageOwner; // 0x3A8
	private Image _cachedDotsAreaFrameImage; // 0x3B0
	private int _gridLayoutCacheFrame; // 0x3B8
	private bool _gridLayoutCacheOk; // 0x3BC
	private RectTransform _gridLayoutCacheArea; // 0x3C0
	private float _gridLayoutCacheCellW; // 0x3C8
	private float _gridLayoutCacheCellH; // 0x3CC
	private Rect _gridLayoutCacheRect; // 0x3D0
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x0064D790
	[Header("T\u1ED1c \u0111\u1ED9 x\u1EED l\u00FD vi\u00EAn (HandleUI)")]
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD m\u1ED7i lo\u1EA1i vi\u00EAn th\u01B0\u1EDDng (sau animation damage).")]
	private float handleUI_waitPerNormalGem; // 0x3E0
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD vi\u00EAn v\u00E0ng (s).")]
	private float handleUI_waitPerVangGem; // 0x3E4
	[SerializeField]
	[Tooltip("Kho\u1EA3ng ngh\u1EC9 ng\u1EAFn sau c\u1EADp nh\u1EADt slider, tr\u01B0\u1EDBc b\u01B0\u1EDBc ti\u1EBFp.")]
	private float handleUI_pauseAfterSliderNormal; // 0x3E8
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; // 0x3EC
	[Header("Pet animation duration cho vi\u00EAn ki\u1EBFm (vang Dot)")]
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation Attack b\u00ECnh th\u01B0\u1EDDng (key=1). Ch\u1EDD \u0111\u1EE7 tr\u01B0\u1EDBc khi reset animator.")]
	private float vangAttackAnimDuration; // 0x3F0
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation AttackPower khi \u0111\u1EE7 n\u1ED9 (key=2).")]
	private float vangAttackPowerAnimDuration; // 0x3F4
	[SerializeField]
	private float destructionEntryPulseSeconds; // 0x3F8
	[SerializeField]
	private float destructionEntryShrinkSeconds; // 0x3FC
	private Coroutine _bossDeadlineCo; // 0x400
	private static Font _multiplierFont; // 0x18
	private static readonly string[] DestroyDisplayOrder; // 0x20
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x408
	private readonly List<GameObject> _destroyEntryPool; // 0x410
	private bool _rewardPanelBuilt; // 0x418
	private bool _weaponRewardShown; // 0x419
	private bool _petShardRewardShown; // 0x41A
	private bool _lateRewardHooked; // 0x41B
	private const float REWARD_REVEAL_STAGGER = 0.12f; // Metadata: 0x0064D794
	private const float REWARD_REVEAL_DURATION = 0.35f; // Metadata: 0x0064D798
	[SerializeField]
	private float mega1AnimDuration; // 0x41C
	private Coroutine _mega1AnimCoroutine; // 0x420
	internal bool isMega1PanelOpen; // 0x428
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x0064D79C
	private Coroutine _megaIcarusAnimCoroutine; // 0x430
	private SpriteRenderer _megaIcarusFxHost; // 0x438
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x0064D7AB
	private readonly List<GameObject> _megaIcarusMarks; // 0x440
	private readonly List<GameObject> _megaIcarusHiddenLabels; // 0x448
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x0064D7BA
	private Coroutine _galaxyScanCoroutine; // 0x450
	public const long FUSION_CARD_ID = -777; // Metadata: 0x0064D7C5
	private static readonly int[][] SwapDirections; // 0x28
	private HashSet<int> _shownExitNoticeActors; // 0x458

	// Properties
	public GameObject ResolvedDotsArea { get; } // 0x000000018058BDB0-0x000000018058BDC0 
	public bool IsBoardReady { get; } // 0x000000018059B4D0-0x000000018059B4E0 
	public static Board Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018059B480-0x000000018059B4D0 0x000000018059B650-0x000000018059B6C0
	internal float HandleUIWaitNormal { get; } // 0x000000018059B440-0x000000018059B460 
	internal float HandleUIWaitVang { get; } // 0x000000018059B460-0x000000018059B480 
	internal float HandleUIPauseNormal { get; } // 0x000000018059B400-0x000000018059B420 
	internal float HandleUIPauseVang { get; } // 0x000000018059B420-0x000000018059B440 
	internal float VangAttackAnimDuration { get; } // 0x000000018059B630-0x000000018059B640 
	internal float VangAttackPowerAnimDuration { get; } // 0x000000018059B640-0x000000018059B650 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x000000018059B4E0-0x000000018059B630 

	// Nested types
	[Serializable]
	public class PetRewardRequest // TypeDefIndex: 1577
	{
		// Fields
		public int petId; // 0x10
		public bool victory; // 0x14

		// Constructors
		public PetRewardRequest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class PetRewardResponse // TypeDefIndex: 1578
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
		public PetRewardResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class StoneRewardInfo // TypeDefIndex: 1579
	{
		// Fields
		public string element; // 0x10
		public int level; // 0x18
		public int quantity; // 0x1C

		// Constructors
		public StoneRewardInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class ApiResponse<T> // TypeDefIndex: 1580
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
	private sealed class __c // TypeDefIndex: 1581
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__294_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__297_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__297_1; // 0x18
		public static Func<StoneRewardInfo, int> __9__351_0; // 0x20
		public static Func<StoneRewardInfo, string> __9__351_1; // 0x28
		public static Func<GameObject, bool> __9__368_0; // 0x30
		public static Func<Vector2Int, int> __9__370_0; // 0x38
		public static Func<Vector2Int, int> __9__370_1; // 0x40
		public static Func<int, int> __9__370_2; // 0x48
		public static Func<Vector2Int, int> __9__370_3; // 0x50
		public static Func<Vector2Int, int> __9__370_4; // 0x58
		public static Func<int, int> __9__370_5; // 0x60
		public static Func<CardData, bool> __9__373_0; // 0x68

		// Constructors
		static __c(); // 0x00000001805AC170-0x00000001805AC1E0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _displayDestroy_b__294_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x00000001805ABD80-0x00000001805ABE30
		internal int _DisplayCoopReward_b__297_0(StoneRewardInfo s); // 0x000000018030F1E0-0x000000018030F200
		internal string _DisplayCoopReward_b__297_1(StoneRewardInfo s); // 0x000000018052BA80-0x000000018052BAA0
		internal int _DisplayRewardFromServer_b__351_0(StoneRewardInfo s); // 0x000000018030F1E0-0x000000018030F200
		internal string _DisplayRewardFromServer_b__351_1(StoneRewardInfo s); // 0x000000018052BA80-0x000000018052BAA0
		internal bool _CalculatePotentialVangDotDestruction_b__368_0(GameObject g); // 0x00000001805ABCA0-0x00000001805ABD30
		internal int _ComputeBossSwordLineMetrics_b__370_0(Vector2Int p); // 0x00000001805ABD30-0x00000001805ABD40
		internal int _ComputeBossSwordLineMetrics_b__370_1(Vector2Int p); // 0x000000018030F1D0-0x000000018030F1E0
		internal int _ComputeBossSwordLineMetrics_b__370_2(int v); // 0x000000018030F1D0-0x000000018030F1E0
		internal int _ComputeBossSwordLineMetrics_b__370_3(Vector2Int p); // 0x000000018030F1D0-0x000000018030F1E0
		internal int _ComputeBossSwordLineMetrics_b__370_4(Vector2Int p); // 0x00000001805ABD30-0x00000001805ABD40
		internal int _ComputeBossSwordLineMetrics_b__370_5(int v); // 0x000000018030F1D0-0x000000018030F1E0
		internal bool _LoadSelectedCards_b__373_0(CardData c); // 0x000000018052BB00-0x000000018052BB10
	}

	[CompilerGenerated]
	private struct __c__DisplayClass209_0 // TypeDefIndex: 1582
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 1583
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass231_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x00000001805ABE30-0x00000001805ABEA0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass296_0 // TypeDefIndex: 1584
	{
		// Fields
		public Animator animator; // 0x10
		public float t; // 0x18
		public float timeout; // 0x1C

		// Constructors
		public __c__DisplayClass296_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _ShowGameResultIntegrated_b__2(); // 0x00000001805ABEA0-0x00000001805ABF40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass297_0 // TypeDefIndex: 1585
	{
		// Fields
		public GameObject petReward; // 0x10

		// Constructors
		public __c__DisplayClass297_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _DisplayCoopReward_b__2(); // 0x00000001805ABF40-0x00000001805AC020
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass309_0 // TypeDefIndex: 1586
	{
		// Fields
		public Transform cell; // 0x10

		// Constructors
		public __c__DisplayClass309_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SpawnTowerRewards_b__0(); // 0x00000001805AC020-0x00000001805AC110
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass352_0 // TypeDefIndex: 1587
	{
		// Fields
		public int level; // 0x10
		public Board __4__this; // 0x18

		// Constructors
		public __c__DisplayClass352_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x00000001805AC110-0x00000001805AC170
	}

	[CompilerGenerated]
	private sealed class _AnimateDotsWaterfall_d__275 : IEnumerator<object> // TypeDefIndex: 1588
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private float _maxDur_5__2; // 0x28
		private float _maxColDelay_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnimateDotsWaterfall_d__275(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059EC70-0x000000018059EFD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059EFD0-0x000000018059F010
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__324 : IEnumerator<object> // TypeDefIndex: 1589
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__324(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059F210-0x000000018059F2F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059F2F0-0x000000018059F330
	}

	[CompilerGenerated]
	private sealed class _BossDeadlineCountdownCoroutine_d__242 : IEnumerator<object> // TypeDefIndex: 1590
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private bool _timeoutToastShown_5__2; // 0x28
		private WaitForSecondsRealtime _wait_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BossDeadlineCountdownCoroutine_d__242(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018059F450-0x000000018059F640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059F640-0x000000018059F680
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__289 : IEnumerator<object> // TypeDefIndex: 1591
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__289(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059F680-0x000000018059F920
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059F920-0x000000018059F960
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__231 : IEnumerator<object> // TypeDefIndex: 1592
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass231_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__231(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018059F960-0x000000018059FE80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059FE80-0x000000018059FEC0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__230 : IEnumerator<object> // TypeDefIndex: 1593
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Board __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__230(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059FEC0-0x000000018059FFC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059FFC0-0x00000001805A0000
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__273 : IEnumerator<object> // TypeDefIndex: 1594
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__273(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A0000-0x00000001805A0C00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A0C00-0x00000001805A0C40
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__282 : IEnumerator<object> // TypeDefIndex: 1595
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__282(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A0C40-0x00000001805A0F50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A0F50-0x00000001805A0F90
	}

	[CompilerGenerated]
	private sealed class _DisplayCoopReward_d__297 : IEnumerator<object> // TypeDefIndex: 1596
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public int gold; // 0x28
		public int exp; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayCoopReward_d__297(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A0F90-0x00000001805A2D30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A2D30-0x00000001805A2D70
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__351 : IEnumerator<object> // TypeDefIndex: 1597
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__351(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A2D70-0x00000001805A42E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A42E0-0x00000001805A4320
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__362 : IEnumerator<object> // TypeDefIndex: 1598
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CanvasGroup canvasGroup; // 0x20
		public float duration; // 0x28
		private float _elapsedTime_5__2; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__362(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A4AA0-0x00000001805A4CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4CF0-0x00000001805A4D30
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__348 : IEnumerator<object> // TypeDefIndex: 1599
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__348(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x00000001805A4D30-0x00000001805A5430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A5430-0x00000001805A5470
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__256 : IEnumerator<object> // TypeDefIndex: 1600
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__256(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A5540-0x00000001805A57D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A57D0-0x00000001805A5810
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__232 : IEnumerator<object> // TypeDefIndex: 1601
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

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleUIWs_d__232(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001805A5810-0x00000001805A6700
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A6700-0x00000001805A6740
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__366 : IEnumerator<object> // TypeDefIndex: 1602
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideAllItemsEnd_d__366(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805285C0-0x0000000180528610
		private bool MoveNext(); // 0x00000001805A6740-0x00000001805A6B10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A6B10-0x00000001805A6B50
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__384 : IEnumerator<object> // TypeDefIndex: 1603
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__384(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A6B50-0x00000001805A6D70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A6D70-0x00000001805A6DB0
	}

	[CompilerGenerated]
	private sealed class _ResetBoardWhenNoMoves_d__392 : IEnumerator<object> // TypeDefIndex: 1604
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResetBoardWhenNoMoves_d__392(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A9520-0x00000001805A9E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A9E50-0x00000001805A9E90
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__295 : IEnumerator<object> // TypeDefIndex: 1605
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20
		private MatchService _msvc_5__2; // 0x28
		private float _wsTimeout_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__295(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001805A9FA0-0x00000001805AA320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AA320-0x00000001805AA360
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__296 : IEnumerator<object> // TypeDefIndex: 1606
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__296(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001805AAB30-0x00000001805ABBB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ABBB0-0x00000001805ABBF0
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__249 : IEnumerator<object> // TypeDefIndex: 1607
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int currentTurnActor; // 0x20
		public Board __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__249(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805AC300-0x00000001805ACA00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ACA00-0x00000001805ACA40
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__276 : IEnumerator<object> // TypeDefIndex: 1608
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Board __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__276(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805ACA40-0x00000001805ACD80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ACD80-0x00000001805ACDC0
	}

	// Constructors
	public Board(); // 0x000000018059A850-0x000000018059ADE0
	static Board(); // 0x000000018059A540-0x000000018059A850

	// Methods
	internal void Awake(); // 0x000000018057FC90-0x00000001805801C0
	private void OnEnable(); // 0x00000001805912C0-0x00000001805912E0
	private void Start(); // 0x00000001805992D0-0x0000000180599530
	private void OnValidate(); // 0x00000001805918F0-0x0000000180591AB0
	private bool HasExplicitDotsParent(); // 0x000000018058C910-0x000000018058C9A0
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x00000001805905C0-0x0000000180590E60
	private void EnsureRuntimeDotsParent(); // 0x000000018058A040-0x000000018058A250
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x0000000180592830-0x0000000180592A30
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x000000018057EB30-0x000000018057EE10
	private Transform GetDotsAreaShellTransform(); // 0x000000018058BC80-0x000000018058BCC0
	private Transform GetDotsParent(); // 0x000000018058BCD0-0x000000018058BDB0
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180588C70-0x0000000180588D30
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x000000018058A570-0x000000018058A830
	public Transform GetDotsParentTransform(); // 0x000000018058BCC0-0x000000018058BCD0
	public void PrepareDotsAreaForCoopSync(); // 0x0000000180591AB0-0x0000000180591B40
	internal bool HasFullDotGridSpawned(); // 0x000000018058C9A0-0x000000018058CAE0
	public void ApplyCoopBoardVisualFinishAfterNetworkSync(); // 0x000000018057F230-0x000000018057F350
	private GameObject ResolveDotsAreaRoot(); // 0x0000000180592C80-0x0000000180592D30
	private GameObject GetDotsVisibilityRoot(); // 0x000000018058BDB0-0x000000018058BDC0
	private Vector3 GetGridOriginWorld(); // 0x000000018058BDC0-0x000000018058BEC0
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x0000000180588D30-0x00000001805890C0
	private void UpdateDotsPlayfieldLayout(); // 0x0000000180599D50-0x000000018059A1A0
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x000000018040CE70-0x000000018040D180
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x000000018058BF90-0x000000018058C0A0
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x000000018058B890-0x000000018058B960
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x000000018058B960-0x000000018058BC80
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x000000018057FA40-0x000000018057FC20
	private void InvalidateGridLayoutCache(); // 0x000000018058EB70-0x000000018058EBA0
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180599880-0x0000000180599980
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x00000001805855F0-0x0000000180585AA0
	private void EnsureDotPrefabSpriteCache(); // 0x0000000180588770-0x0000000180588A10
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x0000000180599830-0x0000000180599880
	private void LateUpdate(); // 0x000000018058F130-0x000000018058F400
	private void ApplyDotScaleToFitGridCells(); // 0x000000018057F350-0x000000018057F8D0
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x000000018058B180-0x000000018058B5B0
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x000000018058B830-0x000000018058B890
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x000000018058B7C0-0x000000018058B830
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x000000018058B830-0x000000018058B890
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x000000018058B730-0x000000018058B7C0
	public Vector2 GetColyseusSpawnWorldPositionAboveBoard(int column); // 0x000000018058B5B0-0x000000018058B680
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x000000018058C0D0-0x000000018058C180
	private void ApplyDotsAreaBackgroundSprite(); // 0x000000018057F8D0-0x000000018057FA40
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x00000001805936C0-0x00000001805937C0
	public void RefreshDotsAreaBackgroundVisible(); // 0x0000000180592230-0x0000000180592240
	private void EnsureDotsAreaLayoutAndBackground(); // 0x0000000180588A10-0x0000000180588C70
	private void ReparentStrayDotsIntoPlayfield(); // 0x0000000180592570-0x0000000180592830
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__230))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x0000000180585B30-0x0000000180585BD0
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__231))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x0000000180585AA0-0x0000000180585B30
	[IteratorStateMachine(typeof(_HandleUIWs_d__232))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, bool bossSide, bool wasFullPower); // 0x000000018058C850-0x000000018058C910
	public bool IsPlayerAllowedToMove(); // 0x000000018058EBA0-0x000000018058ECF0
	public void EnsureBoardVisible(); // 0x0000000180588120-0x0000000180588280
	private void HandleTurnStart(int entityIndex); // 0x00000001802E76C0-0x00000001802E76D0
	internal void HandleTurnEnd(); // 0x000000018058C7A0-0x000000018058C850
	private void EnsureBossCountdownText(); // 0x0000000180588280-0x0000000180588770
	private void EnsureTowerHud(); // 0x000000018058A250-0x000000018058A570
	private void HandleTowerTurnsChanged(int left); // 0x000000018058C650-0x000000018058C7A0
	private void ReleaseTowerHud(); // 0x0000000180592240-0x0000000180592470
	[IteratorStateMachine(typeof(_BossDeadlineCountdownCoroutine_d__242))]
	private IEnumerator BossDeadlineCountdownCoroutine(); // 0x00000001805801C0-0x0000000180580230
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x0000000180599B60-0x0000000180599D50
	public void ReturnToMenuSafely(); // 0x0000000180592E40-0x0000000180593030
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x0000000180580230-0x00000001805806A0
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x0000000180581810-0x0000000180581CF0
	public void LoadGroupBackground(); // 0x000000018058FC40-0x000000018058FE30
	public void OnTurnStartNotify(int actorNumber); // 0x0000000180591310-0x00000001805918F0
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__249))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x000000018059A1A0-0x000000018059A220
	internal void LoadAudioSettings(); // 0x000000018058F850-0x000000018058F9C0
	private int ResolveAuthoritativeEnemyPetId(); // 0x0000000180592B50-0x0000000180592C80
	public void InitializeCards(); // 0x000000018058E080-0x000000018058EB70
	public void OnCardDataReady(CardData data); // 0x0000000180590F00-0x0000000180590F50
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x0000000180586DC0-0x0000000180587350
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x0000000180581560-0x0000000180581810
	[IteratorStateMachine(typeof(_HandleNetworkError_d__256))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x000000018058C5E0-0x000000018058C650
	public int CalculateTrapPotential(int x, int y, string tag); // 0x0000000180580E90-0x0000000180581560
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x0000000180595C00-0x00000001805960C0
	public int GetDotMultiplier(GameObject dot); // 0x000000018058B680-0x000000018058B730
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x00000001805809E0-0x0000000180580E90
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x0000000180584050-0x0000000180584950
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x000000018058ECF0-0x000000018058F130
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x00000001805960C0-0x00000001805968B0
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x00000001805958C0-0x0000000180595C00
	public int CountPlayerVangOpportunities(string[,] board); // 0x0000000180585BD0-0x0000000180585D00
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x0000000180581CF0-0x00000001805820E0
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x0000000180582710-0x0000000180582930
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x0064D76C */); // 0x00000001805968B0-0x0000000180597080
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x0000000180582260-0x00000001805826A0
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x0000000180582D30-0x0000000180583300
	public bool MatchesAt(int column, int row, GameObject piece); // 0x0000000180590080-0x0000000180590440
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180587350-0x00000001805876D0
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__273))]
	internal IEnumerator DecreaseRowCo(); // 0x0000000180586D50-0x0000000180586DC0
	internal void ResetDestroyedCounts(); // 0x00000001805912E0-0x0000000180591310
	[IteratorStateMachine(typeof(_AnimateDotsWaterfall_d__275))]
	private IEnumerator AnimateDotsWaterfall(); // 0x000000018057EE10-0x000000018057EE80
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__276))]
	public IEnumerator WaitAndDestroyMatches(); // 0x000000018059A220-0x000000018059A290
	public void DestroyMatches(); // 0x00000001805876D0-0x0000000180587840
	private void StartCascade(IEnumerator routine); // 0x0000000180599270-0x00000001805992D0
	internal void StopCascadePipeline(); // 0x0000000180599530-0x0000000180599590
	internal void DestroyOrphanDotsUnderDotsParent(bool immediate); // 0x0000000180587940-0x0000000180587E50
	public void DestroyRandomDots(int count); // 0x0000000180587ED0-0x0000000180587F60
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__282))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x0000000180587E50-0x0000000180587ED0
	public void RefillBoard(); // 0x00000001805920F0-0x0000000180592230
	private void RefillBoardNonDeterministic(); // 0x0000000180591B80-0x00000001805920F0
	private static Font GetMultiplierFont(); // 0x000000018058BEC0-0x000000018058BF90
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x00000001805866A0-0x0000000180586D50
	public bool MatchesOnBoard(); // 0x0000000180590440-0x00000001805905C0
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__289))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x00000001805826A0-0x0000000180582710
	private static int DestroyOrderIndexOf(string tag); // 0x0000000180587840-0x0000000180587940
	internal void displayDestroy(); // 0x000000018059ADE0-0x000000018059B400
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__295))]
	internal IEnumerator ResumeAndSyncState(); // 0x0000000180592DD0-0x0000000180592E40
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__296))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool serverAuthoritative = false /* Metadata: 0x0064D76D */); // 0x0000000180593BE0-0x0000000180593C80
	[IteratorStateMachine(typeof(_DisplayCoopReward_d__297))]
	internal IEnumerator DisplayCoopReward(int gold, int exp); // 0x0000000180588000-0x0000000180588090
	private void HookLateRewardPush(); // 0x000000018058D690-0x000000018058D7E0
	private void UnhookLateRewardPush(); // 0x0000000180599A60-0x0000000180599B60
	private void HandleLateRewardPush(string matchId); // 0x000000018058C4E0-0x000000018058C5E0
	private void SpawnPetShardReward(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180597380-0x0000000180597990
	private void SpawnWeaponShardReward(int amount); // 0x0000000180598F80-0x0000000180599270
	private void SpawnWeaponReward(WeaponDropDTO drop); // 0x00000001805989E0-0x0000000180598F80
	private static Image FindRewardIcon(GameObject item); // 0x000000018058AB30-0x000000018058ADE0
	private void SpawnTowerRewards(CoopMatchResultHelper.MatchRewardData reward); // 0x0000000180598320-0x00000001805989E0
	private void SpawnTowerBundle(TowerGiftBundle g); // 0x0000000180597AF0-0x0000000180598320
	private void TowerCell(GameObject prefab, int amount, string format); // 0x0000000180599640-0x0000000180599830
	private void SpawnRewardItem(GameObject prefab, string text); // 0x0000000180597990-0x0000000180597AF0
	private void AnimateRewardReveal(GameObject item); // 0x000000018057EE80-0x000000018057F000
	private float GetRewardRevealTotalSeconds(int itemCount); // 0x000000018058C0A0-0x000000018058C0D0
	private void ShowBtnGetWithAnim(); // 0x00000001805937C0-0x0000000180593950
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x0064D76E */); // 0x00000001805940C0-0x00000001805941F0
	public void HideMega1Animation(); // 0x000000018058D500-0x000000018058D690
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x0064D76F */); // 0x00000001805941F0-0x0000000180594390
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__324))]
	private IEnumerator AutoHideMega1Animation(); // 0x000000018057FC20-0x000000018057FC90
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x0000000180594390-0x0000000180594770
	public void ClearAllMega2Hints(); // 0x00000001805835D0-0x00000001805837D0
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x0000000180589970-0x000000018058A040
	private void StopMegaIcarusWorldFx(); // 0x0000000180599590-0x0000000180599640
	private void RequestHideMegaIcarusWorldFx(); // 0x0000000180592A30-0x0000000180592AE0
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x0064D770 */); // 0x0000000180594770-0x0000000180594970
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x00000001805950A0-0x0000000180595820
	public void ClearAllMegaIcarusHints(); // 0x00000001805837D0-0x00000001805839E0
	public void ShowMegaIcarusMarks(List<Vector3Int> cells); // 0x0000000180594970-0x00000001805950A0
	private void HideExistingMultiplierLabel(GameObject dot); // 0x000000018058D380-0x000000018058D500
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x000000018057E860-0x000000018057EB30
	public void ClearAllMegaIcarusMarks(); // 0x00000001805839E0-0x0000000180583C60
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x0064D771 */); // 0x0000000180593950-0x0000000180593BE0
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__348))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x000000018058B0E0-0x000000018058B180
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180589670-0x0000000180589970
	public void ClearAllGalaxyHints(); // 0x0000000180583300-0x00000001805835D0
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__351))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180588090-0x0000000180588120
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x0000000180586300-0x00000001805866A0
	public void ReturnToMenu(); // 0x0000000180593030-0x0000000180593220
	private void ClearRoomRestoreFlags(); // 0x0000000180583F90-0x0000000180584050
	public void ReturnToQuangTruongFromBoss(); // 0x0000000180593220-0x0000000180593330
	private bool PrepareTowerReturn(); // 0x0000000180591B40-0x0000000180591B80
	internal int CalculateExpByLevel(int level); // 0x000000018040DBC0-0x000000018040DC00
	internal int CalculateTotalStones(int turnCount); // 0x000000018040E840-0x000000018040E8D0
	internal int RollStoneLevel(int turnCount); // 0x0000000180593470-0x00000001805936B0
	internal Sprite GetStoneSprite(string element, int level); // 0x000000018058C180-0x000000018058C360
	internal bool CheckBoardStable(); // 0x00000001805820E0-0x0000000180582260
	[IteratorStateMachine(typeof(_FadeOut_d__362))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x000000018058A830-0x000000018058A8B0
	private void SnapAllDotsToGrid(); // 0x0000000180597080-0x0000000180597380
	public void ShowItems(); // 0x0000000180593C80-0x00000001805940C0
	public void HideAllItems(); // 0x000000018058CEB0-0x000000018058D380
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__366))]
	public IEnumerator HideAllItemsEnd(); // 0x000000018058CE40-0x000000018058CEB0
	public void ResetMoveCounters(); // 0x000000018058C7A0-0x000000018058C850
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x00000001805806A0-0x00000001805809E0
	private static int LongestConsecutiveSpanOnAxis(List<int> sortedAsc); // 0x000000018058FFB0-0x0000000180590080
	public ValueTuple<int, int, int> ComputeBossSwordLineMetrics(GameObject movedDot, int targetX, int targetY); // 0x0000000180584950-0x00000001805855F0
	private void LoadCardsFromPlayerPrefs(); // 0x000000018058F9C0-0x000000018058FC40
	private void CreateCardHT(CardData cardData); // 0x0000000180585D00-0x0000000180586000
	public void LoadSelectedCards(List<CardData> cards); // 0x000000018058FE30-0x000000018058FFB0
	private void DisplayCardsOnBoard(); // 0x0000000180587F60-0x0000000180588000
	public void EnsureFusionCards(); // 0x00000001805890C0-0x0000000180589670
	private void RemoveFusionCard(); // 0x0000000180592470-0x0000000180592570
	public void AddFusionSkillCard(CardData cardData); // 0x000000018057E520-0x000000018057E860
	private CardUI FindWiredSkillCardUI(); // 0x000000018058ADE0-0x000000018058B0E0
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x0000000180586000-0x0000000180586300
	private void ClearCards(); // 0x0000000180583C60-0x0000000180583F90
	public void LeaveMatchAfterGameOver(); // 0x000000018058F400-0x000000018058F650
	public void LeaveMatchMidGame(); // 0x000000018058F6C0-0x000000018058F850
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__384))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x000000018058F650-0x000000018058F6C0
	private void GoToMainScene(); // 0x000000018058C360-0x000000018058C430
	private void FastReturnToRoom(); // 0x000000018058A8B0-0x000000018058AB30
	internal void ReturnToQuangTruong(); // 0x0000000180593330-0x0000000180593470
	public bool HasValidMoves(); // 0x000000018058CB40-0x000000018058CE40
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x000000018059A290-0x000000018059A540
	internal bool CheckMatchAt(int col, int row, string tag); // 0x0000000180582930-0x0000000180582D30
	[IteratorStateMachine(typeof(_ResetBoardWhenNoMoves_d__392))]
	public IEnumerator ResetBoardWhenNoMoves(); // 0x0000000180592AE0-0x0000000180592B50
	public void InitializeCardsClientOnly(); // 0x000000018058D7E0-0x000000018058E080
	public void SetBoardState(GameState state); // 0x00000001805936B0-0x00000001805936C0
	public void GrayOutPlayerAvatar(int actorNumber); // 0x000000018058C430-0x000000018058C4E0
	public void ShowPlayerExitNotice(string playerName, int actorNumber = 0 /* Metadata: 0x0064D775 */); // 0x0000000180595820-0x00000001805958C0
	public void RestorePlayerAvatar(int actorNumber); // 0x0000000180592D30-0x0000000180592DD0
	public bool HasLeftMatch(int actorNumber); // 0x000000018058CAE0-0x000000018058CB40
	private void ApplyAvatarTintIfDisplayed(int actorNumber, Color tint, bool isLeft); // 0x000000018057F000-0x000000018057F230
	internal void OnMouseDown(); // 0x00000001805912E0-0x0000000180591310
	internal void OnDestroy(); // 0x0000000180590F50-0x00000001805912C0
	internal void OnApplicationQuit(); // 0x0000000180590E60-0x0000000180590F00
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_209_0(Transform t, ref __c__DisplayClass209_0 param_00001d25); // 0x0000000180599980-0x0000000180599A50
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__296_0(); // 0x0000000180599A50-0x0000000180599A60
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__296_1(); // 0x0000000180599A50-0x0000000180599A60
}

