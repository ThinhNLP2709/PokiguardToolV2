namespace UnityEngine.Rendering.Universal;

internal class DecalDrawGBufferSystem : DecalDrawSystem
{

	public DecalDrawGBufferSystem(DecalEntityManager entityManager) { }

	protected virtual int GetPassIndex(DecalCachedChunk decalCachedChunk) { }

}

