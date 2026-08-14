namespace UnityEngine.Rendering.Universal;

internal class DecalDrawErrorSystem : DecalDrawSystem
{
	private DecalTechnique m_Technique; //Field offset: 0x40

	public DecalDrawErrorSystem(DecalEntityManager entityManager, DecalTechnique technique) { }

	protected virtual Material GetMaterial(DecalEntityChunk decalEntityChunk) { }

	protected virtual int GetPassIndex(DecalCachedChunk decalCachedChunk) { }

}

