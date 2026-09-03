/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UVFallbackBuffer : IDisposable // TypeDefIndex: 13559
	{
		// Fields
		public RenderTexture UVFallbackRT; // 0x10
		public float WidthScale; // 0x18
		public float HeightScale; // 0x1C
	
		// Properties
		public int Width { get; } // 0x0000000181738F00-0x0000000181738F30 
		public int Height { get; } // 0x0000000181770170-0x00000001817701A0 
	
		// Constructors
		public UVFallbackBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181E001F0-0x0000000181E002A0
		public bool Build(CommandBuffer commandBuffer, UVFallbackBufferBuilder builder, int width, int height, UVMesh uvMesh); // 0x0000000181DFFFD0-0x0000000181E001F0
		public void Bind(CommandBuffer cmd, IRayTracingShader shader, Vector2Int instanceOffset); // 0x0000000181DFFCD0-0x0000000181DFFFD0
		public void BindChunked(CommandBuffer cmd, IRayTracingShader shader, Vector2Int instanceOffset, uint2 chunkOffset, uint chunkSize); // 0x0000000181DFF970-0x0000000181DFFAB0
		public void Bind(CommandBuffer cmd, ComputeShader shader, int kernelIndex, Vector2Int instanceOffset); // 0x0000000181DFFAB0-0x0000000181DFFCD0
	}
}
