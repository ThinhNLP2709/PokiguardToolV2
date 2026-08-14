namespace UnityEngine.Experimental.Rendering;

internal class XROcclusionMesh
{
	private static readonly ProfilingSampler k_OcclusionMeshProfilingSampler; //Field offset: 0x0
	private XRPass m_Pass; //Field offset: 0x10
	private Mesh m_CombinedMesh; //Field offset: 0x18
	private Material m_Material; //Field offset: 0x20
	private int m_CombinedMeshHashCode; //Field offset: 0x28

	internal bool hasValidOcclusionMesh
	{
		internal get { } //Length: 191
	}

	private static XROcclusionMesh() { }

	internal XROcclusionMesh(XRPass xrPass) { }

	private void CreateOcclusionMeshCombined() { }

	internal bool get_hasValidOcclusionMesh() { }

	private bool IsOcclusionMeshSupported() { }

	internal void RenderOcclusionMesh(CommandBuffer cmd, float occlusionMeshScale, bool yFlip = false) { }

	internal void SetMaterial(Material mat) { }

	private bool TryGetOcclusionMeshCombinedHashCode(out int hashCode) { }

	internal void UpdateCombinedMesh() { }

}

