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
	public static class IJobFilterExtensions // TypeDefIndex: 11429
	{
		// Nested types
		internal struct JobFilterProducer<T> // TypeDefIndex: 11430
			where T : struct, IJobFilter
		{
			// Fields
			internal static readonly SharedStatic<IntPtr> jobReflectionData;
	
			// Nested types
			public struct JobWrapper // TypeDefIndex: 11431
			{
				// Fields
				[NativeDisableParallelForRestriction]
				public NativeList<int> outputIndices;
				public int appendCount;
				public T JobData;
			}
	
			public delegate void ExecuteJobFunction(ref JobWrapper<T> jobWrapper, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex); // TypeDefIndex: 11432; 0x00000000-0x00000000
	
			// Constructors
			static JobFilterProducer();
	
			// Methods
			[BurstDiscard]
			internal static void Initialize();
			public static void Execute(ref JobWrapper jobWrapper, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);
			public static void ExecuteAppend(ref JobWrapper jobWrapper, IntPtr bufferRangePatchData);
			public static void ExecuteFilter(ref JobWrapper jobWrapper, IntPtr bufferRangePatchData);
		}
	
		// Methods
		public static void EarlyJobInit<T>()
			where T : struct, IJobFilter;
		private static IntPtr GetReflectionData<T>()
			where T : struct, IJobFilter;
	
		// Extension methods
		public static JobHandle ScheduleAppend<T>(this T jobData, NativeList<int> indices, int arrayLength, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
		public static JobHandle ScheduleFilter<T>(this T jobData, NativeList<int> indices, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
		public static void RunAppend<T>(this T jobData, NativeList<int> indices, int arrayLength)
			where T : struct, IJobFilter;
		public static void RunFilter<T>(this T jobData, NativeList<int> indices)
			where T : struct, IJobFilter;
		public static JobHandle ScheduleAppendByRef<T>(this ref ref T jobData, NativeList<int> indices, int arrayLength, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
		public static JobHandle ScheduleFilterByRef<T>(this ref ref T jobData, NativeList<int> indices, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
		public static void RunAppendByRef<T>(this ref ref T jobData, NativeList<int> indices, int arrayLength)
			where T : struct, IJobFilter;
		public static void RunFilterByRef<T>(this ref ref T jobData, NativeList<int> indices)
			where T : struct, IJobFilter;
	}
}
