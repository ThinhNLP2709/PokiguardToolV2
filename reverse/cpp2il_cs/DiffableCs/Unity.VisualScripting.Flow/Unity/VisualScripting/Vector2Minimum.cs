namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Minimum")]
public sealed class Vector2Minimum : Minimum<Vector2>
{

	public Vector2Minimum() { }

	public virtual Vector2 Operation(IEnumerable<Vector2> values) { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

