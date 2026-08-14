namespace Unity.VisualScripting;

public abstract class UnaryOperatorHandler : OperatorHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Func<T, Object> handler; //Field offset: 0x0

		public <>c__DisplayClass6_0`1() { }

		internal object <Handle>b__0(object operand) { }

	}

	private readonly Dictionary<Type, Func`2<Object, Object>> manualHandlers; //Field offset: 0x30
	private readonly Dictionary<Type, IOptimizedInvoker> userDefinedOperators; //Field offset: 0x38
	private readonly Dictionary<Type, Type> userDefinedOperandTypes; //Field offset: 0x40

	protected UnaryOperatorHandler(string name, string verb, string symbol, string customMethodName) { }

	protected override object CustomHandling(object operand) { }

	protected void Handle(Func<T, Object> handler) { }

	public object Operate(object operand) { }

	private static Type ResolveUserDefinedOperandType(MethodInfo userDefinedOperator) { }

}

