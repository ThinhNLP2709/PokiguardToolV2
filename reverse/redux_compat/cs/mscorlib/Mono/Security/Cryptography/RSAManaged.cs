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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security.Cryptography
{
	internal class RSAManaged : RSA // TypeDefIndex: 2132
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
		public override int KeySize { get; } // 0x00000001814500E0-0x0000000181450190 
		public bool PublicOnly { get; } // 0x0000000181450190-0x0000000181450220 
	
		// Events
		public event KeyGeneratedEventHandler KeyGenerated {
			add; // 0x0000000181450040-0x00000001814500E0
			remove; // 0x0000000181450220-0x00000001814502C0
		}
	
		// Nested types
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e); // TypeDefIndex: 2133; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		public RSAManaged(int keySize); // 0x000000018144FF50-0x0000000181450040
	
		// Methods
		~RSAManaged(); // 0x0000000181428550-0x00000001814285D0
		private void GenerateKeyPair(); // 0x000000018144ED70-0x000000018144F240
		public override byte[] EncryptValue(byte[] rgb); // 0x000000018144E820-0x000000018144E9C0
		public override RSAParameters ExportParameters(bool includePrivateParameters); // 0x000000018144E9C0-0x000000018144ED70
		public override void ImportParameters(RSAParameters parameters); // 0x000000018144F2F0-0x000000018144F9C0
		protected override void Dispose(bool disposing); // 0x000000018144E4A0-0x000000018144E820
		public override string ToXmlString(bool includePrivateParameters); // 0x000000018144F9C0-0x000000018144FF50
		private byte[] GetPaddedValue(BigInteger value, int length); // 0x000000018144F240-0x000000018144F2F0
	}
}
