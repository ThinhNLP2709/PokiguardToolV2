namespace UnityEngine.Rendering.Universal;

internal abstract class DecalDrawSystem
{
	internal static readonly uint MaxBatchSize; //Field offset: 0x0
	protected DecalEntityManager m_EntityManager; //Field offset: 0x10
	private Matrix4x4[] m_WorldToDecals; //Field offset: 0x18
	private Matrix4x4[] m_NormalToDecals; //Field offset: 0x20
	private Single[] m_DecalLayerMasks; //Field offset: 0x28
	private ProfilingSampler m_Sampler; //Field offset: 0x30
	[CompilerGenerated]
	private Material <overrideMaterial>k__BackingField; //Field offset: 0x38

	public Material overrideMaterial
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static DecalDrawSystem() { }

	public DecalDrawSystem(string sampler, DecalEntityManager entityManager) { }

	private void Draw(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int passIndex) { }

	private void Draw(in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk) { }

	private void DrawInstanced(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int passIndex) { }

	private void DrawInstanced(in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk) { }

	public void Execute(CommandBuffer cmd) { }

	internal void Execute(RasterCommandBuffer cmd) { }

	private void Execute(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int count) { }

	public void Execute(in CameraData cameraData) { }

	private void Execute(in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int count) { }

	[CompilerGenerated]
	public Material get_overrideMaterial() { }

	protected override Material GetMaterial(DecalEntityChunk decalEntityChunk) { }

	protected abstract int GetPassIndex(DecalCachedChunk decalCachedChunk) { }

	[CompilerGenerated]
	public void set_overrideMaterial(Material value) { }

}

