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
	public struct UnsafeAtomicCounter32 // TypeDefIndex: 11682
	{
		// Fields
		public unsafe int* Counter; // 0x00
	
		// Constructors
		public unsafe UnsafeAtomicCounter32(void* ptr); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public void Reset(int value = 0 /* Metadata: 0x006A1CF0 */); // 0x0000000180C52420-0x0000000180C52430
		public int Add(int value); // 0x0000000181CAA870-0x0000000181CAA890
		public int Sub(int value); // 0x0000000181CAA8E0-0x0000000181CAA900
		public int AddSat(int value, int max = 2147483647 /* Metadata: 0x006A1CF1 */); // 0x0000000181CAA820-0x0000000181CAA870
		public int SubSat(int value, int min = 2147483647 /* Metadata: 0x006A1CF2 */); // 0x0000000181CAA890-0x0000000181CAA8E0
	}
}
