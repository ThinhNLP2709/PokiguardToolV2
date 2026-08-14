namespace UnityEngine.AdaptivePerformance;

public interface IThermalStatus
{

	public event ThermalEventHandler ThermalEvent
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public ThermalMetrics ThermalMetrics
	{
		 get { } //Length: 0
	}

	[CompilerGenerated]
	public void add_ThermalEvent(ThermalEventHandler value) { }

	public ThermalMetrics get_ThermalMetrics() { }

	[CompilerGenerated]
	public void remove_ThermalEvent(ThermalEventHandler value) { }

}

