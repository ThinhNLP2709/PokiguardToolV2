namespace UnityEngine.InputSystem;

public interface IInputInteraction
{

	public void Process(ref InputInteractionContext context) { }

	public void Reset() { }

}

