/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class ConservativeLightGrid : IManyLightSampling // TypeDefIndex: 13584
	{
		// Fields
		public int LightGridCellCount; // 0x10
		public int MaxLightsPerCell; // 0x14
		public GridSizingStrategy LightGridSizingStrategy; // 0x18
		public GridMemLayout GridMemLayout; // 0x1C
		private readonly ComputeShader _shader; // 0x20
		private readonly int _buildLightGridlKernel; // 0x28
		private ComputeBuffer _lightGridCellsDataBuffer; // 0x30
		private ComputeBuffer _lightGridBuffer; // 0x38
		private ComputeBuffer _totalLightsInGridCountBuffer; // 0x40
		private Bounds _sceneBounds; // 0x48
		private Vector4 _cellSize; // 0x60
		private Vector4 _invCellSize; // 0x70
		private Vector3Int _lightGridDims; // 0x80
		private int _maxLightsInAnyCell; // 0x8C
	
		// Properties
		public int MaxLightsInAnyCell { get; } // 0x000000018033D640-0x000000018033D650 
	
		// Constructors
		public ConservativeLightGrid(ComputeShader shader); // 0x0000000181DEBCD0-0x0000000181DEBD60
	
		// Methods
		public void Init(); // 0x0000000181DEBB10-0x0000000181DEBCD0
		protected void BindComputeResources(CommandBuffer cmd, World.LightState lightState, Bounds sceneBounds, SamplingResources samplingResources); // 0x0000000181DEAAA0-0x0000000181DEAE60
		public void Build(CommandBuffer cmd, World.LightState lightState, Bounds sceneBounds, SamplingResources samplingResources); // 0x0000000181DEB430-0x0000000181DEB970
		public void Bind(CommandBuffer cmd, IRayTracingShader shader); // 0x0000000181DEAE60-0x0000000181DEB430
		public void Dispose(); // 0x0000000181DEBAC0-0x0000000181DEBB10
		private void DispatchBuild(CommandBuffer cmd, int buildPass); // 0x0000000181DEB970-0x0000000181DEBAC0
	}
}
