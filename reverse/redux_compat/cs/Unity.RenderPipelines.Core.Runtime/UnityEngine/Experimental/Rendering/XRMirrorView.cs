/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	internal static class XRMirrorView // TypeDefIndex: 5312
	{
		// Fields
		private static readonly MaterialPropertyBlock s_MirrorViewMaterialProperty; // 0x00
		private static readonly ProfilingSampler k_MirrorViewProfilingSampler; // 0x08
		private static readonly int k_SourceTex; // 0x10
		private static readonly int k_SourceTexArraySlice; // 0x14
		private static readonly int k_ScaleBias; // 0x18
		private static readonly int k_ScaleBiasRt; // 0x1C
		private static readonly int k_SRGBRead; // 0x20
		private static readonly int k_SRGBWrite; // 0x24
		private static readonly int k_MaxNits; // 0x28
		private static readonly int k_SourceMaxNits; // 0x2C
		private static readonly int k_SourceHDREncoding; // 0x30
		private static readonly int k_ColorTransform; // 0x34
	
		// Constructors
		static XRMirrorView(); // 0x0000000181E2CA70-0x0000000181E2CD00
	
		// Methods
		internal static void RenderMirrorView(CommandBuffer cmd, Camera camera, Material mat, XRDisplaySubsystem display); // 0x0000000181E2BA00-0x0000000181E2CA70
	}
}
