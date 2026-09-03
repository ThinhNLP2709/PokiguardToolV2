/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>> // TypeDefIndex: 3570
	{
		// Properties
		TValue this[TKey key] { get => default; set {} }
		ICollection<TKey> Keys { get; }
		ICollection<TValue> Values { get; }
	
		// Methods
		bool ContainsKey(TKey key);
		void Add(TKey key, TValue value);
		bool Remove(TKey key);
		bool TryGetValue(TKey key, out ref TValue value);
	}
}
