namespace UnityEngine.Rendering;

internal struct InstanceAllocators
{
	private InstanceAllocator m_InstanceAlloc_MeshRenderer; //Field offset: 0x0
	private InstanceAllocator m_InstanceAlloc_SpeedTree; //Field offset: 0x20
	private InstanceAllocator m_SharedInstanceAlloc; //Field offset: 0x40

	public InstanceHandle AllocateInstance(InstanceType type) { }

	public SharedInstanceHandle AllocateSharedInstance() { }

	public void Dispose() { }

	public void FreeInstance(InstanceHandle instance) { }

	public void FreeSharedInstance(SharedInstanceHandle instance) { }

	private InstanceAllocator GetInstanceAllocator(InstanceType type) { }

	public int GetInstanceHandlesLength(InstanceType type) { }

	public int GetInstancesLength(InstanceType type) { }

	public void Initialize() { }

}

