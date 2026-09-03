/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public abstract class Array : IList, IStructuralComparable, IStructuralEquatable, ICloneable // TypeDefIndex: 2392
	{
		// Properties
		int ICollection.Count { get; } // 0x0000000180B23260-0x0000000180B23270 
		bool IList.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		object IList.this[int index] { get => default; set {} } // 0x0000000181614E70-0x0000000181614E80 0x0000000181614E80-0x0000000181614EA0
		public long LongLength { get; } // 0x0000000181615400-0x0000000181615470 
		public bool IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		public int Length { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x00000001816153A0-0x0000000181615400 
		public int Rank { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000181612570-0x0000000181612580 
	
		// Nested types
		private sealed class ArrayEnumerator : IEnumerator, ICloneable // TypeDefIndex: 2393
		{
			// Fields
			private Array _array; // 0x10
			private int _index; // 0x18
			private int _endIndex; // 0x1C
	
			// Properties
			public object Current { get; } // 0x000000018162B810-0x000000018162B980 
	
			// Constructors
			internal ArrayEnumerator(Array array); // 0x000000018162B7C0-0x000000018162B810
	
			// Methods
			public bool MoveNext(); // 0x000000018162B7A0-0x000000018162B7C0
			public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
			public object Clone(); // 0x0000000181560410-0x0000000181560420
		}
	
		private class RawData // TypeDefIndex: 2394
		{
			// Fields
			public IntPtr Bounds; // 0x10
			public IntPtr Count; // 0x18
			public byte Data; // 0x20
		}
	
		internal struct InternalEnumerator<T> : IEnumerator<T> // TypeDefIndex: 2395
		{
			// Fields
			private readonly Array array;
			private int idx;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal InternalEnumerator(Array array);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		internal class EmptyInternalEnumerator<T> : IEnumerator<T> // TypeDefIndex: 2396
		{
			// Fields
			public static readonly EmptyInternalEnumerator<T> Value;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public EmptyInternalEnumerator();
			static EmptyInternalEnumerator();
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			void IEnumerator.Reset();
		}
	
		private struct SorterObjectArray // TypeDefIndex: 2397
		{
			// Fields
			private object[] keys; // 0x00
			private object[] items; // 0x08
			private IComparer comparer; // 0x10
	
			// Constructors
			internal SorterObjectArray(object[] keys, object[] items, IComparer comparer); // 0x000000018164A470-0x000000018164A520
	
			// Methods
			internal void SwapIfGreaterWithItems(int a, int b); // 0x000000018164A030-0x000000018164A290
			private void Swap(int i, int j); // 0x000000018164A290-0x000000018164A470
			internal void Sort(int left, int length); // 0x000000018164A020-0x000000018164A030
			private void IntrospectiveSort(int left, int length); // 0x0000000181649D90-0x0000000181649E80
			private void IntroSort(int lo, int hi, int depthLimit); // 0x0000000181649CB0-0x0000000181649D90
			private int PickPivotAndPartition(int lo, int hi); // 0x0000000181649E80-0x000000018164A020
			private void Heapsort(int lo, int hi); // 0x00000001816498E0-0x00000001816499A0
			private void DownHeap(int i, int n, int lo); // 0x0000000181649500-0x00000001816498E0
			private void InsertionSort(int lo, int hi); // 0x00000001816499A0-0x0000000181649CB0
		}
	
		private struct SorterGenericArray // TypeDefIndex: 2398
		{
			// Fields
			private Array keys; // 0x00
			private Array items; // 0x08
			private IComparer comparer; // 0x10
	
			// Constructors
			internal SorterGenericArray(Array keys, Array items, IComparer comparer); // 0x0000000181649450-0x0000000181649500
	
			// Methods
			internal void SwapIfGreaterWithItems(int a, int b); // 0x00000001816491E0-0x0000000181649360
			private void Swap(int i, int j); // 0x0000000181649360-0x0000000181649450
			internal void Sort(int left, int length); // 0x00000001816491D0-0x00000001816491E0
			private void IntrospectiveSort(int left, int length); // 0x0000000181648F60-0x0000000181649050
			private void IntroSort(int lo, int hi, int depthLimit); // 0x0000000181648E80-0x0000000181648F60
			private int PickPivotAndPartition(int lo, int hi); // 0x0000000181649050-0x00000001816491D0
			private void Heapsort(int lo, int hi); // 0x0000000181648C10-0x0000000181648CD0
			private void DownHeap(int i, int n, int lo); // 0x00000001816489D0-0x0000000181648C10
			private void InsertionSort(int lo, int hi); // 0x0000000181648CD0-0x0000000181648E80
		}
	
		// Constructors
		private Array(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static Array CreateInstance(Type elementType, params long[] lengths); // 0x00000001816122F0-0x00000001816124C0
		public static ReadOnlyCollection<T> AsReadOnly<T>(T[] array);
		public static void Resize<T>(ref ref T[] array, int newSize);
		int IList.Add(object value); // 0x0000000181614B10-0x0000000181614B60
		bool IList.Contains(object value); // 0x0000000181614CF0-0x0000000181614D80
		void IList.Clear(); // 0x0000000181614B60-0x0000000181614CF0
		int IList.IndexOf(object value); // 0x0000000181612F40-0x0000000181612FD0
		void IList.Insert(int index, object value); // 0x0000000181614D80-0x0000000181614DD0
		void IList.Remove(object value); // 0x0000000181614E20-0x0000000181614E70
		void IList.RemoveAt(int index); // 0x0000000181614DD0-0x0000000181614E20
		public void CopyTo(Array array, int index); // 0x0000000181610EB0-0x0000000181610F60
		public object Clone(); // 0x0000000181560410-0x0000000181560420
		int IStructuralComparable.CompareTo(object other, IComparer comparer); // 0x0000000181614EA0-0x0000000181615080
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer); // 0x0000000181615080-0x0000000181615210
		internal static int CombineHashCodes(int h1, int h2); // 0x0000000180BE33E0-0x0000000180BE33F0
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer); // 0x0000000181615210-0x0000000181615380
		public static int BinarySearch(Array array, object value); // 0x00000001816105E0-0x0000000181610670
		public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter);
		public static void Copy(Array sourceArray, Array destinationArray, long length); // 0x0000000181610F60-0x00000001816110E0
		public static void Copy(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length); // 0x00000001816111F0-0x0000000181611360
		public void CopyTo(Array array, long index); // 0x0000000181610D90-0x0000000181610EB0
		public static void ForEach<T>(T[] array, Action<T> action);
		public long GetLongLength(int dimension); // 0x0000000181612540-0x0000000181612550
		public object GetValue(long index); // 0x0000000181612910-0x00000001816129B0
		public object GetValue(long index1, long index2); // 0x00000001816127A0-0x0000000181612900
		public object GetValue(long index1, long index2, long index3); // 0x0000000181612CB0-0x0000000181612EA0
		public object GetValue(params long[] indices); // 0x00000001816129B0-0x0000000181612B80
		public static int BinarySearch(Array array, int index, int length, object value); // 0x0000000181610AD0-0x0000000181610AF0
		public static int BinarySearch(Array array, object value, IComparer comparer); // 0x0000000181610670-0x0000000181610710
		public static int BinarySearch(Array array, int index, int length, object value, IComparer comparer); // 0x0000000181610710-0x0000000181610AD0
		private static int GetMedian(int low, int hi); // 0x0000000181612560-0x0000000181612570
		public static int BinarySearch<T>(T[] array, T value);
		public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer);
		public static int BinarySearch<T>(T[] array, int index, int length, T value);
		public static int BinarySearch<T>(T[] array, int index, int length, T value, IComparer<T> comparer);
		public static int IndexOf(Array array, object value); // 0x0000000181612F40-0x0000000181612FD0
		public static int IndexOf(Array array, object value, int startIndex); // 0x0000000181612EA0-0x0000000181612F40
		public static int IndexOf(Array array, object value, int startIndex, int count); // 0x0000000181612FD0-0x00000001816132D0
		public static int IndexOf<T>(T[] array, T value);
		public static int IndexOf<T>(T[] array, T value, int startIndex);
		public static int IndexOf<T>(T[] array, T value, int startIndex, int count);
		public static int LastIndexOf(Array array, object value); // 0x0000000181613370-0x00000001816133F0
		public static int LastIndexOf(Array array, object value, int startIndex); // 0x00000001816133F0-0x0000000181613470
		public static int LastIndexOf(Array array, object value, int startIndex, int count); // 0x0000000181613470-0x00000001816137E0
		public static int LastIndexOf<T>(T[] array, T value);
		public static int LastIndexOf<T>(T[] array, T value, int startIndex);
		public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count);
		public static void Reverse(Array array); // 0x00000001816137E0-0x0000000181613860
		public static void Reverse(Array array, int index, int length); // 0x0000000181613860-0x0000000181613AD0
		public static void Reverse<T>(T[] array);
		public static void Reverse<T>(T[] array, int index, int length);
		public void SetValue(object value, long index); // 0x0000000181613E10-0x0000000181613EB0
		public void SetValue(object value, long index1, long index2); // 0x0000000181614270-0x00000001816143F0
		public void SetValue(object value, long index1, long index2, long index3); // 0x0000000181613EB0-0x00000001816140B0
		public void SetValue(object value, params long[] indices); // 0x0000000181613B80-0x0000000181613D60
		public static void Sort(Array array); // 0x0000000181614930-0x00000001816149C0
		public static void Sort(Array array, int index, int length); // 0x0000000181614900-0x0000000181614930
		public static void Sort(Array array, IComparer comparer); // 0x00000001816149C0-0x0000000181614A50
		public static void Sort(Array array, int index, int length, IComparer comparer); // 0x0000000181614A50-0x0000000181614A80
		public static void Sort(Array keys, Array items); // 0x0000000181614A80-0x0000000181614B10
		public static void Sort(Array keys, Array items, IComparer comparer); // 0x0000000181614860-0x0000000181614900
		public static void Sort(Array keys, Array items, int index, int length); // 0x0000000181614840-0x0000000181614860
		public static void Sort(Array keys, Array items, int index, int length, IComparer comparer); // 0x0000000181614510-0x0000000181614840
		public static void Sort<T>(T[] array);
		public static void Sort<T>(T[] array, int index, int length);
		public static void Sort<T>(T[] array, IComparer<T> comparer);
		public static void Sort<T>(T[] array, int index, int length, IComparer<T> comparer);
		public static void Sort<T>(T[] array, Comparison<T> comparison);
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items);
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length);
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer);
		public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer);
		public static bool Exists<T>(T[] array, Predicate<T> match);
		public static void Fill<T>(T[] array, T value);
		public static void Fill<T>(T[] array, T value, int startIndex, int count);
		public static T Find<T>(T[] array, Predicate<T> match);
		public static T[] FindAll<T>(T[] array, Predicate<T> match);
		public static int FindIndex<T>(T[] array, Predicate<T> match);
		public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match);
		public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
		public static T FindLast<T>(T[] array, Predicate<T> match);
		public static int FindLastIndex<T>(T[] array, Predicate<T> match);
		public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match);
		public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match);
		public static bool TrueForAll<T>(T[] array, Predicate<T> match);
		public IEnumerator GetEnumerator(); // 0x00000001816124D0-0x0000000181612530
		internal int InternalArray__ICollection_get_Count(); // 0x0000000180B23260-0x0000000180B23270
		internal bool InternalArray__ICollection_get_IsReadOnly(); // 0x00000001802E7990-0x00000001802E79A0
		internal ref byte GetRawSzArrayData(); // 0x0000000181612580-0x00000001816125A0
		internal IEnumerator<T> InternalArray__IEnumerable_GetEnumerator<T>();
		internal void InternalArray__ICollection_Clear(); // 0x00000001816132D0-0x0000000181613320
		internal void InternalArray__ICollection_Add<T>(T item);
		internal bool InternalArray__ICollection_Remove<T>(T item);
		internal bool InternalArray__ICollection_Contains<T>(T item);
		internal void InternalArray__ICollection_CopyTo<T>(T[] array, int arrayIndex);
		internal T InternalArray__IReadOnlyList_get_Item<T>(int index);
		internal int InternalArray__IReadOnlyCollection_get_Count(); // 0x0000000180B23260-0x0000000180B23270
		internal void InternalArray__Insert<T>(int index, T item);
		internal void InternalArray__RemoveAt(int index); // 0x0000000181613320-0x0000000181613370
		internal int InternalArray__IndexOf<T>(T item);
		internal T InternalArray__get_Item<T>(int index);
		internal void InternalArray__set_Item<T>(int index, T item);
		internal void GetGenericValueImpl<T>(int pos, out ref T value);
		internal void SetGenericValueImpl<T>(int pos, ref ref T value);
		private int GetRank(); // 0x0000000181612570-0x0000000181612580
		public int GetLength(int dimension); // 0x0000000181612530-0x0000000181612540
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public int GetLowerBound(int dimension); // 0x0000000181612550-0x0000000181612560
		public object GetValue(params int[] indices); // 0x0000000181612900-0x0000000181612910
		public void SetValue(object value, params int[] indices); // 0x0000000181613E00-0x0000000181613E10
		internal object GetValueImpl(int pos); // 0x00000001816125E0-0x00000001816125F0
		internal void SetValueImpl(object value, int pos); // 0x0000000181613AD0-0x0000000181613AE0
		internal static bool FastCopy(Array source, int source_idx, Array dest, int dest_idx, int length); // 0x00000001816124C0-0x00000001816124D0
		internal static Array CreateInstanceImpl(Type elementType, int[] lengths, int[] bounds); // 0x00000001816119B0-0x00000001816119C0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public int GetUpperBound(int dimension); // 0x00000001816125A0-0x00000001816125E0
		public object GetValue(int index); // 0x00000001816125F0-0x00000001816127A0
		public object GetValue(int index1, int index2); // 0x0000000181612B80-0x0000000181612C10
		public object GetValue(int index1, int index2, int index3); // 0x0000000181612C10-0x0000000181612CB0
		public void SetValue(object value, int index); // 0x00000001816140B0-0x0000000181614270
		public void SetValue(object value, int index1, int index2); // 0x0000000181613D60-0x0000000181613E00
		public void SetValue(object value, int index1, int index2, int index3); // 0x0000000181613AE0-0x0000000181613B80
		internal static Array UnsafeCreateInstance(Type elementType, int[] lengths, int[] lowerBounds); // 0x0000000181615380-0x0000000181615390
		internal static Array UnsafeCreateInstance(Type elementType, int length1, int length2); // 0x0000000181611A30-0x0000000181611AC0
		internal static Array UnsafeCreateInstance(Type elementType, params int[] lengths); // 0x0000000181615390-0x00000001816153A0
		public static Array CreateInstance(Type elementType, int length); // 0x00000001816119C0-0x0000000181611A30
		public static Array CreateInstance(Type elementType, int length1, int length2); // 0x0000000181611A30-0x0000000181611AC0
		public static Array CreateInstance(Type elementType, int length1, int length2, int length3); // 0x0000000181612250-0x00000001816122F0
		public static Array CreateInstance(Type elementType, params int[] lengths); // 0x0000000181611AC0-0x0000000181611D80
		public static Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds); // 0x0000000181611D80-0x0000000181612250
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void Clear(Array array, int index, int length); // 0x0000000181610C00-0x0000000181610D80
		private static void ClearInternal(Array a, int index, int count); // 0x0000000181610BF0-0x0000000181610C00
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, Array destinationArray, int length); // 0x00000001816110E0-0x00000001816111F0
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
		public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length); // 0x0000000181611360-0x0000000181611960
		private static ArrayTypeMismatchException CreateArrayTypeMismatchException(); // 0x0000000181611960-0x00000001816119B0
		private static bool CanAssignArrayElement(Type source, Type target); // 0x0000000181610AF0-0x0000000181610BF0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length); // 0x0000000181610D80-0x0000000181610D90
		public static T[] Empty<T>();
		public void Initialize(); // 0x00000001802E76C0-0x00000001802E76D0
		private static int IndexOfImpl<T>(T[] array, T value, int startIndex, int count);
		private static int LastIndexOfImpl<T>(T[] array, T value, int startIndex, int count);
		private static void SortImpl(Array keys, Array items, int index, int length, IComparer comparer); // 0x00000001816143F0-0x0000000181614510
		internal static T UnsafeLoad<T>(T[] array, int index);
		internal static void UnsafeStore<T>(T[] array, int index, T value);
		internal static R UnsafeMov<S, R>(S instance);
	}
}
