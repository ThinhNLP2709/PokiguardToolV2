namespace UnityEngine.Jobs;

[Extension]
public static class IJobParallelForTransformExtensions
{
	public struct TransformParallelForLoopStruct
	{
		internal sealed class ExecuteJobFunction : MulticastDelegate
		{

			public ExecuteJobFunction(object object, IntPtr method) { }

			public override void Invoke(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }

		}

		private struct TransformJobData
		{
			public IntPtr TransformAccessArray; //Field offset: 0x0
			public int IsReadOnly; //Field offset: 0x0

		}

		internal static readonly SharedStatic<IntPtr> jobReflectionData; //Field offset: 0x0

		private static TransformParallelForLoopStruct`1() { }

		public static void Execute(ref T jobData, IntPtr jobData2, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }

		[BurstDiscard]
		internal static void Initialize() { }

	}


	public static void EarlyJobInit() { }

	private static IntPtr GetReflectionData() { }

	[Extension]
	public static JobHandle Schedule(T jobData, TransformAccessArray transforms, JobHandle dependsOn = null) { }

}

