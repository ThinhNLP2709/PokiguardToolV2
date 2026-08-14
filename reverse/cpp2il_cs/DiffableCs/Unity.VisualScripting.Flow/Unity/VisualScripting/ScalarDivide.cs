namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Divide")]
public sealed class ScalarDivide : Divide<Single>
{

	protected virtual float defaultDividend
	{
		 get { } //Length: 9
	}

	protected virtual float defaultDivisor
	{
		 get { } //Length: 9
	}

	public ScalarDivide() { }

	protected virtual float get_defaultDividend() { }

	protected virtual float get_defaultDivisor() { }

	public virtual float Operation(float a, float b) { }

}

