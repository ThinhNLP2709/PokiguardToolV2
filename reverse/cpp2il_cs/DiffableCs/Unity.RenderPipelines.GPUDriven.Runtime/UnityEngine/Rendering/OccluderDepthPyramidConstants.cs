namespace UnityEngine.Rendering;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\GPUDriven\\OccluderDepthPyramidConstants.cs", needAccessors = False, generateCBuffer = True)]
internal struct OccluderDepthPyramidConstants
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_InvViewProjMatrix>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_MipOffsetAndSize>e__FixedBuffer
	{
		public uint FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_SilhouettePlanes>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_SrcOffset>e__FixedBuffer
	{
		public uint FixedElementField; //Field offset: 0x0

	}

	[FixedBuffer(typeof(float), 96)]
	[HLSLArray(6, typeof(Matrix4x4))]
	public <_InvViewProjMatrix>e__FixedBuffer _InvViewProjMatrix; //Field offset: 0x0
	[FixedBuffer(typeof(float), 24)]
	[HLSLArray(6, typeof(Vector4))]
	public <_SilhouettePlanes>e__FixedBuffer _SilhouettePlanes; //Field offset: 0x180
	[FixedBuffer(typeof(uint), 24)]
	[HLSLArray(6, typeof(ShaderGenUInt4))]
	public <_SrcOffset>e__FixedBuffer _SrcOffset; //Field offset: 0x1E0
	[FixedBuffer(typeof(uint), 20)]
	[HLSLArray(5, typeof(ShaderGenUInt4))]
	public <_MipOffsetAndSize>e__FixedBuffer _MipOffsetAndSize; //Field offset: 0x240
	public uint _OccluderMipLayoutSizeX; //Field offset: 0x290
	public uint _OccluderMipLayoutSizeY; //Field offset: 0x294
	public uint _OccluderDepthPyramidPad0; //Field offset: 0x298
	public uint _OccluderDepthPyramidPad1; //Field offset: 0x29C
	public uint _SrcSliceIndices; //Field offset: 0x2A0
	public uint _DstSubviewIndices; //Field offset: 0x2A4
	public uint _MipCount; //Field offset: 0x2A8
	public uint _SilhouettePlaneCount; //Field offset: 0x2AC

}

