namespace UnityEngine.InputSystem.Utilities;

[Extension]
public static class ReadOnlyArrayExtensions
{

	[Extension]
	public static bool Contains(ReadOnlyArray<TValue> array, TValue value) { }

	[Extension]
	public static bool ContainsReference(ReadOnlyArray<TValue> array, TValue value) { }

	[Extension]
	internal static bool HaveEqualReferences(ReadOnlyArray<TValue> array1, IReadOnlyList<TValue> array2, int count = 2147483647) { }

	[Extension]
	public static int IndexOfReference(ReadOnlyArray<TValue> array, TValue value) { }

}

