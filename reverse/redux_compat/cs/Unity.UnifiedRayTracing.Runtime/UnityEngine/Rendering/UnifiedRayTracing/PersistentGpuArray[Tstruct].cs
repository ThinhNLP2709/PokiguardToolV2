/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal sealed class PersistentGpuArray<Tstruct> : IDisposable // TypeDefIndex: 14297
		where Tstruct : struct
	{
		// Fields
		private BlockAllocator m_SlotAllocator;
		private ComputeBuffer m_GpuBuffer;
		private NativeArray<Tstruct> m_CpuList;
		private BitArray m_Updates;
		private bool m_gpuBufferDirty;
		private int m_ElementCount;
	
		// Properties
		public int elementCount { get; }
	
		// Constructors
		public PersistentGpuArray(int initialSize);
	
		// Methods
		public void Dispose();
		public BlockAllocator.Allocation Add(Tstruct element);
		public BlockAllocator.Allocation[] Add(int elementCount);
		public void Remove(BlockAllocator.Allocation allocation);
		public void Clear();
		public void Set(BlockAllocator.Allocation allocation, Tstruct element);
		public Tstruct Get(BlockAllocator.Allocation allocation);
		public void ModifyForEach(Func<Tstruct, Tstruct> lambda);
		public ComputeBuffer GetGpuBuffer(CommandBuffer cmd);
		private void Grow();
	}
}
