namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(6)]
public sealed class NotEqual : BinaryComparisonUnit
{

	[DoNotSerialize]
	[PortKey("notEqual")]
	[PortLabel("A ≠ B")]
	public virtual ValueOutput comparison
	{
		 get { } //Length: 8
	}

	protected virtual string outputKey
	{
		 get { } //Length: 44
	}

	public NotEqual() { }

	protected virtual bool GenericComparison(object a, object b) { }

	public virtual ValueOutput get_comparison() { }

	protected virtual string get_outputKey() { }

	protected virtual bool NumericComparison(float a, float b) { }

}

