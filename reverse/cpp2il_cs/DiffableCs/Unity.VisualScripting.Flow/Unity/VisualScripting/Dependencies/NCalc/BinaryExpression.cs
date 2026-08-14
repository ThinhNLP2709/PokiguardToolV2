namespace Unity.VisualScripting.Dependencies.NCalc;

public class BinaryExpression : LogicalExpression
{
	[CompilerGenerated]
	private LogicalExpression <LeftExpression>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private LogicalExpression <RightExpression>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private BinaryExpressionType <Type>k__BackingField; //Field offset: 0x20

	public LogicalExpression LeftExpression
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public LogicalExpression RightExpression
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public BinaryExpressionType Type
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public BinaryExpression(BinaryExpressionType type, LogicalExpression leftExpression, LogicalExpression rightExpression) { }

	public virtual void Accept(LogicalExpressionVisitor visitor) { }

	[CompilerGenerated]
	public LogicalExpression get_LeftExpression() { }

	[CompilerGenerated]
	public LogicalExpression get_RightExpression() { }

	[CompilerGenerated]
	public BinaryExpressionType get_Type() { }

	[CompilerGenerated]
	public void set_LeftExpression(LogicalExpression value) { }

	[CompilerGenerated]
	public void set_RightExpression(LogicalExpression value) { }

	[CompilerGenerated]
	public void set_Type(BinaryExpressionType value) { }

}

