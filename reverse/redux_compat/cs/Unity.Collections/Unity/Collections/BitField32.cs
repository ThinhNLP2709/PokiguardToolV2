/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerTypeProxy(typeof(BitField32DebugView))]
	[GenerateTestsForBurstCompatibility]
	public struct BitField32 // TypeDefIndex: 11474
	{
		// Fields
		public uint Value; // 0x00
	
		// Constructors
		public BitField32(uint initialValue = 0 /* Metadata: 0x006A1BC8 */); // 0x0000000180732D50-0x0000000180732D60
	
		// Methods
		public void Clear(); // 0x00000001812C86B0-0x00000001812C86C0
		public void SetBits(int pos, bool value); // 0x0000000181C8A780-0x0000000181C8A7B0
		public void SetBits(int pos, bool value, int numBits); // 0x0000000181C8A7B0-0x0000000181C8A7F0
		public uint GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1BC9 */); // 0x0000000181C8A750-0x0000000181C8A770
		public bool IsSet(int pos); // 0x0000000181C8A770-0x0000000181C8A780
		public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1BCA */); // 0x0000000181C8A850-0x0000000181C8A880
		public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1BCB */); // 0x0000000181C8A820-0x0000000181C8A850
		public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1BCC */); // 0x0000000181C8A7F0-0x0000000181C8A820
		public int CountBits(); // 0x0000000181C8A670-0x0000000181C8A6B0
		public int CountLeadingZeros(); // 0x0000000181C8A6B0-0x0000000181C8A700
		public int CountTrailingZeros(); // 0x0000000181C8A700-0x0000000181C8A750
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckArgs(int pos, int numBits); // 0x0000000181C8A5B0-0x0000000181C8A670
	}
}
