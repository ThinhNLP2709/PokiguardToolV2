namespace UnityEngine.Rendering.Universal;

public static class ShaderInput
{
	[GenerateHLSL(PackingRules::Exact (0), False, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal\\ShaderLibrary\\ShaderTypes.cs")]
	internal struct LightData
	{
		public Vector4 position; //Field offset: 0x0
		public Vector4 color; //Field offset: 0x10
		public Vector4 attenuation; //Field offset: 0x20
		public Vector4 spotDirection; //Field offset: 0x30
		public Vector4 occlusionProbeChannels; //Field offset: 0x40
		public uint layerMask; //Field offset: 0x50

	}

	[Obsolete("ShaderInput.ShadowData was deprecated. Shadow slice matrices and per-light shadow parameters are now passed to the GPU using entries in buffers m_AdditionalLightsWorldToShadow_SSBO and m_AdditionalShadowParams_SSBO", True)]
	internal struct ShadowData
	{
		public Matrix4x4 worldToShadowMatrix; //Field offset: 0x0
		public Vector4 shadowParams; //Field offset: 0x40

	}


}

