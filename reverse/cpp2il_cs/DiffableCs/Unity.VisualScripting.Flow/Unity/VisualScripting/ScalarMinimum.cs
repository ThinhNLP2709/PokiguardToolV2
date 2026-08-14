namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Minimum")]
public sealed class ScalarMinimum : Minimum<Single>
{

	public ScalarMinimum() { }

	public virtual float Operation(IEnumerable<Single> values) { }

	public virtual float Operation(float a, float b) { }

}

