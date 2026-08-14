namespace UnityEngine.Rendering;

internal struct GPUInstanceComponentDesc
{
	public int propertyID; //Field offset: 0x0
	public int byteSize; //Field offset: 0x4
	public bool isOverriden; //Field offset: 0x8
	public bool isPerInstance; //Field offset: 0x9
	public InstanceType instanceType; //Field offset: 0xC
	public InstanceComponentGroup componentGroup; //Field offset: 0x10

	public GPUInstanceComponentDesc(int inPropertyID, int inByteSize, bool inIsOverriden, bool inPerInstance, InstanceType inInstanceType, InstanceComponentGroup inComponentType) { }

}

