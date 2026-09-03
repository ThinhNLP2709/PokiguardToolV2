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

public class ManagerMatchPVP : MonoBehaviour // TypeDefIndex: 183
{
	// Fields
	public static ManagerMatchPVP Instance; // 0x00
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
	private ActivePVP active; // 0x130
	[Header("Boss Battle")]
	private bool isBossBattle; // 0x138
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

	// Properties
	public SpriteRenderer PetHostUser { get; } // 0x0000000180682780-0x0000000180682840 
	public SpriteRenderer PetHostEnemy { get; } // 0x00000001806826C0-0x0000000180682780 

	// Events
	public event Action OnAllDataLoaded {
		add; // 0x0000000180682610-0x00000001806826C0
		remove; // 0x0000000180682840-0x00000001806828F0
	}

	// Nested types
	private class DebugPopup // TypeDefIndex: 184
	{
		// Fields
		public int delta; // 0x10
		public float time; // 0x14
		public Vector2 startPos; // 0x18

		// Constructors
		public DebugPopup(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass77_0 // TypeDefIndex: 185
	{
		// Fields
		public int actor; // 0x10

		// Constructors
		public __c__DisplayClass77_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _ShowPopupDelta_b__0(int k); // 0x000000018054E7A0-0x000000018054E7B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass84_0 // TypeDefIndex: 186
	{
		// Fields
		public string prepError; // 0x10
		public ManagerMatchPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass84_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadSceneAfterDelay_b__0(MatchPrepDataDTO data); // 0x0000000180692CA0-0x0000000180692E70
		internal void _LoadSceneAfterDelay_b__1(string err); // 0x00000001803780D0-0x00000001803780E0
		internal bool _LoadSceneAfterDelay_b__2(); // 0x0000000180692E70-0x0000000180692EB0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__84 : IEnumerator<object> // TypeDefIndex: 187
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatchPVP __4__this; // 0x20
		private __c__DisplayClass84_0 __8__1; // 0x28
		private int _userPetId_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__84(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018068ED90-0x000000018068F8A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018068F8A0-0x000000018068F8E0
	}

	[CompilerGenerated]
	private sealed class _SetupOpponentUIWhenReady_d__81 : IEnumerator<object> // TypeDefIndex: 188
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatchPVP __4__this; // 0x20
		private float _timeout_5__2; // 0x28
		private float _elapsed_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SetupOpponentUIWhenReady_d__81(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180691330-0x0000000180691560
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180691560-0x00000001806915A0
	}

	[CompilerGenerated]
	private sealed class _WaitForOpponentProps_d__85 : IEnumerator<object> // TypeDefIndex: 189
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerMatchPVP __4__this; // 0x20
		private float _tWs_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForOpponentProps_d__85(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180692F20-0x0000000180693030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180693030-0x0000000180693070
	}

	// Constructors
	public ManagerMatchPVP(); // 0x0000000180682410-0x0000000180682610

	// Methods
	private void Awake(); // 0x000000018067F3F0-0x000000018067F4B0
	private void OnDestroy(); // 0x000000018067FFD0-0x0000000180680080
	private void Start(); // 0x0000000180681250-0x0000000180681390
	private void WireEnergyBuyButton(); // 0x0000000180682150-0x0000000180682410
	private void OpenEnergyPurchasePopup(); // 0x00000001803B8DA0-0x00000001803B8DB0
	private void InitDebugGuiStyles(); // 0x000000018067FC00-0x000000018067FEE0
	private void Update(); // 0x0000000180682070-0x00000001806820E0
	private void UpdatePingFpsHud(); // 0x0000000180681D50-0x0000000180682070
	private void UpdateDebugStatsRealtime(); // 0x0000000180681520-0x0000000180681D50
	private void ShowPopupDelta(int actor, string statName, int delta); // 0x0000000180681040-0x0000000180681250
	public string GetPlayerName(int actor); // 0x000000018067F920-0x000000018067FC00
	private void InitializeDisplayActor(); // 0x000000018067FEE0-0x000000018067FF60
	[IteratorStateMachine(typeof(_SetupOpponentUIWhenReady_d__81))]
	private IEnumerator SetupOpponentUIWhenReady(); // 0x0000000180680FD0-0x0000000180681040
	private void CheckAndUpdateDisplayActor(); // 0x000000018067F4B0-0x000000018067F520
	public void SwitchDisplayToPlayer(int actorNumber); // 0x0000000180681390-0x0000000180681520
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__84))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018067FF60-0x000000018067FFD0
	[IteratorStateMachine(typeof(_WaitForOpponentProps_d__85))]
	private IEnumerator WaitForOpponentProps(); // 0x00000001806820E0-0x0000000180682150
	private MatchPlayerSnapshotDTO GetOpponentSnapshotWs(); // 0x000000018067F520-0x000000018067F920
	private void OnPet(string petId); // 0x0000000180680790-0x00000001806808C0
	private void OnEnemyPet(string petId); // 0x00000001806805F0-0x0000000180680720
	private void OnPetsReceived(PetUserDTO pets); // 0x00000001806808C0-0x0000000180680E60
	private void OnEPetsReceived(PetUserDTO pets); // 0x0000000180680080-0x00000001806805F0
	private void RefreshWeaknessLabels(); // 0x0000000180680E60-0x0000000180680FD0
	private void OnError(string error); // 0x0000000180680720-0x0000000180680790
	public void AddBossDamage(int damage); // 0x000000018067F3E0-0x000000018067F3F0
	public bool IsBossBattle(); // 0x000000018033D280-0x000000018033D290
	public int GetTotalBossDamage(); // 0x0000000180531AE0-0x0000000180531AF0
}

