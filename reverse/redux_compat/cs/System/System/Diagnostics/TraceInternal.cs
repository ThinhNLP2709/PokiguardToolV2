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

namespace System.Diagnostics
{
	internal static class TraceInternal // TypeDefIndex: 8732
	{
		// Fields
		private static string appName; // 0x00
		private static TraceListenerCollection listeners; // 0x08
		private static bool autoFlush; // 0x10
		[ThreadStatic]
		private static int indentLevel; // 0x80000000
		private static int indentSize; // 0x14
		internal static readonly object critSec; // 0x18
	
		// Properties
		public static TraceListenerCollection Listeners { get; } // 0x0000000181B866B0-0x0000000181B86980 
		public static bool AutoFlush { get; } // 0x0000000181B865A0-0x0000000181B86600 
		public static int IndentLevel { get; } // 0x0000000181B86600-0x0000000181B86650 
		public static int IndentSize { get; } // 0x0000000181B86650-0x0000000181B866B0 
	
		// Constructors
		static TraceInternal(); // 0x0000000181B86500-0x0000000181B865A0
	
		// Methods
		private static void InitializeSettings(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
