//Type is in global namespace

public class EnergyManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public EnergyManager <>4__this; //Field offset: 0x10
		public Action onSuccess; //Field offset: 0x18
		public int amount; //Field offset: 0x20
		public Action onFailed; //Field offset: 0x28

		public <>c__DisplayClass41_0() { }

		internal void <SyncConsumeEnergyWithServer>b__0(ConsumeEnergyResponse response) { }

		internal void <SyncConsumeEnergyWithServer>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <AutoSyncLoop>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <AutoSyncLoop>d__28(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClientSideRegenLoop>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <ClientSideRegenLoop>d__37(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RefreshEnergyCoroutine>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RefreshEnergyCoroutine>d__31(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <SyncConsumeEnergyWithServer>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EnergyManager <>4__this; //Field offset: 0x20
		public Action onSuccess; //Field offset: 0x28
		public int amount; //Field offset: 0x30
		public Action onFailed; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <SyncConsumeEnergyWithServer>d__41(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class EncryptedPayload
	{
		public string data; //Field offset: 0x10
		public string s; //Field offset: 0x18
		public long t; //Field offset: 0x20

		public EncryptedPayload() { }

	}

	[CompilerGenerated]
	private static EnergyManager <Instance>k__BackingField; //Field offset: 0x0
	private const float AUTO_SYNC_INTERVAL_SECONDS = 60; //Field offset: 0x0
	private const float MIN_SYNC_INTERVAL_SECONDS = 5; //Field offset: 0x0
	private const float REGEN_INTERVAL_MINUTES = 8; //Field offset: 0x0
	public const int MIN_ENERGY_TO_START = 5; //Field offset: 0x0
	[Header("UI References - Updated per scene")]
	private Text txtEnergy; //Field offset: 0x20
	private Text txtCountdown; //Field offset: 0x28
	private Image imgEnergyBar; //Field offset: 0x30
	[Header("Server Data")]
	private int currentEnergy; //Field offset: 0x38
	private int maxEnergy; //Field offset: 0x3C
	private DateTime nextRegenTime; //Field offset: 0x40
	[Header("Client-side State")]
	private bool isRegenerating; //Field offset: 0x48
	private Coroutine regenCoroutine; //Field offset: 0x50
	private DateTime lastServerSync; //Field offset: 0x58
	private bool isSyncing; //Field offset: 0x60
	private bool needsServerSync; //Field offset: 0x61
	private Coroutine autoSyncCoroutine; //Field offset: 0x68

	public bool HasServerData
	{
		 get { } //Length: 8
	}

	public private static EnergyManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public EnergyManager() { }

	[CompilerGenerated]
	private void <RefreshEnergyCoroutine>b__31_0(string error) { }

	public void ApplyEnergyInfo(EnergyInfoDTO data) { }

	[IteratorStateMachine(typeof(<AutoSyncLoop>d__28))]
	private IEnumerator AutoSyncLoop() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<ClientSideRegenLoop>d__37))]
	private IEnumerator ClientSideRegenLoop() { }

	public bool ConsumeEnergy(int amount, Action onSuccess = null, Action onFailed = null) { }

	public void ForceRefreshEnergyFromServer() { }

	public bool get_HasServerData() { }

	[CompilerGenerated]
	public static EnergyManager get_Instance() { }

	public int GetCurrentEnergy() { }

	public DateTime GetLastServerSync() { }

	public int GetMaxEnergy() { }

	public TimeSpan GetTimeUntilNextRegen() { }

	private void HandleUserEnergyDelta(ChatMessageDTO msg) { }

	public bool IsRegenerating() { }

	public bool IsSyncing() { }

	public bool NeedsServerSync() { }

	private void OnApplicationFocus(bool hasFocus) { }

	private void OnApplicationPause(bool isPaused) { }

	private void OnDestroy() { }

	private void OnEnergyError(string error) { }

	private void OnEnergyReceivedFromServer(EnergyInfoDTO data) { }

	[IteratorStateMachine(typeof(<RefreshEnergyCoroutine>d__31))]
	private IEnumerator RefreshEnergyCoroutine() { }

	public void RefreshEnergyFromServer() { }

	public void RegisterUI(Text energyText, Text countdownText, Image energyBar) { }

	[CompilerGenerated]
	private static void set_Instance(EnergyManager value) { }

	private void Start() { }

	private void StartAutoSyncTimer() { }

	private void StartClientSideRegeneration() { }

	private void StopClientSideRegeneration() { }

	[IteratorStateMachine(typeof(<SyncConsumeEnergyWithServer>d__41))]
	private IEnumerator SyncConsumeEnergyWithServer(int amount, Action onSuccess, Action onFailed) { }

	public void UnregisterUI() { }

	private void UpdateCountdownUI() { }

	private void UpdateUI() { }

}

