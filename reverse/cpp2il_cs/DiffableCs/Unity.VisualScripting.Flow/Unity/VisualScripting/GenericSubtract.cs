namespace Unity.VisualScripting;

[UnitCategory("Math/Generic")]
[UnitTitle("Subtract")]
public sealed class GenericSubtract : Subtract<Object>
{

	public GenericSubtract() { }

	public virtual object Operation(object a, object b) { }

}

