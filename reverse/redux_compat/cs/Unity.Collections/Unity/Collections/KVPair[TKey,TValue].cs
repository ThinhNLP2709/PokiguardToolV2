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
	[DebuggerDisplay("Key = {Key}, Value = {Value}")]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	public struct KVPair<TKey, TValue> // TypeDefIndex: 11561
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		internal unsafe HashMapHelper<TKey>* m_Data;
		internal int m_Index;
		internal int m_Next;
	
		// Properties
		public static KVPair<TKey, TValue> Null { get; }
		public TKey Key { get; }
		public ref TValue Value { get; }
	
		// Methods
		public bool GetKeyValue(out ref TKey key, out ref TValue value);
	}
}
