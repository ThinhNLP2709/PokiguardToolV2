namespace Unity.VisualScripting;

public sealed class InstanceActionInvoker : InstanceActionInvokerBase<TTarget>
{
	private Action<TTarget> invoke; //Field offset: 0x0

	public InstanceActionInvoker`1(MethodInfo methodInfo) { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target) { }

	private object InvokeUnsafe(object target) { }

}

