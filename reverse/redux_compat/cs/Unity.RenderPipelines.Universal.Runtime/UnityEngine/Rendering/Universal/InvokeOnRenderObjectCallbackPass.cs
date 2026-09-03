/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class InvokeOnRenderObjectCallbackPass : ScriptableRenderPass // TypeDefIndex: 9570
	{
		// Nested types
		private class PassData // TypeDefIndex: 9571
		{
			// Fields
			internal TextureHandle colorTarget; // 0x10
			internal TextureHandle depthTarget; // 0x20
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9572
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, UnsafeGraphContext> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEEA0-0x0000000181FBEF10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__2_0(PassData data, UnsafeGraphContext context); // 0x0000000181FBE600-0x0000000181FBE760
		}
	
		// Constructors
		public InvokeOnRenderObjectCallbackPass(RenderPassEvent evt); // 0x0000000181FA93B0-0x0000000181FA9440
	
		// Methods
		internal void Render(RenderGraph renderGraph, [IsReadOnly] in TextureHandle colorTarget, [IsReadOnly] in TextureHandle depthTarget); // 0x0000000181FA9050-0x0000000181FA93B0
	}
}
