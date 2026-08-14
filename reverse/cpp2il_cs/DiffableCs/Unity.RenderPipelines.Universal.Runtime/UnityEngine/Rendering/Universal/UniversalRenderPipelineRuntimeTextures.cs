namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: Runtime Textures", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class UniversalRenderPipelineRuntimeTextures : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[ResourcePath("Textures/BlueNoise64/L/LDR_LLL1_0.png", SearchType::ProjectPath (0))]
	[SerializeField]
	private Texture2D m_BlueNoise64LTex; //Field offset: 0x18
	[ResourcePath("Textures/BayerMatrix.png", SearchType::ProjectPath (0))]
	[SerializeField]
	private Texture2D m_BayerMatrixTex; //Field offset: 0x20
	[ResourcePath("Textures/DebugFont.tga", SearchType::ProjectPath (0))]
	[SerializeField]
	private Texture2D m_DebugFontTex; //Field offset: 0x28

	public Texture2D bayerMatrixTex
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Texture2D blueNoise64LTex
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public Texture2D debugFontTexture
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	public override int version
	{
		 get { } //Length: 4
	}

	public UniversalRenderPipelineRuntimeTextures() { }

	public Texture2D get_bayerMatrixTex() { }

	public Texture2D get_blueNoise64LTex() { }

	public Texture2D get_debugFontTexture() { }

	public override int get_version() { }

	public void set_bayerMatrixTex(Texture2D value) { }

	public void set_blueNoise64LTex(Texture2D value) { }

	public void set_debugFontTexture(Texture2D value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

