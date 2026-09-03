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
	internal class RegirLightGrid : IManyLightSampling // TypeDefIndex: 13585
	{
		// Fields
		public int LightGridCellCount; // 0x10
		public int MaxLightsPerCell; // 0x14
		public int NumCandidates; // 0x18
		public GridSizingStrategy LightGridSizingStrategy; // 0x1C
		private readonly ComputeShader _shader; // 0x20
		private readonly int _buildRegirLightGridlKernel; // 0x28
		private ComputeBuffer _lightGridCellsDataBuffer; // 0x30
		private ComputeBuffer _lightGridBuffer; // 0x38
		private Bounds _sceneBounds; // 0x40
		private Vector4 _cellSize; // 0x58
		private Vector4 _invCellSize; // 0x68
		private Vector3Int _lightGridDims; // 0x78
		private int _maxLightsInAnyCell; // 0x84
	
		// Properties
		public int MaxLightsInAnyCell { get; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 
	
		// Constructors
		public RegirLightGrid(ComputeShader shader); // 0x0000000181DFC790-0x0000000181DFC820
	
		// Methods
		public void Init(); // 0x0000000181DFC620-0x0000000181DFC790
		public void Build(CommandBuffer cmd, World.LightState lightState, Bounds sceneBounds, SamplingResources samplingResources); // 0x0000000181DFBE40-0x0000000181DFC5E0
		public void Bind(CommandBuffer cmd, IRayTracingShader shader); // 0x0000000181DFB870-0x0000000181DFBE40
		public void Dispose(); // 0x0000000181DFC5E0-0x0000000181DFC620
	}
}
