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
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Collections
{
	[DebuggerDisplay("Length = {m_Length}")]
	[DebuggerTypeProxy(typeof(NativeArrayDebugView<T>))]
	[NativeContainer]
	[NativeContainerSupportsDeallocateOnJobCompletion]
	[NativeContainerSupportsDeferredConvertListToArray]
	[NativeContainerSupportsMinMaxWriteRestriction]
	public struct NativeArray<T> : IDisposable, IEnumerable<T>, IEquatable<Unity.Collections.NativeArray<T>> // TypeDefIndex: 7423
		where T : struct
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		[VisibleToOtherModules(new string[2] {"UnityEngine.ContentLoadModule", "UnityEngine.TilemapModule" })]
		internal unsafe void* m_Buffer;
		internal int m_Length;
		internal Allocator m_AllocatorLabel;
	
		// Properties
		public int Length { get; }
		public T this[int index] { get => default; [WriteAccessRequired] set {} }
		public bool IsCreated { get; }
	
		// Nested types
		[ExcludeFromDocs]
		public struct Enumerator : IEnumerator<T> // TypeDefIndex: 7424
		{
			// Fields
			private NativeArray<T> m_Array;
			private int m_Index;
			private T value;
	
			// Properties
			public T Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator(ref NativeArray<T> array);
	
			// Methods
			public void Dispose();
			public bool MoveNext();
			public void Reset();
		}
	
		[DebuggerDisplay("Length = {Length}")]
		[DebuggerTypeProxy(typeof(NativeArrayReadOnlyDebugView<T>))]
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : IEnumerable<T> // TypeDefIndex: 7425
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe void* m_Buffer;
			internal int m_Length;
	
			// Properties
			public int Length { get; }
			public T this[int index] { get => default; }
	
			// Nested types
			[ExcludeFromDocs]
			public struct Enumerator : IEnumerator<T> // TypeDefIndex: 7426
			{
				// Fields
				private ReadOnly<T> m_Array;
				private int m_Index;
				private T value;
	
				// Properties
				public T Current { get; }
				object IEnumerator.Current { get; }
	
				// Constructors
				public Enumerator([IsReadOnly] in ReadOnly<T> array);
	
				// Methods
				public void Dispose();
				public bool MoveNext();
				public void Reset();
			}
	
			// Constructors
			internal unsafe ReadOnly(void* buffer, int length);
	
			// Methods
			public Enumerator GetEnumerator();
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator();
			[IsReadOnly]
			public ReadOnlySpan<T> AsReadOnlySpan();
		}
	
		// Constructors
		public unsafe NativeArray(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x0069D1C7 */);
		public unsafe NativeArray(int length, MemoryLabel label, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x0069D1C8 */);
		public unsafe NativeArray(T[] array, Allocator allocator);
		public unsafe NativeArray(NativeArray<T> array, Allocator allocator);
	
		// Methods
		private static void Allocate(int length, Allocator allocator, MemoryLabel label, out NativeArray<T> array);
		[WriteAccessRequired]
		public void Dispose();
		public JobHandle Dispose(JobHandle inputDeps);
		[WriteAccessRequired]
		public void CopyFrom(T[] array);
		[WriteAccessRequired]
		public void CopyFrom(NativeArray<T> array);
		public void CopyTo(T[] array);
		public void CopyTo(NativeArray<T> array);
		public T[] ToArray();
		public Enumerator GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public bool Equals(NativeArray<T> other);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public static bool operator ==(NativeArray<T> left, NativeArray<T> right);
		public static bool operator !=(NativeArray<T> left, NativeArray<T> right);
		public static void Copy(NativeArray<T> src, NativeArray<T> dst);
		public static void Copy(T[] src, NativeArray<T> dst);
		public static void Copy(NativeArray<T> src, T[] dst);
		public static void Copy(NativeArray<T> src, NativeArray<T> dst, int length);
		public static void Copy(NativeArray<T> src, T[] dst, int length);
		public static void Copy(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
		public static void Copy(T[] src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
		public static void Copy(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length);
		private static void CopySafe(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
		private static void CopySafe(T[] src, int srcIndex, NativeArray<T> dst, int dstIndex, int length);
		private static void CopySafe(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length);
		private Collections.NativeArray<U> InternalReinterpret<U>(int length)
			where U : struct;
		public Collections.NativeArray<U> Reinterpret<U>()
			where U : struct;
		public Collections.NativeArray<U> Reinterpret<U>(int expectedTypeSize)
			where U : struct;
		public NativeArray<T> GetSubArray(int start, int length);
		public ReadOnly AsReadOnly();
		[IsReadOnly]
		[WriteAccessRequired]
		public Span<T> AsSpan();
		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan();
		public static implicit operator Span<T>([IsReadOnly] in NativeArray<T> source);
		public static implicit operator ReadOnlySpan<T>([IsReadOnly] in NativeArray<T> source);
	}
}
