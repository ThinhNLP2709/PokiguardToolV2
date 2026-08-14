namespace Unity.Collections.LowLevel.Unsafe;

[Extension]
[GenerateTestsForBurstCompatibility]
internal static class UnsafePtrListExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static UnsafeList<IntPtr>& ListData(ref UnsafePtrList<T>& from) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static UnsafeList<IntPtr> ListDataRO(UnsafePtrList<T> from) { }

}

