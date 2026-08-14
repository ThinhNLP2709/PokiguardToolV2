namespace UnityEngine.Rendering.Universal;

internal class DecalDrawDBufferSystem : DecalDrawSystem
{

	public DecalDrawDBufferSystem(DecalEntityManager entityManager) { }

	protected virtual int GetPassIndex(DecalCachedChunk decalCachedChunk) { }

}

