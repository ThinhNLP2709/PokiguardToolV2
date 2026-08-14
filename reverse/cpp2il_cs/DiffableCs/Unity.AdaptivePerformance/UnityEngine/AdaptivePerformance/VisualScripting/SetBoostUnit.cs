namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Set Boost")]
[UnitSubtitle("Set CPU and GPU Boost")]
public class SetBoostUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger; //Field offset: 0x90
	[DoNotSerialize]
	public ControlOutput outputTrigger; //Field offset: 0x98
	[DoNotSerialize]
	public ValueInput cpuBoostInput; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueInput gpuBoostInput; //Field offset: 0xA8

	public SetBoostUnit() { }

	[CompilerGenerated]
	private ControlOutput <Definition>b__4_0(Flow flow) { }

	protected virtual void Definition() { }

}

