namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct FreeLODGroupDataJob : IJob
{
	[ReadOnly]
	public NativeArray<Int32> destroyedLODGroupsID; //Field offset: 0x0
	public NativeList<LODGroupData> lodGroupsData; //Field offset: 0x10
	public NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataHash; //Field offset: 0x18
	public NativeList<GPUInstanceIndex> freeLODGroupDataHandles; //Field offset: 0x28
	[NativeDisableUnsafePtrRestriction]
	public Int32* removedRendererCount; //Field offset: 0x30

	public override void Execute() { }

}

