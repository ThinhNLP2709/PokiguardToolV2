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
	public struct UnsafeAtomicCounter64 // TypeDefIndex: 11683
	{
		// Fields
		public unsafe long* Counter; // 0x00
	
		// Constructors
		public unsafe UnsafeAtomicCounter64(void* ptr); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public void Reset(long value = 0 /* Metadata: 0x006A1CF3 */); // 0x0000000181CAA970-0x0000000181CAA980
		public long Add(long value); // 0x0000000181CAA950-0x0000000181CAA970
		public long Sub(long value); // 0x0000000181CAA9D0-0x0000000181CAAA00
		public long AddSat(long value, long max = 9223372036854775807 /* Metadata: 0x006A1CFB */); // 0x0000000181CAA900-0x0000000181CAA950
		public long SubSat(long value, long min = -9223372036854775808 /* Metadata: 0x006A1D03 */); // 0x0000000181CAA980-0x0000000181CAA9D0
	}
}
