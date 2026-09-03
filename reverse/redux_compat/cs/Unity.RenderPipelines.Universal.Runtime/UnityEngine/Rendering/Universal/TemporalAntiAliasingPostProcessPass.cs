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
	internal sealed class TemporalAntiAliasingPostProcessPass : PostProcessPass // TypeDefIndex: 9635
	{
		// Fields
		public const string k_TargetName = "CameraColorTemporalAA"; // Metadata: 0x0069EDDB
		private Material m_Material; // 0x68
		private bool m_IsValid; // 0x70
		private uint m_WarnCounter; // 0x74
	
		// Nested types
		public static class ShaderConstants // TypeDefIndex: 9636
		{
		}
	
		// Constructors
		public TemporalAntiAliasingPostProcessPass(Shader shader); // 0x0000000181FB7DD0-0x0000000181FB7E80
	
		// Methods
		public override void Dispose(); // 0x0000000181FB7B20-0x0000000181FB7B80
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB7B80-0x0000000181FB7DD0
	}
}
