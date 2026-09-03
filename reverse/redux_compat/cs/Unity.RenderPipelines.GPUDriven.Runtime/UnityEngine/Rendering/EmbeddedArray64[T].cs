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
	internal struct EmbeddedArray64<T> : IDisposable // TypeDefIndex: 12975
		where T : struct
	{
		// Fields
		private FixedList64Bytes<T> m_FixedArray;
		private UnsafeList<T> m_List;
		private int m_Length;
		private bool m_Created;
		private bool m_IsEmbedded;
	
		// Properties
		public int Length { get; }
		public T this[int index] { get => default; set {} }
	
		// Constructors
		public EmbeddedArray64(NativeArray<T> array, Allocator allocator);
	
		// Methods
		public void Dispose();
	}
}
