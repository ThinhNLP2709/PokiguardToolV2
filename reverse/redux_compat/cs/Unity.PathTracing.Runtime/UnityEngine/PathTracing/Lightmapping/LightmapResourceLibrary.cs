/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class LightmapResourceLibrary // TypeDefIndex: 13630
	{
		// Fields
		internal IRayTracingShader GBufferShader; // 0x10
		internal ComputeShader NormalizationShader; // 0x18
		internal IRayTracingShader DirectStochasticLightShader; // 0x20
		internal IRayTracingShader DirectBRDFAccumulationShader; // 0x28
		internal IRayTracingShader DirectDirectionalAndEnvironmentShader; // 0x30
		internal IRayTracingShader AOAccumulationShader; // 0x38
		internal IRayTracingShader ValidityAccumulationShader; // 0x40
		internal IRayTracingShader IndirectAccumulationShader; // 0x48
		internal IRayTracingShader ShadowMaskAccumulationShader; // 0x50
		internal IRayTracingShader NormalAccumulationShader; // 0x58
		internal IRayTracingShader GBufferDebugShader; // 0x60
		internal Material UVFallbackBufferGenerationMaterial; // 0x68
		internal ComputeShader OccupancyShader; // 0x70
		internal LightmapIntegrationHelpers.ComputeHelpers ComputeHelpers; // 0x78
		internal ComputeShader BoxFilterShader; // 0x80
		internal ComputeShader SelectGraphicsBufferShader; // 0x88
		internal ComputeShader CopyTextureAdditiveShader; // 0x90
		internal ComputeShader ExpansionHelpers; // 0x98
		internal Shader SoftwareChartRasterizationShader; // 0xA0
		internal Shader HardwareChartRasterizationShader; // 0xA8
	
		// Constructors
		public LightmapResourceLibrary(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
