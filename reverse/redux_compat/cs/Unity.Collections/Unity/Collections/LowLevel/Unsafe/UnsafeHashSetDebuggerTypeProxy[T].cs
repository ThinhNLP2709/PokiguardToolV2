/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	internal sealed class UnsafeHashSetDebuggerTypeProxy<T> // TypeDefIndex: 11696
		where T : struct, IEquatable<T>
	{
		// Fields
		private HashMapHelper<T> Data;
	
		// Properties
		public List<T> Items { get; }
	
		// Constructors
		public UnsafeHashSetDebuggerTypeProxy(UnsafeHashSet<T> data);
	}
}
