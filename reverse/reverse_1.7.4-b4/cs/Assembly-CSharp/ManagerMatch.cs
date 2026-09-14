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

public class ManagerMatch : MonoBehaviour // TypeDefIndex: 2013
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
	private const int PET_CLIP_MAX_RETRY = 3; // Metadata: 0x005F17C2
	private int _rigEnemyPetId; // 0x1E0
	private int _rigUserPetId; // 0x1E4
	private int _rigEnemyClipCount; // 0x1E8
	private int _rigUserClipCount; // 0x1EC

	// Properties
	public SpriteRenderer PetHostUser { get; } // 0x00000001809A7280-0x00000001809A7480 
	public SpriteRenderer PetHostEnemy { get; } // 0x00000001809A7480-0x00000001809A7680 
	public string EnemyDisplayName { get; } // 0x00000001809A7880-0x00000001809A78B0 

	// Events
	public event Action OnAllDataLoaded {
		add; // 0x00000001809A7680-0x00000001809A7780
		remove; // 0x00000001809A7780-0x00000001809A7880
	}

	// Nested types
	private class DebugPopup // TypeDefIndex: 2014
	{
		// Fields
		public int delta; // 0x10
		public float time; // 0x14
		public Vector2 startPos; // 0x18

		// Constructors
		public DebugPopup(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2015
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__87_1; // 0x08
		public static Action<string> __9__87_3; // 0x10
		public static Action<string> __9__87_5; // 0x18

		// Constructors
		static __c(); // 0x00000001809AE470-0x00000001809AE510
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRestMatchPrepFallback_b__87_1(string err); // 0x00000001809AE510-0x00000001809AE590
		internal void _TryRestMatchPrepFallback_b__87_3(string err); // 0x00000001809AE590-0x00000001809AE610
		internal void _TryRestMatchPrepFallback_b__87_5(string err); // 0x00000001809AE610-0x00000001809AE690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 2016
	{
		// Fields
		public int actor; // 0x10

		// Constructors
		public __c__DisplayClass80_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ShowPopupDelta_b__0(int k); // 0x00000001809AE690-0x00000001809AE6A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 2017
	{
		// Fields
		public string prepError; // 0x10
		public ManagerMatch __4__this; // 0x18

		// Constructors
		public __c__DisplayClass86_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadSceneAfterDelay_b__1(MatchPrepDataDTO data); // 0x00000001809AE6A0-0x00000001809AEA00
		internal void _LoadSceneAfterDelay_b__2(string err); // 0x00000001802D8AB0-0x00000001802D8B10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 2018
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool myDone; // 0x18
		public bool enemyDone; // 0x19

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRestMatchPrepFallback_b__0(PetUserDTO pet); // 0x00000001809AEA00-0x00000001809AEAB0
		internal void _TryRestMatchPrepFallback_b__2(PetUserDTO pet); // 0x00000001809AEAB0-0x00000001809AEB60
		internal void _TryRestMatchPrepFallback_b__4(UserDTO user); // 0x00000001809AEB60-0x00000001809AECD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass97_0 // TypeDefIndex: 2019
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool isEnemy; // 0x18
		public string path; // 0x20
		public int attempt; // 0x28
		public string petId; // 0x30

		// Constructors
		public __c__DisplayClass97_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ApplyPetClips_b__0(AnimationClip[] clips); // 0x00000001809AECD0-0x00000001809AF0B0
	}

	[CompilerGenerated]
	private sealed class _ApplyClipsWhenUiReady_d__107 : IEnumerator<object> // TypeDefIndex: 2020
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyClipsWhenUiReady_d__107(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809AF0B0-0x00000001809AF5F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809AF5F0-0x00000001809AF630
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__86 : IEnumerator<object> // TypeDefIndex: 2021
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__86(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001809AF630-0x00000001809AF6F0
		private bool MoveNext(); // 0x00000001809AF6F0-0x00000001809B0930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809B0930-0x00000001809B0970
	}

	[CompilerGenerated]
	private sealed class _RetryApplyPetClips_d__98 : IEnumerator<object> // TypeDefIndex: 2022
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int attempt; // 0x20
		public ManagerMatch __4__this; // 0x28
		public bool isEnemy; // 0x30
		public string petId; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RetryApplyPetClips_d__98(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809B0970-0x00000001809B0BC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809B0BC0-0x00000001809B0C00
	}

	[CompilerGenerated]
	private sealed class _TryRestMatchPrepFallback_d__87 : IEnumerator<object> // TypeDefIndex: 2023
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TryRestMatchPrepFallback_d__87(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x00000001809B0C00-0x00000001809B16B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809B16B0-0x00000001809B16F0
	}

	// Constructors
	public ManagerMatch(); // 0x00000001809AE070-0x00000001809AE450

	// Methods
	private void Awake(); // 0x00000001809A78B0-0x00000001809A7A70
	private void OnDestroy(); // 0x00000001809A7A70-0x00000001809A7C50
	private void Start(); // 0x00000001809A7C50-0x00000001809A7E10
	private void WireEnergyBuyButton(); // 0x00000001809A7E10-0x00000001809A8320
	private void OpenEnergyPurchasePopup(); // 0x00000001805F3640-0x00000001805F3650
	private void InitDebugGuiStyles(); // 0x00000001809A8320-0x00000001809A8880
	private void Update(); // 0x00000001809A8880-0x00000001809A88A0
	private void UpdatePingFpsHud(); // 0x00000001809A88A0-0x00000001809A8C80
	private void UpdateDebugStatsRealtime(); // 0x00000001809A8C80-0x00000001809A99F0
	private void ShowPopupDelta(int actor, string statName, int delta); // 0x00000001809A99F0-0x00000001809A9C30
	private void InitializeDisplayActor(); // 0x00000001809A9C30-0x00000001809A9C40
	private void CheckAndUpdateDisplayActor(); // 0x00000001809A9C40-0x00000001809A9C50
	public void SwitchDisplayToPlayer(int actorNumber); // 0x00000001809A9C50-0x00000001809AA070
	private void SetLocalUsernameTextSafe(string name); // 0x00000001809AA070-0x00000001809AA3A0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__86))]
	private IEnumerator LoadSceneAfterDelay(); // 0x00000001809AA3A0-0x00000001809AA440
	[IteratorStateMachine(typeof(_TryRestMatchPrepFallback_d__87))]
	private IEnumerator TryRestMatchPrepFallback(int userId, int idPet, int ePetId); // 0x00000001809AA440-0x00000001809AA510
	private void OnPet(string petId); // 0x00000001809AA510-0x00000001809AA550
	private void OnEnemyPet(string petId); // 0x00000001809AA550-0x00000001809AA830
	public void EnsureEnemyDisplaySynced(bool force = false /* Metadata: 0x005F17BF */); // 0x00000001809AA830-0x00000001809AAD80
	private void SyncBossPetDataId(int petId); // 0x00000001809AAD80-0x00000001809AAF40
	private void ApplyPetSprite(string petId, bool isEnemy); // 0x00000001809AAF40-0x00000001809AB180
	private void ApplyPetClips(string petId, bool isEnemy, int attempt = 0 /* Metadata: 0x005F17C0 */); // 0x00000001809AB180-0x00000001809AB4A0
	[IteratorStateMachine(typeof(_RetryApplyPetClips_d__98))]
	private IEnumerator RetryApplyPetClips(string petId, bool isEnemy, int attempt); // 0x00000001809AB4A0-0x00000001809AB5D0
	private static string PetIdFromClipPath(string path); // 0x00000001809AB5D0-0x00000001809AB650
	private bool IsDisplayOwnedByLocalPlayer(); // 0x00000001809AB650-0x00000001809AB7C0
	private void ApplyClipsNow(AnimationClip[] clips, bool isEnemy, string path = null, bool outOfRetries = false /* Metadata: 0x005F17C1 */); // 0x00000001809AB7C0-0x00000001809ABF40
	private static int ParsePetIdOrZero(string path); // 0x00000001809ABF40-0x00000001809AC060
	[IteratorStateMachine(typeof(_ApplyClipsWhenUiReady_d__107))]
	private IEnumerator ApplyClipsWhenUiReady(AnimationClip[] clips, bool isEnemy, string path); // 0x00000001809AC060-0x00000001809AC1E0
	private void OnPetsReceived(PetUserDTO pets); // 0x00000001809AC1E0-0x00000001809ACDE0
	private void OnEPetsReceived(PetUserDTO pets); // 0x00000001809ACDE0-0x00000001809ADC20
	private void OnError(string error); // 0x00000001809ADC20-0x00000001809ADCA0
	public void AddBossDamage(int damage); // 0x00000001809ADCA0-0x00000001809AE040
	public bool IsBossBattle(); // 0x00000001809AE040-0x00000001809AE050
	public bool IsTowerBattle(); // 0x00000001809AE050-0x00000001809AE060
	public int GetTotalBossDamage(); // 0x00000001809AE060-0x00000001809AE070
	[CompilerGenerated]
	private bool _LoadSceneAfterDelay_b__86_0(); // 0x00000001809AE450-0x00000001809AE470
}

