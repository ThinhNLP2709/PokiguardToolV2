namespace UnityEngine;

[NativeContainer]
[NativeHeader("Runtime/Camera/RenderLoops/LightProbeContext.h")]
[StaticAccessor("LightProbeContextWrapper", StaticAccessorType::DoubleColon (2))]
public struct LightProbesQuery : IDisposable
{
	[NativeContainer]
	public struct LightProbesQueryDispose
	{
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr m_LightProbeContextWrapper; //Field offset: 0x0

		public void Dispose() { }

	}

	public struct LightProbesQueryDisposeJob : IJob
	{
		internal LightProbesQueryDispose Data; //Field offset: 0x0

		public override void Execute() { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal IntPtr m_LightProbeContextWrapper; //Field offset: 0x0
	internal Allocator m_AllocatorLabel; //Field offset: 0x8

	public LightProbesQuery(Allocator allocator) { }

	public void CalculateInterpolatedLightAndOcclusionProbes(NativeArray<Vector3> positions, NativeArray<Int32> tetrahedronIndices, NativeArray<SphericalHarmonicsL2> lightProbes, NativeArray<Vector4> occlusionProbes) { }

	[ThreadSafe]
	private static void CalculateInterpolatedLightAndOcclusionProbes(IntPtr lightProbeContextWrapper, IntPtr positions, IntPtr tetrahedronIndices, IntPtr lightProbes, IntPtr occlusionProbes, int count) { }

	private static IntPtr Create() { }

	[ThreadSafe]
	private static void Destroy(IntPtr lightProbeContextWrapper) { }

	public override void Dispose() { }

	public JobHandle Dispose(JobHandle inputDeps) { }

}

