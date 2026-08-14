namespace UnityEngine.Rendering.Universal;

[Flags]
[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal\\ShaderLibrary\\Debug\\DebugViewEnums.cs")]
public enum DebugLightingFeatureFlags
{
	None = 0,
	GlobalIllumination = 1,
	MainLight = 2,
	AdditionalLights = 4,
	VertexLighting = 8,
	Emission = 16,
	AmbientOcclusion = 32,
}

