namespace UnityEngine;

[NativeHeader("Runtime/Utilities/PropertyName.h")]
internal class PropertyNameUtils
{

	[FreeFunction("PropertyNameFromStringICall", IsThreadSafe = True)]
	public static PropertyName PropertyNameFromString(string name) { }

	private static void PropertyNameFromString_Injected(ref ManagedSpanWrapper name, out PropertyName ret) { }

}

