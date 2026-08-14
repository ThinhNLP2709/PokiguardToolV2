namespace Unity.VisualScripting;

public interface IGraphEventListener
{

	public bool IsListening(GraphPointer pointer) { }

	public void StartListening(GraphStack stack) { }

	public void StopListening(GraphStack stack) { }

}

