/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct JaggedSpan<T> : IDisposable // TypeDefIndex: 12990
		where T : struct
	{
		// Fields
		private UnsafeList<UnsafeList<T>> m_Sections;
		private int m_TotalLength;
	
		// Properties
		public bool isCreated { get; }
		public int sectionCount { get; }
		public int totalLength { get; }
		public bool isEmpty { get; }
		public NativeArray<UnsafeList<T>> sections { get; }
		public NativeArray<UntypedUnsafeList> untypedSections { get; }
		public NativeArray<T> this[int index] { get => default; set {} }
	
		// Constructors
		public JaggedSpan(int initialCapacity, Allocator allocator);
	
		// Methods
		public void Dispose();
		public JobHandle Dispose(JobHandle jobHandle);
		public void Add([IsReadOnly] in NativeArray<T> section);
		public bool HasSameLayout<U>([IsReadOnly] in Rendering.JaggedSpan<U> other)
			where U : struct;
		private static NativeArray<T> SectionAsArray([IsReadOnly] in UnsafeList<T> section);
		private static UnsafeList<T> SectionAsUnsafeList([IsReadOnly] in NativeArray<T> section);
	}
}
