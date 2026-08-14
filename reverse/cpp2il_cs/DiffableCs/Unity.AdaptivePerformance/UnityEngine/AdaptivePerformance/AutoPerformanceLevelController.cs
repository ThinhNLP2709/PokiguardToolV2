namespace UnityEngine.AdaptivePerformance;

internal class AutoPerformanceLevelController
{
	private IDevicePerformanceControl m_PerfControl; //Field offset: 0x10
	private IPerformanceStatus m_PerfStats; //Field offset: 0x18
	private IThermalStatus m_ThermalStats; //Field offset: 0x20
	private float m_LastChangeTimeStamp; //Field offset: 0x28
	private float m_LastGpuLevelRaiseTimeStamp; //Field offset: 0x2C
	private float m_LastCpuLevelRaiseTimeStamp; //Field offset: 0x30
	private float m_TargetFrameRateHitTimestamp; //Field offset: 0x34
	private float m_BottleneckUnknownTimestamp; //Field offset: 0x38
	private bool m_TriedToResolveUnknownBottleneck; //Field offset: 0x3C
	private bool m_Enabled; //Field offset: 0x3D
	private string m_FeatureName; //Field offset: 0x40
	[CompilerGenerated]
	private float <TargetFrameTime>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private float <AllowedCpuActiveTimeRatio>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	private float <AllowedGpuActiveTimeRatio>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private float <GpuLevelBounceAvoidanceThreshold>k__BackingField; //Field offset: 0x54
	[CompilerGenerated]
	private float <CpuLevelBounceAvoidanceThreshold>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private float <UpdateInterval>k__BackingField; //Field offset: 0x5C
	[CompilerGenerated]
	private float <MinTargetFrameRateHitTime>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private float <MaxTemperatureLevel>k__BackingField; //Field offset: 0x64

	public float AllowedCpuActiveTimeRatio
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float AllowedGpuActiveTimeRatio
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float CpuLevelBounceAvoidanceThreshold
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public bool Enabled
	{
		 get { } //Length: 5
		 set { } //Length: 9
	}

	public float GpuLevelBounceAvoidanceThreshold
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float MaxTemperatureLevel
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float MinTargetFrameRateHitTime
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float TargetFrameTime
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float UpdateInterval
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public AutoPerformanceLevelController(IDevicePerformanceControl perfControl, IPerformanceStatus perfStat, IThermalStatus thermalStat) { }

	[CompilerGenerated]
	private void <.ctor>b__43_0(PerformanceBottleneckChangeEventArgs ev) { }

	private bool AllowLowerCpuLevel(float timestamp) { }

	private bool AllowLowerGpuLevel(float timestamp) { }

	private bool AllowRaiseCpuLevel() { }

	private bool AllowRaiseGpuLevel() { }

	private bool AllowRaiseLevels() { }

	[CompilerGenerated]
	public float get_AllowedCpuActiveTimeRatio() { }

	[CompilerGenerated]
	public float get_AllowedGpuActiveTimeRatio() { }

	[CompilerGenerated]
	public float get_CpuLevelBounceAvoidanceThreshold() { }

	public bool get_Enabled() { }

	[CompilerGenerated]
	public float get_GpuLevelBounceAvoidanceThreshold() { }

	[CompilerGenerated]
	public float get_MaxTemperatureLevel() { }

	[CompilerGenerated]
	public float get_MinTargetFrameRateHitTime() { }

	[CompilerGenerated]
	public float get_TargetFrameTime() { }

	[CompilerGenerated]
	public float get_UpdateInterval() { }

	private void LowerCpuLevel(float timestamp) { }

	private void LowerGpuLevel(float timestamp) { }

	private void OnBottleneckChange(PerformanceBottleneckChangeEventArgs ev) { }

	public void Override(int requestedCpuLevel, int requestedGpuLevel) { }

	private void RaiseCpuLevel(float timestamp) { }

	private void RaiseGpuLevel(float timestamp) { }

	[CompilerGenerated]
	public void set_AllowedCpuActiveTimeRatio(float value) { }

	[CompilerGenerated]
	public void set_AllowedGpuActiveTimeRatio(float value) { }

	[CompilerGenerated]
	public void set_CpuLevelBounceAvoidanceThreshold(float value) { }

	public void set_Enabled(bool value) { }

	[CompilerGenerated]
	public void set_GpuLevelBounceAvoidanceThreshold(float value) { }

	[CompilerGenerated]
	public void set_MaxTemperatureLevel(float value) { }

	[CompilerGenerated]
	public void set_MinTargetFrameRateHitTime(float value) { }

	[CompilerGenerated]
	public void set_TargetFrameTime(float value) { }

	[CompilerGenerated]
	public void set_UpdateInterval(float value) { }

	public void Update() { }

	private void UpdateImpl(float timestamp) { }

}

