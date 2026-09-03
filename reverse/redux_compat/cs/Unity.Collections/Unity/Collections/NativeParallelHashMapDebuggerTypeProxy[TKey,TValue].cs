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
	internal sealed class NativeParallelHashMapDebuggerTypeProxy<TKey, TValue> // TypeDefIndex: 11583
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		private UnsafeParallelHashMap<TKey, TValue> m_Target;
	
		// Properties
		public List<Pair<TKey, TValue>> Items { get; }
	
		// Constructors
		public NativeParallelHashMapDebuggerTypeProxy(NativeParallelHashMap<TKey, TValue> target);
		internal NativeParallelHashMapDebuggerTypeProxy(NativeParallelHashMap<TKey, TValue> target);
	}
}
