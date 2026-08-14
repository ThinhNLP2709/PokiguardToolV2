namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Set Performance Level")]
[UnitSubtitle("CPU and GPU Levels")]
public class SetPerformanceLevelsUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger; //Field offset: 0x90
	[DoNotSerialize]
	public ControlOutput outputTrigger; //Field offset: 0x98
	[DoNotSerialize]
	public ValueInput cpuLevelInput; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueInput gpuLevelInput; //Field offset: 0xA8

	public SetPerformanceLevelsUnit() { }

	[CompilerGenerated]
	private ControlOutput <Definition>b__4_0(Flow flow) { }

	protected virtual void Definition() { }

}

