namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Divide")]
public sealed class Vector3Divide : Divide<Vector3>
{

	protected virtual Vector3 defaultDividend
	{
		 get { } //Length: 74
	}

	protected virtual Vector3 defaultDivisor
	{
		 get { } //Length: 74
	}

	public Vector3Divide() { }

	protected virtual Vector3 get_defaultDividend() { }

	protected virtual Vector3 get_defaultDivisor() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

}

