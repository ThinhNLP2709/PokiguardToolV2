/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UAi
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(MatrixMxNDebugView<T>))]
	internal struct MatrixMxN<T> : IDisposable // TypeDefIndex: 14995
		where T : struct
	{
		// Fields
		internal NativeArray<T> m_Array;
		internal int m_Width;
		internal int m_Height;
		internal Allocator m_AllocLabel;
		internal NativeArrayOptions m_Options;
	
		// Properties
		private T this[int index] { get => default; set {} }
		public bool IsCreated { get; }
		public int Length { get; }
		public int DimensionX { get; }
		public int DimensionY { get; }
	
		// Constructors
		public MatrixMxN(int width, int height, Allocator allocMode, NativeArrayOptions options);
	
		// Methods
		public NativeArray<T> GetArray();
		public T Get(int x, int y);
		public void Set(int x, int y, T v);
		public void Dispose();
		public void CopyTo(T[] array);
	}
}
