namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class NativeArrayExtensions
{
	internal struct NativeArrayStaticId
	{
		internal static readonly SharedStatic<Int32> s_staticSafetyId; //Field offset: 0x0

		private static NativeArrayStaticId`1() { }

	}


	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static bool ArraysEqual(NativeArray<T> container, NativeArray<T> other) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckReinterpretSize(ref NativeArray<T>& array) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(NativeArray<T> array, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(ReadOnly<T> array, U value) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(Void* ptr, int length, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void CopyFrom(ref NativeArray<T>& container, NativeList<T> other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void CopyFrom(ref NativeArray<T>& container, in NativeHashSet<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void CopyFrom(ref NativeArray<T>& container, in UnsafeHashSet<T>& other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void DisposeCheckAllocator(ref NativeArray<T>& array) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(NativeArray<T> array, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(ReadOnly<T> array, U value) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(Void* ptr, int length, U value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void Initialize(ref NativeArray<T>& array, int length, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(AllocatorHandle)})]
	internal static void Initialize(ref NativeArray<T>& array, int length, ref U allocator, NativeArrayOptions options = 1) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static NativeArray<U> Reinterpret(NativeArray<T> array) { }

}

