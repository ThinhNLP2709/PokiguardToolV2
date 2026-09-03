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
	internal sealed class PaniniProjectionPostProcessPass : PostProcessPass // TypeDefIndex: 9614
	{
		// Fields
		public const string k_TargetName = "CameraColorPaniniProjection"; // Metadata: 0x0069ED41
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
	
		// Nested types
		private class PaniniProjectionPassData // TypeDefIndex: 9615
		{
			// Fields
			internal Material material; // 0x10
			internal TextureHandle sourceTexture; // 0x18
			internal Vector4 paniniParams; // 0x28
			internal bool isPaniniGeneric; // 0x38
	
			// Constructors
			public PaniniProjectionPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9616
		{
			// Fields
			public static readonly int _Params; // 0x00
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4AE0-0x0000000181FB4B30
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9617
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PaniniProjectionPassData, RasterGraphContext> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEF10-0x0000000181FBEF80
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__6_0(PaniniProjectionPassData data, RasterGraphContext context); // 0x0000000181FBBE60-0x0000000181FBC080
		}
	
		// Constructors
		public PaniniProjectionPostProcessPass(Shader shader); // 0x0000000181FAEE00-0x0000000181FAEEE0
	
		// Methods
		public override void Dispose(); // 0x0000000181FAE500-0x0000000181FAE560
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FAE560-0x0000000181FAEE00
		public static Vector2 CalcViewExtents(float fieldOfView, int width, int height); // 0x0000000181FAE4B0-0x0000000181FAE500
		public static Vector2 CalcCropExtents(float fieldOfView, float d, int width, int height); // 0x0000000181FAE3D0-0x0000000181FAE4B0
	}
}
