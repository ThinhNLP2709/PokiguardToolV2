/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class DebugLifecycle // TypeDefIndex: 14857
	{
		// Fields
		private static readonly bool loggingEnabled; // 0x00
		private static readonly bool verificationEnabled; // 0x01
	
		// Constructors
		static DebugLifecycle(); // 0x0000000182063C90-0x0000000182063D70
	
		// Methods
		public static void Log(string message); // 0x0000000182063A10-0x0000000182063B50
		public static void ReportError(string message, bool criticalError = true /* Metadata: 0x006A98CB */); // 0x0000000182063B50-0x0000000182063C90
		internal static bool IsLoggingEnabled(); // 0x0000000182063950-0x00000001820639B0
		internal static bool IsVerificationEnabled(); // 0x00000001820639B0-0x0000000182063A10
	}
}
