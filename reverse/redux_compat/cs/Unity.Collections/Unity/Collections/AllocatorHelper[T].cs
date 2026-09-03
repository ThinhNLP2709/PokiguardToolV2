/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(AllocatorManager.AllocatorHandle) })]
	public struct AllocatorHelper<T> : IDisposable // TypeDefIndex: 11468
		where T : struct, AllocatorManager.IAllocator
	{
		// Fields
		private readonly unsafe T* m_allocator;
		private AllocatorManager.AllocatorHandle m_backingAllocator;
	
		// Properties
		public ref T Allocator { get; }
	
		// Constructors
		[ExcludeFromBurstCompatTesting("CreateAllocator is unburstable")]
		public unsafe AllocatorHelper(AllocatorManager.AllocatorHandle backingAllocator, bool isGlobal = false /* Metadata: 0x006A1BC0 */, int globalIndex = 0 /* Metadata: 0x006A1BC1 */);
	
		// Methods
		[ExcludeFromBurstCompatTesting("DestroyAllocator is unburstable")]
		public void Dispose();
	}
}
