namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Multiply")]
public sealed class ScalarMultiply : Multiply<Single>
{

	protected virtual float defaultB
	{
		 get { } //Length: 9
	}

	public ScalarMultiply() { }

	protected virtual float get_defaultB() { }

	public virtual float Operation(float a, float b) { }

}

