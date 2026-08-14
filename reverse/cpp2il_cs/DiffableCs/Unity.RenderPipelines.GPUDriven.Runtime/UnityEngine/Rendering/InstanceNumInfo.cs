namespace UnityEngine.Rendering;

internal struct InstanceNumInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <InstanceNums>e__FixedBuffer
	{
		public int FixedElementField; //Field offset: 0x0

	}

	[FixedBuffer(typeof(int), 2)]
	public <InstanceNums>e__FixedBuffer InstanceNums; //Field offset: 0x0

	public InstanceNumInfo(InstanceType type, int instanceNum) { }

	public InstanceNumInfo(int meshRendererNum = 0, int speedTreeNum = 0) { }

	public int GetInstanceNum(InstanceType type) { }

	public int GetInstanceNumIncludingChildren(InstanceType type) { }

	public int GetTotalInstanceNum() { }

	public void InitDefault() { }

}

