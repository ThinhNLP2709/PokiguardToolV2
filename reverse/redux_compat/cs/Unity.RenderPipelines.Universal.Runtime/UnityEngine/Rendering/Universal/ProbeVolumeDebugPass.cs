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
	internal class ProbeVolumeDebugPass : ScriptableRenderPass // TypeDefIndex: 9653
	{
		// Fields
		private ComputeShader m_ComputeShader; // 0x60
	
		// Nested types
		private class WriteApvData // TypeDefIndex: 9654
		{
			// Fields
			public ComputeShader computeShader; // 0x10
			public BufferHandle resultBuffer; // 0x18
			public Vector2 clickCoordinates; // 0x24
			public TextureHandle depthBuffer; // 0x2C
			public TextureHandle normalBuffer; // 0x3C
	
			// Constructors
			public WriteApvData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9655
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<WriteApvData, ComputeGraphContext> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF0D0-0x0000000181FBF140
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__3_0(WriteApvData data, ComputeGraphContext ctx); // 0x0000000181FBE760-0x0000000181FBE9A0
		}
	
		// Constructors
		public ProbeVolumeDebugPass(RenderPassEvent evt, ComputeShader computeShader); // 0x0000000181FAF540-0x0000000181FAF5F0
	
		// Methods
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle depthPyramidBuffer, [IsReadOnly] in TextureHandle normalBuffer); // 0x0000000181FAEF60-0x0000000181FAF540
	}
}
