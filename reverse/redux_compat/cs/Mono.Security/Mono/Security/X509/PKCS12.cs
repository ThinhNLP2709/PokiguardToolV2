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
using Mono.Security.Cryptography;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class PKCS12 : ICloneable // TypeDefIndex: 13817
	{
		// Fields
		private byte[] _password; // 0x10
		private ArrayList _keyBags; // 0x18
		private ArrayList _secretBags; // 0x20
		private X509CertificateCollection _certs; // 0x28
		private bool _keyBagsChanged; // 0x30
		private bool _secretBagsChanged; // 0x31
		private bool _certsChanged; // 0x32
		private int _iterations; // 0x34
		private ArrayList _safeBags; // 0x38
		private RandomNumberGenerator _rng; // 0x40
		private static int password_max_length; // 0x00
	
		// Properties
		public string Password { set; } // 0x000000018140D9B0-0x000000018140DB70
		public int IterationCount { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public ArrayList Keys { get; } // 0x000000018140D310-0x000000018140D920 
		public X509CertificateCollection Certificates { get; } // 0x000000018140CF20-0x000000018140D310 
		internal RandomNumberGenerator RNG { get; } // 0x000000018140D970-0x000000018140D9B0 
		public static int MaximumPasswordLength { get; } // 0x000000018140D920-0x000000018140D970 
	
		// Nested types
		public class DeriveBytes // TypeDefIndex: 13818
		{
			// Fields
			private static byte[] keyDiversifier; // 0x00
			private static byte[] ivDiversifier; // 0x08
			private static byte[] macDiversifier; // 0x10
			private string _hashName; // 0x10
			private int _iterations; // 0x18
			private byte[] _password; // 0x20
			private byte[] _salt; // 0x28
	
			// Properties
			public string HashName { set; } // 0x00000001803780D0-0x00000001803780E0
			public int IterationCount { set; } // 0x0000000180F9EB90-0x0000000180F9EBA0
			public byte[] Password { set; } // 0x00000001814048A0-0x0000000181404980
			public byte[] Salt { set; } // 0x0000000181404980-0x0000000181404A50
	
			// Constructors
			public DeriveBytes(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static DeriveBytes(); // 0x0000000181404720-0x00000001814048A0
	
			// Methods
			private void Adjust(byte[] a, int aOff, byte[] b); // 0x0000000181404060-0x0000000181404160
			private byte[] Derive(byte[] diversifier, int n); // 0x00000001814042B0-0x0000000181404720
			public byte[] DeriveKey(int size); // 0x00000001814041D0-0x0000000181404240
			public byte[] DeriveIV(int size); // 0x0000000181404160-0x00000001814041D0
			public byte[] DeriveMAC(int size); // 0x0000000181404240-0x00000001814042B0
		}
	
		// Constructors
		public PKCS12(); // 0x000000018140CE20-0x000000018140CF20
		public PKCS12(byte[] data); // 0x000000018140CD90-0x000000018140CE20
		public PKCS12(byte[] data, string password); // 0x000000018140CD40-0x000000018140CD90
		static PKCS12(); // 0x000000018140CD00-0x000000018140CD40
	
		// Methods
		private void Decode(byte[] data); // 0x00000001814069B0-0x0000000181407370
		~PKCS12(); // 0x0000000181408050-0x00000001814080F0
		private bool Compare(byte[] expected, byte[] actual); // 0x0000000181406930-0x00000001814069B0
		private SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmOid, byte[] salt, int iterationCount); // 0x000000018140AA60-0x000000018140B0A0
		public byte[] Decrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] encryptedData); // 0x00000001814074B0-0x0000000181407600
		public byte[] Decrypt(PKCS7.EncryptedData ed); // 0x0000000181407370-0x00000001814074B0
		public byte[] Encrypt(string algorithmOid, byte[] salt, int iterationCount, byte[] data); // 0x0000000181407600-0x0000000181407770
		private DSAParameters GetExistingParameters(out bool found); // 0x000000018140A770-0x000000018140AA60
		private void AddPrivateKey(PKCS8.PrivateKeyInfo pki); // 0x0000000181405970-0x0000000181405C30
		private void ReadSafeBag(ASN1 safeBag); // 0x000000018140BDA0-0x000000018140C6B0
		private ASN1 Pkcs8ShroudedKeyBagSafeBag(AsymmetricAlgorithm aa, IDictionary attributes); // 0x000000018140B250-0x000000018140BDA0
		private ASN1 CertificateSafeBag(X509Certificate x509, IDictionary attributes); // 0x0000000181405C30-0x0000000181406720
		private byte[] MAC(byte[] password, byte[] salt, int iterations, byte[] data); // 0x000000018140B0A0-0x000000018140B250
		public byte[] GetBytes(); // 0x00000001814080F0-0x000000018140A770
		private PKCS7.ContentInfo EncryptedContentInfo(ASN1 safeBags, string algorithmOid); // 0x0000000181407770-0x0000000181408050
		public void AddCertificate(X509Certificate cert); // 0x0000000181405260-0x0000000181405270
		public void AddCertificate(X509Certificate cert, IDictionary attributes); // 0x0000000181405270-0x0000000181405570
		public void RemoveCertificate(X509Certificate cert); // 0x000000018140CCF0-0x000000018140CD00
		public void RemoveCertificate(X509Certificate cert, IDictionary attrs); // 0x000000018140C6B0-0x000000018140CCF0
		private bool CompareAsymmetricAlgorithm(AsymmetricAlgorithm a1, AsymmetricAlgorithm a2); // 0x0000000181406870-0x0000000181406930
		public void AddPkcs8ShroudedKeyBag(AsymmetricAlgorithm aa, IDictionary attributes); // 0x0000000181405570-0x0000000181405970
		public object Clone(); // 0x0000000181406720-0x0000000181406870
	}
}
