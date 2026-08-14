namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Multiply")]
public sealed class Vector3Multiply : Multiply<Vector3>
{

	protected virtual Vector3 defaultB
	{
		 get { } //Length: 74
	}

	public Vector3Multiply() { }

	protected virtual Vector3 get_defaultB() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

