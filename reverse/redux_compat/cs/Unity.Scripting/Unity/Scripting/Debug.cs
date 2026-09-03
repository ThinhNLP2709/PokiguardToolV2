/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class Debug // TypeDefIndex: 14820
	{
		// Fields
		private static IScriptingCoreDebug _scriptingCoreDebug; // 0x00
	
		// Properties
		public static IScriptingCoreDebug ScriptingCoreDebug { get; set; } // 0x0000000182064660-0x00000001820646B0 0x00000001820646B0-0x0000000182064750
	
		// Nested types
		[Nullable(0)]
		private class DefaultScriptingCoreDebug : IScriptingCoreDebug // TypeDefIndex: 14821
		{
			// Constructors
			public DefaultScriptingCoreDebug(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool IsDiagnosticSwitchEnabled(string name); // 0x00000001802E7840-0x00000001802E7850
			public void Log(string message); // 0x00000001802E76C0-0x00000001802E76D0
			public void LogError(string message); // 0x00000001802E76C0-0x00000001802E76D0
			public void LogException(Exception exception); // 0x00000001802E76C0-0x00000001802E76D0
			public void LogExceptionFatal(Exception exception); // 0x00000001802E76C0-0x00000001802E76D0
			public void Assert(bool condition); // 0x00000001802E76C0-0x00000001802E76D0
			public void AssertMsg(bool condition, string message); // 0x00000001802E76C0-0x00000001802E76D0
			public bool RunAssemblyLoadContextLeakDetection(List<IntPtr> assemblyLoadContextWeakHandles); // 0x00000001802E7840-0x00000001802E7850
		}
	
		// Constructors
		static Debug(); // 0x00000001820645E0-0x0000000182064660
	
		// Methods
		public static bool IsDiagnosticSwitchEnabled(string name); // 0x0000000182063FE0-0x0000000182064100
		public static void Log(string message); // 0x00000001820643F0-0x00000001820644B0
		public static void LogError(string message); // 0x0000000182064200-0x00000001820642C0
		public static void LogError(string message, Exception exception); // 0x0000000182064100-0x0000000182064200
		public static void LogException(Exception exception); // 0x00000001820642C0-0x00000001820643F0
		[Conditional("DEBUG")]
		public static void Assert(bool condition); // 0x0000000182063EB0-0x0000000182063FE0
		[Conditional("DEBUG")]
		public static void AssertMsg(bool condition, string message); // 0x0000000182063D70-0x0000000182063EB0
		public static bool RunAssemblyLoadContextLeakDetection(List<IntPtr> assemblyLoadContextWeakHandles); // 0x00000001820644B0-0x00000001820645E0
	}
}
