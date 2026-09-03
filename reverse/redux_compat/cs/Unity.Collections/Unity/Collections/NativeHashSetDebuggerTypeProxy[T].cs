/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	internal sealed class NativeHashSetDebuggerTypeProxy<T> // TypeDefIndex: 11569
		where T : struct, IEquatable<T>
	{
		// Fields
		private unsafe HashMapHelper<T>* Data;
	
		// Properties
		public List<T> Items { get; }
	
		// Constructors
		public NativeHashSetDebuggerTypeProxy(NativeHashSet<T> data);
	}
}
