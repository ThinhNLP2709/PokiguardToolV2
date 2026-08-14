namespace UnityEngine.Bindings;

[VisibleToOtherModules]
internal static class ThrowHelper
{

	[DoesNotReturn]
	public static void ThrowArgumentNullException(object obj, string parameterName) { }

	[DoesNotReturn]
	public static void ThrowNullReferenceException(object obj) { }

}

