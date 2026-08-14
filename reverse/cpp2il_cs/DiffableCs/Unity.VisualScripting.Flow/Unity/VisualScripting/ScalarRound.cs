namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitTitle("Round")]
public sealed class ScalarRound : Round<Single, Int32>
{

	public ScalarRound() { }

	protected virtual int AwayFromZero(float input) { }

	protected virtual int Ceiling(float input) { }

	protected virtual int Floor(float input) { }

}

