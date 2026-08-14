namespace UnityEngine.Rendering;

internal struct InstanceCullerViewStats
{
	public BatchCullingViewType viewType; //Field offset: 0x0
	public int viewInstanceID; //Field offset: 0x4
	public int splitIndex; //Field offset: 0x8
	public int visibleInstances; //Field offset: 0xC
	public int drawCommands; //Field offset: 0x10

}

