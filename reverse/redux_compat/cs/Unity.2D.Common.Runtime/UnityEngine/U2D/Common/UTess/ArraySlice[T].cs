/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ArraySliceDebugView<T>))]
	internal struct ArraySlice<T> : IEquatable<UnityEngine.U2D.Common.UTess.ArraySlice<T>> // TypeDefIndex: 14957
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe byte* m_Buffer;
		internal int m_Stride;
		internal int m_Length;
	
		// Properties
		public T this[int index] { get => default; [WriteAccessRequired] set {} }
		public int Stride { get; }
		public int Length { get; }
	
		// Constructors
		public unsafe ArraySlice(NativeArray<T> array, int start, int length);
		public unsafe ArraySlice(Array<T> array, int start, int length);
	
		// Methods
		public bool Equals(ArraySlice<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public static bool operator ==(ArraySlice<T> left, ArraySlice<T> right);
		public static bool operator !=(ArraySlice<T> left, ArraySlice<T> right);
		public static unsafe ArraySlice<T> ConvertExistingDataToArraySlice(void* dataPointer, int stride, int length);
		internal unsafe void* GetUnsafeReadOnlyPtr();
		internal void CopyTo(T[] array);
		internal T[] ToArray();
	}
}
