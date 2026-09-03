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
	internal class SparselyPopulatedArray<T> // TypeDefIndex: 2558
		where T : class
	{
		// Fields
		private readonly SparselyPopulatedArrayFragment<T> _head;
		private SparselyPopulatedArrayFragment<T> _tail;
	
		// Properties
		internal SparselyPopulatedArrayFragment<T> Tail { get; }
	
		// Constructors
		internal SparselyPopulatedArray(int initialSize);
	
		// Methods
		internal SparselyPopulatedArrayAddInfo<T> Add(T element);
	}
}
