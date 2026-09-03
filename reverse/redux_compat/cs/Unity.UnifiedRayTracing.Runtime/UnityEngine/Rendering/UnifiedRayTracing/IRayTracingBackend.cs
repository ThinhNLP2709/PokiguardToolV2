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
	internal interface IRayTracingBackend // TypeDefIndex: 14315
	{
		// Methods
		IRayTracingShader CreateRayTracingShader(UnityEngine.Object shader, string kernelName, GraphicsBuffer dispatchBuffer);
		IRayTracingAccelStruct CreateAccelerationStructure(AccelerationStructureOptions options, ReferenceCounter counter);
		ulong GetRequiredTraceScratchBufferSizeInBytes(uint width, uint height, uint depth);
	}
}
