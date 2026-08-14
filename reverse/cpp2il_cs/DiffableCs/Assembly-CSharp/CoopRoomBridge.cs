//Type is in global namespace

public class CoopRoomBridge
{
	private static CoopRoomBridge _instance; //Field offset: 0x0

	public static CoopRoomBridge Instance
	{
		 get { } //Length: 141
	}

	public CoopRoomBridge() { }

	public void CreateAndJoinPhoton(string roomType, int maxPlayers, Dictionary<String, Object> properties = null) { }

	public void EnsureSubscribed() { }

	public static CoopRoomBridge get_Instance() { }

	public void JoinAndJoinPhoton(string roomId) { }

	public void LeaveBoth() { }

}

