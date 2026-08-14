namespace UnityEngine.Networking.PlayerConnection;

internal class PlayerEditorConnectionEvents
{
	internal class ConnectionChangeEvent : UnityEvent<Int32>
	{

		public ConnectionChangeEvent() { }

	}

	internal class MessageEvent : UnityEvent<MessageEventArgs>
	{

		public MessageEvent() { }

	}

	internal class MessageTypeSubscribers
	{
		[SerializeField]
		private string m_messageTypeId; //Field offset: 0x10
		public int subscriberCount; //Field offset: 0x18
		public MessageEvent messageCallback; //Field offset: 0x20

		public Guid MessageTypeId
		{
			 get { } //Length: 54
			 set { } //Length: 44
		}

		public MessageTypeSubscribers() { }

		public Guid get_MessageTypeId() { }

		public void set_MessageTypeId(Guid value) { }

	}

	[SerializeField]
	private List<MessageTypeSubscribers> m_MessageTypeSubscribers; //Field offset: 0x10
	private Dictionary<Guid, MessageTypeSubscribers> m_SubscriberLookup; //Field offset: 0x18
	[SerializeField]
	public ConnectionChangeEvent connectionEvent; //Field offset: 0x20
	[SerializeField]
	public ConnectionChangeEvent disconnectionEvent; //Field offset: 0x28

	public IReadOnlyList<MessageTypeSubscribers> messageTypeSubscribers
	{
		 get { } //Length: 5
	}

	public PlayerEditorConnectionEvents() { }

	public UnityEvent<MessageEventArgs> AddAndCreate(Guid messageId) { }

	private void BuildLookup() { }

	public IReadOnlyList<MessageTypeSubscribers> get_messageTypeSubscribers() { }

	public void InvokeMessageIdSubscribers(Guid messageId, Byte[] data, int playerId) { }

	public void UnregisterManagedCallback(Guid messageId, UnityAction<MessageEventArgs> callback) { }

}

