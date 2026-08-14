namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Per Second")]
public sealed class ScalarPerSecond : PerSecond<Single>
{

	public ScalarPerSecond() { }

	public virtual float Operation(float input) { }

}

