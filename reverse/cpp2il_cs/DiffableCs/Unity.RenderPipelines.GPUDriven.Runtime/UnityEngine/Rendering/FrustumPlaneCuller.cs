namespace UnityEngine.Rendering;

internal struct FrustumPlaneCuller
{
	public struct PlanePacket4
	{
		public float4 nx; //Field offset: 0x0
		public float4 ny; //Field offset: 0x10
		public float4 nz; //Field offset: 0x20
		public float4 d; //Field offset: 0x30
		public float4 nxAbs; //Field offset: 0x40
		public float4 nyAbs; //Field offset: 0x50
		public float4 nzAbs; //Field offset: 0x60

		public PlanePacket4(NativeArray<Plane> planes, int offset, int limit) { }

	}

	public struct SplitInfo
	{
		public int packetCount; //Field offset: 0x0

	}

	public NativeList<PlanePacket4> planePackets; //Field offset: 0x0
	public NativeList<SplitInfo> splitInfos; //Field offset: 0x8

	internal static uint ComputeSplitVisibilityMask(NativeArray<PlanePacket4> planePackets, NativeArray<SplitInfo> splitInfos, in AABB bounds) { }

	internal static FrustumPlaneCuller Create(in BatchCullingContext cc, NativeArray<Plane> receiverPlanes, in ReceiverSphereCuller receiverSphereCuller, Allocator allocator) { }

	internal void Dispose(JobHandle job) { }

}

