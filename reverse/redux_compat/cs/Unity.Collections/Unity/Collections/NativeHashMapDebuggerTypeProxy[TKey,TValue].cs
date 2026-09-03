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
	internal sealed class NativeHashMapDebuggerTypeProxy<TKey, TValue> // TypeDefIndex: 11565
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		private unsafe HashMapHelper<TKey>* Data;
	
		// Properties
		public List<Pair<TKey, TValue>> Items { get; }
	
		// Constructors
		public NativeHashMapDebuggerTypeProxy(NativeHashMap<TKey, TValue> target);
		public NativeHashMapDebuggerTypeProxy(NativeHashMap<TKey, TValue> target);
	}
}
