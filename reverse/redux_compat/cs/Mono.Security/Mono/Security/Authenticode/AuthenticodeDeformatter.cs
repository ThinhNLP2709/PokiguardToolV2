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
using Mono.Security;
using Mono.Security.X509;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Authenticode
{
	public class AuthenticodeDeformatter : AuthenticodeBase // TypeDefIndex: 13889
	{
		// Fields
		private string filename; // 0x40
		private byte[] rawdata; // 0x48
		private byte[] hash; // 0x50
		private X509CertificateCollection coll; // 0x58
		private ASN1 signedHash; // 0x60
		private DateTime timestamp; // 0x68
		private X509Certificate signingCertificate; // 0x70
		private int reason; // 0x78
		private bool trustedRoot; // 0x7C
		private bool trustedTimestampRoot; // 0x7D
		private byte[] entry; // 0x80
		private X509Chain signerChain; // 0x88
		private X509Chain timestampChain; // 0x90
	
		// Properties
		public byte[] RawData { set; } // 0x000000018141C040-0x000000018141C1A0
		public X509Certificate SigningCertificate { get; } // 0x000000018033D4D0-0x000000018033D4E0 
	
		// Constructors
		public AuthenticodeDeformatter(); // 0x000000018141BE60-0x000000018141BF40
		public AuthenticodeDeformatter(byte[] rawData); // 0x000000018141BF40-0x000000018141C040
	
		// Methods
		private bool CheckSignature(); // 0x0000000181419BE0-0x000000018141A9D0
		private bool CompareIssuerSerial(string issuer, byte[] serial, X509Certificate x509); // 0x000000018141A9D0-0x000000018141AAE0
		private bool VerifySignature(PKCS7.SignedData sd, byte[] calculatedMessageDigest, HashAlgorithm ha); // 0x000000018141B4C0-0x000000018141BE60
		private bool VerifyCounterSignature(PKCS7.SignerInfo cs, byte[] signature); // 0x000000018141ABE0-0x000000018141B4C0
		private void Reset(); // 0x000000018141AAE0-0x000000018141ABE0
	}
}
