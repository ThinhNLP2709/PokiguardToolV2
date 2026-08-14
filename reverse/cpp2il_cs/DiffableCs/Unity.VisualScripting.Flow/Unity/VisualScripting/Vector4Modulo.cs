namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Modulo")]
public sealed class Vector4Modulo : Modulo<Vector4>
{

	protected virtual Vector4 defaultDividend
	{
		 get { } //Length: 66
	}

	protected virtual Vector4 defaultDivisor
	{
		 get { } //Length: 66
	}

	public Vector4Modulo() { }

	protected virtual Vector4 get_defaultDividend() { }

	protected virtual Vector4 get_defaultDivisor() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

