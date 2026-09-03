/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[DebuggerDisplay("Size = {size} Capacity = {capacity}")]
	public class DynamicArray<T> // TypeDefIndex: 5360
		where T : new()
	{
		// Fields
		protected T[] m_Array;
		[CompilerGenerated]
		private int _size_k__BackingField;
	
		// Properties
		public int size { [CompilerGenerated] get; [CompilerGenerated] protected set; }
		public int capacity { get; }
		public ref T this[int index] { get => default; }
	
		// Nested types
		public struct Iterator // TypeDefIndex: 5361
		{
			// Fields
			private readonly DynamicArray<T> owner;
			private int index;
	
			// Properties
			public ref T Current { get; }
	
			// Constructors
			public Iterator(DynamicArray<T> setOwner);
	
			// Methods
			public bool MoveNext();
			public void Reset();
		}
	
		public struct RangeEnumerable // TypeDefIndex: 5362
		{
			// Fields
			public RangeIterator iterator;
	
			// Nested types
			public struct RangeIterator // TypeDefIndex: 5363
			{
				// Fields
				private readonly DynamicArray<T> owner;
				private int index;
				private int first;
				private int last;
	
				// Properties
				public ref T Current { get; }
	
				// Constructors
				public RangeIterator(DynamicArray<T> setOwner, int first, int numItems);
	
				// Methods
				public bool MoveNext();
				public void Reset();
			}
	
			// Methods
			public RangeIterator GetEnumerator();
		}
	
		public delegate int SortComparer(T x, T y); // TypeDefIndex: 5364; 0x00000000-0x00000000
	
		// Constructors
		public DynamicArray();
		public DynamicArray(int size);
		public DynamicArray(int capacity, bool resize);
		public DynamicArray(DynamicArray<T> deepCopy);
	
		// Methods
		public void Clear();
		public bool Contains(T item);
		public int Add([IsReadOnly] in ref T value);
		public void AddRange(DynamicArray<T> array);
		public void Insert(int index, T item);
		public bool Remove(T item);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		public int FindIndex(int startIndex, int count, Predicate<T> match);
		public int FindIndex(Predicate<T> match);
		public int IndexOf(T item, int index, int count);
		public int IndexOf(T item, int index);
		public int IndexOf(T item);
		public void Resize(int newSize, bool keepContent = false /* Metadata: 0x006614A1 */);
		public void ResizeAndClear(int newSize);
		public void Reserve(int newCapacity, bool keepContent = false /* Metadata: 0x006614A2 */);
		[Obsolete("This is deprecated because it returns an incorrect value. It may returns an array with elements beyond the size. Please use Span/ReadOnly if you want safe raw access to the DynamicArray memory. #from(2023.2)")]
		public static implicit operator T[](DynamicArray<T> array);
		public static implicit operator ReadOnlySpan<T>(DynamicArray<T> array);
		public static implicit operator Span<T>(DynamicArray<T> array);
		public Iterator GetEnumerator();
		public RangeEnumerable SubRange(int first, int numItems);
		protected internal void BumpVersion();
	}
}
