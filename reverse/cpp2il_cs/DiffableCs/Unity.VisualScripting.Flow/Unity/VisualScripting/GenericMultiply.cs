namespace Unity.VisualScripting;

[UnitCategory("Math/Generic")]
[UnitTitle("Multiply")]
public sealed class GenericMultiply : Multiply<Object>
{

	public GenericMultiply() { }

	public virtual object Operation(object a, object b) { }

}

