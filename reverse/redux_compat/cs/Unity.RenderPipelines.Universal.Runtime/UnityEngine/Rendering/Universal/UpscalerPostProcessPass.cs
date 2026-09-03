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
	internal sealed class UpscalerPostProcessPass : PostProcessPass // TypeDefIndex: 9649
	{
		// Fields
		public const string k_UpscaledColorTargetName = "CameraColorUpscaled"; // Metadata: 0x0069EE17
		private Texture2D[] m_BlueNoise16LTex; // 0x68
		private bool m_IsValid; // 0x70
	
		// Nested types
		private class UpdateCameraResolutionPassData // TypeDefIndex: 9650
		{
			// Fields
			internal Vector2Int newCameraTargetSize; // 0x10
	
			// Constructors
			public UpdateCameraResolutionPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9651
		{
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9652
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<UpdateCameraResolutionPassData, UnsafeGraphContext> __9__7_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEE30-0x0000000181FBEEA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _UpdateCameraResolution_b__7_0(UpdateCameraResolutionPassData data, UnsafeGraphContext ctx); // 0x0000000181FBE9D0-0x0000000181FBEAB0
		}
	
		// Constructors
		public UpscalerPostProcessPass(Texture2D[] blueNoise16LTex); // 0x0000000181FC10C0-0x0000000181FC1120
	
		// Methods
		public override void Dispose(); // 0x0000000181FB73F0-0x0000000181FB7400
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void UpdateCameraResolution(RenderGraph renderGraph, UniversalCameraData cameraData, Vector2Int newCameraTargetSize); // 0x0000000181FC0DD0-0x0000000181FC10C0
	}
}
