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
	public static class RayTracingHelper // TypeDefIndex: 14324
	{
		// Fields
		public const GraphicsBuffer.Target ScratchBufferTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A963D
	
		// Methods
		public static GraphicsBuffer CreateDispatchIndirectBuffer(); // 0x0000000182127350-0x00000001821273B0
		public static GraphicsBuffer CreateScratchBufferForBuildAndDispatch(IRayTracingAccelStruct accelStruct, IRayTracingShader shader, uint dispatchWidth, uint dispatchHeight, uint dispatchDepth); // 0x0000000182127510-0x0000000182127640
		public static GraphicsBuffer CreateScratchBufferForBuildAndDispatch(IRayTracingAccelStruct accelStruct, RayTracingContext context, uint dispatchWidth, uint dispatchHeight, uint dispatchDepth); // 0x00000001821273B0-0x0000000182127510
		public static GraphicsBuffer CreateScratchBufferForBuild(IRayTracingAccelStruct accelStruct); // 0x0000000182127640-0x00000001821276F0
		public static GraphicsBuffer CreateScratchBufferForTrace(IRayTracingShader shader, uint dispatchWidth, uint dispatchHeight, uint dispatchDepth); // 0x00000001821276F0-0x00000001821277C0
		public static void ResizeScratchBufferForTrace(IRayTracingShader shader, uint dispatchWidth, uint dispatchHeight, uint dispatchDepth, ref GraphicsBuffer scratchBuffer); // 0x00000001821278C0-0x00000001821279E0
		public static void ResizeScratchBufferForBuild(IRayTracingAccelStruct accelStruct, ref GraphicsBuffer scratchBuffer); // 0x00000001821277C0-0x00000001821278C0
	}
}
