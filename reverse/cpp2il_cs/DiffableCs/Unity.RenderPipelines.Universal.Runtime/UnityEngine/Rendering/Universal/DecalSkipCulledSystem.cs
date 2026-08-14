namespace UnityEngine.Rendering.Universal;

internal class DecalSkipCulledSystem
{
	private DecalEntityManager m_EntityManager; //Field offset: 0x10
	private ProfilingSampler m_Sampler; //Field offset: 0x18
	private Camera m_Camera; //Field offset: 0x20

	public DecalSkipCulledSystem(DecalEntityManager entityManager) { }

	public void Execute(Camera camera) { }

	private void Execute(DecalCulledChunk culledChunk, int count) { }

	internal static ulong GetSceneCullingMaskFromCamera(Camera camera) { }

}

