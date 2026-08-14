namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("On Bottleneck")]
[UnitSubtitle("CPU, GPU, TargetFrameRate bottleneck")]
public class OnBottleneckUnit : EventUnit<PerformanceBottleneck>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Flow, String> <>9__11_0; //Field offset: 0x8
		public static Func<Flow, Boolean> <>9__11_1; //Field offset: 0x10
		public static Func<Flow, Boolean> <>9__11_2; //Field offset: 0x18
		public static Func<Flow, Boolean> <>9__11_3; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal string <Definition>b__11_0(Flow flow) { }

		internal bool <Definition>b__11_1(Flow flow) { }

		internal bool <Definition>b__11_2(Flow flow) { }

		internal bool <Definition>b__11_3(Flow flow) { }

	}

	[CompilerGenerated]
	private ValueOutput <bottleneck>k__BackingField; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput cpu; //Field offset: 0xA8
	[DoNotSerialize]
	public ValueOutput gpu; //Field offset: 0xB0
	[DoNotSerialize]
	public ValueOutput targetFrameRate; //Field offset: 0xB8

	[DoNotSerialize]
	public private ValueOutput bottleneck
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	public OnBottleneckUnit() { }

	protected virtual void AssignArguments(Flow flow, PerformanceBottleneck data) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_bottleneck() { }

	protected virtual bool get_register() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	[CompilerGenerated]
	private void set_bottleneck(ValueOutput value) { }

}

