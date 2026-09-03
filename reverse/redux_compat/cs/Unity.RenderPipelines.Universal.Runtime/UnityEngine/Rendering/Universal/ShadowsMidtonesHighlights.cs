/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	[VolumeComponentMenu("Post-processing/Shadows, Midtones, Highlights")]
	public sealed class ShadowsMidtonesHighlights : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9537
	{
		// Fields
		public Vector4Parameter shadows; // 0x38
		public Vector4Parameter midtones; // 0x40
		public Vector4Parameter highlights; // 0x48
		[Header("Shadow Limits")]
		[Tooltip("Start point of the transition between shadows and midtones.")]
		public MinFloatParameter shadowsStart; // 0x50
		[Tooltip("End point of the transition between shadows and midtones.")]
		public MinFloatParameter shadowsEnd; // 0x58
		[Header("Highlight Limits")]
		[Tooltip("Start point of the transition between midtones and highlights.")]
		public MinFloatParameter highlightsStart; // 0x60
		[Tooltip("End point of the transition between midtones and highlights.")]
		public MinFloatParameter highlightsEnd; // 0x68
	
		// Constructors
		public ShadowsMidtonesHighlights(); // 0x0000000181F98310-0x0000000181F98510
	
		// Methods
		public bool IsActive(); // 0x0000000181F98260-0x0000000181F98310
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
