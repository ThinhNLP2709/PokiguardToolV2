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
	internal class ClearTargetsPass // TypeDefIndex: 9873
	{
		// Fields
		private static readonly ProfilingSampler s_ClearProfilingSampler; // 0x00
	
		// Nested types
		private class PassData // TypeDefIndex: 9874
		{
			// Fields
			internal TextureHandle color; // 0x10
			internal TextureHandle depth; // 0x20
			internal RTClearFlags clearFlags; // 0x30
			internal Color clearColor; // 0x34
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9875
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182030990-0x0000000182030A00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__3_0(PassData data, RasterGraphContext context); // 0x0000000182030530-0x0000000182030580
		}
	
		// Constructors
		public ClearTargetsPass(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static ClearTargetsPass(); // 0x00000001820207A0-0x0000000182020830
	
		// Methods
		internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, UniversalCameraData cameraData); // 0x00000001820206A0-0x00000001820207A0
		internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, RTClearFlags clearFlags, Color clearColor); // 0x0000000182020180-0x00000001820206A0
	}
}
