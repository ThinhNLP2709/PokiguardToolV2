namespace UnityEngine.Rendering.Universal;

internal class DecalUpdateCachedSystem
{
	[BurstCompile]
	internal struct UpdateTransformsJob : IJobParallelForTransform
	{
		private static readonly quaternion k_MinusYtoZRotation; //Field offset: 0x0
		public NativeArray<float3> positions; //Field offset: 0x0
		public NativeArray<quaternion> rotations; //Field offset: 0x10
		public NativeArray<float3> scales; //Field offset: 0x20
		public NativeArray<Boolean> dirty; //Field offset: 0x30
		[ReadOnly]
		public NativeArray<DecalScaleMode> scaleModes; //Field offset: 0x40
		[ReadOnly]
		public NativeArray<float4x4> sizeOffsets; //Field offset: 0x50
		[WriteOnly]
		public NativeArray<float4x4> decalToWorlds; //Field offset: 0x60
		[WriteOnly]
		public NativeArray<float4x4> normalToWorlds; //Field offset: 0x70
		[WriteOnly]
		public NativeArray<BoundingSphere> boundingSpheres; //Field offset: 0x80
		public float minDistance; //Field offset: 0x90

		private static UpdateTransformsJob() { }

		private float DistanceBetweenQuaternions(quaternion a, quaternion b) { }

		public override void Execute(int index, TransformAccess transform) { }

		private BoundingSphere GetDecalProjectBoundingSphere(Matrix4x4 decalToWorld) { }

	}

	private DecalEntityManager m_EntityManager; //Field offset: 0x10
	private ProfilingSampler m_Sampler; //Field offset: 0x18
	private ProfilingSampler m_SamplerJob; //Field offset: 0x20

	public DecalUpdateCachedSystem(DecalEntityManager entityManager) { }

	public void Execute() { }

	private void Execute(DecalEntityChunk entityChunk, DecalCachedChunk cachedChunk, int count) { }

}

