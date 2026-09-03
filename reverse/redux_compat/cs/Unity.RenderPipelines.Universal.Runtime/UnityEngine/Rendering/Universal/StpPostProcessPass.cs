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
	internal sealed class StpPostProcessPass : PostProcessPass // TypeDefIndex: 9633
	{
		// Fields
		public const string k_UpscaledColorTargetName = "CameraColorUpscaledSTP"; // Metadata: 0x0069EDC4
		private Texture2D[] m_BlueNoise16LTex; // 0x68
		private bool m_IsValid; // 0x70
		private uint m_WarnCounter; // 0x74
	
		// Nested types
		public static class ShaderConstants // TypeDefIndex: 9634
		{
		}
	
		// Constructors
		public StpPostProcessPass(Texture2D[] blueNoise16LTex); // 0x0000000181FB7AA0-0x0000000181FB7B20
	
		// Methods
		public override void Dispose(); // 0x0000000181FB73F0-0x0000000181FB7400
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FB75E0-0x0000000181FB7AA0
		public static TextureDesc GetStpTargetDesc([IsReadOnly] in TextureDesc sourceDesc, UniversalCameraData cameraData); // 0x0000000181FB7400-0x0000000181FB75E0
	}
}
