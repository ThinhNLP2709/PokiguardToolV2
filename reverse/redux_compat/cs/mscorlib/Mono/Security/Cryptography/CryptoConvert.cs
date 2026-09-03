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
	internal sealed class CryptoConvert // TypeDefIndex: 2124
	{
		// Methods
		private static int ToInt32LE(byte[] bytes, int offset); // 0x0000000181444FD0-0x0000000181445050
		private static uint ToUInt32LE(byte[] bytes, int offset); // 0x0000000181444FD0-0x0000000181445050
		private static byte[] Trim(byte[] array); // 0x0000000181445050-0x0000000181445110
		public static RSA FromCapiPrivateKeyBlob(byte[] blob, int offset); // 0x0000000181444250-0x0000000181444300
		private static RSAParameters GetParametersFromCapiPrivateKeyBlob(byte[] blob, int offset); // 0x0000000181444430-0x0000000181444B10
		public static RSA FromCapiPublicKeyBlob(byte[] blob, int offset); // 0x0000000181444300-0x0000000181444430
		private static RSAParameters GetParametersFromCapiPublicKeyBlob(byte[] blob, int offset); // 0x0000000181444B10-0x0000000181444FD0
		public static RSA FromCapiKeyBlob(byte[] blob); // 0x0000000181444040-0x0000000181444050
		public static RSA FromCapiKeyBlob(byte[] blob, int offset); // 0x0000000181444050-0x0000000181444250
	}
}
