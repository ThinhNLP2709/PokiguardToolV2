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

public class ManagerMatch : MonoBehaviour // TypeDefIndex: 2011
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
	private const int PET_CLIP_MAX_RETRY = 3; // Metadata: 0x005F03F1
	private int _rigEnemyPetId; // 0x1E0
	private int _rigUserPetId; // 0x1E4
	private int _rigEnemyClipCount; // 0x1E8
	private int _rigUserClipCount; // 0x1EC

	// Properties
	public SpriteRenderer PetHostUser { get; } // 0x00000001809A39D0-0x00000001809A3BD0 
	public SpriteRenderer PetHostEnemy { get; } // 0x00000001809A3BD0-0x00000001809A3DD0 
	public string EnemyDisplayName { get; } // 0x00000001809A3FD0-0x00000001809A4000 

	// Events
	public event Action OnAllDataLoaded {
		add; // 0x00000001809A3DD0-0x00000001809A3ED0
		remove; // 0x00000001809A3ED0-0x00000001809A3FD0
	}

	// Nested types
	private class DebugPopup // TypeDefIndex: 2012
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
	private sealed class __c // TypeDefIndex: 2013
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__87_1; // 0x08
		public static Action<string> __9__87_3; // 0x10
		public static Action<string> __9__87_5; // 0x18

		// Constructors
		static __c(); // 0x00000001809AABC0-0x00000001809AAC60
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRestMatchPrepFallback_b__87_1(string err); // 0x00000001809AAC60-0x00000001809AACE0
		internal void _TryRestMatchPrepFallback_b__87_3(string err); // 0x00000001809AACE0-0x00000001809AAD60
		internal void _TryRestMatchPrepFallback_b__87_5(string err); // 0x00000001809AAD60-0x00000001809AADE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass80_0 // TypeDefIndex: 2014
	{
		// Fields
		public int actor; // 0x10

		// Constructors
		public __c__DisplayClass80_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _ShowPopupDelta_b__0(int k); // 0x00000001809AADE0-0x00000001809AADF0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass86_0 // TypeDefIndex: 2015
	{
		// Fields
		public string prepError; // 0x10
		public ManagerMatch __4__this; // 0x18

		// Constructors
		public __c__DisplayClass86_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadSceneAfterDelay_b__1(MatchPrepDataDTO data); // 0x00000001809AADF0-0x00000001809AB150
		internal void _LoadSceneAfterDelay_b__2(string err); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass87_0 // TypeDefIndex: 2016
	{
		// Fields
		public ManagerMatch __4__this; // 0x10
		public bool myDone; // 0x18
		public bool enemyDone; // 0x19

		// Constructors
		public __c__DisplayClass87_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRestMatchPrepFallback_b__0(PetUserDTO pet); // 0x00000001809AB150-0x00000001809AB200
		internal void _TryRestMatchPrepFallback_b__2(PetUserDTO pet); // 0x00000001809AB200-0x00000001809AB2B0
		internal void _TryRestMatchPrepFallback_b__4(UserDTO user); // 0x00000001809AB2B0-0x00000001809AB420
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass97_0 // TypeDefIndex: 2017
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
		internal void _ApplyPetClips_b__0(AnimationClip[] clips); // 0x00000001809AB420-0x00000001809AB800
	}

	[CompilerGenerated]
	private sealed class _ApplyClipsWhenUiReady_d__107 : IEnumerator<object> // TypeDefIndex: 2018
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809AB800-0x00000001809ABD40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809ABD40-0x00000001809ABD80
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__86 : IEnumerator<object> // TypeDefIndex: 2019
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
		void IDisposable.Dispose(); // 0x00000001809ABD80-0x00000001809ABE40
		private bool MoveNext(); // 0x00000001809ABE40-0x00000001809AD080
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809AD080-0x00000001809AD0C0
	}

	[CompilerGenerated]
	private sealed class _RetryApplyPetClips_d__98 : IEnumerator<object> // TypeDefIndex: 2020
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001809AD0C0-0x00000001809AD310
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809AD310-0x00000001809AD350
	}

	[CompilerGenerated]
	private sealed class _TryRestMatchPrepFallback_d__87 : IEnumerator<object> // TypeDefIndex: 2021
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
		private bool MoveNext(); // 0x00000001809AD350-0x00000001809ADDB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809ADDB0-0x00000001809ADDF0
	}

	// Constructors
	public ManagerMatch(); // 0x00000001809AA7C0-0x00000001809AABA0

	// Methods
	private void Awake(); // 0x00000001809A4000-0x00000001809A41C0
	private void OnDestroy(); // 0x00000001809A41C0-0x00000001809A43A0
	private void Start(); // 0x00000001809A43A0-0x00000001809A4560
	private void WireEnergyBuyButton(); // 0x00000001809A4560-0x00000001809A4A70
	private void OpenEnergyPurchasePopup(); // 0x00000001805F1C50-0x00000001805F1C60
	private void InitDebugGuiStyles(); // 0x00000001809A4A70-0x00000001809A4FD0
	private void Update(); // 0x00000001809A4FD0-0x00000001809A4FF0
	private void UpdatePingFpsHud(); // 0x00000001809A4FF0-0x00000001809A53D0
	private void UpdateDebugStatsRealtime(); // 0x00000001809A53D0-0x00000001809A6140
	private void ShowPopupDelta(int actor, string statName, int delta); // 0x00000001809A6140-0x00000001809A6380
	private void InitializeDisplayActor(); // 0x00000001809A6380-0x00000001809A6390
	private void CheckAndUpdateDisplayActor(); // 0x00000001809A6390-0x00000001809A63A0
	public void SwitchDisplayToPlayer(int actorNumber); // 0x00000001809A63A0-0x00000001809A67C0
	private void SetLocalUsernameTextSafe(string name); // 0x00000001809A67C0-0x00000001809A6AF0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__86))]
	private IEnumerator LoadSceneAfterDelay(); // 0x00000001809A6AF0-0x00000001809A6B90
	[IteratorStateMachine(typeof(_TryRestMatchPrepFallback_d__87))]
	private IEnumerator TryRestMatchPrepFallback(int userId, int idPet, int ePetId); // 0x00000001809A6B90-0x00000001809A6C60
	private void OnPet(string petId); // 0x00000001809A6C60-0x00000001809A6CA0
	private void OnEnemyPet(string petId); // 0x00000001809A6CA0-0x00000001809A6F80
	public void EnsureEnemyDisplaySynced(bool force = false /* Metadata: 0x005F03EE */); // 0x00000001809A6F80-0x00000001809A74D0
	private void SyncBossPetDataId(int petId); // 0x00000001809A74D0-0x00000001809A7690
	private void ApplyPetSprite(string petId, bool isEnemy); // 0x00000001809A7690-0x00000001809A78D0
	private void ApplyPetClips(string petId, bool isEnemy, int attempt = 0 /* Metadata: 0x005F03EF */); // 0x00000001809A78D0-0x00000001809A7BF0
	[IteratorStateMachine(typeof(_RetryApplyPetClips_d__98))]
	private IEnumerator RetryApplyPetClips(string petId, bool isEnemy, int attempt); // 0x00000001809A7BF0-0x00000001809A7D20
	private static string PetIdFromClipPath(string path); // 0x00000001809A7D20-0x00000001809A7DA0
	private bool IsDisplayOwnedByLocalPlayer(); // 0x00000001809A7DA0-0x00000001809A7F10
	private void ApplyClipsNow(AnimationClip[] clips, bool isEnemy, string path = null, bool outOfRetries = false /* Metadata: 0x005F03F0 */); // 0x00000001809A7F10-0x00000001809A8690
	private static int ParsePetIdOrZero(string path); // 0x00000001809A8690-0x00000001809A87B0
	[IteratorStateMachine(typeof(_ApplyClipsWhenUiReady_d__107))]
	private IEnumerator ApplyClipsWhenUiReady(AnimationClip[] clips, bool isEnemy, string path); // 0x00000001809A87B0-0x00000001809A8930
	private void OnPetsReceived(PetUserDTO pets); // 0x00000001809A8930-0x00000001809A9530
	private void OnEPetsReceived(PetUserDTO pets); // 0x00000001809A9530-0x00000001809AA370
	private void OnError(string error); // 0x00000001809AA370-0x00000001809AA3F0
	public void AddBossDamage(int damage); // 0x00000001809AA3F0-0x00000001809AA790
	public bool IsBossBattle(); // 0x00000001809AA790-0x00000001809AA7A0
	public bool IsTowerBattle(); // 0x00000001809AA7A0-0x00000001809AA7B0
	public int GetTotalBossDamage(); // 0x00000001809AA7B0-0x00000001809AA7C0
	[CompilerGenerated]
	private bool _LoadSceneAfterDelay_b__86_0(); // 0x00000001809AABA0-0x00000001809AABC0
}

