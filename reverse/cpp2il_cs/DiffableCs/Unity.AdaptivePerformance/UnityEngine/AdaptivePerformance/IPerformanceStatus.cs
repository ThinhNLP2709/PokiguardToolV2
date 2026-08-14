namespace UnityEngine.AdaptivePerformance;

public interface IPerformanceStatus
{

	public event PerformanceBoostChangeHandler PerformanceBoostChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event PerformanceBottleneckChangeHandler PerformanceBottleneckChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event PerformanceLevelChangeHandler PerformanceLevelChangeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public FrameTiming FrameTiming
	{
		 get { } //Length: 0
	}

	public PerformanceMetrics PerformanceMetrics
	{
		 get { } //Length: 0
	}

	public PerformanceMode PerformanceMode
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_PerformanceBoostChangeEvent(PerformanceBoostChangeHandler value) { }

	[CompilerGenerated]
	public void add_PerformanceBottleneckChangeEvent(PerformanceBottleneckChangeHandler value) { }

	[CompilerGenerated]
	public void add_PerformanceLevelChangeEvent(PerformanceLevelChangeHandler value) { }

	public FrameTiming get_FrameTiming() { }

	public PerformanceMetrics get_PerformanceMetrics() { }

	public PerformanceMode get_PerformanceMode() { }

	[CompilerGenerated]
	public void remove_PerformanceBoostChangeEvent(PerformanceBoostChangeHandler value) { }

	[CompilerGenerated]
	public void remove_PerformanceBottleneckChangeEvent(PerformanceBottleneckChangeHandler value) { }

	[CompilerGenerated]
	public void remove_PerformanceLevelChangeEvent(PerformanceLevelChangeHandler value) { }

}

