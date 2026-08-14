namespace UnityEngine.Rendering.Universal;

public class UniversalLightData : ContextItem
{
	public int mainLightIndex; //Field offset: 0x10
	public int additionalLightsCount; //Field offset: 0x14
	public int maxPerObjectAdditionalLightsCount; //Field offset: 0x18
	public NativeArray<VisibleLight> visibleLights; //Field offset: 0x20
	public bool shadeAdditionalLightsPerVertex; //Field offset: 0x30
	public bool supportsMixedLighting; //Field offset: 0x31
	public bool reflectionProbeBoxProjection; //Field offset: 0x32
	public bool reflectionProbeBlending; //Field offset: 0x33
	public bool supportsLightLayers; //Field offset: 0x34
	public bool supportsAdditionalLights; //Field offset: 0x35

	public UniversalLightData() { }

	public virtual void Reset() { }

}

