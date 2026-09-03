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
using Mono.Math;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Cryptography
{
	public class RSAManaged : RSA // TypeDefIndex: 13886
	{
		// Fields
		private bool isCRTpossible; // 0x20
		private bool keyBlinding; // 0x21
		private bool keypairGenerated; // 0x22
		private bool m_disposed; // 0x23
		private BigInteger d; // 0x28
		private BigInteger p; // 0x30
		private BigInteger q; // 0x38
		private BigInteger dp; // 0x40
		private BigInteger dq; // 0x48
		private BigInteger qInv; // 0x50
		private BigInteger n; // 0x58
		private BigInteger e; // 0x60
		[CompilerGenerated]
		private KeyGeneratedEventHandler KeyGenerated; // 0x68
	
		// Properties
		public override int KeySize { get; } // 0x0000000181429990-0x0000000181429A40 
		public bool PublicOnly { get; } // 0x0000000181429A40-0x0000000181429AD0 
	
		// Nested types
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e); // TypeDefIndex: 13887; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		public RSAManaged(); // 0x00000001814297B0-0x00000001814298A0
		public RSAManaged(int keySize); // 0x00000001814298A0-0x0000000181429990
	
		// Methods
		~RSAManaged(); // 0x0000000181428550-0x00000001814285D0
		private void GenerateKeyPair(); // 0x00000001814285D0-0x0000000181428AA0
		public override byte[] EncryptValue(byte[] rgb); // 0x0000000181427FA0-0x00000001814281A0
		public override RSAParameters ExportParameters(bool includePrivateParameters); // 0x00000001814281A0-0x0000000181428550
		public override void ImportParameters(RSAParameters parameters); // 0x0000000181428B50-0x0000000181429220
		protected override void Dispose(bool disposing); // 0x0000000181427C20-0x0000000181427FA0
		public override string ToXmlString(bool includePrivateParameters); // 0x0000000181429220-0x00000001814297B0
		private byte[] GetPaddedValue(BigInteger value, int length); // 0x0000000181428AA0-0x0000000181428B50
	}
}
