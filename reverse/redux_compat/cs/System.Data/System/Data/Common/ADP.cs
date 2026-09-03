/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.Common
{
	internal static class ADP // TypeDefIndex: 11374
	{
		// Fields
		private static readonly Type s_stackOverflowType; // 0x00
		private static readonly Type s_outOfMemoryType; // 0x08
		private static readonly Type s_threadAbortType; // 0x10
		private static readonly Type s_nullReferenceType; // 0x18
		private static readonly Type s_accessViolationType; // 0x20
		private static readonly Type s_securityType; // 0x28
		internal static readonly string StrEmpty; // 0x30
		internal static readonly string[] AzureSqlServerEndpoints; // 0x38
		internal static readonly IntPtr PtrZero; // 0x40
		internal static readonly int PtrSize; // 0x48
	
		// Constructors
		static ADP(); // 0x00000001818F85B0-0x00000001818F8910
	
		// Methods
		private static void TraceException(string trace, Exception e); // 0x00000001818F8410-0x00000001818F8490
		internal static void TraceExceptionAsReturnValue(Exception e); // 0x00000001818F8290-0x00000001818F8350
		internal static void TraceExceptionWithoutRethrow(Exception e); // 0x00000001818F8350-0x00000001818F8410
		internal static ArgumentException Argument(string error); // 0x00000001818F7BA0-0x00000001818F7C20
		internal static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName); // 0x00000001818F7A90-0x00000001818F7B10
		internal static ArgumentOutOfRangeException ArgumentOutOfRange(string message, string parameterName); // 0x00000001818F7B10-0x00000001818F7BA0
		internal static InvalidOperationException InvalidOperation(string error); // 0x00000001818F7E10-0x00000001818F7E90
		internal static NotSupportedException NotSupported(string error); // 0x00000001818F8210-0x00000001818F8290
		internal static bool IsCatchableExceptionType(Exception e); // 0x00000001818F7F70-0x00000001818F80E0
		internal static bool IsCatchableOrSecurityExceptionType(Exception e); // 0x00000001818F80E0-0x00000001818F8210
		internal static ArgumentOutOfRangeException InvalidEnumerationValue(Type type, int value); // 0x00000001818F7CA0-0x00000001818F7D90
		internal static Exception InvalidSeekOrigin(string parameterName); // 0x00000001818F7F10-0x00000001818F7F70
		internal static ArgumentOutOfRangeException InvalidAcceptRejectRule(AcceptRejectRule value); // 0x00000001818F7C20-0x00000001818F7CA0
		internal static ArgumentOutOfRangeException InvalidMissingSchemaAction(MissingSchemaAction value); // 0x00000001818F7D90-0x00000001818F7E10
		internal static ArgumentOutOfRangeException InvalidRule(Rule value); // 0x00000001818F7E90-0x00000001818F7F10
		internal static Exception WrongType(Type got, Type expected); // 0x00000001818F8490-0x00000001818F85B0
	}
}
