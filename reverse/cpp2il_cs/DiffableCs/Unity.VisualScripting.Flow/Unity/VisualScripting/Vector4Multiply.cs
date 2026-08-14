namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Multiply")]
public sealed class Vector4Multiply : Multiply<Vector4>
{

	protected virtual Vector4 defaultB
	{
		 get { } //Length: 66
	}

	public Vector4Multiply() { }

	protected virtual Vector4 get_defaultB() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

