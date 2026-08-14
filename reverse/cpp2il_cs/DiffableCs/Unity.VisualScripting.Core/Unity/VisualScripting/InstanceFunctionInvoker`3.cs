namespace Unity.VisualScripting;

public sealed class InstanceFunctionInvoker : InstanceFunctionInvokerBase<TTarget, TResult>
{
	private Func<TTarget, TParam0, TResult> invoke; //Field offset: 0x0

	public InstanceFunctionInvoker`3(MethodInfo methodInfo) { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target, object arg0) { }

	public object InvokeUnsafe(object target, object arg0) { }

}

