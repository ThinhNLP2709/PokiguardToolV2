/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class EnvironmentImportanceSampling : IDisposable // TypeDefIndex: 13575
	{
		// Fields
		private readonly ComputeShader _shader; // 0x10
		private readonly int _computeConditionalKernel; // 0x18
		private readonly int _computeMarginalKernel; // 0x1C
		private readonly EnvironmentCDF _environmentCDF; // 0x20
	
		// Constructors
		public EnvironmentImportanceSampling(ComputeShader shader); // 0x0000000181DEDC90-0x0000000181DEDE10
	
		// Methods
		public void ComputeCDFBuffers(CommandBuffer cmd, Texture cubemap); // 0x0000000181DEDA20-0x0000000181DEDC30
		internal EnvironmentCDF GetSkyboxCDF(); // 0x0000000181DEDC70-0x0000000181DEDC90
		public void Dispose(); // 0x0000000181DEDC30-0x0000000181DEDC70
	}
}
