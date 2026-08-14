namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("On CPU/GPU Boosted")]
[UnitSubtitle("CPU and GPU Boost Event")]
public class OnBoostUnit : EventUnit<PerformanceBoostChangeEventArgs>
{
	[DoNotSerialize]
	public ValueOutput cpuBoost; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput gpuBoost; //Field offset: 0xA8
	private bool CpuBoost; //Field offset: 0xB0
	private bool GpuBoost; //Field offset: 0xB1

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	public OnBoostUnit() { }

	[CompilerGenerated]
	private bool <Definition>b__8_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__8_1(Flow flow) { }

	protected virtual void AssignArguments(Flow flow, PerformanceBoostChangeEventArgs data) { }

	protected virtual void Definition() { }

	protected virtual bool get_register() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	private void UpdateStats() { }

}

