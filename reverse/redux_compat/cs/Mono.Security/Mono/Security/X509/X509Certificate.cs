/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class X509Certificate : ISerializable // TypeDefIndex: 13822
	{
		// Fields
		private ASN1 decoder; // 0x10
		private byte[] m_encodedcert; // 0x18
		private DateTime m_from; // 0x20
		private DateTime m_until; // 0x28
		private ASN1 issuer; // 0x30
		private string m_issuername; // 0x38
		private string m_keyalgo; // 0x40
		private byte[] m_keyalgoparams; // 0x48
		private ASN1 subject; // 0x50
		private string m_subject; // 0x58
		private byte[] m_publickey; // 0x60
		private byte[] signature; // 0x68
		private string m_signaturealgo; // 0x70
		private byte[] m_signaturealgoparams; // 0x78
		private byte[] certhash; // 0x80
		private RSA _rsa; // 0x88
		private DSA _dsa; // 0x90
		private int version; // 0x98
		private byte[] serialnumber; // 0xA0
		private byte[] issuerUniqueID; // 0xA8
		private byte[] subjectUniqueID; // 0xB0
		private X509ExtensionCollection extensions; // 0xB8
		private static string encoding_error; // 0x00
	
		// Properties
		public DSA DSA { get; set; } // 0x00000001814136C0-0x0000000181413A60 0x00000001814146A0-0x00000001814146F0
		public X509ExtensionCollection Extensions { get; } // 0x00000001806CCB90-0x00000001806CCBA0 
		public byte[] Hash { get; } // 0x0000000181413A60-0x0000000181413CB0 
		public virtual string IssuerName { get; } // 0x00000001803272A0-0x00000001803272B0 
		public virtual string KeyAlgorithm { get; } // 0x0000000180377940-0x0000000180377950 
		public virtual byte[] KeyAlgorithmParameters { get; set; } // 0x0000000181413E30-0x0000000181413EB0 0x00000001803780C0-0x00000001803780D0
		public virtual byte[] PublicKey { get; } // 0x0000000181413EB0-0x0000000181413F30 
		public virtual RSA RSA { get; set; } // 0x0000000181413F30-0x0000000181414160 0x00000001814146F0-0x0000000181414740
		public virtual byte[] RawData { get; } // 0x0000000181414160-0x00000001814141E0 
		public virtual byte[] SerialNumber { get; } // 0x00000001814141E0-0x0000000181414270 
		public virtual byte[] Signature { get; } // 0x0000000181414270-0x00000001814146A0 
		public virtual string SubjectName { get; } // 0x00000001802F4000-0x00000001802F4010 
		public virtual DateTime ValidFrom { get; } // 0x00000001802F8630-0x00000001802F8640 
		public virtual DateTime ValidUntil { get; } // 0x000000018033D240-0x000000018033D250 
		public int Version { get; } // 0x000000018033D1D0-0x000000018033D1E0 
		public bool IsCurrent { get; } // 0x0000000181413CB0-0x0000000181413DA0 
		public bool IsSelfSigned { get; } // 0x0000000181413DA0-0x0000000181413E30 
	
		// Constructors
		public X509Certificate(byte[] data); // 0x0000000181413460-0x00000001814136C0
		static X509Certificate(); // 0x0000000181413400-0x0000000181413460
	
		// Methods
		private void Parse(byte[] data); // 0x0000000181412540-0x0000000181412F40
		private byte[] GetUnsignedBigInteger(byte[] integer); // 0x0000000181412380-0x0000000181412420
		public bool WasCurrent(DateTime instant); // 0x0000000181413340-0x0000000181413400
		internal bool VerifySignature(DSA dsa); // 0x0000000181413260-0x0000000181413340
		internal bool VerifySignature(RSA rsa); // 0x0000000181413130-0x0000000181413260
		public bool VerifySignature(AsymmetricAlgorithm aa); // 0x0000000181412F40-0x0000000181413130
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181412320-0x0000000181412380
		private static byte[] PEM(string type, byte[] data); // 0x0000000181412420-0x0000000181412540
	}
}
