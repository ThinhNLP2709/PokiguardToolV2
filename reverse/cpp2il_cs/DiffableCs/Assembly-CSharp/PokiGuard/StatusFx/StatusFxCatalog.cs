namespace PokiGuard.StatusFx;

public static class StatusFxCatalog
{
	internal struct Meta
	{
		public string label; //Field offset: 0x0
		public string iconName; //Field offset: 0x8
		public Color color; //Field offset: 0x10
		public bool isDebuff; //Field offset: 0x20
		public bool showTurns; //Field offset: 0x21

	}

	private static readonly Dictionary<String, Meta> _map; //Field offset: 0x0
	private const int FRAME_START_PROBE = 20; //Field offset: 0x0
	private const int FRAME_MAX_COUNT = 300; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _iconCache; //Field offset: 0x8
	private static readonly Dictionary<String, Sprite[]> _frameCache; //Field offset: 0x10

	private static StatusFxCatalog() { }

	private static Color C(float r, float g, float b) { }

	private static Sprite LoadFrame(string prefix, int index) { }

	public static Sprite[] LoadFrames(string prefix) { }

	public static Sprite LoadIcon(string iconName) { }

	public static string PopupText(string type, string action, double value) { }

	public static bool TryGet(string type, out Meta meta) { }

}

