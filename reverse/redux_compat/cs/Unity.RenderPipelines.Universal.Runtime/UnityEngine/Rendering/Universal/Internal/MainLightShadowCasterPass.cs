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
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class MainLightShadowCasterPass : ScriptableRenderPass // TypeDefIndex: 9934
	{
		// Fields
		internal RTHandle m_MainLightShadowmapTexture; // 0x60
		private GraphicsFormat m_ShadowmapDepthStencilFormat; // 0x68
		private int m_RenderTargetWidth; // 0x6C
		private int m_RenderTargetHeight; // 0x70
		private int m_ShadowCasterCascadesCount; // 0x74
		private bool m_CreateEmptyShadowmap; // 0x78
		private bool m_SetKeywordForEmptyShadowmap; // 0x79
		private float m_CascadeBorder; // 0x7C
		private float m_MaxShadowDistanceSq; // 0x80
		private RenderTextureDescriptor m_MainLightShadowDescriptor; // 0x84
		private readonly Vector4[] m_CascadeSplitDistances; // 0xB8
		private readonly Matrix4x4[] m_MainLightShadowMatrices; // 0xC0
		private readonly ProfilingSampler m_ProfilingSetupSampler; // 0xC8
		private readonly ShadowSliceData[] m_CascadeSlices; // 0xD0
		private const int k_EmptyShadowMapDimensions = 1; // Metadata: 0x0069FDC6
		private const int k_MaxCascades = 4; // Metadata: 0x0069FDC7
		private const string k_MainLightShadowMapTextureName = "_MainLightShadowmapTexture"; // Metadata: 0x0069FDC8
		private static readonly Vector4 k_DefaultEmptyShadowParams; // 0x00
		private static Vector4 s_EmptyShadowParams; // 0x10
		private static readonly Vector4 s_EmptyShadowmapSize; // 0x20
	
		// Nested types
		private static class MainLightShadowConstantBuffer // TypeDefIndex: 9935
		{
			// Fields
			public static readonly int _WorldToShadow; // 0x00
			public static readonly int _ShadowParams; // 0x04
			public static readonly int _CascadeShadowSplitSpheres0; // 0x08
			public static readonly int _CascadeShadowSplitSpheres1; // 0x0C
			public static readonly int _CascadeShadowSplitSpheres2; // 0x10
			public static readonly int _CascadeShadowSplitSpheres3; // 0x14
			public static readonly int _CascadeShadowSplitSphereRadii; // 0x18
			public static readonly int _ShadowOffset0; // 0x1C
			public static readonly int _ShadowOffset1; // 0x20
			public static readonly int _ShadowmapSize; // 0x24
			public static readonly int _MainLightShadowmapID; // 0x28
	
			// Constructors
			static MainLightShadowConstantBuffer(); // 0x000000018203F7E0-0x000000018203F9F0
		}
	
		private class PassData // TypeDefIndex: 9936
		{
			// Fields
			internal bool emptyShadowmap; // 0x10
			internal bool setKeywordForEmptyShadowmap; // 0x11
			internal UniversalRenderingData renderingData; // 0x18
			internal UniversalCameraData cameraData; // 0x20
			internal UniversalLightData lightData; // 0x28
			internal UniversalShadowData shadowData; // 0x30
			internal MainLightShadowCasterPass pass; // 0x38
			internal TextureHandle shadowmapTexture; // 0x40
			internal readonly RendererListHandle[] shadowRendererListsHandle; // 0x50
	
			// Constructors
			public PassData(); // 0x000000018203F9F0-0x000000018203FA50
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9937
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__37_0; // 0x08
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__38_0; // 0x10
	
			// Constructors
			static __c(); // 0x00000001820414A0-0x0000000182041510
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _FetchShadowMapAndSetParameters_b__37_0(PassData data, RasterGraphContext context); // 0x0000000182040080-0x0000000182040240
			internal void _Render_b__38_0(PassData data, RasterGraphContext context); // 0x00000001820413C0-0x00000001820414A0
		}
	
		// Constructors
		public MainLightShadowCasterPass(RenderPassEvent evt); // 0x000000018203F670-0x000000018203F7E0
		static MainLightShadowCasterPass(); // 0x000000018203F600-0x000000018203F670
	
		// Methods
		public void Dispose(); // 0x0000000181F904B0-0x0000000181F904D0
		internal TextureHandle GetOrCreateShadowMapTexture(RenderGraph renderGraph, UniversalShadowData shadowData); // 0x000000018203C790-0x000000018203CA30
		public bool Setup(ref RenderingData renderingData); // 0x000000018203E820-0x000000018203E920
		public bool Setup(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018203F490-0x000000018203F4C0
		public bool Setup(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData, bool stencilBuffer); // 0x000000018203E920-0x000000018203F490
		private void UpdateTextureDescriptorIfNeeded(); // 0x000000018203F4C0-0x000000018203F600
		private bool SetupForEmptyRendering(bool stripShadowsOffVariants, bool shadowsEnabled, Light light, UniversalCameraData cameraData, UniversalShadowData shadowData); // 0x000000018203DFC0-0x000000018203E1E0
		private void Clear(); // 0x000000018203C170-0x000000018203C2D0
		internal static void SetShadowParamsForEmptyShadowmap(RasterCommandBuffer rasterCommandBuffer); // 0x000000018203DED0-0x000000018203DFC0
		private void RenderMainLightCascadeShadowmap(RasterCommandBuffer cmd, ref PassData data); // 0x000000018203CD70-0x000000018203D4B0
		internal void SetShadowGlobalKeywordsAndConstants(RasterCommandBuffer cmd, ref VisibleLight shadowLight, UniversalShadowData shadowData); // 0x000000018203DD80-0x000000018203DED0
		private void SetupMainLightShadowReceiverConstants(RasterCommandBuffer cmd, ref VisibleLight shadowLight, UniversalShadowData shadowData); // 0x000000018203E1E0-0x000000018203E820
		private void InitPassData(ref PassData passData, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018203CA30-0x000000018203CB10
		private void InitRendererLists(ref PassData passData, RenderGraph renderGraph); // 0x000000018203CB10-0x000000018203CD70
		internal TextureHandle FetchShadowMapAndSetParameters(RenderGraph graph, ContextContainer frameData); // 0x000000018203C2D0-0x000000018203C790
		internal TextureHandle Render(RenderGraph graph, ContextContainer frameData); // 0x000000018203D4B0-0x000000018203DD80
	}
}
