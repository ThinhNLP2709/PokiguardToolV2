namespace UnityEngine.AdaptivePerformance.VisualScripting;

[UnitCategory("AdaptivePerformance/Performance")]
[UnitShortTitle("FPS")]
[UnitSubtitle("Frames Per Seconnd")]
public class FPSUnit : Unit
{
	[DoNotSerialize]
	public ValueOutput fps; //Field offset: 0x90
	private int FPS; //Field offset: 0x98

	public FPSUnit() { }

	[CompilerGenerated]
	private float <Definition>b__2_0(Flow flow) { }

	protected virtual void Definition() { }

	private void UpdateStats() { }

}

