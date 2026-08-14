namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Modulo")]
public sealed class Vector2Modulo : Modulo<Vector2>
{

	protected virtual Vector2 defaultDividend
	{
		 get { } //Length: 68
	}

	protected virtual Vector2 defaultDivisor
	{
		 get { } //Length: 68
	}

	public Vector2Modulo() { }

	protected virtual Vector2 get_defaultDividend() { }

	protected virtual Vector2 get_defaultDivisor() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

