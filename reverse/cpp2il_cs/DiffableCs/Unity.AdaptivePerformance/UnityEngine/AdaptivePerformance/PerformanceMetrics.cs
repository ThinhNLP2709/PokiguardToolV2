namespace UnityEngine.AdaptivePerformance;

public struct PerformanceMetrics
{
	[CompilerGenerated]
	private int <CurrentCpuLevel>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private int <CurrentGpuLevel>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	private PerformanceBottleneck <PerformanceBottleneck>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private bool <CpuPerformanceBoost>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private bool <GpuPerformanceBoost>k__BackingField; //Field offset: 0xD
	[CompilerGenerated]
	private ClusterInfo <ClusterInfo>k__BackingField; //Field offset: 0x10

	public ClusterInfo ClusterInfo
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 19
		[CompilerGenerated]
		 set { } //Length: 16
	}

	public bool CpuPerformanceBoost
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public int CurrentCpuLevel
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public int CurrentGpuLevel
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool GpuPerformanceBoost
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public PerformanceBottleneck PerformanceBottleneck
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[CompilerGenerated]
	[IsReadOnly]
	public ClusterInfo get_ClusterInfo() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_CpuPerformanceBoost() { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_CurrentCpuLevel() { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_CurrentGpuLevel() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_GpuPerformanceBoost() { }

	[CompilerGenerated]
	[IsReadOnly]
	public PerformanceBottleneck get_PerformanceBottleneck() { }

	[CompilerGenerated]
	public void set_ClusterInfo(ClusterInfo value) { }

	[CompilerGenerated]
	public void set_CpuPerformanceBoost(bool value) { }

	[CompilerGenerated]
	public void set_CurrentCpuLevel(int value) { }

	[CompilerGenerated]
	public void set_CurrentGpuLevel(int value) { }

	[CompilerGenerated]
	public void set_GpuPerformanceBoost(bool value) { }

	[CompilerGenerated]
	public void set_PerformanceBottleneck(PerformanceBottleneck value) { }

}

