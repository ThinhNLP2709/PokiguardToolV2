namespace UnityEngine.Rendering.Universal;

public abstract class ScriptableRendererData : ScriptableObject
{
	[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)", False)]
	[ReloadGroup]
	internal sealed class DebugShaderResources
	{
		[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)", False)]
		[Reload("Shaders/Debug/DebugReplacement.shader", Package::Root (1))]
		public Shader debugReplacementPS; //Field offset: 0x10
		[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)", False)]
		[Reload("Shaders/Debug/HDRDebugView.shader", Package::Root (1))]
		public Shader hdrDebugViewPS; //Field offset: 0x18

		public DebugShaderResources() { }

	}

	[Obsolete("Probe volume debug resource are now in the ProbeVolumeDebugResources class.")]
	[ReloadGroup]
	internal sealed class ProbeVolumeResources
	{
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Shader probeVolumeDebugShader; //Field offset: 0x10
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Shader probeVolumeFragmentationDebugShader; //Field offset: 0x18
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Shader probeVolumeOffsetDebugShader; //Field offset: 0x20
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Shader probeVolumeSamplingDebugShader; //Field offset: 0x28
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Mesh probeSamplingDebugMesh; //Field offset: 0x30
		[Obsolete("This shader is now in the ProbeVolumeDebugResources class.")]
		public Texture2D probeSamplingDebugTexture; //Field offset: 0x38
		[Obsolete("This shader is now in the ProbeVolumeRuntimeResources class.")]
		public ComputeShader probeVolumeBlendStatesCS; //Field offset: 0x40

		public ProbeVolumeResources() { }

	}

	[Obsolete("Moved to UniversalRenderPipelineDebugShaders on GraphicsSettings. #from(2023.3)", False)]
	public DebugShaderResources debugShaders; //Field offset: 0x18
	[Obsolete("Probe volume debug resource are now in the ProbeVolumeDebugResources class.")]
	public ProbeVolumeResources probeVolumeResources; //Field offset: 0x20
	[CompilerGenerated]
	private bool <isInvalidated>k__BackingField; //Field offset: 0x28
	[SerializeField]
	internal List<ScriptableRendererFeature> m_RendererFeatures; //Field offset: 0x30
	[SerializeField]
	internal List<Int64> m_RendererFeatureMap; //Field offset: 0x38
	[SerializeField]
	private bool m_UseNativeRenderPass; //Field offset: 0x40

	internal bool isInvalidated
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public List<ScriptableRendererFeature> rendererFeatures
	{
		 get { } //Length: 5
	}

	public bool useNativeRenderPass
	{
		 get { } //Length: 5
		 set { } //Length: 8
	}

	protected ScriptableRendererData() { }

	protected abstract ScriptableRenderer Create() { }

	[CompilerGenerated]
	internal bool get_isInvalidated() { }

	public List<ScriptableRendererFeature> get_rendererFeatures() { }

	public bool get_useNativeRenderPass() { }

	internal ScriptableRenderer InternalCreateRenderer() { }

	protected override void OnEnable() { }

	protected override void OnValidate() { }

	[CompilerGenerated]
	internal void set_isInvalidated(bool value) { }

	public void set_useNativeRenderPass(bool value) { }

	public void SetDirty() { }

	public bool TryGetRendererFeature(out T rendererFeature) { }

}

