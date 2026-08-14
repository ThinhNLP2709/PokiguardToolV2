namespace UnityEngine.Rendering;

public struct ProbeVolumeSystemParameters
{
	public ProbeVolumeTextureMemoryBudget memoryBudget; //Field offset: 0x0
	public ProbeVolumeBlendingTextureMemoryBudget blendingMemoryBudget; //Field offset: 0x4
	public ProbeVolumeSHBands shBands; //Field offset: 0x8
	public bool supportScenarios; //Field offset: 0xC
	public bool supportScenarioBlending; //Field offset: 0xD
	public bool supportGPUStreaming; //Field offset: 0xE
	public bool supportDiskStreaming; //Field offset: 0xF
	[Obsolete("This field is not used anymore.")]
	public Shader probeDebugShader; //Field offset: 0x10
	[Obsolete("This field is not used anymore.")]
	public Shader probeSamplingDebugShader; //Field offset: 0x18
	[Obsolete("This field is not used anymore.")]
	public Texture probeSamplingDebugTexture; //Field offset: 0x20
	[Obsolete("This field is not used anymore.")]
	public Mesh probeSamplingDebugMesh; //Field offset: 0x28
	[Obsolete("This field is not used anymore.")]
	public Shader offsetDebugShader; //Field offset: 0x30
	[Obsolete("This field is not used anymore.")]
	public Shader fragmentationDebugShader; //Field offset: 0x38
	[Obsolete("This field is not used anymore.")]
	public ComputeShader scenarioBlendingShader; //Field offset: 0x40
	[Obsolete("This field is not used anymore.")]
	public ComputeShader streamingUploadShader; //Field offset: 0x48
	[Obsolete("This field is not used anymore.")]
	public ProbeVolumeSceneData sceneData; //Field offset: 0x50
	[Obsolete("This field is not used anymore. Used with the current Shader Stripping Settings. #from(2023.3)")]
	public bool supportsRuntimeDebug; //Field offset: 0x58

}

