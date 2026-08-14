namespace Unity.VisualScripting.Dependencies.NCalc;

public class UnaryExpression : LogicalExpression
{
	[CompilerGenerated]
	private LogicalExpression <Expression>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private UnaryExpressionType <Type>k__BackingField; //Field offset: 0x18

	public LogicalExpression Expression
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public UnaryExpressionType Type
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public UnaryExpression(UnaryExpressionType type, LogicalExpression expression) { }

	public virtual void Accept(LogicalExpressionVisitor visitor) { }

	[CompilerGenerated]
	public LogicalExpression get_Expression() { }

	[CompilerGenerated]
	public UnaryExpressionType get_Type() { }

	[CompilerGenerated]
	public void set_Expression(LogicalExpression value) { }

	[CompilerGenerated]
	public void set_Type(UnaryExpressionType value) { }

}

