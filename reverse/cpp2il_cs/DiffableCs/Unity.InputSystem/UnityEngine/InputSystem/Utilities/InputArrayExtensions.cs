namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class InputArrayExtensions
{

	[Extension]
	public static bool Contains(InlinedArray<TValue> array, TValue value) { }

	[Extension]
	public static bool ContainsReference(InlinedArray<TValue> array, TValue value) { }

	[Extension]
	public static int IndexOfReference(InlinedArray<TValue> array, TValue value) { }

}

