/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class RenderGraphUtils // TypeDefIndex: 9870
	{
		// Fields
		private static readonly ProfilingSampler s_SetGlobalTextureProfilingSampler; // 0x00
		internal const int GBufferSize = 7; // Metadata: 0x0069FC8D
		internal const int DBufferSize = 3; // Metadata: 0x0069FC8E
		internal const int LightTextureSize = 4; // Metadata: 0x0069FC8F
	
		// Nested types
		private class PassData // TypeDefIndex: 9871
		{
			// Fields
			internal TextureHandle texture; // 0x10
			internal int nameID; // 0x20
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9872
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820308B0-0x0000000182030920
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SetGlobalTexture_b__6_0(PassData data, RasterGraphContext context); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		static RenderGraphUtils(); // 0x000000018202FA20-0x000000018202FAB0
	
		// Methods
		internal static void UseDBufferIfValid(IRasterRenderGraphBuilder builder, UniversalResourceData resourceData); // 0x000000018202F880-0x000000018202FA20
		public static void SetGlobalTexture(RenderGraph graph, int nameId, TextureHandle handle, string passName = "Set Global Texture" /* Metadata: 0x0069FC78 */, [CallerFilePath] string file = "" /* Metadata: 0x0069FC8B */, [CallerLineNumber] int line = 0 /* Metadata: 0x0069FC8C */); // 0x000000018202F510-0x000000018202F880
	}
}
