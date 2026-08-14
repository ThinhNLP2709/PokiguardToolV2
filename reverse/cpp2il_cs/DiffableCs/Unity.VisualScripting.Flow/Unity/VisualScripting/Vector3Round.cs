namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Round")]
public sealed class Vector3Round : Round<Vector3, Vector3>
{

	public Vector3Round() { }

	protected virtual Vector3 AwayFromZero(Vector3 input) { }

	protected virtual Vector3 Ceiling(Vector3 input) { }

	protected virtual Vector3 Floor(Vector3 input) { }

}

