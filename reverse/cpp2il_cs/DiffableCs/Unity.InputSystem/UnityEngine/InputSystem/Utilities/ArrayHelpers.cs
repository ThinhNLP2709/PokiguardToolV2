namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class ArrayHelpers
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public TValue secondValue; //Field offset: 0x0

		public <>c__DisplayClass33_0`1() { }

		internal bool <Merge>b__0(TValue x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public IEqualityComparer<TValue> comparer; //Field offset: 0x0

		public <>c__DisplayClass34_0`1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_1
	{
		public TValue secondValue; //Field offset: 0x0
		public <>c__DisplayClass34_0<TValue> CS$<>8__locals1; //Field offset: 0x0

		public <>c__DisplayClass34_1`1() { }

		internal bool <Merge>b__0(TValue x) { }

	}


	public static int Append(ref TValue[] array, TValue value) { }

	public static int Append(ref TValue[] array, IEnumerable<TValue> values) { }

	public static int AppendListWithCapacity(ref TValue[] array, ref int length, TValues values, int capacityIncrement = 10) { }

	public static int AppendToImmutable(ref TValue[] array, TValue[] values) { }

	public static int AppendWithCapacity(ref TValue[] array, ref int count, TValue value, int capacityIncrement = 10) { }

	public static int AppendWithCapacity(ref NativeArray<TValue>& array, ref int count, TValue value, int capacityIncrement = 10, Allocator allocator = 4) { }

	[Extension]
	public static void Clear(TValue[] array, ref int count) { }

	[Extension]
	public static void Clear(TValue[] array) { }

	[Extension]
	public static void Clear(TValue[] array, int count) { }

	public static TValue[] Clone(TValue[] array) { }

	public static bool Contains(TValue[] array, TValue value) { }

	[Extension]
	public static bool ContainsReference(TFirst[] array, int startIndex, int count, TSecond value) { }

	[Extension]
	public static bool ContainsReference(TFirst[] array, int count, TSecond value) { }

	[Extension]
	public static bool ContainsReference(TValue[] array, TValue value) { }

	public static TValue[] Copy(TValue[] array) { }

	public static void DuplicateWithCapacity(ref TValue[] array, int count, int capacity, int capacityIncrement = 10) { }

	public static void EnsureCapacity(ref TValue[] array, int count, int capacity, int capacityIncrement = 10) { }

	public static bool Erase(ref TValue[] array, TValue value) { }

	public static void EraseAt(ref TValue[] array, int index) { }

	public static void EraseAtByMovingTail(TValue[] array, ref int count, int index) { }

	public static void EraseAtWithCapacity(NativeArray<TValue> array, ref int count, int index) { }

	[Extension]
	public static void EraseAtWithCapacity(TValue[] array, ref int count, int index) { }

	public static void EraseSliceWithCapacity(ref TValue[] array, ref int length, int index, int count) { }

	public static int GrowBy(ref TValue[] array, int count) { }

	public static int GrowBy(ref NativeArray<TValue>& array, int count, Allocator allocator = 4) { }

	public static int GrowWithCapacity(ref TValue[] array, ref int count, int growBy, int capacityIncrement = 10) { }

	public static int GrowWithCapacity(ref NativeArray<TValue>& array, ref int count, int growBy, int capacityIncrement = 10, Allocator allocator = 4) { }

	[Extension]
	public static bool HaveDuplicateReferences(TFirst[] first, int index, int count) { }

	public static bool HaveEqualElements(TValue[] first, TValue[] second, int count = 2147483647) { }

	[Extension]
	public static int IndexOf(TValue[] array, Predicate<TValue> predicate) { }

	public static int IndexOf(TValue[] array, TValue value, int startIndex = 0, int count = -1) { }

	[Extension]
	public static int IndexOf(TValue[] array, Predicate<TValue> predicate, int startIndex = 0, int count = -1) { }

	[Extension]
	public static int IndexOfReference(TFirst[] array, TSecond value, int count = -1) { }

	[Extension]
	public static int IndexOfReference(TFirst[] array, TSecond value, int startIndex, int count) { }

	[Extension]
	public static int IndexOfValue(TValue[] array, TValue value, int startIndex = 0, int count = -1) { }

	public static void InsertAt(ref TValue[] array, int index, TValue value) { }

	public static void InsertAtWithCapacity(ref TValue[] array, ref int count, int index, TValue value, int capacityIncrement = 10) { }

	public static TValue[] Join(TValue value, TValue[] values) { }

	[Extension]
	public static int LengthSafe(TValue[] array) { }

	public static TValue[] Merge(TValue[] first, TValue[] second) { }

	public static TValue[] Merge(TValue[] first, TValue[] second, IEqualityComparer<TValue> comparer) { }

	public static void MoveSlice(TValue[] array, int sourceIndex, int destinationIndex, int count) { }

	public static void PutAtIfNotSet(ref TValue[] array, int index, Func<TValue> valueFn) { }

	public static void Resize(ref NativeArray<TValue>& array, int newSize, Allocator allocator) { }

	public static TNew[] Select(TOld[] array, Func<TOld, TNew> converter) { }

	private static void Swap(ref TValue first, ref TValue second) { }

	[Extension]
	public static void SwapElements(TValue[] array, int index1, int index2) { }

	[Extension]
	public static void SwapElements(NativeArray<TValue> array, int index1, int index2) { }

}

