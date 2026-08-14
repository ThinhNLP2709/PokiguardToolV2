namespace UnityEngine.AdaptivePerformance;

internal class AdaptivePerformanceManager : MonoBehaviour, IAdaptivePerformance, IThermalStatus, IPerformanceStatus, IDevicePerformanceControl, IDevelopmentSettings, IPerformanceModeStatus
{
	[CompilerGenerated]
	private sealed class <InvokeEndOfFrame>d__108 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AdaptivePerformanceManager <>4__this; //Field offset: 0x20

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
		public <InvokeEndOfFrame>d__108(int <>1__state) { }

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
	private ThermalEventHandler ThermalEvent; //Field offset: 0x20
	[CompilerGenerated]
	private PerformanceBottleneckChangeHandler PerformanceBottleneckChangeEvent; //Field offset: 0x28
	[CompilerGenerated]
	private PerformanceLevelChangeHandler PerformanceLevelChangeEvent; //Field offset: 0x30
	[CompilerGenerated]
	private PerformanceBoostChangeHandler PerformanceBoostChangeEvent; //Field offset: 0x38
	[CompilerGenerated]
	private PerformanceModeEventHandler PerformanceModeEvent; //Field offset: 0x40
	private bool m_JustResumed; //Field offset: 0x48
	private int m_RequestedCpuLevel; //Field offset: 0x4C
	private int m_RequestedGpuLevel; //Field offset: 0x50
	private bool m_NewUserPerformanceLevelRequest; //Field offset: 0x54
	private bool m_RequestedCpuBoost; //Field offset: 0x55
	private bool m_RequestedGpuBoost; //Field offset: 0x56
	private bool m_NewUserCpuPerformanceBoostRequest; //Field offset: 0x57
	private bool m_NewUserGpuPerformanceBoostRequest; //Field offset: 0x58
	private ThermalMetrics m_ThermalMetrics; //Field offset: 0x5C
	private PerformanceMetrics m_PerformanceMetrics; //Field offset: 0x68
	private FrameTiming m_FrameTiming; //Field offset: 0x84
	private PerformanceMode m_PerformanceMode; //Field offset: 0x9C
	[CompilerGenerated]
	private int <LoggingFrequencyInFrames>k__BackingField; //Field offset: 0xA0
	private bool m_AutomaticPerformanceControl; //Field offset: 0xA4
	private bool m_AutomaticPerformanceControlChanged; //Field offset: 0xA5
	[CompilerGenerated]
	private AdaptivePerformanceIndexer <Indexer>k__BackingField; //Field offset: 0xA8
	private IAdaptivePerformanceSettings m_Settings; //Field offset: 0xB0
	private AdaptivePerformanceSubsystem m_Subsystem; //Field offset: 0xB8
	private DevicePerformanceControlImpl m_DevicePerfControl; //Field offset: 0xC0
	private AutoPerformanceLevelController m_AutoPerformanceLevelController; //Field offset: 0xC8
	private AutoPerformanceModeController m_AutoPerformanceModeController; //Field offset: 0xD0
	private CpuTimeProvider m_CpuFrameTimeProvider; //Field offset: 0xD8
	private GpuTimeProvider m_GpuFrameTimeProvider; //Field offset: 0xE0
	private IApplicationLifecycle m_AppLifecycle; //Field offset: 0xE8
	private TemperatureTrend m_TemperatureTrend; //Field offset: 0xF0
	private bool m_UseProviderOverallFrameTime; //Field offset: 0xF8
	private WaitForEndOfFrame m_WaitForEndOfFrame; //Field offset: 0x100
	private int m_FrameCount; //Field offset: 0x108
	private RunningAverage m_OverallFrameTime; //Field offset: 0x110
	private float m_OverallFrameTimeAccu; //Field offset: 0x118
	private RunningAverage m_GpuFrameTime; //Field offset: 0x120
	private RunningAverage m_CpuFrameTime; //Field offset: 0x128

	public override event PerformanceBoostChangeHandler PerformanceBoostChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event PerformanceBottleneckChangeHandler PerformanceBottleneckChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event PerformanceLevelChangeHandler PerformanceLevelChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event PerformanceModeEventHandler PerformanceModeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event ThermalEventHandler ThermalEvent
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override bool Active
	{
		 get { } //Length: 301
	}

	public override bool AutomaticPerformanceControl
	{
		 get { } //Length: 8
		 set { } //Length: 14
	}

	public override int CpuLevel
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public override bool CpuPerformanceBoost
	{
		 get { } //Length: 5
		 set { } //Length: 8
	}

	public override IDevelopmentSettings DevelopmentSettings
	{
		 get { } //Length: 4
	}

	public override IDevicePerformanceControl DevicePerformanceControl
	{
		 get { } //Length: 4
	}

	public override FrameTiming FrameTiming
	{
		 get { } //Length: 27
	}

	public override int GpuLevel
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public override bool GpuPerformanceBoost
	{
		 get { } //Length: 5
		 set { } //Length: 8
	}

	public private override AdaptivePerformanceIndexer Indexer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public override bool Initialized
	{
		 get { } //Length: 279
	}

	public override bool Logging
	{
		 get { } //Length: 54
		 set { } //Length: 59
	}

	public override int LoggingFrequencyInFrames
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public override int MaxCpuPerformanceLevel
	{
		 get { } //Length: 113
	}

	public override int MaxGpuPerformanceLevel
	{
		 get { } //Length: 116
	}

	public override PerformanceControlMode PerformanceControlMode
	{
		 get { } //Length: 27
	}

	public override PerformanceMetrics PerformanceMetrics
	{
		 get { } //Length: 30
	}

	public override PerformanceMode PerformanceMode
	{
		 get { } //Length: 7
	}

	public override IPerformanceModeStatus PerformanceModeStatus
	{
		 get { } //Length: 4
	}

	public override IPerformanceStatus PerformanceStatus
	{
		 get { } //Length: 4
	}

	public private override IAdaptivePerformanceSettings Settings
	{
		 get { } //Length: 8
		private set { } //Length: 19
	}

	public override AdaptivePerformanceSubsystem Subsystem
	{
		 get { } //Length: 8
	}

	public override ThermalMetrics ThermalMetrics
	{
		 get { } //Length: 19
	}

	public override IThermalStatus ThermalStatus
	{
		 get { } //Length: 4
	}

	public AdaptivePerformanceManager() { }

	private void AccumulateTimingValue(ref float accu, float newValue) { }

	[CompilerGenerated]
	public override void add_PerformanceBoostChangeEvent(PerformanceBoostChangeHandler value) { }

	[CompilerGenerated]
	public override void add_PerformanceBottleneckChangeEvent(PerformanceBottleneckChangeHandler value) { }

	[CompilerGenerated]
	public override void add_PerformanceLevelChangeEvent(PerformanceLevelChangeHandler value) { }

	[CompilerGenerated]
	public override void add_PerformanceModeEvent(PerformanceModeEventHandler value) { }

	[CompilerGenerated]
	public override void add_ThermalEvent(ThermalEventHandler value) { }

	private void AddNonNegativeValue(RunningAverage runningAverage, float value) { }

	public void Awake() { }

	private void CollectProfilerStats() { }

	public override void DeinitializeAdaptivePerformance() { }

	public static float EffectiveTargetFrameRate() { }

	public override bool get_Active() { }

	public override bool get_AutomaticPerformanceControl() { }

	public override int get_CpuLevel() { }

	public override bool get_CpuPerformanceBoost() { }

	public override IDevelopmentSettings get_DevelopmentSettings() { }

	public override IDevicePerformanceControl get_DevicePerformanceControl() { }

	public override FrameTiming get_FrameTiming() { }

	public override int get_GpuLevel() { }

	public override bool get_GpuPerformanceBoost() { }

	[CompilerGenerated]
	public override AdaptivePerformanceIndexer get_Indexer() { }

	public override bool get_Initialized() { }

	public override bool get_Logging() { }

	[CompilerGenerated]
	public override int get_LoggingFrequencyInFrames() { }

	public override int get_MaxCpuPerformanceLevel() { }

	public override int get_MaxGpuPerformanceLevel() { }

	public override PerformanceControlMode get_PerformanceControlMode() { }

	public override PerformanceMetrics get_PerformanceMetrics() { }

	public override PerformanceMode get_PerformanceMode() { }

	public override IPerformanceModeStatus get_PerformanceModeStatus() { }

	public override IPerformanceStatus get_PerformanceStatus() { }

	public override IAdaptivePerformanceSettings get_Settings() { }

	public override AdaptivePerformanceSubsystem get_Subsystem() { }

	public override ThermalMetrics get_ThermalMetrics() { }

	public override IThermalStatus get_ThermalStatus() { }

	public override void InitializeAdaptivePerformance() { }

	[IteratorStateMachine(typeof(<InvokeEndOfFrame>d__108))]
	private IEnumerator InvokeEndOfFrame() { }

	public void LateUpdate() { }

	private void LogBoostEvent(PerformanceBoostChangeEventArgs ev) { }

	private void LogBottleneckEvent(PerformanceBottleneckChangeEventArgs ev) { }

	private void LogPerformanceLevelEvent(PerformanceLevelChangeEventArgs ev) { }

	private void LogPerformanceModeEvent(PerformanceMode performanceMode) { }

	private void LogThermalEvent(ThermalMetrics ev) { }

	public void OnApplicationPause(bool pause) { }

	public void OnDestroy() { }

	[CompilerGenerated]
	public override void remove_PerformanceBoostChangeEvent(PerformanceBoostChangeHandler value) { }

	[CompilerGenerated]
	public override void remove_PerformanceBottleneckChangeEvent(PerformanceBottleneckChangeHandler value) { }

	[CompilerGenerated]
	public override void remove_PerformanceLevelChangeEvent(PerformanceLevelChangeHandler value) { }

	[CompilerGenerated]
	public override void remove_PerformanceModeEvent(PerformanceModeEventHandler value) { }

	[CompilerGenerated]
	public override void remove_ThermalEvent(ThermalEventHandler value) { }

	public override void set_AutomaticPerformanceControl(bool value) { }

	public override void set_CpuLevel(int value) { }

	public override void set_CpuPerformanceBoost(bool value) { }

	public override void set_GpuLevel(int value) { }

	public override void set_GpuPerformanceBoost(bool value) { }

	[CompilerGenerated]
	private void set_Indexer(AdaptivePerformanceIndexer value) { }

	public override void set_Logging(bool value) { }

	[CompilerGenerated]
	public override void set_LoggingFrequencyInFrames(int value) { }

	private void set_Settings(IAdaptivePerformanceSettings value) { }

	public override void StartAdaptivePerformance() { }

	public override void StopAdaptivePerformance() { }

	public override bool SupportedFeature(Feature feature) { }

	private static string ToStringWithSign(int x) { }

	public void Update() { }

	private void UpdateSubsystem() { }

	private static bool WillCurrentFrameRender() { }

}

