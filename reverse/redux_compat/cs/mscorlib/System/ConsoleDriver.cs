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
	internal static class ConsoleDriver // TypeDefIndex: 2453
	{
		// Fields
		internal static IConsoleDriver driver; // 0x00
		private static bool is_console; // 0x08
		private static bool called_isatty; // 0x09
	
		// Properties
		public static bool IsConsole { get; } // 0x000000018164C5E0-0x000000018164C6B0 
	
		// Constructors
		static ConsoleDriver(); // 0x000000018164C500-0x000000018164C5E0
	
		// Methods
		private static IConsoleDriver CreateNullConsoleDriver(); // 0x000000018164C2D0-0x000000018164C300
		private static IConsoleDriver CreateWindowsConsoleDriver(); // 0x000000018164C360-0x000000018164C3B0
		private static IConsoleDriver CreateTermInfoDriver(string term); // 0x000000018164C300-0x000000018164C360
		public static ConsoleKeyInfo ReadKey(bool intercept); // 0x000000018164C3D0-0x000000018164C4E0
		private static bool Isatty(IntPtr handle); // 0x000000018164C3C0-0x000000018164C3D0
		internal static int InternalKeyAvailable(int ms_timeout); // 0x000000018164C3B0-0x000000018164C3C0
		internal static unsafe bool TtySetup(string keypadXmit, string teardown, out byte[] control_characters, out int* address); // 0x000000018164C4F0-0x000000018164C500
		internal static bool SetEcho(bool wantEcho); // 0x000000018164C4E0-0x000000018164C4F0
	}
}
