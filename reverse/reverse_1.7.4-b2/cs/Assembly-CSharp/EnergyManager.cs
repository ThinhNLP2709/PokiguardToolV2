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

public class EnergyManager : MonoBehaviour // TypeDefIndex: 1544
{
	// Fields
	[CompilerGenerated]
	private static EnergyManager _Instance_k__BackingField; // 0x00
	public const int MIN_ENERGY_TO_START = 5; // Metadata: 0x0068D414
	[Header("UI References - Updated per scene")]
	private UnityEngine.UI.Text txtEnergy; // 0x20
	private UnityEngine.UI.Text txtCountdown; // 0x28
	private Image imgEnergyBar; // 0x30
	[Header("Server Data")]
	private int currentEnergy; // 0x38
	private int maxEnergy; // 0x3C
	private DateTime nextRegenTime; // 0x40
	private const float REGEN_INTERVAL_MINUTES = 8f; // Metadata: 0x0068D415
	[Header("Client-side State")]
	private bool isRegenerating; // 0x48
	private Coroutine regenCoroutine; // 0x50
	private DateTime lastServerSync; // 0x58
	private const float MIN_SYNC_INTERVAL_SECONDS = 5f; // Metadata: 0x0068D419
	private const float AUTO_SYNC_INTERVAL_SECONDS = 60f; // Metadata: 0x0068D41D
	private bool isSyncing; // 0x60
	private bool needsServerSync; // 0x61
	private Coroutine autoSyncCoroutine; // 0x68

	// Properties
	public static EnergyManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805F26E0-0x00000001805F2720 0x00000001805F2720-0x00000001805F2780
	public bool HasServerData { get; } // 0x00000001805F26D0-0x00000001805F26E0 

	// Nested types
	[Serializable]
	private class EncryptedPayload // TypeDefIndex: 1545
	{
		// Fields
		public string data; // 0x10
		public string s; // 0x18
		public long t; // 0x20

		// Constructors
		public EncryptedPayload(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 1546
	{
		// Fields
		public EnergyManager __4__this; // 0x10
		public Action onSuccess; // 0x18
		public int amount; // 0x20
		public Action onFailed; // 0x28

		// Constructors
		public __c__DisplayClass42_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SyncConsumeEnergyWithServer_b__0(ConsumeEnergyResponse response); // 0x000000018060A210-0x000000018060A290
		internal void _SyncConsumeEnergyWithServer_b__1(string error); // 0x000000018060A290-0x000000018060A2F0
	}

	[CompilerGenerated]
	private sealed class _AutoSyncLoop_d__29 : IEnumerator<object> // TypeDefIndex: 1547
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoSyncLoop_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806043D0-0x0000000180604530
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180604530-0x0000000180604570
	}

	[CompilerGenerated]
	private sealed class _ClientSideRegenLoop_d__38 : IEnumerator<object> // TypeDefIndex: 1548
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClientSideRegenLoop_d__38(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180604EE0-0x0000000180605030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180605030-0x0000000180605070
	}

	[CompilerGenerated]
	private sealed class _RefreshEnergyCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1549
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefreshEnergyCoroutine_d__32(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180605D40-0x0000000180605EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180605EF0-0x0000000180605F30
	}

	[CompilerGenerated]
	private sealed class _SyncConsumeEnergyWithServer_d__42 : IEnumerator<object> // TypeDefIndex: 1550
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20
		public Action onSuccess; // 0x28
		public int amount; // 0x30
		public Action onFailed; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SyncConsumeEnergyWithServer_d__42(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180609540-0x0000000180609840
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180609840-0x0000000180609880
	}

	// Constructors
	public EnergyManager(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001805F11D0-0x00000001805F12C0
	private void Start(); // 0x00000001805F2050-0x00000001805F21C0
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x00000001805F15C0-0x00000001805F17F0
	public void RegisterUI(UnityEngine.UI.Text energyText, UnityEngine.UI.Text countdownText, Image energyBar, bool autoSync = true /* Metadata: 0x0068D413 */); // 0x00000001805F1DF0-0x00000001805F1F10
	public void ApplyFromUser(UserDTO u); // 0x00000001805F1020-0x00000001805F1160
	public void UnregisterUI(); // 0x00000001805F2340-0x00000001805F23B0
	private void StartAutoSyncTimer(); // 0x00000001805F1F10-0x00000001805F1FB0
	[IteratorStateMachine(typeof(_AutoSyncLoop_d__29))]
	private IEnumerator AutoSyncLoop(); // 0x00000001805F1160-0x00000001805F11D0
	public void RefreshEnergyFromServer(); // 0x00000001805F1D20-0x00000001805F1DF0
	public void ForceRefreshEnergyFromServer(); // 0x00000001805F1490-0x00000001805F1510
	[IteratorStateMachine(typeof(_RefreshEnergyCoroutine_d__32))]
	private IEnumerator RefreshEnergyCoroutine(); // 0x00000001805F1CB0-0x00000001805F1D20
	private void OnEnergyReceivedFromServer(EnergyInfoDTO data); // 0x00000001805F1BB0-0x00000001805F1CB0
	public void ApplyEnergyInfo(EnergyInfoDTO data); // 0x00000001805F0F20-0x00000001805F1020
	private void OnEnergyError(string error); // 0x00000001805F1B40-0x00000001805F1BB0
	private void StartClientSideRegeneration(); // 0x00000001805F1FB0-0x00000001805F2050
	private void StopClientSideRegeneration(); // 0x00000001805F21C0-0x00000001805F2200
	[IteratorStateMachine(typeof(_ClientSideRegenLoop_d__38))]
	private IEnumerator ClientSideRegenLoop(); // 0x00000001805F12C0-0x00000001805F1330
	private void UpdateUI(); // 0x00000001805F2590-0x00000001805F26D0
	private void UpdateCountdownUI(); // 0x00000001805F23B0-0x00000001805F2590
	public bool ConsumeEnergy(int amount, Action onSuccess = null, Action onFailed = null); // 0x00000001805F1330-0x00000001805F1490
	[IteratorStateMachine(typeof(_SyncConsumeEnergyWithServer_d__42))]
	private IEnumerator SyncConsumeEnergyWithServer(int amount, Action onSuccess, Action onFailed); // 0x00000001805F2200-0x00000001805F22C0
	private void OnApplicationFocus(bool hasFocus); // 0x00000001805F1810-0x00000001805F18E0
	private void OnApplicationPause(bool isPaused); // 0x00000001805F18E0-0x00000001805F19B0
	public int GetCurrentEnergy(); // 0x000000018056F320-0x000000018056F330
	public int GetMaxEnergy(); // 0x00000001805F1510-0x00000001805F1520
	public bool IsRegenerating(); // 0x00000001805F17F0-0x00000001805F1800
	public bool IsSyncing(); // 0x000000018039C0A0-0x000000018039C0B0
	public TimeSpan GetTimeUntilNextRegen(); // 0x00000001805F1520-0x00000001805F15C0
	public DateTime GetLastServerSync(); // 0x00000001803F79E0-0x00000001803F79F0
	public bool NeedsServerSync(); // 0x00000001805F1800-0x00000001805F1810
	private void OnDestroy(); // 0x00000001805F19B0-0x00000001805F1B40
	[CompilerGenerated]
	private void _RefreshEnergyCoroutine_b__32_0(string error); // 0x00000001805F22C0-0x00000001805F2340
}

