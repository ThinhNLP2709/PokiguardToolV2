//Type is in global namespace

public class LoginResponse
{
	public bool success; //Field offset: 0x10
	public string message; //Field offset: 0x18
	public string token; //Field offset: 0x20
	public string sessionKey; //Field offset: 0x28
	public int userId; //Field offset: 0x30
	public string username; //Field offset: 0x38
	public string name; //Field offset: 0x40
	public int level; //Field offset: 0x48
	public int gold; //Field offset: 0x4C
	public int ruby; //Field offset: 0x50
	public int energy; //Field offset: 0x54
	public int energyFull; //Field offset: 0x58
	public UserDTO user; //Field offset: 0x60
	public long serverTimestamp; //Field offset: 0x68

	public LoginResponse() { }

}

