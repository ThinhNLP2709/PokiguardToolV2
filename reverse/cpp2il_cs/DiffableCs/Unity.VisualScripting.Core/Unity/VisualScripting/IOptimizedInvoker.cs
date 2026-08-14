namespace Unity.VisualScripting;

public interface IOptimizedInvoker
{

	public void Compile() { }

	public object Invoke(object target) { }

	public object Invoke(object target, object arg0) { }

	public object Invoke(object target, object arg0, object arg1) { }

	public object Invoke(object target, object arg0, object arg1, object arg2) { }

	public object Invoke(object target, object arg0, object arg1, object arg2, object arg3) { }

	public object Invoke(object target, object arg0, object arg1, object arg2, object arg3, object arg4) { }

	public object Invoke(object target, Object[] args) { }

}

