/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	public class TraceEventCache // TypeDefIndex: 8729
	{
		// Fields
		private static int processId; // 0x00
		private static string processName; // 0x08
		private long timeStamp; // 0x10
		private DateTime dateTime; // 0x18
		private string stackTrace; // 0x20
	
		// Properties
		public string Callstack { get; } // 0x0000000181B861E0-0x0000000181B86220 
		public Stack LogicalOperationStack { get; } // 0x0000000181B862A0-0x0000000181B863F0 
		public DateTime DateTime { get; } // 0x0000000181B86220-0x0000000181B862A0 
		public int ProcessId { get; } // 0x0000000181B85EA0-0x0000000181B85EF0 
		public string ThreadId { get; } // 0x0000000181B863F0-0x0000000181B86450 
		public long Timestamp { get; } // 0x0000000181B86450-0x0000000181B864B0 
	
		// Constructors
		public TraceEventCache(); // 0x0000000181B86170-0x0000000181B861E0
	
		// Methods
		private static void InitProcessInfo(); // 0x0000000181B85EF0-0x0000000181B86170
		internal static int GetProcessId(); // 0x0000000181B85EA0-0x0000000181B85EF0
		internal static int GetThreadId(); // 0x0000000181651F60-0x0000000181651F90
	}
}
