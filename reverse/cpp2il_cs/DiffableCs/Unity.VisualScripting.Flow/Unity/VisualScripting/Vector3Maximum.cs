namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Maximum")]
public sealed class Vector3Maximum : Maximum<Vector3>
{

	public Vector3Maximum() { }

	public virtual Vector3 Operation(IEnumerable<Vector3> values) { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

