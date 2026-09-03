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
	internal class AAOPass : ScriptableRenderPass, IDisposable // TypeDefIndex: 9659
	{
		// Fields
		private readonly bool m_SupportsR8RenderTextureFormat; // 0x60
		private int m_BlueNoiseTextureIndex; // 0x64
		private Material m_Material; // 0x68
		private Texture2D[] m_BlueNoiseTextures; // 0x70
		private SSAOUtils.CameraViewData m_CameraViewData; // 0x78
		private SSAOUtils.BlurTypes m_BlurType; // 0xA0
		private ProfilingSampler m_ProfilingSampler; // 0xA8
		private ScreenSpaceAmbientOcclusionSettings m_CurrentSettings; // 0xB0
		private SSAOUtils.SSAOMaterialParams m_SSAOParamsPrev; // 0xB8
	
		// Constructors
		internal AAOPass(Shader shader, Texture2D[] blueNoiseTextures); // 0x0000000181FA1FD0-0x0000000181FA2140
	
		// Methods
		internal bool Setup(ScreenSpaceAmbientOcclusionSettings featureSettings, ScreenSpaceAmbientOcclusionSettings.DepthSource depthSource); // 0x0000000181FA1ED0-0x0000000181FA1FD0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA1A80-0x0000000181FA1ED0
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000181FA19A0-0x0000000181FA1A80
		public void Dispose(); // 0x0000000181FA1910-0x0000000181FA19A0
	}
}
