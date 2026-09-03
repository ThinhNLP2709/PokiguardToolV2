/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 81: Unity.RenderPipeline.Universal.ShaderLibrary.dll - Assembly: Unity.RenderPipeline.Universal.ShaderLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15934-15952

namespace UnityEngine.Rendering.Universal
{
	public static class ShaderInput // TypeDefIndex: 15950
	{
		// Nested types
		[Obsolete("ShaderInput.ShadowData was deprecated. Shadow slice matrices and per-light shadow parameters are now passed to the GPU using entries in buffers m_AdditionalLightsWorldToShadow_SSBO and m_AdditionalShadowParams_SSBO. #from(2021.1) #breakingFrom(2023.1)", true)]
		public struct ShadowData // TypeDefIndex: 15951
		{
			// Fields
			public Matrix4x4 worldToShadowMatrix; // 0x00
			public Vector4 shadowParams; // 0x40
		}
	
		[GenerateHLSL(PackingRules.Exact, false, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.universal@8e101b78ae7d\\ShaderLibrary\\ShaderTypes.cs")]
		public struct LightData // TypeDefIndex: 15952
		{
			// Fields
			public Vector4 position; // 0x00
			public Vector4 color; // 0x10
			public Vector4 attenuation; // 0x20
			public Vector4 spotDirection; // 0x30
			public Vector4 occlusionProbeChannels; // 0x40
			public uint layerMask; // 0x50
		}
	}
}
