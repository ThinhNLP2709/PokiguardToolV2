namespace UnityEngine.InputSystem;

internal class RemoteInputPlayerConnection : ScriptableObject, IObserver<Message>, IObservable<Message>
{
	private class Subscriber : IDisposable
	{
		public RemoteInputPlayerConnection owner; //Field offset: 0x10
		public IObserver<Message> observer; //Field offset: 0x18

		public Subscriber() { }

		public override void Dispose() { }

	}

	public static readonly Guid kNewDeviceMsg; //Field offset: 0x0
	public static readonly Guid kNewLayoutMsg; //Field offset: 0x10
	public static readonly Guid kNewEventsMsg; //Field offset: 0x20
	public static readonly Guid kRemoveDeviceMsg; //Field offset: 0x30
	public static readonly Guid kChangeUsagesMsg; //Field offset: 0x40
	public static readonly Guid kStartSendingMsg; //Field offset: 0x50
	public static readonly Guid kStopSendingMsg; //Field offset: 0x60
	[SerializeField]
	private IEditorPlayerConnection m_Connection; //Field offset: 0x18
	private Subscriber[] m_Subscribers; //Field offset: 0x20
	[SerializeField]
	private Int32[] m_ConnectedIds; //Field offset: 0x28

	private static RemoteInputPlayerConnection() { }

	public RemoteInputPlayerConnection() { }

	public void Bind(IEditorPlayerConnection connection, bool isConnected) { }

	private void OnChangeUsages(MessageEventArgs args) { }

	private void OnConnected(int id) { }

	private void OnDisconnected(int id) { }

	private void OnNewDevice(MessageEventArgs args) { }

	private void OnNewEvents(MessageEventArgs args) { }

	private void OnNewLayout(MessageEventArgs args) { }

	private void OnRemoveDevice(MessageEventArgs args) { }

	private void OnStartSending(MessageEventArgs args) { }

	private void OnStopSending(MessageEventArgs args) { }

	private void SendToSubscribers(MessageType type, MessageEventArgs args) { }

	public override IDisposable Subscribe(IObserver<Message> observer) { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnCompleted() { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnError(Exception error) { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnNext(Message msg) { }

}

