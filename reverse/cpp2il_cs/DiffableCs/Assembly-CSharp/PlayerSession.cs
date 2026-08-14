//Type is in global namespace

public static class PlayerSession
{
	public static int UserId; //Field offset: 0x0
	public static string Username; //Field offset: 0x8
	public static string CharacterName; //Field offset: 0x10

	public static bool IsLoggedIn
	{
		 get { } //Length: 64
	}

	public static void Clear() { }

	public static bool get_IsLoggedIn() { }

}

