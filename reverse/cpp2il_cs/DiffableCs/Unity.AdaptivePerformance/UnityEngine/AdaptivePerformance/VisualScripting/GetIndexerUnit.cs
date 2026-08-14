namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Scaler")]
[UnitShortTitle("Get Indexer Data")]
[UnitSubtitle("Performance and Thermal Actions")]
public class GetIndexerUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput performanceAction; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput thermalAction; //Field offset: 0x98
	[DoNotSerialize]
	public ValueOutput timeUntilNextAction; //Field offset: 0xA0
	private StateAction PerformanceAction; //Field offset: 0xA8
	private StateAction ThermalAction; //Field offset: 0xAC
	private float TimeUntilNextAction; //Field offset: 0xB0

	public GetIndexerUnit() { }

	[CompilerGenerated]
	private StateAction <Definition>b__6_0(Flow flow) { }

	[CompilerGenerated]
	private StateAction <Definition>b__6_1(Flow flow) { }

	[CompilerGenerated]
	private float <Definition>b__6_2(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

