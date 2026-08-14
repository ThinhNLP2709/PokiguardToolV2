namespace UnityEngine.AdaptivePerformance;

internal static class AdaptivePerformanceInitializer
{
	private static AdaptivePerformanceManagerSpawner s_Spawner; //Field offset: 0x0

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInitialize() { }

	public static void Deinitialize() { }

	public static void Initialize() { }

	private static void InitializeSpawner(bool isAuto) { }

}

