namespace UnityEngine.Rendering.Universal;

internal struct PostProcessPasses : IDisposable
{
	private ColorGradingLutPass m_ColorGradingLutPass; //Field offset: 0x0
	private PostProcessPass m_PostProcessPass; //Field offset: 0x8
	private PostProcessPass m_FinalPostProcessPass; //Field offset: 0x10
	internal RTHandle m_AfterPostProcessColor; //Field offset: 0x18
	internal RTHandle m_ColorGradingLut; //Field offset: 0x20
	private PostProcessData m_RendererPostProcessData; //Field offset: 0x28
	private PostProcessData m_CurrentPostProcessData; //Field offset: 0x30
	private Material m_BlitMaterial; //Field offset: 0x38

	public RTHandle afterPostProcessColor
	{
		 get { } //Length: 5
	}

	public RTHandle colorGradingLut
	{
		 get { } //Length: 5
	}

	public ColorGradingLutPass colorGradingLutPass
	{
		 get { } //Length: 4
	}

	public PostProcessPass finalPostProcessPass
	{
		 get { } //Length: 5
	}

	public bool isCreated
	{
		 get { } //Length: 80
	}

	public PostProcessPass postProcessPass
	{
		 get { } //Length: 5
	}

	public PostProcessPasses(PostProcessData rendererPostProcessData, ref PostProcessParams postProcessParams) { }

	public override void Dispose() { }

	public RTHandle get_afterPostProcessColor() { }

	public RTHandle get_colorGradingLut() { }

	public ColorGradingLutPass get_colorGradingLutPass() { }

	public PostProcessPass get_finalPostProcessPass() { }

	public bool get_isCreated() { }

	public PostProcessPass get_postProcessPass() { }

	public void Recreate(PostProcessData data, ref PostProcessParams ppParams) { }

	internal void ReleaseRenderTargets() { }

}

