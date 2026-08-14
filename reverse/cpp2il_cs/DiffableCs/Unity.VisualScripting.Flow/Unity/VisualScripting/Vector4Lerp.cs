namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Lerp")]
public sealed class Vector4Lerp : Lerp<Vector4>
{

	protected virtual Vector4 defaultA
	{
		 get { } //Length: 66
	}

	protected virtual Vector4 defaultB
	{
		 get { } //Length: 67
	}

	public Vector4Lerp() { }

	protected virtual Vector4 get_defaultA() { }

	protected virtual Vector4 get_defaultB() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b, float t) { }

}

