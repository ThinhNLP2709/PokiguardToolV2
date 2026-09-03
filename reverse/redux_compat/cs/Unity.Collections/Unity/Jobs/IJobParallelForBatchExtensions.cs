/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Jobs.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Jobs
{
	public static class IJobParallelForBatchExtensions // TypeDefIndex: 11434
	{
		// Nested types
		internal struct JobParallelForBatchProducer<T> // TypeDefIndex: 11435
			where T : struct, IJobParallelForBatch
		{
			// Fields
			internal static readonly SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			internal delegate void ExecuteJobFunction(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 11436; 0x00000000-0x00000000
	
			// Constructors
			static JobParallelForBatchProducer();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobParallelForBatch;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJobParallelForBatch;
	
		// Extension methods
		public static JobHandle Schedule<T>(this T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static JobHandle ScheduleByRef<T>(this ref ref T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static JobHandle ScheduleParallel<T>(this T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static JobHandle ScheduleParallelByRef<T>(this ref ref T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static JobHandle ScheduleBatch<T>(this T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static JobHandle ScheduleBatchByRef<T>(this ref ref T jobData, int arrayLength, int indicesPerJobCount, JobHandle dependsOn = default)
			where T : struct, IJobParallelForBatch;
		public static void Run<T>(this T jobData, int arrayLength, int indicesPerJobCount)
			where T : struct, IJobParallelForBatch;
		public static void RunByRef<T>(this ref ref T jobData, int arrayLength, int indicesPerJobCount)
			where T : struct, IJobParallelForBatch;
		public static void RunBatch<T>(this T jobData, int arrayLength)
			where T : struct, IJobParallelForBatch;
		public static void RunBatchByRef<T>(this ref ref T jobData, int arrayLength)
			where T : struct, IJobParallelForBatch;
	}
}
