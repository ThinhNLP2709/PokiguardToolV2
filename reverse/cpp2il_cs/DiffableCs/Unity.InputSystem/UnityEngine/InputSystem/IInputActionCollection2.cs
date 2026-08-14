namespace UnityEngine.InputSystem;

public interface IInputActionCollection2 : IInputActionCollection, IEnumerable<InputAction>, IEnumerable
{

	public IEnumerable<InputBinding> bindings
	{
		 get { } //Length: 0
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false) { }

	public int FindBinding(InputBinding mask, out InputAction action) { }

	public IEnumerable<InputBinding> get_bindings() { }

}

