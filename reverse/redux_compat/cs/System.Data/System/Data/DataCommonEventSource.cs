/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[EventSource(Name = "System.Data.DataCommonEventSource")]
	internal class DataCommonEventSource : EventSource // TypeDefIndex: 11218
	{
		// Fields
		internal static readonly DataCommonEventSource Log; // 0x00
		private static long s_nextScopeId; // 0x08
	
		// Constructors
		public DataCommonEventSource(); // 0x00000001815A75F0-0x00000001815A7600
		static DataCommonEventSource(); // 0x000000018186A050-0x000000018186A0D0
	
		// Methods
		[Event(1, Level = EventLevel.Informational)]
		internal void Trace(string message); // 0x000000018186A040-0x000000018186A050
		[NonEvent]
		internal void Trace<T0>(string format, T0 arg0);
		[NonEvent]
		internal void Trace<T0, T1>(string format, T0 arg0, T1 arg1);
		[NonEvent]
		internal void Trace<T0, T1, T2>(string format, T0 arg0, T1 arg1, T2 arg2);
		[NonEvent]
		internal void Trace<T0, T1, T2, T3>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
		[NonEvent]
		internal void Trace<T0, T1, T2, T3, T4>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		[NonEvent]
		internal void Trace<T0, T1, T2, T3, T4, T5, T6>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
		[Event(2, Level = EventLevel.Verbose)]
		internal long EnterScope(string message); // 0x0000000181869F70-0x000000018186A030
		[NonEvent]
		internal long EnterScope<T1>(string format, T1 arg1);
		[NonEvent]
		internal long EnterScope<T1, T2>(string format, T1 arg1, T2 arg2);
		[NonEvent]
		internal long EnterScope<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3);
		[NonEvent]
		internal long EnterScope<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		[Event(3, Level = EventLevel.Verbose)]
		internal void ExitScope(long scopeId); // 0x000000018186A030-0x000000018186A040
	}
}
