/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UVAccelerationStructure : IDisposable // TypeDefIndex: 13556
	{
		// Fields
		internal IRayTracingAccelStruct _uvAS; // 0x10
		private GraphicsBuffer _buildScratchBuffer; // 0x18
	
		// Constructors
		public UVAccelerationStructure(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181DFF1E0-0x0000000181DFF260
		public void Build(CommandBuffer commandBuffer, RayTracingContext rayTracingContext, UVMesh uvMesh, BuildFlags buildFlags); // 0x0000000181DFEEC0-0x0000000181DFF1E0
	}
}
