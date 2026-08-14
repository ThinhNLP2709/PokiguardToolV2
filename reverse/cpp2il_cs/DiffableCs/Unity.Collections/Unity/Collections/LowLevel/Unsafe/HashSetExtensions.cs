namespace Unity.Collections.LowLevel.Unsafe;

[Extension]
public static class HashSetExtensions
{

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref UnsafeParallelHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, UnsafeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, UnsafeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, UnsafeList<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref UnsafeParallelHashSet<T>& container, UnsafeList<T> other) { }

}

