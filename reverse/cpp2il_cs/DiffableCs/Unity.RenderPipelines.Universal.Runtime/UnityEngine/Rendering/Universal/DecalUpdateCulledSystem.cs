namespace UnityEngine.Rendering.Universal;

internal class DecalUpdateCulledSystem
{
	private DecalEntityManager m_EntityManager; //Field offset: 0x10
	private ProfilingSampler m_Sampler; //Field offset: 0x18

	public DecalUpdateCulledSystem(DecalEntityManager entityManager) { }

	public void Execute() { }

	private void Execute(DecalCulledChunk culledChunk, int count) { }

}

