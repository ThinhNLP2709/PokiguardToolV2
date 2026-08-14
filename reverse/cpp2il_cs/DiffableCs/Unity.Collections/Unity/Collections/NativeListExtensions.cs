namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class NativeListExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static bool ArraysEqual(NativeArray<T> container, in NativeList<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static bool ArraysEqual(NativeList<T> container, in NativeArray<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static bool ArraysEqual(NativeList<T> container, in NativeList<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static bool ArraysEqual(NativeList<T> container, in UnsafeList<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(NativeList<T> list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(NativeList<T> list, U value) { }

}

