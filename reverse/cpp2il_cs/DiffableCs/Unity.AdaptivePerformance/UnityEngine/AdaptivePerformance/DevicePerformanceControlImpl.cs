namespace UnityEngine.AdaptivePerformance;

internal class DevicePerformanceControlImpl : IDevicePerformanceControl
{
	private IDevicePerformanceLevelControl m_PerformanceLevelControl; //Field offset: 0x10
	[CompilerGenerated]
	private PerformanceControlMode <PerformanceControlMode>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private int <CpuLevel>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private int <GpuLevel>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <CurrentCpuLevel>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private int <CurrentGpuLevel>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private bool <CpuPerformanceBoost>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	private bool <GpuPerformanceBoost>k__BackingField; //Field offset: 0x2D

	public override bool AutomaticPerformanceControl
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public override int CpuLevel
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override bool CpuPerformanceBoost
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int CurrentCpuLevel
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int CurrentGpuLevel
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override int GpuLevel
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override bool GpuPerformanceBoost
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override int MaxCpuPerformanceLevel
	{
		 get { } //Length: 78
	}

	public override int MaxGpuPerformanceLevel
	{
		 get { } //Length: 81
	}

	public override PerformanceControlMode PerformanceControlMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DevicePerformanceControlImpl(IDevicePerformanceLevelControl performanceLevelControl) { }

	private int ComputeDelta(int oldLevel, int newLevel) { }

	public override bool get_AutomaticPerformanceControl() { }

	[CompilerGenerated]
	public override int get_CpuLevel() { }

	[CompilerGenerated]
	public override bool get_CpuPerformanceBoost() { }

	[CompilerGenerated]
	public int get_CurrentCpuLevel() { }

	[CompilerGenerated]
	public int get_CurrentGpuLevel() { }

	[CompilerGenerated]
	public override int get_GpuLevel() { }

	[CompilerGenerated]
	public override bool get_GpuPerformanceBoost() { }

	public override int get_MaxCpuPerformanceLevel() { }

	public override int get_MaxGpuPerformanceLevel() { }

	[CompilerGenerated]
	public override PerformanceControlMode get_PerformanceControlMode() { }

	public override void set_AutomaticPerformanceControl(bool value) { }

	[CompilerGenerated]
	public override void set_CpuLevel(int value) { }

	[CompilerGenerated]
	public override void set_CpuPerformanceBoost(bool value) { }

	[CompilerGenerated]
	public void set_CurrentCpuLevel(int value) { }

	[CompilerGenerated]
	public void set_CurrentGpuLevel(int value) { }

	[CompilerGenerated]
	public override void set_GpuLevel(int value) { }

	[CompilerGenerated]
	public override void set_GpuPerformanceBoost(bool value) { }

	[CompilerGenerated]
	public void set_PerformanceControlMode(PerformanceControlMode value) { }

	public bool Update(out PerformanceLevelChangeEventArgs changeArgs) { }

}

