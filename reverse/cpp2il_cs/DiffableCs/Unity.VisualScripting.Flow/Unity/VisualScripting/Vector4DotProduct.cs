namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Dot Product")]
public sealed class Vector4DotProduct : DotProduct<Vector4>
{

	public Vector4DotProduct() { }

	public virtual float Operation(Vector4 a, Vector4 b) { }

}

