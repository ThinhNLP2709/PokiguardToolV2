/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PathTracing.Core;
using UnityEngine.PathTracing.Integration;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal class LightmappingContext : IDisposable // TypeDefIndex: 13657
	{
		// Fields
		private UnityComputeDeviceContext _deviceContext; // 0x10
		public UnityComputeWorld World; // 0x18
		public GraphicsBuffer TraceScratchBuffer; // 0x20
		public LightmapIntegratorContext IntegratorContext; // 0x28
		public LightmapIntegrationResourceCache ResourceCache; // 0x30
		public RenderTexture AccumulatedOutput; // 0x38
		public RenderTexture AccumulatedDirectionalOutput; // 0x40
		public GraphicsBuffer ExpandedOutput; // 0x48
		public GraphicsBuffer ExpandedOutputDirectional; // 0x50
		public GraphicsBuffer GBuffer; // 0x58
		public GraphicsBuffer CompactedTexelIndices; // 0x60
		public GraphicsBuffer CompactedGBufferLength; // 0x68
		public GraphicsBuffer IndirectDispatchBuffer; // 0x70
		public GraphicsBuffer IndirectDispatchRayTracingBuffer; // 0x78
		public ChartRasterizer ChartRasterizer; // 0x80
		public ChartRasterizer.Buffers ChartRasterizerBuffers; // 0x88
		private int _width; // 0xA0
		private int _height; // 0xA4
	
		// Properties
		public int Width { get; } // 0x000000018033D1F0-0x000000018033D200 
		public int Height { get; } // 0x000000018033D210-0x000000018033D220 
	
		// Constructors
		public LightmappingContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void ClearOutputs(); // 0x0000000181E10040-0x0000000181E10160
		public static RenderTexture MakeRenderTexture(int width, int height, string name); // 0x0000000181E10D00-0x0000000181E10EA0
		internal bool ExpandedBufferNeedsUpdating(ulong expandedSize); // 0x0000000181E102E0-0x0000000181E10390
		internal bool InitializeExpandedBuffer(ulong expandedSize); // 0x0000000181E10570-0x0000000181E107C0
		internal bool Initialize(UnityComputeDeviceContext deviceContext, int width, int height, UnityComputeWorld world, uint maxIndexCount, uint maxVertexCount, LightmapResourceLibrary resources); // 0x0000000181E108C0-0x0000000181E10D00
		internal bool SetOutputResolution(int width, int height); // 0x0000000181E10F60-0x0000000181E11190
		public void InitializeTraceScratchBuffer(uint width, uint height, uint expandedSampleWidth); // 0x0000000181E107C0-0x0000000181E108C0
		private void InitializeChartRasterizationBuffers(uint maxIndexCount, uint maxVertexCount); // 0x0000000181E103B0-0x0000000181E10570
		public CommandBuffer GetCommandBuffer(); // 0x0000000181E10390-0x0000000181E103B0
		public void Dispose(); // 0x0000000181E10160-0x0000000181E102E0
		private static void ReleaseAndDestroy(ref RenderTexture tex); // 0x0000000181E10EA0-0x0000000181E10F60
	}
}
