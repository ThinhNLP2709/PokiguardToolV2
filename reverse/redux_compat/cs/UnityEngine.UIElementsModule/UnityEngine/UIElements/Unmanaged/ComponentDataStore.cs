/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	internal struct ComponentDataStore : IDisposable // TypeDefIndex: 4992
	{
		// Fields
		public readonly MemoryLabel MemoryLabel; // 0x00
		public int Size; // 0x10
		public int Align; // 0x14
		public int ComponentCountPerChunk; // 0x18
		public int ChunkCount; // 0x1C
		[NativeDisableUnsafePtrRestriction]
		private unsafe Chunk* m_Chunks; // 0x20
		[NativeDisableUnsafePtrRestriction]
		public unsafe byte* InitialData; // 0x28
	
		// Properties
		public int Capacity { get; } // 0x00000001823F4FB0-0x00000001823F4FC0 
	
		// Nested types
		private struct Chunk // TypeDefIndex: 4993
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			public unsafe byte* Buffer; // 0x00
		}
	
		// Constructors
		public unsafe ComponentDataStore(int size, int align, MemoryLabel allocLabel, byte* initialData); // 0x00000001823F4F40-0x00000001823F4FB0
	
		// Methods
		public void Dispose(); // 0x00000001823F4CB0-0x00000001823F4D80
		public unsafe byte* GetComponentDataPtr(int index); // 0x00000001823F4D80-0x00000001823F4DB0
		public void ResizeCapacity(int capacity); // 0x00000001823F4DB0-0x00000001823F4F40
	}
}
