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
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	[DefaultMember("Item")]
	public class X509Crl // TypeDefIndex: 13820
	{
		// Fields
		private string issuer; // 0x10
		private byte version; // 0x18
		private DateTime thisUpdate; // 0x20
		private DateTime nextUpdate; // 0x28
		private ArrayList entries; // 0x30
		private string signatureOID; // 0x38
		private byte[] signature; // 0x40
		private X509ExtensionCollection extensions; // 0x48
		private byte[] encoded; // 0x50
		private byte[] hash_value; // 0x58
	
		// Properties
		public X509ExtensionCollection Extensions { get; } // 0x00000001803272B0-0x00000001803272C0 
		public byte[] Hash { get; } // 0x0000000181416780-0x0000000181416920 
		public string IssuerName { get; } // 0x0000000180377550-0x0000000180377560 
		public DateTime NextUpdate { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		public class X509CrlEntry // TypeDefIndex: 13821
		{
			// Fields
			private byte[] sn; // 0x10
			private DateTime revocationDate; // 0x18
			private X509ExtensionCollection extensions; // 0x20
	
			// Properties
			public byte[] SerialNumber { get; } // 0x0000000181415540-0x00000001814155C0 
			public DateTime RevocationDate { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public X509ExtensionCollection Extensions { get; } // 0x00000001802F8630-0x00000001802F8640 
	
			// Constructors
			internal X509CrlEntry(ASN1 entry); // 0x0000000181415430-0x0000000181415540
		}
	
		// Constructors
		public X509Crl(byte[] crl); // 0x0000000181416660-0x0000000181416780
	
		// Methods
		private void Parse(byte[] crl); // 0x0000000181415870-0x0000000181415FD0
		private bool Compare(byte[] array1, byte[] array2); // 0x0000000181411CC0-0x0000000181411D30
		public X509CrlEntry GetCrlEntry(X509Certificate x509); // 0x00000001814155C0-0x0000000181415650
		public X509CrlEntry GetCrlEntry(byte[] serialNumber); // 0x0000000181415650-0x0000000181415870
		internal bool VerifySignature(DSA dsa); // 0x0000000181416360-0x0000000181416660
		internal bool VerifySignature(RSA rsa); // 0x0000000181416280-0x0000000181416360
		public bool VerifySignature(AsymmetricAlgorithm aa); // 0x0000000181415FD0-0x0000000181416280
	}
}
