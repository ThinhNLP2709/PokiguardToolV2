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
	public static class IJobForExtensions // TypeDefIndex: 7370
	{
		// Nested types
		internal struct ForJobStruct<T> // TypeDefIndex: 7371
			where T : struct, IJobFor
		{
			// Fields
			internal static readonly BurstLike.SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			public delegate void ExecuteJobFunction(ref ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 7372; 0x00000000-0x00000000
	
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 7373
			{
				// Fields
				public static ExecuteJobFunction<T> _0___Execute;
			}
	
			// Constructors
			static ForJobStruct();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobFor;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJobFor;
	
		// Extension methods
		public static JobHandle ScheduleParallel<T>(this T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependency)
			where T : struct, IJobFor;
		public static JobHandle ScheduleParallelByRef<T>(this ref ref T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependency)
			where T : struct, IJobFor;
	}
}
