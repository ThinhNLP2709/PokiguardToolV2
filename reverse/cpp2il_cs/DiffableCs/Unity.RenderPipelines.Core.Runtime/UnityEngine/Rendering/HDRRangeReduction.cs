namespace UnityEngine.Rendering;

[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\PostProcessing\\HDROutputDefines.cs")]
public enum HDRRangeReduction
{
	None = 0,
	Reinhard = 1,
	BT2390 = 2,
	ACES1000Nits = 3,
	ACES2000Nits = 4,
	ACES4000Nits = 5,
}

