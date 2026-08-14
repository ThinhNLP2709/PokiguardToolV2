namespace UnityEngine.AdaptivePerformance;

public struct PerformanceBoostChangeEventArgs
{
	[CompilerGenerated]
	private bool <CpuBoost>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private bool <GpuBoost>k__BackingField; //Field offset: 0x1

	public bool CpuBoost
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public bool GpuBoost
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_CpuBoost() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_GpuBoost() { }

	[CompilerGenerated]
	public void set_CpuBoost(bool value) { }

	[CompilerGenerated]
	public void set_GpuBoost(bool value) { }

}

