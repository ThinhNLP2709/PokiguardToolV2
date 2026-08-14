namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Distance")]
public sealed class Vector3Distance : Distance<Vector3>
{

	public Vector3Distance() { }

	public virtual float Operation(Vector3 a, Vector3 b) { }

}

