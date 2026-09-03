/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Jobs
{
	[Obsolete("\'JobParallelIndexListExtensions\' has been deprecated; Use \'IJobFilterExtensions\' instead.", false)]
	public static class JobParallelIndexListExtensions // TypeDefIndex: 11426
	{
		// Extension methods
		[Obsolete("The signature for \'ScheduleAppend\' has changed. \'innerloopBatchCount\' is no longer part of this API.", false)]
		public static JobHandle ScheduleAppend<T>(this T jobData, NativeList<int> indices, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
		[Obsolete("The signature for \'ScheduleFilter\' has changed. \'innerloopBatchCount\' is no longer part of this API.")]
		public static JobHandle ScheduleFilter<T>(this T jobData, NativeList<int> indices, int innerloopBatchCount, JobHandle dependsOn = default)
			where T : struct, IJobFilter;
	}
}
