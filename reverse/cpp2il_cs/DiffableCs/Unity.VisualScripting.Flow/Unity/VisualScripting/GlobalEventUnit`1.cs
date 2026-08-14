namespace Unity.VisualScripting;

public abstract class GlobalEventUnit : EventUnit<TArgs>
{

	protected override string hookName
	{
		 get { } //Length: 57
	}

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	protected GlobalEventUnit`1() { }

	protected override string get_hookName() { }

	protected virtual bool get_register() { }

	public virtual EventHook GetHook(GraphReference reference) { }

}

