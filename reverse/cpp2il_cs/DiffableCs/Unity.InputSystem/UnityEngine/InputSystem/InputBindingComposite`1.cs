namespace UnityEngine.InputSystem;

public abstract class InputBindingComposite : InputBindingComposite
{

	public virtual int valueSizeInBytes
	{
		 get { } //Length: 6
	}

	public virtual Type valueType
	{
		 get { } //Length: 56
	}

	protected InputBindingComposite`1() { }

	public virtual int get_valueSizeInBytes() { }

	public virtual Type get_valueType() { }

	public abstract TValue ReadValue(ref InputBindingCompositeContext context) { }

	public virtual void ReadValue(ref InputBindingCompositeContext context, Void* buffer, int bufferSize) { }

	public virtual object ReadValueAsObject(ref InputBindingCompositeContext context) { }

}

