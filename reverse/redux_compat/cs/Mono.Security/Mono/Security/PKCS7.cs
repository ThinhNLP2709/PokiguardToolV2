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
using Mono.Security.X509;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security
{
	public sealed class PKCS7 // TypeDefIndex: 13811
	{
		// Nested types
		public class ContentInfo // TypeDefIndex: 13812
		{
			// Fields
			private string contentType; // 0x10
			private ASN1 content; // 0x18
	
			// Properties
			public ASN1 ASN1 { get; } // 0x0000000181403FF0-0x0000000181404000 
			public ASN1 Content { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public string ContentType { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
			// Constructors
			public ContentInfo(); // 0x0000000181403CB0-0x0000000181403D30
			public ContentInfo(string oid); // 0x0000000181403DA0-0x0000000181403DE0
			public ContentInfo(byte[] data); // 0x0000000181403D30-0x0000000181403DA0
			public ContentInfo(ASN1 asn1); // 0x0000000181403DE0-0x0000000181403FF0
	
			// Methods
			internal ASN1 GetASN1(); // 0x0000000181403AC0-0x0000000181403CB0
		}
	
		public class EncryptedData // TypeDefIndex: 13813
		{
			// Fields
			private byte _version; // 0x10
			private ContentInfo _content; // 0x18
			private ContentInfo _encryptionAlgorithm; // 0x20
			private byte[] _encrypted; // 0x28
	
			// Properties
			public ContentInfo EncryptionAlgorithm { get; } // 0x00000001802F8630-0x00000001802F8640 
			public byte[] EncryptedContent { get; } // 0x0000000181404FB0-0x0000000181405030 
	
			// Constructors
			public EncryptedData(); // 0x0000000181404B70-0x0000000181404B90
			public EncryptedData(ASN1 asn1); // 0x0000000181404B90-0x0000000181404FB0
		}
	
		public class SignedData // TypeDefIndex: 13814
		{
			// Fields
			private byte version; // 0x10
			private string hashAlgorithm; // 0x18
			private ContentInfo contentInfo; // 0x20
			private X509CertificateCollection certs; // 0x28
			private ArrayList crls; // 0x30
			private SignerInfo signerInfo; // 0x38
			private bool mda; // 0x40
	
			// Properties
			public X509CertificateCollection Certificates { get; } // 0x000000018033D240-0x000000018033D250 
			public ContentInfo ContentInfo { get; } // 0x00000001802F8630-0x00000001802F8640 
			public string HashName { set; } // 0x000000018140E600-0x000000018140E650
			public SignerInfo SignerInfo { get; } // 0x00000001803272A0-0x00000001803272B0 
	
			// Constructors
			public SignedData(ASN1 asn1); // 0x000000018140DD60-0x000000018140E600
	
			// Methods
			internal string OidToName(string oid); // 0x000000018140DBD0-0x000000018140DD60
		}
	
		public class SignerInfo // TypeDefIndex: 13815
		{
			// Fields
			private byte version; // 0x10
			private string hashAlgorithm; // 0x18
			private ArrayList authenticatedAttributes; // 0x20
			private ArrayList unauthenticatedAttributes; // 0x28
			private byte[] signature; // 0x30
			private string issuer; // 0x38
			private byte[] serial; // 0x40
			private byte[] ski; // 0x48
	
			// Properties
			public string IssuerName { get; } // 0x00000001803272A0-0x00000001803272B0 
			public byte[] SerialNumber { get; } // 0x000000018140EB90-0x000000018140EC10 
			public ArrayList AuthenticatedAttributes { get; } // 0x00000001802F8630-0x00000001802F8640 
			public string HashName { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public byte[] Signature { get; } // 0x000000018140EC10-0x000000018140EC90 
			public ArrayList UnauthenticatedAttributes { get; } // 0x000000018033D240-0x000000018033D250 
			public byte Version { get; } // 0x00000001805625D0-0x00000001805625E0 
	
			// Constructors
			public SignerInfo(); // 0x000000018140E650-0x000000018140E6F0
			public SignerInfo(ASN1 asn1); // 0x000000018140E6F0-0x000000018140EB90
		}
	}
}
