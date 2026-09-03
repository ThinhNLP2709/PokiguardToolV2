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
	internal sealed class UnsafeParallelMultiHashMapDebuggerTypeProxy<TKey, TValue> // TypeDefIndex: 11737
		where TKey : struct, IEquatable<TKey>, IComparable<TKey>
		where TValue : struct
	{
		// Fields
		private UnsafeParallelMultiHashMap<TKey, TValue> m_Target;
	
		// Properties
		public List<ListPair<TKey, List<TValue>>> Items { get; }
	
		// Constructors
		public UnsafeParallelMultiHashMapDebuggerTypeProxy(UnsafeParallelMultiHashMap<TKey, TValue> target);
	
		// Methods
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray(ref UnsafeParallelMultiHashMap<TKey, TValue> hashMap, AllocatorManager.AllocatorHandle allocator);
	}
}
