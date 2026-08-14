namespace Unity.VisualScripting;

[UnitCategory("Math/Generic")]
[UnitTitle("Add")]
public sealed class GenericSum : Sum<Object>
{

	public GenericSum() { }

	public virtual object Operation(IEnumerable<Object> values) { }

	public virtual object Operation(object a, object b) { }

}

