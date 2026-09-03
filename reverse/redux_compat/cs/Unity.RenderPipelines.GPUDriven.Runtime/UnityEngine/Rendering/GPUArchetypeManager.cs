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
	internal struct GPUArchetypeManager : IDisposable // TypeDefIndex: 12760
	{
		// Fields
		public const int kMaxComponentsCount = 64; // Metadata: 0x006A758B
		public const int kGPUArchetypeBits = 6; // Metadata: 0x006A758D
		public const int kMaxGPUArchetypesCount = 64; // Metadata: 0x006A758E
		public const int kGPUArchetypeBitsMask = 63; // Metadata: 0x006A7590
		private NativeHandleAllocator m_ComponentHandleAllocator; // 0x00
		private NativeHandleAllocator m_ArchetypeHandleAllocator; // 0x48
		private NativeList<GPUComponentDesc> m_Components; // 0x90
		private NativeList<GPUArchetypeDesc> m_Archetypes; // 0x98
		private NativeParallelHashMap<int, GPUComponentHandle> m_ComponentHash; // 0xA0
		private NativeParallelHashMap<GPUComponentSet, GPUArchetypeHandle> m_ArchetypeHash; // 0xB0
		private NativeParallelHashMap<GPUArchetypeHandle, GPUComponentSet> m_ComponentSetHash; // 0xC0
		private GraphicsDeviceType m_GraphicsDeviceType; // 0xD0
	
		// Methods
		public void Initialize(); // 0x0000000181F07F10-0x0000000181F08080
		public void Dispose(); // 0x0000000181F076E0-0x0000000181F07990
		public GPUComponentHandle FindComponent(int propertyID); // 0x0000000181F07A90-0x0000000181F07B20
		public GPUArchetypeHandle FindArchetype(GPUComponentSet componentSet); // 0x0000000181F07990-0x0000000181F07A40
		public GPUComponentSet FindComponentSet(GPUArchetypeHandle archetype); // 0x0000000181F07A40-0x0000000181F07A90
		public ref GPUComponentDesc GetComponentDesc(GPUComponentHandle componentHandle); // 0x0000000181F07B90-0x0000000181F07BF0
		public ref GPUArchetypeDesc GetArchetypeDesc(GPUArchetypeHandle archetypeHandle); // 0x0000000181F07B20-0x0000000181F07B80
		public int GetComponentsCount(); // 0x0000000181F07BF0-0x0000000181F07C00
		public int GetArchetypesCount(); // 0x0000000181F07B80-0x0000000181F07B90
		public GPUComponentHandle CreateComponent(int propertyID, int byteSize, bool isPerInstance); // 0x0000000181F07540-0x0000000181F076E0
		public GPUComponentHandle CreateComponent<T>(int propertyID, bool isPerInstance)
			where T : struct;
		public GPUArchetypeHandle CreateArchetype(GPUComponentSet componentSet); // 0x0000000181F07300-0x0000000181F07540
		public GPUArchetypeHandle GetOrCreateArchetype(GPUComponentSet componentSet); // 0x0000000181F07C00-0x0000000181F07C80
		public GPUComponentHandle GetOrCreateComponent(int propertyID, int byteSize, bool perInstance); // 0x0000000181F07C80-0x0000000181F07F10
	}
}
