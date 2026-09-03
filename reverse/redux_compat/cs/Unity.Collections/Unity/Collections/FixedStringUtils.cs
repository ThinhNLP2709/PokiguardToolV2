/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal static class FixedStringUtils // TypeDefIndex: 11542
	{
		// Nested types
		internal struct UintFloatUnion // TypeDefIndex: 11543
		{
			// Fields
			public uint uintValue; // 0x00
			public float floatValue; // 0x00
		}
	
		// Methods
		internal static ParseError Base10ToBase2(ref float output, ulong mantissa10, int exponent10); // 0x0000000181CA1740-0x0000000181CA1880
		internal static void Base2ToBase10(ref ulong mantissa10, ref int exponent10, float input); // 0x0000000181CA1880-0x0000000181CA19B0
	}
}
