namespace UnityEngine.InputSystem.Utilities;

internal class ForDeviceEventObservable : IObservable<InputEventPtr>
{
	private class ForDevice : IObserver<InputEventPtr>
	{
		private IObserver<InputEventPtr> m_Observer; //Field offset: 0x10
		private InputDevice m_Device; //Field offset: 0x18
		private Type m_DeviceType; //Field offset: 0x20

		public ForDevice(Type deviceType, InputDevice device, IObserver<InputEventPtr> observer) { }

		public override void OnCompleted() { }

		public override void OnError(Exception error) { }

		public override void OnNext(InputEventPtr value) { }

	}

	private IObservable<InputEventPtr> m_Source; //Field offset: 0x10
	private InputDevice m_Device; //Field offset: 0x18
	private Type m_DeviceType; //Field offset: 0x20

	public ForDeviceEventObservable(IObservable<InputEventPtr> source, Type deviceType, InputDevice device) { }

	public override IDisposable Subscribe(IObserver<InputEventPtr> observer) { }

}

