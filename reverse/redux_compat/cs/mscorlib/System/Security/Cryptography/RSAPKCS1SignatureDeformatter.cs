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
	[ComVisible(true)]
	public class RSAPKCS1SignatureDeformatter : AsymmetricSignatureDeformatter // TypeDefIndex: 2844
	{
		// Fields
		private RSA rsa; // 0x10
		private string hashName; // 0x18
	
		// Constructors
		public RSAPKCS1SignatureDeformatter(); // 0x00000001802F4070-0x00000001802F4080
		public RSAPKCS1SignatureDeformatter(AsymmetricAlgorithm key); // 0x00000001814A4320-0x00000001814A4360
	
		// Methods
		public override void SetHashAlgorithm(string strName); // 0x00000001814A3FB0-0x00000001814A4020
		public override void SetKey(AsymmetricAlgorithm key); // 0x00000001814A4020-0x00000001814A4130
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature); // 0x00000001814A4130-0x00000001814A4320
	}
}
