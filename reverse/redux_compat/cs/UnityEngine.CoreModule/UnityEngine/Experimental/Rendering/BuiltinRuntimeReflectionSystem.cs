/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.Rendering
{
	[NativeHeader("Runtime/Camera/ReflectionProbes.h")]
	internal class BuiltinRuntimeReflectionSystem : IScriptableRuntimeReflectionSystem // TypeDefIndex: 8228
	{
		// Constructors
		public BuiltinRuntimeReflectionSystem(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool TickRealtimeProbes(); // 0x000000018222B080-0x000000018222B0B0
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		private void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		[StaticAccessor("GetReflectionProbes()", Type = StaticAccessorType.Dot)]
		private static bool BuiltinUpdate(); // 0x000000018222B080-0x000000018222B0B0
		[RequiredByNativeCode]
		private static BuiltinRuntimeReflectionSystem Internal_BuiltinRuntimeReflectionSystem_New(); // 0x000000018222B0B0-0x000000018222B100
	}
}
