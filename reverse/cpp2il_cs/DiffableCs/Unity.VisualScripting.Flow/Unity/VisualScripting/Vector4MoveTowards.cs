namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Move Towards")]
public sealed class Vector4MoveTowards : MoveTowards<Vector4>
{

	protected virtual Vector4 defaultCurrent
	{
		 get { } //Length: 66
	}

	protected virtual Vector4 defaultTarget
	{
		 get { } //Length: 67
	}

	public Vector4MoveTowards() { }

	protected virtual Vector4 get_defaultCurrent() { }

	protected virtual Vector4 get_defaultTarget() { }

	public virtual Vector4 Operation(Vector4 current, Vector4 target, float maxDelta) { }

}

