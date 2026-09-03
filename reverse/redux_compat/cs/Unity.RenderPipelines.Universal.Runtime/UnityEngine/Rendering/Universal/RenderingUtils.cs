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
	public static class RenderingUtils // TypeDefIndex: 9766
	{
		// Fields
		private static readonly ShaderTagId[] s_LegacyShaderPassNames; // 0x00
		private static readonly AttachmentDescriptor s_EmptyAttachment; // 0x08
		private static Mesh s_FullscreenMesh; // 0x80
		private static Material s_ErrorMaterial; // 0x88
		private static readonly ShaderTagId[] s_ShaderTagValues; // 0x90
		private static readonly RenderStateBlock[] s_RenderStateBlocks; // 0x98
		private static readonly Dictionary<RenderTextureFormat, bool> s_RenderTextureFormatSupport; // 0xA0
	
		// Properties
		internal static AttachmentDescriptor emptyAttachment { get; } // 0x0000000181FE1CD0-0x0000000181FE1D70 
		[Obsolete("Use Blitter.BlitCameraTexture instead of CommandBuffer.DrawMesh(fullscreenMesh, ...). #from(2022.2)")]
		public static Mesh fullscreenMesh { get; } // 0x0000000181FE1E90-0x0000000181FE23E0 
		internal static bool useStructuredBuffer { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal static bool usePersistentConstantBuffer { get; } // 0x0000000181FE23E0-0x0000000181FE2400 
		private static Material errorMaterial { get; } // 0x0000000181FE1D70-0x0000000181FE1E90 
	
		// Constructors
		static RenderingUtils(); // 0x0000000181FE1940-0x0000000181FE1CD0
	
		// Methods
		internal static bool SupportsLightLayers(GraphicsDeviceType type); // 0x00000001802E7990-0x00000001802E79A0
		internal static bool IsCompatibleWithTileOnlyMode(ScriptableRenderPassInput requirements, RenderPassEvent renderPassEvent); // 0x0000000181FDE660-0x0000000181FDE690
		public static void SetViewAndProjectionMatrices(CommandBuffer cmd, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, bool setInverseMatrices); // 0x0000000181FE14D0-0x0000000181FE15E0
		public static void SetViewAndProjectionMatrices(RasterCommandBuffer cmd, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, bool setInverseMatrices); // 0x0000000181FE10F0-0x0000000181FE14D0
		internal static void SetScaleBiasRt(RasterCommandBuffer cmd, [IsReadOnly] in UniversalCameraData cameraData, RTHandle rTHandle); // 0x0000000181FE0F10-0x0000000181FE10F0
		internal static void SetupOffscreenUIViewportParams(Material material, ref Rect pixelRect, bool isRenderToBackBufferTarget); // 0x0000000181FE15E0-0x0000000181FE1760
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal static void CreateRendererParamsObjectsWithError(ref CullingResults cullResults, Camera camera, FilteringSettings filterSettings, SortingCriteria sortFlags, ref RendererListParams param); // 0x0000000181FDDE40-0x0000000181FDE260
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal static void CreateRendererListObjectsWithError(RenderGraph renderGraph, ref CullingResults cullResults, Camera camera, FilteringSettings filterSettings, SortingCriteria sortFlags, ref RendererListHandle rl); // 0x0000000181FDD950-0x0000000181FDDA60
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal static void DrawRendererListObjectsWithError(RasterCommandBuffer cmd, ref RendererList rl); // 0x0000000181FDE260-0x0000000181FDE2A0
		internal static void CreateRendererListWithRenderStateBlock(RenderGraph renderGraph, ref CullingResults cullResults, DrawingSettings ds, FilteringSettings fs, RenderStateBlock rsb, ref RendererListHandle rl); // 0x0000000181FDDA60-0x0000000181FDDE40
		internal static void ClearSystemInfoCache(); // 0x0000000181FDCA10-0x0000000181FDCA80
		public static bool SupportsRenderTextureFormat(RenderTextureFormat format); // 0x0000000181FE1860-0x0000000181FE1940
		[Obsolete("Use SystemInfo.IsFormatSupported instead. #from(2023.2)")]
		public static bool SupportsGraphicsFormat(GraphicsFormat format, FormatUsage usage); // 0x0000000181FE1840-0x0000000181FE1860
		internal static bool MultisampleDepthResolveSupported(); // 0x0000000181FDE6F0-0x0000000181FDE760
		internal static bool ShouldDepthAttachmentBindMS(); // 0x0000000181FE1760-0x0000000181FE1840
		internal static bool RTHandleNeedsReAlloc(RTHandle handle, [IsReadOnly] in TextureDesc descriptor, bool scaled); // 0x0000000181FDE760-0x0000000181FDEB10
		[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
		public static bool ReAllocateIfNeeded(ref RTHandle handle, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F081 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F082 */, bool isShadowMap = false /* Metadata: 0x0069F083 */, int anisoLevel = 1 /* Metadata: 0x0069F084 */, float mipMapBias = 0f /* Metadata: 0x0069F085 */, string name = "" /* Metadata: 0x0069F089 */); // 0x0000000181FE0520-0x0000000181FE0960
		[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
		public static bool ReAllocateIfNeeded(ref RTHandle handle, Vector2 scaleFactor, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F08A */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F08B */, bool isShadowMap = false /* Metadata: 0x0069F08C */, int anisoLevel = 1 /* Metadata: 0x0069F08D */, float mipMapBias = 0f /* Metadata: 0x0069F08E */, string name = "" /* Metadata: 0x0069F092 */); // 0x0000000181FE0960-0x0000000181FE0EA0
		[Obsolete("This method will be removed in a future release. Please use ReAllocateHandleIfNeeded instead. #from(2023.3)")]
		public static bool ReAllocateIfNeeded(ref RTHandle handle, ScaleFunc scaleFunc, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F093 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F094 */, bool isShadowMap = false /* Metadata: 0x0069F095 */, int anisoLevel = 1 /* Metadata: 0x0069F096 */, float mipMapBias = 0f /* Metadata: 0x0069F097 */, string name = "" /* Metadata: 0x0069F09B */); // 0x0000000181FDFFE0-0x0000000181FE0520
		public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F09C */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F09D */, int anisoLevel = 1 /* Metadata: 0x0069F09E */, float mipMapBias = 0f /* Metadata: 0x0069F09F */, string name = "" /* Metadata: 0x0069F0A3 */); // 0x0000000181FDF5A0-0x0000000181FDFA40
		public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, TextureDesc descriptor, string name); // 0x0000000181FDF0B0-0x0000000181FDF5A0
		public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, Vector2 scaleFactor, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F0A4 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F0A5 */, int anisoLevel = 1 /* Metadata: 0x0069F0A6 */, float mipMapBias = 0f /* Metadata: 0x0069F0A7 */, string name = "" /* Metadata: 0x0069F0AB */); // 0x0000000181FDEB10-0x0000000181FDF0B0
		public static bool ReAllocateHandleIfNeeded(ref RTHandle handle, ScaleFunc scaleFunc, [IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069F0AC */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0069F0AD */, int anisoLevel = 1 /* Metadata: 0x0069F0AE */, float mipMapBias = 0f /* Metadata: 0x0069F0AF */, string name = "" /* Metadata: 0x0069F0B3 */); // 0x0000000181FDFA40-0x0000000181FDFFE0
		public static bool SetMaxRTHandlePoolCapacity(int capacity); // 0x0000000181FE0EA0-0x0000000181FE0F10
		internal static void AddStaleResourceToPoolOrRelease(TextureDesc desc, RTHandle handle); // 0x0000000181FDC940-0x0000000181FDCA10
		public static DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, ref RenderingData renderingData, SortingCriteria sortingCriteria); // 0x0000000181FDD6F0-0x0000000181FDD890
		public static DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria); // 0x0000000181FDCC60-0x0000000181FDCEB0
		public static DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, ref RenderingData renderingData, SortingCriteria sortingCriteria); // 0x0000000181FDD230-0x0000000181FDD6F0
		public static DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria); // 0x0000000181FDCEB0-0x0000000181FDD230
		internal static bool IsHandleYFlipped([IsReadOnly] in RasterGraphContext renderGraphContext, [IsReadOnly] in TextureHandle textureHandle); // 0x0000000181FDE690-0x0000000181FDE6F0
		internal static Vector4 GetFinalBlitScaleBias([IsReadOnly] in RasterGraphContext renderGraphContext, [IsReadOnly] in TextureHandle source, [IsReadOnly] in TextureHandle destination); // 0x0000000181FDE4A0-0x0000000181FDE640
		private static TextureUVOrigin GetRealBackBufferUVOrientation(); // 0x0000000181FDE640-0x0000000181FDE660
		internal static TextureUVOrigin GetBackBufferUVOrientation(UniversalCameraData cameraData); // 0x0000000181FDE2A0-0x0000000181FDE360
		internal static TextureUVOrigin GetCameraTargetsUVOrientation(UniversalCameraData cameraData); // 0x0000000181FDE360-0x0000000181FDE4A0
		internal static Matrix4x4 ComputeInverseViewProjectionMatrix(TextureUVOrigin textureUVOrigin, UniversalCameraData cameraData, int eyeIndex = 0 /* Metadata: 0x0069F0B4 */); // 0x0000000181FDCA80-0x0000000181FDCC60
		internal static RTHandleAllocInfo CreateRTHandleAllocInfo([IsReadOnly] in RenderTextureDescriptor descriptor, FilterMode filterMode, TextureWrapMode wrapMode, int anisoLevel, float mipMapBias, string name); // 0x0000000181FDB170-0x0000000181FDB3B0
		internal static RTHandleAllocInfo CreateRTHandleAllocInfo([IsReadOnly] in TextureDesc descriptor, string name); // 0x0000000181FDD890-0x0000000181FDD950
	}
}
