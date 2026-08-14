//Type is in global namespace

public class InvitePlayer_Handler : MonoBehaviour
{
	[CompilerGenerated]
	private static InvitePlayer_Handler <Instance>k__BackingField; //Field offset: 0x0
	private readonly Dictionary<String, Boolean> _online; //Field offset: 0x20
	private readonly Dictionary<String, Boolean> _busy; //Field offset: 0x28
	[CompilerGenerated]
	private Action<String, Boolean, Boolean> OnPresenceChanged; //Field offset: 0x30
	[CompilerGenerated]
	private Action<UserPresenceDTO[]> OnOnlineListReceived; //Field offset: 0x38

	public event Action<UserPresenceDTO[]> OnOnlineListReceived
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<String, Boolean, Boolean> OnPresenceChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public private static InvitePlayer_Handler Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public bool IsReady
	{
		 get { } //Length: 169
	}

	public IReadOnlyDictionary<String, Boolean> OnlineSnapshot
	{
		 get { } //Length: 5
	}

	public InvitePlayer_Handler() { }

	[CompilerGenerated]
	public void add_OnOnlineListReceived(Action<UserPresenceDTO[]> value) { }

	[CompilerGenerated]
	public void add_OnPresenceChanged(Action<String, Boolean, Boolean> value) { }

	private void Awake() { }

	public static string BuildSlotInfo(string roomName, string roomType) { }

	public static string DetectInviteRoomMode() { }

	public void EnsureConnected() { }

	[CompilerGenerated]
	public static InvitePlayer_Handler get_Instance() { }

	public bool get_IsReady() { }

	public IReadOnlyDictionary<String, Boolean> get_OnlineSnapshot() { }

	private static string GetLocalLoginName() { }

	private void HandleInviteReceived(string sender, object messageObj) { }

	private void HandleOnlineListReceived(UserPresenceDTO[] users) { }

	private void HandlePresenceChanged(string username, bool online, bool busy) { }

	public bool IsUserBusy(string username) { }

	public bool IsUserOnline(string username) { }

	private void OnDestroy() { }

	private void ParseAndShow(string sender, String[] parts, bool full) { }

	[CompilerGenerated]
	public void remove_OnOnlineListReceived(Action<UserPresenceDTO[]> value) { }

	[CompilerGenerated]
	public void remove_OnPresenceChanged(Action<String, Boolean, Boolean> value) { }

	public void RequestOnlineList() { }

	public bool SendInvitation(string targetUsername, string roomName) { }

	[CompilerGenerated]
	private static void set_Instance(InvitePlayer_Handler value) { }

	public void SetMyBusyStatus(bool busy) { }

	private void Start() { }

	private void SubscribeChatEvents() { }

	private void UnsubscribeChatEvents() { }

}

