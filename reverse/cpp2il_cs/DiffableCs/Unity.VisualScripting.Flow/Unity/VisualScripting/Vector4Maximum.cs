namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Maximum")]
public sealed class Vector4Maximum : Maximum<Vector4>
{

	public Vector4Maximum() { }

	public virtual Vector4 Operation(IEnumerable<Vector4> values) { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

