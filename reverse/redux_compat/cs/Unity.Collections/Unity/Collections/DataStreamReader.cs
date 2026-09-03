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
	[MovedFrom(true, "Unity.Networking.Transport", null, null)]
	public struct DataStreamReader // TypeDefIndex: 11487
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe byte* m_BufferPtr; // 0x00
		private Context m_Context; // 0x08
		private int m_Length; // 0x20
	
		// Properties
		public static bool IsLittleEndian { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool HasFailedReads { [IsReadOnly] get; } // 0x0000000181C8EA60-0x0000000181C8EA70 
		public int Length { [IsReadOnly] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
	
		// Nested types
		private struct Context // TypeDefIndex: 11488
		{
			// Fields
			public int m_ReadByteIndex; // 0x00
			public int m_BitIndex; // 0x04
			public ulong m_BitBuffer; // 0x08
			public int m_FailedReads; // 0x10
		}
	
		// Constructors
		public unsafe DataStreamReader(NativeArray<byte> array); // 0x0000000181C8EA40-0x0000000181C8EA60
	
		// Methods
		private static void Initialize(out DataStreamReader self, NativeArray<byte> array); // 0x0000000181C8D790-0x0000000181C8D7B0
		private static short ByteSwap(short val); // 0x00000001815A6F30-0x00000001815A6F40
		private static int ByteSwap(int val); // 0x00000001815A6F20-0x00000001815A6F30
		private unsafe void ReadBytesInternal(byte* data, int length); // 0x0000000181C8D830-0x0000000181C8D8B0
		public void ReadBytes(NativeArray<byte> array); // 0x0000000181C8D8F0-0x0000000181C8D900
		public void ReadBytes(Span<byte> span); // 0x0000000181C8D8B0-0x0000000181C8D8F0
		public int GetBytesRead(); // 0x0000000181C8D780-0x0000000181C8D790
		public int GetBitsRead(); // 0x0000000181C8D770-0x0000000181C8D780
		public void SeekSet(int pos); // 0x0000000181C8EA20-0x0000000181C8EA40
		public byte ReadByte(); // 0x0000000181C8D7B0-0x0000000181C8D830
		public short ReadShort(); // 0x0000000181C8E9A0-0x0000000181C8EA20
		public ushort ReadUShort(); // 0x0000000181C8E9A0-0x0000000181C8EA20
		public int ReadInt(); // 0x0000000181C8DD40-0x0000000181C8DDC0
		public uint ReadUInt(); // 0x0000000181C8DD40-0x0000000181C8DDC0
		public long ReadLong(); // 0x0000000181C8DDC0-0x0000000181C8DE40
		public ulong ReadULong(); // 0x0000000181C8DDC0-0x0000000181C8DE40
		public void Flush(); // 0x0000000181C8D750-0x0000000181C8D770
		public short ReadShortNetworkByteOrder(); // 0x0000000181C8E910-0x0000000181C8E9A0
		public ushort ReadUShortNetworkByteOrder(); // 0x0000000181C8E910-0x0000000181C8E9A0
		public int ReadIntNetworkByteOrder(); // 0x0000000181C8DCC0-0x0000000181C8DD40
		public uint ReadUIntNetworkByteOrder(); // 0x0000000181C8DCC0-0x0000000181C8DD40
		public float ReadFloat(); // 0x0000000181C8DC40-0x0000000181C8DCC0
		public double ReadDouble(); // 0x0000000181C8D900-0x0000000181C8D980
		public uint ReadPackedUInt([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E770-0x0000000181C8E820
		private uint ReadPackedUIntInternal(int maxSymbolLength, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E6A0-0x0000000181C8E770
		private void FillBitBuffer(); // 0x0000000181C8D710-0x0000000181C8D750
		private uint ReadRawBitsInternal(int numbits); // 0x0000000181C8E870-0x0000000181C8E8A0
		public uint ReadRawBits(int numbits); // 0x0000000181C8E8A0-0x0000000181C8E910
		public ulong ReadPackedULong([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E820-0x0000000181C8E870
		public int ReadPackedInt([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E5B0-0x0000000181C8E5D0
		public long ReadPackedLong([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E640-0x0000000181C8E6A0
		public float ReadPackedFloat([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E4F0-0x0000000181C8E580
		public double ReadPackedDouble([IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8DF50-0x0000000181C8E060
		public int ReadPackedIntDelta(int baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E580-0x0000000181C8E5B0
		public uint ReadPackedUIntDelta(uint baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E580-0x0000000181C8E5B0
		public long ReadPackedLongDelta(long baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E5D0-0x0000000181C8E640
		public ulong ReadPackedULongDelta(ulong baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E5D0-0x0000000181C8E640
		public float ReadPackedFloatDelta(float baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E460-0x0000000181C8E4F0
		public double ReadPackedDoubleDelta(double baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8DE40-0x0000000181C8DF50
		public FixedString32Bytes ReadFixedString32(); // 0x0000000181C8D9D0-0x0000000181C8DA10
		public FixedString64Bytes ReadFixedString64(); // 0x0000000181C8DAF0-0x0000000181C8DB30
		public FixedString128Bytes ReadFixedString128(); // 0x0000000181C8D980-0x0000000181C8D9D0
		public FixedString512Bytes ReadFixedString512(); // 0x0000000181C8DAA0-0x0000000181C8DAF0
		public FixedString4096Bytes ReadFixedString4096(); // 0x0000000181C8DA10-0x0000000181C8DAA0
		public ushort ReadFixedString(NativeArray<byte> array); // 0x0000000181C8DC30-0x0000000181C8DC40
		private unsafe ushort ReadFixedStringInternal(byte* data, int maxLength); // 0x0000000181C8DB30-0x0000000181C8DC30
		public FixedString32Bytes ReadPackedFixedString32Delta(FixedString32Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E0D0-0x0000000181C8E130
		public FixedString64Bytes ReadPackedFixedString64Delta(FixedString64Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E270-0x0000000181C8E2D0
		public FixedString128Bytes ReadPackedFixedString128Delta(FixedString128Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E060-0x0000000181C8E0D0
		public FixedString512Bytes ReadPackedFixedString512Delta(FixedString512Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E1F0-0x0000000181C8E270
		public FixedString4096Bytes ReadPackedFixedString4096Delta(FixedString4096Bytes baseline, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E130-0x0000000181C8E1F0
		public ushort ReadPackedFixedStringDelta(NativeArray<byte> data, NativeArray<byte> baseData, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E430-0x0000000181C8E460
		private unsafe ushort ReadPackedFixedStringDeltaInternal(byte* data, int maxLength, byte* baseData, ushort baseLength, [IsReadOnly] in StreamCompressionModel model); // 0x0000000181C8E2D0-0x0000000181C8E430
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		internal void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckBits(int numBits); // 0x0000000181C8D670-0x0000000181C8D710
	}
}
