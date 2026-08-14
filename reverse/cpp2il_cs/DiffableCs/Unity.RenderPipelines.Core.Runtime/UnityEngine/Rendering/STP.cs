namespace UnityEngine.Rendering;

public static class STP
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<SetupData, ComputeGraphContext> <>9__38_0; //Field offset: 0x8
		public static BaseRenderFunc<PreTaaData, ComputeGraphContext> <>9__38_1; //Field offset: 0x10
		public static BaseRenderFunc<TaaData, ComputeGraphContext> <>9__38_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <Execute>b__38_0(SetupData data, ComputeGraphContext ctx) { }

		internal void <Execute>b__38_1(PreTaaData data, ComputeGraphContext ctx) { }

		internal void <Execute>b__38_2(TaaData data, ComputeGraphContext ctx) { }

	}

	internal struct Config
	{
		public Texture2D noiseTexture; //Field offset: 0x0
		public TextureHandle inputColor; //Field offset: 0x8
		public TextureHandle inputDepth; //Field offset: 0x18
		public TextureHandle inputMotion; //Field offset: 0x28
		public TextureHandle inputStencil; //Field offset: 0x38
		public TextureHandle debugView; //Field offset: 0x48
		public TextureHandle destination; //Field offset: 0x58
		public HistoryContext historyContext; //Field offset: 0x68
		public bool enableHwDrs; //Field offset: 0x70
		public bool enableTexArray; //Field offset: 0x71
		public bool enableMotionScaling; //Field offset: 0x72
		public float nearPlane; //Field offset: 0x74
		public float farPlane; //Field offset: 0x78
		public int frameIndex; //Field offset: 0x7C
		public bool hasValidHistory; //Field offset: 0x80
		public int stencilMask; //Field offset: 0x84
		public int debugViewIndex; //Field offset: 0x88
		public float deltaTime; //Field offset: 0x8C
		public float lastDeltaTime; //Field offset: 0x90
		public Vector2Int currentImageSize; //Field offset: 0x94
		public Vector2Int priorImageSize; //Field offset: 0x9C
		public Vector2Int outputImageSize; //Field offset: 0xA4
		public int numActiveViews; //Field offset: 0xAC
		public PerViewConfig[] perViewConfigs; //Field offset: 0xB0

	}

	internal sealed class HistoryContext : IDisposable
	{
		private RTHandle[] m_textures; //Field offset: 0x10
		private Hash128 m_hash; //Field offset: 0x18

		public HistoryContext() { }

		public override void Dispose() { }

		internal RTHandle GetCurrentHistoryTexture(HistoryTextureType historyType, int frameIndex) { }

		internal RTHandle GetPreviousHistoryTexture(HistoryTextureType historyType, int frameIndex) { }

		public bool Update(ref HistoryUpdateInfo info) { }

	}

	public enum HistoryTextureType
	{
		DepthMotion = 0,
		Luma = 1,
		Convergence = 2,
		Feedback = 3,
		Count = 4,
	}

	internal struct HistoryUpdateInfo
	{
		public Vector2Int preUpscaleSize; //Field offset: 0x0
		public Vector2Int postUpscaleSize; //Field offset: 0x8
		public bool useHwDrs; //Field offset: 0x10
		public bool useTexArray; //Field offset: 0x11

	}

	internal struct PerViewConfig
	{
		public Matrix4x4 currentProj; //Field offset: 0x0
		public Matrix4x4 lastProj; //Field offset: 0x40
		public Matrix4x4 lastLastProj; //Field offset: 0x80
		public Matrix4x4 currentView; //Field offset: 0xC0
		public Matrix4x4 lastView; //Field offset: 0x100
		public Matrix4x4 lastLastView; //Field offset: 0x140

	}

	private class PreTaaData
	{
		public ComputeShader cs; //Field offset: 0x10
		public int kernelIndex; //Field offset: 0x18
		public int viewCount; //Field offset: 0x1C
		public Vector2Int dispatchSize; //Field offset: 0x20
		public TextureHandle noiseTexture; //Field offset: 0x28
		public TextureHandle debugView; //Field offset: 0x38
		public TextureHandle intermediateConvergence; //Field offset: 0x48
		public TextureHandle intermediateWeights; //Field offset: 0x58
		public TextureHandle luma; //Field offset: 0x68
		public TextureHandle convergence; //Field offset: 0x78

		public PreTaaData() { }

	}

	private enum ProfileId
	{
		StpSetup = 0,
		StpPreTaa = 1,
		StpTaa = 2,
	}

	[CategoryInfo(Name = "R: STP", Order = 1000)]
	[ElementInfo(Order = 0)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
	public class RuntimeResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
	{
		[ResourcePath("Runtime/STP/StpSetup.compute", SearchType::ProjectPath (0))]
		[SerializeField]
		private ComputeShader m_setupCS; //Field offset: 0x10
		[ResourcePath("Runtime/STP/StpPreTaa.compute", SearchType::ProjectPath (0))]
		[SerializeField]
		private ComputeShader m_preTaaCS; //Field offset: 0x18
		[ResourcePath("Runtime/STP/StpTaa.compute", SearchType::ProjectPath (0))]
		[SerializeField]
		private ComputeShader m_taaCS; //Field offset: 0x20

		public ComputeShader preTaaCS
		{
			 get { } //Length: 5
			 set { } //Length: 101
		}

		public ComputeShader setupCS
		{
			 get { } //Length: 5
			 set { } //Length: 101
		}

		public ComputeShader taaCS
		{
			 get { } //Length: 5
			 set { } //Length: 101
		}

		public override int version
		{
			 get { } //Length: 3
		}

		public RuntimeResources() { }

		public ComputeShader get_preTaaCS() { }

		public ComputeShader get_setupCS() { }

		public ComputeShader get_taaCS() { }

		public override int get_version() { }

		public void set_preTaaCS(ComputeShader value) { }

		public void set_setupCS(ComputeShader value) { }

		public void set_taaCS(ComputeShader value) { }

	}

	private class SetupData
	{
		public ComputeShader cs; //Field offset: 0x10
		public int kernelIndex; //Field offset: 0x18
		public int viewCount; //Field offset: 0x1C
		public Vector2Int dispatchSize; //Field offset: 0x20
		public StpConstantBufferData constantBufferData; //Field offset: 0x28
		public TextureHandle noiseTexture; //Field offset: 0x1E8
		public TextureHandle debugView; //Field offset: 0x1F8
		public TextureHandle inputColor; //Field offset: 0x208
		public TextureHandle inputDepth; //Field offset: 0x218
		public TextureHandle inputMotion; //Field offset: 0x228
		public TextureHandle inputStencil; //Field offset: 0x238
		public TextureHandle intermediateColor; //Field offset: 0x248
		public TextureHandle intermediateConvergence; //Field offset: 0x258
		public TextureHandle priorDepthMotion; //Field offset: 0x268
		public TextureHandle depthMotion; //Field offset: 0x278
		public TextureHandle priorLuma; //Field offset: 0x288
		public TextureHandle luma; //Field offset: 0x298
		public TextureHandle priorFeedback; //Field offset: 0x2A8
		public TextureHandle priorConvergence; //Field offset: 0x2B8

		public SetupData() { }

	}

	private static class ShaderKeywords
	{
		public static readonly string EnableDebugMode; //Field offset: 0x0
		public static readonly string EnableLargeKernel; //Field offset: 0x8
		public static readonly string EnableStencilResponsive; //Field offset: 0x10
		public static readonly string DisableTexture2DXArray; //Field offset: 0x18

		private static ShaderKeywords() { }

	}

	private static class ShaderResources
	{
		public static readonly int _StpConstantBufferData; //Field offset: 0x0
		public static readonly int _StpBlueNoiseIn; //Field offset: 0x4
		public static readonly int _StpDebugOut; //Field offset: 0x8
		public static readonly int _StpInputColor; //Field offset: 0xC
		public static readonly int _StpInputDepth; //Field offset: 0x10
		public static readonly int _StpInputMotion; //Field offset: 0x14
		public static readonly int _StpInputStencil; //Field offset: 0x18
		public static readonly int _StpIntermediateColor; //Field offset: 0x1C
		public static readonly int _StpIntermediateConvergence; //Field offset: 0x20
		public static readonly int _StpIntermediateWeights; //Field offset: 0x24
		public static readonly int _StpPriorLuma; //Field offset: 0x28
		public static readonly int _StpLuma; //Field offset: 0x2C
		public static readonly int _StpPriorDepthMotion; //Field offset: 0x30
		public static readonly int _StpDepthMotion; //Field offset: 0x34
		public static readonly int _StpPriorFeedback; //Field offset: 0x38
		public static readonly int _StpFeedback; //Field offset: 0x3C
		public static readonly int _StpPriorConvergence; //Field offset: 0x40
		public static readonly int _StpConvergence; //Field offset: 0x44
		public static readonly int _StpOutput; //Field offset: 0x48

		private static ShaderResources() { }

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\STP\\STP.cs", needAccessors = False, generateCBuffer = True)]
	private struct StpConstantBufferData
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <_StpSetupPerViewConstants>e__FixedBuffer
		{
			public float FixedElementField; //Field offset: 0x0

		}

		public Vector4 _StpCommonConstant; //Field offset: 0x0
		public Vector4 _StpSetupConstants0; //Field offset: 0x10
		public Vector4 _StpSetupConstants1; //Field offset: 0x20
		public Vector4 _StpSetupConstants2; //Field offset: 0x30
		public Vector4 _StpSetupConstants3; //Field offset: 0x40
		public Vector4 _StpSetupConstants4; //Field offset: 0x50
		public Vector4 _StpSetupConstants5; //Field offset: 0x60
		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public <_StpSetupPerViewConstants>e__FixedBuffer _StpSetupPerViewConstants; //Field offset: 0x70
		public Vector4 _StpDilConstants0; //Field offset: 0x170
		public Vector4 _StpTaaConstants0; //Field offset: 0x180
		public Vector4 _StpTaaConstants1; //Field offset: 0x190
		public Vector4 _StpTaaConstants2; //Field offset: 0x1A0
		public Vector4 _StpTaaConstants3; //Field offset: 0x1B0

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\STP\\STP.cs")]
	private enum StpSetupPerViewConstants
	{
		Count = 8,
	}

	private class TaaData
	{
		public ComputeShader cs; //Field offset: 0x10
		public int kernelIndex; //Field offset: 0x18
		public int viewCount; //Field offset: 0x1C
		public Vector2Int dispatchSize; //Field offset: 0x20
		public TextureHandle noiseTexture; //Field offset: 0x28
		public TextureHandle debugView; //Field offset: 0x38
		public TextureHandle intermediateColor; //Field offset: 0x48
		public TextureHandle intermediateWeights; //Field offset: 0x58
		public TextureHandle priorFeedback; //Field offset: 0x68
		public TextureHandle depthMotion; //Field offset: 0x78
		public TextureHandle convergence; //Field offset: 0x88
		public TextureHandle feedback; //Field offset: 0x98
		public TextureHandle output; //Field offset: 0xA8

		public TaaData() { }

	}

	private const int kNumDebugViews = 6; //Field offset: 0x0
	private static readonly GUIContent[] s_DebugViewDescriptions; //Field offset: 0x0
	private const int kMaxPerViewConfigs = 2; //Field offset: 0x0
	private const int kNumHistoryTextureTypes = 4; //Field offset: 0x0
	private const int kTotalSetupViewConstantsCount = 16; //Field offset: 0x0
	private static readonly Int32[] s_DebugViewIndices; //Field offset: 0x8
	private static PerViewConfig[] s_PerViewConfigs; //Field offset: 0x10
	private static readonly int kQualcommVendorId; //Field offset: 0x18

	public static GUIContent[] debugViewDescriptions
	{
		 get { } //Length: 78
	}

	public static Int32[] debugViewIndices
	{
		 get { } //Length: 79
	}

	public static PerViewConfig[] perViewConfigs
	{
		 get { } //Length: 79
		 set { } //Length: 110
	}

	private static STP() { }

	private static Vector2Int CalculateConvergenceTextureSize(Vector2Int historyTextureSize) { }

	private static float CalculateMotionScale(float deltaTime, float lastDeltaTime) { }

	private static Hash128 ComputeHistoryHash(ref HistoryUpdateInfo info) { }

	public static TextureHandle Execute(RenderGraph renderGraph, ref Config config) { }

	private static Matrix4x4 ExtractRotation(Matrix4x4 input) { }

	public static GUIContent[] get_debugViewDescriptions() { }

	public static Int32[] get_debugViewIndices() { }

	public static PerViewConfig[] get_perViewConfigs() { }

	public static bool IsSupported() { }

	public static Vector2 Jit16(int frameIndex) { }

	private static int PackVector2ToInt(Vector2 value) { }

	private static void PopulateConstantData(ref Config config, ref StpConstantBufferData constants) { }

	public static void set_perViewConfigs(PerViewConfig[] value) { }

	private static TextureHandle UseTexture(IBaseRenderGraphBuilder builder, TextureHandle texture, AccessFlags flags = 1) { }

}

