/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[VisibleToOtherModules]
	internal static class ExceptionMarshaller // TypeDefIndex: 15495
	{
		// Fields
		[NoAutoStaticsCleanup]
		[ThreadStatic]
		private static Exception s_pendingException; // 0x80000000
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15496
		{
			// Fields
			public static Action _0___ClearPendingExceptionOnCodeReload; // 0x00
		}
	
		// Methods
		[RequiredByNativeCode]
		private static void SetPendingException(Exception ex); // 0x00000001822E66F0-0x00000001822E6740
		private static void ClearPendingExceptionOnCodeReload(); // 0x00000001822E66A0-0x00000001822E66F0
		[CompilerGenerated]
		internal static void UnityEngine_Bindings_ExceptionMarshaller_ClearPendingExceptionOnCodeReload_RegisterLifecycleMethod(); // 0x00000001822E6740-0x00000001822E6890
	}
}
