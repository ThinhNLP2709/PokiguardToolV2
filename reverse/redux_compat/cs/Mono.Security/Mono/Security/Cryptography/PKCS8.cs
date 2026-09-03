/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Cryptography
{
	public sealed class PKCS8 // TypeDefIndex: 13883
	{
		// Nested types
		public class PrivateKeyInfo // TypeDefIndex: 13884
		{
			// Fields
			private int _version; // 0x10
			private string _algorithm; // 0x18
			private byte[] _key; // 0x20
			private ArrayList _list; // 0x28
	
			// Properties
			public string Algorithm { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public byte[] PrivateKey { get; set; } // 0x0000000181427AA0-0x0000000181427B20 0x0000000181427B20-0x0000000181427C20
	
			// Constructors
			public PrivateKeyInfo(); // 0x00000001814279A0-0x0000000181427A10
			public PrivateKeyInfo(byte[] data); // 0x0000000181427A10-0x0000000181427AA0
	
			// Methods
			private void Decode(byte[] data); // 0x0000000181426CD0-0x0000000181426FD0
			public byte[] GetBytes(); // 0x0000000181427440-0x0000000181427840
			private static byte[] RemoveLeadingZero(byte[] bigInt); // 0x00000001814278F0-0x00000001814279A0
			private static byte[] Normalize(byte[] bigInt, int length); // 0x0000000181427840-0x00000001814278F0
			public static RSA DecodeRSA(byte[] keypair); // 0x00000001814267D0-0x0000000181426CD0
			public static byte[] Encode(RSA rsa); // 0x0000000181427030-0x0000000181427260
			public static DSA DecodeDSA(byte[] privateKey, DSAParameters dsaParameters); // 0x0000000181426610-0x00000001814267D0
			public static byte[] Encode(DSA dsa); // 0x0000000181426FD0-0x0000000181427030
			public static byte[] Encode(AsymmetricAlgorithm aa); // 0x0000000181427260-0x0000000181427440
		}
	
		public class EncryptedPrivateKeyInfo // TypeDefIndex: 13885
		{
			// Fields
			private string _algorithm; // 0x10
			private byte[] _salt; // 0x18
			private int _iterations; // 0x20
			private byte[] _data; // 0x28
	
			// Properties
			public string Algorithm { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public byte[] EncryptedData { get; set; } // 0x000000018141EC10-0x000000018141EC90 0x000000018141ED60-0x000000018141EE00
			public byte[] Salt { get; } // 0x000000018141EC90-0x000000018141ED60 
			public int IterationCount { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x000000018141EE00-0x000000018141EE80
	
			// Constructors
			public EncryptedPrivateKeyInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
			public EncryptedPrivateKeyInfo(byte[] data); // 0x000000018141EBE0-0x000000018141EC10
	
			// Methods
			private void Decode(byte[] data); // 0x000000018141E630-0x000000018141E9E0
			public byte[] GetBytes(); // 0x000000018141E9E0-0x000000018141EBE0
		}
	}
}
