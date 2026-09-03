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

public class ActivePVP : MonoBehaviour // TypeDefIndex: 82
{
	// Fields
	public Dictionary<int, PlayerStats> playerStatsMap; // 0x20
	[Header("Player Stats (Inspector View)")]
	[SerializeField]
	public List<PlayerStats> playerStatsList; // 0x28
	private int _cachedWsLocalActor; // 0x30
	public const int WS_NO_BOSS = 0; // Metadata: 0x0064BF9D
	[Header("UI Object")]
	public BoardPVP board; // 0x38
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
	private readonly Queue<HandleUISyncPayload> _handleUISyncQueue; // 0x120
	public UnityEngine.UI.Text textMauPlayer; // 0x128
	public UnityEngine.UI.Text textManaPlayer; // 0x130
	public UnityEngine.UI.Text textNoPlayer; // 0x138
	public UnityEngine.UI.Text textMauNPC; // 0x140
	public UnityEngine.UI.Text textManaNPC; // 0x148
	public UnityEngine.UI.Text textNoNPC; // 0x150
	public GameObject healdMana; // 0x158
	public GameObject healdDEF; // 0x160
	public GameObject healdDEFNPC; // 0x168
	public GameObject healdPower; // 0x170
	public GameObject healdHP; // 0x178
	public GameObject healdManaNPC; // 0x180
	public GameObject healdPowerNPC; // 0x188
	public GameObject healdHPNPC; // 0x190
	public GameObject animationPet; // 0x198
	public GameObject animationBoss; // 0x1A0
	public int valueCurrent; // 0x1A8
	public UnityEngine.UI.Text nangLuong; // 0x1B0
	public UnityEngine.UI.Text leverPetUser; // 0x1B8
	public UnityEngine.UI.Text leverEnemyPet; // 0x1C0
	public UnityEngine.UI.Text namePetUser; // 0x1C8
	public UnityEngine.UI.Text namePetEnemy; // 0x1D0
	public UnityEngine.UI.Text dameTypePetUse; // 0x1D8
	public UnityEngine.UI.Text dameTypePetEnemy; // 0x1E0
	public List<CardInfo> cardInfos; // 0x1E8
	public ListCard listCard; // 0x1F0
	public Effect effect; // 0x1F8
	public ApiLoadRoom apiLoadRoom; // 0x200
	public GameObject onCard; // 0x208
	[Header("C\u1EA5u h\u00ECnh h\u1EC7 s\u1ED1")]
	public int GiapPlayerActiveAtTurn; // 0x210
	public int GiapNPCCreatedAtTurn; // 0x214
	public int GiapNPCActiveAtTurn; // 0x218
	public int GiapPlayerCreatedAtTurn; // 0x21C
	public float noGainPercent; // 0x220
	public float giapPercentPerPiece; // 0x224
	public int shieldDurationTurns; // 0x228
	private bool hasStarted; // 0x22C
	[Header("Turn Manager Settings - Public for TurnManager")]
	public int currentTurnSlot; // 0x230
	internal int totalPlayers; // 0x234
	public int bossMaxHP; // 0x238
	public int currentBossHP; // 0x23C
	public int currentTurnIndex; // 0x240
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
	private static ActivePVP _Instance_k__BackingField; // 0x00
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
	internal TurnManagerPVP turnManager; // 0x2F8
	public PetUserDTO playerPets; // 0x300
	public PetUserDTO enemyPets; // 0x308
	internal bool dataFromManagerLoaded; // 0x310
	internal bool statsInitialized; // 0x311
	[Header("Co-op Turn System")]
	[SerializeField]
	internal List<int> activePlayers; // 0x318
	public int bossActorNumber; // 0x320
	[Header("Boss Move Tracking")]
	public bool hasBossMovedCurrentTurn; // 0x324
	[Header("AntiCheat Tracking")]
	private int mauLuotTruoc; // 0x328
	private int mauBossDauLuot; // 0x32C
	private int soVienXanhAnDuoc; // 0x330
	private int tongMauHoiTrongLuot; // 0x334
	public int mauHoiTuThe; // 0x338
	private int damagePlayerGayChoBoss; // 0x33C
	private int damageBossGayChoPlayer; // 0x340
	private int damageBossTuCard; // 0x344
	private int mauNPCLuotTruoc; // 0x348
	private int soVienXanhNPCAnDuoc; // 0x34C
	private int tongMauHoiNPCTrongLuot; // 0x350
	private int manaLuotTruoc; // 0x354
	private int soVienXanhDuongAnDuoc; // 0x358
	public int manaHoiTuThe; // 0x35C
	private int tongManaHoiTrongLuot; // 0x360
	private int manaHoiTuHut; // 0x364
	public int manaTieuHaoTrongLuot; // 0x368
	private int manaBiHutBoiNPC; // 0x36C
	private Active.DamagePopupStyle _dmgPopupStyleRight; // 0x370
	private Active.DamagePopupStyle _dmgPopupStyleLeft; // 0x378
	[NonSerialized]
	public int pendingBlockDisplay; // 0x380
	private Coroutine _petAnimAutoReset; // 0x388

	// Properties
	public int LocalOpponentActorNumber { get; } // 0x0000000180517750-0x0000000180517780 
	internal int localActorNumber { get; } // 0x0000000180517790-0x00000001805179A0 
	internal int HandleUISyncPendingCount { get; } // 0x00000001805176B0-0x00000001805176D0 
	public int CurrentTurnIndex { get; } // 0x0000000180517470-0x0000000180517480 
	public int TurnNumber { get; } // 0x0000000180517780-0x0000000180517790 
	public bool IsTurnInProgress { get; } // 0x0000000180517740-0x0000000180517750 
	public bool IsMyTurn { get; } // 0x0000000180517710-0x0000000180517740 
	public float CurrentTurnTime { get; } // 0x00000001805176A0-0x00000001805176B0 
	public static ActivePVP Instance { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001805176D0-0x0000000180517710 0x0000000180517DD0-0x0000000180517E30
	public List<int> ActivePlayers { get; } // 0x0000000180517460-0x0000000180517470 
	public int CurrentTurnPlayerActorNumber { get; } // 0x0000000180517480-0x00000001805176A0 

	// Events
	public event Action OnTurnEnd {
		add; // 0x0000000180517140-0x00000001805171F0
		remove; // 0x0000000180517A70-0x0000000180517B20
	}
	public event Action<int> OnTurnStart {
		add; // 0x00000001805171F0-0x00000001805172C0
		remove; // 0x0000000180517B20-0x0000000180517BF0
	}
	public event Action<int> OnTurnEndInternal {
		add; // 0x0000000180517070-0x0000000180517140
		remove; // 0x00000001805179A0-0x0000000180517A70
	}
	public event Action<int, float> OnTurnTimeUpdate {
		add; // 0x00000001805172C0-0x0000000180517390
		remove; // 0x0000000180517BF0-0x0000000180517CC0
	}
	public event Action<int> OnTurnTimeout {
		add; // 0x0000000180517390-0x0000000180517460
		remove; // 0x0000000180517CC0-0x0000000180517D90
	}

	// Nested types
	[Serializable]
	public class PlayerStats // TypeDefIndex: 83
	{
		// Fields
		public int actorNumber; // 0x10
		public int teamId; // 0x14
		public int slotInTeam; // 0x18
		public ObfuscatedInt currentHP; // 0x1C
		public ObfuscatedInt maxHP; // 0x2C
		public ObfuscatedInt currentMana; // 0x3C
		public ObfuscatedInt maxMana; // 0x4C
		public ObfuscatedInt currentPower; // 0x5C
		public ObfuscatedInt maxPower; // 0x6C
		public ObfuscatedInt attack; // 0x7C
		public ObfuscatedInt shield; // 0x8C
		public int shieldCreatedTurn; // 0x9C
		public double weaknessValue; // 0xA0
		public PetUserDTO petData; // 0xA8

		// Constructors
		public PlayerStats(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	internal sealed class HandleUISyncPayload // TypeDefIndex: 84
	{
		// Fields
		public int turnIndex; // 0x10
		public int[] actors; // 0x18
		public int[] hp; // 0x20
		public int[] mana; // 0x28
		public int[] power; // 0x30
		public int[] shield; // 0x38
		public int[] shieldTurn; // 0x40
		public int finalDamageDisplay; // 0x48
		public int outputGiap; // 0x4C
		public int outputNo; // 0x50
		public int outputMau; // 0x54
		public int outputMana; // 0x58
		public int outputHut; // 0x5C
		public int stealTypeByte; // 0x60

		// Constructors
		public HandleUISyncPayload(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 85
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<MatchPlayerSnapshotDTO> __9__180_0; // 0x08

		// Constructors
		static __c(); // 0x000000018052BEC0-0x000000018052BF30
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _InitializeStatsFromWsSnapshot_b__180_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x000000018052BAA0-0x000000018052BB00
	}

	[CompilerGenerated]
	private sealed class _AnimateSlider_d__183 : IEnumerator<object> // TypeDefIndex: 86
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AnimateSlider_d__183(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180522970-0x0000000180522B30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180522B30-0x0000000180522B70
	}

	[CompilerGenerated]
	private sealed class _AutoResetPetAnimationsAfter_d__208 : IEnumerator<object> // TypeDefIndex: 87
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public ActivePVP __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoResetPetAnimationsAfter_d__208(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180522E60-0x0000000180522F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180522F40-0x0000000180522F80
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpBoth_d__199 : IEnumerator<object> // TypeDefIndex: 88
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpBoth_d__199(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180526250-0x00000001805262B0
		private bool MoveNext(); // 0x0000000180525DD0-0x0000000180526210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180526210-0x0000000180526250
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpSafe_d__198 : IEnumerator<object> // TypeDefIndex: 89
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeAndMoveUpSafe_d__198(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
		private bool MoveNext(); // 0x00000001805262B0-0x0000000180526570
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180526570-0x00000001805265B0
	}

	[CompilerGenerated]
	private sealed class _OutputsParam_d__185 : IEnumerator<object> // TypeDefIndex: 90
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ActivePVP __4__this; // 0x20
		public string itemType; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OutputsParam_d__185(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180528750-0x00000001805287F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805287F0-0x0000000180528830
	}

	[CompilerGenerated]
	private sealed class _OutputsParam_d__197 : IEnumerator<object> // TypeDefIndex: 91
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int attackerActor; // 0x20
		public ActivePVP __4__this; // 0x28
		public string itemType; // 0x30
		public bool isSkill; // 0x38
		private GameObject _target_5__2; // 0x40
		private Active.DamagePopupStyle _style_5__3; // 0x48
		private GameObject _toObj_5__4; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OutputsParam_d__197(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805293F0-0x0000000180529440
		private bool MoveNext(); // 0x0000000180528830-0x00000001805293B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805293B0-0x00000001805293F0
	}

	[CompilerGenerated]
	private sealed class _PopupStacked_d__196 : IEnumerator<object> // TypeDefIndex: 92
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int attackerActor; // 0x20
		public ActivePVP __4__this; // 0x28
		public string tag; // 0x30
		public int row; // 0x38
		private RectTransform _rt_5__2; // 0x40
		private Vector2 _basePos_5__3; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PopupStacked_d__196(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018032E010-0x000000018032E040
		private bool MoveNext(); // 0x0000000180529440-0x0000000180529770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180529770-0x00000001805297B0
	}

	[CompilerGenerated]
	private sealed class _RenderWsBuffsTogether_d__195 : IEnumerator<object> // TypeDefIndex: 93
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<KeyValuePair<string, int>> items; // 0x20
		public ActivePVP __4__this; // 0x28
		public bool wasFullPower; // 0x30
		public int attackerActor; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsBuffsTogether_d__195(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805297B0-0x0000000180529BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180529BB0-0x0000000180529BF0
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombat_d__189 : IEnumerator<object> // TypeDefIndex: 94
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ActivePVP __4__this; // 0x20
		public List<WsCombatStepDTO> steps; // 0x28
		public int attackerActor; // 0x30
		public bool wasFullPower; // 0x34
		public bool isSkill; // 0x35
		public bool auditionSkill; // 0x36
		private Dictionary<string, int> _byTag_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombat_d__189(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x000000018052A230-0x000000018052A6D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052A6D0-0x000000018052A710
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombatTag_d__194 : IEnumerator<object> // TypeDefIndex: 95
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string tag; // 0x20
		public ActivePVP __4__this; // 0x28
		public int amount; // 0x30
		public bool wasFullPower; // 0x34
		public int attackerActor; // 0x38
		public bool isSkill; // 0x3C
		public bool auditionSkill; // 0x3D

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombatTag_d__194(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180529BF0-0x000000018052A1F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052A1F0-0x000000018052A230
	}

	[CompilerGenerated]
	private sealed class _RenderWsLifesteal_d__192 : IEnumerator<object> // TypeDefIndex: 96
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int amount; // 0x20
		public ActivePVP __4__this; // 0x28
		public int attackerActor; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsLifesteal_d__192(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052A710-0x000000018052A850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052A850-0x000000018052A890
	}

	[CompilerGenerated]
	private sealed class _SetAnimationForItemActor_d__210 : IEnumerator<object> // TypeDefIndex: 97
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int actorOverride; // 0x20
		public ActivePVP __4__this; // 0x28
		public string itemType; // 0x30
		public bool wasFullPower; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SetAnimationForItemActor_d__210(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052AB20-0x000000018052AEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052AEC0-0x000000018052AF00
	}

	[CompilerGenerated]
	private sealed class _ShowBlockPopup_d__191 : IEnumerator<object> // TypeDefIndex: 98
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject node; // 0x20
		public int amount; // 0x28
		public ActivePVP __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowBlockPopup_d__191(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018052AF00-0x000000018052B0B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018052B0B0-0x000000018052B0F0
	}

	// Constructors
	public ActivePVP(); // 0x0000000180516E10-0x0000000180517070

	// Methods
	public void SyncStatsListForInspector(); // 0x0000000180516040-0x00000001805161D0
	internal void ClearHandleUISyncQueue(); // 0x0000000180513840-0x0000000180513870
	internal void EnqueueHandleUISyncFromMaster(HandleUISyncPayload p); // 0x0000000180513870-0x00000001805138D0
	internal bool TryApplyNextHandleUISync(); // 0x00000001805161D0-0x00000001805165D0
	internal void Awake(); // 0x00000001805133C0-0x00000001805134B0
	private void Start(); // 0x0000000180515CF0-0x0000000180516040
	public bool IsCurrentPlayerTurn(int actorNumber); // 0x0000000180514EE0-0x0000000180514F00
	public void InitializeStatsFromWsSnapshot(); // 0x00000001805143A0-0x0000000180514C50
	public int ResolveWsActor(string username); // 0x0000000180515930-0x0000000180515A70
	public void ApplyWsTurn(string currentTurnPlayerUsername, int serverTurnNumber); // 0x0000000180513230-0x0000000180513340
	[IteratorStateMachine(typeof(_AnimateSlider_d__183))]
	public IEnumerator AnimateSlider(Slider slider, float targetValue, float duration = 0.4f /* Metadata: 0x0064BF92 */); // 0x00000001805131A0-0x0000000180513230
	internal void HandleTurnStartInternal(int entityIndex); // 0x0000000180514060-0x0000000180514090
	[IteratorStateMachine(typeof(_OutputsParam_d__185))]
	public IEnumerator OutputsParam(string itemType); // 0x00000001805151A0-0x0000000180515230
	private Active.DamagePopupStyle ResolveDamagePopupStyle(GameObject root, bool rightSide); // 0x0000000180515830-0x0000000180515930
	[IteratorStateMachine(typeof(_RenderWsCombat_d__189))]
	public IEnumerator RenderWsCombat(List<WsCombatStepDTO> steps, int attackerActor, bool wasFullPower = false /* Metadata: 0x0064BF96 */, bool isSkill = false /* Metadata: 0x0064BF97 */, bool auditionSkill = false /* Metadata: 0x0064BF98 */); // 0x0000000180515620-0x00000001805156E0
	[IteratorStateMachine(typeof(_ShowBlockPopup_d__191))]
	internal IEnumerator ShowBlockPopup(GameObject node, int amount); // 0x0000000180515C50-0x0000000180515CF0
	[IteratorStateMachine(typeof(_RenderWsLifesteal_d__192))]
	public IEnumerator RenderWsLifesteal(int amount, int attackerActor); // 0x00000001805156E0-0x0000000180515770
	public Dictionary<string, int> BuildWsOutputsByTag(List<WsCombatStepDTO> steps); // 0x00000001805134B0-0x0000000180513840
	[IteratorStateMachine(typeof(_RenderWsCombatTag_d__194))]
	public IEnumerator RenderWsCombatTag(string tag, int amount, int attackerActor, bool wasFullPower, bool isSkill = false /* Metadata: 0x0064BF99 */, bool auditionSkill = false /* Metadata: 0x0064BF9A */); // 0x0000000180515560-0x0000000180515620
	[IteratorStateMachine(typeof(_RenderWsBuffsTogether_d__195))]
	public IEnumerator RenderWsBuffsTogether(List<KeyValuePair<string, int>> items, int attackerActor, bool wasFullPower); // 0x00000001805154B0-0x0000000180515560
	[IteratorStateMachine(typeof(_PopupStacked_d__196))]
	private IEnumerator PopupStacked(string tag, int attackerActor, int row); // 0x00000001805152E0-0x0000000180515390
	[IteratorStateMachine(typeof(_OutputsParam_d__197))]
	public IEnumerator OutputsParam(string itemType, int attackerActor, bool isSkill = false /* Metadata: 0x0064BF9B */); // 0x0000000180515230-0x00000001805152E0
	[IteratorStateMachine(typeof(_FadeAndMoveUpSafe_d__198))]
	internal IEnumerator FadeAndMoveUpSafe(GameObject obj, float duration); // 0x0000000180513970-0x00000001805139F0
	[IteratorStateMachine(typeof(_FadeAndMoveUpBoth_d__199))]
	internal IEnumerator FadeAndMoveUpBoth(GameObject obj1, GameObject obj2, float duration); // 0x00000001805138D0-0x0000000180513970
	public Animator GetPetAnimatorForActor(int actorNumber); // 0x0000000180513DF0-0x0000000180513E40
	public void UpdateShieldIcons(); // 0x0000000180516630-0x0000000180516E10
	internal void HandleTurnEndInternal(int entityIndex); // 0x0000000180513E40-0x0000000180514060
	public void resetOutput(); // 0x0000000180517D90-0x0000000180517DD0
	public void IncreaseNoPlayer(CardInfo cardInfo); // 0x0000000180514090-0x00000001805143A0
	internal void ResetPetAnimations(); // 0x0000000180515770-0x0000000180515830
	internal void ScheduleAutoResetPetAnimations(float delaySec); // 0x0000000180515A70-0x0000000180515B50
	[IteratorStateMachine(typeof(_AutoResetPetAnimationsAfter_d__208))]
	private IEnumerator AutoResetPetAnimationsAfter(float delaySec); // 0x0000000180513340-0x00000001805133C0
	public IEnumerator SetAnimationForItem(string itemType, bool wasFullPower = false /* Metadata: 0x0064BF9C */); // 0x0000000180515C00-0x0000000180515C50
	[IteratorStateMachine(typeof(_SetAnimationForItemActor_d__210))]
	public IEnumerator SetAnimationForItemActor(string itemType, bool wasFullPower, int actorOverride); // 0x0000000180515B50-0x0000000180515C00
	public void RaiseTurnStart(int actorNumber); // 0x00000001805153D0-0x00000001805153F0
	public void RaiseTurnEnd(); // 0x00000001805153B0-0x00000001805153D0
	public void RaiseTurnEndInternal(int actorNumber); // 0x0000000180515390-0x00000001805153B0
	public void RaiseTurnTimeUpdate(int turnIndex, float time); // 0x00000001805153F0-0x0000000180515410
	public int GetOpponentOf(int actorNumber); // 0x00000001805139F0-0x0000000180513DF0
	public bool RemovePlayerFromActiveTurns(int actorNumber); // 0x0000000180515410-0x00000001805154B0
	public bool IsActorStillInRoom(int actorNumber); // 0x0000000180514C50-0x0000000180514EE0
	internal void OnDestroy(); // 0x0000000180514F00-0x00000001805151A0
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__201_0(); // 0x00000001805165D0-0x0000000180516600
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__201_1(); // 0x0000000180516600-0x0000000180516630
}

