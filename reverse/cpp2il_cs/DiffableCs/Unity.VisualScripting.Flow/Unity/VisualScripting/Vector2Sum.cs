namespace Unity.VisualScripting;

[UnitCategory("Math/Vector 2")]
[UnitTitle("Add")]
public sealed class Vector2Sum : Sum<Vector2>, IDefaultValue<Vector2>
{

	[DoNotSerialize]
	public override Vector2 defaultValue
	{
		 get { } //Length: 68
	}

	public Vector2Sum() { }

	public override Vector2 get_defaultValue() { }

	public virtual Vector2 Operation(Vector2 a, Vector2 b) { }

	public virtual Vector2 Operation(IEnumerable<Vector2> values) { }

}

