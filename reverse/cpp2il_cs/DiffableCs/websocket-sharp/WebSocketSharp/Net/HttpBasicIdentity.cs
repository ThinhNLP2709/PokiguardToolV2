namespace WebSocketSharp.Net;

public class HttpBasicIdentity : GenericIdentity
{
	private string _password; //Field offset: 0x88

	public override string Password
	{
		 get { } //Length: 10
	}

	internal HttpBasicIdentity(string username, string password) { }

	public override string get_Password() { }

}

