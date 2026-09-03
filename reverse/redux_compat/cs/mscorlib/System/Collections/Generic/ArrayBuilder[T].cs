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
	internal struct ArrayBuilder<T> // TypeDefIndex: 3587
	{
		// Fields
		private T[] _array;
		private int _count;
	
		// Properties
		public int Capacity { get; }
		public int Count { get; }
		public T this[int index] { get => default; }
	
		// Methods
		public void Add(T item);
		public void UncheckedAdd(T item);
		private void EnsureCapacity(int minimum);
	}
}
