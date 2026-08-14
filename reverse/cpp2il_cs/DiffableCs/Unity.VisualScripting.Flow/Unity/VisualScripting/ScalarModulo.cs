namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Modulo")]
public sealed class ScalarModulo : Modulo<Single>
{

	protected virtual float defaultDividend
	{
		 get { } //Length: 9
	}

	protected virtual float defaultDivisor
	{
		 get { } //Length: 9
	}

	public ScalarModulo() { }

	protected virtual float get_defaultDividend() { }

	protected virtual float get_defaultDivisor() { }

	public virtual float Operation(float a, float b) { }

}

