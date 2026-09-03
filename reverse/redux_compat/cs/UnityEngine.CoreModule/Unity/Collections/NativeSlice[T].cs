/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Internal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(NativeSliceDebugView<T>))]
	[NativeContainer]
	[NativeContainerSupportsMinMaxWriteRestriction]
	public struct NativeSlice<T> : IEnumerable<T>, IEquatable<Unity.Collections.NativeSlice<T>> // TypeDefIndex: 7432
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
	
		// Nested types
		[ExcludeFromDocs]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 7433
		{
			// Fields
			private NativeSlice<T> m_Array;
			private int m_Index;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator(ref NativeSlice<T> array);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		// Constructors
		public unsafe NativeSlice(NativeSlice<T> slice, int start, int length);
		public unsafe NativeSlice(NativeArray<T> array);
		public unsafe NativeSlice(NativeArray<T> array, int start);
		public unsafe NativeSlice(NativeArray<T> array, int start, int length);
	
		// Methods
		public static implicit operator NativeSlice<T>(NativeArray<T> array);
		public Collections.NativeSlice<U> SliceConvert<U>()
			where U : struct;
		public Collections.NativeSlice<U> SliceWithStride<U>(int offset)
			where U : struct;
		public Collections.NativeSlice<U> SliceWithStride<U>()
			where U : struct;
		[WriteAccessRequired]
		public void CopyFrom(NativeSlice<T> slice);
		[WriteAccessRequired]
		public void CopyFrom(T[] array);
		public void CopyTo(T[] array);
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public bool Equals(NativeSlice<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
