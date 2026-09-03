/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Jobs
{
	public static class IJobParallelForTransformExtensions // TypeDefIndex: 7875
	{
		// Nested types
		internal struct TransformParallelForLoopStruct<T> // TypeDefIndex: 7876
			where T : struct, IJobParallelForTransform
		{
			// Fields
			internal static readonly BurstLike.SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			private struct TransformJobData // TypeDefIndex: 7877
			{
				// Fields
				public IntPtr TransformAccessArray;
				public int IsReadOnly;
			}
	
			public delegate void ExecuteJobFunction(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 7878; 0x00000000-0x00000000
	
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 7879
			{
				// Fields
				public static ExecuteJobFunction<T> _0___Execute;
			}
	
			// Constructors
			static TransformParallelForLoopStruct();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T jobData, IntPtr jobData2, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobParallelForTransform;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJobParallelForTransform;
	
		// Extension methods
		public static JobHandle Schedule<T>(this T jobData, TransformAccessArray transforms, JobHandle dependsOn = default)
			where T : struct, IJobParallelForTransform;
		public static JobHandle ScheduleReadOnly<T>(this T jobData, TransformAccessArray transforms, int batchSize, JobHandle dependsOn = default)
			where T : struct, IJobParallelForTransform;
	}
}
