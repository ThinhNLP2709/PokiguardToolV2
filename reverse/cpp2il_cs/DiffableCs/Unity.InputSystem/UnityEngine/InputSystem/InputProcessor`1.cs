namespace UnityEngine.InputSystem;

public abstract class InputProcessor : InputProcessor
{

	protected InputProcessor`1() { }

	public abstract TValue Process(TValue value, InputControl control) { }

	public virtual void Process(Void* buffer, int bufferSize, InputControl control) { }

	public virtual object ProcessAsObject(object value, InputControl control) { }

}

