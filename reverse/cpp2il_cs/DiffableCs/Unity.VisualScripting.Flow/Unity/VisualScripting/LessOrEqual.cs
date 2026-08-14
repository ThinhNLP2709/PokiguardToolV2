namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(10)]
public sealed class LessOrEqual : BinaryComparisonUnit
{

	[PortLabel("A ≤ B")]
	public virtual ValueOutput comparison
	{
		 get { } //Length: 8
	}

	public LessOrEqual() { }

	protected virtual bool GenericComparison(object a, object b) { }

	public virtual ValueOutput get_comparison() { }

	protected virtual bool NumericComparison(float a, float b) { }

}

