namespace UnityEngine.Rendering.Universal;

[Extension]
internal static class NativeArrayExtensions
{

	[Extension]
	public static T UnsafeElementAt(NativeArray<T> array, int index) { }

	[Extension]
	public static T UnsafeElementAtMutable(NativeArray<T> array, int index) { }

}

