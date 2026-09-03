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
	internal class NativeList<T> : IDisposable // TypeDefIndex: 5112
		where T : struct
	{
		// Fields
		private readonly MemoryLabel m_MemoryLabel;
		private readonly int m_MaxQueuedFrameCount;
		private NativeArray<T> m_NativeArray;
		private int m_Count;
		private List<DeferredArray> m_DeferredArrays;
		[CompilerGenerated]
		private bool _disposed_k__BackingField;
	
		// Properties
		public int Count { get; }
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Nested types
		private struct DeferredArray // TypeDefIndex: 5113
		{
			// Fields
			public NativeArray<T> array;
			public int framesRemaining;
		}
	
		// Constructors
		public NativeList(int initialCapacity, MemoryLabel allocLabel, int maxQueuedFrameCount = 0 /* Metadata: 0x00660AA1 */);
	
		// Methods
		private void Expand(int newLength);
		public void Add(ref ref T data);
		public void Add(NativeSlice<T> src);
		public void Clear();
		public NativeArray<T> GetBuffer();
		public void AdvanceFrame();
		public void Dispose();
		protected void Dispose(bool disposing);
	}
}
