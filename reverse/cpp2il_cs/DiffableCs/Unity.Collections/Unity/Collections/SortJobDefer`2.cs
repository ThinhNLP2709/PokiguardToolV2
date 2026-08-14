namespace Unity.Collections;

[GenerateTestsForBurstCompatibility(RequiredUnityDefine = "UNITY_2020_2_OR_NEWER", GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(Unity.Collections.NativeSortExtension+DefaultComparer`1<System.Int32>)})]
public struct SortJobDefer
{
	[BurstCompile]
	internal struct SegmentSort : IJobParallelForDefer
	{
		[ReadOnly]
		internal NativeList<T> DataRO; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeList<T>* Data; //Field offset: 0x0
		internal U Comp; //Field offset: 0x0
		internal int SegmentWidth; //Field offset: 0x0

		public override void Execute(int index) { }

	}

	[BurstCompile]
	internal struct SegmentSortMerge : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		internal NativeList<T> Data; //Field offset: 0x0
		internal U Comp; //Field offset: 0x0
		internal int SegmentWidth; //Field offset: 0x0

		public override void Execute() { }

	}

	public NativeList<T> Data; //Field offset: 0x0
	public U Comp; //Field offset: 0x0

	public JobHandle Schedule(JobHandle inputDeps = null) { }

}

