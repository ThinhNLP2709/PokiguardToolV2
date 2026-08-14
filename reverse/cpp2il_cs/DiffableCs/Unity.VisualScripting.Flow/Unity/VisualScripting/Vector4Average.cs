namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Average")]
public sealed class Vector4Average : Average<Vector4>
{

	public Vector4Average() { }

	public virtual Vector4 Operation(IEnumerable<Vector4> values) { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

