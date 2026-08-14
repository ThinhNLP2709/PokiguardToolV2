//Type is in global namespace

public class BossRoomBridge
{
	private static BossRoomBridge _instance; //Field offset: 0x0
	private bool _subscribed; //Field offset: 0x10
	[CompilerGenerated]
	private Action OnBossRoomReady; //Field offset: 0x18
	[CompilerGenerated]
	private Action<String> OnBossRoomFailed; //Field offset: 0x20

	public event Action<String> OnBossRoomFailed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action OnBossRoomReady
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public static BossRoomBridge Instance
	{
		 get { } //Length: 141
	}

	public BossRoomBridge() { }

	[CompilerGenerated]
	public void add_OnBossRoomFailed(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnBossRoomReady(Action value) { }

	public void CreateAndJoinPhoton(Dictionary<String, Object> properties = null) { }

	public void EnsureSubscribed() { }

	public static BossRoomBridge get_Instance() { }

	private void HandleWsEnterFailed(string reason) { }

	private void HandleWsRoomEntered(string roomId) { }

	public void LeaveBoth() { }

	[CompilerGenerated]
	public void remove_OnBossRoomFailed(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnBossRoomReady(Action value) { }

	public void Unsubscribe() { }

}

