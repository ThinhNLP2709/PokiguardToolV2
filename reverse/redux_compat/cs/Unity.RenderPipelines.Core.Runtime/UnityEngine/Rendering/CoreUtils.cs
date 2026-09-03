/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class CoreUtils // TypeDefIndex: 5748
	{
		// Fields
		public static readonly Vector3[] lookAtList; // 0x00
		public static readonly Vector3[] upVectorList; // 0x08
		private const string obsoletePriorityMessage = "Use CoreUtils.Priorities instead. #from(2021.2)"; // Metadata: 0x00661A14
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int editMenuPriority1 = 320; // Metadata: 0x00661A44
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int editMenuPriority2 = 331; // Metadata: 0x00661A46
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int editMenuPriority3 = 342; // Metadata: 0x00661A48
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int editMenuPriority4 = 353; // Metadata: 0x00661A4A
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int assetCreateMenuPriority1 = 230; // Metadata: 0x00661A4C
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int assetCreateMenuPriority2 = 241; // Metadata: 0x00661A4E
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int assetCreateMenuPriority3 = 300; // Metadata: 0x00661A50
		[Obsolete("Use CoreUtils.Priorities instead. #from(2021.2)")]
		public const int gameObjectMenuPriority = 10; // Metadata: 0x00661A52
		[NoAutoStaticsCleanup]
		private static Cubemap m_BlackCubeTexture; // 0x10
		[NoAutoStaticsCleanup]
		private static Cubemap m_MagentaCubeTexture; // 0x18
		[NoAutoStaticsCleanup]
		private static CubemapArray m_MagentaCubeTextureArray; // 0x20
		[NoAutoStaticsCleanup]
		private static Cubemap m_WhiteCubeTexture; // 0x28
		[NoAutoStaticsCleanup]
		private static RenderTexture m_EmptyUAV; // 0x30
		[NoAutoStaticsCleanup]
		private static GraphicsBuffer m_EmptyBuffer; // 0x38
		[NoAutoStaticsCleanup]
		private static Texture3D m_BlackVolumeTexture; // 0x40
		[NoAutoStaticsCleanup]
		internal static Texture3D m_WhiteVolumeTexture; // 0x48
		private static IEnumerable<Type> s_AssemblyTypes; // 0x50
	
		// Properties
		public static Cubemap blackCubeTexture { get; } // 0x0000000181EB3610-0x0000000181EB37A0 
		public static Cubemap magentaCubeTexture { get; } // 0x0000000181EB3D30-0x0000000181EB3EC0 
		public static CubemapArray magentaCubeTextureArray { get; } // 0x0000000181EB3B80-0x0000000181EB3D30 
		public static Cubemap whiteCubeTexture { get; } // 0x0000000181EB3EC0-0x0000000181EB4050 
		public static RenderTexture emptyUAV { get; } // 0x0000000181EB3A30-0x0000000181EB3B80 
		public static GraphicsBuffer emptyBuffer { get; } // 0x0000000181EB3940-0x0000000181EB3A30 
		public static Texture3D blackVolumeTexture { get; } // 0x0000000181EB37A0-0x0000000181EB3940 
		internal static Texture3D whiteVolumeTexture { get; } // 0x0000000181EB4050-0x0000000181EB41F0 
	
		// Nested types
		public static class Sections // TypeDefIndex: 5749
		{
			// Fields
			public const int section1 = 10000; // Metadata: 0x00661A53
			public const int section2 = 20000; // Metadata: 0x00661A57
			public const int section3 = 30000; // Metadata: 0x00661A5B
			public const int section4 = 40000; // Metadata: 0x00661A5F
			public const int section5 = 50000; // Metadata: 0x00661A63
			public const int section6 = 60000; // Metadata: 0x00661A67
			public const int section7 = 70000; // Metadata: 0x00661A6B
			public const int section8 = 80000; // Metadata: 0x00661A6F
		}
	
		public static class Priorities // TypeDefIndex: 5750
		{
			// Fields
			public const int assetsCreateShaderMenuPriority = 83; // Metadata: 0x00661A73
			public const int assetsCreateRenderingMenuPriority = 308; // Metadata: 0x00661A75
			public const int editMenuPriority = 320; // Metadata: 0x00661A77
			public const int gameObjectMenuPriority = 10; // Metadata: 0x00661A79
			public const int srpLensFlareMenuPriority = 9; // Metadata: 0x00661A7A
			public const int scriptingPriority = 40; // Metadata: 0x00661A7B
		}
	
		// Constructors
		static CoreUtils(); // 0x0000000181EB33E0-0x0000000181EB3610
	
		// Methods
		public static void ClearRenderTarget(CommandBuffer cmd, ClearFlag clearFlag, Color clearColor); // 0x0000000181EADE80-0x0000000181EADEC0
		private static int FixupDepthSlice(int depthSlice, RTHandle buffer); // 0x0000000181EAEE70-0x0000000181EAEEC0
		private static int FixupDepthSlice(int depthSlice, CubemapFace cubemapFace); // 0x0000000181EAEE60-0x0000000181EAEE70
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619BF */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619C0 */, int depthSlice = -1 /* Metadata: 0x006619C1 */); // 0x0000000181EB12E0-0x0000000181EB13F0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, ClearFlag clearFlag = ClearFlag.None /* Metadata: 0x006619C2 */, int miplevel = 0 /* Metadata: 0x006619C3 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619C4 */, int depthSlice = -1 /* Metadata: 0x006619C5 */); // 0x0000000181EB1570-0x0000000181EB16B0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, int miplevel = 0 /* Metadata: 0x006619C6 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619C7 */, int depthSlice = -1 /* Metadata: 0x006619C8 */); // 0x0000000181EB2EE0-0x0000000181EB3010
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, int miplevel = 0 /* Metadata: 0x006619C9 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619CA */, int depthSlice = -1 /* Metadata: 0x006619CB */); // 0x0000000181EB13F0-0x0000000181EB1570
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619CC */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619CD */, int depthSlice = -1 /* Metadata: 0x006619CE */); // 0x0000000181EB2440-0x0000000181EB2590
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer); // 0x0000000181EB1200-0x0000000181EB12E0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag = ClearFlag.None /* Metadata: 0x006619CF */); // 0x0000000181EB10E0-0x0000000181EB1200
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthBuffer, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB2590-0x0000000181EB2690
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB3010-0x0000000181EB3100
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, int miplevel = 0 /* Metadata: 0x006619D0 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619D1 */, int depthSlice = -1 /* Metadata: 0x006619D2 */); // 0x0000000181EB17B0-0x0000000181EB18C0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619D3 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619D4 */, int depthSlice = -1 /* Metadata: 0x006619D5 */); // 0x0000000181EB0B30-0x0000000181EB0CD0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag); // 0x0000000181EB2AE0-0x0000000181EB2BF0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB2DA0-0x0000000181EB2EE0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, int miplevel = 0 /* Metadata: 0x006619D6 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619D7 */, int depthSlice = -1 /* Metadata: 0x006619D8 */); // 0x0000000181EB0980-0x0000000181EB0B30
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619D9 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619DA */, int depthSlice = -1 /* Metadata: 0x006619DB */); // 0x0000000181EB2690-0x0000000181EB2900
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB16B0-0x0000000181EB17B0
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag); // 0x0000000181EB1C90-0x0000000181EB1E00
		private static void SetViewportAndClear(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB3220-0x0000000181EB3340
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619DC */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619DD */, int depthSlice = -1 /* Metadata: 0x006619DE */); // 0x0000000181EB2900-0x0000000181EB2AE0
		public static void SetRenderTarget(ComputeCommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619DF */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619E0 */, int depthSlice = -1 /* Metadata: 0x006619E1 */); // 0x0000000181EB1B10-0x0000000181EB1BD0
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, ClearFlag clearFlag = ClearFlag.None /* Metadata: 0x006619E2 */, int miplevel = 0 /* Metadata: 0x006619E3 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619E4 */, int depthSlice = -1 /* Metadata: 0x006619E5 */); // 0x0000000181EB3100-0x0000000181EB31C0
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, int miplevel = 0 /* Metadata: 0x006619E6 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619E7 */, int depthSlice = -1 /* Metadata: 0x006619E8 */); // 0x0000000181EB1BD0-0x0000000181EB1C90
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, int miplevel = 0 /* Metadata: 0x006619E9 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619EA */, int depthSlice = -1 /* Metadata: 0x006619EB */); // 0x0000000181EB08C0-0x0000000181EB0980
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619EC */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619ED */, int depthSlice = -1 /* Metadata: 0x006619EE */); // 0x0000000181EB1E00-0x0000000181EB20D0
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle buffer, RenderBufferLoadAction loadAction, RenderBufferStoreAction storeAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619EF */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619F0 */, int depthSlice = -1 /* Metadata: 0x006619F1 */); // 0x0000000181EB0E70-0x0000000181EB10E0
		public static void SetRenderTarget(CommandBuffer cmd, RTHandle colorBuffer, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RTHandle depthBuffer, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlag, Color clearColor, int miplevel = 0 /* Metadata: 0x006619F2 */, CubemapFace cubemapFace = CubemapFace.Unknown /* Metadata: 0x006619F3 */, int depthSlice = -1 /* Metadata: 0x006619F4 */); // 0x0000000181EB20D0-0x0000000181EB2440
		public static void SetShadingRateFragmentSize(CommandBuffer cmd, ShadingRateFragmentSize baseShadingRateFragmentSize); // 0x0000000181EB31E0-0x0000000181EB3200
		public static void SetShadingRateCombiner(CommandBuffer cmd, ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000181EB31C0-0x0000000181EB31E0
		public static void SetShadingRateImage(CommandBuffer cmd, [IsReadOnly] in RenderTargetIdentifier shadingRateImage); // 0x0000000181EB3200-0x0000000181EB3220
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer); // 0x0000000181EB0CD0-0x0000000181EB0E70
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag = ClearFlag.None /* Metadata: 0x006619F5 */); // 0x0000000181EB18C0-0x0000000181EB1B10
		public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier[] colorBuffers, RTHandle depthBuffer, ClearFlag clearFlag, Color clearColor); // 0x0000000181EB2BF0-0x0000000181EB2DA0
		public static void SetViewport(CommandBuffer cmd, RTHandle target); // 0x0000000181EB3340-0x0000000181EB33E0
		public static string GetRenderTargetAutoName(int width, int height, int depth, RenderTextureFormat format, string name, bool mips = false /* Metadata: 0x006619F6 */, bool enableMSAA = false /* Metadata: 0x006619F7 */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x006619F8 */); // 0x0000000181EAF880-0x0000000181EAF980
		public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, string name, bool mips = false /* Metadata: 0x006619F9 */, bool enableMSAA = false /* Metadata: 0x006619FA */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x006619FB */); // 0x0000000181EAF780-0x0000000181EAF880
		public static string GetRenderTargetAutoName(int width, int height, int depth, GraphicsFormat format, TextureDimension dim, string name, bool mips = false /* Metadata: 0x006619FC */, bool enableMSAA = false /* Metadata: 0x006619FD */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x006619FE */, bool dynamicRes = false /* Metadata: 0x006619FF */, bool dynamicResExplicit = false /* Metadata: 0x00661A00 */); // 0x0000000181EAF670-0x0000000181EAF780
		private static string GetRenderTargetAutoName(int width, int height, int depth, string format, TextureDimension dim, string name, bool mips, bool enableMSAA, MSAASamples msaaSamples, bool dynamicRes, bool dynamicResExplicit); // 0x0000000181EAF420-0x0000000181EAF670
		public static string GetTextureAutoName(int width, int height, TextureFormat format, TextureDimension dim = TextureDimension.None /* Metadata: 0x00661A01 */, string name = "" /* Metadata: 0x00661A02 */, bool mips = false /* Metadata: 0x00661A03 */, int depth = 0 /* Metadata: 0x00661A04 */); // 0x0000000181EAFA60-0x0000000181EAFB40
		public static string GetTextureAutoName(int width, int height, GraphicsFormat format, TextureDimension dim = TextureDimension.None /* Metadata: 0x00661A05 */, string name = "" /* Metadata: 0x00661A06 */, bool mips = false /* Metadata: 0x00661A07 */, int depth = 0 /* Metadata: 0x00661A08 */); // 0x0000000181EAF980-0x0000000181EAFA60
		private static string GetTextureAutoName(int width, int height, string format, TextureDimension dim = TextureDimension.None /* Metadata: 0x00661A09 */, string name = "" /* Metadata: 0x00661A0A */, bool mips = false /* Metadata: 0x00661A0B */, int depth = 0 /* Metadata: 0x00661A0C */); // 0x0000000181EAFB40-0x0000000181EB0010
		public static void ClearCubemap(CommandBuffer cmd, RenderTexture renderTexture, Color clearColor, bool clearMips = false /* Metadata: 0x00661A0D */); // 0x0000000181EADBF0-0x0000000181EADE80
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A0E */); // 0x0000000181EAEA70-0x0000000181EAEAF0
		public static void DrawFullScreen(RasterCommandBuffer commandBuffer, Material material, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A0F */); // 0x0000000181EAE6F0-0x0000000181EAE7E0
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A10 */); // 0x0000000181EAEAF0-0x0000000181EAEBE0
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier colorBuffer, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A11 */); // 0x0000000181EAEBE0-0x0000000181EAED00
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, RenderTargetIdentifier depthStencilBuffer, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A12 */); // 0x0000000181EAE7E0-0x0000000181EAE8E0
		public static void DrawFullScreen(CommandBuffer commandBuffer, Material material, RenderTargetIdentifier[] colorBuffers, MaterialPropertyBlock properties = null, int shaderPassId = 0 /* Metadata: 0x00661A13 */); // 0x0000000181EAE8E0-0x0000000181EAEA70
		public static Color ConvertSRGBToActiveColorSpace(Color color); // 0x0000000181EADF60-0x0000000181EAE000
		public static Color ConvertLinearToActiveColorSpace(Color color); // 0x0000000181EADEC0-0x0000000181EADF60
		public static Material CreateEngineMaterial(string shaderPath); // 0x0000000181EAE440-0x0000000181EAE5A0
		public static Material CreateEngineMaterial(Shader shader); // 0x0000000181EAE5A0-0x0000000181EAE690
		public static bool HasFlag<T>(T mask, T flag)
			where T : IConvertible;
		public static void Swap<T>(ref ref T a, ref ref T b);
		public static void SetKeyword(CommandBuffer cmd, string keyword, bool state); // 0x0000000181EB0890-0x0000000181EB08C0
		public static void SetKeyword(CommandBuffer cmd, ComputeShader cs, string keyword, bool state); // 0x0000000181EB0740-0x0000000181EB07C0
		public static void SetKeyword(BaseCommandBuffer cmd, string keyword, bool state); // 0x0000000181EB0820-0x0000000181EB0860
		public static void SetKeyword(Material material, string keyword, bool state); // 0x0000000181EB07F0-0x0000000181EB0820
		public static void SetKeyword(Material material, LocalKeyword keyword, bool state); // 0x0000000181EB07C0-0x0000000181EB07F0
		public static void SetKeyword(ComputeShader cs, string keyword, bool state); // 0x0000000181EB0860-0x0000000181EB0890
		public static void Destroy(UnityEngine.Object obj); // 0x0000000181EAE690-0x0000000181EAE6F0
		public static IEnumerable<Type> GetAllAssemblyTypes(); // 0x0000000181EAEEC0-0x0000000181EAF270
		public static IEnumerable<Type> GetAllTypesDerivedFrom<T>();
		public static void SafeRelease(GraphicsBuffer buffer); // 0x0000000181EB0730-0x0000000181EB0740
		public static void SafeRelease(ComputeBuffer buffer); // 0x0000000181EB0720-0x0000000181EB0730
		public static Mesh CreateCubeMesh(Vector3 min, Vector3 max); // 0x0000000181EAE000-0x0000000181EAE440
		public static bool ArePostProcessesEnabled(Camera camera); // 0x00000001802E7990-0x00000001802E79A0
		public static bool AreAnimatedMaterialsEnabled(Camera camera); // 0x00000001802E7990-0x00000001802E79A0
		public static bool IsSceneLightingDisabled(Camera camera); // 0x00000001802E7840-0x00000001802E7850
		public static bool IsLightOverlapDebugEnabled(Camera camera); // 0x00000001802E7840-0x00000001802E7850
		public static bool IsSceneViewFogEnabled(Camera camera); // 0x00000001802E7990-0x00000001802E79A0
		public static bool IsSceneFilteringEnabled(); // 0x00000001802E7840-0x00000001802E7850
		public static bool IsSceneViewPrefabStageContextHidden(); // 0x00000001802E7840-0x00000001802E7850
		[Obsolete("Use DrawRendererList(CommandBuffer cmd, UnityEngine.Rendering.RendererList rendererList) instead. #from(6000.3) (UnityUpgradable) -> !0")]
		public static void DrawRendererList(ScriptableRenderContext renderContext, CommandBuffer cmd, RendererList rendererList); // 0x0000000181EAED40-0x0000000181EAED80
		public static void DrawRendererList(CommandBuffer cmd, RendererList rendererList); // 0x0000000181EAED00-0x0000000181EAED40
		public static void DrawRendererList(IRasterCommandBuffer cmd, RendererList rendererList); // 0x0000000181EAED80-0x0000000181EAEE60
		public static int GetTextureHash(Texture texture); // 0x0000000181EB0010-0x0000000181EB01A0
		public static int PreviousPowerOfTwo(int size); // 0x0000000181EB06F0-0x0000000181EB0720
		public static int GetMipCount(int size); // 0x0000000181EAF2C0-0x0000000181EAF370
		public static int GetMipCount(float size); // 0x0000000181EAF370-0x0000000181EAF420
		public static int DivRoundUp(int value, int divisor); // 0x0000000181E58550-0x0000000181E58560
		public static T GetLastEnumValue<T>()
			where T : Enum;
		internal static string GetCorePath(); // 0x0000000181EAF270-0x0000000181EAF2A0
		public static Vector3[] CalculateViewSpaceCorners(Matrix4x4 proj, float z); // 0x0000000181EAD690-0x0000000181EADBF0
		public static GraphicsFormat GetDefaultDepthStencilFormat(); // 0x0000000181EAF2B0-0x0000000181EAF2C0
		public static GraphicsFormat GetDefaultDepthOnlyFormat(); // 0x0000000181EAF2A0-0x0000000181EAF2B0
		public static DepthBits GetDefaultDepthBufferBits(); // 0x0000000180A2FAE0-0x0000000180A2FAF0
		public static bool IsScreenFullyCoveredByCameras(List<Camera> cameras); // 0x0000000181EB01A0-0x0000000181EB06F0
	}
}
