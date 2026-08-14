namespace UnityEngine.InputSystem;

public sealed class InputRemoting : IObservable<Message>, IObserver<Message>
{
	private static class ChangeUsageMsg
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<InternedString, String> <>9__1_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal string <Create>b__1_0(InternedString x) { }

		}

		internal struct Data
		{
			public int deviceId; //Field offset: 0x0
			public String[] usages; //Field offset: 0x8

		}


		public static Message Create(InputDevice device) { }

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	private static class ConnectMsg
	{

		public static void Process(InputRemoting receiver) { }

	}

	private static class DisconnectMsg
	{

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	[Flags]
	private enum Flags
	{
		Sending = 1,
		StartSendingOnConnect = 2,
	}

	internal struct Message
	{
		public int participantId; //Field offset: 0x0
		public MessageType type; //Field offset: 0x4
		public Byte[] data; //Field offset: 0x8

	}

	internal enum MessageType
	{
		Connect = 0,
		Disconnect = 1,
		NewLayout = 2,
		NewDevice = 3,
		NewEvents = 4,
		RemoveDevice = 5,
		RemoveLayout = 6,
		ChangeUsages = 7,
		StartSending = 8,
		StopSending = 9,
	}

	private static class NewDeviceMsg
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<InternedString, String> <>9__1_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal string <Create>b__1_0(InternedString x) { }

		}

		internal struct Data
		{
			public string name; //Field offset: 0x0
			public string layout; //Field offset: 0x8
			public int deviceId; //Field offset: 0x10
			public String[] usages; //Field offset: 0x18
			public InputDeviceDescription description; //Field offset: 0x20

		}


		public static Message Create(InputDevice device) { }

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	private static class NewEventsMsg
	{

		public static Message Create(InputEvent* events, int eventCount) { }

		public static Message CreateResetEvent(InputDevice device, bool isHardReset) { }

		public static Message CreateStateEvent(InputDevice device) { }

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	private static class NewLayoutMsg
	{
		internal struct Data
		{
			public string name; //Field offset: 0x0
			public string layoutJson; //Field offset: 0x8
			public bool isOverride; //Field offset: 0x10

		}


		public static Nullable<Message> Create(InputRemoting sender, string layoutName) { }

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	public struct RemoteInputDevice
	{
		public int remoteId; //Field offset: 0x0
		public int localId; //Field offset: 0x4
		public InputDeviceDescription description; //Field offset: 0x8

	}

	public struct RemoteSender
	{
		public int senderId; //Field offset: 0x0
		public InternedString[] layouts; //Field offset: 0x8
		public RemoteInputDevice[] devices; //Field offset: 0x10

	}

	private static class RemoveDeviceMsg
	{

		public static Message Create(InputDevice device) { }

		public static void Process(InputRemoting receiver, Message msg) { }

	}

	private static class StartSendingMsg
	{

		public static void Process(InputRemoting receiver) { }

	}

	private static class StopSendingMsg
	{

		public static void Process(InputRemoting receiver) { }

	}

	public class Subscriber : IDisposable
	{
		public InputRemoting owner; //Field offset: 0x10
		public IObserver<Message> observer; //Field offset: 0x18

		public Subscriber() { }

		public override void Dispose() { }

	}

	private Flags m_Flags; //Field offset: 0x10
	private InputManager m_LocalManager; //Field offset: 0x18
	private Subscriber[] m_Subscribers; //Field offset: 0x20
	private RemoteSender[] m_Senders; //Field offset: 0x28

	internal InputManager manager
	{
		internal get { } //Length: 5
	}

	public private bool sending
	{
		 get { } //Length: 7
		private set { } //Length: 25
	}

	internal InputRemoting(InputManager manager, bool startSendingOnConnect = false) { }

	private static InternedString BuildLayoutNamespace(int senderId) { }

	private static TData DeserializeData(Byte[] data) { }

	private int FindLocalDeviceId(int remoteDeviceId, int senderIndex) { }

	private int FindOrCreateSenderRecord(int senderId) { }

	internal InputManager get_manager() { }

	public bool get_sending() { }

	public void RemoveRemoteDevices(int participantId) { }

	private void Send(Message msg) { }

	private void SendAllDevices() { }

	private void SendAllGeneratedLayouts() { }

	private void SendDevice(InputDevice device) { }

	private void SendDeviceChange(InputDevice device, InputDeviceChange change) { }

	private void SendEvent(InputEventPtr eventPtr, InputDevice device) { }

	private void SendInitialMessages() { }

	private void SendLayout(string layoutName) { }

	private void SendLayoutChange(string layout, InputControlLayoutChange change) { }

	private static Byte[] SerializeData(TData data) { }

	private void set_sending(bool value) { }

	public void StartSending() { }

	public void StopSending() { }

	public override IDisposable Subscribe(IObserver<Message> observer) { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnCompleted() { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnError(Exception error) { }

	private override void System.IObserver<UnityEngine.InputSystem.InputRemoting.Message>.OnNext(Message msg) { }

	private InputDevice TryGetDeviceByRemoteId(int remoteDeviceId, int senderIndex) { }

}

