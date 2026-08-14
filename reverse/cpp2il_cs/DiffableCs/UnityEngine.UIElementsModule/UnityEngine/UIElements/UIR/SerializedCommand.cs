namespace UnityEngine.UIElements.UIR;

internal struct SerializedCommand
{
	public SerializedCommandType type; //Field offset: 0x0
	public IntPtr vertexBuffer; //Field offset: 0x8
	public IntPtr indexBuffer; //Field offset: 0x10
	public int firstRange; //Field offset: 0x18
	public int rangeCount; //Field offset: 0x1C
	public int textureName; //Field offset: 0x20
	public Texture texture; //Field offset: 0x28
	public int gpuDataOffset; //Field offset: 0x30
	public Vector4 gpuData0; //Field offset: 0x34
	public Vector4 gpuData1; //Field offset: 0x44

}

