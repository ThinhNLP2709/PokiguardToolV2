namespace UnityEngine.InputSystem.LowLevel;

public sealed class InputDeviceCommandDelegate : MulticastDelegate
{

	public InputDeviceCommandDelegate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(InputDevice device, InputDeviceCommand* command, AsyncCallback callback, object object) { }

	public override Nullable<Int64> EndInvoke(IAsyncResult result) { }

	public override Nullable<Int64> Invoke(InputDevice device, InputDeviceCommand* command) { }

}

