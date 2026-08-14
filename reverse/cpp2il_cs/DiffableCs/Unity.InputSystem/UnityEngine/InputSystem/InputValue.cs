namespace UnityEngine.InputSystem;

[DebuggerDisplay("Value = {Get()}")]
public class InputValue
{
	internal Nullable<CallbackContext> m_Context; //Field offset: 0x10

	public bool isPressed
	{
		 get { } //Length: 90
	}

	public InputValue() { }

	public object Get() { }

	public TValue Get() { }

	public bool get_isPressed() { }

}

