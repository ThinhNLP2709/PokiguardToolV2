namespace UnityEngine.Rendering;

internal struct ReceiverPlanes
{
	public NativeList<Plane> planes; //Field offset: 0x0
	public int lightFacingPlaneCount; //Field offset: 0x8

	internal static ReceiverPlanes Create(in BatchCullingContext cc, Allocator allocator) { }

	internal static ReceiverPlanes CreateEmptyForTesting(Allocator allocator) { }

	internal void Dispose(JobHandle job) { }

	private static bool IsSignBitSet(float x) { }

	internal NativeArray<Plane> LightFacingFrustumPlaneSubArray() { }

	internal NativeArray<Plane> SilhouettePlaneSubArray() { }

}

