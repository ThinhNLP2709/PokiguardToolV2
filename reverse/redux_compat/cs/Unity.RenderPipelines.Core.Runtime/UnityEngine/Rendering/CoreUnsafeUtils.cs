/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class CoreUnsafeUtils // TypeDefIndex: 5354
	{
		// Nested types
		public struct FixedBufferStringQueue // TypeDefIndex: 5355
		{
			// Fields
			private unsafe byte* m_ReadCursor; // 0x00
			private unsafe byte* m_WriteCursor; // 0x08
			private readonly unsafe byte* m_BufferEnd; // 0x10
			private readonly unsafe byte* m_BufferStart; // 0x18
			private readonly int m_BufferLength; // 0x20
			[CompilerGenerated]
			private int _Count_k__BackingField; // 0x24
	
			// Properties
			public int Count { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
	
			// Constructors
			public unsafe FixedBufferStringQueue(byte* ptr, int length); // 0x0000000181E22D30-0x0000000181E22D70
	
			// Methods
			public bool TryPush(string v); // 0x0000000181E22C80-0x0000000181E22D30
			public bool TryPop(out string v); // 0x0000000181E22BC0-0x0000000181E22C80
			public void Clear(); // 0x0000000181E22B90-0x0000000181E22BC0
		}
	
		public interface IKeyGetter<TValue, TKey> // TypeDefIndex: 5356
		{
			// Methods
			TKey Get(ref ref TValue v);
		}
	
		internal struct DefaultKeyGetter<T> : IKeyGetter<T, T> // TypeDefIndex: 5357
		{
			// Methods
			public T Get(ref ref T v);
		}
	
		internal struct UintKeyGetter : IKeyGetter<uint, uint> // TypeDefIndex: 5358
		{
			// Methods
			public uint Get(ref uint v); // 0x0000000180E6B260-0x0000000180E6B270
		}
	
		internal struct UlongKeyGetter : IKeyGetter<ulong, ulong> // TypeDefIndex: 5359
		{
			// Methods
			public ulong Get(ref ulong v); // 0x0000000180691EA0-0x0000000180691EB0
		}
	
		// Methods
		private static void CalculateRadixParams(int radixBits, out int bitStates); // 0x0000000181E21F70-0x0000000181E21F80
		private static int CalculateRadixSupportSize(int bitStates, int arrayLength); // 0x0000000181E21FC0-0x0000000181E21FD0
		private static unsafe void CalculateRadixSortSupportArrays(int bitStates, int arrayLength, uint* supportArray, out uint* bucketIndices, out uint* bucketSizes, out uint* bucketPrefix, out uint* arrayOutput); // 0x0000000181E21F80-0x0000000181E21FC0
		private static unsafe void MergeSort(uint* array, uint* support, int length); // 0x0000000181E22450-0x0000000181E22600
		public static void MergeSort(uint[] arr, int sortSize, ref uint[] supportArray); // 0x0000000181E22600-0x0000000181E22700
		public static void MergeSort(NativeArray<uint> arr, int sortSize, ref NativeArray<uint> supportArray); // 0x0000000181E223A0-0x0000000181E22450
		private static unsafe void InsertionSort(uint* arr, int length); // 0x0000000181E22270-0x0000000181E222C0
		public static void InsertionSort(uint[] arr, int sortSize); // 0x0000000181E222C0-0x0000000181E223A0
		public static void InsertionSort(NativeArray<uint> arr, int sortSize); // 0x0000000181E221B0-0x0000000181E22270
		private static unsafe void RadixSort(uint* array, uint* support, int radixBits, int bitStates, int length); // 0x0000000181E227E0-0x0000000181E22990
		public static void RadixSort(uint[] arr, int sortSize, ref uint[] supportArray, int radixBits = 8 /* Metadata: 0x0066149F */); // 0x0000000181E22990-0x0000000181E22AB0
		public static void RadixSort(NativeArray<uint> array, int sortSize, ref NativeArray<uint> supportArray, int radixBits = 8 /* Metadata: 0x006614A0 */); // 0x0000000181E22AB0-0x0000000181E22B90
		public static void QuickSort(uint[] arr, int left, int right); // 0x0000000181E22770-0x0000000181E227E0
		public static void QuickSort(ulong[] arr, int left, int right); // 0x0000000181E22700-0x0000000181E22770
		public static unsafe void QuickSort<T>(int count, void* data)
			where T : struct, IComparable<T>;
		public static unsafe void QuickSort<TValue, TKey, TGetter>(int count, void* data)
			where TValue : struct
			where TKey : struct, IComparable<TKey>
			where TGetter : struct, IKeyGetter<TValue, TKey>;
		public static unsafe void QuickSort<TValue, TKey, TGetter>(void* data, int left, int right)
			where TValue : struct
			where TKey : struct, IComparable<TKey>
			where TGetter : struct, IKeyGetter<TValue, TKey>;
		public static unsafe int IndexOf<T>(void* data, int count, T v)
			where T : struct, IEquatable<T>;
		public static unsafe int CompareHashes<TOldValue, TOldGetter, TNewValue, TNewGetter>(int oldHashCount, void* oldHashes, int newHashCount, void* newHashes, int* addIndices, int* removeIndices, out int addCount, out int remCount)
			where TOldValue : struct
			where TOldGetter : struct, IKeyGetter<TOldValue, Hash128>
			where TNewValue : struct
			where TNewGetter : struct, IKeyGetter<TNewValue, Hash128>;
		public static unsafe int CompareHashes(int oldHashCount, Hash128* oldHashes, int newHashCount, Hash128* newHashes, int* addIndices, int* removeIndices, out int addCount, out int remCount); // 0x0000000181E22030-0x0000000181E220A0
		public static unsafe void CombineHashes<TValue, TGetter>(int count, void* hashes, Hash128* outHash)
			where TValue : struct
			where TGetter : struct, IKeyGetter<TValue, Hash128>;
		public static unsafe void CombineHashes(int count, Hash128* hashes, Hash128* outHash); // 0x0000000181E21FD0-0x0000000181E22030
		private static unsafe int Partition<TValue, TKey, TGetter>(void* data, int left, int right)
			where TValue : struct
			where TKey : struct, IComparable<TKey>
			where TGetter : struct, IKeyGetter<TValue, TKey>;
		public static bool HaveDuplicates(int[] arr); // 0x0000000181E220A0-0x0000000181E221B0
	
		// Extension methods
		public static unsafe void CopyTo<T>(this List<T> list, void* dest, int count)
			where T : struct;
		public static unsafe void CopyTo<T>(this T[] list, void* dest, int count)
			where T : struct;
	}
}
