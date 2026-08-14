//Type is in global namespace

public static class MatchFeatureFlags
{
	public const string PREF_DISABLE_HUB_RENDER = "ff_DisableHubRenderInMatch"; //Field offset: 0x0
	public const string PREF_USE_MATCH_PREFAB = "ff_UseMatchPrefab"; //Field offset: 0x0
	public const string PREF_SUSPEND_HUB_SCRIPTS = "ff_SuspendHubScriptsInMatch"; //Field offset: 0x0

	public static bool DisableHubRenderInMatch
	{
		 get { } //Length: 63
	}

	public static bool SuspendHubScriptsInMatch
	{
		 get { } //Length: 63
	}

	public static bool UseMatchPrefab
	{
		 get { } //Length: 63
	}

	public static bool get_DisableHubRenderInMatch() { }

	public static bool get_SuspendHubScriptsInMatch() { }

	public static bool get_UseMatchPrefab() { }

}

