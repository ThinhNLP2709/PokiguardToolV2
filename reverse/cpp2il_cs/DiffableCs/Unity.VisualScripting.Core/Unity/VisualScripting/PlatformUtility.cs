namespace Unity.VisualScripting;

[Extension]
public static class PlatformUtility
{
	public static readonly bool supportsJit; //Field offset: 0x0

	private static PlatformUtility() { }

	private static bool CheckJitSupport() { }

	[Extension]
	public static bool IsEditor(RuntimePlatform platform) { }

	[Extension]
	public static bool IsStandalone(RuntimePlatform platform) { }

}

