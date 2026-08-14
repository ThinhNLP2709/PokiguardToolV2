namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Divide")]
public sealed class Vector2Divide : Divide<Vector2>
{

	protected virtual Vector2 defaultDividend
	{
		 get { } //Length: 68
	}

	protected virtual Vector2 defaultDivisor
	{
		 get { } //Length: 68
	}

	public Vector2Divide() { }

	protected virtual Vector2 get_defaultDividend() { }

	protected virtual Vector2 get_defaultDivisor() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

