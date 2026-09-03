/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[DebuggerDisplay("Key = {Key}, Value = {Value}")]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct KeyValue<TKey, TValue> // TypeDefIndex: 11717
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		internal unsafe UnsafeParallelHashMapData* m_Buffer;
		internal int m_Index;
		internal int m_Next;
	
		// Properties
		public static KeyValue<TKey, TValue> Null { get; }
		public TKey Key { get; }
		public ref TValue Value { get; }
	
		// Methods
		public bool GetKeyValue(out ref TKey key, out ref TValue value);
	}
}
