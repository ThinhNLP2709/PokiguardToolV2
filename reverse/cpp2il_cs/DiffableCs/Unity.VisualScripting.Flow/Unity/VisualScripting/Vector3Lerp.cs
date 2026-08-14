namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Lerp")]
public sealed class Vector3Lerp : Lerp<Vector3>
{

	protected virtual Vector3 defaultA
	{
		 get { } //Length: 74
	}

	protected virtual Vector3 defaultB
	{
		 get { } //Length: 75
	}

	public Vector3Lerp() { }

	protected virtual Vector3 get_defaultA() { }

	protected virtual Vector3 get_defaultB() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b, float t) { }

}

