namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Subtract")]
public sealed class Vector4Subtract : Subtract<Vector4>
{

	protected virtual Vector4 defaultMinuend
	{
		 get { } //Length: 66
	}

	protected virtual Vector4 defaultSubtrahend
	{
		 get { } //Length: 66
	}

	public Vector4Subtract() { }

	protected virtual Vector4 get_defaultMinuend() { }

	protected virtual Vector4 get_defaultSubtrahend() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

}

