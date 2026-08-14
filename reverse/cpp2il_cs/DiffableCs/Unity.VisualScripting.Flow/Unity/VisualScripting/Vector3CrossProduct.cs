namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Cross Product")]
public sealed class Vector3CrossProduct : CrossProduct<Vector3>
{

	public Vector3CrossProduct() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

