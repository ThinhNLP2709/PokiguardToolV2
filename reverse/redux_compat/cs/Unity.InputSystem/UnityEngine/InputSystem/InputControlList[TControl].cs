/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[DebuggerDisplay("Count = {Count}")]
	public struct InputControlList<TControl> : IList<TControl>, IReadOnlyList<TControl>, IDisposable // TypeDefIndex: 6143
		where TControl : InputControl
	{
		// Fields
		private int m_Count;
		private NativeArray<ulong> m_Indices;
		private readonly Allocator m_Allocator;
		private const ulong kInvalidIndex = 18446744073709551615; // Metadata: 0x00698A2F
	
		// Properties
		public int Count { get; }
		public int Capacity { get; set; }
		public bool IsReadOnly { get; }
		public TControl this[int index] { get => default; set {} }
	
		// Nested types
		private struct Enumerator : IEnumerator<TControl> // TypeDefIndex: 6144
		{
			// Fields
			private readonly unsafe ulong* m_Indices;
			private readonly int m_Count;
			private int m_Current;
	
			// Properties
			public TControl Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public unsafe Enumerator(InputControlList<TControl> list);
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		public InputControlList(Allocator allocator, int initialCapacity = 0 /* Metadata: 0x00698A25 */);
		public InputControlList(IEnumerable<TControl> values, Allocator allocator = Allocator.Persistent /* Metadata: 0x00698A26 */);
		public InputControlList(params TControl[] values);
	
		// Methods
		public void Resize(int size);
		public void Add(TControl item);
		public void AddSlice<TList>(TList list, int count = -1 /* Metadata: 0x00698A27 */, int destinationIndex = -1 /* Metadata: 0x00698A28 */, int sourceIndex = 0 /* Metadata: 0x00698A29 */)
			where TList : IReadOnlyList<TControl>;
		public void AddRange(IEnumerable<TControl> list, int count = -1 /* Metadata: 0x00698A2A */, int destinationIndex = -1 /* Metadata: 0x00698A2B */);
		public bool Remove(TControl item);
		public void RemoveAt(int index);
		public void CopyTo(TControl[] array, int arrayIndex);
		public int IndexOf(TControl item);
		public int IndexOf(TControl item, int startIndex, int count = -1 /* Metadata: 0x00698A2C */);
		public void Insert(int index, TControl item);
		public void Clear();
		public bool Contains(TControl item);
		public bool Contains(TControl item, int startIndex, int count = -1 /* Metadata: 0x00698A2D */);
		public void SwapElements(int index1, int index2);
		public void Sort<TCompare>(int startIndex, int count, TCompare comparer)
			where TCompare : IComparer<TControl>;
		public TControl[] ToArray(bool dispose = false /* Metadata: 0x00698A2E */);
		internal void AppendTo(ref ref TControl[] array, ref int count);
		public void Dispose();
		public IEnumerator<TControl> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public override string ToString();
		private static ulong ToIndex(TControl control);
		private static TControl FromIndex(ulong index);
	}
}
