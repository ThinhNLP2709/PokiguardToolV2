/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal static class SerializationHelpers // TypeDefIndex: 13658
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 13659
		{
			// Fields
			public Texture2D readableTex; // 0x10
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _WriteRenderTexture_b__0(AsyncGPUReadbackRequest request); // 0x0000000181E1C200-0x0000000181E1C2A0
		}
	
		// Methods
		private static void ReadbackTexture(Texture2D texture, AsyncGPUReadbackRequest request); // 0x0000000181E1BC60-0x0000000181E1BD00
		internal static void WriteRenderTexture(CommandBuffer cmd, RenderTargetIdentifier renderTex, TextureFormat textureFormat, int width, int height, string path); // 0x0000000181E1BD00-0x0000000181E1C100
		internal static void WriteRenderTexture(CommandBuffer cmd, string path, RenderTexture renderTex); // 0x0000000181E1C100-0x0000000181E1C200
	
		// Extension methods
		internal static byte[] EncodeToR2D(this Texture2D tex); // 0x0000000181E1BAD0-0x0000000181E1BC60
	}
}
