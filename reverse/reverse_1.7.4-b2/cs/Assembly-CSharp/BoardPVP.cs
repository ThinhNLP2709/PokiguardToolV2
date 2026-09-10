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

public class BoardPVP : MonoBehaviour // TypeDefIndex: 114
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
	private const string DotsPlayfieldChildName = "DotsPlayfield"; // Metadata: 0x0068AAC7
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
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5f; // Metadata: 0x0068AAD5
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
	internal const float AUTO_MOVE_COOLDOWN = 1.5f; // Metadata: 0x0068AAD9
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
	private const float DotSweepIntervalSec = 0.25f; // Metadata: 0x0068AADD
	private float _lastDotSweepAt; // 0x318
	private float _lastAppliedDotScaleU; // 0x31C
	private bool _dotScaleDirty; // 0x320
	private bool _lastInputOpen; // 0x321
	private DotPool _dotPool; // 0x328
	private Transform _dotPoolRoot; // 0x330
	private const string DotPoolRootName = "DotPool"; // Metadata: 0x0068AAE1
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
	private const float MinValidDotSpriteSize = 0.001f; // Metadata: 0x0068AAE9
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
	public const bool PVP_CARDS_ENABLED = false; // Metadata: 0x0068AAED
	private static Font _multiplierFontPvp; // 0x08
	private static readonly string[] DestroyDisplayOrder; // 0x10
	private readonly List<KeyValuePair<string, int>> _destroySortBuffer; // 0x3B8
	private readonly List<GameObject> _destroyEntryPool; // 0x3C0
	public const long FUSION_CARD_ID = -777; // Metadata: 0x0068AAEE
	private static readonly int[][] SwapDirections; // 0x18
	[SerializeField]
	private float mega1AnimDuration; // 0x3C8
	private Coroutine _mega1AnimCoroutine; // 0x3D0
	internal bool isMega1PanelOpen; // 0x3D8
	private const string MegaIcarusHintName = "MegaIcarusHint"; // Metadata: 0x0068AAF6
	private SpriteRenderer _megaIcarusFxHost; // 0x3E0
	private const string MegaIcarusMarkName = "MegaIcarusMark"; // Metadata: 0x0068AB05
	private readonly List<GameObject> _megaIcarusMarks; // 0x3E8
	private readonly List<GameObject> _megaIcarusHiddenLabels; // 0x3F0
	private const string GalaxyHintName = "GalaxyHint"; // Metadata: 0x0068AB14
	private Coroutine _galaxyScanCoroutine; // 0x3F8

	// Properties
	public bool IsBoardReady { get; } // 0x00000001805409C0-0x00000001805409D0 
	public static BoardPVP Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180540970-0x00000001805409C0 0x0000000180540B50-0x0000000180540BC0
	internal DotPool Dots { get; } // 0x0000000180540650-0x00000001805408F0 
	internal bool DotsHiddenForPresentation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180540640-0x0000000180540650 0x0000000180540B40-0x0000000180540B50
	internal float HandleUIWaitNormal { get; } // 0x0000000180540930-0x0000000180540950 
	internal float HandleUIWaitVang { get; } // 0x0000000180540950-0x0000000180540970 
	internal float HandleUIPauseNormal { get; } // 0x00000001805408F0-0x0000000180540910 
	internal float HandleUIPauseVang { get; } // 0x0000000180540910-0x0000000180540930 
	internal float VangAttackAnimDuration { get; } // 0x0000000180540B20-0x0000000180540B30 
	internal float VangAttackPowerAnimDuration { get; } // 0x0000000180540B30-0x0000000180540B40 
	public bool IsMegaIcarusAnimationPlaying { get; } // 0x00000001805409D0-0x0000000180540B20 

	// Nested types
	[Serializable]
	public class PetRewardRequest // TypeDefIndex: 115
	{
		// Fields
		public int petId; // 0x10
		public bool victory; // 0x14

		// Constructors
		public PetRewardRequest(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class PetRewardResponse // TypeDefIndex: 116
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
	public class StoneRewardInfo // TypeDefIndex: 117
	{
		// Fields
		public string element; // 0x10
		public int level; // 0x18
		public int quantity; // 0x1C

		// Constructors
		public StoneRewardInfo(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class ApiResponse<T> // TypeDefIndex: 118
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
	private sealed class __c // TypeDefIndex: 119
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<KeyValuePair<string, int>> __9__289_0; // 0x08
		public static Func<StoneRewardInfo, int> __9__297_0; // 0x10
		public static Func<StoneRewardInfo, string> __9__297_1; // 0x18
		public static Func<GameObject, bool> __9__309_0; // 0x20
		public static Func<CardData, bool> __9__312_0; // 0x28

		// Constructors
		static __c(); // 0x000000018065B060-0x000000018065B0D0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _displayDestroy_b__289_0(KeyValuePair<string, int> a, KeyValuePair<string, int> b); // 0x000000018065AE10-0x000000018065AEC0
		internal int _DisplayRewardFromServer_b__297_0(StoneRewardInfo s); // 0x0000000180425510-0x0000000180425530
		internal string _DisplayRewardFromServer_b__297_1(StoneRewardInfo s); // 0x000000018065AD90-0x000000018065ADB0
		internal bool _CalculatePotentialVangDotDestruction_b__309_0(GameObject g); // 0x000000018065AD00-0x000000018065AD90
		internal bool _LoadSelectedCards_b__312_0(CardData c); // 0x0000000180620760-0x0000000180620770
	}

	[CompilerGenerated]
	private struct __c__DisplayClass198_0 // TypeDefIndex: 120
	{
		// Fields
		public Transform shell; // 0x00
		public Transform pf; // 0x08
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass231_0 // TypeDefIndex: 121
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass231_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ConsumeDestructionPanelEntryCo_b__0(); // 0x000000018065AEC0-0x000000018065AF90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass298_0 // TypeDefIndex: 122
	{
		// Fields
		public int level; // 0x10
		public BoardPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass298_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _CreateLocalReward_b__0(StoneRewardInfo s); // 0x000000018065AF90-0x000000018065AFF0
	}

	[CompilerGenerated]
	private sealed class _AutoHideMega1Animation_d__341 : IEnumerator<object> // TypeDefIndex: 123
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoHideMega1Animation_d__341(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180651E20-0x0000000180651F00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180651F00-0x0000000180651F40
	}

	[CompilerGenerated]
	private sealed class _CheckForStableBoardAfterFill_d__284 : IEnumerator<object> // TypeDefIndex: 124
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _checkInterval_5__2; // 0x28
		private float _maxWaitTime_5__3; // 0x2C
		private float _elapsedTime_5__4; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckForStableBoardAfterFill_d__284(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180652060-0x0000000180652160
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180652160-0x00000001806521A0
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryCo_d__231 : IEnumerator<object> // TypeDefIndex: 125
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public string gemTagName; // 0x28
		private __c__DisplayClass231_0 __8__1; // 0x30
		private float _shrink_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryCo_d__231(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806521A0-0x00000001806526D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806526D0-0x0000000180652710
	}

	[CompilerGenerated]
	private sealed class _ConsumeDestructionPanelEntryDelayed_d__230 : IEnumerator<object> // TypeDefIndex: 126
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public BoardPVP __4__this; // 0x28
		public string gemTagName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ConsumeDestructionPanelEntryDelayed_d__230(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180652710-0x0000000180652810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180652810-0x0000000180652850
	}

	[CompilerGenerated]
	private sealed class _DecreaseRowCo_d__271 : IEnumerator<object> // TypeDefIndex: 127
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private int _safety_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DecreaseRowCo_d__271(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180652850-0x00000001806535B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806535B0-0x00000001806535F0
	}

	[CompilerGenerated]
	private sealed class _DestroyRandomDotsCo_d__276 : IEnumerator<object> // TypeDefIndex: 128
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public int count; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DestroyRandomDotsCo_d__276(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806535F0-0x0000000180653900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180653900-0x0000000180653940
	}

	[CompilerGenerated]
	private sealed class _DisplayRewardFromServer_d__297 : IEnumerator<object> // TypeDefIndex: 129
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public PetRewardResponse displayData; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DisplayRewardFromServer_d__297(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180653940-0x0000000180654F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180654F20-0x0000000180654F60
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__304 : IEnumerator<object> // TypeDefIndex: 130
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
		public _FadeOut_d__304(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180655740-0x0000000180655990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180655990-0x00000001806559D0
	}

	[CompilerGenerated]
	private sealed class _GalaxyScanRoutine_d__364 : IEnumerator<object> // TypeDefIndex: 131
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _GalaxyScanRoutine_d__364(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180372850-0x0000000180372880
		private bool MoveNext(); // 0x00000001806559D0-0x00000001806560D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806560D0-0x0000000180656110
	}

	[CompilerGenerated]
	private sealed class _HandleNetworkError_d__254 : IEnumerator<object> // TypeDefIndex: 132
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleNetworkError_d__254(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180656110-0x00000001806563A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806563A0-0x00000001806563E0
	}

	[CompilerGenerated]
	private sealed class _HandleUIWs_d__232 : IEnumerator<object> // TypeDefIndex: 133
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HandleUIWs_d__232(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001806563E0-0x00000001806574A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806574A0-0x00000001806574E0
	}

	[CompilerGenerated]
	private sealed class _HideAllItemsEnd_d__307 : IEnumerator<object> // TypeDefIndex: 134
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideAllItemsEnd_d__307(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180657910-0x0000000180657960
		private bool MoveNext(); // 0x00000001806574E0-0x00000001806578D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806578D0-0x0000000180657910
	}

	[CompilerGenerated]
	private sealed class _LeaveMatchMidGameCoroutine_d__323 : IEnumerator<object> // TypeDefIndex: 135
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LeaveMatchMidGameCoroutine_d__323(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180657960-0x0000000180657A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180657A60-0x0000000180657AA0
	}

	[CompilerGenerated]
	private sealed class _ResumeAndSyncState_d__290 : IEnumerator<object> // TypeDefIndex: 136
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		private float _wsTimeout_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ResumeAndSyncState_d__290(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180659BB0-0x0000000180659E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180659E20-0x0000000180659E60
	}

	[CompilerGenerated]
	private sealed class _ShowGameResultIntegrated_d__291 : IEnumerator<object> // TypeDefIndex: 137
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20
		public bool playerWon; // 0x28
		private int _turnCount_5__2; // 0x2C
		private int _rankBefore_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowGameResultIntegrated_d__291(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018065A400-0x000000018065ACC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018065ACC0-0x000000018065AD00
	}

	[CompilerGenerated]
	private sealed class _UpdateTurnUI_d__246 : IEnumerator<object> // TypeDefIndex: 138
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _UpdateTurnUI_d__246(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018065B0D0-0x000000018065B6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018065B6A0-0x000000018065B6E0
	}

	[CompilerGenerated]
	private sealed class _WaitAndDestroyMatches_d__273 : IEnumerator<object> // TypeDefIndex: 139
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BoardPVP __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndDestroyMatches_d__273(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018065B6E0-0x000000018065B940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018065B940-0x000000018065B980
	}

	[CompilerGenerated]
	private sealed class _WaitAndLogWarning_d__234 : IEnumerator<object> // TypeDefIndex: 140
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndLogWarning_d__234(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018065B980-0x000000018065BA60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018065BA60-0x000000018065BAA0
	}

	// Constructors
	public BoardPVP(); // 0x000000018053F8B0-0x000000018053FDF0
	static BoardPVP(); // 0x000000018053F5C0-0x000000018053F8B0

	// Methods
	internal void Awake(); // 0x0000000180529940-0x0000000180529E60
	private void OnEnable(); // 0x00000001805387D0-0x00000001805387F0
	private void OnValidate(); // 0x0000000180538BD0-0x0000000180538D90
	private void Start(); // 0x000000018053DD30-0x000000018053DFF0
	private void LateUpdate(); // 0x0000000180536990-0x0000000180536C70
	internal void MarkDotScaleDirty(); // 0x00000001805377D0-0x00000001805377E0
	private void Update(); // 0x000000018053EE30-0x000000018053F000
	internal void WakeAllDots(); // 0x000000018053F0E0-0x000000018053F1D0
	private void WakeDriftedDots(); // 0x000000018053F1D0-0x000000018053F310
	private bool HasExplicitDotsParent(); // 0x0000000180534AD0-0x0000000180534B60
	private void MergeDotsAreaDuplicatesIntoSingle(); // 0x0000000180537D00-0x00000001805385A0
	private void EnsureRuntimeDotsParent(); // 0x0000000180532960-0x0000000180532B70
	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea); // 0x0000000180539970-0x0000000180539B70
	private void AlignDotsAreaToBoard(Transform dotsAreaTransform); // 0x00000001805288E0-0x0000000180528BC0
	private Transform GetDotsAreaShellTransform(); // 0x0000000180533DC0-0x0000000180533E00
	public Transform GetDotsParent(); // 0x0000000180533E10-0x0000000180533EF0
	public Transform GetDotsParentTransform(); // 0x0000000180533E00-0x0000000180533E10
	internal bool TryTakePooledDot(string tag, Vector2 worldPos, out GameObject go); // 0x000000018053E1F0-0x000000018053E280
	internal void ReleaseDot(GameObject dot); // 0x0000000180539510-0x00000001805395B0
	internal void ClearDotPool(); // 0x000000018052DE60-0x000000018052DE80
	private Transform EnsureDotsPlayfieldForShell(Transform shell); // 0x0000000180531A60-0x0000000180531B20
	private Transform EnsureWorldDotsPlayfield(Transform shell); // 0x0000000180532B70-0x0000000180532E30
	private Transform EnsureDotsPlayfield(RectTransform shell); // 0x0000000180531B20-0x0000000180531EB0
	private void UpdateDotsPlayfieldLayout(); // 0x000000018053E970-0x000000018053EDC0
	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax); // 0x00000001805293E0-0x00000001805296F0
	private RectMask2D GetPlayfieldMask(RectTransform pfRt); // 0x0000000180534410-0x0000000180534520
	private Image GetDotsAreaFrameImage(RectTransform areaRt); // 0x00000001805339D0-0x0000000180533AA0
	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt); // 0x0000000180533AA0-0x0000000180533DC0
	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s); // 0x00000001805296F0-0x00000001805298D0
	private void InvalidateGridLayoutCache(); // 0x0000000180536390-0x00000001805363D0
	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x000000018053E0F0-0x000000018053E1F0
	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r); // 0x000000018052E780-0x000000018052EC30
	private void EnsureDotPrefabSpriteCache(); // 0x0000000180531550-0x00000001805317F0
	private bool TryCacheDotSpriteSize(Vector3 size); // 0x000000018053E0A0-0x000000018053E0F0
	private void ApplyDotScaleToFitGridCells(); // 0x0000000180528CD0-0x0000000180529270
	public Vector2 GetCellBaseWorldPosition(int col, int row); // 0x00000001805333A0-0x00000001805337C0
	public Vector2 GetDotTargetWorldPosition(int col, int row); // 0x0000000180533970-0x00000001805339D0
	public Vector2 GetDotSpawnWorldPosition(int col, int row); // 0x0000000180533900-0x0000000180533970
	public Vector2 GetWorldPositionForGrid(int column, int row); // 0x0000000180533970-0x00000001805339D0
	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row); // 0x0000000180533870-0x0000000180533900
	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row); // 0x0000000180534520-0x00000001805345D0
	private Vector3 GetGridOriginWorld(); // 0x0000000180534240-0x0000000180534340
	private GameObject ResolveDotsAreaRoot(); // 0x0000000180539C20-0x0000000180539CD0
	private GameObject GetDotsVisibilityRoot(); // 0x0000000180533EF0-0x0000000180533F00
	private void ApplyDotsAreaBackgroundSprite(); // 0x0000000180529270-0x00000001805293E0
	private void SetDotsAreaBackgroundVisible(bool visible); // 0x000000018053A170-0x000000018053A270
	public void RefreshDotsAreaBackgroundVisible(); // 0x0000000180539500-0x0000000180539510
	private void EnsureDotsAreaLayoutAndBackground(); // 0x00000001805317F0-0x0000000180531A60
	private void ReparentStrayDotsIntoPlayfield(); // 0x00000001805396B0-0x0000000180539970
	public void PrepareDotsAreaForSync(); // 0x0000000180538F00-0x0000000180538F90
	internal bool HasFullDotGridSpawned(); // 0x0000000180534B60-0x0000000180534C90
	internal Dot DotCompAt(int x, int y); // 0x00000001805310A0-0x0000000180531360
	private void SetDotsRenderVisible(bool visible); // 0x000000018053A270-0x000000018053A380
	private void SnapAllDotsToGrid(); // 0x000000018053D9D0-0x000000018053DD30
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryDelayed_d__230))]
	internal IEnumerator ConsumeDestructionPanelEntryDelayed(string gemTagName, float delaySec); // 0x000000018052ECC0-0x000000018052ED60
	[IteratorStateMachine(typeof(_ConsumeDestructionPanelEntryCo_d__231))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName); // 0x000000018052EC30-0x000000018052ECC0
	[IteratorStateMachine(typeof(_HandleUIWs_d__232))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, int attackerActor, bool wasFullPower); // 0x0000000180534A20-0x0000000180534AD0
	internal ActivePVP.PlayerStats GetValidAttackerStats(int actorNumber); // 0x00000001805347B0-0x0000000180534890
	[IteratorStateMachine(typeof(_WaitAndLogWarning_d__234))]
	private IEnumerator WaitAndLogWarning(float seconds); // 0x000000018053F070-0x000000018053F0E0
	public bool IsPlayerAllowedToMove(); // 0x00000001805363D0-0x0000000180536550
	public void EnsureBoardVisible(); // 0x0000000180531360-0x0000000180531550
	public void OpenInputForLocalTurnOnly(); // 0x0000000180538D90-0x0000000180538F00
	private void HandleTurnStart(int entityIndex); // 0x00000001802EB6C0-0x00000001802EB6D0
	internal void HandleTurnEnd(); // 0x0000000180534970-0x0000000180534A20
	public void UpdateCountdownDisplay(TimeSpan remaining); // 0x000000018053E6A0-0x000000018053E970
	public void ReturnToMenuSafely(); // 0x0000000180539D40-0x0000000180539E10
	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2); // 0x000000018052A170-0x000000018052A5C0
	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2); // 0x000000018052B7B0-0x000000018052BC90
	public void LoadGroupBackground(); // 0x00000001805373B0-0x00000001805374F0
	public void OnTurnStartNotify(int actorNumber); // 0x0000000180538820-0x0000000180538BD0
	[IteratorStateMachine(typeof(_UpdateTurnUI_d__246))]
	public IEnumerator UpdateTurnUI(int currentTurnActor); // 0x000000018053EDC0-0x000000018053EE30
	internal void LoadAudioSettings(); // 0x0000000180536FC0-0x0000000180537130
	public void InitializeCards(); // 0x0000000180535D50-0x0000000180536390
	private bool CardsHiddenThisMatch(); // 0x00000001802EB990-0x00000001802EB9A0
	public void OnCardDataReady(CardData data); // 0x00000001805385A0-0x00000001805385C0
	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount); // 0x000000018052FD20-0x0000000180530260
	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier); // 0x000000018052B500-0x000000018052B7B0
	[IteratorStateMachine(typeof(_HandleNetworkError_d__254))]
	public IEnumerator HandleNetworkError(string errorMessage); // 0x0000000180534900-0x0000000180534970
	public int CalculateTrapPotential(int x, int y, string tag); // 0x000000018052AE40-0x000000018052B500
	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY); // 0x000000018053C5D0-0x000000018053CA50
	public int GetDotMultiplier(GameObject dot); // 0x00000001805337C0-0x0000000180533870
	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2); // 0x000000018052A900-0x000000018052ADB0
	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots); // 0x000000018052DE80-0x000000018052E780
	public bool IsTrapMove(int x1, int y1, int x2, int y2); // 0x0000000180536550-0x0000000180536990
	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions); // 0x000000018053CA50-0x000000018053D240
	public string[,] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions); // 0x000000018053C2C0-0x000000018053C5D0
	public int CountPlayerVangOpportunities(string[,] board); // 0x000000018052ED60-0x000000018052EE80
	public bool CanCreateMatchAtPosition(string[,] board, int x, int y, string tag); // 0x000000018052BC90-0x000000018052C070
	public bool CheckMatchAtSimulated(string[,] board, int col, int row, string tag); // 0x000000018052C640-0x000000018052C860
	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3 /* Metadata: 0x0068AABF */); // 0x000000018053D240-0x000000018053D9D0
	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain); // 0x000000018052C1D0-0x000000018052C5D0
	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain); // 0x000000018052CC50-0x000000018052D220
	public bool MatchesAt(int column, int row, GameObject piece); // 0x00000001805377E0-0x0000000180537BA0
	internal void DestroyMatchesAt(int column, int row); // 0x0000000180530260-0x00000001805304D0
	[IteratorStateMachine(typeof(_DecreaseRowCo_d__271))]
	internal IEnumerator DecreaseRowCo(); // 0x000000018052FCB0-0x000000018052FD20
	internal void ResetDestroyedCounts(); // 0x00000001805387F0-0x0000000180538820
	[IteratorStateMachine(typeof(_WaitAndDestroyMatches_d__273))]
	public IEnumerator WaitAndDestroyMatches(); // 0x000000018053F000-0x000000018053F070
	public void DestroyMatches(); // 0x00000001805304D0-0x0000000180530550
	public void DestroyRandomDots(int count); // 0x00000001805306D0-0x0000000180530760
	[IteratorStateMachine(typeof(_DestroyRandomDotsCo_d__276))]
	internal IEnumerator DestroyRandomDotsCo(int count); // 0x0000000180530650-0x00000001805306D0
	public void RefillBoard(); // 0x00000001805394F0-0x0000000180539500
	private void RefillBoardNonDeterministic(); // 0x0000000180538F90-0x00000001805394F0
	public string CalculateBoardHash(); // 0x0000000180529E60-0x000000018052A130
	private static Font GetMultiplierFontPvp(); // 0x0000000180534340-0x0000000180534410
	internal void CreateMultiplierText(GameObject dot, int multiplier); // 0x000000018052F600-0x000000018052FCB0
	public bool MatchesOnBoard(); // 0x0000000180537BA0-0x0000000180537D00
	[IteratorStateMachine(typeof(_CheckForStableBoardAfterFill_d__284))]
	public IEnumerator CheckForStableBoardAfterFill(); // 0x000000018052C5D0-0x000000018052C640
	private static int DestroyOrderIndexOf(string tag); // 0x0000000180530550-0x0000000180530650
	internal void displayDestroy(); // 0x000000018053FDF0-0x0000000180540640
	[IteratorStateMachine(typeof(_ResumeAndSyncState_d__290))]
	internal IEnumerator ResumeAndSyncState(); // 0x0000000180539CD0-0x0000000180539D40
	[IteratorStateMachine(typeof(_ShowGameResultIntegrated_d__291))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon); // 0x000000018053A6C0-0x000000018053A740
	private long GetEnemyUserId(); // 0x0000000180533F00-0x0000000180534240
	private void DisplayPvpResultStats(int rankBefore, int rankChange, int newRank, int gold); // 0x0000000180530770-0x0000000180530EB0
	private void DisplayPvpTopAndWinRate(int rankPosition, int winRate); // 0x0000000180530EB0-0x0000000180531010
	private void LoadPvpTopPositionForResult(); // 0x00000001805374F0-0x0000000180537650
	private static void ApplyCtIcon(GameObject item); // 0x0000000180528BC0-0x0000000180528CD0
	[IteratorStateMachine(typeof(_DisplayRewardFromServer_d__297))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData); // 0x0000000180531010-0x00000001805310A0
	internal PetRewardResponse CreateLocalReward(int turnCount); // 0x000000018052F260-0x000000018052F600
	internal int CalculateExpByLevel(int level); // 0x000000018052A130-0x000000018052A170
	internal int CalculateTotalStones(int turnCount); // 0x000000018052ADB0-0x000000018052AE40
	internal int RollStoneLevel(int turnCount); // 0x0000000180539F20-0x000000018053A160
	internal Sprite GetStoneSprite(string element, int level); // 0x00000001805345D0-0x00000001805347B0
	internal bool CheckBoardStable(); // 0x000000018052C070-0x000000018052C1D0
	[IteratorStateMachine(typeof(_FadeOut_d__304))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration); // 0x0000000180532E30-0x0000000180532EB0
	public void ShowItems(); // 0x000000018053A740-0x000000018053AB80
	public void HideAllItems(); // 0x0000000180534FE0-0x0000000180535480
	[IteratorStateMachine(typeof(_HideAllItemsEnd_d__307))]
	public IEnumerator HideAllItemsEnd(); // 0x0000000180534F70-0x0000000180534FE0
	public void ResetMoveCounters(); // 0x0000000180534970-0x0000000180534A20
	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY); // 0x000000018052A5C0-0x000000018052A900
	private void LoadCardsFromPlayerPrefs(); // 0x0000000180537130-0x00000001805373B0
	private void CreateCardHT(CardData cardData); // 0x000000018052EE80-0x000000018052EF60
	public void LoadSelectedCards(List<CardData> cards); // 0x0000000180537650-0x00000001805377D0
	private void DisplayCardsOnBoard(); // 0x0000000180530760-0x0000000180530770
	public void EnsureFusionCards(); // 0x0000000180531EB0-0x0000000180531FB0
	private void RemoveFusionCard(); // 0x00000001805395B0-0x00000001805396B0
	public void AddFusionSkillCard(CardData cardData); // 0x0000000180528510-0x0000000180528610
	private CardUIPVP FindWiredSkillCardUI(); // 0x0000000180533000-0x0000000180533300
	private void CreateCard(CardData cardData, int index, int totalCards); // 0x000000018052EF60-0x000000018052F260
	private void ClearCards(); // 0x000000018052DB30-0x000000018052DE60
	public void LeaveMatchAfterGameOver(); // 0x0000000180536C70-0x0000000180536E30
	public void LeaveMatchMidGame(); // 0x0000000180536EA0-0x0000000180536FC0
	[IteratorStateMachine(typeof(_LeaveMatchMidGameCoroutine_d__323))]
	private IEnumerator LeaveMatchMidGameCoroutine(); // 0x0000000180536E30-0x0000000180536EA0
	private void GoToMainScene(); // 0x0000000180534890-0x0000000180534900
	private void FastReturnToRoom(); // 0x0000000180532EB0-0x0000000180533000
	internal void ReturnToQuangTruong(); // 0x0000000180539E10-0x0000000180539F20
	public bool HasValidMoves(); // 0x0000000180534C90-0x0000000180534F70
	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2); // 0x000000018053F310-0x000000018053F5C0
	internal bool CheckMatchAt(int col, int row, string tag); // 0x000000018052C860-0x000000018052CC50
	public void InitializeCardsClientOnly(); // 0x0000000180535790-0x0000000180535D50
	public void SetBoardState(GameStates state); // 0x000000018053A160-0x000000018053A170
	internal void OnMouseDown(); // 0x00000001805387F0-0x0000000180538820
	internal void OnDestroy(); // 0x00000001805385C0-0x00000001805387D0
	public void ShowMega1Animation(bool autoHide = true /* Metadata: 0x0068AAC0 */); // 0x000000018053AB80-0x000000018053ACB0
	public void HideMega1Animation(); // 0x0000000180535600-0x0000000180535790
	public void ShowMega2Animation(bool autoHide = true /* Metadata: 0x0068AAC1 */); // 0x000000018053ACB0-0x000000018053AE50
	[IteratorStateMachine(typeof(_AutoHideMega1Animation_d__341))]
	private IEnumerator AutoHideMega1Animation(); // 0x00000001805298D0-0x0000000180529940
	public void ShowMega2ToggleHint(int col, int row, bool isOn); // 0x000000018053AE50-0x000000018053B230
	public void ClearAllMega2Hints(); // 0x000000018052D4D0-0x000000018052D6C0
	private SpriteRenderer EnsureMegaIcarusFxHost(); // 0x00000001805322B0-0x0000000180532960
	private void StopMegaIcarusWorldFx(); // 0x000000018053DFF0-0x000000018053E0A0
	private void RequestHideMegaIcarusWorldFx(); // 0x0000000180539B70-0x0000000180539C20
	public void ShowMegaIcarusAnimation(bool autoHide = true /* Metadata: 0x0068AAC2 */); // 0x000000018053B230-0x000000018053B430
	public void ShowMegaIcarusRadiusHint(int centerCol, int centerRow, int radius); // 0x000000018053BB50-0x000000018053C2C0
	public void ClearAllMegaIcarusHints(); // 0x000000018052D6C0-0x000000018052D8B0
	public void ShowMegaIcarusMarks(List<Vector3Int> cells); // 0x000000018053B430-0x000000018053BB50
	private void HideExistingMultiplierLabelPvp(GameObject dot); // 0x0000000180535480-0x0000000180535600
	private void AddMegaIcarusMarkText(Transform parent, string text, Font font, Color color, Vector3 localOffset, float scale, int sortingOrder); // 0x0000000180528610-0x00000001805288E0
	public void ClearAllMegaIcarusMarks(); // 0x000000018052D8B0-0x000000018052DB30
	public int ShowGalaxyScanFx(string tagToHighlight, float duration = 1f /* Metadata: 0x0068AAC3 */); // 0x000000018053A380-0x000000018053A6C0
	[IteratorStateMachine(typeof(_GalaxyScanRoutine_d__364))]
	private IEnumerator GalaxyScanRoutine(string tagToHighlight, float duration); // 0x0000000180533300-0x00000001805333A0
	private Transform EnsureGalaxyHint(GameObject dotObj); // 0x0000000180531FB0-0x00000001805322B0
	public void ClearAllGalaxyHints(); // 0x000000018052D220-0x000000018052D4D0
	[CompilerGenerated]
	internal static void _ReparentStrayDotsIntoPlayfield_g__ReparentIfDot_198_0(Transform t, ref __c__DisplayClass198_0 param_00000320); // 0x000000018053E5D0-0x000000018053E6A0
	[CompilerGenerated]
	private void _ShowGameResultIntegrated_b__291_0(); // 0x0000000180532EB0-0x0000000180533000
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__295_0(PvpProfileDTO data); // 0x000000018053E280-0x000000018053E4A0
	[CompilerGenerated]
	private void _LoadPvpTopPositionForResult_b__295_1(string err); // 0x000000018053E4A0-0x000000018053E5D0
}

