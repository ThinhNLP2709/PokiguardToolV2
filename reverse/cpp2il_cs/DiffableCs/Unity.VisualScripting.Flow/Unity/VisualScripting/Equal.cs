namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(5)]
public sealed class Equal : BinaryComparisonUnit
{

	[DoNotSerialize]
	[PortKey("equal")]
	[PortLabel("A = B")]
	public virtual ValueOutput comparison
	{
		 get { } //Length: 8
	}

	protected virtual string outputKey
	{
		 get { } //Length: 44
	}

	public Equal() { }

	protected virtual bool GenericComparison(object a, object b) { }

	public virtual ValueOutput get_comparison() { }

	protected virtual string get_outputKey() { }

	protected virtual bool NumericComparison(float a, float b) { }

}

