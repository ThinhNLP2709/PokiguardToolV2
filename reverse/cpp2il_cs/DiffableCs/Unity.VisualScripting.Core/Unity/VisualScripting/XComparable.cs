namespace Unity.VisualScripting;

[Extension]
internal static class XComparable
{

	[Extension]
	internal static bool IsEq(IComparable<T> x, T y) { }

	[Extension]
	internal static bool IsGt(IComparable<T> x, T y) { }

	[Extension]
	internal static bool IsLt(IComparable<T> x, T y) { }

}

