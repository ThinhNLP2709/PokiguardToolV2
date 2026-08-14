//Type is in global namespace

public class WsRoomService
{
	private static WsRoomService _instance; //Field offset: 0x0
	[CompilerGenerated]
	private string <CurrentRoomId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <CurrentRoomType>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <OwnerUsername>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <MaxPlayers>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Dictionary<String, Boolean> <Members>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Dictionary<String, Object> <Properties>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private Dictionary<String, WsPlayerStateDTO> <PlayerStates>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private Dictionary<String, RoomSummaryDTO> <AvailableRooms>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private bool <IsSubscribed>k__BackingField; //Field offset: 0x50
	private RoomListFilterDTO _activeFilter; //Field offset: 0x58
	[CompilerGenerated]
	private string <LastLeaveReason>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private Action<String> OnRoomEntered; //Field offset: 0x68
	[CompilerGenerated]
	private Action<String> OnRoomLeft; //Field offset: 0x70
	[CompilerGenerated]
	private Action<String> OnEnterFailed; //Field offset: 0x78
	[CompilerGenerated]
	private Action OnMembersChanged; //Field offset: 0x80
	[CompilerGenerated]
	private Action OnPropertiesChanged; //Field offset: 0x88
	[CompilerGenerated]
	private Action OnPlayerStatesChanged; //Field offset: 0x90
	[CompilerGenerated]
	private Action<String> OnKicked; //Field offset: 0x98
	[CompilerGenerated]
	private Action<String> OnKickFailed; //Field offset: 0xA0
	[CompilerGenerated]
	private Action<String, Dictionary`2<String, Object>> OnMatchStarting; //Field offset: 0xA8
	[CompilerGenerated]
	private Action OnRoomListChanged; //Field offset: 0xB0
	private bool _subscribed; //Field offset: 0xB8
	private ChatService _boundChat; //Field offset: 0xC0
	private bool _pendingLeaveFlush; //Field offset: 0xC8

	public event Action<String> OnEnterFailed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<String> OnKicked
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnKickFailed
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, Dictionary`2<String, Object>> OnMatchStarting
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action OnMembersChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action OnPlayerStatesChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action OnPropertiesChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action<String> OnRoomEntered
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<String> OnRoomLeft
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action OnRoomListChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public bool AllReady
	{
		 get { } //Length: 360
	}

	public private Dictionary<String, RoomSummaryDTO> AvailableRooms
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string CurrentRoomId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string CurrentRoomType
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public static WsRoomService Instance
	{
		 get { } //Length: 141
	}

	public bool IsHost
	{
		 get { } //Length: 164
	}

	public bool IsInRoom
	{
		 get { } //Length: 22
	}

	public bool IsRoomFull
	{
		 get { } //Length: 98
	}

	public private bool IsSubscribed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private string LastLeaveReason
	{
		[CompilerGenerated]
		 get { } //Length: 694
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private int MaxPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private Dictionary<String, Boolean> Members
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string OwnerUsername
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Dictionary<String, WsPlayerStateDTO> PlayerStates
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Dictionary<String, Object> Properties
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private WsRoomService() { }

	[CompilerGenerated]
	public void add_OnEnterFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnKicked(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnKickFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchStarting(Action<String, Dictionary`2<String, Object>> value) { }

	[CompilerGenerated]
	public void add_OnMembersChanged(Action value) { }

	[CompilerGenerated]
	public void add_OnPlayerStatesChanged(Action value) { }

	[CompilerGenerated]
	public void add_OnPropertiesChanged(Action value) { }

	[CompilerGenerated]
	public void add_OnRoomEntered(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomLeft(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnRoomListChanged(Action value) { }

	public void CreateRoom(string roomType, int maxPlayers, Dictionary<String, Object> properties = null) { }

	private void EchoMyPropsLocally(WsPlayerStateDTO diff) { }

	public bool get_AllReady() { }

	[CompilerGenerated]
	public Dictionary<String, RoomSummaryDTO> get_AvailableRooms() { }

	[CompilerGenerated]
	public string get_CurrentRoomId() { }

	[CompilerGenerated]
	public string get_CurrentRoomType() { }

	public static WsRoomService get_Instance() { }

	public bool get_IsHost() { }

	public bool get_IsInRoom() { }

	public bool get_IsRoomFull() { }

	[CompilerGenerated]
	public bool get_IsSubscribed() { }

	[CompilerGenerated]
	public string get_LastLeaveReason() { }

	[CompilerGenerated]
	public int get_MaxPlayers() { }

	[CompilerGenerated]
	public Dictionary<String, Boolean> get_Members() { }

	[CompilerGenerated]
	public string get_OwnerUsername() { }

	[CompilerGenerated]
	public Dictionary<String, WsPlayerStateDTO> get_PlayerStates() { }

	[CompilerGenerated]
	public Dictionary<String, Object> get_Properties() { }

	private void HandleConnectionChanged(bool connected) { }

	private void HandleEntered(ChatMessageDTO m) { }

	private void HandleEnterFailed(string reason) { }

	private void HandleMatchStarting(ChatMessageDTO m) { }

	private void HandleMemberUpdate(ChatMessageDTO m) { }

	private void HandlePlayerPropsUpdate(ChatMessageDTO m) { }

	private void HandlePropsUpdate(ChatMessageDTO m) { }

	private void HandleReadyUpdate(ChatMessageDTO m) { }

	private void HandleRoomCreated(ChatMessageDTO m) { }

	private void HandleRoomJoined(ChatMessageDTO m) { }

	private void HandleRoomKicked(ChatMessageDTO m) { }

	private void HandleRoomKickFailed(string reason) { }

	private void HandleRoomListDelta(string action, RoomSummaryDTO room) { }

	private void HandleRoomListSnapshot(RoomSummaryDTO[] rooms) { }

	public void JoinRoom(string roomId) { }

	public void KickMember(string targetUsername) { }

	public void LeaveRoom() { }

	[CompilerGenerated]
	public void remove_OnEnterFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnKicked(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnKickFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchStarting(Action<String, Dictionary`2<String, Object>> value) { }

	[CompilerGenerated]
	public void remove_OnMembersChanged(Action value) { }

	[CompilerGenerated]
	public void remove_OnPlayerStatesChanged(Action value) { }

	[CompilerGenerated]
	public void remove_OnPropertiesChanged(Action value) { }

	[CompilerGenerated]
	public void remove_OnRoomEntered(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomLeft(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnRoomListChanged(Action value) { }

	public void RequestRoomList() { }

	private void ResetState(string reason) { }

	[CompilerGenerated]
	private void set_AvailableRooms(Dictionary<String, RoomSummaryDTO> value) { }

	[CompilerGenerated]
	private void set_CurrentRoomId(string value) { }

	[CompilerGenerated]
	private void set_CurrentRoomType(string value) { }

	[CompilerGenerated]
	private void set_IsSubscribed(bool value) { }

	[CompilerGenerated]
	private void set_LastLeaveReason(string value) { }

	[CompilerGenerated]
	private void set_MaxPlayers(int value) { }

	[CompilerGenerated]
	private void set_Members(Dictionary<String, Boolean> value) { }

	[CompilerGenerated]
	private void set_OwnerUsername(string value) { }

	[CompilerGenerated]
	private void set_PlayerStates(Dictionary<String, WsPlayerStateDTO> value) { }

	[CompilerGenerated]
	private void set_Properties(Dictionary<String, Object> value) { }

	public void SetReady(bool ready) { }

	public void StartMatch() { }

	public void SubscribeRoomList(RoomListFilterDTO filter = null) { }

	private static Dictionary<String, WsPlayerStateDTO> ToIgnoreCaseDict(Dictionary<String, WsPlayerStateDTO> src) { }

	private static Dictionary<String, Boolean> ToIgnoreCaseMembers(Dictionary<String, Boolean> src) { }

	public void TrySubscribe() { }

	public void Unsubscribe() { }

	private void UnsubscribeFrom(ChatService cs) { }

	public void UnsubscribeRoomList() { }

	public void UpdateMyPlayerProps(WsPlayerStateDTO diff) { }

	public void UpdateProperties(Dictionary<String, Object> props) { }

}

