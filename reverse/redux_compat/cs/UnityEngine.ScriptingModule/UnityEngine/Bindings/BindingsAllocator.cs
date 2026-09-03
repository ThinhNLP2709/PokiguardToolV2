/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[NativeHeader("Scripting/Marshalling/BindingsAllocator.h")]
	[StaticAccessor("Marshalling::BindingsAllocator", StaticAccessorType.DoubleColon)]
	[VisibleToOtherModules]
	internal static class BindingsAllocator // TypeDefIndex: 15487
	{
		// Nested types
		private struct NativeOwnedMemory // TypeDefIndex: 15488
		{
			// Fields
			public unsafe void* data; // 0x00
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void Free(void* ptr); // 0x00000001822E6550-0x00000001822E6590
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void FreeNativeOwnedMemory(void* ptr); // 0x00000001822E6510-0x00000001822E6550
		public static unsafe void* GetNativeOwnedDataPointer(void* ptr); // 0x000000018093CE30-0x000000018093CE50
	}
}
