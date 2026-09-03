/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UVFallbackBufferBuilder : IDisposable // TypeDefIndex: 13558
	{
		// Fields
		private static readonly ProfilerMarker k_BuildUVFallbackBuffer; // 0x00
		private GraphicsBuffer _vertexBuffer; // 0x10
		private Material _uvFallbackBufferMaterial; // 0x18
	
		// Constructors
		public UVFallbackBufferBuilder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static UVFallbackBufferBuilder(); // 0x0000000181DFF900-0x0000000181DFF970
	
		// Methods
		public void Dispose(); // 0x0000000181DFF8C0-0x0000000181DFF900
		public void Prepare(Material uvFallbackBufferMaterial); // 0x00000001802FAF70-0x00000001802FAF80
		public void Build(CommandBuffer cmd, RenderTexture uvFallbackRT, int width, int height, float widthScale, float heightScale, Mesh uvMesh); // 0x0000000181DFF510-0x0000000181DFF8C0
	}
}
