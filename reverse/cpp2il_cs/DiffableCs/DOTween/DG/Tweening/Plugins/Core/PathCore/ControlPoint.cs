namespace DG.Tweening.Plugins.Core.PathCore;

public struct ControlPoint
{
	public Vector3 a; //Field offset: 0x0
	public Vector3 b; //Field offset: 0xC

	public ControlPoint(Vector3 a, Vector3 b) { }

	public static ControlPoint op_Addition(ControlPoint cp, Vector3 v) { }

	public virtual string ToString() { }

}

