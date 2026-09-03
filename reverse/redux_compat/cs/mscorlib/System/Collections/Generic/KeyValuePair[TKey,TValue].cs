/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	[IsReadOnly]
	public struct KeyValuePair<TKey, TValue> // TypeDefIndex: 3583
	{
		// Fields
		private readonly TKey key;
		private readonly TValue value;
	
		// Properties
		public TKey Key { get; }
		public TValue Value { get; }
	
		// Constructors
		public KeyValuePair(TKey key, TValue value);
	
		// Methods
		public override string ToString();
		public void Deconstruct(out ref TKey key, out ref TValue value);
	}
}
