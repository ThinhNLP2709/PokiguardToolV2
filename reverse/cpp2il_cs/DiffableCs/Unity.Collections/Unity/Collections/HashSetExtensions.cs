namespace Unity.Collections;

[Extension]
public static class HashSetExtensions
{

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeParallelHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void ExceptWith(ref NativeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void IntersectWith(ref NativeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, NativeList<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, NativeParallelHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, ReadOnly<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, NativeHashSet<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, NativeArray<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, FixedList512Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, FixedList4096Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, FixedList32Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeHashSet<T>& container, FixedList128Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, FixedList64Bytes<T> other) { }

	[Extension]
	public static void UnionWith(ref NativeParallelHashSet<T>& container, NativeList<T> other) { }

}

