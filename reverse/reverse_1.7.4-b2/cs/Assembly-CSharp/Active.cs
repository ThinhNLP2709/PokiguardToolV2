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

public class Active : MonoBehaviour // TypeDefIndex: 1795
{
	// Fields
	public Dictionary<int, PlayerStats> playerStatsMap; // 0x20
	[Header("Player Stats (Inspector View)")]
	[SerializeField]
	public List<PlayerStats> playerStatsList; // 0x28
	internal int enemyActorNumber; // 0x30
	public const int WS_BOSS_ACTOR = 99; // Metadata: 0x0068D945
	[Header("UI Object")]
	public Board board; // 0x38
	public Slider thanhMauSlider; // 0x40
	public Slider thanhManaSlider; // 0x48
	public Slider thanhNoSlider; // 0x50
	public Slider thanhMauNPC; // 0x58
	public Slider thanhManaNPC; // 0x60
	public Slider thanhNoNPC; // 0x68
	public ImageLoader enemyPet; // 0x70
	public ImageLoader playerPet; // 0x78
	public ImageLoader typePetUser; // 0x80
	public ImageLoader typePetEnemy; // 0x88
	[CompilerGenerated]
	private Action OnTurnEnd; // 0x90
	public Animator playerPetAnimator; // 0x98
	public Animator bossPetAnimator; // 0xA0
	private const float HealFxFallbackSeconds = 2f; // Metadata: 0x0068D947
	private Coroutine _healFxOffSelf; // 0xA8
	private Coroutine _healFxOffEnemy; // 0xB0
	public Animator anmtHealP; // 0xB8
	public Animator anmtHealE; // 0xC0
	public GameObject offBoard; // 0xC8
	public GameObject dameATKPrefad; // 0xD0
	public GameObject dameATKPrefadNPC; // 0xD8
	[Header("UI Information")]
	public int inputKiem; // 0xE0
	public int outputKiem; // 0xE4
	public int finalDamageDisplay; // 0xE8
	public int inputGiap; // 0xEC
	public int outputGiap; // 0xF0
	public int inputMau; // 0xF4
	public int outputMau; // 0xF8
	public int inputHut; // 0xFC
	public int outputHut; // 0x100
	public int inputNo; // 0x104
	public int outputNo; // 0x108
	public int inputMana; // 0x10C
	public int outputMana; // 0x110
	internal int sloMauAnDuoc; // 0x114
	internal int sloNoAnDuoc; // 0x118
	internal int sloHutAnDuoc; // 0x11C
	internal int sloGiapAnDuoc; // 0x120
	internal int sloManaAnDuoc; // 0x124
	internal int sloKiemAnDuoc; // 0x128
	public UnityEngine.UI.Text textMauPlayer; // 0x130
	public UnityEngine.UI.Text textManaPlayer; // 0x138
	public UnityEngine.UI.Text textNoPlayer; // 0x140
	public UnityEngine.UI.Text textMauNPC; // 0x148
	public UnityEngine.UI.Text textManaNPC; // 0x150
	public UnityEngine.UI.Text textNoNPC; // 0x158
	public GameObject healdMana; // 0x160
	public GameObject healdDEF; // 0x168
	public GameObject healdDEFNPC; // 0x170
	public GameObject healdPower; // 0x178
	public GameObject healdHP; // 0x180
	public GameObject healdManaNPC; // 0x188
	public GameObject healdPowerNPC; // 0x190
	public GameObject healdHPNPC; // 0x198
	public GameObject animationPet; // 0x1A0
	public GameObject animationBoss; // 0x1A8
	public int valueCurrent; // 0x1B0
	public UnityEngine.UI.Text nangLuong; // 0x1B8
	public UnityEngine.UI.Text leverPetUser; // 0x1C0
	public UnityEngine.UI.Text leverEnemyPet; // 0x1C8
	public UnityEngine.UI.Text namePetUser; // 0x1D0
	public UnityEngine.UI.Text namePetEnemy; // 0x1D8
	public UnityEngine.UI.Text dameTypePetUse; // 0x1E0
	public UnityEngine.UI.Text dameTypePetEnemy; // 0x1E8
	public List<CardInfo> cardInfos; // 0x1F0
	public ListCard listCard; // 0x1F8
	public Effect effect; // 0x200
	public ApiLoadRoom apiLoadRoom; // 0x208
	public GameObject onCard; // 0x210
	[Header("C\u1EA5u h\u00ECnh h\u1EC7 s\u1ED1")]
	public int GiapPlayerActiveAtTurn; // 0x218
	public int GiapNPCCreatedAtTurn; // 0x21C
	public int GiapNPCActiveAtTurn; // 0x220
	public int GiapPlayerCreatedAtTurn; // 0x224
	public float noGainPercent; // 0x228
	public float giapPercentPerPiece; // 0x22C
	public int shieldDurationTurns; // 0x230
	private bool hasStarted; // 0x234
	[Header("Turn Manager Settings - Public for TurnManager")]
	public int currentTurnSlot; // 0x238
	internal int totalPlayers; // 0x23C
	public int bossMaxHP; // 0x240
	public int currentBossHP; // 0x244
	public int currentTurnIndex; // 0x248
	[NonSerialized]
	public int pinnedAttackerActor; // 0x24C
	[NonSerialized]
	public bool pinnedAttackerIsBoss; // 0x250
	public int turnNumber; // 0x254
	public bool isTurnInProgress; // 0x258
	public float currentTurnTime; // 0x25C
	public int currentPlayerTurnIndex; // 0x260
	[CompilerGenerated]
	private Action<int> OnTurnStart; // 0x268
	[CompilerGenerated]
	private Action<int> OnTurnEndInternal; // 0x270
	[CompilerGenerated]
	private Action<int, float> OnTurnTimeUpdate; // 0x278
	[CompilerGenerated]
	private Action<int> OnTurnTimeout; // 0x280
	internal string lastStealType; // 0x288
	[Header("Game Result")]
	internal bool isCalculating; // 0x290
	[Header("Display Tracking")]
	public int lastDisplayedPlayerActor; // 0x294
	[CompilerGenerated]
	private static Active _Instance_k__BackingField; // 0x00
	[Header("Boss Auto Attack System")]
	public int bossAutoAttackManaThreshold; // 0x298
	public bool hasBossAutoAttackedThisTurn; // 0x29C
	public GameObject bossSkillEffect; // 0x2A0
	[Header("Boss Card Attack System")]
	public int bossCardManaThreshold; // 0x2A8
	public GameObject bossCardEffect; // 0x2B0
	public bool hasBossUsedCardThisTurn; // 0x2B8
	[Header("Boss Card Visual")]
	public Sprite bossCardSprite; // 0x2C0
	public Image bossCardImage; // 0x2C8
	public Canvas bossCardCanvas; // 0x2D0
	internal Coroutine noPlayerCoroutine; // 0x2D8
	internal Coroutine noNPCCoroutine; // 0x2E0
	internal Coroutine manaPlayerCoroutine; // 0x2E8
	internal Coroutine manaNPCCoroutine; // 0x2F0
	internal Coroutine hpPlayerCoroutine; // 0x2F8
	internal Coroutine hpNPCCoroutine; // 0x300
	internal TurnManager turnManager; // 0x308
	public PetUserDTO playerPets; // 0x310
	public PetUserDTO enemyPets; // 0x318
	internal bool dataFromManagerLoaded; // 0x320
	internal bool statsInitialized; // 0x321
	private string _appliedStatsSnapshotKey; // 0x328
	[Header("Co-op Turn System")]
	[SerializeField]
	internal List<int> activePlayers; // 0x330
	public int bossActorNumber; // 0x338
	[Header("Boss Move Tracking")]
	public bool hasBossMovedCurrentTurn; // 0x33C
	[Header("AntiCheat Tracking")]
	private int mauLuotTruoc; // 0x340
	private int mauBossDauLuot; // 0x344
	private int soVienXanhAnDuoc; // 0x348
	private int tongMauHoiTrongLuot; // 0x34C
	public int mauHoiTuThe; // 0x350
	private int damagePlayerGayChoBoss; // 0x354
	private int damageBossGayChoPlayer; // 0x358
	private int damageBossTuCard; // 0x35C
	private int mauNPCLuotTruoc; // 0x360
	private int soVienXanhNPCAnDuoc; // 0x364
	private int tongMauHoiNPCTrongLuot; // 0x368
	private int manaLuotTruoc; // 0x36C
	private int soVienXanhDuongAnDuoc; // 0x370
	public int manaHoiTuThe; // 0x374
	private int tongManaHoiTrongLuot; // 0x378
	private int manaHoiTuHut; // 0x37C
	public int manaTieuHaoTrongLuot; // 0x380
	private int manaBiHutBoiNPC; // 0x384
	private bool onAllDataLoadedSubscribed; // 0x388
	private float _emptyActiveWarnAt; // 0x38C
	private const float StatsMismatchTolerance = 0.05f; // Metadata: 0x0068D94B
	private const float SKILL_DAMAGE_POPUP_SCALE = 1.25f; // Metadata: 0x0068D94F
	private DamagePopupStyle _dmgPopupStyleSelf; // 0x390
	private DamagePopupStyle _dmgPopupStyleNpc; // 0x398
	internal static readonly string[] WsProcessOrder; // 0x08
	internal const float PopupStackStep = 46f; // Metadata: 0x0068D953
	[NonSerialized]
	public int pendingBlockDisplay; // 0x3A0
	private const float HEAL_POPUP_SEC = 1.05f; // Metadata: 0x0068D957
	private Coroutine _petAnimAutoReset; // 0x3A8

	// Properties
	internal int localActorNumber { get; } // 0x0000000180690850-0x0000000180690870 
	internal int LocalActorNumberOrZero { get; } // 0x00000001806905D0-0x0000000180690840 
	public int CurrentTurnIndex { get; } // 0x0000000180690410-0x0000000180690420 
	public int TurnNumber { get; } // 0x0000000180690840-0x0000000180690850 
	public bool IsTurnInProgress { get; } // 0x00000001806905C0-0x00000001806905D0 
	public bool IsPlayerTurnNew { get; } // 0x00000001806905B0-0x00000001806905C0 
	public bool IsNPCTurnNew { get; } // 0x0000000180690590-0x00000001806905B0 
	public float CurrentTurnTime { get; } // 0x0000000180690530-0x0000000180690540 
	public static Active Instance { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180690540-0x0000000180690590 0x0000000180690CA0-0x0000000180690D10
	public List<int> ActivePlayers { get; } // 0x0000000180690400-0x0000000180690410 
	public int CurrentTurnPlayerActorNumber { get; } // 0x0000000180690420-0x0000000180690530 

	// Events
	public event Action OnTurnEnd {
		add; // 0x00000001806900E0-0x0000000180690190
		remove; // 0x0000000180690940-0x00000001806909F0
	}
	public event Action<int> OnTurnStart {
		add; // 0x0000000180690190-0x0000000180690260
		remove; // 0x00000001806909F0-0x0000000180690AC0
	}
	public event Action<int> OnTurnEndInternal {
		add; // 0x0000000180690010-0x00000001806900E0
		remove; // 0x0000000180690870-0x0000000180690940
	}
	public event Action<int, float> OnTurnTimeUpdate {
		add; // 0x0000000180690260-0x0000000180690330
		remove; // 0x0000000180690AC0-0x0000000180690B90
	}
	public event Action<int> OnTurnTimeout {
		add; // 0x0000000180690330-0x0000000180690400
		remove; // 0x0000000180690B90-0x0000000180690C60
	}

	// Nested types
	[Serializable]
	public class PlayerStats // TypeDefIndex: 1796
	{
		// Fields
		public int actorNumber; // 0x10
		public ObfuscatedInt currentHP; // 0x14
		public ObfuscatedInt maxHP; // 0x24
		public ObfuscatedInt currentMana; // 0x34
		public ObfuscatedInt maxMana; // 0x44
		public ObfuscatedInt currentPower; // 0x54
		public ObfuscatedInt maxPower; // 0x64
		public ObfuscatedInt attack; // 0x74
		public ObfuscatedInt shield; // 0x84
		public int shieldCreatedTurn; // 0x94
		public double weakness; // 0x98
		public PetUserDTO petData; // 0xA0

		// Constructors
		public PlayerStats(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	internal class DamagePopupStyle // TypeDefIndex: 1797
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Vector3 scale; // 0x18
		public Color color; // 0x24
		public HorizontalWrapMode hOverflow; // 0x34
		public VerticalWrapMode vOverflow; // 0x38

		// Constructors
		public DamagePopupStyle(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1798
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<MatchPlayerSnapshotDTO> __9__189_0; // 0x08
		public static Comparison<MatchPlayerSnapshotDTO> __9__192_0; // 0x10

		// Constructors
		static __c(); // 0x000000018069C210-0x000000018069C280
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal int _InitializeActivePlayers_b__189_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x000000018069C100-0x000000018069C140
		internal int _InitializeStatsFromWsSnapshot_b__192_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x000000018069C100-0x000000018069C140
	}

	[CompilerGenerated]
	private sealed class _AnimateSlider_d__204 : IEnumerator<object> // TypeDefIndex: 1799
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Slider slider; // 0x20
		public float duration; // 0x28
		public float targetValue; // 0x2C
		private float _start_5__2; // 0x30
		private float _elapsed_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AnimateSlider_d__204(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806970B0-0x0000000180697270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180697270-0x00000001806972B0
	}

	[CompilerGenerated]
	private sealed class _AutoResetPetAnimationsAfter_d__249 : IEnumerator<object> // TypeDefIndex: 1800
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Active __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoResetPetAnimationsAfter_d__249(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806972B0-0x0000000180697390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180697390-0x00000001806973D0
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpBoth_d__236 : IEnumerator<object> // TypeDefIndex: 1801
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject obj1; // 0x20
		public GameObject obj2; // 0x28
		public float duration; // 0x30
		private CanvasGroup _cg1_5__2; // 0x38
		private RectTransform _rt1_5__3; // 0x40
		private Vector2 _startPos1_5__4; // 0x48
		private CanvasGroup _cg2_5__5; // 0x50
		private RectTransform _rt2_5__6; // 0x58
		private Vector2 _startPos2_5__7; // 0x60
		private float _elapsed_5__8; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpBoth_d__236(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806553E0-0x0000000180655440
		private bool MoveNext(); // 0x00000001806976F0-0x0000000180697B30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180697B30-0x0000000180697B70
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpSafe_d__235 : IEnumerator<object> // TypeDefIndex: 1802
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject obj; // 0x20
		public float duration; // 0x28
		private CanvasGroup _cg_5__2; // 0x30
		private RectTransform _rt_5__3; // 0x38
		private Vector2 _startPos_5__4; // 0x40
		private float _elapsed_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpSafe_d__235(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180425260-0x00000001804252A0
		private bool MoveNext(); // 0x0000000180697B70-0x0000000180697E30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180697E30-0x0000000180697E70
	}

	[CompilerGenerated]
	private sealed class _HealFxWatchdog_d__31 : IEnumerator<object> // TypeDefIndex: 1803
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float seconds; // 0x20
		public Animator anmt; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HealFxWatchdog_d__31(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806980E0-0x0000000180698230
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180698230-0x0000000180698270
	}

	[CompilerGenerated]
	private sealed class _OutputsParamSide_d__216 : IEnumerator<object> // TypeDefIndex: 1804
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool npcSide; // 0x20
		public string itemType; // 0x28
		public Active __4__this; // 0x30
		public bool isSkill; // 0x38
		private GameObject _dmgRoot_5__2; // 0x40
		private DamagePopupStyle _style_5__3; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OutputsParamSide_d__216(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180699320-0x0000000180699360
		private bool MoveNext(); // 0x0000000180698270-0x00000001806992E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806992E0-0x0000000180699320
	}

	[CompilerGenerated]
	private sealed class _PopupRiseAndFade_d__234 : IEnumerator<object> // TypeDefIndex: 1805
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject obj; // 0x20
		public float duration; // 0x28
		private CanvasGroup _cg_5__2; // 0x30
		private RectTransform _rt_5__3; // 0x38
		private Vector2 _startPos_5__4; // 0x40
		private Vector3 _startScale_5__5; // 0x48
		private float _e_5__6; // 0x54
		private float _rest_5__7; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PopupRiseAndFade_d__234(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180425260-0x00000001804252A0
		private bool MoveNext(); // 0x0000000180699860-0x0000000180699CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180699CF0-0x0000000180699D30
	}

	[CompilerGenerated]
	private sealed class _PopupStacked_d__223 : IEnumerator<object> // TypeDefIndex: 1806
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		public string tag; // 0x28
		public bool bossSide; // 0x30
		public int row; // 0x34
		private RectTransform _rt_5__2; // 0x38
		private Vector2 _basePos_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PopupStacked_d__223(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180699D30-0x000000018069A060
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069A060-0x000000018069A0A0
	}

	[CompilerGenerated]
	private sealed class _RenderWsBuffsTogether_d__221 : IEnumerator<object> // TypeDefIndex: 1807
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<KeyValuePair<string, int>> items; // 0x20
		public Active __4__this; // 0x28
		public bool wasFullPower; // 0x30
		public bool bossSide; // 0x31
		public bool deferHp; // 0x32

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsBuffsTogether_d__221(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069A0A0-0x000000018069A450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069A450-0x000000018069A490
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombat_d__226 : IEnumerator<object> // TypeDefIndex: 1808
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		public List<WsCombatStepDTO> steps; // 0x28
		public bool bossSide; // 0x30
		public bool wasFullPower; // 0x31
		public bool isSkill; // 0x32
		public bool auditionSkill; // 0x33
		private Dictionary<string, int> _byTag_5__2; // 0x38
		private int _boardDot_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombat_d__226(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x000000018069AA70-0x000000018069B0F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069B0F0-0x000000018069B130
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombatTag_d__219 : IEnumerator<object> // TypeDefIndex: 1809
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string tag; // 0x20
		public Active __4__this; // 0x28
		public int amount; // 0x30
		public bool wasFullPower; // 0x34
		public bool bossSide; // 0x35
		public bool isSkill; // 0x36
		public bool auditionSkill; // 0x37

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombatTag_d__219(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069A490-0x000000018069AA30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069AA30-0x000000018069AA70
	}

	[CompilerGenerated]
	private sealed class _RenderWsLifesteal_d__232 : IEnumerator<object> // TypeDefIndex: 1810
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int amount; // 0x20
		public Active __4__this; // 0x28
		public bool attackerNpcSide; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsLifesteal_d__232(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069B130-0x000000018069B2B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069B2B0-0x000000018069B2F0
	}

	[CompilerGenerated]
	private sealed class _SetAnimationForItemSide_d__245 : IEnumerator<object> // TypeDefIndex: 1811
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool npcSide; // 0x20
		public string itemType; // 0x28
		public bool wasFullPower; // 0x30
		public Active __4__this; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SetAnimationForItemSide_d__245(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018069B2F0-0x000000018069B830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018069B830-0x000000018069B870
	}

	[CompilerGenerated]
	private sealed class _ShowBlockPopup_d__230 : IEnumerator<object> // TypeDefIndex: 1812
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject node; // 0x20
		public int amount; // 0x28
		public Active __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ShowBlockPopup_d__230(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E3D30-0x00000001806E3EE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E3EE0-0x00000001806E3F20
	}

	[CompilerGenerated]
	private sealed class _WaitAndStartGame_d__205 : IEnumerator<object> // TypeDefIndex: 1813
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndStartGame_d__205(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E74C0-0x00000001806E75E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E75E0-0x00000001806E7620
	}

	[CompilerGenerated]
	private sealed class _WaitAndSubscribeOnAllDataLoaded_d__184 : IEnumerator<object> // TypeDefIndex: 1814
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSubscribeOnAllDataLoaded_d__184(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806E7620-0x00000001806E77A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806E77A0-0x00000001806E77E0
	}

	// Constructors
	public Active(); // 0x000000018068FDE0-0x0000000180690010
	static Active(); // 0x000000018068FC60-0x000000018068FDE0

	// Methods
	public void SyncStatsListForInspector(); // 0x000000018068F010-0x000000018068F1A0
	private void ShowHealFx(Animator anmt, bool self); // 0x000000018068DBC0-0x000000018068DE50
	private static float HealFxSeconds(Animator anmt); // 0x00000001806897F0-0x0000000180689930
	[IteratorStateMachine(typeof(_HealFxWatchdog_d__31))]
	private IEnumerator HealFxWatchdog(Animator anmt, float seconds); // 0x0000000180689930-0x00000001806899B0
	public void PinCascadeAttacker(); // 0x000000018068BDD0-0x000000018068BF40
	public void ClearCascadeAttacker(); // 0x0000000180689120-0x0000000180689140
	internal void Awake(); // 0x0000000180688A20-0x0000000180688B50
	private void TrySubscribeOnAllDataLoaded(); // 0x000000018068F1A0-0x000000018068F2A0
	[IteratorStateMachine(typeof(_WaitAndSubscribeOnAllDataLoaded_d__184))]
	private IEnumerator WaitAndSubscribeOnAllDataLoaded(); // 0x000000018068FBF0-0x000000018068FC60
	private void Start(); // 0x000000018068DE50-0x000000018068E3E0
	public void InitializeActivePlayers(); // 0x0000000180689D50-0x000000018068A1B0
	public bool IsCurrentPlayerTurn(int actorNumber); // 0x000000018068B870-0x000000018068B890
	internal void OnManagerMatchDataLoaded(); // 0x000000018068BCD0-0x000000018068BCE0
	public void InitializeStatsFromWsSnapshot(); // 0x000000018068A1B0-0x000000018068B730
	public void SyncDisplayActorToServerTurn(); // 0x000000018068E760-0x000000018068E820
	private int ResolveDisplayActorFromServerTurn(); // 0x000000018068D480-0x000000018068D6F0
	private static void ReconcileStatsWithMatchPrep(PlayerStats st, PetUserDTO prep, string who); // 0x000000018068C690-0x000000018068CB90
	private void RefreshLocalPetDisplayFromManager(); // 0x000000018068CB90-0x000000018068CF50
	public void SyncStatsFromWsSnapshot(); // 0x000000018068E820-0x000000018068F010
	public int ResolveWsActor(string username); // 0x000000018068D6F0-0x000000018068D830
	public void ApplyWsTurn(string currentTurnPlayerUsername, int serverTurnNumber); // 0x00000001806887E0-0x00000001806889A0
	public double GetWeaknessVsBoss(int playerActor); // 0x0000000180689460-0x00000001806894D0
	public double GetBossWeaknessVsPlayer(int playerActor); // 0x0000000180689260-0x00000001806892E0
	internal void InitializeStatsWithDefaults(); // 0x000000018068B730-0x000000018068B870
	[IteratorStateMachine(typeof(_AnimateSlider_d__204))]
	public IEnumerator AnimateSlider(Slider slider, float targetValue, float duration = 0.4f /* Metadata: 0x0068D937 */); // 0x00000001806884C0-0x0000000180688550
	[IteratorStateMachine(typeof(_WaitAndStartGame_d__205))]
	private IEnumerator WaitAndStartGame(); // 0x000000018068FBA0-0x000000018068FBF0
	internal void HandleTurnStartInternal(int entityIndex); // 0x0000000180689510-0x00000001806897F0
	private DamagePopupStyle ResolveDamagePopupStyle(GameObject root, bool npcSide); // 0x000000018068D390-0x000000018068D480
	internal static DamagePopupStyle CaptureDamagePopupStyle(GameObject root); // 0x0000000180688EE0-0x0000000180689120
	internal static void ApplyDamagePopupStyle(GameObject root, DamagePopupStyle style, int damage, bool isSkill); // 0x0000000180688550-0x00000001806887E0
	internal static void RestoreDamagePopupStyle(GameObject root, DamagePopupStyle style); // 0x000000018068D830-0x000000018068D950
	public IEnumerator OutputsParam(string itemType); // 0x000000018068BD90-0x000000018068BDD0
	[IteratorStateMachine(typeof(_OutputsParamSide_d__216))]
	public IEnumerator OutputsParamSide(string itemType, bool npcSide, bool isSkill = false /* Metadata: 0x0068D93B */); // 0x000000018068BCE0-0x000000018068BD90
	public Dictionary<string, int> BuildWsOutputsByTag(List<WsCombatStepDTO> steps); // 0x0000000180688B50-0x0000000180688EE0
	[IteratorStateMachine(typeof(_RenderWsCombatTag_d__219))]
	public IEnumerator RenderWsCombatTag(string tag, int amount, bool bossSide, bool wasFullPower, bool isSkill = false /* Metadata: 0x0068D93C */, bool auditionSkill = false /* Metadata: 0x0068D93D */); // 0x000000018068D0B0-0x000000018068D180
	private void PlayImpactFx(bool bossIsAttacker, int damage); // 0x000000018068BF40-0x000000018068C130
	[IteratorStateMachine(typeof(_RenderWsBuffsTogether_d__221))]
	public IEnumerator RenderWsBuffsTogether(List<KeyValuePair<string, int>> items, bool bossSide, bool wasFullPower, bool deferHp = false /* Metadata: 0x0068D93E */); // 0x000000018068CFF0-0x000000018068D0B0
	[IteratorStateMachine(typeof(_PopupStacked_d__223))]
	private IEnumerator PopupStacked(string tag, bool bossSide, int row); // 0x000000018068C560-0x000000018068C610
	private GameObject PopupNodeForTag(string tag, bool npcSide); // 0x000000018068C350-0x000000018068C4E0
	internal static MatchStatMask MaskForTag(string tag); // 0x000000018068B890-0x000000018068B9C0
	[IteratorStateMachine(typeof(_RenderWsCombat_d__226))]
	public IEnumerator RenderWsCombat(List<WsCombatStepDTO> steps, bool bossSide, bool wasFullPower = false /* Metadata: 0x0068D93F */, bool isSkill = false /* Metadata: 0x0068D940 */, bool auditionSkill = false /* Metadata: 0x0068D941 */); // 0x000000018068D180-0x000000018068D240
	public static int SumBlock(List<WsCombatStepDTO> steps); // 0x000000018068E3E0-0x000000018068E500
	public static int SumBoardDotDamage(List<WsCombatStepDTO> steps); // 0x000000018068E500-0x000000018068E640
	[IteratorStateMachine(typeof(_ShowBlockPopup_d__230))]
	internal IEnumerator ShowBlockPopup(GameObject node, int amount); // 0x000000018068DB20-0x000000018068DBC0
	public static int SumLifesteal(List<WsCombatStepDTO> steps); // 0x000000018068E640-0x000000018068E760
	[IteratorStateMachine(typeof(_RenderWsLifesteal_d__232))]
	public IEnumerator RenderWsLifesteal(int amount, bool attackerNpcSide); // 0x000000018068D240-0x000000018068D2D0
	[IteratorStateMachine(typeof(_PopupRiseAndFade_d__234))]
	internal IEnumerator PopupRiseAndFade(GameObject obj, float duration); // 0x000000018068C4E0-0x000000018068C560
	[IteratorStateMachine(typeof(_FadeAndMoveUpSafe_d__235))]
	internal IEnumerator FadeAndMoveUpSafe(GameObject obj, float duration); // 0x00000001806891E0-0x0000000180689260
	[IteratorStateMachine(typeof(_FadeAndMoveUpBoth_d__236))]
	internal IEnumerator FadeAndMoveUpBoth(GameObject obj1, GameObject obj2, float duration); // 0x0000000180689140-0x00000001806891E0
	internal float GetDamageMultiplier(int attackerActor, int defActor); // 0x00000001806892E0-0x0000000180689390
	public Animator GetPetAnimatorForActor(int actorNumber); // 0x0000000180689390-0x0000000180689460
	public void UpdateShieldIcons(bool refreshBars = true /* Metadata: 0x0068D942 */); // 0x000000018068F300-0x000000018068FBA0
	internal void HandleTurnEndInternal(int entityIndex); // 0x00000001806894D0-0x0000000180689510
	public void resetOutput(); // 0x0000000180690C60-0x0000000180690CA0
	public void IncreaseNoPlayer(CardInfo cardInfo); // 0x00000001806899B0-0x0000000180689D50
	internal void ResetPetAnimations(); // 0x000000018068D2D0-0x000000018068D390
	public IEnumerator SetAnimationForItem(string itemType, bool wasFullPower = false /* Metadata: 0x0068D943 */); // 0x000000018068DAE0-0x000000018068DB20
	[IteratorStateMachine(typeof(_SetAnimationForItemSide_d__245))]
	public IEnumerator SetAnimationForItemSide(string itemType, bool wasFullPower, bool npcSide); // 0x000000018068DA30-0x000000018068DAE0
	internal void PlayPetAnimationRPC(bool isPlayerAttack, bool fullPower = false /* Metadata: 0x0068D944 */); // 0x000000018068C130-0x000000018068C350
	internal void ScheduleAutoResetPetAnimations(float delaySec); // 0x000000018068D950-0x000000018068DA30
	[IteratorStateMachine(typeof(_AutoResetPetAnimationsAfter_d__249))]
	private IEnumerator AutoResetPetAnimationsAfter(float delaySec); // 0x00000001806889A0-0x0000000180688A20
	public void RaiseTurnStart(int actorNumber); // 0x000000018068C630-0x000000018068C670
	public void RaiseTurnEnd(); // 0x0000000180413A30-0x0000000180413A50
	public void RaiseTurnEndInternal(int actorNumber); // 0x000000018068C610-0x000000018068C630
	public void RaiseTurnTimeUpdate(int turnIndex, float time); // 0x000000018068C670-0x000000018068C690
	public bool RemovePlayerFromActiveTurns(int actorNumber); // 0x000000018068CF50-0x000000018068CFF0
	internal void OnDestroy(); // 0x000000018068B9C0-0x000000018068BCD0
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__239_0(); // 0x000000018068F2A0-0x000000018068F2D0
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__239_1(); // 0x000000018068F2D0-0x000000018068F300
}

