namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 4")]
[UnitTitle("Add")]
public sealed class Vector4Sum : Sum<Vector4>, IDefaultValue<Vector4>
{

	[DoNotSerialize]
	public override Vector4 defaultValue
	{
		 get { } //Length: 66
	}

	public Vector4Sum() { }

	public override Vector4 get_defaultValue() { }

	public virtual Vector4 Operation(Vector4 a, Vector4 b) { }

	public virtual Vector4 Operation(IEnumerable<Vector4> values) { }

}

