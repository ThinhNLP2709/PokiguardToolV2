/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class GPUResidentContext : IDisposable // TypeDefIndex: 12921
	{
		// Fields
		private InstanceDataSystem m_InstanceDataSystem; // 0x10
		private LODGroupDataSystem m_LODGroupDataSystem; // 0x18
		private InstanceCuller m_Culler; // 0x20
		private OcclusionCullingCommon m_OcclusionCullingCommon; // 0x28
		private InstanceCullingBatcher m_InstanceCullingBatcher; // 0x30
		private GPUResidentDrawerResources m_Resources; // 0x38
		private DebugRendererBatcherStats m_DebugStats; // 0x40
		public SphericalHarmonicsL2 cachedAmbientProbe; // 0x48
		public readonly float smallMeshScreenPercentage; // 0xB4
		public readonly float4 shadowSmallMeshScreenPercentages; // 0xB8
	
		// Properties
		public InstanceDataSystem instanceDataSystem { get; } // 0x0000000180377550-0x0000000180377560 
		public LODGroupDataSystem lodGroupDataSystem { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public InstanceCuller culler { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal OcclusionCullingCommon occlusionCullingCommon { get; } // 0x000000018033D240-0x000000018033D250 
		public InstanceCullingBatcher batcher { get; } // 0x000000018031E110-0x000000018031E120 
		public GPUResidentDrawerResources resources { get; } // 0x00000001803272A0-0x00000001803272B0 
		internal DebugRendererBatcherStats debugStats { get; } // 0x0000000180377940-0x0000000180377950 
	
		// Constructors
		public GPUResidentContext([IsReadOnly] in GPUResidentDrawerSettings settings, InstanceDataSystem instanceDataSystem, LODGroupDataSystem lodGroupDataSystem, InstanceCuller culler, OcclusionCullingCommon occlusionCullingCommon, InstanceCullingBatcher instanceCullingBatcher, GPUResidentDrawerResources resources); // 0x0000000181F345C0-0x0000000181F347D0
	
		// Methods
		public void Dispose(); // 0x0000000181F34550-0x0000000181F345C0
	}
}
