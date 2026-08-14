//Type is in global namespace

[Preserve]
public static class PokiContentChannel
{
	public const string CHANNEL = "a1"; //Field offset: 0x0
	public const string DEFAULT_BASE = "https://cdn.pokiguard.online/addressables/a1"; //Field offset: 0x0
	private static readonly String[] ALLOWED_HOST_SUFFIXES; //Field offset: 0x0
	private const string PREF_BASE_URL = "ContentBaseUrl"; //Field offset: 0x0
	private const string PREF_CONTENT_VERSION = "LastContentVersion"; //Field offset: 0x0
	private static string _base; //Field offset: 0x8

	[Preserve]
	public static string Base
	{
		 get { } //Length: 79
	}

	public static string LastAppliedContentVersion
	{
		 get { } //Length: 70
	}

	private static PokiContentChannel() { }

	public static bool ApplyFromServer(string baseUrl, string contentVersion) { }

	public static string get_Base() { }

	public static string get_LastAppliedContentVersion() { }

	public static bool IsAllowed(string url) { }

	public static void LoadPersisted() { }

}

