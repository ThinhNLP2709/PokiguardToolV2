namespace Unity.VisualScripting;

public static class RuntimeVSUsageUtility
{

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void RuntimeInitializeOnLoadBeforeSceneLoad() { }

}

