namespace Unity.VisualScripting;

public sealed class InstanceFunctionInvoker : InstanceFunctionInvokerBase<TTarget, TResult>
{
	private Func<TTarget, TResult> invoke; //Field offset: 0x0

	public InstanceFunctionInvoker`2(MethodInfo methodInfo) { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target) { }

	public object InvokeUnsafe(object target) { }

}

