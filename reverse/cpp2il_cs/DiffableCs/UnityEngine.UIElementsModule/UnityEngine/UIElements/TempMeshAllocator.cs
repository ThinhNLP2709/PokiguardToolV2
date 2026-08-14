namespace UnityEngine.UIElements;

[NativeContainer]
[NativeContainerIsReadOnly]
public struct TempMeshAllocator
{
	private GCHandle m_Handle; //Field offset: 0x0

	public void AllocateTempMesh(int vertexCount, int indexCount, out NativeSlice<Vertex>& vertices, out NativeSlice<UInt16>& indices) { }

	internal static void Create(GCHandle handle, out TempMeshAllocator allocator) { }

}

