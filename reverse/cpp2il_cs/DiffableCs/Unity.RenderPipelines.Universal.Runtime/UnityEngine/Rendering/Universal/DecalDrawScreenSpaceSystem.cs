namespace UnityEngine.Rendering.Universal;

internal class DecalDrawScreenSpaceSystem : DecalDrawSystem
{

	public DecalDrawScreenSpaceSystem(DecalEntityManager entityManager) { }

	protected virtual int GetPassIndex(DecalCachedChunk decalCachedChunk) { }

}

