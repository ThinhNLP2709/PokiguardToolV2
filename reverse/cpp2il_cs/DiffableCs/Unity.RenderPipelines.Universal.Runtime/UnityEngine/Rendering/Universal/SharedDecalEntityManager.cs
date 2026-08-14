namespace UnityEngine.Rendering.Universal;

internal class SharedDecalEntityManager : IDisposable
{
	private DecalEntityManager m_DecalEntityManager; //Field offset: 0x10
	private int m_ReferenceCounter; //Field offset: 0x18

	public SharedDecalEntityManager() { }

	public override void Dispose() { }

	public DecalEntityManager Get() { }

	private void OnAllDecalPropertyChange() { }

	private void OnDecalAdd(DecalProjector decalProjector) { }

	private void OnDecalMaterialChange(DecalProjector decalProjector) { }

	private void OnDecalPropertyChange(DecalProjector decalProjector) { }

	private void OnDecalRemove(DecalProjector decalProjector) { }

	public void Release(DecalEntityManager decalEntityManager) { }

}

