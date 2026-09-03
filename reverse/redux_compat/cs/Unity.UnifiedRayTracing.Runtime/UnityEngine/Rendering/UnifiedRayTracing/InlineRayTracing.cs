/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal static class InlineRayTracing // TypeDefIndex: 14317
	{
		// Methods
		public static void SetTraceScratchBuffer(CommandBuffer cmd, ComputeShader shader, int kernelIndex, GraphicsBuffer traceScratchBuffer); // 0x0000000182126B10-0x0000000182126BC0
		public static void SetAccelerationStructure(CommandBuffer cmd, ComputeShader shader, int kernelIndex, string name, IRayTracingAccelStruct accelStruct); // 0x0000000182126900-0x0000000182126A30
		public static void SetKeywords(CommandBuffer cmd, ComputeShader computeShader, BackendShaderKeywords shaderKeywords, RayTracingBackend backend); // 0x0000000182126A30-0x0000000182126AB0
		public static void SetKeywords(ComputeShader computeShader, BackendShaderKeywords shaderKeywords, RayTracingBackend backend); // 0x0000000182126AB0-0x0000000182126B10
	}
}
