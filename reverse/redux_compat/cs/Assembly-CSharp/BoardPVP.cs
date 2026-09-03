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

public class BoardPVP : MonoBehaviour // TypeDefIndex: 103
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
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x0064BFA8
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
	private const float MinSecondsBetweenCanvasForceRebuild = 0.1f; // Metadata: 0x0064BFB6
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
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x0064BFBA
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
	private RectTransform _cachedPlayfieldMaskOwner; // 0x318
	private RectMask2D _cachedPlayfieldMask; // 0x320
	private RectTransform _cachedDotsAreaFrameImageOwner; // 0x328
	private Image _cachedDotsAreaFrameImage; // 0x330
	private int _gridLayoutCacheFrame; // 0x338
	private bool _gridLayoutCacheOk; // 0x33C
	private RectTransform _gridLayoutCacheArea; // 0x340
	private float _gridLayoutCacheCellW; // 0x348
	private float _gridLayoutCacheCellH; // 0x34C
	private Rect _gridLayoutCacheRect; // 0x350
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x0064BFBE
	[Header("T\u1ED1c \u0111\u1ED9 x\u1EED l\u00FD vi\u00EAn (HandleUI)")]
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD m\u1ED7i lo\u1EA1i vi\u00EAn th\u01B0\u1EDDng (sau animation damage).")]
	private float handleUI_waitPerNormalGem; // 0x360
	[SerializeField]
	[Tooltip("Th\u1EDDi gian ch\u1EDD vi\u00EAn v\u00E0ng (s).")]
	private float handleUI_waitPerVangGem; // 0x364
	[SerializeField]
	[Tooltip("Kho\u1EA3ng ngh\u1EC9 ng\u1EAFn sau c\u1EADp nh\u1EADt slider, tr\u01B0\u1EDBc b\u01B0\u1EDBc ti\u1EBFp.")]
	private float handleUI_pauseAfterSliderNormal; // 0x368
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; // 0x36C
	[Header("Pet animation duration cho vi\u00EAn ki\u1EBFm (vang Dot)")]
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation Attack b\u00ECnh th\u01B0\u1EDDng (key=1). Ch\u1EDD \u0111\u1EE7 tr\u01B0\u1EDBc khi reset animator.")]
	private float vangAttackAnimDuration; // 0x370
	[SerializeField]
	[Tooltip("\u0110\u1ED9 d\u00E0i animation AttackPower khi \u0111\u1EE7 n\u1ED9 (key=2).")]
	private float vangAttackPowerAnimDuration; // 0x374
	[SerializeField]
	private float destructionEntryPulseSeconds; // 0x378
	[SerializeField]
	private float destructionEntryShrinkSeconds; // 0x37C
	private static Font _multiplierFontPvp; // 0x08
	private static readonly string[] DestroyDisplayOrder; // 0x10
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x380
	private readonly List<GameObject> _destroyEntryPool; // 0x388
	public const long FUSION_CARD_ID = -777; // Metadata: 0x0064BFC2
	private static readonly int[][] SwapDirections; // 0x18
	[SerializeField]
	private float mega1AnimDuration; // 0x390
	private Coroutine _mega1AnimCoroutine; // 0x398
	internal bool isMega1PanelOpen; // 0x3A0
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x0064BFCA
	private SpriteRenderer _megaIcarusFxHost; // 0x3A8
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x0064BFD9
	private readonly List<GameObject> _megaIcarusMarks; // 0x3B0
	private readonly List<GameObject> _megaIcarusHiddenLabels; // 0x3B8
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x0064BFE8
	private Coroutine _galaxyScanCoroutine; // 0x3C0

	// Properties
	public bool IsBoardReady { get; } // 0x0000000180423830-0x0000000180423840 
	public static BoardPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804237E0-0x0000000180423830 0x00000001804239B0-0x0000000180423A20
	internal float HandleUIWaitNormal { get; } // 0x00000001804237A0-0x00000001804237C0 
	internal float HandleUIWaitVang { get; } // 0x00000001804237C0-0x00000001804237E0 
	internal float HandleUIPauseNormal { get; } // 0x0000000180423760-0x0000000180423780 
	internal float HandleUIPauseVang { get; } // 0x0000000180423780-0x00000001804237A0 
	internal float VangAttackAnimDuration { get; } // 0x0000000180423990-0x00000001804239A0 
	internal float VangAttackPowerAnimDuration { get; } // 0x00000001804239A0-0x00000001804239B0 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x0000000180423840-0x0000000180423990 

	// Nested types
	[Serializable]
	public class PetRewardRequest // TypeDefIndex: 104
	{
		// Fields
		public int petId; // 0x10
		public bool victory; // 0x14

		// Constructors
		public PetRewardRequest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class PetRewardResponse // TypeDefIndex: 105
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
	public class StoneRewardInfo // TypeDefIndex: 106
	{
		// Fields
		public string element; // 0x10
		public int level; // 0x18
		public int quantity; // 0x1C

		// Constructors
		public StoneRewardInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class ApiResponse<T> // TypeDefIndex: 107
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
	private sealed class __c // TypeDefIndex: 108
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__261_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__268_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__268_1; // 0x18
		public static Func<GameObject, bool> __9__280_0; // 0x20
		public static Func<CardData, bool> __9__283_0; // 0x28

		// Constructors
		static __c(); // 0x000000018052BF30-0x000000018052BFA0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _displayDestroy_b__261_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x000000018052BB10-0x000000018052BBC0
		internal int _DisplayRewardFromServer_b__268_0(StoneRewardInfo s); // 0x000000018030F1E0-0x000000018030F200
		internal string _DisplayRewardFromServer_b__268_1(StoneRewardInfo s); // 0x000000018052BA80-0x000000018052BAA0
		internal bool _CalculatePotentialVangDotDestruction_b__280_0(GameObject g); // 0x000000018052B9F0-0x000000018052BA80
		internal bool _LoadSelectedCards_b__283_0(CardData c); // 0x000000018052BB00-0x000000018052BB10
	}

	[CompilerGenerated]
	private struct __c__DisplayClass181_0 // TypeDefIndex: 109
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass206_0 // TypeDefIndex: 110
	{
		// Fields
		public GameObject go; // 0x10

		// Constructors
		public __c__DisplayClass206_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x000000018052BD40-0x000000018052BDB0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass269_0 // TypeDefIndex: 111
	{
		// Fields
		public int level; // 0x10
		public BoardPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass269_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x000000018052BE60-0x000000018052BEC0
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__312 : IEnumerator<object> // TypeDefIndex: 112
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__312(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180522D40-0x0000000180522E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180522E20-0x0000000180522E60
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__256 : IEnumerator<object> // TypeDefIndex: 113
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _checkInterval_5__2; // 0x28
		private float _maxWaitTime_5__3; // 0x2C
		private float _elapsedTime_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__256(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180522F80-0x0000000180523080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180523080-0x00000001805230C0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__206 : IEnumerator<object> // TypeDefIndex: 114
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass206_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__206(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x00000001805230C0-0x00000001805235E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805235E0-0x0000000180523620
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__205 : IEnumerator<object> // TypeDefIndex: 115
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public BoardPVP __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__205(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180523620-0x0000000180523720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180523720-0x0000000180523760
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__243 : IEnumerator<object> // TypeDefIndex: 116
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__243(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180523760-0x0000000180524450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180524450-0x0000000180524490
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__248 : IEnumerator<object> // TypeDefIndex: 117
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__248(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180524490-0x00000001805247A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805247A0-0x00000001805247E0
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__268 : IEnumerator<object> // TypeDefIndex: 118
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__268(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805247E0-0x0000000180525D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180525D90-0x0000000180525DD0
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__275 : IEnumerator<object> // TypeDefIndex: 119
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
		public _FadeOut_d__275(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805265B0-0x0000000180526800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180526800-0x0000000180526840
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__335 : IEnumerator<object> // TypeDefIndex: 120
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__335(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x0000000180526840-0x0000000180526F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180526F40-0x0000000180526F80
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__226 : IEnumerator<object> // TypeDefIndex: 121
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__226(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180526F80-0x0000000180527210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180527210-0x0000000180527250
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__207 : IEnumerator<object> // TypeDefIndex: 122
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

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HandleUIWs_d__207(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x0000000180527250-0x0000000180528150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180528150-0x0000000180528190
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__278 : IEnumerator<object> // TypeDefIndex: 123
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideAllItemsEnd_d__278(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805285C0-0x0000000180528610
		private bool MoveNext(); // 0x0000000180528190-0x0000000180528580
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180528580-0x00000001805285C0
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__294 : IEnumerator<object> // TypeDefIndex: 124
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__294(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180528610-0x0000000180528710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180528710-0x0000000180528750
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__262 : IEnumerator<object> // TypeDefIndex: 125
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _wsTimeout_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__262(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052A890-0x000000018052AAE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052AAE0-0x000000018052AB20
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__263 : IEnumerator<object> // TypeDefIndex: 126
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public bool playerWon; // 0x28
		private int _turnCount_5__2; // 0x2C
		private int _rankBefore_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__263(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052B0F0-0x000000018052B9B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052B9B0-0x000000018052B9F0
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__220 : IEnumerator<object> // TypeDefIndex: 127
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__220(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052BFA0-0x000000018052C570
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052C570-0x000000018052C5B0
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__245 : IEnumerator<object> // TypeDefIndex: 128
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__245(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052C5B0-0x000000018052C810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052C810-0x000000018052C850
	}

	[CompilerGenerated]
	private sealed class _WaitAndLogWarning_d__209 : IEnumerator<object> // TypeDefIndex: 129
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndLogWarning_d__209(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052C850-0x000000018052C930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052C930-0x000000018052C970
	}

	// Constructors
	public BoardPVP(); // 0x0000000180422C20-0x0000000180423140
	static BoardPVP(); // 0x0000000180422930-0x0000000180422C20

	// Methods
	internal void Awake(); // 0x000000018040D3D0-0x000000018040D8F0
	private void OnEnable(); // 0x000000018041C640-0x000000018041C660
	private void OnValidate(); // 0x000000018041C890-0x000000018041CA50
	private void Start(); // 0x0000000180421540-0x00000001804217F0
	private void LateUpdate(); // 0x000000018041A7F0-0x000000018041AAC0
	private bool HasExplicitDotsParent(); // 0x0000000180418860-0x00000001804188F0
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x000000018041BB40-0x000000018041C3E0
	private void EnsureRuntimeDotsParent(); // 0x00000001804166F0-0x0000000180416900
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x000000018041D410-0x000000018041D610
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x000000018040C630-0x000000018040C910
	private Transform GetDotsAreaShellTransform(); // 0x0000000180417B50-0x0000000180417B90
	public Transform GetDotsParent(); // 0x0000000180417BA0-0x0000000180417C80
	public Transform GetDotsParentTransform(); // 0x0000000180417B90-0x0000000180417BA0
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180415340-0x0000000180415400
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x0000000180416900-0x0000000180416BC0
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x0000000180415400-0x0000000180415790
	private void UpdateDotsPlayfieldLayout(); // 0x00000001804220E0-0x0000000180422530
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x000000018040CE70-0x000000018040D180
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x00000001804181A0-0x00000001804182B0
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x0000000180417760-0x0000000180417830
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x0000000180417830-0x0000000180417B50
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x000000018040D180-0x000000018040D360
	private void InvalidateGridLayoutCache(); // 0x000000018041A230-0x000000018041A260
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x00000001804218F0-0x00000001804219F0
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x00000001804121F0-0x00000001804126A0
	private void EnsureDotPrefabSpriteCache(); // 0x0000000180414E40-0x00000001804150E0
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x00000001804218A0-0x00000001804218F0
	private void ApplyDotScaleToFitGridCells(); // 0x000000018040C910-0x000000018040CD00
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x0000000180417130-0x0000000180417550
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x0000000180417700-0x0000000180417760
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x0000000180417690-0x0000000180417700
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x0000000180417700-0x0000000180417760
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x0000000180417600-0x0000000180417690
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x00000001804182B0-0x0000000180418360
	private Vector3 GetGridOriginWorld(); // 0x0000000180417FD0-0x00000001804180D0
	private GameObject ResolveDotsAreaRoot(); // 0x000000018041D6C0-0x000000018041D770
	private GameObject GetDotsVisibilityRoot(); // 0x0000000180417C80-0x0000000180417C90
	private void ApplyDotsAreaBackgroundSprite(); // 0x000000018040CD00-0x000000018040CE70
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x000000018041DC10-0x000000018041DD10
	public void RefreshDotsAreaBackgroundVisible(); // 0x000000018041D040-0x000000018041D050
	private void EnsureDotsAreaLayoutAndBackground(); // 0x00000001804150E0-0x0000000180415340
	private void ReparentStrayDotsIntoPlayfield(); // 0x000000018041D150-0x000000018041D410
	public void PrepareDotsAreaForSync(); // 0x000000018041CA50-0x000000018041CAD0
	internal bool HasFullDotGridSpawned(); // 0x00000001804188F0-0x0000000180418A20
	private void SnapAllDotsToGrid(); // 0x0000000180421260-0x0000000180421540
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__205))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x0000000180412730-0x00000001804127D0
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__206))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x00000001804126A0-0x0000000180412730
	[IteratorStateMachine(typeof(_HandleUIWs_d__207))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, int attackerActor, bool wasFullPower); // 0x00000001804187B0-0x0000000180418860
	internal ActivePVP.PlayerStats GetValidAttackerStats(int actorNumber); // 0x0000000180418540-0x0000000180418620
	[IteratorStateMachine(typeof(_WaitAndLogWarning_d__209))]
	private IEnumerator WaitAndLogWarning(float seconds); // 0x0000000180422610-0x0000000180422680
	public bool IsPlayerAllowedToMove(); // 0x000000018041A260-0x000000018041A3B0
	public void EnsureBoardVisible(); // 0x0000000180414DC0-0x0000000180414E40
	private void HandleTurnStart(int entityIndex); // 0x00000001802E76C0-0x00000001802E76D0
	internal void HandleTurnEnd(); // 0x0000000180418700-0x00000001804187B0
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x0000000180421E10-0x00000001804220E0
	public void ReturnToMenuSafely(); // 0x000000018041D7E0-0x000000018041D8B0
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x000000018040DC00-0x000000018040E050
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x000000018040F240-0x000000018040F720
	public void LoadGroupBackground(); // 0x000000018041B200-0x000000018041B340
	public void OnTurnStartNotify(int actorNumber); // 0x000000018041C690-0x000000018041C890
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__220))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x0000000180422530-0x00000001804225A0
	internal void LoadAudioSettings(); // 0x000000018041AE10-0x000000018041AF80
	public void InitializeCards(); // 0x0000000180419B50-0x000000018041A230
	public void OnCardDataReady(CardData data); // 0x000000018041C3E0-0x000000018041C430
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x00000001804139B0-0x0000000180413EF0
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x000000018040EF90-0x000000018040F240
	[IteratorStateMachine(typeof(_HandleNetworkError_d__226))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x0000000180418690-0x0000000180418700
	public int CalculateTrapPotential(int x, int y, string tag); // 0x000000018040E8D0-0x000000018040EF90
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x000000018041FE60-0x00000001804202E0
	public int GetDotMultiplier(GameObject dot); // 0x0000000180417550-0x0000000180417600
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x000000018040E390-0x000000018040E840
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x00000001804118F0-0x00000001804121F0
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x000000018041A3B0-0x000000018041A7F0
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x00000001804202E0-0x0000000180420AD0
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x000000018041FB50-0x000000018041FE60
	public int CountPlayerVangOpportunities(string[,] board); // 0x00000001804127D0-0x00000001804128F0
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x000000018040F720-0x000000018040FB00
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x00000001804100D0-0x00000001804102F0
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x0064BFA0 */); // 0x0000000180420AD0-0x0000000180421260
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x000000018040FC60-0x0000000180410060
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x00000001804106E0-0x0000000180410CB0
	public bool MatchesAt(int column, int row, GameObject piece); // 0x000000018041B620-0x000000018041B9E0
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180413EF0-0x0000000180414160
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__243))]
	internal IEnumerator DecreaseRowCo(); // 0x0000000180413940-0x00000001804139B0
	internal void ResetDestroyedCounts(); // 0x000000018041C660-0x000000018041C690
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__245))]
	public IEnumerator WaitAndDestroyMatches(); // 0x00000001804225A0-0x0000000180422610
	public void DestroyMatches(); // 0x0000000180414160-0x00000001804141E0
	public void DestroyRandomDots(int count); // 0x0000000180414360-0x00000001804143F0
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__248))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x00000001804142E0-0x0000000180414360
	public void RefillBoard(); // 0x000000018041D030-0x000000018041D040
	private void RefillBoardNonDeterministic(); // 0x000000018041CAD0-0x000000018041D030
	public string CalculateBoardHash(); // 0x000000018040D8F0-0x000000018040DBC0
	private static Font GetMultiplierFontPvp(); // 0x00000001804180D0-0x00000001804181A0
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x0000000180413290-0x0000000180413940
	public bool MatchesOnBoard(); // 0x000000018041B9E0-0x000000018041BB40
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__256))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x0000000180410060-0x00000001804100D0
	private static int DestroyOrderIndexOf(string tag); // 0x00000001804141E0-0x00000001804142E0
	internal void displayDestroy(); // 0x0000000180423140-0x0000000180423760
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__262))]
	internal IEnumerator ResumeAndSyncState(); // 0x000000018041D770-0x000000018041D7E0
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__263))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon); // 0x000000018041DF90-0x000000018041E010
	private long GetEnemyUserId(); // 0x0000000180417C90-0x0000000180417FD0
	private void DisplayPvpResultStats(int rankBefore, int rankChange, int newRank, int gold); // 0x0000000180414490-0x0000000180414BD0
	private void DisplayPvpTopAndWinRate(int rankPosition, int winRate); // 0x0000000180414BD0-0x0000000180414D30
	private void LoadPvpTopPositionForResult(); // 0x000000018041B340-0x000000018041B4A0
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__268))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180414D30-0x0000000180414DC0
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x0000000180412EF0-0x0000000180413290
	internal int CalculateExpByLevel(int level); // 0x000000018040DBC0-0x000000018040DC00
	internal int CalculateTotalStones(int turnCount); // 0x000000018040E840-0x000000018040E8D0
	internal int RollStoneLevel(int turnCount); // 0x000000018041D9C0-0x000000018041DC00
	internal Sprite GetStoneSprite(string element, int level); // 0x0000000180418360-0x0000000180418540
	internal bool CheckBoardStable(); // 0x000000018040FB00-0x000000018040FC60
	[IteratorStateMachine(typeof(_FadeOut_d__275))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x0000000180416BC0-0x0000000180416C40
	public void ShowItems(); // 0x000000018041E010-0x000000018041E410
	public void HideAllItems(); // 0x0000000180418D70-0x00000001804191F0
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__278))]
	public IEnumerator HideAllItemsEnd(); // 0x0000000180418D00-0x0000000180418D70
	public void ResetMoveCounters(); // 0x0000000180418700-0x00000001804187B0
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x000000018040E050-0x000000018040E390
	private void LoadCardsFromPlayerPrefs(); // 0x000000018041AF80-0x000000018041B200
	private void CreateCardHT(CardData cardData); // 0x00000001804128F0-0x0000000180412BF0
	public void LoadSelectedCards(List<CardData> cards); // 0x000000018041B4A0-0x000000018041B620
	private void DisplayCardsOnBoard(); // 0x00000001804143F0-0x0000000180414490
	public void EnsureFusionCards(); // 0x0000000180415790-0x0000000180415D40
	private void RemoveFusionCard(); // 0x000000018041D050-0x000000018041D150
	public void AddFusionSkillCard(CardData cardData); // 0x000000018040C020-0x000000018040C360
	private CardUIPVP FindWiredSkillCardUI(); // 0x0000000180416D90-0x0000000180417090
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x0000000180412BF0-0x0000000180412EF0
	private void ClearCards(); // 0x00000001804115C0-0x00000001804118F0
	public void LeaveMatchAfterGameOver(); // 0x000000018041AAC0-0x000000018041AC80
	public void LeaveMatchMidGame(); // 0x000000018041ACF0-0x000000018041AE10
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__294))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x000000018041AC80-0x000000018041ACF0
	private void GoToMainScene(); // 0x0000000180418620-0x0000000180418690
	private void FastReturnToRoom(); // 0x0000000180416C40-0x0000000180416D90
	internal void ReturnToQuangTruong(); // 0x000000018041D8B0-0x000000018041D9C0
	public bool HasValidMoves(); // 0x0000000180418A20-0x0000000180418D00
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x0000000180422680-0x0000000180422930
	internal bool CheckMatchAt(int col, int row, string tag); // 0x00000001804102F0-0x00000001804106E0
	public void InitializeCardsClientOnly(); // 0x0000000180419500-0x0000000180419B50
	public void SetBoardState(GameStates state); // 0x000000018041DC00-0x000000018041DC10
	internal void OnMouseDown(); // 0x000000018041C660-0x000000018041C690
	internal void OnDestroy(); // 0x000000018041C430-0x000000018041C640
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x0064BFA1 */); // 0x000000018041E410-0x000000018041E540
	public void HideMega1Animation(); // 0x0000000180419370-0x0000000180419500
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x0064BFA2 */); // 0x000000018041E540-0x000000018041E6E0
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__312))]
	private IEnumerator AutoHideMega1Animation(); // 0x000000018040D360-0x000000018040D3D0
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x000000018041E6E0-0x000000018041EAC0
	public void ClearAllMega2Hints(); // 0x0000000180410F60-0x0000000180411150
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x0000000180416040-0x00000001804166F0
	private void StopMegaIcarusWorldFx(); // 0x00000001804217F0-0x00000001804218A0
	private void RequestHideMegaIcarusWorldFx(); // 0x000000018041D610-0x000000018041D6C0
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x0064BFA3 */); // 0x000000018041EAC0-0x000000018041ECC0
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x000000018041F3E0-0x000000018041FB50
	public void ClearAllMegaIcarusHints(); // 0x0000000180411150-0x0000000180411340
	public void ShowMegaIcarusMarks(List<Vector3Int> cells); // 0x000000018041ECC0-0x000000018041F3E0
	private void HideExistingMultiplierLabelPvp(GameObject dot); // 0x00000001804191F0-0x0000000180419370
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x000000018040C360-0x000000018040C630
	public void ClearAllMegaIcarusMarks(); // 0x0000000180411340-0x00000001804115C0
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x0064BFA4 */); // 0x000000018041DD10-0x000000018041DF90
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__335))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x0000000180417090-0x0000000180417130
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180415D40-0x0000000180416040
	public void ClearAllGalaxyHints(); // 0x0000000180410CB0-0x0000000180410F60
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_181_0(Transform t, ref __c__DisplayClass181_0 param_00000259); // 0x0000000180421D40-0x0000000180421E10
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__263_0(); // 0x0000000180416C40-0x0000000180416D90
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__267_0(PvpProfileDTO data); // 0x00000001804219F0-0x0000000180421C10
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__267_1(string err); // 0x0000000180421C10-0x0000000180421D40
}

