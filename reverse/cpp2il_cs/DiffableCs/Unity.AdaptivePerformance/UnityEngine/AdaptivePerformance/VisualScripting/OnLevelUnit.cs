namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Scaler")]
[UnitShortTitle("On Level Scaler")]
[UnitSubtitle("Scaler level")]
public class OnLevelUnit : EventUnit<AdaptivePerformanceScalerEvent>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Flow, String> <>9__12_0; //Field offset: 0x8
		public static Func<Flow, Int32> <>9__12_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <Definition>b__12_0(Flow flow) { }

		internal int <Definition>b__12_1(Flow flow) { }

	}

	[CompilerGenerated]
	private ValueOutput <onScalerLevel>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <scalerLevel>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ValueOutput onScalerLevel
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

	[DoNotSerialize]
	public private ValueOutput scalerLevel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnLevelUnit() { }

	protected virtual void AssignArguments(Flow flow, AdaptivePerformanceScalerEvent scalerEvent) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_onScalerLevel() { }

	protected virtual bool get_register() { }

	[CompilerGenerated]
	public ValueOutput get_scalerLevel() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	[CompilerGenerated]
	private void set_onScalerLevel(ValueOutput value) { }

	[CompilerGenerated]
	private void set_scalerLevel(ValueOutput value) { }

}

