namespace UnityEngine.Rendering;

internal struct InstanceOcclusionTestSubviewSettings
{
	public int testCount; //Field offset: 0x0
	public int occluderSubviewIndices; //Field offset: 0x4
	public int occluderSubviewMask; //Field offset: 0x8
	public int cullingSplitIndices; //Field offset: 0xC
	public int cullingSplitMask; //Field offset: 0x10

	public static InstanceOcclusionTestSubviewSettings FromSpan(ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests) { }

}

