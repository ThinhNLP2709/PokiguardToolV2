namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Move Towards")]
public sealed class Vector2MoveTowards : MoveTowards<Vector2>
{

	protected virtual Vector2 defaultCurrent
	{
		 get { } //Length: 68
	}

	protected virtual Vector2 defaultTarget
	{
		 get { } //Length: 69
	}

	public Vector2MoveTowards() { }

	protected virtual Vector2 get_defaultCurrent() { }

	protected virtual Vector2 get_defaultTarget() { }

	public virtual Vector2 Operation(Vector2 current, Vector2 target, float maxDelta) { }

}

