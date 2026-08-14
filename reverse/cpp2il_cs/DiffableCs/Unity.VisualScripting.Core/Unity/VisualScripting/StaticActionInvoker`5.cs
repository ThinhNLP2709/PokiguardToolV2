namespace Unity.VisualScripting;

public sealed class StaticActionInvoker : StaticActionInvokerBase
{
	private Action<TParam0, TParam1, TParam2, TParam3, TParam4> invoke; //Field offset: 0x0

	public StaticActionInvoker`5(MethodInfo methodInfo) { }

	[CompilerGenerated]
	private void <CreateDelegate>b__7_0(TParam0 param0, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4) { }

	protected virtual void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void CreateDelegate() { }

	protected virtual Type[] GetParameterTypes() { }

	public virtual object Invoke(object target, Object[] args) { }

	public virtual object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	public object InvokeUnsafe(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

}

