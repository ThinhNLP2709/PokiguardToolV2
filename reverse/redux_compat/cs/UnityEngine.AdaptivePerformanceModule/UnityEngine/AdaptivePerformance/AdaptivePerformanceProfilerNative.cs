/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	[NativeHeader("Modules/AdaptivePerformance/Profiler/AdaptivePerformanceProfilerNative.bindings.h")]
	internal static class AdaptivePerformanceProfilerNative // TypeDefIndex: 14191
	{
		// Methods
		internal static void EmitFrameMetaData<T>(Guid id, int tag, List<T> data)
			where T : struct;
		[NativeMethod(Name = "ProfilerBindings::Internal_EmitGlobalMetaData_Span", IsFreeFunction = true, IsThreadSafe = true)]
		internal static unsafe void EmitGlobalMetaData_Span(void* id, int idLen, int tag, Span<byte> data, int count, int elementSize, bool frameData); // 0x000000018213A300-0x000000018213A3B0
		private static unsafe void EmitGlobalMetaData_Span_Injected(void* id, int idLen, int tag, ref ManagedSpanWrapper data, int count, int elementSize, bool frameData); // 0x000000018213A280-0x000000018213A300
	}
}
