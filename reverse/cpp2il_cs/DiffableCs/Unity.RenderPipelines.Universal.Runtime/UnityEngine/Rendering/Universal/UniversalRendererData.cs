namespace UnityEngine.Rendering.Universal;

[ExcludeFromPreset]
[ReloadGroup]
public class UniversalRendererData : ScriptableRendererData, ISerializationCallbackReceiver
{
	private const int k_LatestAssetVersion = 2; //Field offset: 0x0
	[Obsolete("Moved to UniversalRenderPipelineRuntimeXRResources on GraphicsSettings. #from(2023.3)", False)]
	public XRSystemData xrSystemData; //Field offset: 0x48
	public PostProcessData postProcessData; //Field offset: 0x50
	[SerializeField]
	private int m_AssetVersion; //Field offset: 0x58
	[SerializeField]
	private LayerMask m_OpaqueLayerMask; //Field offset: 0x5C
	[SerializeField]
	private LayerMask m_TransparentLayerMask; //Field offset: 0x60
	[SerializeField]
	private StencilStateData m_DefaultStencilState; //Field offset: 0x68
	[SerializeField]
	private bool m_ShadowTransparentReceive; //Field offset: 0x70
	[SerializeField]
	private RenderingMode m_RenderingMode; //Field offset: 0x74
	[SerializeField]
	private DepthPrimingMode m_DepthPrimingMode; //Field offset: 0x78
	[SerializeField]
	private CopyDepthMode m_CopyDepthMode; //Field offset: 0x7C
	[SerializeField]
	private DepthFormat m_DepthAttachmentFormat; //Field offset: 0x80
	[SerializeField]
	private DepthFormat m_DepthTextureFormat; //Field offset: 0x84
	[SerializeField]
	private bool m_AccurateGbufferNormals; //Field offset: 0x88
	[SerializeField]
	private IntermediateTextureMode m_IntermediateTextureMode; //Field offset: 0x8C

	public bool accurateGbufferNormals
	{
		 get { } //Length: 8
		 set { } //Length: 11
	}

	public CopyDepthMode copyDepthMode
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public StencilStateData defaultStencilState
	{
		 get { } //Length: 5
		 set { } //Length: 17
	}

	public DepthFormat depthAttachmentFormat
	{
		 get { } //Length: 136
		 set { } //Length: 184
	}

	public DepthPrimingMode depthPrimingMode
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public DepthFormat depthTextureFormat
	{
		 get { } //Length: 231
		 set { } //Length: 11
	}

	public IntermediateTextureMode intermediateTextureMode
	{
		 get { } //Length: 7
		 set { } //Length: 11
	}

	public LayerMask opaqueLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public RenderingMode renderingMode
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public bool shadowTransparentReceive
	{
		 get { } //Length: 5
		 set { } //Length: 8
	}

	public LayerMask transparentLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public UniversalRendererData() { }

	protected virtual ScriptableRenderer Create() { }

	public bool get_accurateGbufferNormals() { }

	public CopyDepthMode get_copyDepthMode() { }

	public StencilStateData get_defaultStencilState() { }

	public DepthFormat get_depthAttachmentFormat() { }

	public DepthPrimingMode get_depthPrimingMode() { }

	public DepthFormat get_depthTextureFormat() { }

	public IntermediateTextureMode get_intermediateTextureMode() { }

	public LayerMask get_opaqueLayerMask() { }

	public RenderingMode get_renderingMode() { }

	public bool get_shadowTransparentReceive() { }

	public LayerMask get_transparentLayerMask() { }

	protected virtual void OnEnable() { }

	private void ReloadAllNullProperties() { }

	public void set_accurateGbufferNormals(bool value) { }

	public void set_copyDepthMode(CopyDepthMode value) { }

	public void set_defaultStencilState(StencilStateData value) { }

	public void set_depthAttachmentFormat(DepthFormat value) { }

	public void set_depthPrimingMode(DepthPrimingMode value) { }

	public void set_depthTextureFormat(DepthFormat value) { }

	public void set_intermediateTextureMode(IntermediateTextureMode value) { }

	public void set_opaqueLayerMask(LayerMask value) { }

	public void set_renderingMode(RenderingMode value) { }

	public void set_shadowTransparentReceive(bool value) { }

	public void set_transparentLayerMask(LayerMask value) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

