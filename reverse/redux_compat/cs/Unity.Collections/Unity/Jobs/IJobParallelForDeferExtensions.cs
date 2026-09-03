/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Jobs
{
	public static class IJobParallelForDeferExtensions // TypeDefIndex: 11438
	{
		// Nested types
		internal struct JobParallelForDeferProducer<T> // TypeDefIndex: 11439
			where T : struct, IJobParallelForDefer
		{
			// Fields
			internal static readonly SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			public delegate void ExecuteJobFunction(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 11440; 0x00000000-0x00000000
	
			// Constructors
			static JobParallelForDeferProducer();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobParallelForDefer;
		private static unsafe JobHandle ScheduleInternal<T>(ref ref T jobData, int innerloopBatchCount, void* forEachListPtr, void* atomicSafetyHandlePtr, JobHandle dependsOn)
			where T : struct, IJobParallelForDefer;
	
		// Extension methods
		public static JobHandle Schedule<T, U>(this T jobData, NativeList<U> list, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForDefer
			where U : struct;
		public static JobHandle ScheduleByRef<T, U>(this ref ref T jobData, NativeList<U> list, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForDefer
			where U : struct;
		public static unsafe JobHandle Schedule<T>(this T jobData, int* forEachCount, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForDefer;
		public static unsafe JobHandle ScheduleByRef<T>(this ref ref T jobData, int* forEachCount, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForDefer;
	}
}
