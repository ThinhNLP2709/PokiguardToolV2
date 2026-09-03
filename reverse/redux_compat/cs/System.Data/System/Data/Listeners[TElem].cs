/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class Listeners<TElem> // TypeDefIndex: 11319
		where TElem : class
	{
		// Fields
		private readonly List<TElem> _listeners;
		private readonly Func<bool> _filter;
		private readonly int _objectID;
		private int _listenerReaderCount;
	
		// Properties
		internal bool HasListeners { get; }
	
		// Nested types
		internal delegate void Action<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4); // TypeDefIndex: 11320; 0x00000000-0x00000000
	
		internal delegate TResult Func<T1, TResult>(T1 arg1); // TypeDefIndex: 11321; 0x00000000-0x00000000
	
		// Constructors
		internal Listeners(int ObjectID, Func<bool> notifyFilter);
	
		// Methods
		internal void Add(TElem listener);
		internal int IndexOfReference(TElem listener);
		internal void Remove(TElem listener);
		internal void Notify<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3, Action<T1, T2, T3> action);
		private void RemoveNullListeners(int nullIndex);
	}
}
