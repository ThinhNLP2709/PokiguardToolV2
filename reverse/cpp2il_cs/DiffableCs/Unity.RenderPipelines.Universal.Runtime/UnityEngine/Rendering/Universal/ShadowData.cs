namespace UnityEngine.Rendering.Universal;

public struct ShadowData
{
	private ContextContainer frameData; //Field offset: 0x0

	internal bool additionalLightShadowsEnabled
	{
		internal get { } //Length: 77
	}

	public int additionalLightsShadowmapHeight
	{
		 get { } //Length: 77
	}

	public int additionalLightsShadowmapWidth
	{
		 get { } //Length: 77
	}

	public List<Vector4>& bias
	{
		 get { } //Length: 77
	}

	internal bool isKeywordAdditionalLightShadowsEnabled
	{
		internal get { } //Length: 77
	}

	internal bool isKeywordSoftShadowsEnabled
	{
		internal get { } //Length: 77
	}

	internal int mainLightRenderTargetHeight
	{
		internal get { } //Length: 77
	}

	internal int mainLightRenderTargetWidth
	{
		internal get { } //Length: 77
	}

	public float mainLightShadowCascadeBorder
	{
		 get { } //Length: 77
	}

	public int mainLightShadowCascadesCount
	{
		 get { } //Length: 77
	}

	public Vector3 mainLightShadowCascadesSplit
	{
		 get { } //Length: 77
	}

	public int mainLightShadowmapHeight
	{
		 get { } //Length: 77
	}

	public int mainLightShadowmapWidth
	{
		 get { } //Length: 77
	}

	internal int mainLightShadowResolution
	{
		internal get { } //Length: 77
	}

	internal bool mainLightShadowsEnabled
	{
		internal get { } //Length: 77
	}

	public List<Int32>& resolution
	{
		 get { } //Length: 77
	}

	internal AdditionalLightsShadowAtlasLayout shadowAtlasLayout
	{
		internal get { } //Length: 77
	}

	public int shadowmapDepthBufferBits
	{
		 get { } //Length: 77
	}

	public bool supportsAdditionalLightShadows
	{
		 get { } //Length: 77
	}

	public bool supportsMainLightShadows
	{
		 get { } //Length: 77
	}

	public bool supportsSoftShadows
	{
		 get { } //Length: 77
	}

	internal UniversalShadowData universalShadowData
	{
		internal get { } //Length: 67
	}

	internal NativeArray<URPLightShadowCullingInfos>& visibleLightsShadowCullingInfos
	{
		internal get { } //Length: 77
	}

	internal ShadowData(ContextContainer frameData) { }

	internal bool get_additionalLightShadowsEnabled() { }

	public int get_additionalLightsShadowmapHeight() { }

	public int get_additionalLightsShadowmapWidth() { }

	public List<Vector4>& get_bias() { }

	internal bool get_isKeywordAdditionalLightShadowsEnabled() { }

	internal bool get_isKeywordSoftShadowsEnabled() { }

	internal int get_mainLightRenderTargetHeight() { }

	internal int get_mainLightRenderTargetWidth() { }

	public float get_mainLightShadowCascadeBorder() { }

	public int get_mainLightShadowCascadesCount() { }

	public Vector3 get_mainLightShadowCascadesSplit() { }

	public int get_mainLightShadowmapHeight() { }

	public int get_mainLightShadowmapWidth() { }

	internal int get_mainLightShadowResolution() { }

	internal bool get_mainLightShadowsEnabled() { }

	public List<Int32>& get_resolution() { }

	internal AdditionalLightsShadowAtlasLayout get_shadowAtlasLayout() { }

	public int get_shadowmapDepthBufferBits() { }

	public bool get_supportsAdditionalLightShadows() { }

	public bool get_supportsMainLightShadows() { }

	public bool get_supportsSoftShadows() { }

	internal UniversalShadowData get_universalShadowData() { }

	internal NativeArray<URPLightShadowCullingInfos>& get_visibleLightsShadowCullingInfos() { }

}

