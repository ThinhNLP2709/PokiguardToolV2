/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class XROcclusionMeshPass : ScriptableRenderPass // TypeDefIndex: 9680
	{
		// Nested types
		private class PassData // TypeDefIndex: 9681
		{
			// Fields
			internal XRPass xr; // 0x10
			internal bool isActiveTargetBackBuffer; // 0x18
			internal bool shouldYFlip; // 0x19
			internal TextureHandle cameraColorAttachment; // 0x1C
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 9682
		{
			// Fields
			public PassData passData; // 0x10
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__0(PassData data, RasterGraphContext context); // 0x0000000181FD7010-0x0000000181FD7110
		}
	
		// Constructors
		public XROcclusionMeshPass(RenderPassEvent evt); // 0x0000000181FDB0E0-0x0000000181FDB170
	
		// Methods
		private static void ExecutePass(RasterCommandBuffer cmd, PassData data); // 0x0000000181FDAA80-0x0000000181FDAB10
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle cameraColorAttachment, [IsReadOnly] in TextureHandle cameraDepthAttachment); // 0x0000000181FDAB10-0x0000000181FDB0E0
	}
}
