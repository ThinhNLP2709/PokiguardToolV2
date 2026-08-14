namespace UnityEngine.AdaptivePerformance;

public interface IPerformanceModeStatus
{

	public event PerformanceModeEventHandler PerformanceModeEvent
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public PerformanceMode PerformanceMode
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_PerformanceModeEvent(PerformanceModeEventHandler value) { }

	public PerformanceMode get_PerformanceMode() { }

	[CompilerGenerated]
	public void remove_PerformanceModeEvent(PerformanceModeEventHandler value) { }

}

