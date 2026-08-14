namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Subtract")]
public sealed class ScalarSubtract : Subtract<Single>
{

	protected virtual float defaultMinuend
	{
		 get { } //Length: 9
	}

	protected virtual float defaultSubtrahend
	{
		 get { } //Length: 9
	}

	public ScalarSubtract() { }

	protected virtual float get_defaultMinuend() { }

	protected virtual float get_defaultSubtrahend() { }

	public virtual float Operation(float a, float b) { }

}

