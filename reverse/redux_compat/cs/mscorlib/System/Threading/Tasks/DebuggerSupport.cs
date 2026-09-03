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
using Internal.Runtime.Augments;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	internal static class DebuggerSupport // TypeDefIndex: 2639
	{
		// Fields
		private static readonly LowLevelDictionary<int, Task> s_activeTasks; // 0x00
		private static readonly object s_activeTasksLock; // 0x08
	
		// Properties
		public static bool LoggingOn { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		static DebuggerSupport(); // 0x000000018167E210-0x000000018167E2E0
	
		// Methods
		public static void TraceOperationCreation(CausalityTraceLevel traceLevel, Task task, string operationName, ulong relatedContext); // 0x00000001802E76C0-0x00000001802E76D0
		public static void TraceOperationCompletion(CausalityTraceLevel traceLevel, Task task, AsyncStatus status); // 0x00000001802E76C0-0x00000001802E76D0
		public static void TraceOperationRelation(CausalityTraceLevel traceLevel, Task task, CausalityRelation relation); // 0x00000001802E76C0-0x00000001802E76D0
		public static void TraceSynchronousWorkStart(CausalityTraceLevel traceLevel, Task task, CausalitySynchronousWork work); // 0x00000001802E76C0-0x00000001802E76D0
		public static void TraceSynchronousWorkCompletion(CausalityTraceLevel traceLevel, CausalitySynchronousWork work); // 0x00000001802E76C0-0x00000001802E76D0
		public static void AddToActiveTasks(Task task); // 0x000000018167DFB0-0x000000018167E040
		private static void AddToActiveTasksNonInlined(Task task); // 0x000000018167DE60-0x000000018167DFB0
		public static void RemoveFromActiveTasks(Task task); // 0x000000018167E180-0x000000018167E210
		private static void RemoveFromActiveTasksNonInlined(Task task); // 0x000000018167E040-0x000000018167E180
	}
}
