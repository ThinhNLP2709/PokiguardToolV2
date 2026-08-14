namespace Unity.VisualScripting;

public abstract class ManualEventUnit : EventUnit<TArgs>
{

	protected abstract string hookName
	{
		 get { } //Length: 0
	}

	protected virtual bool register
	{
		 get { } //Length: 3
	}

	protected ManualEventUnit`1() { }

	protected abstract string get_hookName() { }

	protected virtual bool get_register() { }

	public virtual EventHook GetHook(GraphReference reference) { }

}

