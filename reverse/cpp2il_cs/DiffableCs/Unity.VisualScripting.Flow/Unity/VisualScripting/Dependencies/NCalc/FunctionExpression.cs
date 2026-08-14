namespace Unity.VisualScripting.Dependencies.NCalc;

public class FunctionExpression : LogicalExpression
{
	[CompilerGenerated]
	private IdentifierExpression <Identifier>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private LogicalExpression[] <Expressions>k__BackingField; //Field offset: 0x18

	public LogicalExpression[] Expressions
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public IdentifierExpression Identifier
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public FunctionExpression(IdentifierExpression identifier, LogicalExpression[] expressions) { }

	public virtual void Accept(LogicalExpressionVisitor visitor) { }

	[CompilerGenerated]
	public LogicalExpression[] get_Expressions() { }

	[CompilerGenerated]
	public IdentifierExpression get_Identifier() { }

	[CompilerGenerated]
	public void set_Expressions(LogicalExpression[] value) { }

	[CompilerGenerated]
	public void set_Identifier(IdentifierExpression value) { }

}

