namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct CullingJob : IJobParallelFor
{
	private enum CrossFadeType
	{
		kDisabled = 0,
		kCrossFadeOut = 1,
		kCrossFadeIn = 2,
		kVisible = 3,
	}

	public const int k_BatchSize = 32; //Field offset: 0x0
	private const uint k_LODFadeZeroPacked = 127; //Field offset: 0x0
	private const float k_LODPercentInvisible = 0; //Field offset: 0x0
	private const float k_LODPercentFullyVisible = 1; //Field offset: 0x0
	private const float k_LODPercentSpeedTree = 2; //Field offset: 0x0
	private const float k_SmallMeshTransitionWidth = 0.1; //Field offset: 0x0
	[ReadOnly]
	public BinningConfig binningConfig; //Field offset: 0x0
	[ReadOnly]
	public BatchCullingViewType viewType; //Field offset: 0x8
	[ReadOnly]
	public float3 cameraPosition; //Field offset: 0xC
	[ReadOnly]
	public float sqrScreenRelativeMetric; //Field offset: 0x18
	[ReadOnly]
	public float minScreenRelativeHeight; //Field offset: 0x1C
	[ReadOnly]
	public bool isOrtho; //Field offset: 0x20
	[ReadOnly]
	public bool cullLightmappedShadowCasters; //Field offset: 0x21
	[ReadOnly]
	public int maxLOD; //Field offset: 0x24
	[ReadOnly]
	public uint cullingLayerMask; //Field offset: 0x28
	[ReadOnly]
	public ulong sceneCullingMask; //Field offset: 0x30
	[ReadOnly]
	public NativeArray<PlanePacket4> frustumPlanePackets; //Field offset: 0x38
	[ReadOnly]
	public NativeArray<SplitInfo> frustumSplitInfos; //Field offset: 0x48
	[ReadOnly]
	public NativeArray<Plane> lightFacingFrustumPlanes; //Field offset: 0x58
	[ReadOnly]
	public NativeArray<SplitInfo> receiverSplitInfos; //Field offset: 0x68
	public float3x3 worldToLightSpaceRotation; //Field offset: 0x78
	[ReadOnly]
	public ReadOnly instanceData; //Field offset: 0xA0
	[ReadOnly]
	public ReadOnly sharedInstanceData; //Field offset: 0x178
	[NativeDisableContainerSafetyRestriction]
	[NoAlias]
	[ReadOnly]
	public NativeList<LODGroupCullingData> lodGroupCullingData; //Field offset: 0x218
	[NativeDisableUnsafePtrRestriction]
	[ReadOnly]
	public IntPtr occlusionBuffer; //Field offset: 0x220
	[NativeDisableParallelForRestriction]
	[WriteOnly]
	public NativeArray<Byte> rendererVisibilityMasks; //Field offset: 0x228
	[NativeDisableParallelForRestriction]
	[WriteOnly]
	public NativeArray<Byte> rendererCrossFadeValues; //Field offset: 0x238

	private float CalculateLODVisibility(int instanceIndex, int sharedInstanceIndex, InstanceFlags instanceFlags) { }

	private uint CalculateVisibilityMask(int instanceIndex, int sharedInstanceIndex, InstanceFlags instanceFlags) { }

	public override void Execute(int instanceIndex) { }

	private static uint PackFloatToUint8(float percent) { }

}

