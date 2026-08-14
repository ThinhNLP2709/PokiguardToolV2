namespace UnityEngine.SceneManagement;

[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
[RequiredByNativeCode]
public class SceneManager
{
	internal static bool s_AllowLoadScene; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static UnityAction<Scene, LoadSceneMode> sceneLoaded; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static UnityAction<Scene> sceneUnloaded; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static UnityAction<Scene, Scene> activeSceneChanged; //Field offset: 0x18

	public static event UnityAction<Scene, Scene> activeSceneChanged
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event UnityAction<Scene, LoadSceneMode> sceneLoaded
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event UnityAction<Scene> sceneUnloaded
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static int sceneCount
	{
		[NativeHeader("Runtime/SceneManager/SceneManager.h")]
		[NativeMethod("GetSceneCount")]
		[StaticAccessor("GetSceneManager()", StaticAccessorType::Dot (0))]
		 get { } //Length: 42
	}

	private static SceneManager() { }

	[CompilerGenerated]
	public static void add_activeSceneChanged(UnityAction<Scene, Scene> value) { }

	[CompilerGenerated]
	public static void add_sceneLoaded(UnityAction<Scene, LoadSceneMode> value) { }

	[CompilerGenerated]
	public static void add_sceneUnloaded(UnityAction<Scene> value) { }

	[NativeHeader("Runtime/SceneManager/SceneManager.h")]
	[NativeMethod("GetSceneCount")]
	[StaticAccessor("GetSceneManager()", StaticAccessorType::Dot (0))]
	public static int get_sceneCount() { }

	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	public static Scene GetActiveScene() { }

	private static void GetActiveScene_Injected(out Scene ret) { }

	[NativeThrows]
	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	public static Scene GetSceneAt(int index) { }

	private static void GetSceneAt_Injected(int index, out Scene ret) { }

	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	public static Scene GetSceneByName(string name) { }

	private static void GetSceneByName_Injected(ref ManagedSpanWrapper name, out Scene ret) { }

	[RequiredByNativeCode]
	private static void Internal_ActiveSceneChanged(Scene previousActiveScene, Scene newActiveScene) { }

	[RequiredByNativeCode]
	private static void Internal_SceneLoaded(Scene scene, LoadSceneMode mode) { }

	[RequiredByNativeCode]
	private static void Internal_SceneUnloaded(Scene scene) { }

	[RequiredByNativeCode]
	internal static AsyncOperation LoadFirstScene_Internal(bool async) { }

	[ExcludeFromDocs]
	public static void LoadScene(int sceneBuildIndex) { }

	public static Scene LoadScene(int sceneBuildIndex, LoadSceneParameters parameters) { }

	public static Scene LoadScene(string sceneName, LoadSceneParameters parameters) { }

	[ExcludeFromDocs]
	public static void LoadScene(string sceneName) { }

	public static void LoadScene(string sceneName, LoadSceneMode mode) { }

	[ExcludeFromDocs]
	public static AsyncOperation LoadSceneAsync(string sceneName) { }

	public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters) { }

	private static AsyncOperation LoadSceneAsyncNameIndexInternal(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame) { }

	[NativeThrows]
	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	public static void MoveGameObjectToScene(GameObject go, Scene scene) { }

	private static void MoveGameObjectToScene_Injected(IntPtr go, in Scene scene) { }

	[CompilerGenerated]
	public static void remove_activeSceneChanged(UnityAction<Scene, Scene> value) { }

	[CompilerGenerated]
	public static void remove_sceneLoaded(UnityAction<Scene, LoadSceneMode> value) { }

	[CompilerGenerated]
	public static void remove_sceneUnloaded(UnityAction<Scene> value) { }

	[NativeThrows]
	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	public static bool SetActiveScene(Scene scene) { }

	private static bool SetActiveScene_Injected(in Scene scene) { }

	public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options) { }

	public static AsyncOperation UnloadSceneAsync(string sceneName) { }

	public static AsyncOperation UnloadSceneAsync(Scene scene) { }

	[NativeThrows]
	[StaticAccessor("SceneManagerBindings", StaticAccessorType::DoubleColon (2))]
	private static AsyncOperation UnloadSceneAsyncInternal(Scene scene, UnloadSceneOptions options) { }

	private static IntPtr UnloadSceneAsyncInternal_Injected(in Scene scene, UnloadSceneOptions options) { }

	private static AsyncOperation UnloadSceneNameIndexInternal(string sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess) { }

}

