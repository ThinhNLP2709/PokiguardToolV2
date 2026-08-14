namespace UnityEngine.Rendering.Universal;

public class UniversalShadowData : ContextItem
{
	public bool supportsMainLightShadows; //Field offset: 0x10
	internal bool mainLightShadowsEnabled; //Field offset: 0x11
	public int mainLightShadowmapWidth; //Field offset: 0x14
	public int mainLightShadowmapHeight; //Field offset: 0x18
	public int mainLightShadowCascadesCount; //Field offset: 0x1C
	public Vector3 mainLightShadowCascadesSplit; //Field offset: 0x20
	public float mainLightShadowCascadeBorder; //Field offset: 0x2C
	public bool supportsAdditionalLightShadows; //Field offset: 0x30
	internal bool additionalLightShadowsEnabled; //Field offset: 0x31
	public int additionalLightsShadowmapWidth; //Field offset: 0x34
	public int additionalLightsShadowmapHeight; //Field offset: 0x38
	public bool supportsSoftShadows; //Field offset: 0x3C
	public int shadowmapDepthBufferBits; //Field offset: 0x40
	public List<Vector4> bias; //Field offset: 0x48
	public List<Int32> resolution; //Field offset: 0x50
	internal bool isKeywordAdditionalLightShadowsEnabled; //Field offset: 0x58
	internal bool isKeywordSoftShadowsEnabled; //Field offset: 0x59
	internal int mainLightShadowResolution; //Field offset: 0x5C
	internal int mainLightRenderTargetWidth; //Field offset: 0x60
	internal int mainLightRenderTargetHeight; //Field offset: 0x64
	internal NativeArray<URPLightShadowCullingInfos> visibleLightsShadowCullingInfos; //Field offset: 0x68
	internal AdditionalLightsShadowAtlasLayout shadowAtlasLayout; //Field offset: 0x78

	public UniversalShadowData() { }

	public virtual void Reset() { }

}

