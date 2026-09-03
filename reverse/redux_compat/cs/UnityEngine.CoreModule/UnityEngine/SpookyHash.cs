/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal static class SpookyHash // TypeDefIndex: 7643
	{
		// Nested types
		private struct U // TypeDefIndex: 7644
		{
			// Fields
			public unsafe byte* p8; // 0x00
			public unsafe uint* p32; // 0x00
			public unsafe ulong* p64; // 0x00
			public ulong i; // 0x00
	
			// Constructors
			public unsafe U(ushort* p8); // 0x0000000180CBE820-0x0000000180CBE830
		}
	
		// Methods
		public static unsafe void Hash(void* message, ulong length, ulong* hash1, ulong* hash2); // 0x00000001821D4BB0-0x00000001821D52A0
		private static unsafe void End(ulong* data, ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3, ref ulong h4, ref ulong h5, ref ulong h6, ref ulong h7, ref ulong h8, ref ulong h9, ref ulong h10, ref ulong h11); // 0x00000001821D49C0-0x00000001821D4BB0
		private static void EndPartial(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3, ref ulong h4, ref ulong h5, ref ulong h6, ref ulong h7, ref ulong h8, ref ulong h9, ref ulong h10, ref ulong h11); // 0x00000001821D47F0-0x00000001821D49C0
		private static void Rot64(ref ulong x, int k); // 0x00000001821CD220-0x00000001821CD240
		private static unsafe void Short(void* message, ulong length, ulong* hash1, ulong* hash2); // 0x00000001821D5690-0x00000001821D5C00
		private static void ShortMix(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3); // 0x00000001821D5520-0x00000001821D5690
		private static void ShortEnd(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3); // 0x00000001821CD240-0x00000001821CD390
		private static unsafe void Mix(ulong* data, ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4, ref ulong s5, ref ulong s6, ref ulong s7, ref ulong s8, ref ulong s9, ref ulong s10, ref ulong s11); // 0x00000001821D52A0-0x00000001821D5520
	}
}
