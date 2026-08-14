namespace UnityEngine.Rendering;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\Lighting\\ProbeVolume\\ShaderVariablesProbeVolumes.cs", needAccessors = False, generateCBuffer = True, constantRegister = 6)]
internal struct ShaderVariablesProbeVolumes
{
	public Vector4 _Offset_LayerCount; //Field offset: 0x0
	public Vector4 _MinLoadedCellInEntries_IndirectionEntryDim; //Field offset: 0x10
	public Vector4 _MaxLoadedCellInEntries_RcpIndirectionEntryDim; //Field offset: 0x20
	public Vector4 _PoolDim_MinBrickSize; //Field offset: 0x30
	public Vector4 _RcpPoolDim_XY; //Field offset: 0x40
	public Vector4 _MinEntryPos_Noise; //Field offset: 0x50
	public uint4 _EntryCount_X_XY_LeakReduction; //Field offset: 0x60
	public Vector4 _Biases_NormalizationClamp; //Field offset: 0x70
	public Vector4 _FrameIndex_Weights; //Field offset: 0x80
	public uint4 _ProbeVolumeLayerMask; //Field offset: 0x90

}

