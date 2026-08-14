namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Average")]
public sealed class ScalarAverage : Average<Single>
{

	public ScalarAverage() { }

	public virtual float Operation(IEnumerable<Single> values) { }

	public virtual float Operation(float a, float b) { }

}

