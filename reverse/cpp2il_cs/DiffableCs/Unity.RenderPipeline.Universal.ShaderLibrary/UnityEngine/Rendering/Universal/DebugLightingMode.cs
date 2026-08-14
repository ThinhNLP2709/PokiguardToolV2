namespace UnityEngine.Rendering.Universal;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugLightingMode
{
	None = 0,
	ShadowCascades = 1,
	LightingWithoutNormalMaps = 2,
	LightingWithNormalMaps = 3,
	Reflections = 4,
	ReflectionsWithSmoothness = 5,
	GlobalIllumination = 6,
}

