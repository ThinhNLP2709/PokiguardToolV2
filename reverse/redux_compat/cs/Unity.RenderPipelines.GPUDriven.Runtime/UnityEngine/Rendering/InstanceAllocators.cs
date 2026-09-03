/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct InstanceAllocators // TypeDefIndex: 12786
	{
		// Fields
		private NativeHandleAllocator m_InstanceCPUHandleAllocator; // 0x00
		private NativeArray<NativeHandleAllocator> m_InstanceGPUHandleAllocators; // 0x48
	
		// Methods
		public void Initialize(); // 0x0000000181F0C3A0-0x0000000181F0C440
		public void Dispose(); // 0x0000000181F0C0E0-0x0000000181F0C160
		private ref NativeHandleAllocator GetInstanceGPUHandleAllocator(GPUArchetypeHandle archetype); // 0x0000000181F0C2E0-0x0000000181F0C340
		public int TrimGPUAllocatorLength(GPUArchetypeHandle archetype); // 0x0000000181F0C440-0x0000000181F0C4B0
		public int GetInstanceGPUHandlesAllocatedCount(GPUArchetypeHandle archetype); // 0x0000000181F0C340-0x0000000181F0C3A0
		public InstanceHandle AllocateInstance(); // 0x0000000181F0C050-0x0000000181F0C0E0
		public InstanceGPUHandle AllocateInstanceGPUHandle(GPUArchetypeHandle archetype); // 0x0000000181F0BF80-0x0000000181F0C050
		public void FreeInstance(InstanceHandle instance); // 0x0000000181F0C280-0x0000000181F0C2E0
		public void FreeInstanceGPUHandle(InstanceGPUHandle gpuHandle); // 0x0000000181F0C160-0x0000000181F0C280
	}
}
