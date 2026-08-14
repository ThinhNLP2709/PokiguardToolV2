namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Absolute")]
public sealed class ScalarAbsolute : Absolute<Single>
{

	public ScalarAbsolute() { }

	protected virtual float Operation(float input) { }

}

