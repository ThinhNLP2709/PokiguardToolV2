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

namespace System.Threading
{
	internal class SparselyPopulatedArrayFragment<T> // TypeDefIndex: 2560
		where T : class
	{
		// Fields
		internal readonly T[] _elements;
		internal int _freeCount;
		internal SparselyPopulatedArrayFragment<T> _next;
		internal SparselyPopulatedArrayFragment<T> _prev;
	
		// Properties
		internal T this[int index] { get => default; }
		internal int Length { get; }
		internal SparselyPopulatedArrayFragment<T> Prev { get; }
	
		// Constructors
		internal SparselyPopulatedArrayFragment(int size);
		internal SparselyPopulatedArrayFragment(int size, SparselyPopulatedArrayFragment<T> prev);
	
		// Methods
		internal T SafeAtomicRemove(int index, T expectedElement);
	}
}
