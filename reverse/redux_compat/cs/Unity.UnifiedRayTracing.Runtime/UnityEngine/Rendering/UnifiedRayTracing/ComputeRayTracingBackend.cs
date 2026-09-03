/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal class ComputeRayTracingBackend : IRayTracingBackend // TypeDefIndex: 14307
	{
		// Fields
		private readonly RayTracingResources m_Resources; // 0x10
	
		// Constructors
		public ComputeRayTracingBackend(RayTracingResources resources); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IRayTracingShader CreateRayTracingShader(UnityEngine.Object shader, string kernelName, GraphicsBuffer dispatchBuffer); // 0x0000000182124F90-0x00000001821250E0
		public IRayTracingAccelStruct CreateAccelerationStructure(AccelerationStructureOptions options, ReferenceCounter counter); // 0x0000000182124F00-0x0000000182124F90
		public ulong GetRequiredTraceScratchBufferSizeInBytes(uint width, uint height, uint depth); // 0x00000001821250E0-0x0000000182125100
	}
}
