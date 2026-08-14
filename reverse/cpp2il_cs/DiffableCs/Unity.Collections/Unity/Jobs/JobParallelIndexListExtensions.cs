namespace Unity.Jobs;

[Extension]
[Obsolete("'JobParallelIndexListExtensions' has been deprecated; Use 'IJobFilterExtensions' instead.", False)]
public static class JobParallelIndexListExtensions
{

	[Extension]
	[Obsolete("The signature for 'ScheduleAppend' has changed. 'innerloopBatchCount' is no longer part of this API.", False)]
	public static JobHandle ScheduleAppend(T jobData, NativeList<Int32> indices, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = null) { }

	[Extension]
	[Obsolete("The signature for 'ScheduleFilter' has changed. 'innerloopBatchCount' is no longer part of this API.")]
	public static JobHandle ScheduleFilter(T jobData, NativeList<Int32> indices, int innerloopBatchCount, JobHandle dependsOn = null) { }

}

