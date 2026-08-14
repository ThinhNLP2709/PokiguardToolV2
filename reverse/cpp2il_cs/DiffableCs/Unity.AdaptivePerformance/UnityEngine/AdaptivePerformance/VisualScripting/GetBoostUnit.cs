namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Get Boost")]
[UnitSubtitle("Get CPU and GPU Boost")]
public class GetBoostUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput cpuBoost; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput gpuBoost; //Field offset: 0x98
	private bool CpuBoost; //Field offset: 0xA0
	private bool GpuBoost; //Field offset: 0xA1

	public GetBoostUnit() { }

	[CompilerGenerated]
	private bool <Definition>b__4_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__4_1(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

