namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "R: 2D Renderer", Order = 1000)]
[HideInInspector]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
internal class Renderer2DResources : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[ResourcePath("Shaders/2D/Light2D.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_LightShader; //Field offset: 0x18
	[ResourcePath("Shaders/2D/Shadow2D-Projected.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_ProjectedShadowShader; //Field offset: 0x20
	[ResourcePath("Shaders/2D/Shadow2D-Shadow-Sprite.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_SpriteShadowShader; //Field offset: 0x28
	[ResourcePath("Shaders/2D/Shadow2D-Unshadow-Sprite.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_SpriteUnshadowShader; //Field offset: 0x30
	[ResourcePath("Shaders/2D/Shadow2D-Shadow-Geometry.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_GeometryShadowShader; //Field offset: 0x38
	[ResourcePath("Shaders/2D/Shadow2D-Unshadow-Geometry.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_GeometryUnshadowShader; //Field offset: 0x40
	[HideInInspector]
	[ResourcePath("Runtime/2D/Data/Textures/FalloffLookupTexture.png", SearchType::ProjectPath (0))]
	[SerializeField]
	private Texture2D m_FallOffLookup; //Field offset: 0x48
	[ResourcePath("Shaders/Utils/CopyDepth.shader", SearchType::ProjectPath (0))]
	[SerializeField]
	private Shader m_CopyDepthPS; //Field offset: 0x50

	internal Shader copyDepthPS
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Texture2D fallOffLookup
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader geometryShadowShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader geometryUnshadowShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader lightShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader projectedShadowShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader spriteShadowShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	internal Shader spriteUnshadowShader
	{
		internal get { } //Length: 5
		internal set { } //Length: 101
	}

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild
	{
		private get { } //Length: 3
	}

	public override int version
	{
		 get { } //Length: 4
	}

	public Renderer2DResources() { }

	internal Shader get_copyDepthPS() { }

	internal Texture2D get_fallOffLookup() { }

	internal Shader get_geometryShadowShader() { }

	internal Shader get_geometryUnshadowShader() { }

	internal Shader get_lightShader() { }

	internal Shader get_projectedShadowShader() { }

	internal Shader get_spriteShadowShader() { }

	internal Shader get_spriteUnshadowShader() { }

	public override int get_version() { }

	internal void set_copyDepthPS(Shader value) { }

	internal void set_fallOffLookup(Texture2D value) { }

	internal void set_geometryShadowShader(Shader value) { }

	internal void set_geometryUnshadowShader(Shader value) { }

	internal void set_lightShader(Shader value) { }

	internal void set_projectedShadowShader(Shader value) { }

	internal void set_spriteShadowShader(Shader value) { }

	internal void set_spriteUnshadowShader(Shader value) { }

	private override bool UnityEngine.Rendering.IRenderPipelineGraphicsSettings.get_isAvailableInPlayerBuild() { }

}

