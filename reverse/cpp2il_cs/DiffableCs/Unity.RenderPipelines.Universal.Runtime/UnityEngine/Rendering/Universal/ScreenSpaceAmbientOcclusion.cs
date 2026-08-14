namespace UnityEngine.Rendering.Universal;

[DisallowMultipleRendererFeature("Screen Space Ambient Occlusion")]
[SupportedOnRenderer(typeof(UniversalRendererData))]
[Tooltip("The Ambient Occlusion effect darkens creases, holes, intersections and surfaces that are close to each other.")]
public class ScreenSpaceAmbientOcclusion : ScriptableRendererFeature
{
	internal const string k_AOInterleavedGradientKeyword = "_INTERLEAVED_GRADIENT"; //Field offset: 0x0
	internal const string k_AOBlueNoiseKeyword = "_BLUE_NOISE"; //Field offset: 0x0
	internal const string k_OrthographicCameraKeyword = "_ORTHOGRAPHIC"; //Field offset: 0x0
	internal const string k_SourceDepthLowKeyword = "_SOURCE_DEPTH_LOW"; //Field offset: 0x0
	internal const string k_SourceDepthMediumKeyword = "_SOURCE_DEPTH_MEDIUM"; //Field offset: 0x0
	internal const string k_SourceDepthHighKeyword = "_SOURCE_DEPTH_HIGH"; //Field offset: 0x0
	internal const string k_SourceDepthNormalsKeyword = "_SOURCE_DEPTH_NORMALS"; //Field offset: 0x0
	internal const string k_SampleCountLowKeyword = "_SAMPLE_COUNT_LOW"; //Field offset: 0x0
	internal const string k_SampleCountMediumKeyword = "_SAMPLE_COUNT_MEDIUM"; //Field offset: 0x0
	internal const string k_SampleCountHighKeyword = "_SAMPLE_COUNT_HIGH"; //Field offset: 0x0
	[SerializeField]
	private ScreenSpaceAmbientOcclusionSettings m_Settings; //Field offset: 0x20
	[HideInInspector]
	[Reload("Textures/BlueNoise256/LDR_LLL1_{0}.png", 0, 7, Package::Root (1))]
	[SerializeField]
	internal Texture2D[] m_BlueNoise256Textures; //Field offset: 0x28
	[HideInInspector]
	[Reload("Shaders/Utils/ScreenSpaceAmbientOcclusion.shader", Package::Root (1))]
	[SerializeField]
	private Shader m_Shader; //Field offset: 0x30
	private Material m_Material; //Field offset: 0x38
	private ScreenSpaceAmbientOcclusionPass m_SSAOPass; //Field offset: 0x40

	internal ScreenSpaceAmbientOcclusionSettings settings
	{
		internal get { } //Length: 5
	}

	public ScreenSpaceAmbientOcclusion() { }

	public virtual void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) { }

	public virtual void Create() { }

	protected virtual void Dispose(bool disposing) { }

	internal ScreenSpaceAmbientOcclusionSettings get_settings() { }

	private bool GetMaterials() { }

}

