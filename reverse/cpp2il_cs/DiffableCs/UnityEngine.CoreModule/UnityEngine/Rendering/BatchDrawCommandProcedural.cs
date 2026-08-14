namespace UnityEngine.Rendering;

public struct BatchDrawCommandProcedural
{
	public BatchDrawCommandFlags flags; //Field offset: 0x0
	public BatchID batchID; //Field offset: 0x4
	public BatchMaterialID materialID; //Field offset: 0x8
	public ushort splitVisibilityMask; //Field offset: 0xC
	public ushort lightmapIndex; //Field offset: 0xE
	public int sortingPosition; //Field offset: 0x10
	public uint visibleOffset; //Field offset: 0x14
	public uint visibleCount; //Field offset: 0x18
	public MeshTopology topology; //Field offset: 0x1C
	public GraphicsBufferHandle indexBufferHandle; //Field offset: 0x20
	public uint baseVertex; //Field offset: 0x24
	public uint indexOffsetBytes; //Field offset: 0x28
	public uint elementCount; //Field offset: 0x2C

}

