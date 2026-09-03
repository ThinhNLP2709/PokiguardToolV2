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
	internal struct GPUInstanceUploadData : IDisposable // TypeDefIndex: 12775
	{
		// Fields
		private NativeArray<GPUComponentHandle> m_Components; // 0x00
		private NativeArray<int> m_ComponentGPUAddress; // 0x10
		private NativeArray<int> m_ComponentSize; // 0x20
		private NativeArray<bool> m_ComponentPerInstance; // 0x30
		private NativeArray<int> m_ComponentIndices; // 0x40
		private NativeList<GPUComponentHandle> m_WrittenComponents; // 0x50
		private int m_Length; // 0x58
		private int m_UploadDataUIntSize; // 0x5C
	
		// Properties
		public int length { get; } // 0x000000018033D260-0x000000018033D270 
		public int uploadDataUIntSize { get; } // 0x000000018033D270-0x000000018033D280 
		public NativeArray<int> componentGPUAddress { get; } // 0x0000000181F0BF20-0x0000000181F0BF50 
		public NativeArray<GPUComponentHandle> writtenComponents { get; } // 0x0000000181F0BF50-0x0000000181F0BF80 
	
		// Constructors
		public GPUInstanceUploadData(ref GPUArchetypeManager archetypeManager, NativeArray<GPUComponentHandle> components, int length, Allocator allocator); // 0x0000000181F0BC00-0x0000000181F0BF20
	
		// Methods
		public void Dispose(); // 0x0000000181F0B870-0x0000000181F0B910
		public int FindComponentIndex(GPUComponentHandle component); // 0x0000000181F0B910-0x0000000181F0B970
		public int PrepareComponentWrite<T>(GPUComponentHandle component)
			where T : struct;
		public JobHandle ScheduleWriteComponentsJob<T>(NativeArray<T> instanceData, GPUComponentHandle component, NativeArray<uint> uploadBuffer)
			where T : struct;
		public JobHandle ScheduleWriteComponentsJob(JaggedSpan<byte> instanceData, GPUComponentHandle component, int componentSize, NativeArray<uint> uploadBuffer); // 0x0000000181F0B970-0x0000000181F0BC00
	}
}
