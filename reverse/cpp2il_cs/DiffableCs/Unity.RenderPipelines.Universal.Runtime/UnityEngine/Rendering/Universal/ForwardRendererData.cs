namespace UnityEngine.Rendering.Universal;

[ExcludeFromPreset]
[Obsolete("ForwardRendererData has been deprecated (UnityUpgradable) -> UniversalRendererData", True)]
[ReloadGroup]
public class ForwardRendererData : ScriptableRendererData
{
	[ReloadGroup]
	internal sealed class ShaderResources
	{
		[Reload("Shaders/Utils/Blit.shader", Package::Root (1))]
		public Shader blitPS; //Field offset: 0x10
		[Reload("Shaders/Utils/CopyDepth.shader", Package::Root (1))]
		public Shader copyDepthPS; //Field offset: 0x18
		[Obsolete("Obsolete, this feature will be supported by new 'ScreenSpaceShadows' renderer feature", True)]
		public Shader screenSpaceShadowPS; //Field offset: 0x20
		[Reload("Shaders/Utils/Sampling.shader", Package::Root (1))]
		public Shader samplingPS; //Field offset: 0x28
		[Reload("Shaders/Utils/StencilDeferred.shader", Package::Root (1))]
		public Shader stencilDeferredPS; //Field offset: 0x30
		[Reload("Shaders/Utils/FallbackError.shader", Package::Root (1))]
		public Shader fallbackErrorPS; //Field offset: 0x38
		[Reload("Shaders/Utils/FallbackLoading.shader", Package::Root (1))]
		public Shader fallbackLoadingPS; //Field offset: 0x40
		[Obsolete("Use fallbackErrorPS instead", True)]
		[Reload("Shaders/Utils/MaterialError.shader", Package::Root (1))]
		public Shader materialErrorPS; //Field offset: 0x48
		[Reload("Shaders/Utils/CoreBlit.shader", Package::Root (1))]
		[SerializeField]
		internal Shader coreBlitPS; //Field offset: 0x50
		[Reload("Shaders/Utils/CoreBlitColorAndDepth.shader", Package::Root (1))]
		[SerializeField]
		internal Shader coreBlitColorAndDepthPS; //Field offset: 0x58
		[Reload("Shaders/CameraMotionVectors.shader", Package::Root (1))]
		public Shader cameraMotionVector; //Field offset: 0x60
		[Reload("Shaders/ObjectMotionVectors.shader", Package::Root (1))]
		public Shader objectMotionVector; //Field offset: 0x68

		public ShaderResources() { }

	}

	private const string k_ErrorMessage = "ForwardRendererData has been deprecated. Use UniversalRendererData instead"; //Field offset: 0x0
	public ShaderResources shaders; //Field offset: 0x48
	public PostProcessData postProcessData; //Field offset: 0x50
	public XRSystemData xrSystemData; //Field offset: 0x58
	[SerializeField]
	private LayerMask m_OpaqueLayerMask; //Field offset: 0x60
	[SerializeField]
	private LayerMask m_TransparentLayerMask; //Field offset: 0x64
	[SerializeField]
	private StencilStateData m_DefaultStencilState; //Field offset: 0x68
	[SerializeField]
	private bool m_ShadowTransparentReceive; //Field offset: 0x70
	[SerializeField]
	private RenderingMode m_RenderingMode; //Field offset: 0x74
	[SerializeField]
	private DepthPrimingMode m_DepthPrimingMode; //Field offset: 0x78
	[SerializeField]
	private bool m_AccurateGbufferNormals; //Field offset: 0x7C
	[SerializeField]
	private bool m_ClusteredRendering; //Field offset: 0x7D
	[SerializeField]
	private TileSize m_TileSize; //Field offset: 0x80

	public bool accurateGbufferNormals
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public StencilStateData defaultStencilState
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public LayerMask opaqueLayerMask
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public RenderingMode renderingMode
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public bool shadowTransparentReceive
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public LayerMask transparentLayerMask
	{
		 get { } //Length: 78
		 set { } //Length: 78
	}

	public ForwardRendererData() { }

	protected virtual ScriptableRenderer Create() { }

	public bool get_accurateGbufferNormals() { }

	public StencilStateData get_defaultStencilState() { }

	public LayerMask get_opaqueLayerMask() { }

	public RenderingMode get_renderingMode() { }

	public bool get_shadowTransparentReceive() { }

	public LayerMask get_transparentLayerMask() { }

	public void set_accurateGbufferNormals(bool value) { }

	public void set_defaultStencilState(StencilStateData value) { }

	public void set_opaqueLayerMask(LayerMask value) { }

	public void set_renderingMode(RenderingMode value) { }

	public void set_shadowTransparentReceive(bool value) { }

	public void set_transparentLayerMask(LayerMask value) { }

}

