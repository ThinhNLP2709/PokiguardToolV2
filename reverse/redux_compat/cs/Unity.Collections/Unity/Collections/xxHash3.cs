/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[BurstCompile]
	[GenerateTestsForBurstCompatibility]
	[GenerateTestsForBurstCompatibility]
	[GenerateTestsForBurstCompatibility]
	public static class xxHash3 // TypeDefIndex: 11664
	{
		// Fields
		private const int STRIPE_LEN = 64; // Metadata: 0x006A1C94
		private const int ACC_NB = 8; // Metadata: 0x006A1C96
		private const int SECRET_CONSUME_RATE = 8; // Metadata: 0x006A1C97
		private const int SECRET_KEY_SIZE = 192; // Metadata: 0x006A1C98
		private const int SECRET_KEY_MIN_SIZE = 136; // Metadata: 0x006A1C9A
		private const int SECRET_LASTACC_START = 7; // Metadata: 0x006A1C9C
		private const int NB_ROUNDS = 16; // Metadata: 0x006A1C9D
		private const int BLOCK_LEN = 1024; // Metadata: 0x006A1C9E
		private const uint PRIME32_1 = 2654435761; // Metadata: 0x006A1CA0
		private const uint PRIME32_2 = 2246822519; // Metadata: 0x006A1CA5
		private const uint PRIME32_3 = 3266489917; // Metadata: 0x006A1CAA
		private const uint PRIME32_5 = 374761393; // Metadata: 0x006A1CAF
		private const ulong PRIME64_1 = 11400714785074694791; // Metadata: 0x006A1CB3
		private const ulong PRIME64_2 = 14029467366897019727; // Metadata: 0x006A1CBB
		private const ulong PRIME64_3 = 1609587929392839161; // Metadata: 0x006A1CC3
		private const ulong PRIME64_4 = 9650029242287828579; // Metadata: 0x006A1CCB
		private const ulong PRIME64_5 = 2870177450012600261; // Metadata: 0x006A1CD3
		private const int MIDSIZE_MAX = 240; // Metadata: 0x006A1CDB
		private const int MIDSIZE_STARTOFFSET = 3; // Metadata: 0x006A1CDD
		private const int MIDSIZE_LASTOFFSET = 17; // Metadata: 0x006A1CDE
		private const int SECRET_MERGEACCS_START = 11; // Metadata: 0x006A1CDF
	
		// Nested types
		[GenerateTestsForBurstCompatibility]
		public struct StreamingState // TypeDefIndex: 11665
		{
			// Fields
			private static readonly int SECRET_LIMIT; // 0x00
			private static readonly int NB_STRIPES_PER_BLOCK; // 0x04
			private static readonly int INTERNAL_BUFFER_SIZE; // 0x08
			private static readonly int INTERNAL_BUFFER_STRIPES; // 0x0C
			private StreamingStateData State; // 0x00
	
			// Properties
			private unsafe ulong* Acc { [DebuggerStepThrough] get; } // 0x0000000180370C60-0x0000000180370C70 
			private unsafe byte* Buffer { [DebuggerStepThrough] get; } // 0x0000000181CA89C0-0x0000000181CA89D0 
			private unsafe byte* SecretKey { [DebuggerStepThrough] get; } // 0x0000000181CA89D0-0x0000000181CA89E0 
	
			// Nested types
			private struct StreamingStateData // TypeDefIndex: 11666
			{
				// Fields
				public ulong Acc; // 0x00
				public byte Buffer; // 0x40
				public int IsHash64; // 0x140
				public int BufferedSize; // 0x144
				public int NbStripesSoFar; // 0x148
				public long TotalLength; // 0x150
				public ulong Seed; // 0x158
				public byte SecretKey; // 0x160
				public byte _PadEnd; // 0x21C
			}
	
			// Constructors
			public StreamingState(bool isHash64, ulong seed = 0 /* Metadata: 0x006A1CE0 */); // 0x0000000181CA8940-0x0000000181CA89C0
			static StreamingState(); // 0x0000000181CA88A0-0x0000000181CA8940
	
			// Methods
			public void Reset(bool isHash64, ulong seed = 0 /* Metadata: 0x006A1CE8 */); // 0x0000000181CA8520-0x0000000181CA86B0
			public unsafe void Update(void* input, int length); // 0x0000000181CA86B0-0x0000000181CA88A0
			[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
			public void Update<T>([IsReadOnly] in ref T input)
				where T : struct;
			public uint4 DigestHash128(); // 0x0000000181CA7DB0-0x0000000181CA7FC0
			public uint2 DigestHash64(); // 0x0000000181CA7FC0-0x0000000181CA8160
			private unsafe void DigestLong(ulong* acc, byte* secret, int isHash64); // 0x0000000181CA8160-0x0000000181CA8520
			private unsafe void ConsumeStripes(ulong* acc, ref int nbStripesSoFar, byte* input, long totalStripes, byte* secret, int isHash64); // 0x0000000181CA79B0-0x0000000181CA7DB0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void CheckKeySize(int isHash64); // 0x0000000181CA78F0-0x0000000181CA79B0
		}
	
		private struct ulong2 // TypeDefIndex: 11667
		{
			// Fields
			public ulong x; // 0x00
			public ulong y; // 0x08
	
			// Constructors
			public ulong2(ulong x, ulong y); // 0x0000000180C13E40-0x0000000180C13E50
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate ulong Hash64Long_00000ADA_PostfixBurstDelegate(byte* input, byte* dest, long length, byte* secret); // TypeDefIndex: 11668; 0x000000018043A200-0x000000018043A220
	
		internal static class Hash64Long_00000ADA_BurstDirectCall // TypeDefIndex: 11669
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181CA2040-0x0000000181CA2080
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000166a7); // 0x0000000181CA2080-0x0000000181CA21F0
			private static IntPtr GetFunctionPointer(); // 0x0000000181CA21F0-0x0000000181CA2350
			public static unsafe ulong Invoke(byte* input, byte* dest, long length, byte* secret); // 0x0000000181CA2350-0x0000000181CA2550
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void Hash128Long_00000AE1_PostfixBurstDelegate(byte* input, byte* dest, long length, byte* secret, out uint4 result); // TypeDefIndex: 11670; 0x000000018122C800-0x000000018122C820
	
		internal static class Hash128Long_00000AE1_BurstDirectCall // TypeDefIndex: 11671
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181CA19B0-0x0000000181CA19F0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000166bb); // 0x0000000181CA19F0-0x0000000181CA1B60
			private static IntPtr GetFunctionPointer(); // 0x0000000181CA1B60-0x0000000181CA1CC0
			public static unsafe void Invoke(byte* input, byte* dest, long length, byte* secret, out uint4 result); // 0x0000000181CA1CC0-0x0000000181CA1ED0
		}
	
		// Methods
		internal static unsafe void Avx2HashLongInternalLoop(ulong* acc, byte* input, byte* dest, long length, byte* secret, int isHash64); // 0x0000000181CADAF0-0x0000000181CADDA0
		internal static unsafe void Avx2ScrambleAcc(ulong* acc, byte* secret); // 0x0000000181CADDA0-0x0000000181CAE250
		internal static unsafe void Avx2Accumulate(ulong* acc, byte* input, byte* dest, byte* secret, long nbStripes, int isHash64); // 0x0000000181CAD9F0-0x0000000181CADAF0
		internal static unsafe void Avx2Accumulate512(ulong* acc, byte* input, byte* dest, byte* secret); // 0x0000000181CAD600-0x0000000181CAD9F0
		public static unsafe uint2 Hash64(void* input, long length); // 0x0000000181CB0610-0x0000000181CB06C0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static uint2 Hash64<T>([IsReadOnly] in ref T input)
			where T : struct;
		public static unsafe uint2 Hash64(void* input, long length, ulong seed); // 0x0000000181CB06C0-0x0000000181CB0780
		public static unsafe uint4 Hash128(void* input, long length); // 0x0000000181CAFAB0-0x0000000181CAFB60
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static uint4 Hash128<T>([IsReadOnly] in ref T input)
			where T : struct;
		public static unsafe uint4 Hash128(void* input, void* destination, long length); // 0x0000000181CAF9F0-0x0000000181CAFAB0
		public static unsafe uint4 Hash128(void* input, long length, ulong seed); // 0x0000000181CAF930-0x0000000181CAF9F0
		public static unsafe uint4 Hash128(void* input, void* destination, long length, ulong seed); // 0x0000000181CAFB60-0x0000000181CAFC30
		internal static unsafe ulong Hash64Internal(byte* input, byte* dest, long length, byte* secret, ulong seed); // 0x0000000181CAFC30-0x0000000181CAFEF0
		internal static unsafe void Hash128Internal(byte* input, byte* dest, long length, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAEA00-0x0000000181CAEBA0
		private static unsafe ulong Hash64Len1To3(byte* input, long len, byte* secret, ulong seed); // 0x0000000181CB0470-0x0000000181CB04F0
		private static unsafe ulong Hash64Len4To8(byte* input, long length, byte* secret, ulong seed); // 0x0000000181CB04F0-0x0000000181CB0580
		private static unsafe ulong Hash64Len9To16(byte* input, long length, byte* secret, ulong seed); // 0x0000000181CB0580-0x0000000181CB0610
		private static unsafe ulong Hash64Len0To16(byte* input, long length, byte* secret, ulong seed); // 0x0000000181CAFEF0-0x0000000181CB00D0
		private static unsafe ulong Hash64Len17To128(byte* input, long length, byte* secret, ulong seed); // 0x0000000181CB0260-0x0000000181CB0470
		private static unsafe ulong Hash64Len129To240(byte* input, long length, byte* secret, ulong seed); // 0x0000000181CB00D0-0x0000000181CB0260
		[BurstCompile]
		private static unsafe ulong Hash64Long(byte* input, byte* dest, long length, byte* secret); // 0x0000000181CA2350-0x0000000181CA2550
		private static unsafe void Hash128Len1To3(byte* input, long length, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAF620-0x0000000181CAF720
		private static unsafe void Hash128Len4To8(byte* input, long len, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAF720-0x0000000181CAF800
		private static unsafe void Hash128Len9To16(byte* input, long len, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAF800-0x0000000181CAF930
		private static unsafe void Hash128Len0To16(byte* input, long length, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAEBA0-0x0000000181CAEEE0
		private static unsafe void Hash128Len17To128(byte* input, long length, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAF2E0-0x0000000181CAF620
		private static unsafe void Hash128Len129To240(byte* input, long length, byte* secret, ulong seed, out uint4 result); // 0x0000000181CAEEE0-0x0000000181CAF2E0
		[BurstCompile]
		private static unsafe void Hash128Long(byte* input, byte* dest, long length, byte* secret, out uint4 result); // 0x0000000181CA1CC0-0x0000000181CA1ED0
		internal static uint2 ToUint2(ulong u); // 0x0000000181CB0A50-0x0000000181CB0A70
		internal static uint4 ToUint4(ulong ul0, ulong ul1); // 0x0000000181CB0A70-0x0000000181CB0A90
		internal static unsafe void EncodeSecretKey(byte* dst, byte* secret, ulong seed); // 0x0000000181CAE9C0-0x0000000181CAEA00
		private static unsafe ulong Read64LE(void* addr); // 0x00000001808BADD0-0x00000001808BADE0
		private static unsafe uint Read32LE(void* addr); // 0x0000000180732D10-0x0000000180732D20
		private static unsafe void Write64LE(void* addr, ulong value); // 0x0000000180CBE820-0x0000000180CBE830
		private static ulong Mul32To64(uint x, uint y); // 0x0000000181604620-0x0000000181604630
		private static ulong Swap64(ulong x); // 0x0000000181CB0A40-0x0000000181CB0A50
		private static uint Swap32(uint x); // 0x00000001815A6F20-0x00000001815A6F30
		private static uint RotL32(uint x, int r); // 0x00000001815FB690-0x00000001815FB6B0
		private static ulong RotL64(ulong x, int r); // 0x0000000181CB0A20-0x0000000181CB0A40
		private static ulong XorShift64(ulong v64, int shift); // 0x0000000181CB0A90-0x0000000181CB0AB0
		private static ulong Mul128Fold64(ulong lhs, ulong rhs); // 0x0000000181CB09F0-0x0000000181CB0A20
		private static unsafe ulong Mix16(byte* input, byte* secret, ulong seed); // 0x0000000181CB0890-0x0000000181CB08D0
		private static unsafe ulong2 Mix32(ulong2 acc, byte* input_1, byte* input_2, byte* secret, ulong seed); // 0x0000000181CB0900-0x0000000181CB09F0
		private static ulong Avalanche(ulong h64); // 0x0000000181CAD5D0-0x0000000181CAD600
		private static ulong AvalancheH64(ulong h64); // 0x0000000181CAD590-0x0000000181CAD5D0
		private static ulong rrmxmx(ulong h64, ulong length); // 0x0000000181CB0AB0-0x0000000181CB0B10
		private static unsafe ulong Mix2Acc(ulong acc0, ulong acc1, byte* secret); // 0x0000000181CB08D0-0x0000000181CB0900
		internal static unsafe ulong MergeAcc(ulong* acc, byte* secret, ulong start); // 0x0000000181CB0780-0x0000000181CB0890
		private static unsafe void DefaultHashLongInternalLoop(ulong* acc, byte* input, byte* dest, long length, byte* secret, int isHash64); // 0x0000000181CAE590-0x0000000181CAE8E0
		internal static unsafe void DefaultAccumulate(ulong* acc, byte* input, byte* dest, byte* secret, long nbStripes, int isHash64); // 0x0000000181CAE3B0-0x0000000181CAE590
		internal static unsafe void DefaultAccumulate512(ulong* acc, byte* input, byte* dest, byte* secret, int isHash64); // 0x0000000181CAE250-0x0000000181CAE3B0
		internal static unsafe void DefaultScrambleAcc(ulong* acc, byte* secret); // 0x0000000181CAE8E0-0x0000000181CAE9C0
		[BurstCompile]
		[MonoPInvokeCallback(typeof(Hash64Long_00000ADA_PostfixBurstDelegate))]
		internal static unsafe ulong Hash64Long_BurstManaged(byte* input, byte* dest, long length, byte* secret); // 0x0000000181CA0CB0-0x0000000181CA0DF0
		[BurstCompile]
		[MonoPInvokeCallback(typeof(Hash128Long_00000AE1_PostfixBurstDelegate))]
		internal static unsafe void Hash128Long_BurstManaged(byte* input, byte* dest, long length, byte* secret, out uint4 result); // 0x0000000181CA0B30-0x0000000181CA0CB0
	}
}
