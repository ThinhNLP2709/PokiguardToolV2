namespace UnityEngine.InputSystem.LowLevel;

internal sealed class InputUpdateDelegate : MulticastDelegate
{

	public InputUpdateDelegate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(InputUpdateType updateType, ref InputEventBuffer eventBuffer, AsyncCallback callback, object object) { }

	public override void EndInvoke(ref InputEventBuffer eventBuffer, IAsyncResult result) { }

	public override void Invoke(InputUpdateType updateType, ref InputEventBuffer eventBuffer) { }

}

