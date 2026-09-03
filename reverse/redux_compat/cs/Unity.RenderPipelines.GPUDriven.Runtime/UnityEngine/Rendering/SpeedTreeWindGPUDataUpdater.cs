/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class SpeedTreeWindGPUDataUpdater : IDisposable // TypeDefIndex: 12963
	{
		// Fields
		private static readonly ProfilerMarker k_UpdateGPUData; // 0x00
		private static readonly ProfilerMarker k_UpdateSpeedTreeWindAndUploadWindParamsToGPU; // 0x08
		private InstanceDataSystem m_InstanceDataSystem; // 0x10
		private InstanceCuller m_Culler; // 0x18
		private ParallelBitArray m_ProcessedThisFrameTreeBits; // 0x20
		private NativeArray<uint> m_CPUUploadBuffer; // 0x40
		private GraphicsBuffer m_GPUUploadBuffer; // 0x50
	
		// Constructors
		public SpeedTreeWindGPUDataUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static SpeedTreeWindGPUDataUpdater(); // 0x0000000181F52060-0x0000000181F52110
	
		// Methods
		public void Initialize(InstanceDataSystem instanceDataSystem, InstanceCuller culler); // 0x0000000181F515B0-0x0000000181F515F0
		public void Dispose(); // 0x0000000181F51410-0x0000000181F514A0
		public void OnBeginContextRendering(); // 0x0000000181F515F0-0x0000000181F51640
		public void UpdateGPUData(); // 0x0000000181F51640-0x0000000181F51C40
		private void UpdateSpeedTreeWindAndUploadWindParamsToGPU(NativeArray<EntityId> treeRenderers, NativeArray<InstanceHandle> treeInstances, bool history); // 0x0000000181F51C40-0x0000000181F52060
		private void EnsureUploadBufferUintCount(int uintCount); // 0x0000000181F514A0-0x0000000181F515B0
	}
}
