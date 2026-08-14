namespace UnityEngine.Rendering;

public struct BatchDrawCommandIndirect
{
	public BatchDrawCommandFlags flags; //Field offset: 0x0
	public BatchID batchID; //Field offset: 0x4
	public BatchMaterialID materialID; //Field offset: 0x8
	public ushort splitVisibilityMask; //Field offset: 0xC
	public ushort lightmapIndex; //Field offset: 0xE
	public int sortingPosition; //Field offset: 0x10
	public uint visibleOffset; //Field offset: 0x14
	public BatchMeshID meshID; //Field offset: 0x18
	public MeshTopology topology; //Field offset: 0x1C
	public GraphicsBufferHandle visibleInstancesBufferHandle; //Field offset: 0x20
	public uint visibleInstancesBufferWindowOffset; //Field offset: 0x24
	public uint visibleInstancesBufferWindowSizeBytes; //Field offset: 0x28
	public GraphicsBufferHandle indirectArgsBufferHandle; //Field offset: 0x2C
	public uint indirectArgsBufferOffset; //Field offset: 0x30

}

