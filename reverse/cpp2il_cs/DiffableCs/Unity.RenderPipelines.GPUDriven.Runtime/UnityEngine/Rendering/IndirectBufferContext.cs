namespace UnityEngine.Rendering;

internal struct IndirectBufferContext
{
	internal enum BufferState
	{
		Pending = 0,
		Zeroed = 1,
		NoOcclusionTest = 2,
		AllInstancesOcclusionTested = 3,
		OccludedInstancesReTested = 4,
	}

	public JobHandle cullingJobHandle; //Field offset: 0x0
	public BufferState bufferState; //Field offset: 0x10
	public int occluderVersion; //Field offset: 0x14
	public int subviewMask; //Field offset: 0x18

	public IndirectBufferContext(JobHandle cullingJobHandle) { }

	public bool Matches(BufferState bufferState, int occluderVersion, int subviewMask) { }

}

