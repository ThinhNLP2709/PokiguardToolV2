namespace UnityEngine.Rendering.Universal;

public struct LightData
{
	private ContextContainer frameData; //Field offset: 0x0

	public int additionalLightsCount
	{
		 get { } //Length: 77
	}

	public int mainLightIndex
	{
		 get { } //Length: 77
	}

	public int maxPerObjectAdditionalLightsCount
	{
		 get { } //Length: 77
	}

	public bool reflectionProbeBlending
	{
		 get { } //Length: 77
	}

	public bool reflectionProbeBoxProjection
	{
		 get { } //Length: 77
	}

	public bool shadeAdditionalLightsPerVertex
	{
		 get { } //Length: 77
	}

	public bool supportsAdditionalLights
	{
		 get { } //Length: 77
	}

	public bool supportsLightLayers
	{
		 get { } //Length: 77
	}

	public bool supportsMixedLighting
	{
		 get { } //Length: 77
	}

	internal UniversalLightData universalLightData
	{
		internal get { } //Length: 67
	}

	public NativeArray<VisibleLight>& visibleLights
	{
		 get { } //Length: 77
	}

	internal LightData(ContextContainer frameData) { }

	public int get_additionalLightsCount() { }

	public int get_mainLightIndex() { }

	public int get_maxPerObjectAdditionalLightsCount() { }

	public bool get_reflectionProbeBlending() { }

	public bool get_reflectionProbeBoxProjection() { }

	public bool get_shadeAdditionalLightsPerVertex() { }

	public bool get_supportsAdditionalLights() { }

	public bool get_supportsLightLayers() { }

	public bool get_supportsMixedLighting() { }

	internal UniversalLightData get_universalLightData() { }

	public NativeArray<VisibleLight>& get_visibleLights() { }

}

