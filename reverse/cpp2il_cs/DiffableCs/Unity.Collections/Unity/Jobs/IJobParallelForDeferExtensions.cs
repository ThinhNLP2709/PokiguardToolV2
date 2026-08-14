namespace Unity.Jobs;

[Extension]
public static class IJobParallelForDeferExtensions
{
	public struct JobParallelForDeferProducer
	{
		internal sealed class ExecuteJobFunction : MulticastDelegate
		{

			public ExecuteJobFunction(object object, IntPtr method) { }

			public override IAsyncResult BeginInvoke(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex, AsyncCallback callback, object object) { }

			public override void EndInvoke(ref T jobData, ref JobRanges ranges, IAsyncResult result) { }

			public override void Invoke(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }

		}

		internal static readonly SharedStatic<IntPtr> jobReflectionData; //Field offset: 0x0

		private static JobParallelForDeferProducer`1() { }

		public static void Execute(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }

		[BurstDiscard]
		internal static void Initialize() { }

	}


	public static void EarlyJobInit() { }

	[Extension]
	public static JobHandle Schedule(T jobData, NativeList<U> list, int innerloopBatchCount, JobHandle dependsOn = null) { }

	[Extension]
	public static JobHandle Schedule(T jobData, Int32* forEachCount, int innerloopBatchCount, JobHandle dependsOn = null) { }

	[Extension]
	public static JobHandle ScheduleByRef(ref T jobData, NativeList<U> list, int innerloopBatchCount, JobHandle dependsOn = null) { }

	[Extension]
	public static JobHandle ScheduleByRef(ref T jobData, Int32* forEachCount, int innerloopBatchCount, JobHandle dependsOn = null) { }

	private static JobHandle ScheduleInternal(ref T jobData, int innerloopBatchCount, Void* forEachListPtr, Void* atomicSafetyHandlePtr, JobHandle dependsOn) { }

}

