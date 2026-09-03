/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	internal static class Utils // TypeDefIndex: 2837
	{
		// Fields
		private static RNGCryptoServiceProvider _rng; // 0x00
	
		// Properties
		internal static RNGCryptoServiceProvider StaticRandomNumberGenerator { get; } // 0x00000001814AD7A0-0x00000001814ADBD0 
	
		// Methods
		internal static byte[] GenerateRandom(int keySize); // 0x00000001814AD530-0x00000001814AD5A0
		internal static bool HasAlgorithm(int dwCalg, int dwKeySize); // 0x00000001802E7990-0x00000001802E79A0
		internal static string DiscardWhiteSpaces(string inputBuffer); // 0x00000001814AD270-0x00000001814AD2A0
		internal static string DiscardWhiteSpaces(string inputBuffer, int inputOffset, int inputCount); // 0x00000001814AD2A0-0x00000001814AD460
		internal static int ConvertByteArrayToInt(byte[] input); // 0x00000001814ACEA0-0x00000001814ACEF0
		internal static byte[] ConvertIntToByteArray(int dwInput); // 0x00000001814ACEF0-0x00000001814AD010
		internal static byte[] FixupKeyParity(byte[] key); // 0x00000001814AD460-0x00000001814AD530
		internal static unsafe void DWORDFromLittleEndian(uint* x, int digits, byte* block); // 0x00000001814AD060-0x00000001814AD0B0
		internal static void DWORDToLittleEndian(byte[] block, uint[] x, int digits); // 0x00000001814AD190-0x00000001814AD270
		internal static unsafe void DWORDFromBigEndian(uint* x, int digits, byte* block); // 0x00000001814AD010-0x00000001814AD060
		internal static void DWORDToBigEndian(byte[] block, uint[] x, int digits); // 0x00000001814AD0B0-0x00000001814AD190
		internal static unsafe void QuadWordFromBigEndian(ulong* x, int digits, byte* block); // 0x00000001814AD5A0-0x00000001814AD630
		internal static void QuadWordToBigEndian(byte[] block, ulong[] x, int digits); // 0x00000001814AD630-0x00000001814AD7A0
		internal static bool _ProduceLegacyHmacValues(); // 0x00000001802E7840-0x00000001802E7850
	}
}
