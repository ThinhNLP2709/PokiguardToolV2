/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Scripting.APIUpdating;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	[MovedFrom(true, "Unity.Networking.Transport", "Unity.Networking.Transport", null)]
	public struct DataStreamWriter // TypeDefIndex: 11489
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		private StreamData m_Data; // 0x00
		public IntPtr m_SendHandleData; // 0x20
	
		// Properties
		public static bool IsLittleEndian { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public bool HasFailedWrites { [IsReadOnly] get; } // 0x0000000181C8F9E0-0x0000000181C8F9F0 
		public int Capacity { [IsReadOnly] get; } // 0x0000000180732D30-0x0000000180732D40 
		public int Length { get; } // 0x0000000181C8FA40-0x0000000181C8FA90 
		public int LengthInBits { get; } // 0x0000000181C8F9F0-0x0000000181C8FA40 
	
		// Nested types
		private struct StreamData // TypeDefIndex: 11490
		{
			// Fields
			public unsafe byte* buffer; // 0x00
			public int length; // 0x08
			public int capacity; // 0x0C
			public ulong bitBuffer; // 0x10
			public int bitIndex; // 0x18
			public int failedWrites; // 0x1C
		}
	
		// Constructors
		public DataStreamWriter(int length, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C8F900-0x0000000181C8F960
		public DataStreamWriter(NativeArray<byte> data); // 0x0000000181C8F9B0-0x0000000181C8F9E0
		public unsafe DataStreamWriter(byte* data, int length); // 0x0000000181C8F960-0x0000000181C8F9B0
	
		// Methods
		public NativeArray<byte> AsNativeArray(); // 0x0000000181C8EA70-0x0000000181C8EB00
		private static void Initialize(out DataStreamWriter self, NativeArray<byte> data); // 0x0000000181C8ED80-0x0000000181C8EDA0
		private static short ByteSwap(short val); // 0x00000001815A6F30-0x00000001815A6F40
		private static int ByteSwap(int val); // 0x00000001815A6F20-0x00000001815A6F30
		private void SyncBitData(); // 0x0000000181C8EDA0-0x0000000181C8EDE0
		public void Flush(); // 0x0000000181C8ED40-0x0000000181C8ED80
		private unsafe bool WriteBytesInternal(byte* data, int bytes); // 0x0000000181C8EE00-0x0000000181C8EE90
		public bool WriteByte(byte value); // 0x0000000181C8EDE0-0x0000000181C8EE00
		public bool WriteBytes(NativeArray<byte> value); // 0x0000000181C8EE90-0x0000000181C8EEA0
		public bool WriteBytes(Span<byte> value); // 0x0000000181C8EEA0-0x0000000181C8EEE0
		public bool WriteShort(short value); // 0x0000000181C8F870-0x0000000181C8F8A0
		public bool WriteUShort(ushort value); // 0x0000000181C8F870-0x0000000181C8F8A0
		public bool WriteInt(int value); // 0x0000000181C8F010-0x0000000181C8F030
		public bool WriteUInt(uint value); // 0x0000000181C8F010-0x0000000181C8F030
		public bool WriteLong(long value); // 0x0000000181C8F030-0x0000000181C8F060
		public bool WriteULong(ulong value); // 0x0000000181C8F030-0x0000000181C8F060
		public bool WriteShortNetworkByteOrder(short value); // 0x0000000181C8F840-0x0000000181C8F870
		public bool WriteUShortNetworkByteOrder(ushort value); // 0x0000000181C8F8D0-0x0000000181C8F900
		public bool WriteIntNetworkByteOrder(int value); // 0x0000000181C8EFE0-0x0000000181C8F010
		public bool WriteUIntNetworkByteOrder(uint value); // 0x0000000181C8F8A0-0x0000000181C8F8D0
		public bool WriteFloat(float value); // 0x0000000181C8EFB0-0x0000000181C8EFE0
		public bool WriteDouble(double value); // 0x0000000181C8EEE0-0x0000000181C8EF10
		private void FlushBits(); // 0x0000000181C8ED00-0x0000000181C8ED40
		private void WriteRawBitsInternal(uint value, int numbits); // 0x0000000181C8F7C0-0x0000000181C8F7E0
		public bool WriteRawBits(uint value, int numbits); // 0x0000000181C8F7E0-0x0000000181C8F840
		public bool WritePackedUInt(uint value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F660-0x0000000181C8F770
		public bool WritePackedULong(ulong value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F770-0x0000000181C8F7C0
		public bool WritePackedInt(int value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F580-0x0000000181C8F5A0
		public bool WritePackedLong(long value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F600-0x0000000181C8F660
		public bool WritePackedFloat(float value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F4B0-0x0000000181C8F560
		public bool WritePackedDouble(double value, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F160-0x0000000181C8F260
		public bool WritePackedUIntDelta(uint value, uint baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F560-0x0000000181C8F580
		public bool WritePackedIntDelta(int value, int baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F560-0x0000000181C8F580
		public bool WritePackedLongDelta(long value, long baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F5A0-0x0000000181C8F600
		public bool WritePackedULongDelta(ulong value, ulong baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F5A0-0x0000000181C8F600
		public bool WritePackedFloatDelta(float value, float baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F410-0x0000000181C8F4B0
		public bool WritePackedDoubleDelta(double value, double baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F060-0x0000000181C8F160
		public bool WriteFixedString32(FixedString32Bytes str); // 0x0000000181C8EF10-0x0000000181C8EFB0
		public bool WriteFixedString64(FixedString64Bytes str); // 0x0000000181C8EF10-0x0000000181C8EFB0
		public bool WriteFixedString128(FixedString128Bytes str); // 0x0000000181C8EF10-0x0000000181C8EFB0
		public bool WriteFixedString512(FixedString512Bytes str); // 0x0000000181C8EF10-0x0000000181C8EFB0
		public bool WriteFixedString4096(FixedString4096Bytes str); // 0x0000000181C8EF10-0x0000000181C8EFB0
		public bool WritePackedFixedString32Delta(FixedString32Bytes str, FixedString32Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F260-0x0000000181C8F2A0
		public bool WritePackedFixedString64Delta(FixedString64Bytes str, FixedString64Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F260-0x0000000181C8F2A0
		public bool WritePackedFixedString128Delta(FixedString128Bytes str, FixedString128Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F260-0x0000000181C8F2A0
		public bool WritePackedFixedString512Delta(FixedString512Bytes str, FixedString512Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F260-0x0000000181C8F2A0
		public bool WritePackedFixedString4096Delta(FixedString4096Bytes str, FixedString4096Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F260-0x0000000181C8F2A0
		private unsafe bool WritePackedFixedStringDelta(byte* data, uint length, byte* baseData, uint baseLength, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8F2A0-0x0000000181C8F410
		public void Clear(); // 0x0000000181C8ECF0-0x0000000181C8ED00
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckAllocator(AllocatorManager.AllocatorHandle allocator); // 0x0000000181C8EB00-0x0000000181C8EB70
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckBits(uint value, int numBits); // 0x0000000181C8EB70-0x0000000181C8ECF0
	}
}
