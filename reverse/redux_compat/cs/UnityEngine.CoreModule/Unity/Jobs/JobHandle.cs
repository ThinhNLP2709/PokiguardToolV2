/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Jobs
{
	[NativeHeader("ManagedKernel/Jobs/ScriptBindings/JobsBindings.h")]
	public struct JobHandle : IEquatable<Unity.Jobs.JobHandle> // TypeDefIndex: 7379
	{
		// Fields
		internal ulong jobGroup; // 0x00
		internal int version; // 0x08
	
		// Properties
		public bool IsCompleted { get; } // 0x000000018218F670-0x000000018218F6B0 
	
		// Methods
		public void Complete(); // 0x000000018218F560-0x000000018218F5A0
		[NativeMethod("ScheduleBatchedScriptingJobs", IsFreeFunction = true, IsThreadSafe = true)]
		public static void ScheduleBatchedJobs(); // 0x000000018218F6B0-0x000000018218F6E0
		[NativeMethod("ScheduleBatchedScriptingJobsAndComplete", IsFreeFunction = true, IsThreadSafe = true, ThrowsException = true)]
		private static void ScheduleBatchedJobsAndComplete(ref JobHandle job); // 0x000000018218F630-0x000000018218F670
		[NativeMethod("ScheduleBatchedScriptingJobsAndIsCompleted", IsFreeFunction = true, IsThreadSafe = true, ThrowsException = true)]
		private static bool ScheduleBatchedJobsAndIsCompleted(ref JobHandle job); // 0x000000018218F670-0x000000018218F6B0
		public static JobHandle CombineDependencies(JobHandle job0, JobHandle job1); // 0x000000018218F4F0-0x000000018218F560
		public static JobHandle CombineDependencies(JobHandle job0, JobHandle job1, JobHandle job2); // 0x000000018218F390-0x000000018218F410
		public static JobHandle CombineDependencies(NativeArray<JobHandle> jobs); // 0x000000018218F410-0x000000018218F480
		public static JobHandle CombineDependencies(NativeSlice<JobHandle> jobs); // 0x000000018218F480-0x000000018218F4F0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true, ThrowsException = true)]
		private static JobHandle CombineDependenciesInternal2(ref JobHandle job0, ref JobHandle job1); // 0x000000018218F1A0-0x000000018218F200
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true, ThrowsException = true)]
		private static JobHandle CombineDependenciesInternal3(ref JobHandle job0, ref JobHandle job1, ref JobHandle job2); // 0x000000018218F270-0x000000018218F2E0
		[NativeMethod(IsFreeFunction = true, IsThreadSafe = true, ThrowsException = true)]
		internal static unsafe JobHandle CombineDependenciesInternalPtr(void* jobs, int count); // 0x000000018218F330-0x000000018218F390
		public bool Equals(JobHandle other); // 0x000000018218F620-0x000000018218F630
		public override bool Equals(object obj); // 0x000000018218F5A0-0x000000018218F620
		public static bool operator ==(JobHandle a, JobHandle b); // 0x000000018218F620-0x000000018218F630
		public override int GetHashCode(); // 0x000000018126B220-0x000000018126B230
		private static void CombineDependenciesInternal2_Injected(ref JobHandle job0, ref JobHandle job1, ); // 0x000000018218F140-0x000000018218F1A0
		private static void CombineDependenciesInternal3_Injected(ref JobHandle job0, ref JobHandle job1, ref JobHandle job2, ); // 0x000000018218F200-0x000000018218F270
		private static unsafe void CombineDependenciesInternalPtr_Injected(void* jobs, int count, ); // 0x000000018218F2E0-0x000000018218F330
	}
}
