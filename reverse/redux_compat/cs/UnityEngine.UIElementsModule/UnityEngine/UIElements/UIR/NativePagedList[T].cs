/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class NativePagedList<T> : IDisposable // TypeDefIndex: 5114
		where T : struct
	{
		// Fields
		private readonly int k_PoolCapacity;
		private List<NativeArray<T>> m_Pages;
		private NativeArray<T> m_LastPage;
		private int m_CountInLastPage;
		private readonly NativeArrayAllocator m_FirstPageAllocator;
		private readonly NativeArrayAllocator m_OtherPagesAllocator;
		private List<NativeSlice<T>> m_Enumerator;
		[CompilerGenerated]
		private bool _disposed_k__BackingField;
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Nested types
		private struct NativeArrayAllocator // TypeDefIndex: 5115
		{
			// Fields
			private Allocator m_Allocator;
			private MemoryLabel m_MemoryLabel;
	
			// Constructors
			public NativeArrayAllocator(string profilerName, Allocator allocator);
	
			// Methods
			public NativeArray<T> CreateArray(int length, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x00660AA4 */);
		}
	
		public struct Enumerator // TypeDefIndex: 5116
		{
			// Fields
			private NativePagedList<T> m_NativePagedList;
			private NativeArray<T> m_CurrentPage;
			private int m_IndexInCurrentPage;
			private int m_IndexOfCurrentPage;
			private int m_CountInCurrentPage;
	
			// Constructors
			public Enumerator(NativePagedList<T> nativePagedList, int offset);
	
			// Methods
			public bool HasNext();
			public T GetNext();
		}
	
		// Constructors
		public NativePagedList(int poolCapacity, string profilerName, Allocator firstPageAllocator = Allocator.Persistent /* Metadata: 0x00660AA2 */, Allocator otherPagesAllocator = Allocator.Persistent /* Metadata: 0x00660AA3 */);
	
		// Methods
		public void Add(ref ref T data);
		public void Add(T data);
		public unsafe T* AllocLast();
		public List<NativeSlice<T>> GetPages();
		public int GetCount();
		public void Reset();
		public void Dispose();
		protected void Dispose(bool disposing);
	}
}
