/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	internal sealed class UnsafeHashMapDebuggerTypeProxy<TKey, TValue> // TypeDefIndex: 11692
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		private HashMapHelper<TKey> Data;
	
		// Properties
		public List<Pair<TKey, TValue>> Items { get; }
	
		// Constructors
		public UnsafeHashMapDebuggerTypeProxy(UnsafeHashMap<TKey, TValue> target);
		public UnsafeHashMapDebuggerTypeProxy(UnsafeHashMap<TKey, TValue> target);
	}
}
