namespace Unity.VisualScripting;

public sealed class StaticActionInvoker : StaticActionInvokerBase
{
	private Action<TParam0> invoke; //Field offset: 0x0

	public StaticActionInvoker`1(MethodInfo methodInfo) { }

	[CompilerGenerated]
	private void <CreateDelegate>b__7_0(TParam0 param0) { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target, object arg0) { }

	private object InvokeUnsafe(object target, object arg0) { }

}

