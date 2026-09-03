/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PathTracing.Core;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class GBufferDebug : IDisposable // TypeDefIndex: 13551
	{
		// Fields
		private IRayTracingShader _accumulationShader; // 0x10
		private GraphicsBuffer _accumulationDispatchBuffer; // 0x18
		private ComputeShader _expansionHelpers; // 0x20
		private int _populateAccumulationDispatchKernel; // 0x28
	
		// Constructors
		public GBufferDebug(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181DEE130-0x0000000181DEE150
		public void SetTerrainKeyword(CommandBuffer cmd, bool hasTerrains); // 0x0000000181DEE1F0-0x0000000181DEE210
		public void Prepare(IRayTracingShader accumulationShader, ComputeShader expansionHelpers); // 0x0000000181DEE150-0x0000000181DEE1F0
		public void Accumulate(CommandBuffer cmd, Matrix4x4 shaderLocalToWorld, Matrix4x4 shaderLocalToWorldNormals, int instanceGeometryIndex, int terrainIndex, World world, GraphicsBuffer gBuffer, uint expandedSampleWidth, GraphicsBuffer lightmapSamplesExpanded, GraphicsBuffer compactedGbufferLength); // 0x0000000181DEDE10-0x0000000181DEE130
	}
}
