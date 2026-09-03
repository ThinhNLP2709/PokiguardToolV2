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
	internal struct GPUInstanceDataBufferReadback<TData> : IDisposable // TypeDefIndex: 12779
		where TData : struct
	{
		// Fields
		private GPUInstanceDataBuffer m_InstanceDataBuffer;
		[CompilerGenerated]
		private NativeArray<TData> _data_k__BackingField;
	
		// Properties
		public NativeArray<TData> data { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 12780
		{
			// Fields
			public NativeArray<TData> localData;
			public int errorCount;
	
			// Constructors
			public __c__DisplayClass5_0();
	
			// Methods
			internal void _Load_b__0(AsyncGPUReadbackRequest req);
		}
	
		// Methods
		public bool Load(CommandBuffer cmd, GPUInstanceDataBuffer instanceDataBuffer);
		public T LoadData<T>(GPUComponentHandle component, GPUInstanceIndex gpuInstanceIndex)
			where T : struct;
		public void Dispose();
	}
}
