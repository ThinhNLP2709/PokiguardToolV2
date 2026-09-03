/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security.Cryptography
{
	internal sealed class PKCS1 // TypeDefIndex: 2131
	{
		// Fields
		private static byte[] emptySHA1; // 0x00
		private static byte[] emptySHA256; // 0x08
		private static byte[] emptySHA384; // 0x10
		private static byte[] emptySHA512; // 0x18
	
		// Constructors
		static PKCS1(); // 0x000000018144D9F0-0x000000018144DBB0
	
		// Methods
		private static bool Compare(byte[] array1, byte[] array2); // 0x0000000181424850-0x00000001814248E0
		public static byte[] I2OSP(byte[] x, int size); // 0x000000018144D3A0-0x000000018144D420
		public static byte[] OS2IP(byte[] x); // 0x000000018144D420-0x000000018144D4F0
		public static byte[] RSAVP1(RSA rsa, byte[] s); // 0x00000001814256E0-0x0000000181425710
		public static bool Verify_v15(RSA rsa, HashAlgorithm hash, byte[] hashValue, byte[] signature); // 0x000000018144D960-0x000000018144D9F0
		internal static bool Verify_v15(RSA rsa, string hashName, byte[] hashValue, byte[] signature); // 0x000000018144D840-0x000000018144D960
		public static bool Verify_v15(RSA rsa, HashAlgorithm hash, byte[] hashValue, byte[] signature, bool tryNonStandardEncoding); // 0x000000018144D4F0-0x000000018144D840
		public static byte[] Encode_v15(HashAlgorithm hash, byte[] hashValue, int emLength); // 0x000000018144D060-0x000000018144D3A0
		internal static HashAlgorithm CreateFromName(string name); // 0x000000018144C9D0-0x000000018144D060
	}
}
