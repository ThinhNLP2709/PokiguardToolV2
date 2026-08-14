namespace Unity.VisualScripting;

[Extension]
public static class OperatorUtility
{
	public static readonly Dictionary<String, String> operatorNames; //Field offset: 0x0
	public static readonly Dictionary<String, Int32> operatorRanks; //Field offset: 0x8
	private static readonly Dictionary<UnaryOperator, UnaryOperatorHandler> unaryOperatorHandlers; //Field offset: 0x10
	private static readonly Dictionary<BinaryOperator, BinaryOperatorHandler> binaryOpeatorHandlers; //Field offset: 0x18
	private static readonly LogicalNegationHandler logicalNegationHandler; //Field offset: 0x20
	private static readonly NumericNegationHandler numericNegationHandler; //Field offset: 0x28
	private static readonly IncrementHandler incrementHandler; //Field offset: 0x30
	private static readonly DecrementHandler decrementHandler; //Field offset: 0x38
	private static readonly PlusHandler plusHandler; //Field offset: 0x40
	private static readonly AdditionHandler additionHandler; //Field offset: 0x48
	private static readonly SubtractionHandler subtractionHandler; //Field offset: 0x50
	private static readonly MultiplicationHandler multiplicationHandler; //Field offset: 0x58
	private static readonly DivisionHandler divisionHandler; //Field offset: 0x60
	private static readonly ModuloHandler moduloHandler; //Field offset: 0x68
	private static readonly AndHandler andHandler; //Field offset: 0x70
	private static readonly OrHandler orHandler; //Field offset: 0x78
	private static readonly ExclusiveOrHandler exclusiveOrHandler; //Field offset: 0x80
	private static readonly EqualityHandler equalityHandler; //Field offset: 0x88
	private static readonly InequalityHandler inequalityHandler; //Field offset: 0x90
	private static readonly GreaterThanHandler greaterThanHandler; //Field offset: 0x98
	private static readonly LessThanHandler lessThanHandler; //Field offset: 0xA0
	private static readonly GreaterThanOrEqualHandler greaterThanOrEqualHandler; //Field offset: 0xA8
	private static readonly LessThanOrEqualHandler lessThanOrEqualHandler; //Field offset: 0xB0
	private static readonly LeftShiftHandler leftShiftHandler; //Field offset: 0xB8
	private static readonly RightShiftHandler rightShiftHandler; //Field offset: 0xC0

	private static OperatorUtility() { }

	public static object Add(object a, object b) { }

	public static object And(object a, object b) { }

	public static object Decrement(object x) { }

	public static object Divide(object a, object b) { }

	public static bool Equal(object a, object b) { }

	public static object ExclusiveOr(object a, object b) { }

	public static UnaryOperatorHandler GetHandler(UnaryOperator operator) { }

	public static BinaryOperatorHandler GetHandler(BinaryOperator operator) { }

	public static bool GreaterThan(object a, object b) { }

	public static bool GreaterThanOrEqual(object a, object b) { }

	public static object Increment(object x) { }

	public static object LeftShift(object a, object b) { }

	public static bool LessThan(object a, object b) { }

	public static bool LessThanOrEqual(object a, object b) { }

	public static object Modulo(object a, object b) { }

	public static object Multiply(object a, object b) { }

	[Extension]
	public static string Name(BinaryOperator operator) { }

	[Extension]
	public static string Name(UnaryOperator operator) { }

	public static object Negate(object x) { }

	public static object Not(object x) { }

	public static bool NotEqual(object a, object b) { }

	public static object Operate(BinaryOperator operator, object a, object b) { }

	public static object Operate(UnaryOperator operator, object x) { }

	public static object Or(object a, object b) { }

	public static object RightShift(object a, object b) { }

	public static object Subtract(object a, object b) { }

	[Extension]
	public static string Symbol(UnaryOperator operator) { }

	[Extension]
	public static string Symbol(BinaryOperator operator) { }

	public static object UnaryPlus(object x) { }

	[Extension]
	public static string Verb(BinaryOperator operator) { }

	[Extension]
	public static string Verb(UnaryOperator operator) { }

}

