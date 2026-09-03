/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Profiling
{
	[IgnoredByDeepProfiler]
	[MovedFrom("UnityEngine")]
	[NativeHeader("NativeKernel/Allocator/MemoryManager.h")]
	[NativeHeader("NativeKernel/Profiler/MemoryProfiler.h")]
	[NativeHeader("Runtime/Profiler/Profiler.h")]
	[NativeHeader("Runtime/Profiler/ScriptBindings/Profiler.bindings.h")]
	[NativeHeader("Scripting/ScriptingBackend/ScriptingApi.h")]
	[NativeHeader("NativeKernel/Utilities/MemoryUtilities.h")]
	[UsedByNativeCode]
	public sealed class Profiler // TypeDefIndex: 7870
	{
		// Properties
		public static bool supported { [NativeMethod(Name = "profiler_is_available", IsFreeFunction = true)] get; } // 0x0000000182209FB0-0x0000000182209FE0 
		public static bool enabled { [NativeConditional("ENABLE_PROFILER")] [NativeMethod(Name = "profiler_is_enabled", IsFreeFunction = true, IsThreadSafe = true)] get; } // 0x0000000182209F80-0x0000000182209FB0 
	
		// Methods
		[NativeMethod(Name = "ProfilerBindings::GetRuntimeMemorySizeLong", IsFreeFunction = true)]
		public static long GetRuntimeMemorySizeLong([NotNull] UnityEngine.Object o); // 0x0000000182209EF0-0x0000000182209F80
		private static long GetRuntimeMemorySizeLong_Injected(IntPtr o); // 0x0000000182209EB0-0x0000000182209EF0
	}
}
