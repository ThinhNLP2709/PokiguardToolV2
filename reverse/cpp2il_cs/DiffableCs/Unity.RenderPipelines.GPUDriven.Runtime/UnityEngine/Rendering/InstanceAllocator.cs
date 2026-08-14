namespace UnityEngine.Rendering;

internal struct InstanceAllocator
{
	private NativeArray<Int32> m_StructData; //Field offset: 0x0
	private NativeList<Int32> m_FreeInstances; //Field offset: 0x10
	private int m_BaseInstanceOffset; //Field offset: 0x18
	private int m_InstanceStride; //Field offset: 0x1C

	public int length
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public bool valid
	{
		 get { } //Length: 50
	}

	public int AllocateInstance() { }

	public void Dispose() { }

	public void FreeInstance(int instance) { }

	public int get_length() { }

	public bool get_valid() { }

	public int GetNumAllocated() { }

	public void Initialize(int baseInstanceOffset = 0, int instanceStride = 1) { }

	public void set_length(int value) { }

}

