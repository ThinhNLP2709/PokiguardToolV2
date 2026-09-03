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

namespace System.Threading.Tasks
{
	[FriendAccessAllowed]
	internal static class AsyncCausalityTracer // TypeDefIndex: 2685
	{
		// Properties
		[FriendAccessAllowed]
		internal static bool LoggingOn { [FriendAccessAllowed] get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Methods
		[FriendAccessAllowed]
		internal static void TraceOperationCreation(CausalityTraceLevel traceLevel, int taskId, string operationName, ulong relatedContext); // 0x00000001802E76C0-0x00000001802E76D0
		[FriendAccessAllowed]
		internal static void TraceOperationCompletion(CausalityTraceLevel traceLevel, int taskId, AsyncCausalityStatus status); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void TraceSynchronousWorkStart(CausalityTraceLevel traceLevel, int taskId, CausalitySynchronousWork work); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void TraceSynchronousWorkCompletion(CausalityTraceLevel traceLevel, CausalitySynchronousWork work); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
