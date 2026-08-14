namespace DG.Tweening.Plugins.Options;

public struct Vector3ArrayOptions : IPlugOptions
{
	public AxisConstraint axisConstraint; //Field offset: 0x0
	public bool snapping; //Field offset: 0x4
	internal Single[] durations; //Field offset: 0x8

	public override void Reset() { }

}

