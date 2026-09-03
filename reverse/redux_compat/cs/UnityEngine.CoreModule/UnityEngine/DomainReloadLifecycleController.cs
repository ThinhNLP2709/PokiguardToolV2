/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal class DomainReloadLifecycleController // TypeDefIndex: 7840
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static AssemblyLoadedScopeIl2Cpp _currentAssemblyLoadedScope; // 0x00
		[NoAutoStaticsCleanup]
		private static DependencyOrderedNativeCallbackProvider _nativeCallbackProvider; // 0x08
	
		// Nested types
		private class ScriptingCoreDebugForIl2AndMonoCpp : IScriptingCoreDebug // TypeDefIndex: 7841
		{
			// Constructors
			public ScriptingCoreDebugForIl2AndMonoCpp(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool IsDiagnosticSwitchEnabled(string name); // 0x00000001802E7840-0x00000001802E7850
			public void Log(string message); // 0x0000000182210B70-0x0000000182210BC0
			public void LogError(string message); // 0x0000000182210AD0-0x0000000182210B20
			public void LogException(Exception exception); // 0x0000000182210B20-0x0000000182210B70
			public void Assert(bool condition); // 0x0000000182210A80-0x0000000182210AD0
			public void AssertMsg(bool condition, string message); // 0x0000000182210A20-0x0000000182210A80
			public bool RunAssemblyLoadContextLeakDetection(List<IntPtr> assemblyLoadContextWeakHandles); // 0x00000001802E7840-0x00000001802E7850
		}
	
		// Methods
		[RequiredByNativeCode]
		private static void Internal_InitializeLifecycleController(); // 0x0000000182205B00-0x0000000182205C90
		[RequiredByNativeCode]
		private static void Internal_EnterAssemblyLoadedScope(Assembly[] loadedAssemblies); // 0x0000000182205620-0x0000000182205790
		[RequiredByNativeCode]
		private static void Internal_EnterCodeLoadedScope(); // 0x0000000182205790-0x0000000182205890
		[RequiredByNativeCode]
		private static void Internal_ExitCodeLoadedScope(); // 0x0000000182205A00-0x0000000182205B00
		[RequiredByNativeCode]
		private static void Internal_ExitAssemblyLoadedScope(); // 0x0000000182205890-0x0000000182205A00
	}
}
