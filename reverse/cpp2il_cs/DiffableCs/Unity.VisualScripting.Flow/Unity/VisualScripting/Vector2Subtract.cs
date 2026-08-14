namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Subtract")]
public sealed class Vector2Subtract : Subtract<Vector2>
{

	protected virtual Vector2 defaultMinuend
	{
		 get { } //Length: 68
	}

	protected virtual Vector2 defaultSubtrahend
	{
		 get { } //Length: 68
	}

	public Vector2Subtract() { }

	protected virtual Vector2 get_defaultMinuend() { }

	protected virtual Vector2 get_defaultSubtrahend() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

}

