namespace UnityEngine.Rendering.Universal;

internal class DecalCreateDrawCallSystem
{
	[BurstCompile]
	private struct DrawCallJob : IJob
	{
		[ReadOnly]
		public NativeArray<float4x4> decalToWorlds; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<float4x4> normalToWorlds; //Field offset: 0x10
		[ReadOnly]
		public NativeArray<float4x4> sizeOffsets; //Field offset: 0x20
		[ReadOnly]
		public NativeArray<float2> drawDistances; //Field offset: 0x30
		[ReadOnly]
		public NativeArray<float2> angleFades; //Field offset: 0x40
		[ReadOnly]
		public NativeArray<float4> uvScaleBiases; //Field offset: 0x50
		[ReadOnly]
		public NativeArray<Int32> layerMasks; //Field offset: 0x60
		[ReadOnly]
		public NativeArray<UInt64> sceneLayerMasks; //Field offset: 0x70
		[ReadOnly]
		public NativeArray<Single> fadeFactors; //Field offset: 0x80
		[ReadOnly]
		public NativeArray<BoundingSphere> boundingSpheres; //Field offset: 0x90
		[ReadOnly]
		public NativeArray<UInt32> renderingLayerMasks; //Field offset: 0xA0
		public Vector3 cameraPosition; //Field offset: 0xB0
		public ulong sceneCullingMask; //Field offset: 0xC0
		public int cullingMask; //Field offset: 0xC8
		[ReadOnly]
		public NativeArray<Int32> visibleDecalIndices; //Field offset: 0xD0
		public int visibleDecalCount; //Field offset: 0xE0
		public float maxDrawDistance; //Field offset: 0xE4
		[WriteOnly]
		public NativeArray<float4x4> decalToWorldsDraw; //Field offset: 0xE8
		[WriteOnly]
		public NativeArray<float4x4> normalToDecalsDraw; //Field offset: 0xF8
		[WriteOnly]
		public NativeArray<Single> renderingLayerMasksDraw; //Field offset: 0x108
		[WriteOnly]
		public NativeArray<DecalSubDrawCall> subCalls; //Field offset: 0x118
		[WriteOnly]
		public NativeArray<Int32> subCallCount; //Field offset: 0x128

		public override void Execute() { }

	}

	private DecalEntityManager m_EntityManager; //Field offset: 0x10
	private ProfilingSampler m_Sampler; //Field offset: 0x18
	private float m_MaxDrawDistance; //Field offset: 0x20

	public float maxDrawDistance
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public DecalCreateDrawCallSystem(DecalEntityManager entityManager, float maxDrawDistance) { }

	public void Execute() { }

	private void Execute(DecalCachedChunk cachedChunk, DecalCulledChunk culledChunk, DecalDrawCallChunk drawCallChunk, int count) { }

	public float get_maxDrawDistance() { }

	public void set_maxDrawDistance(float value) { }

}

