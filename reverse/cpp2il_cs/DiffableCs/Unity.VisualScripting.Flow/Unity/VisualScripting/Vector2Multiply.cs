namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Multiply")]
public sealed class Vector2Multiply : Multiply<Vector2>
{

	protected virtual Vector2 defaultB
	{
		 get { } //Length: 68
	}

	public Vector2Multiply() { }

	protected virtual Vector2 get_defaultB() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

