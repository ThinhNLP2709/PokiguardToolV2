namespace UnityEngine.Experimental.Rendering;

internal static class XRMirrorView
{
	private static readonly MaterialPropertyBlock s_MirrorViewMaterialProperty; //Field offset: 0x0
	private static readonly ProfilingSampler k_MirrorViewProfilingSampler; //Field offset: 0x8
	private static readonly int k_SourceTex; //Field offset: 0x10
	private static readonly int k_SourceTexArraySlice; //Field offset: 0x14
	private static readonly int k_ScaleBias; //Field offset: 0x18
	private static readonly int k_ScaleBiasRt; //Field offset: 0x1C
	private static readonly int k_SRGBRead; //Field offset: 0x20
	private static readonly int k_SRGBWrite; //Field offset: 0x24
	private static readonly int k_MaxNits; //Field offset: 0x28
	private static readonly int k_SourceMaxNits; //Field offset: 0x2C
	private static readonly int k_SourceHDREncoding; //Field offset: 0x30
	private static readonly int k_ColorTransform; //Field offset: 0x34

	private static XRMirrorView() { }

	internal static void RenderMirrorView(CommandBuffer cmd, Camera camera, Material mat, XRDisplaySubsystem display) { }

}

