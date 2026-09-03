/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal static class ArrayHelpers // TypeDefIndex: 6588
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass33_0<TValue> // TypeDefIndex: 6589
			where TValue : IEquatable<TValue>
		{
			// Fields
			public TValue secondValue;
	
			// Constructors
			public __c__DisplayClass33_0();
	
			// Methods
			internal bool _Merge_b__0(TValue x);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass34_0<TValue> // TypeDefIndex: 6590
		{
			// Fields
			public IEqualityComparer<TValue> comparer;
	
			// Constructors
			public __c__DisplayClass34_0();
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass34_1<TValue> // TypeDefIndex: 6591
		{
			// Fields
			public TValue secondValue;
			public __c__DisplayClass34_0<TValue> CS___8__locals1;
	
			// Constructors
			public __c__DisplayClass34_1();
	
			// Methods
			internal bool _Merge_b__0(TValue x);
		}
	
		// Methods
		public static void EnsureCapacity<TValue>(ref ref TValue[] array, int count, int capacity, int capacityIncrement = 10 /* Metadata: 0x00699191 */);
		public static void DuplicateWithCapacity<TValue>(ref ref TValue[] array, int count, int capacity, int capacityIncrement = 10 /* Metadata: 0x00699192 */);
		public static bool Contains<TValue>(TValue[] array, TValue value);
		public static bool HaveEqualElements<TValue>(TValue[] first, TValue[] second, int count = 2147483647 /* Metadata: 0x00699193 */);
		public static int IndexOf<TValue>(TValue[] array, TValue value, int startIndex = 0 /* Metadata: 0x00699194 */, int count = -1 /* Metadata: 0x00699195 */);
		public static void Resize<TValue>(ref NativeArray<TValue> array, int newSize, Allocator allocator)
			where TValue : struct;
		public static int Append<TValue>(ref ref TValue[] array, TValue value);
		public static int Append<TValue>(ref ref TValue[] array, IEnumerable<TValue> values);
		public static int AppendToImmutable<TValue>(ref ref TValue[] array, TValue[] values);
		public static int AppendWithCapacity<TValue>(ref ref TValue[] array, ref int count, TValue value, int capacityIncrement = 10 /* Metadata: 0x0069919B */);
		public static int AppendListWithCapacity<TValue, TValues>(ref ref TValue[] array, ref int length, TValues values, int capacityIncrement = 10 /* Metadata: 0x0069919C */)
			where TValues : IReadOnlyList<TValue>;
		public static int AppendWithCapacity<TValue>(ref NativeArray<TValue> array, ref int count, TValue value, int capacityIncrement = 10 /* Metadata: 0x0069919D */, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069919E */)
			where TValue : struct;
		public static void InsertAt<TValue>(ref ref TValue[] array, int index, TValue value);
		public static void InsertAtWithCapacity<TValue>(ref ref TValue[] array, ref int count, int index, TValue value, int capacityIncrement = 10 /* Metadata: 0x0069919F */);
		public static void PutAtIfNotSet<TValue>(ref ref TValue[] array, int index, Func<TValue> valueFn);
		public static int GrowBy<TValue>(ref ref TValue[] array, int count);
		public static int GrowBy<TValue>(ref NativeArray<TValue> array, int count, Allocator allocator = Allocator.Persistent /* Metadata: 0x006991A0 */)
			where TValue : struct;
		public static int GrowWithCapacity<TValue>(ref ref TValue[] array, ref int count, int growBy, int capacityIncrement = 10 /* Metadata: 0x006991A1 */);
		public static int GrowWithCapacity<TValue>(ref NativeArray<TValue> array, ref int count, int growBy, int capacityIncrement = 10 /* Metadata: 0x006991A2 */, Allocator allocator = Allocator.Persistent /* Metadata: 0x006991A3 */)
			where TValue : struct;
		public static TValue[] Join<TValue>(TValue value, params TValue[] values);
		public static TValue[] Merge<TValue>(TValue[] first, TValue[] second)
			where TValue : IEquatable<TValue>;
		public static TValue[] Merge<TValue>(TValue[] first, TValue[] second, IEqualityComparer<TValue> comparer);
		public static void EraseAt<TValue>(ref ref TValue[] array, int index);
		public static void EraseAtWithCapacity<TValue>(NativeArray<TValue> array, ref int count, int index)
			where TValue : struct;
		public static bool Erase<TValue>(ref ref TValue[] array, TValue value);
		public static void EraseAtByMovingTail<TValue>(TValue[] array, ref int count, int index);
		public static TValue[] Copy<TValue>(TValue[] array);
		public static TValue[] Clone<TValue>(TValue[] array)
			where TValue : ICloneable;
		public static TNew[] Select<TOld, TNew>(TOld[] array, Func<TOld, TNew> converter);
		private static void Swap<TValue>(ref ref TValue first, ref ref TValue second);
		public static void MoveSlice<TValue>(TValue[] array, int sourceIndex, int destinationIndex, int count);
		public static void EraseSliceWithCapacity<TValue>(ref ref TValue[] array, ref int length, int index, int count);
	
		// Extension methods
		public static int LengthSafe<TValue>(this TValue[] array);
		public static void Clear<TValue>(this TValue[] array);
		public static void Clear<TValue>(this TValue[] array, int count);
		public static void Clear<TValue>(this TValue[] array, ref int count);
		public static bool ContainsReference<TValue>(this TValue[] array, TValue value)
			where TValue : class;
		public static bool ContainsReference<TFirst, TSecond>(this TFirst[] array, int count, TSecond value)
			where TFirst : TSecond
			where TSecond : class;
		public static bool ContainsReference<TFirst, TSecond>(this TFirst[] array, int startIndex, int count, TSecond value)
			where TFirst : TSecond
			where TSecond : class;
		public static bool HaveDuplicateReferences<TFirst>(this TFirst[] first, int index, int count);
		public static int IndexOf<TValue>(this TValue[] array, Predicate<TValue> predicate);
		public static int IndexOf<TValue>(this TValue[] array, Predicate<TValue> predicate, int startIndex = 0 /* Metadata: 0x00699196 */, int count = -1 /* Metadata: 0x00699197 */);
		public static int IndexOfReference<TFirst, TSecond>(this TFirst[] array, TSecond value, int count = -1 /* Metadata: 0x00699198 */)
			where TFirst : TSecond
			where TSecond : class;
		public static int IndexOfReference<TFirst, TSecond>(this TFirst[] array, TSecond value, int startIndex, int count)
			where TFirst : TSecond
			where TSecond : class;
		public static int IndexOfValue<TValue>(this TValue[] array, TValue value, int startIndex = 0 /* Metadata: 0x00699199 */, int count = -1 /* Metadata: 0x0069919A */)
			where TValue : struct, IEquatable<TValue>;
		public static void EraseAtWithCapacity<TValue>(this TValue[] array, ref int count, int index);
		public static void SwapElements<TValue>(this TValue[] array, int index1, int index2);
		public static void SwapElements<TValue>(this NativeArray<TValue> array, int index1, int index2)
			where TValue : struct;
	}
}
