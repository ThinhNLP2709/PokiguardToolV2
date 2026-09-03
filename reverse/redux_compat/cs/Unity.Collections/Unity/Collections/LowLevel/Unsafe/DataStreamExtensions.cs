/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility]
	public static class DataStreamExtensions // TypeDefIndex: 11675
	{
		// Methods
		public static unsafe DataStreamWriter Create(byte* data, int length); // 0x0000000181CA12A0-0x0000000181CA1300
	
		// Extension methods
		public static unsafe bool WriteBytesUnsafe(this ref DataStreamWriter writer, byte* data, int bytes); // 0x0000000181CA1440-0x0000000181CA1490
		public static unsafe void ReadBytesUnsafe(this ref DataStreamReader reader, byte* data, int length); // 0x0000000181CA1300-0x0000000181CA1350
		public static unsafe ushort ReadFixedStringUnsafe(this ref DataStreamReader reader, byte* data, int maxLength); // 0x0000000181CA1350-0x0000000181CA13A0
		public static unsafe ushort ReadPackedFixedStringDeltaUnsafe(this ref DataStreamReader reader, byte* data, int maxLength, byte* baseData, ushort baseLength, StreamCompressionModel model); // 0x0000000181CA13A0-0x0000000181CA1440
		public static unsafe void* GetUnsafeReadOnlyPtr(this ref DataStreamReader reader); // 0x00000001808BADD0-0x00000001808BADE0
	}
}
