namespace UnityEngine.InputSystem.LowLevel;

public struct InputEventListener : IObservable<InputEventPtr>
{
	private class DisposableObserver : IDisposable
	{
		public IObserver<InputEventPtr> observer; //Field offset: 0x10

		public DisposableObserver() { }

		public override void Dispose() { }

	}

	public class ObserverState
	{
		public InlinedArray<IObserver`1<InputEventPtr>> observers; //Field offset: 0x10
		public Action<InputEventPtr, InputDevice> onEventDelegate; //Field offset: 0x28

		public ObserverState() { }

		[CompilerGenerated]
		private void <.ctor>b__2_0(InputEventPtr eventPtr, InputDevice device) { }

	}

	internal static ObserverState s_ObserverState; //Field offset: 0x0

	public static InputEventListener op_Addition(InputEventListener _, Action<InputEventPtr, InputDevice> callback) { }

	public static InputEventListener op_Subtraction(InputEventListener _, Action<InputEventPtr, InputDevice> callback) { }

	public override IDisposable Subscribe(IObserver<InputEventPtr> observer) { }

}

