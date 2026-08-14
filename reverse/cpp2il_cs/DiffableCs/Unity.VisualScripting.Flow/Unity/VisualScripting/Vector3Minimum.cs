namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Minimum")]
public sealed class Vector3Minimum : Minimum<Vector3>
{

	public Vector3Minimum() { }

	public virtual Vector3 Operation(IEnumerable<Vector3> values) { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

