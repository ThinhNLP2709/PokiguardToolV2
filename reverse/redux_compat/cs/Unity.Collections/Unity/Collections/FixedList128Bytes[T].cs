/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[Serializable]
	[DebuggerTypeProxy(typeof(FixedList128BytesDebugView<T>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct FixedList128Bytes<T> : INativeList<T>, IEnumerable<T>, IEquatable<Unity.Collections.FixedList32Bytes<T>>, IComparable<Unity.Collections.FixedList32Bytes<T>>, IEquatable<Unity.Collections.FixedList64Bytes<T>>, IComparable<Unity.Collections.FixedList64Bytes<T>>, IEquatable<Unity.Collections.FixedList128Bytes<T>>, IComparable<Unity.Collections.FixedList128Bytes<T>>, IEquatable<Unity.Collections.FixedList512Bytes<T>>, IComparable<Unity.Collections.FixedList512Bytes<T>>, IEquatable<Unity.Collections.FixedList4096Bytes<T>>, IComparable<Unity.Collections.FixedList4096Bytes<T>> // TypeDefIndex: 11504
		where T : struct
	{
		// Fields
		[SerializeField]
		internal FixedBytes128Align8 data;
	
		// Properties
		internal ushort length { [IsReadOnly] get; set; }
		internal unsafe byte* buffer { [IsReadOnly] get; }
		[CreateProperty]
		public int Length { [IsReadOnly] get; set; }
		[CreateProperty]
		private IEnumerable<T> Elements { get; }
		public bool IsEmpty { [IsReadOnly] get; }
		internal int LengthInBytes { get; }
		internal unsafe byte* Buffer { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public T this[int index] { [IsReadOnly] get => default; set {} }
	
		// Nested types
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 11505
		{
			// Fields
			private FixedList128Bytes<T> m_List;
			private int m_Index;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator(ref FixedList128Bytes<T> list);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public FixedList128Bytes([IsReadOnly] in FixedList32Bytes<T> other);
		public FixedList128Bytes([IsReadOnly] in FixedList64Bytes<T> other);
		public FixedList128Bytes([IsReadOnly] in FixedList512Bytes<T> other);
		public FixedList128Bytes([IsReadOnly] in FixedList4096Bytes<T> other);
	
		// Methods
		[WriteAccessRequired]
		public unsafe T* GetUnsafePtr();
		[IsReadOnly]
		public unsafe T* GetUnsafeReadOnlyPtr();
		[WriteAccessRequired]
		public static implicit operator Span<T>([IsReadOnly] in FixedList128Bytes<T> container);
		public static implicit operator ReadOnlySpan<T>([IsReadOnly] in FixedList128Bytes<T> container);
		[WriteAccessRequired]
		public Span<T> AsSpan();
		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan();
		public ref ref T ElementAt(int index);
		public override int GetHashCode();
		public void Add([IsReadOnly] in ref T item);
		public unsafe void AddRange(void* ptr, int length);
		public void AddRange(ReadOnlySpan<T> roSpan);
		public void AddNoResize([IsReadOnly] in ref T item);
		public unsafe void AddRangeNoResize(void* ptr, int length);
		public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
		public void AddReplicate([IsReadOnly] in ref T value, int count);
		public void Clear();
		public void InsertRangeWithBeginEnd(int begin, int end);
		public void InsertRange(int index, int count);
		public void Insert(int index, [IsReadOnly] in ref T item);
		public void RemoveAtSwapBack(int index);
		public void RemoveRangeSwapBack(int index, int count);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public T[] ToArray();
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
		public static bool operator ==([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList32Bytes<T> b);
		public static bool operator !=([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList32Bytes<T> b);
		public int CompareTo(FixedList32Bytes<T> other);
		public bool Equals(FixedList32Bytes<T> other);
		internal int Initialize([IsReadOnly] in FixedList32Bytes<T> other);
		public static implicit operator FixedList128Bytes<T>([IsReadOnly] in FixedList32Bytes<T> other);
		public static bool operator ==([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList64Bytes<T> b);
		public static bool operator !=([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList64Bytes<T> b);
		public int CompareTo(FixedList64Bytes<T> other);
		public bool Equals(FixedList64Bytes<T> other);
		internal int Initialize([IsReadOnly] in FixedList64Bytes<T> other);
		public static implicit operator FixedList128Bytes<T>([IsReadOnly] in FixedList64Bytes<T> other);
		public static bool operator ==([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList128Bytes<T> b);
		public static bool operator !=([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList128Bytes<T> b);
		public int CompareTo(FixedList128Bytes<T> other);
		public bool Equals(FixedList128Bytes<T> other);
		public static bool operator ==([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList512Bytes<T> b);
		public static bool operator !=([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList512Bytes<T> b);
		public int CompareTo(FixedList512Bytes<T> other);
		public bool Equals(FixedList512Bytes<T> other);
		internal int Initialize([IsReadOnly] in FixedList512Bytes<T> other);
		public static implicit operator FixedList128Bytes<T>([IsReadOnly] in FixedList512Bytes<T> other);
		public static bool operator ==([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList4096Bytes<T> b);
		public static bool operator !=([IsReadOnly] in FixedList128Bytes<T> a, [IsReadOnly] in FixedList4096Bytes<T> b);
		public int CompareTo(FixedList4096Bytes<T> other);
		public bool Equals(FixedList4096Bytes<T> other);
		internal int Initialize([IsReadOnly] in FixedList4096Bytes<T> other);
		public static implicit operator FixedList128Bytes<T>([IsReadOnly] in FixedList4096Bytes<T> other);
		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public override bool Equals(object obj);
		public Enumerator GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
	}
}
