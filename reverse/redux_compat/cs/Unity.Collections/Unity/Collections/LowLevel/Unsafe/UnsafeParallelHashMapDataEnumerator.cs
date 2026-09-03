/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	internal struct UnsafeParallelHashMapDataEnumerator // TypeDefIndex: 11718
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeParallelHashMapData* m_Buffer; // 0x00
		internal int m_Index; // 0x08
		internal int m_BucketIndex; // 0x0C
		internal int m_NextIndex; // 0x10
	
		// Constructors
		internal unsafe UnsafeParallelHashMapDataEnumerator(UnsafeParallelHashMapData* data); // 0x000000018112DDA0-0x000000018112DDC0
	
		// Methods
		internal bool MoveNext(); // 0x0000000181CABDD0-0x0000000181CABE80
		internal void Reset(); // 0x000000018112AC30-0x000000018112AC50
		internal KeyValue<TKey, TValue> GetCurrent<TKey, TValue>()
			where TKey : struct, IEquatable<TKey>
			where TValue : struct;
		internal TKey GetCurrentKey<TKey>()
			where TKey : struct, IEquatable<TKey>;
	}
}
