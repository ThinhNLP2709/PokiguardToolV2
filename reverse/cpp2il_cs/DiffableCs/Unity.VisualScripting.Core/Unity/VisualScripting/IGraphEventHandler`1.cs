namespace Unity.VisualScripting;

public interface IGraphEventHandler
{

	public EventHook GetHook(GraphReference reference) { }

	public bool IsListening(GraphPointer pointer) { }

	public void Trigger(GraphReference reference, TArgs args) { }

}

