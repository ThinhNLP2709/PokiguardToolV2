namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class FixedList64BytesExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(ref FixedList64Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(ref FixedList64Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Remove(ref FixedList64Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool RemoveSwapBack(ref FixedList64Bytes<T>& list, U value) { }

}

