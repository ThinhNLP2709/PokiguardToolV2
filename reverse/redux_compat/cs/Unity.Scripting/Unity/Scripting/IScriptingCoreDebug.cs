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
	[NullableContext(1)]
	internal interface IScriptingCoreDebug // TypeDefIndex: 14822
	{
		// Methods
		bool IsDiagnosticSwitchEnabled(string name);
		void Log(string message);
		void LogError(string message);
		void LogException(Exception exception);
		void Assert(bool condition);
		void AssertMsg(bool condition, string message);
		bool RunAssemblyLoadContextLeakDetection(List<IntPtr> assemblyLoadContextWeakHandles);
	}
}
