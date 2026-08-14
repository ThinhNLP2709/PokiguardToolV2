//Type is in global namespace

public static class AppRuntimeConfig
{

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void Apply() { }

	private static void ApplyFrameRateCap() { }

	private static void ApplyLogStackTracePolicy() { }

}

