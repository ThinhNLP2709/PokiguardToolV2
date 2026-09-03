/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public sealed class EventHandlerList // TypeDefIndex: 8812
	{
		// Fields
		private ListEntry _head; // 0x10
		private Component _parent; // 0x18
	
		// Properties
		public Delegate this[object key] { get => default; } // 0x0000000181B90680-0x0000000181B906E0 
	
		// Nested types
		private sealed class ListEntry // TypeDefIndex: 8813
		{
			// Fields
			internal ListEntry _next; // 0x10
			internal object _key; // 0x18
			internal Delegate _handler; // 0x20
		}
	
		// Methods
		private ListEntry Find(object key); // 0x0000000181B90660-0x0000000181B90680
	}
}
