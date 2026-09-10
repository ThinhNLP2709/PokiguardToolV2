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

public class ManagerMatch : MonoBehaviour // TypeDefIndex: 1646
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
	private const int PET_CLIP_MAX_RETRY = 3; // Metadata: 0x0068D57C
	private int _rigEnemyPetId; // 0x1E0
	private int _rigUserPetId; // 0x1E4
	private int _rigEnemyClipCount; // 0x1E8
	private int _rigUserClipCount; // 0x1EC

	// Properties
	public SpriteRenderer PetHostUser { get; } // 0x00000001806292E0-0x00000001806293A0 
	public SpriteRenderer PetHostEnemy { get; } // 0x0000000180629220-0x00000001806292E0 
	public string EnemyDisplayName { get; } // 0x00000001806291D0-0x0000000180629220 

	// Events
	public event Action OnAllDataLoaded {
		add; // 0x0000000180629120-0x00000001806291D0
		remove; // 0x00000001806293A0-0x0000000180629450
	}

	// Nested types
	private class DebugPopup // TypeDefIndex: 1647
	{
		// Fields
		public int delta; // 0x10
		public float time; // 0x14
		public Vector2 startPos; // 0x18

		// Constructors
		public DebugPopup(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1648
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__87_1; // 0x08
		public static Action<string> __9__87_3; // 0x10
		public static Action<string> __9__87_5; // 0x18

		// Constructors
		static __c(); // 0x0000000180644800-0x0000000180644870
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _TryRestMatchPrepFallback_b__87_1(string err); // 0x0000000180643CD0-0x0000000180643D40
		internal void _TryRestMatchPrepFallback_b__87_3(string err); // 0x0000000180643D40-0x0000000180643DB0
		internal void _TryRestMatchPrepFallback_b__87_5(string err); // 0x0000000180643DB0-0x0000000180643E20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 1649
	{
		// Fields
		public int actor; // 0x10

		// Constructors
		public __c__DisplayClass80_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _ShowPopupDelta_b__0(int k); // 0x00000001806441D0-0x00000001806441E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 1650
	{
		// Fields
		public string prepError; // 0x10
		public ManagerMatch __4__this; // 0x18

		// Constructors
		public __c__DisplayClass86_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadSceneAfterDelay_b__1(MatchPrepDataDTO data); // 0x00000001806441E0-0x00000001806443D0
		internal void _LoadSceneAfterDelay_b__2(string err); // 0x0000000180317090-0x00000001803170A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 1651
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool myDone; // 0x18
		public bool enemyDone; // 0x19

		// Constructors
		public __c__DisplayClass87_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _TryRestMatchPrepFallback_b__0(PetUserDTO pet); // 0x00000001806443D0-0x0000000180644440
		internal void _TryRestMatchPrepFallback_b__2(PetUserDTO pet); // 0x0000000180644440-0x00000001806444B0
		internal void _TryRestMatchPrepFallback_b__4(UserDTO user); // 0x00000001806444B0-0x00000001806445A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass97_0 // TypeDefIndex: 1652
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool isEnemy; // 0x18
		public string path; // 0x20
		public int attempt; // 0x28
		public string petId; // 0x30

		// Constructors
		public __c__DisplayClass97_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ApplyPetClips_b__0(AnimationClip[] clips); // 0x00000001806445A0-0x0000000180644800
	}

	[CompilerGenerated]
	private sealed class _ApplyClipsWhenUiReady_d__107 : IEnumerator<object> // TypeDefIndex: 1653
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyClipsWhenUiReady_d__107(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063E3F0-0x000000018063E6F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063E6F0-0x000000018063E730
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__86 : IEnumerator<object> // TypeDefIndex: 1654
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatch __4__this; // 0x20
		private __c__DisplayClass86_0 __8__1; // 0x28
		private int _localUserId_5__2; // 0x30
		private int _ePetId_5__3; // 0x34
		private int _idPet_5__4; // 0x38
		private bool _isGuildBossBattle_5__5; // 0x3C
		private Active _activeRef_5__6; // 0x40
		private float _waited_5__7; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__86(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180641CA0-0x0000000180641CE0
		private bool MoveNext(); // 0x0000000180640DE0-0x0000000180641C60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180641C60-0x0000000180641CA0
	}

	[CompilerGenerated]
	private sealed class _RetryApplyPetClips_d__98 : IEnumerator<object> // TypeDefIndex: 1655
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int attempt; // 0x20
		public ManagerMatch __4__this; // 0x28
		public bool isEnemy; // 0x30
		public string petId; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RetryApplyPetClips_d__98(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180643120-0x00000001806432A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806432A0-0x00000001806432E0
	}

	[CompilerGenerated]
	private sealed class _TryRestMatchPrepFallback_d__87 : IEnumerator<object> // TypeDefIndex: 1656
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatch __4__this; // 0x20
		public int userId; // 0x28
		public int idPet; // 0x2C
		public int ePetId; // 0x30
		private __c__DisplayClass87_0 __8__1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TryRestMatchPrepFallback_d__87(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x0000000180643600-0x0000000180643C00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180643C00-0x0000000180643C40
	}

	// Constructors
	public ManagerMatch(); // 0x0000000180628F20-0x0000000180629120

	// Methods
	private void Awake(); // 0x0000000180625480-0x0000000180625540
	private void OnDestroy(); // 0x0000000180625D80-0x0000000180625E30
	private void Start(); // 0x0000000180627B40-0x0000000180627C60
	private void WireEnergyBuyButton(); // 0x0000000180628C60-0x0000000180628F20
	private void OpenEnergyPurchasePopup(); // 0x000000018049A450-0x000000018049A460
	private void InitDebugGuiStyles(); // 0x00000001806258B0-0x0000000180625B90
	private void Update(); // 0x0000000180628C40-0x0000000180628C60
	private void UpdatePingFpsHud(); // 0x0000000180628920-0x0000000180628C40
	private void UpdateDebugStatsRealtime(); // 0x00000001806280F0-0x0000000180628920
	private void ShowPopupDelta(int actor, string statName, int delta); // 0x0000000180627930-0x0000000180627B40
	private void InitializeDisplayActor(); // 0x0000000180625B90-0x0000000180625BA0
	private void CheckAndUpdateDisplayActor(); // 0x0000000180625540-0x0000000180625550
	public void SwitchDisplayToPlayer(int actorNumber); // 0x0000000180627C60-0x0000000180627F00
	private void SetLocalUsernameTextSafe(string name); // 0x00000001806276E0-0x0000000180627930
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__86))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180625D10-0x0000000180625D80
	[IteratorStateMachine(typeof(_TryRestMatchPrepFallback_d__87))]
	private IEnumerator TryRestMatchPrepFallback(int userId, int idPet, int ePetId); // 0x0000000180628030-0x00000001806280D0
	private void OnPet(string petId); // 0x0000000180626E00-0x0000000180626E40
	private void OnEnemyPet(string petId); // 0x0000000180626BB0-0x0000000180626D90
	public void EnsureEnemyDisplaySynced(bool force = false /* Metadata: 0x0068D579 */); // 0x0000000180625550-0x00000001806258B0
	private void SyncBossPetDataId(int petId); // 0x0000000180627F00-0x0000000180628030
	private void ApplyPetSprite(string petId, bool isEnemy); // 0x0000000180625380-0x0000000180625480
	private void ApplyPetClips(string petId, bool isEnemy, int attempt = 0 /* Metadata: 0x0068D57A */); // 0x00000001806251C0-0x0000000180625380
	[IteratorStateMachine(typeof(_RetryApplyPetClips_d__98))]
	private IEnumerator RetryApplyPetClips(string petId, bool isEnemy, int attempt); // 0x0000000180627630-0x00000001806276E0
	private static string PetIdFromClipPath(string path); // 0x00000001806275B0-0x0000000180627630
	private bool IsDisplayOwnedByLocalPlayer(); // 0x0000000180625BB0-0x0000000180625D00
	private void ApplyClipsNow(AnimationClip[] clips, bool isEnemy, string path = null, bool outOfRetries = false /* Metadata: 0x0068D57B */); // 0x0000000180624A80-0x0000000180625100
	private static int ParsePetIdOrZero(string path); // 0x0000000180627510-0x00000001806275B0
	[IteratorStateMachine(typeof(_ApplyClipsWhenUiReady_d__107))]
	private IEnumerator ApplyClipsWhenUiReady(AnimationClip[] clips, bool isEnemy, string path); // 0x0000000180625100-0x00000001806251C0
	private void OnPetsReceived(PetUserDTO pets); // 0x0000000180626E40-0x0000000180627510
	private void OnEPetsReceived(PetUserDTO pets); // 0x0000000180625E30-0x0000000180626BB0
	private void OnError(string error); // 0x0000000180626D90-0x0000000180626E00
	public void AddBossDamage(int damage); // 0x0000000180624780-0x0000000180624A80
	public bool IsBossBattle(); // 0x0000000180625BA0-0x0000000180625BB0
	public bool IsTowerBattle(); // 0x0000000180625D00-0x0000000180625D10
	public int GetTotalBossDamage(); // 0x000000018039C640-0x000000018039C650
	[CompilerGenerated]
	private bool _LoadSceneAfterDelay_b__86_0(); // 0x00000001806280D0-0x00000001806280F0
}

