/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[Serializable]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(FixedBytes32Align8) })]
	internal struct FixedList<T, U> : INativeList<T> // TypeDefIndex: 11494
		where T : struct
		where U : struct
	{
		// Fields
		[SerializeField]
		internal U data;
	
		// Properties
		internal ushort length { [IsReadOnly] get; set; }
		internal unsafe byte* buffer { [IsReadOnly] get; }
		[CreateProperty]
		public int Length { [IsReadOnly] get; set; }
		[CreateProperty]
		private IEnumerable<T> Elements { get; }
		public bool IsEmpty { [IsReadOnly] get; }
		internal int LengthInBytes { [IsReadOnly] get; }
		internal unsafe byte* Buffer { [IsReadOnly] get; }
		public int Capacity { [IsReadOnly] get; set; }
		public T this[int index] { [IsReadOnly] get => default; set {} }
	
		// Methods
		[WriteAccessRequired]
		public unsafe T* GetUnsafePtr();
		[IsReadOnly]
		public unsafe T* GetUnsafeReadOnlyPtr();
		[WriteAccessRequired]
		public static implicit operator Span<T>([IsReadOnly] in FixedList<T, U> container);
		public static implicit operator ReadOnlySpan<T>([IsReadOnly] in FixedList<T, U> container);
		[WriteAccessRequired]
		public Span<T> AsSpan();
		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan();
		public ref ref T ElementAt(int index);
		public override int GetHashCode();
		public void Add([IsReadOnly] in ref T item);
		public unsafe void AddRange(void* ptr, int length);
		public void AddRange(ReadOnlySpan<T> roSpan);
		public void AddNoResize([IsReadOnly] in ref T item);
		public unsafe void AddRangeNoResize(void* ptr, int length);
		public void AddRangeNoResize(ReadOnlySpan<T> roSpan);
		public void AddReplicate([IsReadOnly] in ref T value, int count);
		public void Clear();
		public void InsertRangeWithBeginEnd(int begin, int end);
		public void InsertRange(int index, int count);
		public void Insert(int index, [IsReadOnly] in ref T item);
		public void RemoveAtSwapBack(int index);
		public void RemoveRangeSwapBack(int index, int count);
		public void RemoveAt(int index);
		public void RemoveRange(int index, int count);
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public T[] ToArray();
		public NativeArray<T> ToNativeArray(AllocatorManager.AllocatorHandle allocator);
	}
}
