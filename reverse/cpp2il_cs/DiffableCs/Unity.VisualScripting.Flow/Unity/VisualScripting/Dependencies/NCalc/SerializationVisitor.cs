namespace Unity.VisualScripting.Dependencies.NCalc;

public class SerializationVisitor : LogicalExpressionVisitor
{
	private readonly NumberFormatInfo _numberFormatInfo; //Field offset: 0x10
	[CompilerGenerated]
	private StringBuilder <Result>k__BackingField; //Field offset: 0x18

	public StringBuilder Result
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public SerializationVisitor() { }

	protected void EncapsulateNoValue(LogicalExpression expression) { }

	[CompilerGenerated]
	public StringBuilder get_Result() { }

	[CompilerGenerated]
	protected void set_Result(StringBuilder value) { }

	public virtual void Visit(TernaryExpression ternary) { }

	public virtual void Visit(BinaryExpression binary) { }

	public virtual void Visit(UnaryExpression unary) { }

	public virtual void Visit(ValueExpression value) { }

	public virtual void Visit(FunctionExpression function) { }

	public virtual void Visit(IdentifierExpression identifier) { }

}

