namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Average")]
public sealed class Vector3Average : Average<Vector3>
{

	public Vector3Average() { }

	public virtual Vector3 Operation(IEnumerable<Vector3> values) { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

