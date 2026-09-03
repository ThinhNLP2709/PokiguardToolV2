/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Jobs
{
	public static class IJobParallelForExtensions // TypeDefIndex: 7375
	{
		// Nested types
		internal struct ParallelForJobStruct<T> // TypeDefIndex: 7376
			where T : struct, IJobParallelFor
		{
			// Fields
			internal static readonly BurstLike.SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			public delegate void ExecuteJobFunction(ref ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 7377; 0x00000000-0x00000000
	
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 7378
			{
				// Fields
				public static ExecuteJobFunction<T> _0___Execute;
			}
	
			// Constructors
			static ParallelForJobStruct();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobParallelFor;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJobParallelFor;
	
		// Extension methods
		public static JobHandle Schedule<T>(this T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static JobHandle ScheduleByRef<T>(this ref ref T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelFor;
		public static void RunByRef<T>(this ref ref T jobData, int arrayLength)
			where T : struct, IJobParallelFor;
	}
}
