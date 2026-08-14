namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Average")]
public sealed class Vector2Average : Average<Vector2>
{

	public Vector2Average() { }

	public virtual Vector2 Operation(IEnumerable<Vector2> values) { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

