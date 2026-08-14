namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Thermal")]
[UnitShortTitle("On Thermal Metric")]
[UnitSubtitle("Throttling and Thermal Info")]
public class OnThermalMetricUnit : EventUnit<WarningLevel>
{
	[CompilerGenerated]
	private ValueOutput <warningLevel>k__BackingField; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput throttlingImminent; //Field offset: 0xA8
	[DoNotSerialize]
	public ValueOutput throttling; //Field offset: 0xB0
	private string WarningLevel; //Field offset: 0xB8
	private bool ThrottlingImminent; //Field offset: 0xC0
	private bool Throttling; //Field offset: 0xC1

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	public private ValueOutput warningLevel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnThermalMetricUnit() { }

	[CompilerGenerated]
	private string <Definition>b__13_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__13_1(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__13_2(Flow flow) { }

	protected virtual void AssignArguments(Flow flow, WarningLevel data) { }

	protected virtual void Definition() { }

	protected virtual bool get_register() { }

	[CompilerGenerated]
	public ValueOutput get_warningLevel() { }

	public virtual EventHook GetHook(GraphReference reference) { }

	[CompilerGenerated]
	private void set_warningLevel(ValueOutput value) { }

	private void UpdateStats() { }

}

