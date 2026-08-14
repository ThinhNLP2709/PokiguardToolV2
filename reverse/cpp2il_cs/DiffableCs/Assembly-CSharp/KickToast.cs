//Type is in global namespace

public static class KickToast
{
	private static class RuntimeFallback
	{

		public static void Show(string message, float duration) { }

	}

	private const string PREFAB_PATH = "UI/KickToastPanel"; //Field offset: 0x0

	public static void Show(string message = "Bạn đã bị kick khỏi phòng", float duration = 2) { }

}

