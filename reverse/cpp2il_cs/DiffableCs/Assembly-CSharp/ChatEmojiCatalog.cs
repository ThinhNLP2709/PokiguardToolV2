//Type is in global namespace

public static class ChatEmojiCatalog
{
	internal class Entry
	{
		public string Id; //Field offset: 0x10
		public String[] FramePaths; //Field offset: 0x18
		public float Fps; //Field offset: 0x20

		public Entry(string id, float fps, String[] framePaths) { }

	}

	public static readonly IReadOnlyList<Entry> All; //Field offset: 0x0
	private static readonly Dictionary<String, Entry> _byId; //Field offset: 0x8
	private static readonly Dictionary<String, Sprite[]> _frameCache; //Field offset: 0x10

	public static Sprite UiFrameEmoji
	{
		 get { } //Length: 83
	}

	public static Sprite UiIconChat
	{
		 get { } //Length: 83
	}

	public static Sprite UiTabActive
	{
		 get { } //Length: 83
	}

	public static Sprite UiTabInactive
	{
		 get { } //Length: 83
	}

	private static ChatEmojiCatalog() { }

	private static Dictionary<String, Entry> BuildIndex() { }

	public static Entry Get(string id) { }

	public static Sprite get_UiFrameEmoji() { }

	public static Sprite get_UiIconChat() { }

	public static Sprite get_UiTabActive() { }

	public static Sprite get_UiTabInactive() { }

	public static bool IsValid(string id) { }

	public static Sprite[] LoadFrames(string id) { }

}

