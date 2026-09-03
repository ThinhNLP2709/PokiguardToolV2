/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class VrsResources : IDisposable // TypeDefIndex: 5862
	{
		// Fields
		internal ProfilingSampler conversionProfilingSampler; // 0x10
		internal ProfilingSampler visualizationProfilingSampler; // 0x18
		internal GraphicsBuffer conversionLutBuffer; // 0x20
		internal GraphicsBuffer visualizationLutBuffer; // 0x28
		internal ComputeShader textureComputeShader; // 0x30
		internal int textureReduceKernel; // 0x38
		internal int textureCopyKernel; // 0x3C
		internal Vector2Int tileSize; // 0x40
		internal GraphicsBuffer validatedShadingRateFragmentSizeBuffer; // 0x48
		private Shader m_VisualizationShader; // 0x50
		private Material m_VisualizationMaterial; // 0x58
	
		// Properties
		internal Material visualizationMaterial { get; } // 0x0000000181ED2CE0-0x0000000181ED2D90 
	
		// Constructors
		internal VrsResources(VrsRenderPipelineRuntimeResources resources); // 0x0000000181ED2C00-0x0000000181ED2CE0
	
		// Methods
		public void Dispose(); // 0x0000000181ED26D0-0x0000000181ED26E0
		private void InitializeResources(VrsRenderPipelineRuntimeResources resources); // 0x0000000181ED2950-0x0000000181ED2BB0
		private void DisposeResources(); // 0x0000000181ED25F0-0x0000000181ED26D0
		private void AllocFragmentSizeBuffer(); // 0x0000000181ED2430-0x0000000181ED25F0
		private bool InitComputeShader(VrsRenderPipelineRuntimeResources resources); // 0x0000000181ED26E0-0x0000000181ED2950
		private static int TryFindKernel(ComputeShader computeShader, string name); // 0x0000000181ED2BB0-0x0000000181ED2C00
	}
}
