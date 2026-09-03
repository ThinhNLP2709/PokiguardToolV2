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
	public interface IList : ICollection // TypeDefIndex: 3497
	{
		// Properties
		object this[int index] { get => default; set {} }
		bool IsReadOnly { get; }
		bool IsFixedSize { get; }
	
		// Methods
		int Add(object value);
		bool Contains(object value);
		void Clear();
		int IndexOf(object value);
		void Insert(int index, object value);
		void Remove(object value);
		void RemoveAt(int index);
	}
}
