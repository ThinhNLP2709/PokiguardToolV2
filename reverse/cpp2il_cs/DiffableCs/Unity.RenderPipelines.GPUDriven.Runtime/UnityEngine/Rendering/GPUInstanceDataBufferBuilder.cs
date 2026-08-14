namespace UnityEngine.Rendering;

internal struct GPUInstanceDataBufferBuilder : IDisposable
{
	private NativeList<GPUInstanceComponentDesc> m_Components; //Field offset: 0x0

	public void AddComponent(int propertyID, bool isOverriden, bool isPerInstance, InstanceType instanceType, InstanceComponentGroup componentGroup = 1) { }

	public void AddComponent(int propertyID, bool isOverriden, int byteSize, bool isPerInstance, InstanceType instanceType, InstanceComponentGroup componentGroup) { }

	public GPUInstanceDataBuffer Build(in InstanceNumInfo instanceNumInfo) { }

	private MetadataValue CreateMetadataValue(int nameID, int gpuAddress, bool isOverridden) { }

	public override void Dispose() { }

}

