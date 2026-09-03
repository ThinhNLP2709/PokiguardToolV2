/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct ListBuffer<T> // TypeDefIndex: 5379
		where T : struct
	{
		// Fields
		private unsafe T* m_BufferPtr;
		private int m_Capacity;
		private unsafe int* m_CountPtr;
	
		// Properties
		internal unsafe T* BufferPtr { get; }
		public int Count { get; }
		public int Capacity { get; }
		public ref T this[[IsReadOnly] in int index] { get => default; }
	
		// Constructors
		public unsafe ListBuffer(T* bufferPtr, int* countPtr, int capacity);
	
		// Methods
		public ref ref T GetUnchecked([IsReadOnly] in int index);
		public bool TryAdd([IsReadOnly] in ref T value);
		public unsafe void CopyTo(T* dstBuffer, int startDstIndex, int copyCount);
		public bool TryCopyTo(ListBuffer<T> other);
		public unsafe bool TryCopyFrom(T* srcPtr, int count);
	}
}
