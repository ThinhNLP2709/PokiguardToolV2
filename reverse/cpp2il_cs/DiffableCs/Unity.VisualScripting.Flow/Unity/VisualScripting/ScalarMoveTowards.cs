namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Move Towards")]
public sealed class ScalarMoveTowards : MoveTowards<Single>
{

	protected virtual float defaultCurrent
	{
		 get { } //Length: 4
	}

	protected virtual float defaultTarget
	{
		 get { } //Length: 9
	}

	public ScalarMoveTowards() { }

	protected virtual float get_defaultCurrent() { }

	protected virtual float get_defaultTarget() { }

	public virtual float Operation(float current, float target, float maxDelta) { }

}

