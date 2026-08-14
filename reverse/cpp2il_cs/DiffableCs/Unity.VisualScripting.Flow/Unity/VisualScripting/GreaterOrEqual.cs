namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(12)]
public sealed class GreaterOrEqual : BinaryComparisonUnit
{

	[PortLabel("A ≥ B")]
	public virtual ValueOutput comparison
	{
		 get { } //Length: 8
	}

	public GreaterOrEqual() { }

	protected virtual bool GenericComparison(object a, object b) { }

	public virtual ValueOutput get_comparison() { }

	protected virtual bool NumericComparison(float a, float b) { }

}

