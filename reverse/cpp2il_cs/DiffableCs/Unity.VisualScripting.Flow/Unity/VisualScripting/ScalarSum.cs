namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Add")]
public sealed class ScalarSum : Sum<Single>, IDefaultValue<Single>
{

	[DoNotSerialize]
	public override float defaultValue
	{
		 get { } //Length: 9
	}

	public ScalarSum() { }

	public override float get_defaultValue() { }

	public virtual float Operation(float a, float b) { }

	public virtual float Operation(IEnumerable<Single> values) { }

}

