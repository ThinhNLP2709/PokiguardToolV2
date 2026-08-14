namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("Cluster Info")]
[UnitSubtitle("CPU Core Cluster")]
public class ClusterInfoUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput bigCore; //Field offset: 0x90
	[DoNotSerialize]
	public ValueOutput mediumCore; //Field offset: 0x98
	[DoNotSerialize]
	public ValueOutput littleCore; //Field offset: 0xA0
	private int BigCore; //Field offset: 0xA8
	private int MediumCore; //Field offset: 0xAC
	private int LittleCore; //Field offset: 0xB0

	public ClusterInfoUnit() { }

	[CompilerGenerated]
	private int <Definition>b__6_0(Flow flow) { }

	[CompilerGenerated]
	private int <Definition>b__6_1(Flow flow) { }

	[CompilerGenerated]
	private int <Definition>b__6_2(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

