namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Normalize")]
public sealed class ScalarNormalize : Normalize<Single>
{

	public ScalarNormalize() { }

	public virtual float Operation(float input) { }

}

