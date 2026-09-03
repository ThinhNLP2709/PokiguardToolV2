/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	internal sealed class NativeListDebugView<T> // TypeDefIndex: 11576
		where T : struct
	{
		// Fields
		private unsafe UnsafeList<T>* Data;
	
		// Properties
		public T[] Items { get; }
	
		// Constructors
		public NativeListDebugView(NativeList<T> array);
	}
}
