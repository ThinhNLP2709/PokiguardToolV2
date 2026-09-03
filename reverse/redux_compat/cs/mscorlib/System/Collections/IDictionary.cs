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

namespace System.Collections
{
	public interface IDictionary : ICollection // TypeDefIndex: 3492
	{
		// Properties
		object this[object key] { get => default; set {} }
		ICollection Keys { get; }
		ICollection Values { get; }
		bool IsReadOnly { get; }
		bool IsFixedSize { get; }
	
		// Methods
		bool Contains(object key);
		void Add(object key, object value);
		void Clear();
		IDictionaryEnumerator GetEnumerator();
		void Remove(object key);
	}
}
