namespace UnityEngine.Rendering.Universal;

internal class DecalUpdateCullingGroupSystem
{
	private Single[] m_BoundingDistance; //Field offset: 0x10
	private Camera m_Camera; //Field offset: 0x18
	private DecalEntityManager m_EntityManager; //Field offset: 0x20
	private ProfilingSampler m_Sampler; //Field offset: 0x28

	public float boundingDistance
	{
		 get { } //Length: 40
		 set { } //Length: 40
	}

	public DecalUpdateCullingGroupSystem(DecalEntityManager entityManager, float drawDistance) { }

	public void Execute(Camera camera) { }

	public void Execute(DecalCachedChunk cachedChunk, DecalCulledChunk culledChunk, int count) { }

	public float get_boundingDistance() { }

	internal static ulong GetSceneCullingMaskFromCamera(Camera camera) { }

	public void set_boundingDistance(float value) { }

}

