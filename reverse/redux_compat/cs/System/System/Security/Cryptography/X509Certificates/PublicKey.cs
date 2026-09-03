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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	public sealed class PublicKey // TypeDefIndex: 8773
	{
		// Fields
		private AsnEncodedData _keyValue; // 0x10
		private AsnEncodedData _params; // 0x18
		private Oid _oid; // 0x20
		private static byte[] Empty; // 0x00
	
		// Properties
		public AsnEncodedData EncodedKeyValue { get; } // 0x0000000180377550-0x0000000180377560 
		public AsnEncodedData EncodedParameters { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public AsymmetricAlgorithm Key { get; } // 0x0000000181B91340-0x0000000181B91500 
		public Oid Oid { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		public PublicKey(Oid oid, AsnEncodedData parameters, AsnEncodedData keyValue); // 0x0000000181B91150-0x0000000181B91340
		static PublicKey(); // 0x0000000181B910E0-0x0000000181B91150
	
		// Methods
		private static byte[] GetUnsignedBigInteger(byte[] integer); // 0x0000000181B91040-0x0000000181B910E0
		internal static DSA DecodeDSA(byte[] rawPublicKey, byte[] rawParameters); // 0x0000000181B907E0-0x0000000181B90CE0
		internal static RSA DecodeRSA(byte[] rawPublicKey); // 0x0000000181B90CE0-0x0000000181B91040
	}
}
