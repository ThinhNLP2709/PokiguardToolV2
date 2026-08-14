namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Subtract")]
public sealed class Vector3Subtract : Subtract<Vector3>
{

	protected virtual Vector3 defaultMinuend
	{
		 get { } //Length: 74
	}

	protected virtual Vector3 defaultSubtrahend
	{
		 get { } //Length: 74
	}

	public Vector3Subtract() { }

	protected virtual Vector3 get_defaultMinuend() { }

	protected virtual Vector3 get_defaultSubtrahend() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

