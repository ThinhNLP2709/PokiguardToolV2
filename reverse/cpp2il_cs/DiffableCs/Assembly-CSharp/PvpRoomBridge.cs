//Type is in global namespace

public class PvpRoomBridge
{
	private static PvpRoomBridge _instance; //Field offset: 0x0
	private string _pendingRoomId; //Field offset: 0x10
	private bool _subscribed; //Field offset: 0x18
	[CompilerGenerated]
	private Action OnPvpRoomReady; //Field offset: 0x20
	[CompilerGenerated]
	private Action<String> OnPvpRoomFailed; //Field offset: 0x28

	public event Action<String> OnPvpRoomFailed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action OnPvpRoomReady
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public static PvpRoomBridge Instance
	{
		 get { } //Length: 141
	}

	public PvpRoomBridge() { }

	[CompilerGenerated]
	public void add_OnPvpRoomFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnPvpRoomReady(Action value) { }

	public void CancelPending() { }

	public void CreateAndJoinPhoton(int maxPlayers = 4, Dictionary<String, Object> properties = null) { }

	public void EnsureSubscribed() { }

	private void FailPending(string reason) { }

	public static PvpRoomBridge get_Instance() { }

	private void HandleWsEnterFailed(string reason) { }

	private void HandleWsRoomEntered(string roomId) { }

	public void JoinAndJoinPhoton(string roomId) { }

	[CompilerGenerated]
	public void remove_OnPvpRoomFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnPvpRoomReady(Action value) { }

	public void Unsubscribe() { }

}

