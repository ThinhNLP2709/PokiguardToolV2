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

public class EnergyManager : MonoBehaviour // TypeDefIndex: 1310
{
	// Fields
	[CompilerGenerated]
	private static EnergyManager _Instance_k__BackingField; // 0x00
	public const int MIN_ENERGY_TO_START = 5; // Metadata: 0x0064D5F3
	[Header("UI References - Updated per scene")]
	private UnityEngine.UI.Text txtEnergy; // 0x20
	private UnityEngine.UI.Text txtCountdown; // 0x28
	private Image imgEnergyBar; // 0x30
	[Header("Server Data")]
	private int currentEnergy; // 0x38
	private int maxEnergy; // 0x3C
	private DateTime nextRegenTime; // 0x40
	private const float REGEN_INTERVAL_MINUTES = 8f; // Metadata: 0x0064D5F4
	[Header("Client-side State")]
	private bool isRegenerating; // 0x48
	private Coroutine regenCoroutine; // 0x50
	private DateTime lastServerSync; // 0x58
	private const float MIN_SYNC_INTERVAL_SECONDS = 5f; // Metadata: 0x0064D5F8
	private const float AUTO_SYNC_INTERVAL_SECONDS = 60f; // Metadata: 0x0064D5FC
	private bool isSyncing; // 0x60
	private bool needsServerSync; // 0x61
	private Coroutine autoSyncCoroutine; // 0x68

	// Properties
	public static EnergyManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804F0C80-0x00000001804F0CC0 0x00000001804F0CC0-0x00000001804F0D20
	public bool HasServerData { get; } // 0x00000001804F0C70-0x00000001804F0C80 

	// Nested types
	[Serializable]
	private class EncryptedPayload // TypeDefIndex: 1311
	{
		// Fields
		public string data; // 0x10
		public string s; // 0x18
		public long t; // 0x20

		// Constructors
		public EncryptedPayload(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass41_0 // TypeDefIndex: 1312
	{
		// Fields
		public EnergyManager __4__this; // 0x10
		public Action onSuccess; // 0x18
		public int amount; // 0x20
		public Action onFailed; // 0x28

		// Constructors
		public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SyncConsumeEnergyWithServer_b__0(ConsumeEnergyResponse response); // 0x0000000180512F50-0x0000000180512FD0
		internal void _SyncConsumeEnergyWithServer_b__1(string error); // 0x0000000180512FD0-0x0000000180513030
	}

	[CompilerGenerated]
	private sealed class _AutoSyncLoop_d__28 : IEnumerator<object> // TypeDefIndex: 1313
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoSyncLoop_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018050F880-0x000000018050F9E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050F9E0-0x000000018050FA20
	}

	[CompilerGenerated]
	private sealed class _ClientSideRegenLoop_d__37 : IEnumerator<object> // TypeDefIndex: 1314
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClientSideRegenLoop_d__37(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180510880-0x00000001805109D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805109D0-0x0000000180510A10
	}

	[CompilerGenerated]
	private sealed class _RefreshEnergyCoroutine_d__31 : IEnumerator<object> // TypeDefIndex: 1315
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefreshEnergyCoroutine_d__31(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180511CA0-0x0000000180511E50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180511E50-0x0000000180511E90
	}

	[CompilerGenerated]
	private sealed class _SyncConsumeEnergyWithServer_d__41 : IEnumerator<object> // TypeDefIndex: 1316
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnergyManager __4__this; // 0x20
		public Action onSuccess; // 0x28
		public int amount; // 0x30
		public Action onFailed; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SyncConsumeEnergyWithServer_d__41(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805121C0-0x00000001805124C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805124C0-0x0000000180512500
	}

	// Constructors
	public EnergyManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001804EF780-0x00000001804EF870
	private void Start(); // 0x00000001804F05F0-0x00000001804F0760
	private void HandleUserEnergyDelta(ChatMessageDTO msg); // 0x00000001804EFB70-0x00000001804EFDA0
	public void RegisterUI(UnityEngine.UI.Text energyText, UnityEngine.UI.Text countdownText, Image energyBar); // 0x00000001804F03A0-0x00000001804F04B0
	public void UnregisterUI(); // 0x00000001804F08E0-0x00000001804F0950
	private void StartAutoSyncTimer(); // 0x00000001804F04B0-0x00000001804F0550
	[IteratorStateMachine(typeof(_AutoSyncLoop_d__28))]
	private IEnumerator AutoSyncLoop(); // 0x00000001804EF710-0x00000001804EF780
	public void RefreshEnergyFromServer(); // 0x00000001804F02D0-0x00000001804F03A0
	public void ForceRefreshEnergyFromServer(); // 0x00000001804EFA40-0x00000001804EFAC0
	[IteratorStateMachine(typeof(_RefreshEnergyCoroutine_d__31))]
	private IEnumerator RefreshEnergyCoroutine(); // 0x00000001804F0260-0x00000001804F02D0
	private void OnEnergyReceivedFromServer(EnergyInfoDTO data); // 0x00000001804F0160-0x00000001804F0260
	public void ApplyEnergyInfo(EnergyInfoDTO data); // 0x00000001804EF610-0x00000001804EF710
	private void OnEnergyError(string error); // 0x00000001804F00F0-0x00000001804F0160
	private void StartClientSideRegeneration(); // 0x00000001804F0550-0x00000001804F05F0
	private void StopClientSideRegeneration(); // 0x00000001804F0760-0x00000001804F07A0
	[IteratorStateMachine(typeof(_ClientSideRegenLoop_d__37))]
	private IEnumerator ClientSideRegenLoop(); // 0x00000001804EF870-0x00000001804EF8E0
	private void UpdateUI(); // 0x00000001804F0B30-0x00000001804F0C70
	private void UpdateCountdownUI(); // 0x00000001804F0950-0x00000001804F0B30
	public bool ConsumeEnergy(int amount, Action onSuccess = null, Action onFailed = null); // 0x00000001804EF8E0-0x00000001804EFA40
	[IteratorStateMachine(typeof(_SyncConsumeEnergyWithServer_d__41))]
	private IEnumerator SyncConsumeEnergyWithServer(int amount, Action onSuccess, Action onFailed); // 0x00000001804F07A0-0x00000001804F0860
	private void OnApplicationFocus(bool hasFocus); // 0x00000001804EFDC0-0x00000001804EFE90
	private void OnApplicationPause(bool isPaused); // 0x00000001804EFE90-0x00000001804EFF60
	public int GetCurrentEnergy(); // 0x000000018047EDE0-0x000000018047EDF0
	public int GetMaxEnergy(); // 0x00000001804EFAC0-0x00000001804EFAD0
	public bool IsRegenerating(); // 0x00000001804EFDA0-0x00000001804EFDB0
	public bool IsSyncing(); // 0x000000018033D4F0-0x000000018033D500
	public TimeSpan GetTimeUntilNextRegen(); // 0x00000001804EFAD0-0x00000001804EFB70
	public DateTime GetLastServerSync(); // 0x00000001802F4000-0x00000001802F4010
	public bool NeedsServerSync(); // 0x00000001804EFDB0-0x00000001804EFDC0
	private void OnDestroy(); // 0x00000001804EFF60-0x00000001804F00F0
	[CompilerGenerated]
	private void _RefreshEnergyCoroutine_b__31_0(string error); // 0x00000001804F0860-0x00000001804F08E0
}

