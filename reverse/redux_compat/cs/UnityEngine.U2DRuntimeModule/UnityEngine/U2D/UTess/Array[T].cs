/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ArrayDebugView<T>))]
	internal struct Array<T> : IDisposable // TypeDefIndex: 15053
		where T : struct
	{
		// Fields
		internal NativeArray<T> m_Array;
		internal int m_MaxSize;
		internal Allocator m_AllocLabel;
		internal NativeArrayOptions m_Options;
	
		// Properties
		public T this[int index] { get => default; set {} }
		public bool IsCreated { get; }
		public int Length { get; }
		public unsafe void* UnsafePtr { get; }
		public unsafe void* UnsafeReadOnlyPtr { get; }
	
		// Constructors
		public Array(int length, int maxSize, Allocator allocMode, NativeArrayOptions options);
	
		// Methods
		private void ResizeIfRequired(int index);
		public void Dispose();
	}
}
