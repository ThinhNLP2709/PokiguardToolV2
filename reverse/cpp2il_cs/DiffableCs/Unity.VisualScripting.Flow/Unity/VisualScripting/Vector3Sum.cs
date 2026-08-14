namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 3")]
[UnitTitle("Add")]
public sealed class Vector3Sum : Sum<Vector3>, IDefaultValue<Vector3>
{

	[DoNotSerialize]
	public override Vector3 defaultValue
	{
		 get { } //Length: 74
	}

	public Vector3Sum() { }

	public override Vector3 get_defaultValue() { }

	public virtual Vector3 Operation(Vector3 a, Vector3 b) { }

	public virtual Vector3 Operation(IEnumerable<Vector3> values) { }

}

