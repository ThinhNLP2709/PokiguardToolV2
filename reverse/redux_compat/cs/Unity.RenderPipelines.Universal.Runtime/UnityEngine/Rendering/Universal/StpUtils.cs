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
	internal static class StpUtils // TypeDefIndex: 9787
	{
		// Fields
		internal static TemporalAA.JitterFunc s_JitterFunc; // 0x00
	
		// Constructors
		static StpUtils(); // 0x0000000181FEAB90-0x0000000181FEACA0
	
		// Methods
		private static void CalculateJitter(int frameIndex, out Vector2 jitter, out bool allowScaling); // 0x0000000181FE9EC0-0x0000000181FE9F50
		private static void PopulateStpConfig(UniversalCameraData cameraData, [IsReadOnly] in TextureHandle inputColor, [IsReadOnly] in TextureHandle inputDepth, [IsReadOnly] in TextureHandle inputMotion, int debugViewIndex, [IsReadOnly] in TextureHandle debugView, [IsReadOnly] in TextureHandle destination, Texture2D noiseTexture, out STP.Config config); // 0x0000000181FEA260-0x0000000181FEAB90
		internal static void Execute(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle inputColor, [IsReadOnly] in TextureHandle inputDepth, [IsReadOnly] in TextureHandle inputMotion, [IsReadOnly] in TextureHandle destination, Texture2D noiseTexture); // 0x0000000181FE9F50-0x0000000181FEA260
	}
}
