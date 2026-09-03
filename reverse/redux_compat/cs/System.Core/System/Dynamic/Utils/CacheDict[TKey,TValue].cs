/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic.Utils
{
	internal sealed class CacheDict<TKey, TValue> // TypeDefIndex: 12585
	{
		// Fields
		private readonly int _mask;
		private readonly Entry[] _entries;
	
		// Properties
		internal TValue this[TKey key] { set {} }
	
		// Nested types
		private sealed class Entry // TypeDefIndex: 12586
		{
			// Fields
			internal readonly int _hash;
			internal readonly TKey _key;
			internal readonly TValue _value;
	
			// Constructors
			internal Entry(int hash, TKey key, TValue value);
		}
	
		// Constructors
		internal CacheDict(int size);
	
		// Methods
		private static int AlignSize(int size);
		internal bool TryGetValue(TKey key, out ref TValue value);
		internal void Add(TKey key, TValue value);
	}
}
