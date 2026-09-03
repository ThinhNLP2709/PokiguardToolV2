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
	internal struct SparselyPopulatedArrayAddInfo<T> // TypeDefIndex: 2559
		where T : class
	{
		// Fields
		private SparselyPopulatedArrayFragment<T> _source;
		private int _index;
	
		// Properties
		internal SparselyPopulatedArrayFragment<T> Source { get; }
		internal int Index { get; }
	
		// Constructors
		internal SparselyPopulatedArrayAddInfo(SparselyPopulatedArrayFragment<T> source, int index);
	}
}
