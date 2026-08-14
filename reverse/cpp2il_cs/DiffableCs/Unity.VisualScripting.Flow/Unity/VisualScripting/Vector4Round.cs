namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Round")]
public sealed class Vector4Round : Round<Vector4, Vector4>
{

	public Vector4Round() { }

	protected virtual Vector4 AwayFromZero(Vector4 input) { }

	protected virtual Vector4 Ceiling(Vector4 input) { }

	protected virtual Vector4 Floor(Vector4 input) { }

}

