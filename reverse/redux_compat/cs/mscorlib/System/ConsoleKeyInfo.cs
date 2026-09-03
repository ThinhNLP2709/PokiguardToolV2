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

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct ConsoleKeyInfo // TypeDefIndex: 2382
	{
		// Fields
		private readonly char _keyChar; // 0x00
		private readonly ConsoleKey _key; // 0x04
		private readonly ConsoleModifiers _mods; // 0x08
	
		// Properties
		public char KeyChar { get; } // 0x000000018123AD30-0x000000018123AD40 
		public ConsoleKey Key { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
		// Constructors
		public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control); // 0x00000001816156B0-0x0000000181615760
	
		// Methods
		public override bool Equals(object value); // 0x00000001816155E0-0x0000000181615690
		public bool Equals(ConsoleKeyInfo obj); // 0x00000001816155C0-0x00000001816155E0
		public override int GetHashCode(); // 0x0000000181615690-0x00000001816156B0
	}
}
