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
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class UniversalCameraData : ContextItem // TypeDefIndex: 9477
	{
		// Fields
		private Matrix4x4 m_ViewMatrix; // 0x10
		private Matrix4x4 m_ProjectionMatrix; // 0x50
		private Matrix4x4 m_JitterMatrix; // 0x90
		private bool m_CachedRenderIntoTextureXR; // 0xD0
		private bool m_InitBuiltinXRConstants; // 0xD1
		public Camera camera; // 0xD8
		public int scaledWidth; // 0xE0
		public int scaledHeight; // 0xE4
		internal UniversalCameraHistory m_HistoryManager; // 0xE8
		public CameraRenderType renderType; // 0xF0
		public RenderTexture targetTexture; // 0xF8
		public RenderTextureDescriptor cameraTargetDescriptor; // 0x100
		internal RenderTargetInfo backbufferColor; // 0x134
		internal RenderTargetInfo backbufferDepth; // 0x14C
		internal Rect pixelRect; // 0x164
		internal bool useScreenCoordOverride; // 0x174
		internal Vector4 screenSizeOverride; // 0x178
		internal Vector4 screenCoordScaleBias; // 0x188
		internal int pixelWidth; // 0x198
		internal int pixelHeight; // 0x19C
		internal float aspectRatio; // 0x1A0
		public float renderScale; // 0x1A4
		internal ImageScalingMode imageScalingMode; // 0x1A8
		internal ImageUpscalingFilter upscalingFilter; // 0x1AC
		internal bool fsrOverrideSharpness; // 0x1B0
		internal float fsrSharpness; // 0x1B4
		internal HDRColorBufferPrecision hdrColorBufferPrecision; // 0x1B8
		public bool clearDepth; // 0x1BC
		public CameraType cameraType; // 0x1C0
		public bool isDefaultViewport; // 0x1C4
		public bool isHdrEnabled; // 0x1C5
		public bool allowHDROutput; // 0x1C6
		public bool isAlphaOutputEnabled; // 0x1C7
		public bool requiresDepthTexture; // 0x1C8
		public bool requiresOpaqueTexture; // 0x1C9
		public bool postProcessingRequiresDepthTexture; // 0x1CA
		public bool xrRendering; // 0x1CB
		internal bool useGPUOcclusionCulling; // 0x1CC
		internal bool stackLastCameraOutputToHDR; // 0x1CD
		internal bool rendersOffscreenUI; // 0x1CE
		internal bool blitsOffscreenUICover; // 0x1CF
		public SortingCriteria defaultOpaqueSortFlags; // 0x1D0
		[CompilerGenerated]
		private XRPass _xr_k__BackingField; // 0x1D8
		public float maxShadowDistance; // 0x1E0
		public bool postProcessEnabled; // 0x1E4
		internal bool stackAnyPostProcessingEnabled; // 0x1E5
		public IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> captureActions; // 0x1E8
		public LayerMask volumeLayerMask; // 0x1F0
		public Transform volumeTrigger; // 0x1F8
		public bool isStopNaNEnabled; // 0x200
		public bool isDitheringEnabled; // 0x201
		public AntialiasingMode antialiasing; // 0x204
		public AntialiasingQuality antialiasingQuality; // 0x208
		public ScriptableRenderer renderer; // 0x210
		public bool resolveFinalTarget; // 0x218
		public Vector3 worldSpaceCameraPos; // 0x21C
		public Color backgroundColor; // 0x228
		internal TaaHistory taaHistory; // 0x238
		internal StpHistory stpHistory; // 0x240
		internal TemporalAA.Settings taaSettings; // 0x248
		internal Vector2 subpixelJitter; // 0x268
		public Camera baseCamera; // 0x270
		internal bool isLastBaseCamera; // 0x278
	
		// Properties
		internal Vector2 jitter { get; } // 0x0000000181F9D8A0-0x0000000181F9D8C0 
		public UniversalCameraHistory historyManager { get; set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		internal bool requireSrgbConversion { get; } // 0x0000000181F9D930-0x0000000181F9DB50 
		public bool isGameCamera { get; } // 0x0000000181F9D7A0-0x0000000181F9D7B0 
		public bool isSceneViewCamera { get; } // 0x0000000181F9D890-0x0000000181F9D8A0 
		public bool isPreviewCamera { get; } // 0x0000000181F9D860-0x0000000181F9D870 
		internal bool isRenderPassSupportedCamera { get; } // 0x0000000181F9D870-0x0000000181F9D890 
		internal bool resolveToScreen { get; } // 0x0000000181F9DB60-0x0000000181F9DC10 
		public bool isHDROutputActive { get; } // 0x0000000181F9D7B0-0x0000000181F9D860 
		public HDROutputUtils.HDRDisplayInformation hdrDisplayInformation { get; } // 0x0000000181F9D620-0x0000000181F9D7A0 
		public ColorGamut hdrDisplayColorGamut { get; } // 0x0000000181F9D540-0x0000000181F9D620 
		public bool rendersOverlayUI { get; } // 0x0000000181F9D8C0-0x0000000181F9D930 
		public XRPass xr { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		internal XRPassUniversal xrUniversal { get; } // 0x0000000181F9DC10-0x0000000181F9DC90 
		internal bool resetHistory { get; } // 0x0000000181F9DB50-0x0000000181F9DB60 
	
		// Constructors
		public UniversalCameraData(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal void SetViewAndProjectionMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix); // 0x0000000181F9D430-0x0000000181F9D4C0
		internal void SetViewProjectionAndJitterMatrix(Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, Matrix4x4 jitterMatrix); // 0x0000000181F9D4C0-0x0000000181F9D540
		internal void PushBuiltinShaderConstantsXR(RasterCommandBuffer cmd, bool renderIntoTexture); // 0x0000000181F9C9A0-0x0000000181F9D1D0
		public Matrix4x4 GetViewMatrix(int viewIndex = 0 /* Metadata: 0x0069EBBF */); // 0x0000000181F9C100-0x0000000181F9C1A0
		public Matrix4x4 GetProjectionMatrix(int viewIndex = 0 /* Metadata: 0x0069EBC0 */); // 0x0000000181F9BF40-0x0000000181F9C100
		internal Matrix4x4 GetProjectionMatrixNoJitter(int viewIndex = 0 /* Metadata: 0x0069EBC1 */); // 0x0000000181F9BE90-0x0000000181F9BF40
		internal Matrix4x4 GetGPUProjectionMatrix(bool renderIntoTexture, int viewIndex = 0 /* Metadata: 0x0069EBC2 */); // 0x0000000181F9BDF0-0x0000000181F9BE90
		public bool IsHandleYFlipped(RTHandle handle); // 0x0000000181F9C1A0-0x0000000181F9C460
		public bool IsRenderTargetProjectionMatrixFlipped(RTHandle color, RTHandle depth = null); // 0x0000000181F9C460-0x0000000181F9C790
		internal bool IsTemporalAARequested(); // 0x0000000181F9C990-0x0000000181F9C9A0
		internal bool IsTemporalAAEnabled(); // 0x0000000181F9C8B0-0x0000000181F9C990
		internal bool IsSTPRequested(); // 0x0000000181F9C890-0x0000000181F9C8B0
		internal bool IsSTPEnabled(); // 0x0000000181F9C790-0x0000000181F9C890
		public override void Reset(); // 0x0000000181F9D1D0-0x0000000181F9D430
	}
}
