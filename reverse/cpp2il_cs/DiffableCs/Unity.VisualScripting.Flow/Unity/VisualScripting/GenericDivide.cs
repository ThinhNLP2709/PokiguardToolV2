namespace Unity.VisualScripting;

[UnitCategory("Math/Generic")]
[UnitTitle("Divide")]
public sealed class GenericDivide : Divide<Object>
{

	public GenericDivide() { }

	public virtual object Operation(object a, object b) { }

}

