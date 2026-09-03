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
	public static class IJobExtensions // TypeDefIndex: 7365
	{
		// Nested types
		internal struct JobStruct<T> // TypeDefIndex: 7366
			where T : struct, IJob
		{
			// Fields
			internal static readonly BurstLike.SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			internal delegate void ExecuteJobFunction(ref ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 7367; 0x00000000-0x00000000
	
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 7368
			{
				// Fields
				public static ExecuteJobFunction<T> _0___Execute;
			}
	
			// Constructors
			static JobStruct();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJob;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJob;
	
		// Extension methods
		public static JobHandle Schedule<T>(this T jobData, JobHandle dependsOn = default)
			where T : struct, IJob;
		public static void Run<T>(this T jobData)
			where T : struct, IJob;
		public static JobHandle ScheduleByRef<T>(this ref ref T jobData, JobHandle dependsOn = default)
			where T : struct, IJob;
	}
}
