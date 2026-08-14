namespace UnityEngine.InputSystem.Layouts;

public sealed class InputDeviceFindControlLayoutDelegate : MulticastDelegate
{

	public InputDeviceFindControlLayoutDelegate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeDeviceCommand, AsyncCallback callback, object object) { }

	public override string EndInvoke(ref InputDeviceDescription description, IAsyncResult result) { }

	public override string Invoke(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeDeviceCommand) { }

}

