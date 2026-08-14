namespace Unity.VisualScripting;

public abstract class InvokerBase : IOptimizedInvoker
{
	protected readonly Type targetType; //Field offset: 0x10
	protected readonly MethodInfo methodInfo; //Field offset: 0x18

	protected InvokerBase(MethodInfo methodInfo) { }

	public override void Compile() { }

	protected abstract void CompileExpression() { }

	protected abstract void CreateDelegate() { }

	protected ParameterExpression[] GetParameterExpressions() { }

	protected abstract Type[] GetParameterTypes() { }

	public abstract object Invoke(object target, Object[] args) { }

	public override object Invoke(object target) { }

	public override object Invoke(object target, object arg0) { }

	public override object Invoke(object target, object arg0, object arg1) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3) { }

	public override object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	protected void VerifyArgument(MethodInfo methodInfo, int argIndex, object arg) { }

	protected abstract void VerifyTarget(object target) { }

}

