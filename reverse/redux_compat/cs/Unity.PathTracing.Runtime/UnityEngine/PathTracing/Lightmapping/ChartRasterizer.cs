/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class ChartRasterizer : IDisposable // TypeDefIndex: 13652
	{
		// Fields
		private readonly Material _softwareRasterizationMaterial; // 0x10
		private readonly Material _hardwareRasterizationMaterial; // 0x18
	
		// Nested types
		public struct Buffers // TypeDefIndex: 13653
		{
			// Fields
			public GraphicsBuffer vertex; // 0x00
			public GraphicsBuffer vertexToOriginalVertex; // 0x08
			public GraphicsBuffer vertexToChartID; // 0x10
		}
	
		private static class ShaderProperties // TypeDefIndex: 13654
		{
			// Fields
			public static readonly int VertexBuffer; // 0x00
			public static readonly int VertexToOriginalVertex; // 0x04
			public static readonly int VertexToChartID; // 0x08
			public static readonly int ScaleAndOffset; // 0x0C
			public static readonly int ChartIndexOffset; // 0x10
			public static readonly int Width; // 0x14
			public static readonly int Height; // 0x18
	
			// Constructors
			static ShaderProperties(); // 0x0000000181E134B0-0x0000000181E13610
		}
	
		// Constructors
		public ChartRasterizer(Shader softwareRasterizationShader, Shader hardwareRasterizationShader); // 0x0000000181E06A30-0x0000000181E06AF0
	
		// Methods
		public void Dispose(); // 0x0000000181E063C0-0x0000000181E06430
		private static Vector2[] SelectUVBuffer(Mesh from); // 0x0000000181E069F0-0x0000000181E06A30
		public static void PrepareRasterizeSoftware(CommandBuffer cmd, Mesh from, GraphicsBuffer vertexBuffer, GraphicsBuffer vertexToOriginalVertexBuffer); // 0x0000000181E06430-0x0000000181E065B0
		public void RasterizeSoftware(CommandBuffer cmd, GraphicsBuffer vertexBuffer, GraphicsBuffer vertexToOriginalVertexBuffer, GraphicsBuffer vertexToChartIdBuffer, uint indexCount, Vector4 scaleAndOffset, uint chartIndexOffset, RenderTexture destination); // 0x0000000181E06790-0x0000000181E069F0
		public void RasterizeHardware(CommandBuffer cmd, Mesh mesh, GraphicsBuffer vertexToChartIdBuffer, Vector4 scaleAndOffset, uint chartIndexOffset, RenderTexture destination); // 0x0000000181E065B0-0x0000000181E06790
	}
}
