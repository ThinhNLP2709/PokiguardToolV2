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
	internal struct UnmanagedArray<T> : IDisposable // TypeDefIndex: 11635
		where T : struct
	{
		// Fields
		private IntPtr m_pointer;
		private int m_length;
		private AllocatorManager.AllocatorHandle m_allocator;
	
		// Properties
		public int Length { get; }
		public ref T this[int index] { get => default; }
	
		// Constructors
		public UnmanagedArray(int length, AllocatorManager.AllocatorHandle allocator);
	
		// Methods
		public void Dispose();
		public unsafe T* GetUnsafePointer();
	}
}
