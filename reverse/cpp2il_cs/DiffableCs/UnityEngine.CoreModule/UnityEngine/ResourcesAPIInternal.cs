namespace UnityEngine;

[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
internal static class ResourcesAPIInternal
{

	[FreeFunction("Resources_Bindings::FindObjectsOfTypeAll")]
	[TypeInferenceRule(TypeInferenceRules::ArrayOfTypeReferencedByFirstArgument (2))]
	public static Object[] FindObjectsOfTypeAll(Type type) { }

	[FreeFunction("GetShaderNameRegistry().FindShader")]
	public static Shader FindShaderByName(string name) { }

	private static IntPtr FindShaderByName_Injected(ref ManagedSpanWrapper name) { }

	[FreeFunction("Resources_Bindings::Load")]
	[NativeThrows]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedBySecondArgument (1))]
	public static object Load(string path, Type systemTypeInstance) { }

	private static IntPtr Load_Injected(ref ManagedSpanWrapper path, Type systemTypeInstance) { }

	[FreeFunction("Resources_Bindings::LoadAll")]
	[NativeThrows]
	public static Object[] LoadAll(string path, Type systemTypeInstance) { }

	private static Object[] LoadAll_Injected(ref ManagedSpanWrapper path, Type systemTypeInstance) { }

	[FreeFunction("Resources_Bindings::LoadAsyncInternal")]
	internal static ResourceRequest LoadAsyncInternal(string path, Type type) { }

	private static IntPtr LoadAsyncInternal_Injected(ref ManagedSpanWrapper path, Type type) { }

}

