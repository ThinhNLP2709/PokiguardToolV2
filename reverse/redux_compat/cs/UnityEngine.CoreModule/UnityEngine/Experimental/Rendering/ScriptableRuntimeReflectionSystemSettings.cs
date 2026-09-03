/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.Rendering
{
	[NativeHeader("Runtime/Camera/ScriptableRuntimeReflectionSystem.h")]
	[RequiredByNativeCode]
	public static class ScriptableRuntimeReflectionSystemSettings // TypeDefIndex: 8230
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static ScriptableRuntimeReflectionSystemWrapper s_Instance; // 0x00
	
		// Properties
		private static IScriptableRuntimeReflectionSystem Internal_ScriptableRuntimeReflectionSystemSettings_system { [RequiredByNativeCode] set; } // 0x00000001822532F0-0x00000001822533A0
		private static ScriptableRuntimeReflectionSystemWrapper Internal_ScriptableRuntimeReflectionSystemSettings_instance { [RequiredByNativeCode] get; } // 0x00000001822532A0-0x00000001822532F0 
	
		// Constructors
		static ScriptableRuntimeReflectionSystemSettings(); // 0x0000000182253220-0x00000001822532A0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[StaticAccessor("ScriptableRuntimeReflectionSystem", StaticAccessorType.DoubleColon)]
		private static void ScriptingDirtyReflectionSystemInstance(); // 0x00000001822531F0-0x0000000182253220
	}
}
