/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ArrayDebugView<T>))]
	internal struct Array<T> : IDisposable // TypeDefIndex: 14955
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
		public int MaxSize { get; }
		public unsafe void* UnsafePtr { get; }
		public unsafe void* UnsafeReadOnlyPtr { get; }
	
		// Constructors
		public Array(int length, int maxSize, Allocator allocMode, NativeArrayOptions options);
	
		// Methods
		private void ResizeIfRequired(int index);
		public void Dispose();
		public void CopyTo(T[] array);
	}
}
