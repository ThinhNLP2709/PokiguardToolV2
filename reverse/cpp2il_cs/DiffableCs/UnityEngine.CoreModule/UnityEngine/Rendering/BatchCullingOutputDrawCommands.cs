namespace UnityEngine.Rendering;

public struct BatchCullingOutputDrawCommands
{
	public BatchDrawCommand* drawCommands; //Field offset: 0x0
	public BatchDrawCommandIndirect* indirectDrawCommands; //Field offset: 0x8
	public BatchDrawCommandProcedural* proceduralDrawCommands; //Field offset: 0x10
	public BatchDrawCommandProceduralIndirect* proceduralIndirectDrawCommands; //Field offset: 0x18
	public Int32* visibleInstances; //Field offset: 0x20
	public BatchDrawRange* drawRanges; //Field offset: 0x28
	public Single* instanceSortingPositions; //Field offset: 0x30
	public Int32* drawCommandPickingInstanceIDs; //Field offset: 0x38
	public int drawCommandCount; //Field offset: 0x40
	public int indirectDrawCommandCount; //Field offset: 0x44
	public int proceduralDrawCommandCount; //Field offset: 0x48
	public int proceduralIndirectDrawCommandCount; //Field offset: 0x4C
	public int visibleInstanceCount; //Field offset: 0x50
	public int drawRangeCount; //Field offset: 0x54
	public int instanceSortingPositionFloatCount; //Field offset: 0x58

}

