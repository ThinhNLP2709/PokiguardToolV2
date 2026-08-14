//Type is in global namespace

public class ApiResponse
{
	public string timestamp; //Field offset: 0x10
	public int status; //Field offset: 0x18
	public bool success; //Field offset: 0x1C
	public string message; //Field offset: 0x20
	public Data data; //Field offset: 0x28

	public ApiResponse() { }

}

