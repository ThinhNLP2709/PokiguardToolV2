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

public class Active : MonoBehaviour // TypeDefIndex: 1532
{
	// Fields
	public Dictionary<int, PlayerStats> playerStatsMap; // 0x20
	[Header("Player Stats (Inspector View)")]
	[SerializeField]
	public List<PlayerStats> playerStatsList; // 0x28
	internal int enemyActorNumber; // 0x30
	public const int WS_BOSS_ACTOR = 99; // Metadata: 0x0064D758
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
	private bool onAllDataLoadedSubscribed; // 0x370
	private float _emptyActiveWarnAt; // 0x374
	private const float StatsMismatchTolerance = 0.05f; // Metadata: 0x0064D75A
	private const float SKILL_DAMAGE_POPUP_SCALE = 1.25f; // Metadata: 0x0064D75E
	private DamagePopupStyle _dmgPopupStyleSelf; // 0x378
	private DamagePopupStyle _dmgPopupStyleNpc; // 0x380
	internal static readonly string[] WsProcessOrder; // 0x08
	internal const float PopupStackStep = 46f; // Metadata: 0x0064D762
	[NonSerialized]
	public int pendingBlockDisplay; // 0x388
	private const float HEAL_POPUP_SEC = 1.05f; // Metadata: 0x0064D766
	private Coroutine _petAnimAutoReset; // 0x390

	// Properties
	internal int localActorNumber { get; } // 0x000000018056A9A0-0x000000018056A9C0 
	internal int LocalActorNumberOrZero { get; } // 0x000000018056A730-0x000000018056A9A0 
	public int CurrentTurnIndex { get; } // 0x000000018056A590-0x000000018056A5A0 
	public int TurnNumber { get; } // 0x0000000180517780-0x0000000180517790 
	public bool IsTurnInProgress { get; } // 0x0000000180517740-0x0000000180517750 
	public bool IsPlayerTurnNew { get; } // 0x000000018056A720-0x000000018056A730 
	public bool IsNPCTurnNew { get; } // 0x000000018056A700-0x000000018056A720 
	public float CurrentTurnTime { get; } // 0x00000001805176A0-0x00000001805176B0 
	public static Active Instance { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x000000018056A6B0-0x000000018056A700 0x000000018056ADB0-0x000000018056AE20
	public List<int> ActivePlayers { get; } // 0x0000000180517460-0x0000000180517470 
	public int CurrentTurnPlayerActorNumber { get; } // 0x000000018056A5A0-0x000000018056A6B0 

	// Events
	public event Action OnTurnEnd {
		add; // 0x000000018056A270-0x000000018056A320
		remove; // 0x000000018056AA90-0x000000018056AB40
	}
	public event Action<int> OnTurnStart {
		add; // 0x000000018056A320-0x000000018056A3F0
		remove; // 0x000000018056AB40-0x000000018056AC10
	}
	public event Action<int> OnTurnEndInternal {
		add; // 0x000000018056A1A0-0x000000018056A270
		remove; // 0x000000018056A9C0-0x000000018056AA90
	}
	public event Action<int, float> OnTurnTimeUpdate {
		add; // 0x000000018056A3F0-0x000000018056A4C0
		remove; // 0x000000018056AC10-0x000000018056ACE0
	}
	public event Action<int> OnTurnTimeout {
		add; // 0x000000018056A4C0-0x000000018056A590
		remove; // 0x000000018056ACE0-0x000000018056ADB0
	}

	// Nested types
	[Serializable]
	public class PlayerStats // TypeDefIndex: 1533
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
		public PlayerStats(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	internal class DamagePopupStyle // TypeDefIndex: 1534
	{
		// Fields
		public UnityEngine.UI.Text text; // 0x10
		public Vector3 scale; // 0x18
		public Color color; // 0x24
		public HorizontalWrapMode hOverflow; // 0x34
		public VerticalWrapMode vOverflow; // 0x38

		// Constructors
		public DamagePopupStyle(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1535
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<MatchPlayerSnapshotDTO> __9__182_0; // 0x08
		public static Comparison<MatchPlayerSnapshotDTO> __9__185_0; // 0x10

		// Constructors
		static __c(); // 0x00000001805AC1E0-0x00000001805AC250
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal int _InitializeActivePlayers_b__182_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x00000001805ABD40-0x00000001805ABD80
		internal int _InitializeStatsFromWsSnapshot_b__185_0(MatchPlayerSnapshotDTO a, MatchPlayerSnapshotDTO b); // 0x00000001805ABD40-0x00000001805ABD80
	}

	[CompilerGenerated]
	private sealed class _AnimateSlider_d__197 : IEnumerator<object> // TypeDefIndex: 1536
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
		public _AnimateSlider_d__197(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059F010-0x000000018059F1D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059F1D0-0x000000018059F210
	}

	[CompilerGenerated]
	private sealed class _AutoResetPetAnimationsAfter_d__240 : IEnumerator<object> // TypeDefIndex: 1537
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delaySec; // 0x20
		public Active __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoResetPetAnimationsAfter_d__240(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018059F330-0x000000018059F410
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059F410-0x000000018059F450
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpBoth_d__227 : IEnumerator<object> // TypeDefIndex: 1538
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
		public _FadeAndMoveUpBoth_d__227(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180526250-0x00000001805262B0
		private bool MoveNext(); // 0x00000001805A4320-0x00000001805A4760
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4760-0x00000001805A47A0
	}

	[CompilerGenerated]
	private sealed class _FadeAndMoveUpSafe_d__226 : IEnumerator<object> // TypeDefIndex: 1539
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
		public _FadeAndMoveUpSafe_d__226(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
		private bool MoveNext(); // 0x00000001805A47A0-0x00000001805A4A60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4A60-0x00000001805A4AA0
	}

	[CompilerGenerated]
	private sealed class _OutputsParamSide_d__209 : IEnumerator<object> // TypeDefIndex: 1540
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OutputsParamSide_d__209(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805A7C20-0x00000001805A7C60
		private bool MoveNext(); // 0x00000001805A6DB0-0x00000001805A7BE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A7BE0-0x00000001805A7C20
	}

	[CompilerGenerated]
	private sealed class _PopupRiseAndFade_d__225 : IEnumerator<object> // TypeDefIndex: 1541
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PopupRiseAndFade_d__225(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018030EF30-0x000000018030EF70
		private bool MoveNext(); // 0x00000001805A7C60-0x00000001805A80F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A80F0-0x00000001805A8130
	}

	[CompilerGenerated]
	private sealed class _PopupStacked_d__215 : IEnumerator<object> // TypeDefIndex: 1542
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PopupStacked_d__215(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001805A8130-0x00000001805A8370
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A8370-0x00000001805A83B0
	}

	[CompilerGenerated]
	private sealed class _RenderWsBuffsTogether_d__213 : IEnumerator<object> // TypeDefIndex: 1543
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsBuffsTogether_d__213(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A8460-0x00000001805A8800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A8800-0x00000001805A8840
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombat_d__218 : IEnumerator<object> // TypeDefIndex: 1544
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

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombat_d__218(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x00000001805A8E30-0x00000001805A9310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A9310-0x00000001805A9350
	}

	[CompilerGenerated]
	private sealed class _RenderWsCombatTag_d__212 : IEnumerator<object> // TypeDefIndex: 1545
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsCombatTag_d__212(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A8840-0x00000001805A8DF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A8DF0-0x00000001805A8E30
	}

	[CompilerGenerated]
	private sealed class _RenderWsLifesteal_d__223 : IEnumerator<object> // TypeDefIndex: 1546
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int amount; // 0x20
		public Active __4__this; // 0x28
		public bool attackerNpcSide; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RenderWsLifesteal_d__223(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805A9350-0x00000001805A94E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A94E0-0x00000001805A9520
	}

	[CompilerGenerated]
	private sealed class _SetAnimationForItemSide_d__236 : IEnumerator<object> // TypeDefIndex: 1547
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool npcSide; // 0x20
		public string itemType; // 0x28
		public bool wasFullPower; // 0x30
		public Active __4__this; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SetAnimationForItemSide_d__236(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805AA360-0x00000001805AA900
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AA900-0x00000001805AA940
	}

	[CompilerGenerated]
	private sealed class _ShowBlockPopup_d__221 : IEnumerator<object> // TypeDefIndex: 1548
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GameObject node; // 0x20
		public int amount; // 0x28
		public Active __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ShowBlockPopup_d__221(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805AA940-0x00000001805AAAF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AAAF0-0x00000001805AAB30
	}

	[CompilerGenerated]
	private sealed class _WaitAndStartGame_d__198 : IEnumerator<object> // TypeDefIndex: 1549
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndStartGame_d__198(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805ACDC0-0x00000001805ACEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805ACEE0-0x00000001805ACF20
	}

	[CompilerGenerated]
	private sealed class _WaitAndSubscribeOnAllDataLoaded_d__177 : IEnumerator<object> // TypeDefIndex: 1550
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Active __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitAndSubscribeOnAllDataLoaded_d__177(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805ACF20-0x00000001805AD0A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805AD0A0-0x00000001805AD140
	}

	// Constructors
	public Active(); // 0x0000000180569F70-0x000000018056A1A0
	static Active(); // 0x0000000180569DF0-0x0000000180569F70

	// Methods
	public void SyncStatsListForInspector(); // 0x00000001805691A0-0x0000000180569330
	public void PinCascadeAttacker(); // 0x0000000180566550-0x00000001805666C0
	public void ClearCascadeAttacker(); // 0x0000000180563D90-0x0000000180563DB0
	internal void Awake(); // 0x0000000180563690-0x00000001805637C0
	private void TrySubscribeOnAllDataLoaded(); // 0x0000000180569330-0x0000000180569430
	[IteratorStateMachine(typeof(_WaitAndSubscribeOnAllDataLoaded_d__177))]
	private IEnumerator WaitAndSubscribeOnAllDataLoaded(); // 0x0000000180569D80-0x0000000180569DF0
	private void Start(); // 0x0000000180568120-0x00000001805686B0
	public void InitializeActivePlayers(); // 0x0000000180564800-0x0000000180564C60
	public bool IsCurrentPlayerTurn(int actorNumber); // 0x0000000180565F60-0x0000000180565F80
	internal void OnManagerMatchDataLoaded(); // 0x00000001805663C0-0x00000001805663D0
	public void InitializeStatsFromWsSnapshot(); // 0x0000000180564C60-0x0000000180565E20
	public void SyncDisplayActorToServerTurn(); // 0x00000001805688F0-0x00000001805689B0
	private int ResolveDisplayActorFromServerTurn(); // 0x0000000180567940-0x0000000180567BB0
	private static void ReconcileStatsWithMatchPrep(PlayerStats st, PetUserDTO prep, string who); // 0x0000000180566BB0-0x0000000180567040
	private void RefreshLocalPetDisplayFromManager(); // 0x0000000180567040-0x0000000180567400
	public void SyncStatsFromWsSnapshot(); // 0x00000001805689B0-0x00000001805691A0
	public int ResolveWsActor(string username); // 0x0000000180567BB0-0x0000000180567CF0
	public void ApplyWsTurn(string currentTurnPlayerUsername, int serverTurnNumber); // 0x0000000180563450-0x0000000180563610
	public double GetWeaknessVsBoss(int playerActor); // 0x00000001805640D0-0x0000000180564140
	public double GetBossWeaknessVsPlayer(int playerActor); // 0x0000000180563ED0-0x0000000180563F50
	internal void InitializeStatsWithDefaults(); // 0x0000000180565E20-0x0000000180565F60
	[IteratorStateMachine(typeof(_AnimateSlider_d__197))]
	public IEnumerator AnimateSlider(Slider slider, float targetValue, float duration = 0.4f /* Metadata: 0x0064D74A */); // 0x0000000180563120-0x00000001805631C0
	[IteratorStateMachine(typeof(_WaitAndStartGame_d__198))]
	private IEnumerator WaitAndStartGame(); // 0x0000000180569D30-0x0000000180569D80
	internal void HandleTurnStartInternal(int entityIndex); // 0x0000000180564180-0x0000000180564460
	private DamagePopupStyle ResolveDamagePopupStyle(GameObject root, bool npcSide); // 0x0000000180567850-0x0000000180567940
	internal static DamagePopupStyle CaptureDamagePopupStyle(GameObject root); // 0x0000000180563B50-0x0000000180563D90
	internal static void ApplyDamagePopupStyle(GameObject root, DamagePopupStyle style, int damage, bool isSkill); // 0x00000001805631C0-0x0000000180563450
	internal static void RestoreDamagePopupStyle(GameObject root, DamagePopupStyle style); // 0x0000000180567CF0-0x0000000180567E10
	public IEnumerator OutputsParam(string itemType); // 0x0000000180566490-0x0000000180566550
	[IteratorStateMachine(typeof(_OutputsParamSide_d__209))]
	public IEnumerator OutputsParamSide(string itemType, bool npcSide, bool isSkill = false /* Metadata: 0x0064D74E */); // 0x00000001805663D0-0x0000000180566490
	public Dictionary<string, int> BuildWsOutputsByTag(List<WsCombatStepDTO> steps); // 0x00000001805637C0-0x0000000180563B50
	[IteratorStateMachine(typeof(_RenderWsCombatTag_d__212))]
	public IEnumerator RenderWsCombatTag(string tag, int amount, bool bossSide, bool wasFullPower, bool isSkill = false /* Metadata: 0x0064D74F */, bool auditionSkill = false /* Metadata: 0x0064D750 */); // 0x0000000180567560-0x0000000180567630
	[IteratorStateMachine(typeof(_RenderWsBuffsTogether_d__213))]
	public IEnumerator RenderWsBuffsTogether(List<KeyValuePair<string, int>> items, bool bossSide, bool wasFullPower, bool deferHp = false /* Metadata: 0x0064D751 */); // 0x00000001805674A0-0x0000000180567560
	[IteratorStateMachine(typeof(_PopupStacked_d__215))]
	private IEnumerator PopupStacked(string tag, bool bossSide, int row); // 0x0000000180566AC0-0x0000000180566B70
	private GameObject PopupNodeForTag(string tag, bool npcSide); // 0x00000001805668B0-0x0000000180566A40
	internal static MatchStatMask MaskForTag(string tag); // 0x0000000180565F80-0x00000001805660B0
	[IteratorStateMachine(typeof(_RenderWsCombat_d__218))]
	public IEnumerator RenderWsCombat(List<WsCombatStepDTO> steps, bool bossSide, bool wasFullPower = false /* Metadata: 0x0064D752 */, bool isSkill = false /* Metadata: 0x0064D753 */, bool auditionSkill = false /* Metadata: 0x0064D754 */); // 0x0000000180567630-0x0000000180567700
	public static int SumBlock(List<WsCombatStepDTO> steps); // 0x00000001805686B0-0x00000001805687D0
	[IteratorStateMachine(typeof(_ShowBlockPopup_d__221))]
	internal IEnumerator ShowBlockPopup(GameObject node, int amount); // 0x0000000180568080-0x0000000180568120
	public static int SumLifesteal(List<WsCombatStepDTO> steps); // 0x00000001805687D0-0x00000001805688F0
	[IteratorStateMachine(typeof(_RenderWsLifesteal_d__223))]
	public IEnumerator RenderWsLifesteal(int amount, bool attackerNpcSide); // 0x0000000180567700-0x0000000180567790
	[IteratorStateMachine(typeof(_PopupRiseAndFade_d__225))]
	internal IEnumerator PopupRiseAndFade(GameObject obj, float duration); // 0x0000000180566A40-0x0000000180566AC0
	[IteratorStateMachine(typeof(_FadeAndMoveUpSafe_d__226))]
	internal IEnumerator FadeAndMoveUpSafe(GameObject obj, float duration); // 0x0000000180563E50-0x0000000180563ED0
	[IteratorStateMachine(typeof(_FadeAndMoveUpBoth_d__227))]
	internal IEnumerator FadeAndMoveUpBoth(GameObject obj1, GameObject obj2, float duration); // 0x0000000180563DB0-0x0000000180563E50
	internal float GetDamageMultiplier(int attackerActor, int defActor); // 0x0000000180563F50-0x0000000180564000
	public Animator GetPetAnimatorForActor(int actorNumber); // 0x0000000180564000-0x00000001805640D0
	public void UpdateShieldIcons(bool refreshBars = true /* Metadata: 0x0064D755 */); // 0x0000000180569490-0x0000000180569D30
	internal void HandleTurnEndInternal(int entityIndex); // 0x0000000180564140-0x0000000180564180
	public void resetOutput(); // 0x0000000180517D90-0x0000000180517DD0
	public void IncreaseNoPlayer(CardInfo cardInfo); // 0x0000000180564460-0x0000000180564800
	internal void ResetPetAnimations(); // 0x0000000180567790-0x0000000180567850
	public IEnumerator SetAnimationForItem(string itemType, bool wasFullPower = false /* Metadata: 0x0064D756 */); // 0x0000000180567FB0-0x0000000180568080
	[IteratorStateMachine(typeof(_SetAnimationForItemSide_d__236))]
	public IEnumerator SetAnimationForItemSide(string itemType, bool wasFullPower, bool npcSide); // 0x0000000180567EF0-0x0000000180567FB0
	internal void PlayPetAnimationRPC(bool isPlayerAttack, bool fullPower = false /* Metadata: 0x0064D757 */); // 0x00000001805666C0-0x00000001805668B0
	internal void ScheduleAutoResetPetAnimations(float delaySec); // 0x0000000180567E10-0x0000000180567EF0
	[IteratorStateMachine(typeof(_AutoResetPetAnimationsAfter_d__240))]
	private IEnumerator AutoResetPetAnimationsAfter(float delaySec); // 0x0000000180563610-0x0000000180563690
	public void RaiseTurnStart(int actorNumber); // 0x0000000180566B70-0x0000000180566BB0
	public void RaiseTurnEnd(); // 0x00000001805153B0-0x00000001805153D0
	public void RaiseTurnEndInternal(int actorNumber); // 0x0000000180515390-0x00000001805153B0
	public void RaiseTurnTimeUpdate(int turnIndex, float time); // 0x00000001805153F0-0x0000000180515410
	public bool RemovePlayerFromActiveTurns(int actorNumber); // 0x0000000180567400-0x00000001805674A0
	internal void OnDestroy(); // 0x00000001805660B0-0x00000001805663C0
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__230_0(); // 0x0000000180569430-0x0000000180569460
	[CompilerGenerated]
	private void _UpdateShieldIcons_b__230_1(); // 0x0000000180569460-0x0000000180569490
}

