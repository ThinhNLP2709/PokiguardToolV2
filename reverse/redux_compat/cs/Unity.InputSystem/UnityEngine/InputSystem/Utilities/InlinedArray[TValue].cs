/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct InlinedArray<TValue> : IEnumerable<TValue> // TypeDefIndex: 6600
	{
		// Fields
		public int length;
		public TValue firstValue;
		public TValue[] additionalValues;
	
		// Properties
		public int Capacity { get; }
		public TValue this[int index] { get => default; set {} }
	
		// Nested types
		private struct Enumerator : IEnumerator<TValue> // TypeDefIndex: 6601
		{
			// Fields
			public InlinedArray<TValue> array;
			public int index;
	
			// Properties
			public TValue Current { get; }
			object IEnumerator.Current { get; }
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		public InlinedArray(TValue value);
		public InlinedArray(TValue firstValue, params TValue[] additionalValues);
		public InlinedArray(IEnumerable<TValue> values);
	
		// Methods
		public void Clear();
		public void ClearWithCapacity();
		public InlinedArray<TValue> Clone();
		public void SetLength(int size);
		public TValue[] ToArray();
		public TOther[] ToArray<TOther>(Func<TValue, TOther> mapFunction);
		public int IndexOf(TValue value);
		public int Append(TValue value);
		public int AppendWithCapacity(TValue value, int capacityIncrement = 10 /* Metadata: 0x006991AC */);
		public void AssignWithCapacity(InlinedArray<TValue> values);
		public void Append(IEnumerable<TValue> values);
		public void Remove(TValue value);
		public void RemoveAtWithCapacity(int index);
		public void RemoveAt(int index);
		public void RemoveAtByMovingTailWithCapacity(int index);
		public bool RemoveByMovingTailWithCapacity(TValue value);
		public bool Contains(TValue value, IEqualityComparer<TValue> comparer);
		public void Merge(InlinedArray<TValue> other);
		public IEnumerator<TValue> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
