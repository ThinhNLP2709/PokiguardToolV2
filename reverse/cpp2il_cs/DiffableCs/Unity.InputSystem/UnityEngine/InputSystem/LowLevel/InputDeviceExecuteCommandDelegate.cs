namespace UnityEngine.InputSystem.LowLevel;

public sealed class InputDeviceExecuteCommandDelegate : MulticastDelegate
{

	public InputDeviceExecuteCommandDelegate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(ref InputDeviceCommand command, AsyncCallback callback, object object) { }

	public override long EndInvoke(ref InputDeviceCommand command, IAsyncResult result) { }

	public override long Invoke(ref InputDeviceCommand command) { }

}

