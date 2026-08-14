namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct AllocateOrGetLODGroupDataInstancesJob : IJob
{
	[ReadOnly]
	public NativeArray<Int32> lodGroupsID; //Field offset: 0x0
	public NativeList<LODGroupData> lodGroupsData; //Field offset: 0x10
	public NativeList<LODGroupCullingData> lodGroupCullingData; //Field offset: 0x18
	public NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataHash; //Field offset: 0x20
	public NativeList<GPUInstanceIndex> freeLODGroupDataHandles; //Field offset: 0x30
	[WriteOnly]
	public NativeArray<GPUInstanceIndex> lodGroupInstances; //Field offset: 0x38
	[NativeDisableUnsafePtrRestriction]
	public Int32* previousRendererCount; //Field offset: 0x48

	public override void Execute() { }

}

