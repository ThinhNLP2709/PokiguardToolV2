namespace UnityEngine;

[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
public sealed class Resources
{

	internal static T[] ConvertObjects(Object[] rawObjects) { }

	public static Object[] FindObjectsOfTypeAll(Type type) { }

	public static T[] FindObjectsOfTypeAll() { }

	[FreeFunction("GetScriptingBuiltinResource", ThrowsException = True)]
	[TypeInferenceRule(TypeInferenceRules::TypeReferencedByFirstArgument (0))]
	public static object GetBuiltinResource(Type type, string path) { }

	public static T GetBuiltinResource(string path) { }

	private static IntPtr GetBuiltinResource_Injected(Type type, ref ManagedSpanWrapper path) { }

	public static object Load(string path) { }

	public static T Load(string path) { }

	public static object Load(string path, Type systemTypeInstance) { }

	public static Object[] LoadAll(string path, Type systemTypeInstance) { }

	public static T[] LoadAll(string path) { }

	public static ResourceRequest LoadAsync(string path) { }

	public static ResourceRequest LoadAsync(string path, Type type) { }

}

