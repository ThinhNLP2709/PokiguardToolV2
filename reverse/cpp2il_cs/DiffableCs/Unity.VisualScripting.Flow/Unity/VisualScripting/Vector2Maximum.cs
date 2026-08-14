namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Maximum")]
public sealed class Vector2Maximum : Maximum<Vector2>
{

	public Vector2Maximum() { }

	public virtual Vector2 Operation(IEnumerable<Vector2> values) { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

