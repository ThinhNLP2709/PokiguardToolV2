/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	internal struct LargeArrayBuilder<T> // TypeDefIndex: 3589
	{
		// Fields
		private readonly int _maxCapacity;
		private T[] _first;
		private ArrayBuilder<T[]> _buffers;
		private T[] _current;
		private int _index;
		private int _count;
	
		// Constructors
		public LargeArrayBuilder(bool initialize);
		public LargeArrayBuilder(int maxCapacity);
	
		// Methods
		public void AddRange(IEnumerable<T> items);
		private void AddWithBufferAllocation(T item, ref ref T[] destination, ref int index);
		public void CopyTo(T[] array, int arrayIndex, int count);
		public T[] GetBuffer(int index);
		public T[] ToArray();
		public bool TryMove(out ref T[] array);
		private void AllocateBuffer();
	}
}
