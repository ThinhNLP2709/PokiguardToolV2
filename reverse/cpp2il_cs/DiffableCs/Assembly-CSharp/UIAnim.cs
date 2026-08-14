//Type is in global namespace

public static class UIAnim
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public GameObject panel; //Field offset: 0x10
		public Action onComplete; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <Close>b__0() { }

	}

	public const float OpenTime = 0.18; //Field offset: 0x0
	public const float CloseTime = 0.12; //Field offset: 0x0
	public const LeanTweenType OpenEase = 27; //Field offset: 0x0
	public const LeanTweenType CloseEase = 26; //Field offset: 0x0

	public static void Close(GameObject panel, CanvasGroup canvasGroup = null, Action onComplete = null) { }

	public static void Open(GameObject panel, CanvasGroup canvasGroup = null) { }

}

