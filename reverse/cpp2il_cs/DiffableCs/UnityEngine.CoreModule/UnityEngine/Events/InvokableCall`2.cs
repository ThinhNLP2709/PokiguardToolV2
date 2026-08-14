namespace UnityEngine.Events;

internal class InvokableCall : BaseInvokableCall
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UnityAction<T1, T2> Delegate; //Field offset: 0x0

	protected event UnityAction<T1, T2> Delegate
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public InvokableCall`2(object target, MethodInfo theFunction) { }

	public InvokableCall`2(UnityAction<T1, T2> action) { }

	[CompilerGenerated]
	protected void add_Delegate(UnityAction<T1, T2> value) { }

	public virtual bool Find(object targetObj, MethodInfo method) { }

	public virtual void Invoke(Object[] args) { }

	public void Invoke(T1 args0, T2 args1) { }

	[CompilerGenerated]
	protected void remove_Delegate(UnityAction<T1, T2> value) { }

}

