namespace Unity.VisualScripting.Dependencies.NCalc;

public abstract class LogicalExpression
{
	private const char BS = '\u5C'; //Field offset: 0x0

	protected LogicalExpression() { }

	public override void Accept(LogicalExpressionVisitor visitor) { }

	public BinaryExpression And(LogicalExpression operand) { }

	public BinaryExpression And(object operand) { }

	public BinaryExpression BitwiseAnd(LogicalExpression operand) { }

	public BinaryExpression BitwiseAnd(object operand) { }

	public BinaryExpression BitwiseOr(object operand) { }

	public BinaryExpression BitwiseOr(LogicalExpression operand) { }

	public BinaryExpression BitwiseXOr(LogicalExpression operand) { }

	public BinaryExpression BitwiseXOr(object operand) { }

	public BinaryExpression DividedBy(LogicalExpression operand) { }

	public BinaryExpression DividedBy(object operand) { }

	public BinaryExpression EqualsTo(LogicalExpression operand) { }

	public BinaryExpression EqualsTo(object operand) { }

	private static string ExtractString(string text) { }

	public BinaryExpression GreaterOrEqualThan(LogicalExpression operand) { }

	public BinaryExpression GreaterOrEqualThan(object operand) { }

	public BinaryExpression GreaterThan(LogicalExpression operand) { }

	public BinaryExpression GreaterThan(object operand) { }

	public BinaryExpression LeftShift(LogicalExpression operand) { }

	public BinaryExpression LeftShift(object operand) { }

	public BinaryExpression LesserOrEqualThan(LogicalExpression operand) { }

	public BinaryExpression LesserOrEqualThan(object operand) { }

	public BinaryExpression LesserThan(LogicalExpression operand) { }

	public BinaryExpression LesserThan(object operand) { }

	public BinaryExpression Minus(object operand) { }

	public BinaryExpression Minus(LogicalExpression operand) { }

	public BinaryExpression Modulo(object operand) { }

	public BinaryExpression Modulo(LogicalExpression operand) { }

	public BinaryExpression Mult(LogicalExpression operand) { }

	public BinaryExpression Mult(object operand) { }

	public BinaryExpression NotEqual(object operand) { }

	public BinaryExpression NotEqual(LogicalExpression operand) { }

	public BinaryExpression Or(LogicalExpression operand) { }

	public BinaryExpression Or(object operand) { }

	public BinaryExpression Plus(LogicalExpression operand) { }

	public BinaryExpression Plus(object operand) { }

	public BinaryExpression RightShift(LogicalExpression operand) { }

	public BinaryExpression RightShift(object operand) { }

	public virtual string ToString() { }

}

