namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Minimum")]
public sealed class Vector4Minimum : Minimum<Vector4>
{

	public Vector4Minimum() { }

	public virtual Vector4 Operation(IEnumerable<Vector4> values) { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

