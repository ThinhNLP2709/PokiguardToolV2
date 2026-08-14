namespace UnityEngine.Rendering;

internal struct ReceiverSphereCuller
{
	public struct SplitInfo
	{
		public float4 receiverSphereLightSpace; //Field offset: 0x0
		public float cascadeBlendCullingFactor; //Field offset: 0x10

	}

	public NativeList<SplitInfo> splitInfos; //Field offset: 0x0
	public float3x3 worldToLightSpaceRotation; //Field offset: 0x8

	internal static uint ComputeSplitVisibilityMask(NativeArray<Plane> lightFacingFrustumPlanes, NativeArray<SplitInfo> splitInfos, float3x3 worldToLightSpaceRotation, in AABB bounds) { }

	internal static ReceiverSphereCuller Create(in BatchCullingContext cc, Allocator allocator) { }

	internal static ReceiverSphereCuller CreateEmptyForTesting(Allocator allocator) { }

	internal void Dispose(JobHandle job) { }

	internal static float DistanceUntilCylinderFullyCrossesPlane(float3 cylinderCenter, float3 cylinderDirection, float cylinderRadius, Plane plane) { }

	internal bool UseReceiverPlanes() { }

}

