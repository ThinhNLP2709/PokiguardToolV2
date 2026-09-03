/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	internal sealed class NativeParallelMultiHashMapDebuggerTypeProxy<TKey, TValue> // TypeDefIndex: 11597
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		private NativeParallelMultiHashMap<TKey, TValue> m_Target;
	
		// Properties
		public List<ListPair<TKey, List<TValue>>> Items { get; }
	
		// Constructors
		public NativeParallelMultiHashMapDebuggerTypeProxy(NativeParallelMultiHashMap<TKey, TValue> target);
	}
}
