/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public struct StreamCompressionModel // TypeDefIndex: 11641
	{
		// Fields
		internal static readonly byte[] k_BucketSizes; // 0x00
		internal static readonly uint[] k_BucketOffsets; // 0x08
		internal static readonly int[] k_FirstBucketCandidate; // 0x10
		internal static readonly byte[] k_DefaultModelData; // 0x18
		internal const int k_AlphabetSize = 16; // Metadata: 0x006A1C7B
		internal const int k_MaxHuffmanSymbolLength = 6; // Metadata: 0x006A1C7C
		internal const int k_MaxContexts = 1; // Metadata: 0x006A1C7D
		private byte m_Initialized; // 0x00
		internal unsafe fixed /* 0x00000000-0x00000000 */ ushort encodeTable[0]; // 0x02
		internal unsafe fixed /* 0x00000000-0x00000000 */ ushort decodeTable[0]; // 0x22
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte bucketSizes[0]; // 0xA2
		internal unsafe fixed /* 0x00000000-0x00000000 */ uint bucketOffsets[0]; // 0xB4
	
		// Properties
		public static StreamCompressionModel Default { get; } // 0x0000000181CA77B0-0x0000000181CA78F0 
	
		// Nested types
		private static class SharedStaticCompressionModel // TypeDefIndex: 11642
		{
			// Fields
			internal static readonly SharedStatic<StreamCompressionModel> Default; // 0x00
	
			// Constructors
			static SharedStaticCompressionModel(); // 0x0000000181CA6850-0x0000000181CA68A0
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _bucketOffsets_e__FixedBuffer // TypeDefIndex: 11643
		{
			// Fields
			public uint FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _bucketSizes_e__FixedBuffer // TypeDefIndex: 11644
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _decodeTable_e__FixedBuffer // TypeDefIndex: 11645
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _encodeTable_e__FixedBuffer // TypeDefIndex: 11646
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	
		// Constructors
		static StreamCompressionModel(); // 0x0000000181CA75A0-0x0000000181CA77B0
	
		// Methods
		private static void Initialize(); // 0x0000000181CA6FD0-0x0000000181CA7540
		private static void GenerateHuffmanCodes(NativeArray<byte> symbolCodes, int symbolCodesOffset, NativeArray<byte> symbolLengths, int symbolLengthsOffset, int alphabetSize, int maxCodeLength); // 0x0000000181CA6B80-0x0000000181CA6DE0
		private static uint ReverseBits(uint value, int num_bits); // 0x0000000181CA7540-0x0000000181CA75A0
		private static void GenerateHuffmanDecodeTable(NativeArray<ushort> decodeTable, int decodeTableOffset, NativeArray<byte> symbolLengths, NativeArray<byte> symbolCodes, int alphabetSize, int maxCodeLength); // 0x0000000181CA6DE0-0x0000000181CA6EA0
		[IsReadOnly]
		public int CalculateBucket(uint value); // 0x0000000181CA68C0-0x0000000181CA69A0
		[IsReadOnly]
		public int GetCompressedSizeInBits(uint value); // 0x0000000181CA6EA0-0x0000000181CA6FD0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckAlphabetSize(int alphabetSize); // 0x0000000181CA6A10-0x0000000181CA6AB0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckSymbolLength(NativeArray<byte> symbolLengths, int symbolLengthsOffset, int symbol, int length); // 0x0000000181CA6B10-0x0000000181CA6B80
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckAlphabetAndMaxCodeLength(int alphabetSize, int maxCodeLength); // 0x0000000181CA69A0-0x0000000181CA6A10
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckExceedMaxCodeLength(int length, int maxCodeLength); // 0x0000000181CA6AB0-0x0000000181CA6B10
	}
}
