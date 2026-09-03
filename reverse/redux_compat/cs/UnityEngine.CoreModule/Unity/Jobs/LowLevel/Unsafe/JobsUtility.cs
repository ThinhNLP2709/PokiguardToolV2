/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using Unity.Jobs;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Jobs.LowLevel.Unsafe
{
	[NativeHeader("ManagedKernel/Jobs/ScriptBindings/JobsBindings.h")]
	[NativeHeader("NativeJobs/JobSystem.h")]
	public static class JobsUtility // TypeDefIndex: 7383
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static PanicFunction_ PanicFunction; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public static bool IsExecutingJob { [NativeMethod(Name = "GetIsExecutingScriptingJob", IsFreeFunction = true, IsThreadSafe = true)] get; } // 0x0000000182190080-0x00000001821900B0 
		public static int JobWorkerCount { get; } // 0x00000001821900B0-0x0000000182190110 
		public static int ThreadIndex { [FreeFunction("GetJobWorkerIndex", IsThreadSafe = true)] [BurstAuthorizedExternalMethod] get; } // 0x0000000182190140-0x0000000182190170 
		public static int ThreadIndexCount { [FreeFunction("GetJobWorkerIndexCount", IsThreadSafe = true)] [BurstAuthorizedExternalMethod] get; } // 0x0000000182190110-0x0000000182190140 
	
		// Nested types
		public struct JobScheduleParameters // TypeDefIndex: 7384
		{
			// Fields
			public JobHandle Dependency; // 0x00
			public int ScheduleMode; // 0x10
			public IntPtr ReflectionData; // 0x18
			public IntPtr JobDataPtr; // 0x20
	
			// Constructors
			public unsafe JobScheduleParameters(void* i_jobData, IntPtr i_reflectionData, JobHandle i_dependency, ScheduleMode i_scheduleMode); // 0x000000018218F6E0-0x000000018218F720
		}
	
		internal delegate void PanicFunction_(); // TypeDefIndex: 7385; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		static JobsUtility(); // 0x000000018218FF60-0x0000000182190080
	
		// Methods
		public static void GetJobRange(ref JobRanges ranges, int jobIndex, out int beginIndex, out int endIndex); // 0x000000018218F8F0-0x000000018218F940
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true)]
		public static bool GetWorkStealingRange(ref JobRanges ranges, int jobIndex, out int beginIndex, out int endIndex); // 0x000000018218F940-0x000000018218F9A0
		[FreeFunction("ScheduleManagedJob", ThrowsException = true, IsThreadSafe = true)]
		public static JobHandle Schedule(ref JobScheduleParameters parameters); // 0x000000018218FE70-0x000000018218FEF0
		[FreeFunction("ScheduleManagedJobParallelFor", ThrowsException = true, IsThreadSafe = true)]
		public static JobHandle ScheduleParallelFor(ref JobScheduleParameters parameters, int arrayLength, int innerloopBatchCount); // 0x000000018218FD80-0x000000018218FE20
		[FreeFunction("ScheduleManagedJobParallelForDeferArraySize", ThrowsException = true, IsThreadSafe = true)]
		public static unsafe JobHandle ScheduleParallelForDeferArraySize(ref JobScheduleParameters parameters, int innerloopBatchCount, void* listData, void* listDataAtomicSafetyHandle); // 0x000000018218FA70-0x000000018218FB20
		[FreeFunction("ScheduleManagedJobParallelForTransform", ThrowsException = true)]
		public static JobHandle ScheduleParallelForTransform(ref JobScheduleParameters parameters, IntPtr transfromAccesssArray); // 0x000000018218FC90-0x000000018218FD20
		[FreeFunction("ScheduleManagedJobParallelForTransformReadOnly", ThrowsException = true)]
		public static JobHandle ScheduleParallelForTransformReadOnly(ref JobScheduleParameters parameters, IntPtr transfromAccesssArray, int innerloopBatchCount); // 0x000000018218FB90-0x000000018218FC30
		[FreeFunction(ThrowsException = true, IsThreadSafe = true)]
		private static IntPtr CreateJobReflectionData(Type wrapperJobType, Type userJobType, object managedJobFunction0, object managedJobFunction1, object managedJobFunction2); // 0x000000018218F7C0-0x000000018218F830
		public static IntPtr CreateJobReflectionData(Type type, object managedJobFunction0, object managedJobFunction1 = null, object managedJobFunction2 = null); // 0x000000018218F720-0x000000018218F7C0
		public static IntPtr CreateJobReflectionData(Type wrapperJobType, Type userJobType, object managedJobFunction0); // 0x000000018218F830-0x000000018218F8C0
		[FreeFunction("JobSystem::GetJobQueueWorkerThreadCount")]
		private static int GetJobQueueWorkerThreadCount(); // 0x000000018218F8C0-0x000000018218F8F0
		[RequiredByNativeCode]
		private static void InvokePanicFunction(); // 0x000000018218F9A0-0x000000018218FA10
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018218FEF0-0x000000018218FF60
		private static void Schedule_Injected(ref JobScheduleParameters parameters, ); // 0x000000018218FE20-0x000000018218FE70
		private static void ScheduleParallelFor_Injected(ref JobScheduleParameters parameters, int arrayLength, int innerloopBatchCount, ); // 0x000000018218FD20-0x000000018218FD80
		private static unsafe void ScheduleParallelForDeferArraySize_Injected(ref JobScheduleParameters parameters, int innerloopBatchCount, void* listData, void* listDataAtomicSafetyHandle, ); // 0x000000018218FA10-0x000000018218FA70
		private static void ScheduleParallelForTransform_Injected(ref JobScheduleParameters parameters, IntPtr transfromAccesssArray, ); // 0x000000018218FC30-0x000000018218FC90
		private static void ScheduleParallelForTransformReadOnly_Injected(ref JobScheduleParameters parameters, IntPtr transfromAccesssArray, int innerloopBatchCount, ); // 0x000000018218FB20-0x000000018218FB90
	}
}
