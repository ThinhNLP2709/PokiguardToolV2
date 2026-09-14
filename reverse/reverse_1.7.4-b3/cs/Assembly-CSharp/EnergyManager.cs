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

public class EnergyManager : MonoBehaviour // TypeDefIndex: 1927
{
	// Fields
	[CompilerGenerated]
	private static EnergyManager _Instance_k__BackingField; // 0x00
	public const int MIN_ENERGY_TO_START = 5; // Metadata: 0x005F02DA
	[Header("UI References - Updated per scene")]
	private UnityEngine.UI.Text txtEnergy; // 0x20
	private UnityEngine.UI.Text txtCountdown; // 0x28
	private Image imgEnergyBar; // 0x30
	[Header("Server Data")]
	private int currentEnergy; // 0x38
	private int maxEnergy; // 0x3C
	private DateTime nextRegenTime; // 0x40
	private const float REGEN_INTERVAL_MINUTES = 8f; // Metadata: 0x005F02DB
	[Header("Client-side State")]
	private bool isRegenerating; // 0x48
	private Coroutine regenCoroutine; // 0x50
	private DateTime lastServerSync; // 0x58
	private const float MIN_SYNC_INTERVAL_SECONDS = 5f; // Metadata: 0x005F02DF
	private const float AUTO_SYNC_INTERVAL_SECONDS = 60f; // Metadata: 0x005F02E3
	private bool isSyncing; // 0x60
	private bool needsServerSync; // 0x61
	private Coroutine autoSyncCoroutine; // 0x68

	// Properties
	public static EnergyManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180932440-0x0000000180932480 0x0000000180932480-0x0000000180932520
	public bool HasServerData { get; } // 0x0000000180932520-0x0000000180932530 

	// Nested types
	[Serializable]
	private class EncryptedPayload // TypeDefIndex: 1928
	{
		// Fields
		public string data; // 0x10
		public string s; // 0x18
		public long t; // 0x20

		// Constructors
		public EncryptedPayload(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 1929
	{
		// Fields
		public EnergyManager __4__this; // 0x10
		public Action onSuccess; // 0x18
		public int amount; // 0x20
		public Action onFailed; // 0x28

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SyncConsumeEnergyWithServer_b__0(ConsumeEnergyResponse response); // 0x0000000180934A80-0x0000000180934B10
		internal void _SyncConsumeEnergyWithServer_b__1(string error); // 0x0000000180934B10-0x0000000180934B70
	}

	[CompilerGenerated]
	private sealed class _AutoSyncLoop_d__29 : IEnumerator<object> // TypeDefIndex: 1930
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoSyncLoop_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180934B70-0x0000000180934D90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180934D90-0x0000000180934DD0
	}

	[CompilerGenerated]
	private sealed class _ClientSideRegenLoop_d__38 : IEnumerator<object> // TypeDefIndex: 1931
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClientSideRegenLoop_d__38(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180934DD0-0x0000000180934F90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180934F90-0x0000000180934FD0
	}

	[CompilerGenerated]
	private sealed class _RefreshEnergyCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1932
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefreshEnergyCoroutine_d__32(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180934FD0-0x00000001809352D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809352D0-0x0000000180935310
	}

	[CompilerGenerated]
	private sealed class _SyncConsumeEnergyWithServer_d__42 : IEnumerator<object> // TypeDefIndex: 1933
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20
		public Action onSuccess; // 0x28
		public int amount; // 0x30
		public Action onFailed; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SyncConsumeEnergyWithServer_d__42(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180935310-0x0000000180935970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180935970-0x00000001809359B0
	}

	// Constructors
	public EnergyManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180932530-0x0000000180932720
	private void Start(); // 0x0000000180932720-0x00000001809329B0
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x00000001809329B0-0x0000000180932D50
	public void RegisterUI(UnityEngine.UI.Text energyText, UnityEngine.UI.Text countdownText, Image energyBar, bool autoSync = true /* Metadata: 0x005F02D9 */); // 0x0000000180932D50-0x0000000180932F30
	public void ApplyFromUser(UserDTO u); // 0x0000000180932F30-0x00000001809330E0
	public void UnregisterUI(); // 0x00000001809330E0-0x0000000180933260
	private void StartAutoSyncTimer(); // 0x0000000180933260-0x0000000180933380
	[IteratorStateMachine(typeof(_AutoSyncLoop_d__29))]
	private IEnumerator AutoSyncLoop(); // 0x0000000180933380-0x0000000180933420
	public void RefreshEnergyFromServer(); // 0x0000000180933420-0x0000000180933500
	public void ForceRefreshEnergyFromServer(); // 0x0000000180933500-0x0000000180933530
	[IteratorStateMachine(typeof(_RefreshEnergyCoroutine_d__32))]
	private IEnumerator RefreshEnergyCoroutine(); // 0x0000000180933530-0x00000001809335D0
	private void OnEnergyReceivedFromServer(EnergyInfoDTO data); // 0x00000001809335D0-0x0000000180933700
	public void ApplyEnergyInfo(EnergyInfoDTO data); // 0x0000000180933700-0x0000000180933820
	private void OnEnergyError(string error); // 0x0000000180933820-0x00000001809338A0
	private void StartClientSideRegeneration(); // 0x00000001809338A0-0x00000001809339D0
	private void StopClientSideRegeneration(); // 0x00000001809339D0-0x0000000180933A50
	[IteratorStateMachine(typeof(_ClientSideRegenLoop_d__38))]
	private IEnumerator ClientSideRegenLoop(); // 0x0000000180933A50-0x0000000180933AF0
	private void UpdateUI(); // 0x0000000180933AF0-0x0000000180933D90
	private void UpdateCountdownUI(); // 0x0000000180933D90-0x0000000180934080
	public bool ConsumeEnergy(int amount, Action onSuccess = null, Action onFailed = null); // 0x0000000180934080-0x00000001809342E0
	[IteratorStateMachine(typeof(_SyncConsumeEnergyWithServer_d__42))]
	private IEnumerator SyncConsumeEnergyWithServer(int amount, Action onSuccess, Action onFailed); // 0x00000001809342E0-0x0000000180934450
	private void OnApplicationFocus(bool hasFocus); // 0x0000000180934450-0x0000000180934520
	private void OnApplicationPause(bool isPaused); // 0x0000000180934520-0x00000001809345F0
	public int GetCurrentEnergy(); // 0x0000000180853A80-0x0000000180853A90
	public int GetMaxEnergy(); // 0x00000001809345F0-0x0000000180934600
	public bool IsRegenerating(); // 0x00000001806D8E70-0x00000001806D8E80
	public bool IsSyncing(); // 0x0000000180934600-0x0000000180934610
	public TimeSpan GetTimeUntilNextRegen(); // 0x0000000180934610-0x00000001809346C0
	public DateTime GetLastServerSync(); // 0x00000001803456E0-0x00000001803456F0
	public bool NeedsServerSync(); // 0x00000001809346C0-0x00000001809346D0
	private void OnDestroy(); // 0x00000001809346D0-0x00000001809349F0
	[CompilerGenerated]
	private void _RefreshEnergyCoroutine_b__32_0(string error); // 0x00000001809349F0-0x0000000180934A80
}

