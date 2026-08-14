namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class FixedList4096BytesExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(ref FixedList4096Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(ref FixedList4096Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Remove(ref FixedList4096Bytes<T>& list, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool RemoveSwapBack(ref FixedList4096Bytes<T>& list, U value) { }

}

