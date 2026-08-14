namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class FixedList512BytesExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(ref FixedList512Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(ref FixedList512Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Remove(ref FixedList512Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool RemoveSwapBack(ref FixedList512Bytes<T>& list, U value) { }

}

