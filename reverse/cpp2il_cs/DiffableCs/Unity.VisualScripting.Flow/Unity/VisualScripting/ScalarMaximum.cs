namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Maximum")]
public sealed class ScalarMaximum : Maximum<Single>
{

	public ScalarMaximum() { }

	public virtual float Operation(IEnumerable<Single> values) { }

	public virtual float Operation(float a, float b) { }

}

