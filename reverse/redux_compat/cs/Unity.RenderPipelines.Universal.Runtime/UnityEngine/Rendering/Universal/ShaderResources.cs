/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
	[ReloadGroup]
	public sealed class ShaderResources // TypeDefIndex: 9471
	{
		// Fields
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/Blit.shader", ReloadAttribute.Package.Root)]
		public Shader blitPS; // 0x10
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/CopyDepth.shader", ReloadAttribute.Package.Root)]
		public Shader copyDepthPS; // 0x18
		[Obsolete("Obsolete, this feature will be supported by new \'ScreenSpaceShadows\' renderer feature. #from(2023.3) #breakingFrom(2023.3)", true)]
		public Shader screenSpaceShadowPS; // 0x20
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/Sampling.shader", ReloadAttribute.Package.Root)]
		public Shader samplingPS; // 0x28
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/StencilDeferred.shader", ReloadAttribute.Package.Root)]
		public Shader stencilDeferredPS; // 0x30
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/FallbackError.shader", ReloadAttribute.Package.Root)]
		public Shader fallbackErrorPS; // 0x38
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/FallbackLoading.shader", ReloadAttribute.Package.Root)]
		public Shader fallbackLoadingPS; // 0x40
		[Obsolete("Use fallbackErrorPS instead. #from(2023.3) #breakingFrom(2023.3)", true)]
		public Shader materialErrorPS; // 0x48
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/CoreBlit.shader", ReloadAttribute.Package.Root)]
		[SerializeField]
		internal Shader coreBlitPS; // 0x50
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/CoreBlitColorAndDepth.shader", ReloadAttribute.Package.Root)]
		[SerializeField]
		internal Shader coreBlitColorAndDepthPS; // 0x58
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/Utils/BlitHDROverlay.shader", ReloadAttribute.Package.Root)]
		[SerializeField]
		internal Shader blitHDROverlay; // 0x60
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/CameraMotionVectors.shader", ReloadAttribute.Package.Root)]
		public Shader cameraMotionVector; // 0x68
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/PostProcessing/LensFlareScreenSpace.shader", ReloadAttribute.Package.Root)]
		public Shader screenSpaceLensFlare; // 0x70
		[Obsolete("Moved to UniversalRenderPipelineRuntimeShaders on GraphicsSettings. #from(2023.3)")]
		[Reload("Shaders/PostProcessing/LensFlareDataDriven.shader", ReloadAttribute.Package.Root)]
		public Shader dataDrivenLensFlare; // 0x78
	
		// Constructors
		public ShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
