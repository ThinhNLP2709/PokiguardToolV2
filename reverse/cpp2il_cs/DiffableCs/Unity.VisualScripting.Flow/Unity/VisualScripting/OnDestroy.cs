namespace Unity.VisualScripting;

[UnitCategory("Events/Lifecycle")]
[UnitOrder(7)]
public sealed class OnDestroy : MachineEventUnit<EmptyEventArgs>
{

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnDestroy() { }

	protected virtual string get_hookName() { }

	virtual void InternalTrigger(GraphReference reference, EmptyEventArgs args) { }

	public virtual void StopListening(GraphStack stack) { }

}

