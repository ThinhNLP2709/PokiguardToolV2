namespace UnityEngine.Rendering;

public struct BatchDrawCommand
{
	public BatchDrawCommandFlags flags; //Field offset: 0x0
	public BatchID batchID; //Field offset: 0x4
	public BatchMaterialID materialID; //Field offset: 0x8
	public ushort splitVisibilityMask; //Field offset: 0xC
	public ushort lightmapIndex; //Field offset: 0xE
	public int sortingPosition; //Field offset: 0x10
	public uint visibleOffset; //Field offset: 0x14
	public uint visibleCount; //Field offset: 0x18
	public BatchMeshID meshID; //Field offset: 0x1C
	public ushort submeshIndex; //Field offset: 0x20
	private ushort unusedPadding2; //Field offset: 0x22

}

