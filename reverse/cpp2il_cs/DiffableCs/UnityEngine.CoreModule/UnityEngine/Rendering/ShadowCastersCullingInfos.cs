namespace UnityEngine.Rendering;

public struct ShadowCastersCullingInfos
{
	public NativeArray<ShadowSplitData> splitBuffer; //Field offset: 0x0
	public NativeArray<LightShadowCasterCullingInfo> perLightInfos; //Field offset: 0x10

}

