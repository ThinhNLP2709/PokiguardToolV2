//Type is in global namespace

public static class MatchContext
{
	public const string COOP_SCENE = "Match"; //Field offset: 0x0
	public const string PVP_SCENE = "MatchPVP"; //Field offset: 0x0

	public static bool InAnyMatch
	{
		 get { } //Length: 33
	}

	public static bool InCoopMatch
	{
		 get { } //Length: 229
	}

	public static bool InPvpMatch
	{
		 get { } //Length: 230
	}

	public static bool get_InAnyMatch() { }

	public static bool get_InCoopMatch() { }

	public static bool get_InPvpMatch() { }

	public static bool InMatchOfSceneName(string sceneName) { }

	private static bool IsSceneLoaded(string sceneName) { }

}

