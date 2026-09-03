/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public struct CameraData // TypeDefIndex: 9842
	{
		// Fields
		private ContextContainer frameData; // 0x00
	
		// Properties
		internal UniversalCameraData universalCameraData { get; } // 0x0000000181FF5DA0-0x0000000181FF5DF0 
		public ref Camera camera { get; } // 0x0000000181FF5020-0x0000000181FF5070 
		public ref UniversalCameraHistory historyManager { get; } // 0x0000000181FF5320-0x0000000181FF5370 
		public ref CameraRenderType renderType { get; } // 0x0000000181FF5900-0x0000000181FF5950 
		public ref RenderTexture targetTexture { get; } // 0x0000000181FF5D50-0x0000000181FF5DA0 
		public ref RenderTextureDescriptor cameraTargetDescriptor { get; } // 0x0000000181FF4F80-0x0000000181FF4FD0 
		internal ref Rect pixelRect { get; } // 0x0000000181FF5770-0x0000000181FF57C0 
		internal ref bool useScreenCoordOverride { get; } // 0x0000000181FF5E40-0x0000000181FF5E90 
		internal ref Vector4 screenSizeOverride { get; } // 0x0000000181FF5C60-0x0000000181FF5CB0 
		internal ref Vector4 screenCoordScaleBias { get; } // 0x0000000181FF5C10-0x0000000181FF5C60 
		internal ref int pixelWidth { get; } // 0x0000000181FF57C0-0x0000000181FF5810 
		internal ref int pixelHeight { get; } // 0x0000000181FF5720-0x0000000181FF5770 
		internal ref float aspectRatio { get; } // 0x0000000181FF4E90-0x0000000181FF4EE0 
		public ref float renderScale { get; } // 0x0000000181FF58B0-0x0000000181FF5900 
		internal ref ImageScalingMode imageScalingMode { get; } // 0x0000000181FF5370-0x0000000181FF53C0 
		internal ref ImageUpscalingFilter upscalingFilter { get; } // 0x0000000181FF5DF0-0x0000000181FF5E40 
		internal ref bool fsrOverrideSharpness { get; } // 0x0000000181FF5160-0x0000000181FF51B0 
		internal ref float fsrSharpness { get; } // 0x0000000181FF51B0-0x0000000181FF5200 
		internal ref HDRColorBufferPrecision hdrColorBufferPrecision { get; } // 0x0000000181FF5200-0x0000000181FF5250 
		public ref bool clearDepth { get; } // 0x0000000181FF50C0-0x0000000181FF5110 
		public ref CameraType cameraType { get; } // 0x0000000181FF4FD0-0x0000000181FF5020 
		public ref bool isDefaultViewport { get; } // 0x0000000181FF5410-0x0000000181FF5460 
		public ref bool isHdrEnabled { get; } // 0x0000000181FF5510-0x0000000181FF5560 
		public ref bool allowHDROutput { get; } // 0x0000000181FF4DA0-0x0000000181FF4DF0 
		public ref bool isAlphaOutputEnabled { get; } // 0x0000000181FF53C0-0x0000000181FF5410 
		public ref bool requiresDepthTexture { get; } // 0x0000000181FF5A60-0x0000000181FF5AB0 
		public ref bool requiresOpaqueTexture { get; } // 0x0000000181FF5AB0-0x0000000181FF5B00 
		public ref bool postProcessingRequiresDepthTexture { get; } // 0x0000000181FF5860-0x0000000181FF58B0 
		public ref bool xrRendering { get; } // 0x0000000181FF5F80-0x0000000181FF5FD0 
		internal bool requireSrgbConversion { get; } // 0x0000000181FF5A00-0x0000000181FF5A60 
		public bool isSceneViewCamera { get; } // 0x0000000181FF5620-0x0000000181FF5680 
		public bool isPreviewCamera { get; } // 0x0000000181FF5560-0x0000000181FF55C0 
		internal bool isRenderPassSupportedCamera { get; } // 0x0000000181FF55C0-0x0000000181FF5620 
		internal bool resolveToScreen { get; } // 0x0000000181FF5BB0-0x0000000181FF5C10 
		public bool isHDROutputActive { get; } // 0x0000000181FF54B0-0x0000000181FF5510 
		public HDROutputUtils.HDRDisplayInformation hdrDisplayInformation { get; } // 0x0000000181FF52B0-0x0000000181FF5320 
		public ColorGamut hdrDisplayColorGamut { get; } // 0x0000000181FF5250-0x0000000181FF52B0 
		public bool rendersOverlayUI { get; } // 0x0000000181FF59A0-0x0000000181FF5A00 
		public ref SortingCriteria defaultOpaqueSortFlags { get; } // 0x0000000181FF5110-0x0000000181FF5160 
		public XRPass xr { get; internal set; } // 0x0000000181FF6030-0x0000000181FF6090 0x0000000181FF6090-0x0000000181FF6100
		internal XRPassUniversal xrUniversal { get; } // 0x0000000181FF5FD0-0x0000000181FF6030 
		public ref float maxShadowDistance { get; } // 0x0000000181FF56D0-0x0000000181FF5720 
		public ref bool postProcessEnabled { get; } // 0x0000000181FF5810-0x0000000181FF5860 
		public ref IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> captureActions { get; } // 0x0000000181FF5070-0x0000000181FF50C0 
		public ref LayerMask volumeLayerMask { get; } // 0x0000000181FF5E90-0x0000000181FF5EE0 
		public ref Transform volumeTrigger { get; } // 0x0000000181FF5EE0-0x0000000181FF5F30 
		public ref bool isStopNaNEnabled { get; } // 0x0000000181FF5680-0x0000000181FF56D0 
		public ref bool isDitheringEnabled { get; } // 0x0000000181FF5460-0x0000000181FF54B0 
		public ref AntialiasingMode antialiasing { get; } // 0x0000000181FF4E40-0x0000000181FF4E90 
		public ref AntialiasingQuality antialiasingQuality { get; } // 0x0000000181FF4DF0-0x0000000181FF4E40 
		public ref ScriptableRenderer renderer { get; } // 0x0000000181FF5950-0x0000000181FF59A0 
		public ref bool resolveFinalTarget { get; } // 0x0000000181FF5B60-0x0000000181FF5BB0 
		public ref Vector3 worldSpaceCameraPos { get; } // 0x0000000181FF5F30-0x0000000181FF5F80 
		public ref Color backgroundColor { get; } // 0x0000000181FF4EE0-0x0000000181FF4F30 
		internal ref TaaHistory taaHistory { get; } // 0x0000000181FF5CB0-0x0000000181FF5D00 
		internal ref TemporalAA.Settings taaSettings { get; } // 0x0000000181FF5D00-0x0000000181FF5D50 
		internal bool resetHistory { get; } // 0x0000000181FF5B00-0x0000000181FF5B60 
		public ref Camera baseCamera { get; } // 0x0000000181FF4F30-0x0000000181FF4F80 
	
		// Constructors
		internal CameraData(ContextContainer frameData); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		internal void SetViewAndProjectionMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix); // 0x0000000181FF4BA0-0x0000000181FF4C70
		internal void SetViewProjectionAndJitterMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, Matrix4x4 jitterMatrix); // 0x0000000181FF4C70-0x0000000181FF4DA0
		internal void PushBuiltinShaderConstantsXR(RasterCommandBuffer cmd, bool renderIntoTexture); // 0x0000000181FF4B20-0x0000000181FF4BA0
		public Matrix4x4 GetViewMatrix(int viewIndex = 0 /* Metadata: 0x0069F2FF */); // 0x0000000181FF4930-0x0000000181FF49D0
		public Matrix4x4 GetProjectionMatrix(int viewIndex = 0 /* Metadata: 0x0069F300 */); // 0x0000000181FF4890-0x0000000181FF4930
		internal Matrix4x4 GetProjectionMatrixNoJitter(int viewIndex = 0 /* Metadata: 0x0069F301 */); // 0x0000000181FF47F0-0x0000000181FF4890
		internal Matrix4x4 GetGPUProjectionMatrix(bool renderIntoTexture, int viewIndex = 0 /* Metadata: 0x0069F302 */); // 0x0000000181FF4740-0x0000000181FF47F0
		public bool IsHandleYFlipped(RTHandle handle); // 0x0000000181FF49D0-0x0000000181FF4A40
		public bool IsRenderTargetProjectionMatrixFlipped(RTHandle color, RTHandle depth = null); // 0x0000000181FF4A40-0x0000000181FF4AC0
		internal bool IsTemporalAAEnabled(); // 0x0000000181FF4AC0-0x0000000181FF4B20
	}
}
