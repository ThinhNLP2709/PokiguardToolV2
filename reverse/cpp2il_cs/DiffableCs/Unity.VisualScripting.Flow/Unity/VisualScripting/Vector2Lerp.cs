namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Lerp")]
public sealed class Vector2Lerp : Lerp<Vector2>
{

	protected virtual Vector2 defaultA
	{
		 get { } //Length: 68
	}

	protected virtual Vector2 defaultB
	{
		 get { } //Length: 69
	}

	public Vector2Lerp() { }

	protected virtual Vector2 get_defaultA() { }

	protected virtual Vector2 get_defaultB() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b, float t) { }

}

