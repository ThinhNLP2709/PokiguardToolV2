namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Absolute")]
public sealed class Vector3Absolute : Absolute<Vector3>
{

	public Vector3Absolute() { }

	protected virtual Vector3 Operation(Vector3 input) { }

}

