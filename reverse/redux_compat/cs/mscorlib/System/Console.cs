/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	public static class Console // TypeDefIndex: 2450
	{
		// Fields
		internal static TextWriter stdout; // 0x00
		private static TextWriter stderr; // 0x08
		private static TextReader stdin; // 0x10
		internal static bool IsRunningOnAndroid; // 0x18
		private static Encoding inputEncoding; // 0x20
		private static Encoding outputEncoding; // 0x28
		private static ConsoleCancelEventHandler cancel_event; // 0x30
	
		// Properties
		public static TextWriter Error { get; } // 0x000000018164D7B0-0x000000018164D800 
		public static TextWriter Out { get; } // 0x000000018164D850-0x000000018164D8A0 
		public static Encoding InputEncoding { get; } // 0x000000018164D800-0x000000018164D850 
		public static Encoding OutputEncoding { get; } // 0x000000018164D8A0-0x000000018164D8F0 
	
		// Nested types
		private class WindowsConsole // TypeDefIndex: 2451
		{
			// Fields
			public static bool ctrlHandlerAdded; // 0x00
			private static WindowsCancelHandler cancelHandler; // 0x08
	
			// Nested types
			private delegate bool WindowsCancelHandler(int keyCode); // TypeDefIndex: 2452; 0x00000001804A78A0-0x00000001804A78B0
	
			// Constructors
			static WindowsConsole(); // 0x0000000181663220-0x0000000181663520
	
			// Methods
			private static extern int GetConsoleCP(); // 0x0000000181663000-0x0000000181663070
			private static extern int GetConsoleOutputCP(); // 0x0000000181663070-0x00000001816630E0
			private static bool DoWindowsConsoleCancelEvent(int keyCode); // 0x0000000181662FB0-0x0000000181663000
			public static int GetInputCodePage(); // 0x00000001816630E0-0x0000000181663180
			public static int GetOutputCodePage(); // 0x0000000181663180-0x0000000181663220
		}
	
		// Constructors
		static Console(); // 0x000000018164D540-0x000000018164D7B0
	
		// Methods
		private static void SetupStreams(Encoding inputEncoding, Encoding outputEncoding); // 0x000000018164CF50-0x000000018164D380
		private static Stream Open(IntPtr handle, FileAccess access, int bufferSize); // 0x000000018164C9D0-0x000000018164CAB0
		public static Stream OpenStandardError(int bufferSize); // 0x000000018164C820-0x000000018164C8B0
		public static Stream OpenStandardInput(int bufferSize); // 0x000000018164C8B0-0x000000018164C940
		public static Stream OpenStandardOutput(int bufferSize); // 0x000000018164C940-0x000000018164C9D0
		public static void SetError(TextWriter newError); // 0x000000018164CD70-0x000000018164CE60
		public static void SetOut(TextWriter newOut); // 0x000000018164CE60-0x000000018164CF50
		public static void WriteLine(string value); // 0x000000018164D380-0x000000018164D400
		public static void WriteLine(string format, object arg0); // 0x000000018164D4B0-0x000000018164D540
		public static void WriteLine(string format, object arg0, object arg1, object arg2); // 0x000000018164D400-0x000000018164D4B0
		public static ConsoleKeyInfo ReadKey(); // 0x000000018164CC00-0x000000018164CD70
		public static ConsoleKeyInfo ReadKey(bool intercept); // 0x000000018164CAB0-0x000000018164CC00
		private static void DoConsoleCancelEvent(); // 0x000000018164C6B0-0x000000018164C820
	}
}
