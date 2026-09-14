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

public class Active : MonoBehaviour // TypeDefIndex: 2157
{
	// Fields
	public Dictionary<int, PlayerStats> playerStatsMap; // 0x20
	[Header("Player Stats (Inspector View)")]
	[SerializeField]
	public List<PlayerStats> playerStatsList; // 0x28
	internal int enemyActorNumber; // 0x30
	public const int WS_BOSS_ACTOR = 99; // Metadata: 0x005F0779
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
	public Animator anmtHealP; // 0xA8
	public Animator anmtHealE; // 0xB0
	public GameObject offBoard; // 0xB8
	public GameObject dameATKPrefad; // 0xC0
	public GameObject dameATKPrefadNPC; // 0xC8
	[Header("UI Information")]
	public int inputKiem; // 0xD0
	public int outputKiem; // 0xD4
	public int finalDamageDisplay; // 0xD8
	public int inputGiap; // 0xDC
	public int outputGiap; // 0xE0
	public int inputMau; // 0xE4
	public int outputMau; // 0xE8
	public int inputHut; // 0xEC
	public int outputHut; // 0xF0
	public int inputNo; // 0xF4
	public int outputNo; // 0xF8
	public int inputMana; // 0xFC
	public int outputMana; // 0x100
	internal int sloMauAnDuoc; // 0x104
	internal int sloNoAnDuoc; // 0x108
	internal int sloHutAnDuoc; // 0x10C
	internal int sloGiapAnDuoc; // 0x110
	internal int sloManaAnDuoc; // 0x114
	internal int sloKiemAnDuoc; // 0x118
	public UnityEngine.UI.Text textMauPlayer; // 0x120
	public UnityEngine.UI.Text textManaPlayer; // 0x128
	public UnityEngine.UI.Text textNoPlayer; // 0x130
	public UnityEngine.UI.Text textMauNPC; // 0x138
	public UnityEngine.UI.Text textManaNPC; // 0x140
	public UnityEngine.UI.Text textNoNPC; // 0x148
	public GameObject healdMana; // 0x150
	public GameObject healdDEF; // 0x158
	public GameObject healdDEFNPC; // 0x160
	public GameObject healdPower; // 0x168
	public GameObject healdHP; // 0x170
	public GameObject healdManaNPC; // 0x178
	public GameObject healdPowerNPC; // 0x180
	public GameObject healdHPNPC; // 0x188
	public GameObject animationPet; // 0x190
	public GameObject animationBoss; // 0x198
	public int valueCurrent; // 0x1A0
	public UnityEngine.UI.Text nangLuong; // 0x1A8
	public UnityEngine.UI.Text leverPetUser; // 0x1B0
	public UnityEngine.UI.Text leverEnemyPet; // 0x1B8
	public UnityEngine.UI.Text namePetUser; // 0x1C0
	public UnityEngine.UI.Text namePetEnemy; // 0x1C8
	public UnityEngine.UI.Text dameTypePetUse; // 0x1D0
	public UnityEngine.UI.Text dameTypePetEnemy; // 0x1D8
	public List<CardInfo> cardInfos; // 0x1E0
	public ListCard listCard; // 0x1E8
	public Effect effect; // 0x1F0
	public ApiLoadRoom apiLoadRoom; // 0x1F8
	public GameObject onCard; // 0x200
	[Header("C\u1EA5u h\u00ECnh h\u1EC7 s\u1ED1")]
	public int GiapPlayerActiveAtTurn; // 0x208
	public int GiapNPCCreatedAtTurn; // 0x20C
	public int GiapNPCActiveAtTurn; // 0x210
	public int GiapPlayerCreatedAtTurn; // 0x214
	public float noGainPercent; // 0x218
	public float giapPercentPerPiece; // 0x21C
	public int shieldDurationTurns; // 0x220
	private bool hasStarted; // 0x224
	[Header("Turn Manager Settings - Public for TurnManager")]
	public int currentTurnSlot; // 0x228
	internal int totalPlayers; // 0x22C
	public int bossMaxHP; // 0x230
	public int currentBossHP; // 0x234
	public int currentTurnIndex; // 0x238
	[NonSerialized]
	public int pinnedAttackerActor; // 0x23C
	[NonSerialized]
	public bool pinnedAttackerIsBoss; // 0x240
	public int turnNumber; // 0x244
	public bool isTurnInProgress; // 0x248
	public float currentTurnTime; // 0x24C
	public int currentPlayerTurnIndex; // 0x250
	[CompilerGenerated]
	private Action<int> OnTurnStart; // 0x258
	[CompilerGenerated]
	private Action<int> OnTurnEndInternal; // 0x260
	[CompilerGenerated]
	private Action<int, float> OnTurnTimeUpdate; // 0x268
	[CompilerGenerated]
	private Action<int> OnTurnTimeout; // 0x270
	internal string lastStealType; // 0x278
	[Header("Game Result")]
	internal bool isCalculating; // 0x280
	[Header("Display Tracking")]
	public int lastDisplayedPlayerActor; // 0x284
	[CompilerGenerated]
	private static Active _Instance_k__BackingField; // 0x00
	[Header("Boss Auto Attack System")]
	public int bossAutoAttackManaThreshold; // 0x288
	public bool hasBossAutoAttackedThisTurn; // 0x28C
	public GameObject bossSkillEffect; // 0x290
	[Header("Boss Card Attack System")]
	public int bossCardManaThreshold; // 0x298
	public GameObject bossCardEffect; // 0x2A0
	public bool hasBossUsedCardThisTurn; // 0x2A8
	[Header("Boss Card Visual")]
	public Sprite bossCardSprite; // 0x2B0
	public Image bossCardImage; // 0x2B8
	public Canvas bossCardCanvas; // 0x2C0
	internal Coroutine noPlayerCoroutine; // 0x2C8
	internal Coroutine noNPCCoroutine; // 0x2D0
	internal Coroutine manaPlayerCoroutine; // 0x2D8
	internal Coroutine manaNPCCoroutine; // 0x2E0
	internal Coroutine hpPlayerCoroutine; // 0x2E8
	internal Coroutine hpNPCCoroutine; // 0x2F0
	internal TurnManager turnManager; // 0x2F8
	public PetUserDTO playerPets; // 0x300
	public PetUserDTO enemyPets; // 0x308
	internal bool dataFromManagerLoaded; // 0x310
	internal bool statsInitialized; // 0x311
	private string _appliedStatsSnapshotKey; // 0x318
	[Header("Co-op Turn System")]
	[SerializeField]
	internal List<int> activePlayers; // 0x320
	public int bossActorNumber; // 0x328
	[Header("Boss Move Tracking")]
	public bool hasBossMovedCurrentTurn; // 0x32C
	[Header("AntiCheat Tracking")]
	private int mauLuotTruoc; // 0x330
	private int mauBossDauLuot; // 0x334
	private int soVienXanhAnDuoc; // 0x338
	private int tongMauHoiTrongLuot; // 0x33C
	public int mauHoiTuThe; // 0x340
	private int damagePlayerGayChoBoss; // 0x344
	private int damageBossGayChoPlayer; // 0x348
	private int damageBossTuCard; // 0x34C
	private int mauNPCLuotTruoc; // 0x350
	private int soVienXanhNPCAnDuoc; // 0x354
	private int tongMauHoiNPCTrongLuot; // 0x358
	private int manaLuotTruoc; // 0x35C
	private int soVienXanhDuongAnDuoc; // 0x360
	public int manaHoiTuThe; // 0x364
	private int tongManaHoiTrongLuot; // 0x368
	private int manaHoiTuHut; // 0x36C
	public int manaTieuHaoTrongLuot; // 0x370
	private int manaBiHutBoiNPC; // 0x374
	private bool onAllDataLoadedSubscribed; // 0x378
	private float _emptyActiveWarnAt; // 0x37C
	private const float StatsMismatchTolerance = 0.05f; // Metadata: 0x005F077B
	private const float SKILL_DAMAGE_POPUP_SCALE = 1.25f; // Metadata: 0x005F077F
	private DamagePopupStyle _dmgPopupStyleSelf; // 0x380
	private DamagePopupStyle _dmgPopupStyleNpc; // 0x388
	internal static readonly string[] WsProcessOrder; // 0x08
	private bool _ragePopupBusy; // 0x390
	internal const float PopupStackStep = 46f; // Metadata: 0x005F0783
	[NonSerialized]
	public int pendingBlockDisplay; // 0x394
	private const float HEAL_POPUP_SEC = 1.05f; // Metadata: 0x005F0787
	private Coroutine _petAnimAutoReset; // 0x398

	// Properties
	internal int localActorNumber { get; } // 0x0000000180A23390-0x0000000180A233B0 
	internal int LocalActorNumberOrZero { get; } // 0x0000000180A233B0-0x0000000180A23690 
	public int CurrentTurnIndex { get; } // 0x0000000180A23AD0-0x0000000180A23AE0 
	public int TurnNumber { get; } // 0x0000000180481B30-0x0000000180481B40 
	public bool IsTurnInProgress { get; } // 0x0000000180481B40-0x0000000180481B50 
	public bool IsPlayerTurnNew { get; } // 0x0000000180A23AE0-0x0000000180A23AF0 
	public bool IsNPCTurnNew { get; } // 0x0000000180A23AF0-0x0000000180A23B10 
	public float CurrentTurnTime { get; } // 0x0000000180481B80-0x0000000180481B90 
	public static Active Instance { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180A24410-0x0000000180A24470 0x0000000180A24470-0x0000000180A24520
	public List<int> ActivePlayers { get; } // 0x0000000180A24520-0x0000000180A24530 
	public int CurrentTurnPlayerActorNumber { get; } // 0x0000000180A250E0-0x0000000180A25260 

	// Events
	public event Action OnTurnEnd {
		add; // 0x0000000180A23690-0x0000000180A23790
		remove; // 0x0000000180A23790-0x0000000180A23890
	}
	public event Action<int> OnTurnStart {
		add; // 0x0000000180A23B10-0x0000000180A23C30
		remove; // 0x0000000180A23C30-0x0000000180A23D50
	}
	public event Action<int> OnTurnEndInternal {
		add; // 0x0000000180A23D50-0x0000000180A23E70
		remove; // 0x0000000180A23E70-0x0000000180A23F90
	}
	public event Action<int, float> OnTurnTimeUpdate {
		add; // 0x0000000180A23F90-0x0000000180A240B0
		remove; // 0x0000000180A240B0-0x0000000180A241D0
	}
	public event Action<int> OnTurnTimeout {
		add; // 0x0000000180A241D0-0x0000000180A242F0
		remove; // 0x0000000180A242F0-0x0000000180A24410
	}

	// Nested types
	[Serializable]
	public class PlayerStats // TypeDefIndex: 2158
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
		public int[] equipCounter; // 0xA0
		public PetUserDTO petData; // 0xA8

		// Constructors
		public PlayerStats(); // 0x000000018028A320-0x000000018028A330
	}

	internal class DamagePopupStyle // TypeDefIndex: 2159
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Vector3 scale; // 0x18
		public Color color; // 0x24
		public HorizontalWrapMode hOverflow; // 0x34
		public VerticalWrapMode vOverflow; // 0x38

		// Constructors
		public DamagePopupStyle(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2160
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<MatchPlayerSnapshotDTO> __9__183_0; // 0x08
		public static Comparison<MatchPlayerSnapshotDTO> __9__186_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180A2EFA0-0x0000000180A2F040
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _InitializeActivePlayers_b__183_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x0000000180A2F040-0x0000000180A2F070
		internal int _InitializeStatsFromWsSnapshot_b__186_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x0000000180A2F040-0x0000000180A2F070
	}

	[CompilerGenerated]
	private sealed class _AnimateSlider_d__198 : IEnumerator<object> // TypeDefIndex: 2161
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AnimateSlider_d__198(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A2F070-0x0000000180A2F340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A2F340-0x0000000180A2F380
	}

	[CompilerGenerated]
	private sealed class _AutoResetPetAnimationsAfter_d__246 : IEnumerator<object> // TypeDefIndex: 2162
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Active __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoResetPetAnimationsAfter_d__246(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A2F380-0x0000000180A2F4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A2F4D0-0x0000000180A2F510
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpBoth_d__233 : IEnumerator<object> // TypeDefIndex: 2163
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpBoth_d__233(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807A2D50-0x00000001807A2EB0
		private bool MoveNext(); // 0x0000000180A2F510-0x0000000180A2FD60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A2FD60-0x0000000180A2FDA0
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpSafe_d__232 : IEnumerator<object> // TypeDefIndex: 2164
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpSafe_d__232(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180469F80-0x000000018046A040
		private bool MoveNext(); // 0x0000000180A2FDA0-0x0000000180A30340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A30340-0x0000000180A30380
	}

	[CompilerGenerated]
	private sealed class _OutputsParamSide_d__210 : IEnumerator<object> // TypeDefIndex: 2165
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
		private GameObject _toObj_5__4; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OutputsParamSide_d__210(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807A3E40-0x00000001807A3F50
		private bool MoveNext(); // 0x0000000180A30380-0x0000000180A311F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A311F0-0x0000000180A31230
	}

	[CompilerGenerated]
	private sealed class _PopupRiseAndFade_d__231 : IEnumerator<object> // TypeDefIndex: 2166
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PopupRiseAndFade_d__231(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180469F80-0x000000018046A040
		private bool MoveNext(); // 0x0000000180A31230-0x0000000180A31AC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A31AC0-0x0000000180A31B00
	}

	[CompilerGenerated]
	private sealed class _PopupStacked_d__220 : IEnumerator<object> // TypeDefIndex: 2167
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PopupStacked_d__220(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180A31B00-0x0000000180A31FB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A31FB0-0x0000000180A31FF0
	}

	[CompilerGenerated]
	private sealed class _RageSpendPopupRoutine_d__216 : IEnumerator<object> // TypeDefIndex: 2168
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		public GameObject node; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RageSpendPopupRoutine_d__216(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180A31FF0-0x0000000180A32060
		private bool MoveNext(); // 0x0000000180A32060-0x0000000180A323B0
		private void __m__Finally1(); // 0x0000000180A323B0-0x0000000180A32520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A32520-0x0000000180A32560
	}

	[CompilerGenerated]
	private sealed class _RenderWsBuffsTogether_d__218 : IEnumerator<object> // TypeDefIndex: 2169
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsBuffsTogether_d__218(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A32560-0x0000000180A32AB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A32AB0-0x0000000180A32AF0
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombat_d__223 : IEnumerator<object> // TypeDefIndex: 2170
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombat_d__223(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x0000000180A32AF0-0x0000000180A33340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A33340-0x0000000180A33380
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombatTag_d__213 : IEnumerator<object> // TypeDefIndex: 2171
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombatTag_d__213(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A33380-0x0000000180A33A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A33A60-0x0000000180A33AA0
	}

	[CompilerGenerated]
	private sealed class _RenderWsLifesteal_d__229 : IEnumerator<object> // TypeDefIndex: 2172
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int amount; // 0x20
		public Active __4__this; // 0x28
		public bool attackerNpcSide; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsLifesteal_d__229(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A33AA0-0x0000000180A33C80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A33C80-0x0000000180A33CC0
	}

	[CompilerGenerated]
	private sealed class _SetAnimationForItemSide_d__242 : IEnumerator<object> // TypeDefIndex: 2173
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool npcSide; // 0x20
		public string itemType; // 0x28
		public bool wasFullPower; // 0x30
		public Active __4__this; // 0x38
		public bool rageBurst; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SetAnimationForItemSide_d__242(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A33CC0-0x0000000180A348A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A348A0-0x0000000180A348E0
	}

	[CompilerGenerated]
	private sealed class _ShowBlockPopup_d__227 : IEnumerator<object> // TypeDefIndex: 2174
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject node; // 0x20
		public int amount; // 0x28
		public Active __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ShowBlockPopup_d__227(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A348E0-0x0000000180A34BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A34BC0-0x0000000180A34D60
	}

	[CompilerGenerated]
	private sealed class _WaitAndStartGame_d__199 : IEnumerator<object> // TypeDefIndex: 2175
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndStartGame_d__199(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A6D7F0-0x0000000180A6D8F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A6D8F0-0x0000000180A6D930
	}

	[CompilerGenerated]
	private sealed class _WaitAndSubscribeOnAllDataLoaded_d__178 : IEnumerator<object> // TypeDefIndex: 2176
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSubscribeOnAllDataLoaded_d__178(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A6D930-0x0000000180A6DB40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A6DB40-0x0000000180A6DB80
	}

	// Constructors
	public Active(); // 0x0000000180A2E8D0-0x0000000180A2ECC0
	static Active(); // 0x0000000180A2ECC0-0x0000000180A2EE80

	// Methods
	public void SyncStatsListForInspector(); // 0x0000000180A231C0-0x0000000180A23390
	public void PinCascadeAttacker(); // 0x0000000180A23890-0x0000000180A23AB0
	public void ClearCascadeAttacker(); // 0x0000000180A23AB0-0x0000000180A23AD0
	internal void Awake(); // 0x0000000180A24530-0x0000000180A24630
	private void TrySubscribeOnAllDataLoaded(); // 0x0000000180A24630-0x0000000180A248A0
	[IteratorStateMachine(typeof(_WaitAndSubscribeOnAllDataLoaded_d__178))]
	private IEnumerator WaitAndSubscribeOnAllDataLoaded(); // 0x0000000180A248A0-0x0000000180A24940
	private void Start(); // 0x0000000180A24940-0x0000000180A250E0
	public void InitializeActivePlayers(); // 0x0000000180A25260-0x0000000180A25790
	public bool IsCurrentPlayerTurn(int actorNumber); // 0x0000000180A25790-0x0000000180A257B0
	internal void OnManagerMatchDataLoaded(); // 0x0000000180A257B0-0x0000000180A257C0
	public void InitializeStatsFromWsSnapshot(); // 0x0000000180A257C0-0x0000000180A26F30
	public void SyncDisplayActorToServerTurn(); // 0x0000000180A26F30-0x0000000180A27070
	private int ResolveDisplayActorFromServerTurn(); // 0x0000000180A27070-0x0000000180A27420
	private static void ReconcileStatsWithMatchPrep(PlayerStats st, PetUserDTO prep, string who); // 0x0000000180A27420-0x0000000180A27F60
	private void RefreshLocalPetDisplayFromManager(); // 0x0000000180A27F60-0x0000000180A28340
	public void SyncStatsFromWsSnapshot(); // 0x0000000180A28340-0x0000000180A28CC0
	public int ResolveWsActor(string username); // 0x0000000180A28CC0-0x0000000180A28E90
	public void ApplyWsTurn(string currentTurnPlayerUsername, int serverTurnNumber); // 0x0000000180A28E90-0x0000000180A29110
	public double GetWeaknessVsBoss(int playerActor); // 0x0000000180A29110-0x0000000180A29180
	public double GetBossWeaknessVsPlayer(int playerActor); // 0x0000000180A29180-0x0000000180A291B0
	internal void InitializeStatsWithDefaults(); // 0x0000000180A291B0-0x0000000180A29300
	[IteratorStateMachine(typeof(_AnimateSlider_d__198))]
	public IEnumerator AnimateSlider(Slider slider, float targetValue, float duration = 0.4f /* Metadata: 0x005F076A */); // 0x0000000180A29300-0x0000000180A293C0
	[IteratorStateMachine(typeof(_WaitAndStartGame_d__199))]
	private IEnumerator WaitAndStartGame(); // 0x0000000180A293C0-0x0000000180A29400
	internal void HandleTurnStartInternal(int entityIndex); // 0x0000000180A29400-0x0000000180A29A30
	private DamagePopupStyle ResolveDamagePopupStyle(GameObject root, bool npcSide); // 0x0000000180A29A30-0x0000000180A29C50
	internal static DamagePopupStyle CaptureDamagePopupStyle(GameObject root); // 0x0000000180A29C50-0x0000000180A2A130
	internal static void ApplyDamagePopupStyle(GameObject root, DamagePopupStyle style, int damage, bool isSkill); // 0x0000000180A2A130-0x0000000180A2A570
	internal static void RestoreDamagePopupStyle(GameObject root, DamagePopupStyle style); // 0x0000000180A2A570-0x0000000180A2A7E0
	public IEnumerator OutputsParam(string itemType); // 0x0000000180A2A7E0-0x0000000180A2A820
	[IteratorStateMachine(typeof(_OutputsParamSide_d__210))]
	public IEnumerator OutputsParamSide(string itemType, bool npcSide, bool isSkill = false /* Metadata: 0x005F076E */); // 0x0000000180A2A820-0x0000000180A2A950
	public Dictionary<string, int> BuildWsOutputsByTag(List<WsCombatStepDTO> steps); // 0x0000000180A2A950-0x0000000180A2AFD0
	[IteratorStateMachine(typeof(_RenderWsCombatTag_d__213))]
	public IEnumerator RenderWsCombatTag(string tag, int amount, bool bossSide, bool wasFullPower, bool isSkill = false /* Metadata: 0x005F076F */, bool auditionSkill = false /* Metadata: 0x005F0770 */); // 0x0000000180A2AFD0-0x0000000180A2B110
	private void ShowRageSpendPopup(bool bossSide); // 0x0000000180A2B110-0x0000000180A2B390
	[IteratorStateMachine(typeof(_RageSpendPopupRoutine_d__216))]
	private IEnumerator RageSpendPopupRoutine(GameObject node); // 0x0000000180A2B390-0x0000000180A2B4A0
	private void PlayImpactFx(bool bossIsAttacker, int damage); // 0x0000000180A2B4A0-0x0000000180A2B800
	[IteratorStateMachine(typeof(_RenderWsBuffsTogether_d__218))]
	public IEnumerator RenderWsBuffsTogether(List<KeyValuePair<string, int>> items, bool bossSide, bool wasFullPower, bool deferHp = false /* Metadata: 0x005F0771 */); // 0x0000000180A2B800-0x0000000180A2B940
	[IteratorStateMachine(typeof(_PopupStacked_d__220))]
	private IEnumerator PopupStacked(string tag, bool bossSide, int row); // 0x0000000180A2B940-0x0000000180A2BA70
	private GameObject PopupNodeForTag(string tag, bool npcSide); // 0x0000000180A2BA70-0x0000000180A2BCC0
	internal static MatchStatMask MaskForTag(string tag); // 0x0000000180A2BCC0-0x0000000180A2BF20
	[IteratorStateMachine(typeof(_RenderWsCombat_d__223))]
	public IEnumerator RenderWsCombat(List<WsCombatStepDTO> steps, bool bossSide, bool wasFullPower = false /* Metadata: 0x005F0772 */, bool isSkill = false /* Metadata: 0x005F0773 */, bool auditionSkill = false /* Metadata: 0x005F0774 */); // 0x0000000180A2BF20-0x0000000180A2C060
	public static int SumBlock(List<WsCombatStepDTO> steps); // 0x0000000180A2C060-0x0000000180A2C1E0
	public static int SumBoardDotDamage(List<WsCombatStepDTO> steps); // 0x0000000180A2C1E0-0x0000000180A2C3C0
	[IteratorStateMachine(typeof(_ShowBlockPopup_d__227))]
	internal IEnumerator ShowBlockPopup(GameObject node, int amount); // 0x0000000180A2C3C0-0x0000000180A2C4D0
	public static int SumLifesteal(List<WsCombatStepDTO> steps); // 0x0000000180A2C4D0-0x0000000180A2C650
	[IteratorStateMachine(typeof(_RenderWsLifesteal_d__229))]
	public IEnumerator RenderWsLifesteal(int amount, bool attackerNpcSide); // 0x0000000180A2C650-0x0000000180A2C710
	[IteratorStateMachine(typeof(_PopupRiseAndFade_d__231))]
	internal IEnumerator PopupRiseAndFade(GameObject obj, float duration); // 0x0000000180A2C710-0x0000000180A2C7D0
	[IteratorStateMachine(typeof(_FadeAndMoveUpSafe_d__232))]
	internal IEnumerator FadeAndMoveUpSafe(GameObject obj, float duration); // 0x0000000180A2C7D0-0x0000000180A2C890
	[IteratorStateMachine(typeof(_FadeAndMoveUpBoth_d__233))]
	internal IEnumerator FadeAndMoveUpBoth(GameObject obj1, GameObject obj2, float duration); // 0x0000000180A2C890-0x0000000180A2C9B0
	internal float GetDamageMultiplier(int attackerActor, int defActor); // 0x0000000180A2C9B0-0x0000000180A2CA20
	public Animator GetPetAnimatorForActor(int actorNumber); // 0x0000000180A2CA20-0x0000000180A2CB30
	public void UpdateShieldIcons(bool refreshBars = true /* Metadata: 0x005F0775 */); // 0x0000000180A2CB30-0x0000000180A2D5A0
	internal void HandleTurnEndInternal(int entityIndex); // 0x0000000180A2D5A0-0x0000000180A2D5E0
	public void resetOutput(); // 0x0000000180486640-0x0000000180486680
	public void IncreaseNoPlayer(CardInfo cardInfo); // 0x0000000180A2D5E0-0x0000000180A2DAD0
	internal void ResetPetAnimations(); // 0x0000000180A2DAD0-0x0000000180A2DC90
	public IEnumerator SetAnimationForItem(string itemType, bool wasFullPower = false /* Metadata: 0x005F0776 */); // 0x0000000180A2DC90-0x0000000180A2DCD0
	[IteratorStateMachine(typeof(_SetAnimationForItemSide_d__242))]
	public IEnumerator SetAnimationForItemSide(string itemType, bool wasFullPower, bool npcSide, bool rageBurst = true /* Metadata: 0x005F0777 */); // 0x0000000180A2DCD0-0x0000000180A2DE10
	internal void PlayPetAnimationRPC(bool isPlayerAttack, bool fullPower = false /* Metadata: 0x005F0778 */); // 0x0000000180A2DE10-0x0000000180A2E1F0
	internal void ScheduleAutoResetPetAnimations(float delaySec); // 0x0000000180A2E1F0-0x0000000180A2E3A0
	[IteratorStateMachine(typeof(_AutoResetPetAnimationsAfter_d__246))]
	private IEnumerator AutoResetPetAnimationsAfter(float delaySec); // 0x0000000180A2E3A0-0x0000000180A2E460
	public void RaiseTurnStart(int actorNumber); // 0x0000000180A2E460-0x0000000180A2E4A0
	public void RaiseTurnEnd(); // 0x0000000180487610-0x0000000180487630
	public void RaiseTurnEndInternal(int actorNumber); // 0x0000000180487630-0x0000000180487650
	public void RaiseTurnTimeUpdate(int turnIndex, float time); // 0x0000000180487650-0x0000000180487670
	public bool RemovePlayerFromActiveTurns(int actorNumber); // 0x0000000180A2E4A0-0x0000000180A2E540
	internal void OnDestroy(); // 0x0000000180A2E540-0x0000000180A2E8D0
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__236_0(); // 0x0000000180A2EE80-0x0000000180A2EF10
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__236_1(); // 0x0000000180A2EF10-0x0000000180A2EFA0
}

