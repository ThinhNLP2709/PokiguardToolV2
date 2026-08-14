namespace Unity.VisualScripting;

public sealed class StaticFunctionInvoker : StaticFunctionInvokerBase<TResult>
{
	private Func<TResult> invoke; //Field offset: 0x0

	public StaticFunctionInvoker`1(MethodInfo methodInfo) { }

	[CompilerGenerated]
	private TResult <CreateDelegate>b__7_0() { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target) { }

	public object InvokeUnsafe(object target) { }

}

