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
	internal class WindowsConsoleDriver : IConsoleDriver // TypeDefIndex: 2514
	{
		// Fields
		private IntPtr inputHandle; // 0x10
		private IntPtr outputHandle; // 0x18
		private short defaultAttribute; // 0x20
	
		// Constructors
		public WindowsConsoleDriver(); // 0x000000018167A240-0x000000018167A330
	
		// Methods
		public ConsoleKeyInfo ReadKey(bool intercept); // 0x0000000181679FF0-0x000000018167A240
		private static bool IsModifierKey(short virtualKeyCode); // 0x0000000181679E90-0x0000000181679EC0
		private static extern IntPtr GetStdHandle(Handles handle); // 0x0000000181679E00-0x0000000181679E90
		private static extern bool GetConsoleScreenBufferInfo(IntPtr handle, out ConsoleScreenBufferInfo info); // 0x0000000181679D60-0x0000000181679E00
		private static extern bool ReadConsoleInput(IntPtr handle, out InputRecord record, int length, out int nread); // 0x0000000181679EC0-0x0000000181679FF0
	}
}
