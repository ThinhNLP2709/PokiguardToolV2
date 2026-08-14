namespace UnityEngine.AdaptivePerformance;

public sealed class AdaptivePerformanceManagerSettings : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <InitializeLoader>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AdaptivePerformanceManagerSettings <>4__this; //Field offset: 0x20
		private Enumerator<AdaptivePerformanceLoader> <>7__wrap1; //Field offset: 0x28

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
		public <InitializeLoader>d__20(int <>1__state) { }

		private void <>m__Finally1() { }

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

	[HideInInspector]
	private static AdaptivePerformanceLoader s_ActiveLoader; //Field offset: 0x0
	[HideInInspector]
	private bool m_InitializationComplete; //Field offset: 0x18
	[SerializeField]
	[Tooltip("Determines if the Adaptive Performance Manager instance is responsible for creating and destroying the appropriate loader instance.")]
	private bool m_AutomaticLoading; //Field offset: 0x19
	[SerializeField]
	[Tooltip("Determines if the Adaptive Performance Manager instance is responsible for starting and stopping subsystems for the active loader instance.")]
	private bool m_AutomaticRunning; //Field offset: 0x1A
	[SerializeField]
	[Tooltip("List of Adaptive Performance Loader instances arranged in desired load order.")]
	private List<AdaptivePerformanceLoader> m_Loaders; //Field offset: 0x20

	[HideInInspector]
	public private AdaptivePerformanceLoader activeLoader
	{
		 get { } //Length: 54
		private set { } //Length: 81
	}

	public bool automaticLoading
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool automaticRunning
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool isInitializationComplete
	{
		 get { } //Length: 5
	}

	public List<AdaptivePerformanceLoader> loaders
	{
		 get { } //Length: 5
	}

	public AdaptivePerformanceManagerSettings() { }

	public T ActiveLoaderAs() { }

	internal void DeinitializeLoader() { }

	public AdaptivePerformanceLoader get_activeLoader() { }

	public bool get_automaticLoading() { }

	public bool get_automaticRunning() { }

	public bool get_isInitializationComplete() { }

	public List<AdaptivePerformanceLoader> get_loaders() { }

	[IteratorStateMachine(typeof(<InitializeLoader>d__20))]
	internal IEnumerator InitializeLoader() { }

	internal void InitializeLoaderSync() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void set_activeLoader(AdaptivePerformanceLoader value) { }

	public void set_automaticLoading(bool value) { }

	public void set_automaticRunning(bool value) { }

	internal void StartSubsystems() { }

	internal void StopSubsystems() { }

}

