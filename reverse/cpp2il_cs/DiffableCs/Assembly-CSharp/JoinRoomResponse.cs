//Type is in global namespace

public class JoinRoomResponse
{
	public string timestamp; //Field offset: 0x10
	public int status; //Field offset: 0x18
	public bool success; //Field offset: 0x1C
	public string message; //Field offset: 0x20
	public JoinRoomData data; //Field offset: 0x28

	public JoinRoomResponse() { }

}

