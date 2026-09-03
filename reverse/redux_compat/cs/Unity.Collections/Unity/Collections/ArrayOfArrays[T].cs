/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	internal struct ArrayOfArrays<T> : IDisposable // TypeDefIndex: 11469
		where T : struct
	{
		// Fields
		private AllocatorManager.AllocatorHandle m_backingAllocatorHandle;
		private int m_lengthInElements;
		private int m_capacityInElements;
		private int m_log2BlockSizeInElements;
		private int m_blocks;
		private unsafe IntPtr* m_block;
	
		// Properties
		private int BlockSizeInElements { get; }
		private int BlockSizeInBytes { get; }
		private int BlockMask { get; }
		public int Length { get; }
		public int Capacity { get; }
		public ref T this[int elementIndex] { get => default; }
	
		// Constructors
		public unsafe ArrayOfArrays(int capacityInElements, AllocatorManager.AllocatorHandle backingAllocatorHandle, int log2BlockSizeInElements = 12 /* Metadata: 0x006A1BC2 */);
	
		// Methods
		public void LockfreeAdd(T t);
		public void Rewind();
		public void Clear();
		public void Dispose();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckElementIndex(int elementIndex);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBlockIndex(int blockIndex);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckBlockIsNotNull(int blockIndex);
		public void RemoveAtSwapBack(int elementIndex);
		private int BlockIndexOfElement(int elementIndex);
		public void TrimExcess();
	}
}
