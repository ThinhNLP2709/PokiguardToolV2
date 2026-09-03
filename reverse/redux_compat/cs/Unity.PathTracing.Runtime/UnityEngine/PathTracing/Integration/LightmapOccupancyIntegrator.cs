/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class LightmapOccupancyIntegrator // TypeDefIndex: 13544
	{
		// Fields
		private ComputeShader _occupancyShader; // 0x10
		private int _occupancyKernel; // 0x18
	
		// Constructors
		public LightmapOccupancyIntegrator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Prepare(ComputeShader occupancyShader); // 0x0000000181DF30B0-0x0000000181DF3120
		public void Accumulate(CommandBuffer cmd, Vector2Int instanceTexelSize, Vector2Int instanceTexelOffset, UVFallbackBuffer uvFallbackBuffer, RenderTexture output); // 0x0000000181DF2D30-0x0000000181DF30B0
	}
}
