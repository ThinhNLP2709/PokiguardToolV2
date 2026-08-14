namespace UnityEngine.Events;

internal class InvokableCall : BaseInvokableCall
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UnityAction<T1, T2, T3> Delegate; //Field offset: 0x0

	protected event UnityAction<T1, T2, T3> Delegate
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public InvokableCall`3(object target, MethodInfo theFunction) { }

	public InvokableCall`3(UnityAction<T1, T2, T3> action) { }

	[CompilerGenerated]
	protected void add_Delegate(UnityAction<T1, T2, T3> value) { }

	public virtual bool Find(object targetObj, MethodInfo method) { }

	public virtual void Invoke(Object[] args) { }

	public void Invoke(T1 args0, T2 args1, T3 args2) { }

	[CompilerGenerated]
	protected void remove_Delegate(UnityAction<T1, T2, T3> value) { }

}

