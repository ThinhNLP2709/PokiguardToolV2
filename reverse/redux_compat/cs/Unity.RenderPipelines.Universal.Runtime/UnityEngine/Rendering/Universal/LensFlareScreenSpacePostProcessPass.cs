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
	internal sealed class LensFlareScreenSpacePostProcessPass : PostProcessPass // TypeDefIndex: 9606
	{
		// Fields
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private int m_ColorBufferWidth; // 0x74
		private int m_ColorBufferHeight; // 0x78
		private int m_FlareSourceBloomMipIndex; // 0x7C
	
		// Nested types
		private class LensFlareScreenSpacePassData // TypeDefIndex: 9607
		{
			// Fields
			internal Material material; // 0x10
			internal ScreenSpaceLensFlare lensFlareScreenSpace; // 0x18
			internal Camera camera; // 0x20
			internal TextureHandle streakTmpTexture; // 0x28
			internal TextureHandle streakTmpTexture2; // 0x38
			internal TextureHandle flareResultTmp; // 0x48
			internal TextureHandle flareDestinationBloomTexture; // 0x58
			internal TextureHandle flareSourceBloomMipTexture; // 0x68
			internal int actualColorWidth; // 0x78
			internal int actualColorHeight; // 0x7C
			internal int downsample; // 0x80
	
			// Constructors
			public LensFlareScreenSpacePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9608
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<LensFlareScreenSpacePassData, UnsafeGraphContext> __9__9_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBF290-0x0000000181FBF300
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__9_0(LensFlareScreenSpacePassData data, UnsafeGraphContext context); // 0x0000000181FBC5B0-0x0000000181FBCBB0
		}
	
		// Constructors
		public LensFlareScreenSpacePostProcessPass(Shader shader); // 0x0000000181FAB790-0x0000000181FAB880
	
		// Methods
		public override void Dispose(); // 0x0000000181FAA830-0x0000000181FAA890
		public void Setup(int colorBufferWidth, int colorBufferHeight, int flareSourceBloomMipIndex); // 0x0000000181FAB780-0x0000000181FAB790
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FAA930-0x0000000181FAB780
		internal static bool IsActive(VolumeStack volumeStack, ContextContainer frameData); // 0x0000000181FAA890-0x0000000181FAA930
	}
}
