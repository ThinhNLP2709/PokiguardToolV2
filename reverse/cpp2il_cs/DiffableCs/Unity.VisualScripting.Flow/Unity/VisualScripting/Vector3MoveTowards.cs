namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Move Towards")]
public sealed class Vector3MoveTowards : MoveTowards<Vector3>
{

	protected virtual Vector3 defaultCurrent
	{
		 get { } //Length: 74
	}

	protected virtual Vector3 defaultTarget
	{
		 get { } //Length: 75
	}

	public Vector3MoveTowards() { }

	protected virtual Vector3 get_defaultCurrent() { }

	protected virtual Vector3 get_defaultTarget() { }

	public virtual Vector3 Operation(Vector3 current, Vector3 target, float maxDelta) { }

}

