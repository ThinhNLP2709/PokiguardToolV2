/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class XRDepthMotionPass : ScriptableRenderPass // TypeDefIndex: 9677
	{
		// Fields
		public const string k_MotionOnlyShaderTagIdName = "XRMotionVectors"; // Metadata: 0x0069EE83
		private static readonly int k_XRDepthTextureNameID; // 0x00
		private LocalKeyword m_SubsampleDepthKeyword; // 0x60
		private static readonly ShaderTagId k_MotionOnlyShaderTagId; // 0x04
		private static readonly int k_SpaceWarpNDCModifier; // 0x08
		private RTHandle m_XRMotionVectorColor; // 0x78
		private TextureHandle xrMotionVectorColor; // 0x80
		private RTHandle m_XRMotionVectorDepth; // 0x90
		private TextureHandle xrMotionVectorDepth; // 0x98
		private bool m_XRSpaceWarpRightHandedNDC; // 0xA8
		private LayerMask m_transparentlayerMask; // 0xAC
		private const int k_XRViewCountPerPass = 2; // Metadata: 0x0069EE93
		private Matrix4x4[] m_StagingMatrixArray; // 0xB0
		private Matrix4x4[] m_PreviousStagingMatrixArray; // 0xB8
		private const int k_XRViewCount = 4; // Metadata: 0x0069EE94
		private Matrix4x4[] m_ViewProjection; // 0xC0
		private Matrix4x4[] m_PreviousViewProjection; // 0xC8
		private int m_LastFrameIndex; // 0xD0
		private Material m_XRMotionVectorMaterial; // 0xD8
	
		// Nested types
		private class PassData // TypeDefIndex: 9678
		{
			// Fields
			internal RendererListHandle objMotionRendererList; // 0x10
			internal RendererListHandle objTransparentMotionRendererList; // 0x1C
			internal Matrix4x4[] previousViewProjectionStereo; // 0x28
			internal Matrix4x4[] viewProjectionStereo; // 0x30
			internal Material xrMotionVector; // 0x38
			internal bool hasValidXRDepth; // 0x40
			internal TextureHandle xrDepthSrc; // 0x44
			internal bool requiresSubsampleDepth; // 0x54
			internal LocalKeyword subsampleDepthKeyword; // 0x58
	
			// Constructors
			public PassData(); // 0x0000000181FC4460-0x0000000181FC44E0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass26_0 // TypeDefIndex: 9679
		{
			// Fields
			public XRDepthMotionPass __4__this; // 0x10
			public PassData passData; // 0x18
	
			// Constructors
			public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__0(PassData data, RasterGraphContext context); // 0x0000000181FD6C40-0x0000000181FD7010
		}
	
		// Constructors
		public XRDepthMotionPass(RenderPassEvent evt, Shader xrMotionVector, LayerMask transparentLayerMask); // 0x0000000181FDA6E0-0x0000000181FDAA80
		static XRDepthMotionPass(); // 0x0000000181FDA620-0x0000000181FDA6E0
	
		// Methods
		private static DrawingSettings GetObjectMotionDrawingSettings(Camera camera, bool isTransparent = false /* Metadata: 0x0069EE82 */); // 0x0000000181FD85B0-0x0000000181FD87F0
		private void InitObjectMotionRendererLists(ref PassData passData, ref CullingResults cullResults, RenderGraph renderGraph, Camera camera, bool forceAllMotionVectorObjects); // 0x0000000181FD8D50-0x0000000181FD9130
		private void InitTransparentObjectMotionRendererLists(ref PassData passData, ref CullingResults cullResults, RenderGraph renderGraph, Camera camera); // 0x0000000181FD9270-0x0000000181FD9620
		private void InitPassData(ref PassData passData, UniversalCameraData cameraData); // 0x0000000181FD9130-0x0000000181FD9270
		private void ImportXRMotionColorAndDepth(RenderGraph renderGraph, UniversalCameraData cameraData); // 0x0000000181FD87F0-0x0000000181FD8D50
		internal void Render(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FD9620-0x0000000181FDA050
		private void ResetMotionData(); // 0x0000000181FDA050-0x0000000181FDA130
		public void Update(ref UniversalCameraData cameraData); // 0x0000000181FDA130-0x0000000181FDA620
		public void Dispose(); // 0x0000000181FD8530-0x0000000181FD85B0
	}
}
