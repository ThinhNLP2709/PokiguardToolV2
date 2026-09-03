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
	public class DefaultTraceListener : TraceListener // TypeDefIndex: 8746
	{
		// Fields
		private static readonly bool OnWin32; // 0x00
		private static readonly string MonoTracePrefix; // 0x08
		private static readonly string MonoTraceFile; // 0x10
		private string logFileName; // 0x38
	
		// Properties
		[MonoTODO]
		public string LogFileName { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		static DefaultTraceListener(); // 0x0000000181B751E0-0x0000000181B753C0
		public DefaultTraceListener(); // 0x0000000181B753C0-0x0000000181B75420
	
		// Methods
		private static string GetPrefix(string var, string target); // 0x0000000181B74B20-0x0000000181B74B90
		private static unsafe void WriteWindowsDebugString(char* message); // 0x0000000181B751C0-0x0000000181B751D0
		private void WriteDebugString(string message); // 0x0000000181B74B90-0x0000000181B74C30
		private void WriteMonoTrace(string message); // 0x0000000181B74F60-0x0000000181B75150
		private void WritePrefix(); // 0x0000000181B75150-0x0000000181B751C0
		private void WriteImpl(string message); // 0x0000000181B74C30-0x0000000181B74D90
		private void WriteLogFile(string message, string logFile); // 0x0000000181B74DE0-0x0000000181B74F60
		public override void Write(string message); // 0x0000000181B751D0-0x0000000181B751E0
		public override void WriteLine(string message); // 0x0000000181B74D90-0x0000000181B74DE0
	}
}
