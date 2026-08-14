namespace Unity.VisualScripting;

public abstract class BinaryOperatorHandler : OperatorHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Func<TLeft, TRight, Object> handler; //Field offset: 0x0

		public <>c__DisplayClass8_0`2() { }

		internal object <Handle>b__0(object left, object right) { }

		internal object <Handle>b__1(object left, object right) { }

	}

	private struct OperatorQuery : IEquatable<OperatorQuery>
	{
		public readonly Type leftType; //Field offset: 0x0
		public readonly Type rightType; //Field offset: 0x8

		public OperatorQuery(Type leftType, Type rightType) { }

		public override bool Equals(OperatorQuery other) { }

		public virtual bool Equals(object obj) { }

		public virtual int GetHashCode() { }

	}

	private readonly Dictionary<OperatorQuery, Func`3<Object, Object, Object>> handlers; //Field offset: 0x30
	private readonly Dictionary<OperatorQuery, IOptimizedInvoker> userDefinedOperators; //Field offset: 0x38
	private readonly Dictionary<OperatorQuery, OperatorQuery> userDefinedOperandTypes; //Field offset: 0x40

	protected BinaryOperatorHandler(string name, string verb, string symbol, string customMethodName) { }

	protected override object BothNullHandling() { }

	protected override object CustomHandling(object leftOperand, object rightOperand) { }

	protected void Handle(Func<TLeft, TRight, Object> handler, bool reverse = false) { }

	public override object Operate(object leftOperand, object rightOperand) { }

	private static OperatorQuery ResolveUserDefinedOperandTypes(MethodInfo userDefinedOperator) { }

	protected override object SingleNullHandling() { }

}

