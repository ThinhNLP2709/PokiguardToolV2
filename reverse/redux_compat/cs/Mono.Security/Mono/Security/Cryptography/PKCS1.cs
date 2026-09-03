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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Cryptography
{
	public sealed class PKCS1 // TypeDefIndex: 13882
	{
		// Fields
		private static byte[] emptySHA1; // 0x00
		private static byte[] emptySHA256; // 0x08
		private static byte[] emptySHA384; // 0x10
		private static byte[] emptySHA512; // 0x18
	
		// Constructors
		static PKCS1(); // 0x0000000181425A60-0x0000000181425C20
	
		// Methods
		private static bool Compare(byte[] array1, byte[] array2); // 0x0000000181424850-0x00000001814248E0
		public static byte[] I2OSP(byte[] x, int size); // 0x0000000181425590-0x0000000181425610
		public static byte[] OS2IP(byte[] x); // 0x0000000181425610-0x00000001814256E0
		public static byte[] RSAVP1(RSA rsa, byte[] s); // 0x00000001814256E0-0x0000000181425710
		public static bool Verify_v15(RSA rsa, HashAlgorithm hash, byte[] hashValue, byte[] signature, bool tryNonStandardEncoding); // 0x0000000181425710-0x0000000181425A60
		public static byte[] Encode_v15(HashAlgorithm hash, byte[] hashValue, int emLength); // 0x0000000181424E80-0x00000001814251C0
		internal static string HashNameFromOid(string oid, bool throwOnError = true /* Metadata: 0x006A818A */); // 0x00000001814251C0-0x0000000181425590
		internal static HashAlgorithm CreateFromOid(string oid); // 0x0000000181424E20-0x0000000181424E80
		internal static HashAlgorithm CreateFromName(string name); // 0x00000001814248E0-0x0000000181424E20
	}
}
