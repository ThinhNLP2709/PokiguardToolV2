namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Dot Product")]
public sealed class Vector2DotProduct : DotProduct<Vector2>
{

	public Vector2DotProduct() { }

	public virtual float Operation(Vector2 a, Vector2 b) { }

}

