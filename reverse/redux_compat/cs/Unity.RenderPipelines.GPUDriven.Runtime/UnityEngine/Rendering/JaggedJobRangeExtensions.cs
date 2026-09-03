/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal static class JaggedJobRangeExtensions // TypeDefIndex: 12986
	{
		// Extension methods
		public static JobHandle Schedule<T>(this T job, [IsReadOnly] in NativeList<JaggedJobRange> jobRanges, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static JobHandle ScheduleByRef<T>(this ref ref T job, [IsReadOnly] in NativeList<JaggedJobRange> jobRanges, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static void RunParallel<T>(this T job, [IsReadOnly] in NativeList<JaggedJobRange> jobRanges, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
	}
}
