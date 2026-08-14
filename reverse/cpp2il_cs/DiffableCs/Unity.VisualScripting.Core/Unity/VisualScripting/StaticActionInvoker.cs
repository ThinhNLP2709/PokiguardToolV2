namespace Unity.VisualScripting;

public sealed class StaticActionInvoker : StaticActionInvokerBase
{
	private Action invoke; //Field offset: 0x20

	public StaticActionInvoker(MethodInfo methodInfo) { }

	[CompilerGenerated]
	private void <CreateDelegate>b__7_0() { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target) { }

	private object InvokeUnsafe(object target) { }

}

