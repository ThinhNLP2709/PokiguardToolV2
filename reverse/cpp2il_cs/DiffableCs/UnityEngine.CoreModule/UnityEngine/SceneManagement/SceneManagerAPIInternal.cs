namespace UnityEngine.SceneManagement;

[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
[NativeHeader("Runtime/SceneManager/SceneManager.h")]
[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
internal static class SceneManagerAPIInternal
{

	[NativeThrows]
	public static AsyncOperation LoadSceneAsyncNameIndexInternal(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame) { }

	private static IntPtr LoadSceneAsyncNameIndexInternal_Injected(ref ManagedSpanWrapper sceneName, int sceneBuildIndex, in LoadSceneParameters parameters, bool mustCompleteNextFrame) { }

	[NativeThrows]
	public static AsyncOperation UnloadSceneNameIndexInternal(string sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess) { }

	private static IntPtr UnloadSceneNameIndexInternal_Injected(ref ManagedSpanWrapper sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess) { }

}

