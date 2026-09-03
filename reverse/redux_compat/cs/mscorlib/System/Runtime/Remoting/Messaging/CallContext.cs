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

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[ComVisible(true)]
	public sealed class CallContext // TypeDefIndex: 2960
	{
		// Constructors
		private CallContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal static object SetCurrentCallContext(LogicalCallContext ctx); // 0x00000001802E7860-0x00000001802E7870
		internal static LogicalCallContext SetLogicalCallContext(LogicalCallContext callCtx); // 0x00000001814D38B0-0x00000001814D3920
		public static object LogicalGetData(string name); // 0x00000001814D3620-0x00000001814D3700
		public static void LogicalSetData(string name, object data); // 0x00000001814D3700-0x00000001814D38B0
	}
}
