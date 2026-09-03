/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	internal class DeferredPass : ScriptableRenderPass // TypeDefIndex: 9910
	{
		// Fields
		private DeferredLights m_DeferredLights; // 0x60
	
		// Nested types
		private class PassData // TypeDefIndex: 9911
		{
			// Fields
			internal UniversalCameraData cameraData; // 0x10
			internal UniversalLightData lightData; // 0x18
			internal UniversalShadowData shadowData; // 0x20
			internal TextureHandle[] gbuffer; // 0x28
			internal DeferredLights deferredLights; // 0x30
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9912
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041820-0x0000000182041890
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__3_0(PassData data, RasterGraphContext context); // 0x0000000182040240-0x00000001820402A0
		}
	
		// Constructors
		public DeferredPass(RenderPassEvent evt, DeferredLights deferredLights); // 0x00000001820340C0-0x0000000182034170
	
		// Methods
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000182033990-0x00000001820340C0
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000182033970-0x0000000182033990
	}
}
