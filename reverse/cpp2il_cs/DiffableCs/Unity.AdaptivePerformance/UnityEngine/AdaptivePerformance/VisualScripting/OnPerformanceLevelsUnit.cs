namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("On Performance Level")]
[UnitSubtitle("CPU and GPU Levels")]
public class OnPerformanceLevelsUnit : EventUnit<PerformanceLevelChangeEventArgs>
{
	[DoNotSerialize]
	public ValueOutput CpuLevel; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput GpuLevel; //Field offset: 0xA8
	private int cpuLevel; //Field offset: 0xB0
	private int gpuLevel; //Field offset: 0xB4

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	public OnPerformanceLevelsUnit() { }

	[CompilerGenerated]
	private int <Definition>b__8_0(Flow flow) { }

	[CompilerGenerated]
	private int <Definition>b__8_1(Flow flow) { }

	protected virtual void AssignArguments(Flow flow, PerformanceLevelChangeEventArgs data) { }

	protected virtual void Definition() { }

	protected virtual bool get_register() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	private void UpdateStats() { }

}

