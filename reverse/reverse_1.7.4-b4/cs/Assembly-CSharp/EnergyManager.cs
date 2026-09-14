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

public class EnergyManager : MonoBehaviour // TypeDefIndex: 1929
{
	// Fields
	[CompilerGenerated]
	private static EnergyManager _Instance_k__BackingField; // 0x00
	public const int MIN_ENERGY_TO_START = 5; // Metadata: 0x005F16AB
	[Header("UI References - Updated per scene")]
	private UnityEngine.UI.Text txtEnergy; // 0x20
	private UnityEngine.UI.Text txtCountdown; // 0x28
	private Image imgEnergyBar; // 0x30
	[Header("Server Data")]
	private int currentEnergy; // 0x38
	private int maxEnergy; // 0x3C
	private DateTime nextRegenTime; // 0x40
	private const float REGEN_INTERVAL_MINUTES = 8f; // Metadata: 0x005F16AC
	[Header("Client-side State")]
	private bool isRegenerating; // 0x48
	private Coroutine regenCoroutine; // 0x50
	private DateTime lastServerSync; // 0x58
	private const float MIN_SYNC_INTERVAL_SECONDS = 5f; // Metadata: 0x005F16B0
	private const float AUTO_SYNC_INTERVAL_SECONDS = 60f; // Metadata: 0x005F16B4
	private bool isSyncing; // 0x60
	private bool needsServerSync; // 0x61
	private Coroutine autoSyncCoroutine; // 0x68

	// Properties
	public static EnergyManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180935980-0x00000001809359C0 0x00000001809359C0-0x0000000180935A60
	public bool HasServerData { get; } // 0x0000000180935A60-0x0000000180935A70 

	// Nested types
	[Serializable]
	private class EncryptedPayload // TypeDefIndex: 1930
	{
		// Fields
		public string data; // 0x10
		public string s; // 0x18
		public long t; // 0x20

		// Constructors
		public EncryptedPayload(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 1931
	{
		// Fields
		public EnergyManager __4__this; // 0x10
		public Action onSuccess; // 0x18
		public int amount; // 0x20
		public Action onFailed; // 0x28

		// Constructors
		public __c__DisplayClass42_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SyncConsumeEnergyWithServer_b__0(ConsumeEnergyResponse response); // 0x0000000180937FC0-0x0000000180938050
		internal void _SyncConsumeEnergyWithServer_b__1(string error); // 0x0000000180938050-0x00000001809380B0
	}

	[CompilerGenerated]
	private sealed class _AutoSyncLoop_d__29 : IEnumerator<object> // TypeDefIndex: 1932
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809380B0-0x00000001809382D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809382D0-0x0000000180938310
	}

	[CompilerGenerated]
	private sealed class _ClientSideRegenLoop_d__38 : IEnumerator<object> // TypeDefIndex: 1933
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180938310-0x00000001809384D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001809384D0-0x0000000180938510
	}

	[CompilerGenerated]
	private sealed class _RefreshEnergyCoroutine_d__32 : IEnumerator<object> // TypeDefIndex: 1934
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180938510-0x0000000180938830
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180938830-0x0000000180938870
	}

	[CompilerGenerated]
	private sealed class _SyncConsumeEnergyWithServer_d__42 : IEnumerator<object> // TypeDefIndex: 1935
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180938870-0x0000000180938EF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180938EF0-0x0000000180938F30
	}

	// Constructors
	public EnergyManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180935A70-0x0000000180935C60
	private void Start(); // 0x0000000180935C60-0x0000000180935EF0
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x0000000180935EF0-0x0000000180936290
	public void RegisterUI(UnityEngine.UI.Text energyText, UnityEngine.UI.Text countdownText, Image energyBar, bool autoSync = true /* Metadata: 0x005F16AA */); // 0x0000000180936290-0x0000000180936470
	public void ApplyFromUser(UserDTO u); // 0x0000000180936470-0x0000000180936620
	public void UnregisterUI(); // 0x0000000180936620-0x00000001809367A0
	private void StartAutoSyncTimer(); // 0x00000001809367A0-0x00000001809368C0
	[IteratorStateMachine(typeof(_AutoSyncLoop_d__29))]
	private IEnumerator AutoSyncLoop(); // 0x00000001809368C0-0x0000000180936960
	public void RefreshEnergyFromServer(); // 0x0000000180936960-0x0000000180936A40
	public void ForceRefreshEnergyFromServer(); // 0x0000000180936A40-0x0000000180936A70
	[IteratorStateMachine(typeof(_RefreshEnergyCoroutine_d__32))]
	private IEnumerator RefreshEnergyCoroutine(); // 0x0000000180936A70-0x0000000180936B10
	private void OnEnergyReceivedFromServer(EnergyInfoDTO data); // 0x0000000180936B10-0x0000000180936C40
	public void ApplyEnergyInfo(EnergyInfoDTO data); // 0x0000000180936C40-0x0000000180936D60
	private void OnEnergyError(string error); // 0x0000000180936D60-0x0000000180936DE0
	private void StartClientSideRegeneration(); // 0x0000000180936DE0-0x0000000180936F10
	private void StopClientSideRegeneration(); // 0x0000000180936F10-0x0000000180936F90
	[IteratorStateMachine(typeof(_ClientSideRegenLoop_d__38))]
	private IEnumerator ClientSideRegenLoop(); // 0x0000000180936F90-0x0000000180937030
	private void UpdateUI(); // 0x0000000180937030-0x00000001809372D0
	private void UpdateCountdownUI(); // 0x00000001809372D0-0x00000001809375C0
	public bool ConsumeEnergy(int amount, Action onSuccess = null, Action onFailed = null); // 0x00000001809375C0-0x0000000180937820
	[IteratorStateMachine(typeof(_SyncConsumeEnergyWithServer_d__42))]
	private IEnumerator SyncConsumeEnergyWithServer(int amount, Action onSuccess, Action onFailed); // 0x0000000180937820-0x0000000180937990
	private void OnApplicationFocus(bool hasFocus); // 0x0000000180937990-0x0000000180937A60
	private void OnApplicationPause(bool isPaused); // 0x0000000180937A60-0x0000000180937B30
	public int GetCurrentEnergy(); // 0x0000000180855D10-0x0000000180855D20
	public int GetMaxEnergy(); // 0x0000000180937B30-0x0000000180937B40
	public bool IsRegenerating(); // 0x00000001806DAAE0-0x00000001806DAAF0
	public bool IsSyncing(); // 0x0000000180937B40-0x0000000180937B50
	public TimeSpan GetTimeUntilNextRegen(); // 0x0000000180937B50-0x0000000180937C00
	public DateTime GetLastServerSync(); // 0x0000000180345800-0x0000000180345810
	public bool NeedsServerSync(); // 0x0000000180937C00-0x0000000180937C10
	private void OnDestroy(); // 0x0000000180937C10-0x0000000180937F30
	[CompilerGenerated]
	private void _RefreshEnergyCoroutine_b__32_0(string error); // 0x0000000180937F30-0x0000000180937FC0
}

