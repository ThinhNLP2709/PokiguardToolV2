namespace UnityEngine.Rendering.Universal;

internal class ScreenSpaceAmbientOcclusionPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<SSAOPassData, UnsafeGraphContext> <>9__52_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__52_0(SSAOPassData data, UnsafeGraphContext rgContext) { }

	}

	private enum BlurTypes
	{
		Bilateral = 0,
		Gaussian = 1,
		Kawase = 2,
	}

	private enum ShaderPasses
	{
		AmbientOcclusion = 0,
		BilateralBlurHorizontal = 1,
		BilateralBlurVertical = 2,
		BilateralBlurFinal = 3,
		BilateralAfterOpaque = 4,
		GaussianBlurHorizontal = 5,
		GaussianBlurVertical = 6,
		GaussianAfterOpaque = 7,
		KawaseBlur = 8,
		KawaseAfterOpaque = 9,
	}

	private struct SSAOMaterialParams
	{
		internal bool orthographicCamera; //Field offset: 0x0
		internal bool aoBlueNoise; //Field offset: 0x1
		internal bool aoInterleavedGradient; //Field offset: 0x2
		internal bool sampleCountHigh; //Field offset: 0x3
		internal bool sampleCountMedium; //Field offset: 0x4
		internal bool sampleCountLow; //Field offset: 0x5
		internal bool sourceDepthNormals; //Field offset: 0x6
		internal bool sourceDepthHigh; //Field offset: 0x7
		internal bool sourceDepthMedium; //Field offset: 0x8
		internal bool sourceDepthLow; //Field offset: 0x9
		internal Vector4 ssaoParams; //Field offset: 0xC

		internal SSAOMaterialParams(ref ScreenSpaceAmbientOcclusionSettings settings, bool isOrthographic) { }

		internal bool Equals(ref SSAOMaterialParams other) { }

	}

	private class SSAOPassData
	{
		internal bool afterOpaque; //Field offset: 0x10
		internal BlurQualityOptions BlurQuality; //Field offset: 0x14
		internal Material material; //Field offset: 0x18
		internal float directLightingStrength; //Field offset: 0x20
		internal TextureHandle cameraColor; //Field offset: 0x24
		internal TextureHandle AOTexture; //Field offset: 0x34
		internal TextureHandle finalTexture; //Field offset: 0x44
		internal TextureHandle blurTexture; //Field offset: 0x54
		internal TextureHandle cameraNormalsTexture; //Field offset: 0x64

		public SSAOPassData() { }

	}

	internal static readonly int s_AmbientOcclusionParamID; //Field offset: 0x0
	private const string k_AmbientOcclusionParamName = "_AmbientOcclusionParam"; //Field offset: 0x0
	private const string k_SSAOTextureName = "_ScreenSpaceOcclusionTexture"; //Field offset: 0x0
	private static readonly int s_SSAOParamsID; //Field offset: 0x4
	private static readonly int s_SSAOBlueNoiseParamsID; //Field offset: 0x8
	private static readonly int s_BlueNoiseTextureID; //Field offset: 0xC
	private static readonly int s_SSAOFinalTextureID; //Field offset: 0x10
	private static readonly int s_CameraViewXExtentID; //Field offset: 0x14
	private static readonly int s_CameraViewYExtentID; //Field offset: 0x18
	private static readonly int s_CameraViewZExtentID; //Field offset: 0x1C
	private static readonly int s_ProjectionParams2ID; //Field offset: 0x20
	private static readonly int s_CameraViewProjectionsID; //Field offset: 0x24
	private static readonly int s_CameraViewTopLeftCornerID; //Field offset: 0x28
	private static readonly int s_CameraDepthTextureID; //Field offset: 0x2C
	private static readonly int s_CameraNormalsTextureID; //Field offset: 0x30
	private static readonly Int32[] m_BilateralTexturesIndices; //Field offset: 0x38
	private static readonly ShaderPasses[] m_BilateralPasses; //Field offset: 0x40
	private static readonly ShaderPasses[] m_BilateralAfterOpaquePasses; //Field offset: 0x48
	private static readonly Int32[] m_GaussianTexturesIndices; //Field offset: 0x50
	private static readonly ShaderPasses[] m_GaussianPasses; //Field offset: 0x58
	private static readonly ShaderPasses[] m_GaussianAfterOpaquePasses; //Field offset: 0x60
	private static readonly Int32[] m_KawaseTexturesIndices; //Field offset: 0x68
	private static readonly ShaderPasses[] m_KawasePasses; //Field offset: 0x70
	private static readonly ShaderPasses[] m_KawaseAfterOpaquePasses; //Field offset: 0x78
	private readonly bool m_SupportsR8RenderTextureFormat; //Field offset: 0xB8
	private int m_BlueNoiseTextureIndex; //Field offset: 0xBC
	private Material m_Material; //Field offset: 0xC0
	private SSAOPassData m_PassData; //Field offset: 0xC8
	private Texture2D[] m_BlueNoiseTextures; //Field offset: 0xD0
	private Vector4[] m_CameraTopLeftCorner; //Field offset: 0xD8
	private Vector4[] m_CameraXExtent; //Field offset: 0xE0
	private Vector4[] m_CameraYExtent; //Field offset: 0xE8
	private Vector4[] m_CameraZExtent; //Field offset: 0xF0
	private RTHandle[] m_SSAOTextures; //Field offset: 0xF8
	private BlurTypes m_BlurType; //Field offset: 0x100
	private Matrix4x4[] m_CameraViewProjections; //Field offset: 0x108
	private ProfilingSampler m_ProfilingSampler; //Field offset: 0x110
	private ScriptableRenderer m_Renderer; //Field offset: 0x118
	private RenderTextureDescriptor m_AOPassDescriptor; //Field offset: 0x120
	private ScreenSpaceAmbientOcclusionSettings m_CurrentSettings; //Field offset: 0x158
	private SSAOMaterialParams m_SSAOParamsPrev; //Field offset: 0x160

	private bool isRendererDeferred
	{
		private get { } //Length: 142
	}

	private static ScreenSpaceAmbientOcclusionPass() { }

	internal ScreenSpaceAmbientOcclusionPass() { }

	private void CreateRenderTextureHandles(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, out TextureHandle aoTexture, out TextureHandle blurTexture, out TextureHandle finalTexture) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private bool get_isRendererDeferred() { }

	private static void GetPassOrder(BlurTypes blurType, bool isAfterOpaque, out Int32[] textureIndices, out ShaderPasses[] shaderPasses) { }

	private void InitSSAOPassData(ref SSAOPassData data) { }

	private static bool IsAfterOpaquePass(ref ShaderPasses pass) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	private static void RenderAndSetBaseMap(ref CommandBuffer cmd, ref RenderingData renderingData, ref ScriptableRenderer renderer, ref Material mat, ref RTHandle baseMap, ref RTHandle target, ShaderPasses pass) { }

	internal bool Setup(ref ScreenSpaceAmbientOcclusionSettings featureSettings, ref ScriptableRenderer renderer, ref Material material, ref Texture2D[] blueNoiseTextures) { }

	private void SetupKeywordsAndParameters(ref ScreenSpaceAmbientOcclusionSettings settings, ref UniversalCameraData cameraData) { }

}

