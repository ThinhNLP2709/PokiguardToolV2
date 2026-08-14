namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Thermal")]
[UnitShortTitle("Thermal Metric")]
[UnitSubtitle("Throttling and Thermal Info")]
public class GetThermalMetricUnit : Unit
{
	[CompilerGenerated]
	private ValueOutput <warningLevel>k__BackingField; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput throttlingImminent; //Field offset: 0x98
	[DoNotSerialize]
	public ValueOutput throttling; //Field offset: 0xA0
	[DoNotSerialize]
	public ValueOutput temperatureLevel; //Field offset: 0xA8
	[DoNotSerialize]
	public ValueOutput temperatureTrend; //Field offset: 0xB0
	private float TemperatureLevel; //Field offset: 0xB8
	private float TemperatureTrend; //Field offset: 0xBC
	private string WarningLevel; //Field offset: 0xC0
	private bool ThrottlingImminent; //Field offset: 0xC8
	private bool Throttling; //Field offset: 0xC9

	[DoNotSerialize]
	public private ValueOutput warningLevel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public GetThermalMetricUnit() { }

	[CompilerGenerated]
	private string <Definition>b__13_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__13_1(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__13_2(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__13_3(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__13_4(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_warningLevel() { }

	[CompilerGenerated]
	private void set_warningLevel(ValueOutput value) { }

	private void UpdateStats() { }

}

