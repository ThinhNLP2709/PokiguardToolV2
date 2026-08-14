namespace UnityEngine.UIElements;

internal struct UnsafeMeshGenerationNode
{
	private GCHandle m_Handle; //Field offset: 0x0

	internal static void Create(GCHandle handle, out UnsafeMeshGenerationNode node) { }

	internal void DrawGradientsInternal(NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, VectorImage gradientsOwner) { }

	public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture = null) { }

	internal void DrawMeshInternal(NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, Texture texture = null, bool skipAtlas = false) { }

	private MeshGenerationNodeImpl GetManaged() { }

	internal Entry GetParentEntry() { }

}

