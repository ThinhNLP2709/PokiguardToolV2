/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	public class RayTracingResources // TypeDefIndex: 14326
	{
		// Fields
		[CompilerGenerated]
		private ComputeShader _geometryPoolKernels_k__BackingField; // 0x10
		[CompilerGenerated]
		private ComputeShader _copyBuffer_k__BackingField; // 0x18
		[CompilerGenerated]
		private ComputeShader _copyPositions_k__BackingField; // 0x20
		[CompilerGenerated]
		private ComputeShader _bitHistogram_k__BackingField; // 0x28
		[CompilerGenerated]
		private ComputeShader _scatter_k__BackingField; // 0x30
		[CompilerGenerated]
		private ComputeShader _blockReducePart_k__BackingField; // 0x38
		[CompilerGenerated]
		private ComputeShader _blockScan_k__BackingField; // 0x40
		[CompilerGenerated]
		private ComputeShader _buildHlbvh_k__BackingField; // 0x48
		[CompilerGenerated]
		private ComputeShader _restructureBvh_k__BackingField; // 0x50
	
		// Properties
		public ComputeShader geometryPoolKernels { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public ComputeShader copyBuffer { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public ComputeShader copyPositions { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public ComputeShader bitHistogram { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public ComputeShader scatter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public ComputeShader blockReducePart { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public ComputeShader blockScan { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public ComputeShader buildHlbvh { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public ComputeShader restructureBvh { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public RayTracingResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void LoadFromAssetBundle(AssetBundle assetBundle); // 0x0000000182127DD0-0x0000000182127FE0
		public bool LoadFromRenderPipelineResources(); // 0x0000000182127FE0-0x0000000182128170
	}
}
