namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct UpdateLODGroupTransformJob : IJobParallelFor
{
	public const int k_BatchSize = 256; //Field offset: 0x0
	[ReadOnly]
	public NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataHash; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Int32> lodGroupIDs; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<Vector3> worldSpaceReferencePoints; //Field offset: 0x20
	[ReadOnly]
	public NativeArray<Single> worldSpaceSizes; //Field offset: 0x30
	[ReadOnly]
	public bool requiresGPUUpload; //Field offset: 0x40
	[ReadOnly]
	public bool supportDitheringCrossFade; //Field offset: 0x41
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<LODGroupData> lodGroupData; //Field offset: 0x48
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[WriteOnly]
	public NativeList<LODGroupCullingData> lodGroupCullingData; //Field offset: 0x50
	[NativeDisableUnsafePtrRestriction]
	public UnsafeAtomicCounter32 atomicUpdateCount; //Field offset: 0x58

	public override void Execute(int index) { }

}

