/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal sealed class MotionVectorRenderPass : ScriptableRenderPass // TypeDefIndex: 9573
	{
		// Fields
		internal const string k_MotionVectorTextureName = "_MotionVectorTexture"; // Metadata: 0x0069EC2D
		internal const string k_MotionVectorDepthTextureName = "_MotionVectorDepthTexture"; // Metadata: 0x0069EC42
		internal const GraphicsFormat k_TargetFormat = GraphicsFormat.R16G16_SFloat; // Metadata: 0x0069EC5C
		public const string k_MotionVectorsLightModeTag = "MotionVectors"; // Metadata: 0x0069EC5D
		private static readonly string[] s_ShaderTags; // 0x00
		private static readonly int s_CameraDepthTextureID; // 0x08
		private static readonly ProfilingSampler s_SetMotionMatrixProfilingSampler; // 0x10
		private readonly Material m_CameraMaterial; // 0x60
		private readonly FilteringSettings m_FilteringSettings; // 0x68
	
		// Nested types
		private class PassData // TypeDefIndex: 9574
		{
			// Fields
			internal Camera camera; // 0x10
			internal XRPass xr; // 0x18
			internal TextureHandle cameraDepth; // 0x20
			internal Material cameraMaterial; // 0x30
			internal RendererListHandle rendererListHdl; // 0x38
			internal RendererList rendererList; // 0x48
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public class MotionMatrixPassData // TypeDefIndex: 9575
		{
			// Fields
			public MotionVectorsPersistentData motionData; // 0x10
			public XRPass xr; // 0x18
	
			// Constructors
			public MotionMatrixPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9576
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__17_0; // 0x08
			public static BaseRenderFunc<MotionMatrixPassData, RasterGraphContext> __9__19_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181FBEB90-0x0000000181FBEC00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__17_0(PassData data, RasterGraphContext context); // 0x0000000181FBE450-0x0000000181FBE600
			internal void _SetRenderGraphMotionVectorGlobalMatrices_b__19_0(MotionMatrixPassData data, RasterGraphContext context); // 0x0000000181FBE9A0-0x0000000181FBE9D0
		}
	
		// Constructors
		internal MotionVectorRenderPass(RenderPassEvent evt, Material cameraMaterial, LayerMask opaqueLayerMask); // 0x0000000181FAE280-0x0000000181FAE3D0
		static MotionVectorRenderPass(); // 0x0000000181FAE140-0x0000000181FAE280
	
		// Methods
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000181FAC960-0x0000000181FACC20
		private static DrawingSettings GetDrawingSettings(Camera camera); // 0x0000000181FACC20-0x0000000181FACF00
		private static void DrawCameraMotionVectors(RasterCommandBuffer cmd, XRPass xr, Material cameraMaterial); // 0x0000000181FAC730-0x0000000181FAC8C0
		private static void DrawObjectMotionVectors(RasterCommandBuffer cmd, XRPass xr, ref RendererList rendererList); // 0x0000000181FAC8C0-0x0000000181FAC960
		private void InitPassData(ref PassData passData, UniversalCameraData cameraData); // 0x0000000181FACF00-0x0000000181FACF90
		private void InitRendererLists(ref PassData passData, ref CullingResults cullResults, RenderGraph renderGraph); // 0x0000000181FACF90-0x0000000181FAD2C0
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle cameraDepthTexture, [IsReadOnly] in TextureHandle motionVectorColor, [IsReadOnly] in TextureHandle motionVectorDepth); // 0x0000000181FAD2C0-0x0000000181FADDA0
		internal static void SetRenderGraphMotionVectorGlobalMatrices(RenderGraph renderGraph, UniversalCameraData cameraData); // 0x0000000181FADDA0-0x0000000181FAE140
	}
}
