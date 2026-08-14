namespace UnityEngine.Rendering.Universal;

[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
[ReloadGroup]
public sealed class ShaderResources
{
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/Blit.shader", Package::Root (1))]
	public Shader blitPS; //Field offset: 0x10
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/CopyDepth.shader", Package::Root (1))]
	public Shader copyDepthPS; //Field offset: 0x18
	[Obsolete("Obsolete, this feature will be supported by new 'ScreenSpaceShadows' renderer feature", True)]
	public Shader screenSpaceShadowPS; //Field offset: 0x20
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/Sampling.shader", Package::Root (1))]
	public Shader samplingPS; //Field offset: 0x28
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/StencilDeferred.shader", Package::Root (1))]
	public Shader stencilDeferredPS; //Field offset: 0x30
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/FallbackError.shader", Package::Root (1))]
	public Shader fallbackErrorPS; //Field offset: 0x38
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/FallbackLoading.shader", Package::Root (1))]
	public Shader fallbackLoadingPS; //Field offset: 0x40
	[Obsolete("Use fallbackErrorPS instead", True)]
	public Shader materialErrorPS; //Field offset: 0x48
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/CoreBlit.shader", Package::Root (1))]
	[SerializeField]
	internal Shader coreBlitPS; //Field offset: 0x50
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/CoreBlitColorAndDepth.shader", Package::Root (1))]
	[SerializeField]
	internal Shader coreBlitColorAndDepthPS; //Field offset: 0x58
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/Utils/BlitHDROverlay.shader", Package::Root (1))]
	[SerializeField]
	internal Shader blitHDROverlay; //Field offset: 0x60
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/CameraMotionVectors.shader", Package::Root (1))]
	public Shader cameraMotionVector; //Field offset: 0x68
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/PostProcessing/LensFlareScreenSpace.shader", Package::Root (1))]
	public Shader screenSpaceLensFlare; //Field offset: 0x70
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)", False)]
	[Reload("Shaders/PostProcessing/LensFlareDataDriven.shader", Package::Root (1))]
	public Shader dataDrivenLensFlare; //Field offset: 0x78

	public ShaderResources() { }

}

