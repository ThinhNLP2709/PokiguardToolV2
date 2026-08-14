namespace UnityEngine.Rendering;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\GPUDriven\\OcclusionCullingDebugShaderVariables.cs", needAccessors = False, generateCBuffer = True)]
internal struct OcclusionCullingDebugShaderVariables
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <_OccluderMipBounds>e__FixedBuffer
	{
		public uint FixedElementField; //Field offset: 0x0

	}

	public Vector4 _DepthSizeInOccluderPixels; //Field offset: 0x0
	[FixedBuffer(typeof(uint), 32)]
	[HLSLArray(8, typeof(ShaderGenUInt4))]
	public <_OccluderMipBounds>e__FixedBuffer _OccluderMipBounds; //Field offset: 0x10
	public uint _OccluderMipLayoutSizeX; //Field offset: 0x90
	public uint _OccluderMipLayoutSizeY; //Field offset: 0x94
	public uint _OcclusionCullingDebugPad0; //Field offset: 0x98
	public uint _OcclusionCullingDebugPad1; //Field offset: 0x9C

}

