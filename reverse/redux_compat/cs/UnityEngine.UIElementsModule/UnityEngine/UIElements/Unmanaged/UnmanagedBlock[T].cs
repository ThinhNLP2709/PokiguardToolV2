/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Unmanaged
{
	internal struct UnmanagedBlock<T> : IDisposable // TypeDefIndex: 4986
		where T : struct
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel;
		private unsafe T* m_Data;
		private int m_Capacity;
	
		// Properties
		public int Capacity { get; set; }
		public ref T this[int index] { get => default; }
	
		// Constructors
		public unsafe UnmanagedBlock(int initialCapacity);
		static UnmanagedBlock();
	
		// Methods
		public unsafe T* GetUnsafePtr();
		public void Dispose();
		public ReadOnlySpan<T> ReadOnlySpan(int start, int count);
		public Span<T> Span(int start, int count);
	}
}
