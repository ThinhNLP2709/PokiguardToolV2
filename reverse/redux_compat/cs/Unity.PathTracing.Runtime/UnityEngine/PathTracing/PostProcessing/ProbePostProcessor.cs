/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.PostProcessing
{
	internal class ProbePostProcessor // TypeDefIndex: 13541
	{
		// Fields
		private ComputeShader _computeShader; // 0x10
		private int _convolveRadianceToIrradianceKernel; // 0x18
		private int _convertToUnityFormatKernel; // 0x1C
		private int _addSphericalHarmonicsL2Kernel; // 0x20
		private int _scaleSphericalHarmonicsL2Kernel; // 0x24
		private int _windowSphericalHarmonicsL2Kernel; // 0x28
	
		// Constructors
		public ProbePostProcessor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Prepare(ComputeShader computeShader); // 0x0000000181DFB260-0x0000000181DFB370
		public void ConvolveRadianceToIrradiance(CommandBuffer cmd, GraphicsBuffer inRadianceBuffer, GraphicsBuffer outIrradianceBuffer, uint inputOffset, uint outputOffset, uint probeCount); // 0x0000000181DFB000-0x0000000181DFB260
		public void ConvertToUnityFormat(CommandBuffer cmd, GraphicsBuffer inIrradianceBuffer, GraphicsBuffer outIrradianceBuffer, uint inputOffset, uint outputOffset, uint probeCount); // 0x0000000181DFADA0-0x0000000181DFB000
		internal void AddSphericalHarmonicsL2(CommandBuffer cmd, GraphicsBuffer inA, GraphicsBuffer inB, GraphicsBuffer outSum, uint inputOffsetA, uint inputOffsetB, uint outputOffset, uint probeCount); // 0x0000000181DFAAC0-0x0000000181DFADA0
		internal void ScaleSphericalHarmonicsL2(CommandBuffer cmd, GraphicsBuffer input, GraphicsBuffer outScaled, uint inputOffset, uint outputOffset, uint probeCount, float scale); // 0x0000000181DFB370-0x0000000181DFB610
		internal void WindowSphericalHarmonicsL2(CommandBuffer cmd, GraphicsBuffer input, GraphicsBuffer outWindowed, uint inputOffset, uint outputOffset, uint probeCount); // 0x0000000181DFB610-0x0000000181DFB870
	}
}
