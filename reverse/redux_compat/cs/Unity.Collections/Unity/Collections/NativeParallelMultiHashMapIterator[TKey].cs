/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	public struct NativeParallelMultiHashMapIterator<TKey> // TypeDefIndex: 11591
		where TKey : struct
	{
		// Fields
		internal TKey key;
		internal int NextEntryIndex;
		internal int EntryIndex;
	
		// Methods
		public int GetEntryIndex();
	}
}
