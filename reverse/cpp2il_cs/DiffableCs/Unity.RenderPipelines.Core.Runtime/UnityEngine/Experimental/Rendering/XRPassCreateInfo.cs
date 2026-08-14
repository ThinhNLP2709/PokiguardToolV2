namespace UnityEngine.Experimental.Rendering;

public struct XRPassCreateInfo
{
	internal RenderTargetIdentifier renderTarget; //Field offset: 0x0
	internal RenderTextureDescriptor renderTargetDesc; //Field offset: 0x28
	internal RenderTargetIdentifier motionVectorRenderTarget; //Field offset: 0x60
	internal RenderTextureDescriptor motionVectorRenderTargetDesc; //Field offset: 0x88
	internal ScriptableCullingParameters cullingParameters; //Field offset: 0xC0
	internal Material occlusionMeshMaterial; //Field offset: 0x6F8
	internal float occlusionMeshScale; //Field offset: 0x700
	internal IntPtr foveatedRenderingInfo; //Field offset: 0x708
	internal int multipassId; //Field offset: 0x710
	internal int cullingPassId; //Field offset: 0x714
	internal bool copyDepth; //Field offset: 0x718
	internal bool hasMotionVectorPass; //Field offset: 0x719
	internal XRRenderPass xrSdkRenderPass; //Field offset: 0x720

}

