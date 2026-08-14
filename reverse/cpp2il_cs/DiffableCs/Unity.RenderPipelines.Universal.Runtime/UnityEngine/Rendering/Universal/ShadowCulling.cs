namespace UnityEngine.Rendering.Universal;

internal static class ShadowCulling
{
	private static readonly ProfilingSampler computeShadowCasterCullingInfosMarker; //Field offset: 0x0

	private static ShadowCulling() { }

	private static void ComputeShadowCasterCullingInfos(UniversalShadowData shadowData, ref AdditionalLightsShadowAtlasLayout shadowAtlasLayout, ref CullingResults cullingResults, out ShadowCastersCullingInfos shadowCullingInfos, out NativeArray<URPLightShadowCullingInfos>& urpVisibleLightsShadowCullingInfos) { }

	public static NativeArray<URPLightShadowCullingInfos> CullShadowCasters(ref ScriptableRenderContext context, UniversalShadowData shadowData, ref AdditionalLightsShadowAtlasLayout shadowAtlasLayout, ref CullingResults cullResults) { }

	private static BatchCullingProjectionType GetCullingProjectionType(LightType type) { }

}

