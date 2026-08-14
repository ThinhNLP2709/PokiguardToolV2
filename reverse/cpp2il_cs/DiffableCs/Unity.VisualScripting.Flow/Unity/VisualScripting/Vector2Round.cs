namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Round")]
public sealed class Vector2Round : Round<Vector2, Vector2>
{

	public Vector2Round() { }

	protected virtual Vector2 AwayFromZero(Vector2 input) { }

	protected virtual Vector2 Ceiling(Vector2 input) { }

	protected virtual Vector2 Floor(Vector2 input) { }

}

