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

public class BoardPVP : MonoBehaviour // TypeDefIndex: 112
{
	// Fields
	public GameObject bossTimeoutPanel; // 0x20
	public UnityEngine.UI.Text bossTimeoutText; // 0x28
	public Button bossTimeoutButton; // 0x30
	public UnityEngine.UI.Text txtBossCountdown; // 0x38
	internal DateTime bossEndTime; // 0x40
	internal bool isBossTimeValid; // 0x48
	internal Coroutine bossCountdownCoroutine; // 0x50
	public GameObject[] dots; // 0x58
	public GameStates currentState; // 0x60
	public GameObject destructionEntryPrefab; // 0x68
	public int width; // 0x70
	public int height; // 0x74
	public int offSet; // 0x78
	[Header("Dot grid / DotsArea")]
	[SerializeField]
	[Tooltip("V\u1ECB tr\u00ED \u00F4 t\u1EEB slot transforms (index = row*width+col).")]
	private bool useSlotPositions; // 0x7C
	[SerializeField]
	private Transform slotsRoot; // 0x80
	[SerializeField]
	private bool autoSyncSlotsFromRoot; // 0x88
	[SerializeField]
	private List<Transform> slots; // 0x90
	[SerializeField]
	private float dotYOffset; // 0x98
	[SerializeField]
	[Tooltip("Khi kh\u00F4ng d\u00F9ng slot: c\u0103n l\u01B0\u1EDBi quanh t\u00E2m Board/DotsArea.")]
	private bool centerBoardOnTransform; // 0x9C
	[SerializeField]
	private Vector2 cellSpacing; // 0xA0
	[SerializeField]
	[Tooltip("B\u1EADt: chia \u0111\u1EC1u \u00F4 theo rect DotsArea. T\u1EAFt: d\u00F9ng cellSpacing / c\u0103n t\u00E2m.")]
	private bool useEvenSpacingFromDotsArea; // 0xA8
	[SerializeField]
	private float dotsAreaPadding; // 0xAC
	[SerializeField]
	private float dotsAreaExtraFrameGap; // 0xB0
	[SerializeField]
	private bool insetGridFromSlicedImageBorder; // 0xB4
	[SerializeField]
	private bool autoScaleDotsToFitGridCells; // 0xB5
	[Range(0f, 0.45f)]
	[SerializeField]
	private float dotVisualFillPadding; // 0xB8
	[SerializeField]
	[Tooltip("T\u1EA1o child DotsPlayfield d\u01B0\u1EDBi DotsArea.")]
	private bool useDotsPlayfieldUnderDotsArea; // 0xBC
	[SerializeField]
	private bool clipDotsInsidePlayfield; // 0xBD
	[Header("Dots hierarchy")]
	[SerializeField]
	[Tooltip("K\u00E9o object cha ch\u1EE9a dot. \u0110\u1EC3 tr\u1ED1ng: t\u1EF1 t\u1EA1o child DotsArea.")]
	public Transform dotsParent; // 0xC0
	private Transform runtimeDotsParent; // 0xC8
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x005EEAB6
	private Transform runtimeDotsPlayfield; // 0xD0
	[SerializeField]
	private Sprite dotsAreaBackgroundSprite; // 0xD8
	[SerializeField]
	private float spawnLiftY; // 0xE0
	private Vector2 _cachedDotPrefabSpriteSize; // 0xE4
	private bool _cachedDotPrefabSpriteSizeValid; // 0xEC
	private Vector3 _dotPrefabRootScale; // 0xF0
	private Vector2 _lastDotsShellRectSize; // 0xFC
	private float _lastCanvasForceUnscaledTime; // 0x104
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x005EEAC4
	internal int destroyedCount; // 0x108
	internal bool isDestroyingMatches; // 0x10C
	public bool hasDestroyedThisTurn; // 0x10D
	public bool playerMovedThisTurn; // 0x10E
	public bool hasMega1BuffThisTurn; // 0x10F
	public bool hasMega2BuffThisTurn; // 0x110
	internal bool isMega2PanelOpen; // 0x111
	[HideInInspector]
	public CardUIPVP activeMega2CardUIPVP; // 0x118
	internal BackGroundTitle[,] allTiles; // 0x120
	public GameObject[,] allDots; // 0x128
	internal FindMatches findMaches; // 0x130
	internal Dictionary<string, int> destroyedCountByTag; // 0x138
	public ActivePVP active; // 0x140
	internal Coroutine stableBoardCheckCoroutine; // 0x148
	public GameObject destructionCountPanel; // 0x150
	internal Dictionary<string, Sprite> itemIcons; // 0x158
	public Sprite[] pieces; // 0x160
	public GameObject loading; // 0x168
	public Api api; // 0x170
	public NotifyWin notifyWin; // 0x178
	public GameObject load; // 0x180
	public bool enableAutoMove; // 0x188
	public GameObject imgTurnE; // 0x190
	public GameObject imgTurnP; // 0x198
	internal bool isProcessingUI; // 0x1A0
	internal bool isAutoMoveInProgress; // 0x1A1
	public GameObject panelResult; // 0x1A8
	public GameObject resultBackground; // 0x1B0
	public GameObject rewards; // 0x1B8
	public GameObject anmtRW; // 0x1C0
	public GameObject listReward; // 0x1C8
	public GameObject itemRewardStone; // 0x1D0
	public GameObject itemRewardPet; // 0x1D8
	public GameObject itemRewardCT; // 0x1E0
	public GameObject itemRewardGold; // 0x1E8
	public GameObject itemRewardEXP; // 0x1F0
	public UnityEngine.UI.Text txtResultTitle; // 0x1F8
	[Header("PVP Result Stats")]
	public UnityEngine.UI.Text txtRankPvp; // 0x200
	public UnityEngine.UI.Text txtTopPvp; // 0x208
	public UnityEngine.UI.Text txtWinRate; // 0x210
	public Button btnGet; // 0x218
	public Sprite[] fireStones; // 0x220
	public Sprite[] waterStones; // 0x228
	public Sprite[] earthStones; // 0x230
	public Sprite[] windStones; // 0x238
	public Sprite[] electricStones; // 0x240
	internal bool isGameOver; // 0x248
	internal string enemyPetElement; // 0x250
	internal int enemyPetId; // 0x258
	internal int currentCount; // 0x25C
	internal int requestPass; // 0x260
	internal float lastAutoMoveTime; // 0x264
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x005EEAC8
	internal bool isBossBattle; // 0x268
	public GameObject cardPrefab; // 0x270
	public Transform cardContainer; // 0x278
	public int maxCardsInHand; // 0x280
	public float cardSpacing; // 0x284
	public float cardYPosition; // 0x288
	public float cardAnimDuration; // 0x28C
	internal List<CardData> selectedCards; // 0x290
	internal List<GameObject> cardsInHand; // 0x298
	public CardData cardData; // 0x2A0
	internal int HOTTURN; // 0x2A8
	internal int SUBHOTTURN; // 0x2AC
	public GameObject energyWarningPanel; // 0x2B0
	public UnityEngine.UI.Text energyWarningText; // 0x2B8
	public Button energyWarningButton; // 0x2C0
	internal bool hasShownEnergyWarning; // 0x2C8
	internal int lastCheckedEnergy; // 0x2CC
	internal AudioSettingsManager audioSettingsManager; // 0x2D0
	public Image boardBackground; // 0x2D8
	internal bool isBoardReady; // 0x2E0
	internal bool isUsingLegendCard; // 0x2E1
	internal float legendDamageMultiplier; // 0x2E4
	internal bool isUsingMega; // 0x2E8
	internal int currentDamageMultiplier; // 0x2EC
	public GameObject imgPDef; // 0x2F0
	public GameObject imgEDef; // 0x2F8
	internal bool isResuming; // 0x300
	internal Coroutine resumeSyncCoroutine; // 0x308
	internal int localPlayerActorNumber; // 0x310
	internal int lastRefillSeed; // 0x314
	[CompilerGenerated]
	private static BoardPVP _Instance_k__BackingField; // 0x00
	private const float DotSweepIntervalSec = 0.25f; // Metadata: 0x005EEACC
	private float _lastDotSweepAt; // 0x318
	private float _lastAppliedDotScaleU; // 0x31C
	private bool _dotScaleDirty; // 0x320
	private bool _lastInputOpen; // 0x321
	private DotPool _dotPool; // 0x328
	private Transform _dotPoolRoot; // 0x330
	private const string DotPoolRootName = "DotPool"; // Metadata: 0x005EEAD0
	private RectTransform _cachedPlayfieldMaskOwner; // 0x338
	private RectMask2D _cachedPlayfieldMask; // 0x340
	private RectTransform _cachedDotsAreaFrameImageOwner; // 0x348
	private Image _cachedDotsAreaFrameImage; // 0x350
	private int _gridLayoutCacheFrame; // 0x358
	private bool _gridLayoutCacheOk; // 0x35C
	private RectTransform _gridLayoutCacheArea; // 0x360
	private float _gridLayoutCacheCellW; // 0x368
	private float _gridLayoutCacheCellH; // 0x36C
	private Rect _gridLayoutCacheRect; // 0x370
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x005EEAD8
	private Dot[,] _dotComps; // 0x380
	private GameObject[,] _dotCompOwners; // 0x388
	[CompilerGenerated]
	private bool _DotsHiddenForPresentation_k__BackingField; // 0x390
	[Header("T\u1ED1c \u0111\u1ED9 x\u1EED l\u00FD vi\u00EAn (HandleUI)")]
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD m\u1ED7i lo\u1EA1i vi\u00EAn th\u01B0\u1EDDng (sau animation damage).")]
	private float handleUI_waitPerNormalGem; // 0x394
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD vi\u00EAn v\u00E0ng (s).")]
	private float handleUI_waitPerVangGem; // 0x398
	[SerializeField]
	[Tooltip("Kho\u1EA3ng ngh\u1EC9 ng\u1EAFn sau c\u1EADp nh\u1EADt slider, tr\u01B0\u1EDBc b\u01B0\u1EDBc ti\u1EBFp.")]
	private float handleUI_pauseAfterSliderNormal; // 0x39C
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; // 0x3A0
	[Header("Pet animation duration cho vi\u00EAn ki\u1EBFm (vang Dot)")]
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation Attack b\u00ECnh th\u01B0\u1EDDng (key=1). Ch\u1EDD \u0111\u1EE7 tr\u01B0\u1EDBc khi reset animator.")]
	private float vangAttackAnimDuration; // 0x3A4
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation AttackPower khi \u0111\u1EE7 n\u1ED9 (key=2).")]
	private float vangAttackPowerAnimDuration; // 0x3A8
	[SerializeField]
	private float destructionEntryPulseSeconds; // 0x3AC
	[SerializeField]
	private float destructionEntryShrinkSeconds; // 0x3B0
	public const bool PVP_CARDS_ENABLED = false; // Metadata: 0x005EEADC
	private static Font _multiplierFontPvp; // 0x08
	private static readonly string[] DestroyDisplayOrder; // 0x10
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x3B8
	private readonly List<GameObject> _destroyEntryPool; // 0x3C0
	public const long FUSION_CARD_ID = -777; // Metadata: 0x005EEADD
	private static readonly int[][] SwapDirections; // 0x18
	[SerializeField]
	private float mega1AnimDuration; // 0x3C8
	private Coroutine _mega1AnimCoroutine; // 0x3D0
	internal bool isMega1PanelOpen; // 0x3D8
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x005EEAE5
	private SpriteRenderer _megaIcarusFxHost; // 0x3E0
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x005EEAF4
	private readonly List<GameObject> _megaIcarusMarks; // 0x3E8
	private readonly List<NudgedMultiplierLabelPvp> _megaIcarusNudgedLabels; // 0x3F0
	private static readonly Vector3 MegaIcarusNudge; // 0x20
	private const float MegaIcarusNudgeScale = 0.78f; // Metadata: 0x005EEB03
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x005EEB07
	private Coroutine _galaxyScanCoroutine; // 0x3F8

	// Properties
	public bool IsBoardReady { get; } // 0x000000018060C780-0x000000018060C790 
	public static BoardPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018060C790-0x000000018060C7F0 0x000000018060C7F0-0x000000018060C8A0
	internal DotPool Dots { get; } // 0x0000000180610710-0x0000000180610D70 
	internal bool DotsHiddenForPresentation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806170E0-0x00000001806170F0 0x00000001806170F0-0x0000000180617100
	internal float HandleUIWaitNormal { get; } // 0x0000000180617760-0x0000000180617780 
	internal float HandleUIWaitVang { get; } // 0x0000000180617780-0x00000001806177A0 
	internal float HandleUIPauseNormal { get; } // 0x00000001806177A0-0x00000001806177C0 
	internal float HandleUIPauseVang { get; } // 0x00000001806177C0-0x00000001806177E0 
	internal float VangAttackAnimDuration { get; } // 0x00000001806177E0-0x00000001806177F0 
	internal float VangAttackPowerAnimDuration { get; } // 0x00000001806177F0-0x0000000180617800 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x000000018062DE90-0x000000018062E220 

	// Nested types
	private struct NudgedMultiplierLabelPvp // TypeDefIndex: 113
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
	public class PetRewardResponse // TypeDefIndex: 114
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
	public class StoneRewardInfo // TypeDefIndex: 115
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
	private sealed class __c // TypeDefIndex: 116
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__289_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__298_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__298_1; // 0x18
		public static Func<GameObject, bool> __9__310_0; // 0x20
		public static Func<CardData, bool> __9__313_0; // 0x28

		// Constructors
		static __c(); // 0x00000001807A9F00-0x00000001807A9FA0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _displayDestroy_b__289_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x00000001807A9FA0-0x00000001807AA060
		internal int _DisplayRewardFromServer_b__298_0(StoneRewardInfo s); // 0x0000000180475D50-0x0000000180475D70
		internal string _DisplayRewardFromServer_b__298_1(StoneRewardInfo s); // 0x00000001807AA060-0x00000001807AA080
		internal bool _CalculatePotentialVangDotDestruction_b__310_0(GameObject g); // 0x00000001807AA080-0x00000001807AA1C0
		internal bool _LoadSelectedCards_b__313_0(CardData c); // 0x00000001807AA1C0-0x00000001807AA1D0
	}

	[CompilerGenerated]
	private struct __c__DisplayClass198_0 // TypeDefIndex: 117
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 118
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass231_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x00000001807AA1D0-0x00000001807AA3C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass299_0 // TypeDefIndex: 119
	{
		// Fields
		public int level; // 0x10
		public BoardPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass299_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x00000001807AA3C0-0x00000001807AA450
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__342 : IEnumerator<object> // TypeDefIndex: 120
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__342(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AA450-0x00000001807AA5B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AA5B0-0x00000001807AA5F0
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__284 : IEnumerator<object> // TypeDefIndex: 121
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _checkInterval_5__2; // 0x28
		private float _maxWaitTime_5__3; // 0x2C
		private float _elapsedTime_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__284(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AA5F0-0x00000001807AA720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AA720-0x00000001807AA760
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__231 : IEnumerator<object> // TypeDefIndex: 122
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass231_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__231(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
		private bool MoveNext(); // 0x00000001807AA760-0x00000001807AAF60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AAF60-0x00000001807AAFA0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__230 : IEnumerator<object> // TypeDefIndex: 123
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public BoardPVP __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__230(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AAFA0-0x00000001807AB0D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AB0D0-0x00000001807AB110
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__271 : IEnumerator<object> // TypeDefIndex: 124
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__271(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AB110-0x00000001807ABE30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807ABE30-0x00000001807ABE70
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__276 : IEnumerator<object> // TypeDefIndex: 125
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__276(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807ABE70-0x00000001807AC4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AC4D0-0x00000001807AC510
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__298 : IEnumerator<object> // TypeDefIndex: 126
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__298(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AC510-0x00000001807AE3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AE3D0-0x00000001807AE410
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__305 : IEnumerator<object> // TypeDefIndex: 127
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
		public _FadeOut_d__305(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AE410-0x00000001807AE8D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AE8D0-0x00000001807AE910
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__368 : IEnumerator<object> // TypeDefIndex: 128
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float duration; // 0x20
		public BoardPVP __4__this; // 0x28
		public string tagToHighlight; // 0x30
		private float _perColumn_5__2; // 0x38
		private List<Transform> _faded_5__3; // 0x40
		private int _c_5__4; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__368(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018037B340-0x000000018037B3B0
		private bool MoveNext(); // 0x00000001807AE910-0x00000001807AF380
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AF380-0x00000001807AF3C0
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__254 : IEnumerator<object> // TypeDefIndex: 129
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__254(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807AF3C0-0x00000001807AF9B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807AF9B0-0x00000001807AF9F0
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__232 : IEnumerator<object> // TypeDefIndex: 130
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public WsCombatBatch batch; // 0x28
		public int attackerActor; // 0x30
		public bool wasFullPower; // 0x34
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
		public _HandleUIWs_d__232(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001807AF9F0-0x00000001807B0F50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B0F50-0x00000001807B0F90
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__308 : IEnumerator<object> // TypeDefIndex: 131
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
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
		public _HideAllItemsEnd_d__308(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807B0F90-0x00000001807B10A0
		private bool MoveNext(); // 0x00000001807B10A0-0x00000001807B18F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B18F0-0x00000001807B1930
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__324 : IEnumerator<object> // TypeDefIndex: 132
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__324(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B1930-0x00000001807B1AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B1AB0-0x00000001807B1AF0
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__290 : IEnumerator<object> // TypeDefIndex: 133
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _wsTimeout_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__290(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B1AF0-0x00000001807B1F10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B1F10-0x00000001807B1F50
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__291 : IEnumerator<object> // TypeDefIndex: 134
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public bool aborted; // 0x28
		public bool playerWon; // 0x29
		private int _turnCount_5__2; // 0x2C
		private int _rankBefore_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__291(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B1F50-0x00000001807B2E30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B2E30-0x00000001807B2E70
	}

	[CompilerGenerated]
	private sealed class _ShowMatchAbortedPanel_d__292 : IEnumerator<object> // TypeDefIndex: 135
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowMatchAbortedPanel_d__292(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B2E70-0x00000001807B3A90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B3A90-0x00000001807B3AD0
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__246 : IEnumerator<object> // TypeDefIndex: 136
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__246(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B3AD0-0x00000001807B40A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B40A0-0x00000001807B40E0
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__273 : IEnumerator<object> // TypeDefIndex: 137
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__273(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B40E0-0x00000001807B4440
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B4440-0x00000001807B4480
	}

	[CompilerGenerated]
	private sealed class _WaitAndLogWarning_d__234 : IEnumerator<object> // TypeDefIndex: 138
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndLogWarning_d__234(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807B4480-0x00000001807B4590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807B4590-0x00000001807B45D0
	}

	// Constructors
	public BoardPVP(); // 0x00000001806339F0-0x00000001806344B0
	static BoardPVP(); // 0x00000001806344B0-0x0000000180634840

	// Methods
	internal void Awake(); // 0x000000018060C8A0-0x000000018060D030
	private void OnEnable(); // 0x000000018060D030-0x000000018060D050
	private void OnValidate(); // 0x000000018060D050-0x000000018060D390
	private void Start(); // 0x000000018060D390-0x000000018060D7A0
	private void LateUpdate(); // 0x000000018060D7A0-0x000000018060DCE0
	internal void MarkDotScaleDirty(); // 0x000000018060DCE0-0x000000018060DCF0
	private void Update(); // 0x000000018060DCF0-0x000000018060DD80
	internal void WakeAllDots(); // 0x000000018060DD80-0x000000018060DF00
	private void WakeDriftedDots(); // 0x000000018060DF00-0x000000018060E0D0
	private bool HasExplicitDotsParent(); // 0x000000018060E0D0-0x000000018060E2D0
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x000000018060E2D0-0x000000018060F3F0
	private void EnsureRuntimeDotsParent(); // 0x000000018060F3F0-0x000000018060F8A0
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x000000018060F8A0-0x000000018060FEF0
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x000000018060FEF0-0x00000001806104E0
	private Transform GetDotsAreaShellTransform(); // 0x00000001806104E0-0x0000000180610520
	public Transform GetDotsParent(); // 0x0000000180610520-0x0000000180610700
	public Transform GetDotsParentTransform(); // 0x0000000180610700-0x0000000180610710
	internal bool TryTakePooledDot(string tag, Vector2 worldPos, out GameObject go); // 0x0000000180610D70-0x0000000180610E40
	internal void ReleaseDot(GameObject dot); // 0x0000000180610E40-0x0000000180610F60
	internal void ClearDotPool(); // 0x0000000180610F60-0x0000000180610F80
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180610F80-0x00000001806110B0
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x00000001806110B0-0x00000001806117D0
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x00000001806117D0-0x0000000180612210
	private void UpdateDotsPlayfieldLayout(); // 0x0000000180612210-0x00000001806129C0
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x00000001806129C0-0x0000000180612D80
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x0000000180612D80-0x0000000180613030
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x0000000180613030-0x0000000180613230
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x0000000180613230-0x00000001806137D0
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x00000001806137D0-0x0000000180613B40
	private void InvalidateGridLayoutCache(); // 0x0000000180613B40-0x0000000180613BC0
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180613BC0-0x0000000180613DD0
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x0000000180613DD0-0x00000001806145F0
	private void EnsureDotPrefabSpriteCache(); // 0x00000001806145F0-0x0000000180614C10
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x0000000180614C10-0x0000000180614C60
	private void ApplyDotScaleToFitGridCells(); // 0x0000000180614C60-0x0000000180615250
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x0000000180615250-0x0000000180615620
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x0000000180615620-0x0000000180615680
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x0000000180615680-0x00000001806156F0
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x0000000180615620-0x0000000180615680
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x00000001806156F0-0x0000000180615780
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x0000000180615780-0x0000000180615830
	private Vector3 GetGridOriginWorld(); // 0x0000000180615830-0x0000000180615B50
	private GameObject ResolveDotsAreaRoot(); // 0x0000000180615B50-0x0000000180615C80
	private GameObject GetDotsVisibilityRoot(); // 0x0000000180615C80-0x0000000180615C90
	private void ApplyDotsAreaBackgroundSprite(); // 0x0000000180615C90-0x0000000180615F60
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x0000000180615F60-0x0000000180616200
	public void RefreshDotsAreaBackgroundVisible(); // 0x0000000180616200-0x0000000180616210
	private void EnsureDotsAreaLayoutAndBackground(); // 0x0000000180616210-0x0000000180616420
	private void ReparentStrayDotsIntoPlayfield(); // 0x0000000180616420-0x0000000180616A80
	public void PrepareDotsAreaForSync(); // 0x0000000180616A80-0x0000000180616AF0
	internal bool HasFullDotGridSpawned(); // 0x0000000180616AF0-0x0000000180616CC0
	internal Dot DotCompAt(int x, int y); // 0x0000000180616CC0-0x00000001806170E0
	private void SetDotsRenderVisible(bool visible); // 0x0000000180617100-0x0000000180617290
	private void SnapAllDotsToGrid(); // 0x0000000180617290-0x0000000180617760
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__230))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x0000000180617800-0x0000000180617920
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__231))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x0000000180617920-0x0000000180617A30
	[IteratorStateMachine(typeof(_HandleUIWs_d__232))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, int attackerActor, bool wasFullPower); // 0x0000000180617A30-0x0000000180617B60
	internal ActivePVP.PlayerStats GetValidAttackerStats(int actorNumber); // 0x0000000180617B60-0x0000000180617C40
	[IteratorStateMachine(typeof(_WaitAndLogWarning_d__234))]
	private IEnumerator WaitAndLogWarning(float seconds); // 0x0000000180617C40-0x0000000180617CA0
	public bool IsPlayerAllowedToMove(); // 0x0000000180617CA0-0x0000000180617EE0
	public void EnsureBoardVisible(); // 0x0000000180617EE0-0x0000000180617FF0
	public void OpenInputForLocalTurnOnly(); // 0x0000000180617FF0-0x00000001806181B0
	private void HandleTurnStart(int entityIndex); // 0x000000018028A320-0x000000018028A330
	internal void HandleTurnEnd(); // 0x00000001806181B0-0x00000001806181C0
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x00000001806181C0-0x0000000180618570
	public void ReturnToMenuSafely(); // 0x0000000180618570-0x00000001806186E0
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x00000001806186E0-0x0000000180618C50
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x0000000180618C50-0x00000001806192E0
	public void LoadGroupBackground(); // 0x00000001806192E0-0x0000000180619560
	public void OnTurnStartNotify(int actorNumber); // 0x0000000180619560-0x0000000180619B50
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__246))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x0000000180619B50-0x0000000180619BF0
	internal void LoadAudioSettings(); // 0x0000000180619BF0-0x0000000180619EB0
	public void InitializeCards(); // 0x0000000180619EB0-0x000000018061AA90
	private bool CardsHiddenThisMatch(); // 0x000000018028A040-0x000000018028A050
	public void OnCardDataReady(CardData data); // 0x000000018061AA90-0x000000018061AAF0
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x000000018061AAF0-0x000000018061B280
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x000000018061B280-0x000000018061B5E0
	[IteratorStateMachine(typeof(_HandleNetworkError_d__254))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x000000018061B5E0-0x000000018061B680
	public int CalculateTrapPotential(int x, int y, string tag); // 0x000000018061B680-0x000000018061BD20
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x000000018061BD20-0x000000018061C3A0
	public int GetDotMultiplier(GameObject dot); // 0x000000018061C3A0-0x000000018061C540
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x000000018061C540-0x000000018061CB70
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x000000018061CB70-0x000000018061D770
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x000000018061D770-0x000000018061DC40
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x000000018061DC40-0x000000018061E7F0
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x000000018061E7F0-0x000000018061EB40
	public int CountPlayerVangOpportunities(string[,] board); // 0x000000018061EB40-0x000000018061ECA0
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x000000018061ECA0-0x000000018061F060
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x000000018061F060-0x000000018061F300
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x005EEAAD */); // 0x000000018061F300-0x000000018061FBE0
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x000000018061FBE0-0x00000001806202E0
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x00000001806202E0-0x0000000180620920
	public bool MatchesAt(int column, int row, GameObject piece); // 0x0000000180620920-0x0000000180620F90
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180620F90-0x00000001806213F0
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__271))]
	internal IEnumerator DecreaseRowCo(); // 0x00000001806213F0-0x0000000180621490
	internal void ResetDestroyedCounts(); // 0x0000000180621490-0x00000001806214B0
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__273))]
	public IEnumerator WaitAndDestroyMatches(); // 0x00000001806214B0-0x0000000180621550
	public void DestroyMatches(); // 0x0000000180621550-0x0000000180621600
	public void DestroyRandomDots(int count); // 0x0000000180621600-0x00000001806216C0
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__276))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x00000001806216C0-0x0000000180621770
	public void RefillBoard(); // 0x0000000180621770-0x00000001806218B0
	private void RefillBoardNonDeterministic(); // 0x00000001806218B0-0x0000000180621F20
	public string CalculateBoardHash(); // 0x0000000180621F20-0x0000000180622300
	private static Font GetMultiplierFontPvp(); // 0x0000000180622300-0x0000000180622490
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x0000000180622490-0x0000000180623620
	public bool MatchesOnBoard(); // 0x0000000180623620-0x00000001806237F0
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__284))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x00000001806237F0-0x0000000180623890
	private static int DestroyOrderIndexOf(string tag); // 0x0000000180623890-0x0000000180623A00
	internal void displayDestroy(); // 0x0000000180623A00-0x0000000180624960
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__290))]
	internal IEnumerator ResumeAndSyncState(); // 0x0000000180624960-0x0000000180624A00
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__291))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool aborted = false /* Metadata: 0x005EEAAE */); // 0x0000000180624A00-0x0000000180624AC0
	[IteratorStateMachine(typeof(_ShowMatchAbortedPanel_d__292))]
	private IEnumerator ShowMatchAbortedPanel(); // 0x0000000180624AC0-0x0000000180624B60
	private long GetEnemyUserId(); // 0x0000000180624B60-0x0000000180625010
	private void DisplayPvpResultStats(int rankBefore, int rankChange, int newRank, int gold); // 0x0000000180625010-0x0000000180625BA0
	private void DisplayPvpTopAndWinRate(int rankPosition, int winRate); // 0x0000000180625BA0-0x0000000180625E90
	private void LoadPvpTopPositionForResult(); // 0x0000000180625E90-0x0000000180626020
	private static void ApplyCtIcon(GameObject item); // 0x0000000180626020-0x0000000180626290
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__298))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180626290-0x00000001806263A0
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x00000001806263A0-0x0000000180626820
	internal int CalculateExpByLevel(int level); // 0x0000000180626820-0x0000000180626860
	internal int CalculateTotalStones(int turnCount); // 0x0000000180626860-0x00000001806268A0
	internal int RollStoneLevel(int turnCount); // 0x00000001806268A0-0x0000000180626B20
	internal Sprite GetStoneSprite(string element, int level); // 0x0000000180626B20-0x0000000180626DF0
	internal bool CheckBoardStable(); // 0x0000000180626DF0-0x0000000180626FD0
	[IteratorStateMachine(typeof(_FadeOut_d__305))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x0000000180626FD0-0x0000000180627090
	public void ShowItems(); // 0x0000000180627090-0x0000000180627AF0
	public void HideAllItems(); // 0x0000000180627AF0-0x0000000180628510
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__308))]
	public IEnumerator HideAllItemsEnd(); // 0x0000000180628510-0x00000001806285B0
	public void ResetMoveCounters(); // 0x00000001806285B0-0x0000000180628700
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x0000000180628700-0x0000000180628A20
	private void LoadCardsFromPlayerPrefs(); // 0x0000000180628A20-0x0000000180628BE0
	private void CreateCardHT(CardData cardData); // 0x0000000180628BE0-0x0000000180628D80
	public void LoadSelectedCards(List<CardData> cards); // 0x0000000180628D80-0x0000000180629020
	private void DisplayCardsOnBoard(); // 0x0000000180629020-0x0000000180629030
	public void EnsureFusionCards(); // 0x0000000180629030-0x00000001806291A0
	private void RemoveFusionCard(); // 0x00000001806291A0-0x0000000180629440
	public void AddFusionSkillCard(CardData cardData); // 0x0000000180629440-0x0000000180629690
	private CardUIPVP FindWiredSkillCardUI(); // 0x0000000180629690-0x0000000180629B60
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x0000000180629B60-0x000000018062A220
	private void ClearCards(); // 0x000000018062A220-0x000000018062A750
	public void LeaveMatchAfterGameOver(); // 0x000000018062A750-0x000000018062A910
	public void LeaveMatchMidGame(); // 0x000000018062A910-0x000000018062AA50
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__324))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x000000018062AA50-0x000000018062AAF0
	private void GoToMainScene(); // 0x000000018062AAF0-0x000000018062AB70
	private void FastReturnToRoom(); // 0x000000018062AB70-0x000000018062ACE0
	internal void ReturnToQuangTruong(); // 0x000000018062ACE0-0x000000018062AE90
	public bool HasValidMoves(); // 0x000000018062AE90-0x000000018062B260
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x000000018062B260-0x000000018062B560
	internal bool CheckMatchAt(int col, int row, string tag); // 0x000000018062B560-0x000000018062BB20
	public void InitializeCardsClientOnly(); // 0x000000018062BB20-0x000000018062C5E0
	public void SetBoardState(GameStates state); // 0x000000018062C5E0-0x000000018062C5F0
	internal void OnMouseDown(); // 0x0000000180621490-0x00000001806214B0
	internal void OnDestroy(); // 0x000000018062C5F0-0x000000018062CA20
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x005EEAAF */); // 0x000000018062CA20-0x000000018062CCC0
	public void HideMega1Animation(); // 0x000000018062CCC0-0x000000018062D090
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x005EEAB0 */); // 0x000000018062D090-0x000000018062D410
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__342))]
	private IEnumerator AutoHideMega1Animation(); // 0x000000018062D410-0x000000018062D4B0
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x000000018062D4B0-0x000000018062DB70
	public void ClearAllMega2Hints(); // 0x000000018062DB70-0x000000018062DE90
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x000000018062E220-0x000000018062EC60
	private void StopMegaIcarusWorldFx(); // 0x000000018062EC60-0x000000018062EDE0
	private void RequestHideMegaIcarusWorldFx(); // 0x000000018062EDE0-0x000000018062EF60
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x005EEAB1 */); // 0x000000018062EF60-0x000000018062F3A0
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x000000018062F3A0-0x000000018062FF50
	public void ClearAllMegaIcarusHints(); // 0x000000018062FF50-0x0000000180630280
	public void ShowMegaIcarusMarks(List<MegaIcarusMark> cells); // 0x0000000180630280-0x0000000180630F40
	private bool NudgeExistingMultiplierLabelPvp(GameObject dot); // 0x0000000180630F40-0x0000000180631B80
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x0000000180631B80-0x0000000180632350
	public void ClearAllMegaIcarusMarks(); // 0x0000000180632350-0x00000001806329C0
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x005EEAB2 */); // 0x00000001806329C0-0x0000000180632E90
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__368))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x0000000180632E90-0x0000000180632FB0
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180632FB0-0x0000000180633570
	public void ClearAllGalaxyHints(); // 0x0000000180633570-0x00000001806339F0
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_198_0(Transform t, ref __c__DisplayClass198_0 param_00000328); // 0x0000000180634840-0x0000000180634B80
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__291_0(); // 0x0000000180634B80-0x0000000180634B90
	[CompilerGenerated]
	private void _ShowMatchAbortedPanel_b__292_0(); // 0x0000000180634B80-0x0000000180634B90
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__296_0(PvpProfileDTO data); // 0x0000000180634B90-0x0000000180635050
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__296_1(string err); // 0x0000000180635050-0x0000000180635360
}

