namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Lerp")]
public sealed class ScalarLerp : Lerp<Single>
{

	protected virtual float defaultA
	{
		 get { } //Length: 4
	}

	protected virtual float defaultB
	{
		 get { } //Length: 9
	}

	public ScalarLerp() { }

	protected virtual float get_defaultA() { }

	protected virtual float get_defaultB() { }

	public virtual float Operation(float a, float b, float t) { }

}

