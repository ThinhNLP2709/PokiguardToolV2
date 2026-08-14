namespace Unity.VisualScripting;

public abstract class StaticInvokerBase : InvokerBase
{

	protected StaticInvokerBase(MethodInfo methodInfo) { }

	protected virtual void CompileExpression() { }

	protected abstract void CompileExpression(MethodCallExpression callExpression, ParameterExpression[] parameterExpressions) { }

	protected virtual void VerifyTarget(object target) { }

}

