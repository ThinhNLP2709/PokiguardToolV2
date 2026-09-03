/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerTypeProxy(typeof(BitField64DebugView))]
	[GenerateTestsForBurstCompatibility]
	public struct BitField64 // TypeDefIndex: 11476
	{
		// Fields
		public ulong Value; // 0x00
	
		// Constructors
		public BitField64(ulong initialValue = 0 /* Metadata: 0x006A1BCD */); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public void Clear(); // 0x000000018145EC40-0x000000018145EC50
		public void SetBits(int pos, bool value); // 0x0000000181C8AB50-0x0000000181C8AB80
		public void SetBits(int pos, bool value, int numBits = 1 /* Metadata: 0x006A1BD5 */); // 0x0000000181C8AB80-0x0000000181C8ABC0
		public ulong GetBits(int pos, int numBits = 1 /* Metadata: 0x006A1BD6 */); // 0x0000000181C8AB00-0x0000000181C8AB30
		public bool IsSet(int pos); // 0x0000000181C8AB30-0x0000000181C8AB50
		public bool TestNone(int pos, int numBits = 1 /* Metadata: 0x006A1BD7 */); // 0x0000000181C8AC20-0x0000000181C8AC50
		public bool TestAny(int pos, int numBits = 1 /* Metadata: 0x006A1BD8 */); // 0x0000000181C8ABF0-0x0000000181C8AC20
		public bool TestAll(int pos, int numBits = 1 /* Metadata: 0x006A1BD9 */); // 0x0000000181C8ABC0-0x0000000181C8ABF0
		public int CountBits(); // 0x0000000181C8A9D0-0x0000000181C8AA30
		public int CountLeadingZeros(); // 0x0000000181C8AA30-0x0000000181C8AA90
		public int CountTrailingZeros(); // 0x0000000181C8AA90-0x0000000181C8AB00
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckArgs(int pos, int numBits); // 0x0000000181C8A910-0x0000000181C8A9D0
	}
}
