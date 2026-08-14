namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Get Performance Levels")]
[UnitSubtitle("CPU and GPU Levels")]
public class GetPerformanceLevelsUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput cpuLevel; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput gpuLevel; //Field offset: 0x98
	private int CpuLevel; //Field offset: 0xA0
	private int GpuLevel; //Field offset: 0xA4

	public GetPerformanceLevelsUnit() { }

	[CompilerGenerated]
	private int <Definition>b__4_0(Flow flow) { }

	[CompilerGenerated]
	private int <Definition>b__4_1(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

