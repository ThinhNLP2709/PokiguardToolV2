/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Burst;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst.Intrinsics
{
	[BurstCompile]
	public static class X86 // TypeDefIndex: 15035
	{
		// Nested types
		public static class Avx // TypeDefIndex: 15036
		{
			// Methods
			[DebuggerStepThrough]
			public static unsafe v256 mm256_load_ps(void* ptr); // 0x0000000181325CE0-0x0000000181325D00
			[DebuggerStepThrough]
			public static unsafe void mm256_store_ps(void* ptr, v256 val); // 0x000000018216DD60-0x000000018216DD70
			[DebuggerStepThrough]
			public static unsafe v256 mm256_loadu_si256(void* ptr); // 0x0000000181325CE0-0x0000000181325D00
			[DebuggerStepThrough]
			public static unsafe void mm256_storeu_si256(void* ptr, v256 v); // 0x000000018216DD60-0x000000018216DD70
			[DebuggerStepThrough]
			public static v256 mm256_set1_epi32(int a); // 0x000000018216DD40-0x000000018216DD60
		}
	
		public static class Avx2 // TypeDefIndex: 15037
		{
			// Properties
			public static bool IsAvx2Supported { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Methods
			[DebuggerStepThrough]
			public static v256 mm256_xor_si256(v256 a, v256 b); // 0x000000018216DCE0-0x000000018216DD40
			[DebuggerStepThrough]
			public static v256 mm256_add_epi64(v256 a, v256 b); // 0x000000018216D8E0-0x000000018216D940
			[DebuggerStepThrough]
			public static v256 mm256_mul_epu32(v256 a, v256 b); // 0x000000018216D940-0x000000018216D9B0
			[DebuggerStepThrough]
			public static v256 mm256_slli_epi64(v256 a, int imm8); // 0x000000018216DA70-0x000000018216DB90
			[DebuggerStepThrough]
			public static v256 mm256_srli_epi64(v256 a, int imm8); // 0x000000018216DB90-0x000000018216DCE0
			[DebuggerStepThrough]
			public static v256 mm256_shuffle_epi32(v256 a, int imm8); // 0x000000018216D9B0-0x000000018216DA70
		}
	
		public static class Sse // TypeDefIndex: 15038
		{
			// Methods
			public static int SHUFFLE(int d, int c, int b, int a); // 0x0000000182174A30-0x0000000182174A60
		}
	
		public static class Sse2 // TypeDefIndex: 15039
		{
			// Methods
			[DebuggerStepThrough]
			public static v128 add_epi64(v128 a, v128 b); // 0x0000000182174840-0x0000000182174860
			[DebuggerStepThrough]
			public static v128 mul_epu32(v128 a, v128 b); // 0x0000000182174860-0x0000000182174880
			[DebuggerStepThrough]
			public static v128 slli_epi64(v128 a, int imm8); // 0x00000001821748D0-0x0000000182174970
			[DebuggerStepThrough]
			public static v128 srli_epi64(v128 a, int imm8); // 0x0000000182174970-0x0000000182174A10
			[DebuggerStepThrough]
			public static v128 xor_si128(v128 a, v128 b); // 0x0000000182174A10-0x0000000182174A30
			[DebuggerStepThrough]
			public static v128 shuffle_epi32(v128 a, int imm8); // 0x0000000182174880-0x00000001821748D0
		}
	}
}
