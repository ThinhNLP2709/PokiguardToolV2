namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Frame Timing")]
[UnitSubtitle("Frame Time Metric")]
public class FrameTimingUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput currentFrameTime; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput averageFrameTime; //Field offset: 0x98
	[DoNotSerialize]
	public ValueOutput currentGpuFrameTime; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput averageGpuFrameTime; //Field offset: 0xA8
	[DoNotSerialize]
	public ValueOutput currentCpuFrameTime; //Field offset: 0xB0
	[DoNotSerialize]
	public ValueOutput averageCpuFrameTime; //Field offset: 0xB8
	private float CurrentFrameTime; //Field offset: 0xC0
	private float AverageFrameTime; //Field offset: 0xC4
	private float CurrentGpuFrameTime; //Field offset: 0xC8
	private float AverageGpuFrameTime; //Field offset: 0xCC
	private float CurrentCpuFrameTime; //Field offset: 0xD0
	private float AverageCpuFrameTime; //Field offset: 0xD4

	public FrameTimingUnit() { }

	[CompilerGenerated]
	private float <Definition>b__12_0(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__12_1(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__12_2(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__12_3(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__12_4(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__12_5(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

