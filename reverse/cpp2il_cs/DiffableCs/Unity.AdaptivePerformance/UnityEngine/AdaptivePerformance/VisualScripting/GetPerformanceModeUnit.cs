namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Get Performance Mode")]
[UnitSubtitle("Performance Mode")]
public class GetPerformanceModeUnit : Unit
{
	[CompilerGenerated]
	private ValueOutput <PerformanceMode>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueOutput <IsStandard>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <IsBattery>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <IsOptimize>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <IsCpu>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <IsGpu>k__BackingField; //Field offset: 0xB8
	private string m_PerformanceMode; //Field offset: 0xC0
	private bool m_IsStandard; //Field offset: 0xC8
	private bool m_IsBattery; //Field offset: 0xC9
	private bool m_IsOptimize; //Field offset: 0xCA
	private bool m_IsCpu; //Field offset: 0xCB
	private bool m_IsGpu; //Field offset: 0xCC

	[DoNotSerialize]
	public private ValueOutput IsBattery
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput IsCpu
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput IsGpu
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput IsOptimize
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput IsStandard
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput PerformanceMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public GetPerformanceModeUnit() { }

	[CompilerGenerated]
	private string <Definition>b__30_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__30_1(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__30_2(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__30_3(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__30_4(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__30_5(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_IsBattery() { }

	[CompilerGenerated]
	public ValueOutput get_IsCpu() { }

	[CompilerGenerated]
	public ValueOutput get_IsGpu() { }

	[CompilerGenerated]
	public ValueOutput get_IsOptimize() { }

	[CompilerGenerated]
	public ValueOutput get_IsStandard() { }

	[CompilerGenerated]
	public ValueOutput get_PerformanceMode() { }

	[CompilerGenerated]
	private void set_IsBattery(ValueOutput value) { }

	[CompilerGenerated]
	private void set_IsCpu(ValueOutput value) { }

	[CompilerGenerated]
	private void set_IsGpu(ValueOutput value) { }

	[CompilerGenerated]
	private void set_IsOptimize(ValueOutput value) { }

	[CompilerGenerated]
	private void set_IsStandard(ValueOutput value) { }

	[CompilerGenerated]
	private void set_PerformanceMode(ValueOutput value) { }

	private void UpdateStats() { }

}

