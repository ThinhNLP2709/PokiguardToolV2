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

namespace UnityEngine
{
	[NativeHeader("Runtime/Mono/Coroutine.h")]
	[RequiredByNativeCode]
	public sealed class Coroutine : YieldInstruction // TypeDefIndex: 7738
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7739
		{
			// Methods
			public static IntPtr ConvertToNative(Coroutine coroutine); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private Coroutine(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		~Coroutine(); // 0x00000001821E5620-0x00000001821E56B0
		[FreeFunction("Coroutine::CleanupCoroutineGC", true)]
		private static void ReleaseCoroutine(IntPtr ptr); // 0x00000001821E56B0-0x00000001821E56F0
	}
}
