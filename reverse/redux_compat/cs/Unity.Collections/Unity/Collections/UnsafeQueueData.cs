/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal struct UnsafeQueueData // TypeDefIndex: 11657
	{
		// Fields
		internal const int m_BlockSize = 16384; // Metadata: 0x006A1C90
		public IntPtr m_FirstBlock; // 0x00
		public IntPtr m_LastBlock; // 0x08
		public int m_MaxItems; // 0x10
		public int m_CurrentRead; // 0x14
		public unsafe byte* m_CurrentWriteBlockTLS; // 0x18
	
		// Methods
		internal unsafe UnsafeQueueBlockHeader* GetCurrentWriteBlockTLS(int threadIndex); // 0x0000000181CAC310-0x0000000181CAC320
		internal unsafe void SetCurrentWriteBlockTLS(int threadIndex, UnsafeQueueBlockHeader* currentWriteBlock); // 0x0000000181CAC320-0x0000000181CAC330
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe UnsafeQueueBlockHeader* AllocateWriteBlockMT<T>(UnsafeQueueData* data, AllocatorManager.AllocatorHandle allocator, int threadIndex)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe void AllocateQueue<T>(AllocatorManager.AllocatorHandle allocator, out UnsafeQueueData* outBuf)
			where T : struct;
		public static unsafe void DeallocateQueue(UnsafeQueueData* data, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CAC2A0-0x0000000181CAC310
	}
}
