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
	internal sealed class StopNanPostProcessPass : PostProcessPass // TypeDefIndex: 9629
	{
		// Fields
		public const string k_TargetName = "CameraColorStopNaNs"; // Metadata: 0x0069EDB0
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
	
		// Nested types
		private class StopNaNsPassData // TypeDefIndex: 9630
		{
			// Fields
			internal TextureHandle sourceTexture; // 0x10
			internal Material stopNaN; // 0x20
	
			// Constructors
			public StopNaNsPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9631
		{
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9632
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<StopNaNsPassData, RasterGraphContext> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF1B0-0x0000000181FBF220
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__6_0(StopNaNsPassData data, RasterGraphContext context); // 0x0000000181FBBA30-0x0000000181FBBBB0
		}
	
		// Constructors
		public StopNanPostProcessPass(Shader shader); // 0x0000000181FB7310-0x0000000181FB73F0
	
		// Methods
		public override void Dispose(); // 0x0000000181FB6D60-0x0000000181FB6DC0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB6DC0-0x0000000181FB7310
	}
}
