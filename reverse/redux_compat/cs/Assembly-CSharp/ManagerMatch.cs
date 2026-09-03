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

public class ManagerMatch : MonoBehaviour // TypeDefIndex: 1402
{
	// Fields
	public static ManagerMatch Instance; // 0x00
	[Header("Display Control")]
	[SerializeField]
	internal int displayActorNumber; // 0x20
	[SerializeField]
	internal bool autoSyncDisplayActor; // 0x24
	internal int lastDisplayActorNumber; // 0x28
	public List<string> playerNamesInOrder; // 0x30
	[Header("UI References")]
	public GameObject LoadingPanel; // 0x38
	public UnityEngine.UI.Text txtHpUser; // 0x40
	public UnityEngine.UI.Text txtManaUser; // 0x48
	public UnityEngine.UI.Text txtPowerUser; // 0x50
	public UnityEngine.UI.Text txtWeeUser; // 0x58
	public UnityEngine.UI.Text txtUsername; // 0x60
	public UnityEngine.UI.Text txtHpEnemy; // 0x68
	public UnityEngine.UI.Text txtManaEnemy; // 0x70
	public UnityEngine.UI.Text txtPowerEnemy; // 0x78
	public UnityEngine.UI.Text txtWeeEnemy; // 0x80
	public UnityEngine.UI.Text txtusernameEnemy; // 0x88
	public UnityEngine.UI.Text txtNLUser; // 0x90
	public Image attributeUser; // 0x98
	public Image attributeEnemy; // 0xA0
	public SpriteRenderer imgPetUser; // 0xA8
	public SpriteRenderer imgPetEnemy; // 0xB0
	public Animator anmtPetUser; // 0xB8
	public Animator anmtPetEnemy; // 0xC0
	public Slider sliderHpUser; // 0xC8
	public Slider sliderManaUser; // 0xD0
	public Slider sliderPowerUser; // 0xD8
	public Slider sliderHpEnemy; // 0xE0
	public Slider sliderManaEnemy; // 0xE8
	public Slider sliderPowerEnemy; // 0xF0
	public CardData cardData; // 0xF8
	[Header("Ping / FPS (match)")]
	[Tooltip("K\u00E9o Text (UI) tr\u00EAn Canvas tr\u1EADn \u0111\u1EA5u v\u00E0o \u0111\u00E2y. \u0110\u1EC3 tr\u1ED1ng th\u00EC kh\u00F4ng hi\u1EC3n th\u1ECB.")]
	public UnityEngine.UI.Text txtPingFps; // 0x100
	public bool showPingFpsHud; // 0x108
	private float _pingFpsHudNextTick; // 0x10C
	private float _pingFpsAccum; // 0x110
	private int _pingFpsFrames; // 0x114
	private int _pingFpsDisplay; // 0x118
	[CompilerGenerated]
	private Action OnAllDataLoaded; // 0x120
	private bool petsLoaded; // 0x128
	private bool enemyPetsLoaded; // 0x129
	private bool userLoaded; // 0x12A
	private Active active; // 0x130
	[Header("Boss Battle")]
	private bool isBossBattle; // 0x138
	private bool isTowerBattle; // 0x139
	internal long currentBossScheduleId; // 0x140
	private int totalDamageDealt; // 0x148
	public PetUserDTO uPetsMatch; // 0x150
	public PetUserDTO ePetsMatch; // 0x158
	[Header("Debug GUI Settings")]
	public bool showDebugGUI; // 0x160
	public float debugGUIFontSize; // 0x164
	public float popupDuration; // 0x168
	public int spaceCenterText; // 0x16C
	private List<DebugPopup> debugPopups; // 0x170
	private Dictionary<int, int> lastHP; // 0x178
	private Dictionary<int, int> lastMana; // 0x180
	private Dictionary<int, int> lastPower; // 0x188
	private Dictionary<int, int> lastShield; // 0x190
	private GUIStyle debugTitleStyle; // 0x198
	private GUIStyle debugLineStyle; // 0x1A0
	private GUIStyle popupStyleGreen; // 0x1A8
	private GUIStyle popupStyleRed; // 0x1B0
	private Vector2 scrollPos; // 0x1B8
	private int _lastHudRtt; // 0x1C0
	private int _lastHudFps; // 0x1C4
	private int _lastAppliedEnemyDisplayPetId; // 0x1C8
	private string _pendingEnemyClipPath; // 0x1D0
	private string _pendingUserClipPath; // 0x1D8
	private const int PET_CLIP_MAX_RETRY = 3; // Metadata: 0x0064D693
	private int _rigEnemyPetId; // 0x1E0
	private int _rigUserPetId; // 0x1E4
	private int _rigEnemyClipCount; // 0x1E8
	private int _rigUserClipCount; // 0x1EC

	// Properties
	public SpriteRenderer PetHostUser { get; } // 0x0000000180535490-0x0000000180535550 
	public SpriteRenderer PetHostEnemy { get; } // 0x00000001805353D0-0x0000000180535490 

	// Events
	public event Action OnAllDataLoaded {
		add; // 0x0000000180535320-0x00000001805353D0
		remove; // 0x0000000180535550-0x0000000180535600
	}

	// Nested types
	private class DebugPopup // TypeDefIndex: 1403
	{
		// Fields
		public int delta; // 0x10
		public float time; // 0x14
		public Vector2 startPos; // 0x18

		// Constructors
		public DebugPopup(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1404
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__85_1; // 0x08
		public static Action<string> __9__85_3; // 0x10
		public static Action<string> __9__85_5; // 0x18

		// Constructors
		static __c(); // 0x000000018054EDD0-0x000000018054EE40
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _TryRestMatchPrepFallback_b__85_1(string err); // 0x000000018054E030-0x000000018054E0A0
		internal void _TryRestMatchPrepFallback_b__85_3(string err); // 0x000000018054E0A0-0x000000018054E110
		internal void _TryRestMatchPrepFallback_b__85_5(string err); // 0x000000018054E110-0x000000018054E180
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass78_0 // TypeDefIndex: 1405
	{
		// Fields
		public int actor; // 0x10

		// Constructors
		public __c__DisplayClass78_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _ShowPopupDelta_b__0(int k); // 0x000000018054E7A0-0x000000018054E7B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass84_0 // TypeDefIndex: 1406
	{
		// Fields
		public string prepError; // 0x10
		public ManagerMatch __4__this; // 0x18

		// Constructors
		public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadSceneAfterDelay_b__1(MatchPrepDataDTO data); // 0x000000018054E7B0-0x000000018054E9A0
		internal void _LoadSceneAfterDelay_b__2(string err); // 0x00000001803780D0-0x00000001803780E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass85_0 // TypeDefIndex: 1407
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool myDone; // 0x18
		public bool enemyDone; // 0x19

		// Constructors
		public __c__DisplayClass85_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _TryRestMatchPrepFallback_b__0(PetUserDTO pet); // 0x000000018054E9A0-0x000000018054EA10
		internal void _TryRestMatchPrepFallback_b__2(PetUserDTO pet); // 0x000000018054EA10-0x000000018054EA80
		internal void _TryRestMatchPrepFallback_b__4(UserDTO user); // 0x000000018054EA80-0x000000018054EB70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass95_0 // TypeDefIndex: 1408
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool isEnemy; // 0x18
		public string path; // 0x20
		public int attempt; // 0x28
		public string petId; // 0x30

		// Constructors
		public __c__DisplayClass95_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ApplyPetClips_b__0(AnimationClip[] clips); // 0x000000018054EB70-0x000000018054EDD0
	}

	[CompilerGenerated]
	private sealed class _ApplyClipsWhenUiReady_d__105 : IEnumerator<object> // TypeDefIndex: 1409
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatch __4__this; // 0x20
		public string path; // 0x28
		public bool isEnemy; // 0x30
		public AnimationClip[] clips; // 0x38
		private float _waited_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyClipsWhenUiReady_d__105(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180548950-0x0000000180548C50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180548C50-0x0000000180548C90
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__84 : IEnumerator<object> // TypeDefIndex: 1410
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatch __4__this; // 0x20
		private __c__DisplayClass84_0 __8__1; // 0x28
		private int _localUserId_5__2; // 0x30
		private int _ePetId_5__3; // 0x34
		private int _idPet_5__4; // 0x38
		private Active _activeRef_5__5; // 0x40
		private float _waited_5__6; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__84(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018054C050-0x000000018054C090
		private bool MoveNext(); // 0x000000018054B240-0x000000018054C010
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054C010-0x000000018054C050
	}

	[CompilerGenerated]
	private sealed class _RetryApplyPetClips_d__96 : IEnumerator<object> // TypeDefIndex: 1411
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int attempt; // 0x20
		public ManagerMatch __4__this; // 0x28
		public bool isEnemy; // 0x30
		public string petId; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RetryApplyPetClips_d__96(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018054D3C0-0x000000018054D540
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054D540-0x000000018054D580
	}

	[CompilerGenerated]
	private sealed class _TryRestMatchPrepFallback_d__85 : IEnumerator<object> // TypeDefIndex: 1412
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatch __4__this; // 0x20
		public int userId; // 0x28
		public int idPet; // 0x2C
		public int ePetId; // 0x30
		private __c__DisplayClass85_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TryRestMatchPrepFallback_d__85(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FC230-0x00000001802FC260
		private bool MoveNext(); // 0x000000018054D8A0-0x000000018054DEA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054DEA0-0x000000018054DEE0
	}

	// Constructors
	public ManagerMatch(); // 0x0000000180535120-0x0000000180535320

	// Methods
	private void Awake(); // 0x00000001805316B0-0x0000000180531770
	private void OnDestroy(); // 0x0000000180531FB0-0x0000000180532060
	private void Start(); // 0x0000000180533D70-0x0000000180533E60
	private void WireEnergyBuyButton(); // 0x0000000180534E60-0x0000000180535120
	private void OpenEnergyPurchasePopup(); // 0x00000001803B8DA0-0x00000001803B8DB0
	private void InitDebugGuiStyles(); // 0x0000000180531AF0-0x0000000180531DD0
	private void Update(); // 0x0000000180534E40-0x0000000180534E60
	private void UpdatePingFpsHud(); // 0x0000000180534B20-0x0000000180534E40
	private void UpdateDebugStatsRealtime(); // 0x00000001805342F0-0x0000000180534B20
	private void ShowPopupDelta(int actor, string statName, int delta); // 0x0000000180533B60-0x0000000180533D70
	private void InitializeDisplayActor(); // 0x0000000180531DD0-0x0000000180531DE0
	private void CheckAndUpdateDisplayActor(); // 0x0000000180531770-0x0000000180531780
	public void SwitchDisplayToPlayer(int actorNumber); // 0x0000000180533E60-0x0000000180534100
	private void SetLocalUsernameTextSafe(string name); // 0x0000000180533910-0x0000000180533B60
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__84))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180531F40-0x0000000180531FB0
	[IteratorStateMachine(typeof(_TryRestMatchPrepFallback_d__85))]
	private IEnumerator TryRestMatchPrepFallback(int userId, int idPet, int ePetId); // 0x0000000180534230-0x00000001805342D0
	private void OnPet(string petId); // 0x0000000180533030-0x0000000180533070
	private void OnEnemyPet(string petId); // 0x0000000180532DE0-0x0000000180532FC0
	public void EnsureEnemyDisplaySynced(bool force = false /* Metadata: 0x0064D690 */); // 0x0000000180531780-0x0000000180531AE0
	private void SyncBossPetDataId(int petId); // 0x0000000180534100-0x0000000180534230
	private void ApplyPetSprite(string petId, bool isEnemy); // 0x00000001805315B0-0x00000001805316B0
	private void ApplyPetClips(string petId, bool isEnemy, int attempt = 0 /* Metadata: 0x0064D691 */); // 0x00000001805313F0-0x00000001805315B0
	[IteratorStateMachine(typeof(_RetryApplyPetClips_d__96))]
	private IEnumerator RetryApplyPetClips(string petId, bool isEnemy, int attempt); // 0x0000000180533860-0x0000000180533910
	private static string PetIdFromClipPath(string path); // 0x00000001805337E0-0x0000000180533860
	private bool IsDisplayOwnedByLocalPlayer(); // 0x0000000180531DE0-0x0000000180531F30
	private void ApplyClipsNow(AnimationClip[] clips, bool isEnemy, string path = null, bool outOfRetries = false /* Metadata: 0x0064D692 */); // 0x0000000180530CB0-0x0000000180531330
	private static int ParsePetIdOrZero(string path); // 0x0000000180533740-0x00000001805337E0
	[IteratorStateMachine(typeof(_ApplyClipsWhenUiReady_d__105))]
	private IEnumerator ApplyClipsWhenUiReady(AnimationClip[] clips, bool isEnemy, string path); // 0x0000000180531330-0x00000001805313F0
	private void OnPetsReceived(PetUserDTO pets); // 0x0000000180533070-0x0000000180533740
	private void OnEPetsReceived(PetUserDTO pets); // 0x0000000180532060-0x0000000180532DE0
	private void OnError(string error); // 0x0000000180532FC0-0x0000000180533030
	public void AddBossDamage(int damage); // 0x00000001805309B0-0x0000000180530CB0
	public bool IsBossBattle(); // 0x000000018033D280-0x000000018033D290
	public bool IsTowerBattle(); // 0x0000000180531F30-0x0000000180531F40
	public int GetTotalBossDamage(); // 0x0000000180531AE0-0x0000000180531AF0
	[CompilerGenerated]
	private bool _LoadSceneAfterDelay_b__84_0(); // 0x00000001805342D0-0x00000001805342F0
}

