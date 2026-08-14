//Type is in global namespace

public class RoomSummaryDTO
{
	public string roomId; //Field offset: 0x10
	public string roomType; //Field offset: 0x18
	public string ownerUsername; //Field offset: 0x20
	public int memberCount; //Field offset: 0x28
	public int maxPlayers; //Field offset: 0x2C
	public bool inMatch; //Field offset: 0x30
	public bool open; //Field offset: 0x31
	public long createdAt; //Field offset: 0x38
	public Dictionary<String, Boolean> members; //Field offset: 0x40
	public Dictionary<String, Object> properties; //Field offset: 0x48

	public RoomSummaryDTO() { }

}

