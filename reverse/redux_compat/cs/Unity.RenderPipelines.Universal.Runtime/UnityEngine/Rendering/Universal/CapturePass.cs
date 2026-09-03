/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class CapturePass : ScriptableRenderPass // TypeDefIndex: 9552
	{
		// Nested types
		private class UnsafePassData // TypeDefIndex: 9553
		{
			// Fields
			internal TextureHandle source; // 0x10
			public IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> captureActions; // 0x20
	
			// Constructors
			public UnsafePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9554
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F9B1E0-0x0000000181F9B250
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__2_0(UnsafePassData data, UnsafeGraphContext unsafeContext); // 0x0000000181F9A4B0-0x0000000181F9A730
		}
	
		// Constructors
		public CapturePass(RenderPassEvent evt); // 0x0000000181F89FA0-0x0000000181F8A030
	
		// Methods
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F89B50-0x0000000181F89FA0
	}
}
