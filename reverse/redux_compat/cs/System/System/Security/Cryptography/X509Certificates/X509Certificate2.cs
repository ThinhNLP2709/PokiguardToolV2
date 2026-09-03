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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	[Serializable]
	public class X509Certificate2 : X509Certificate // TypeDefIndex: 8776
	{
		// Fields
		private byte[] lazyRawData; // 0x60
		private Oid lazySignatureAlgorithm; // 0x68
		private int lazyVersion; // 0x70
		private X500DistinguishedName lazySubjectName; // 0x78
		private X500DistinguishedName lazyIssuerName; // 0x80
		private PublicKey lazyPublicKey; // 0x88
		private AsymmetricAlgorithm lazyPrivateKey; // 0x90
		private X509ExtensionCollection lazyExtensions; // 0x98
	
		// Properties
		public X509ExtensionCollection Extensions { get; } // 0x0000000181B97F00-0x0000000181B98270 
		public string FriendlyName { set; } // 0x0000000181B98AF0-0x0000000181B98B40
		public bool HasPrivateKey { get; } // 0x0000000181B98270-0x0000000181B982C0 
		public AsymmetricAlgorithm PrivateKey { get; set; } // 0x0000000181B983E0-0x0000000181B985A0 0x0000000181B98B40-0x0000000181B98B80
		public X500DistinguishedName IssuerName { get; } // 0x0000000181B98340-0x0000000181B983C0 
		public DateTime NotAfter { get; } // 0x0000000181B983C0-0x0000000181B983D0 
		public DateTime NotBefore { get; } // 0x0000000181B983D0-0x0000000181B983E0 
		public PublicKey PublicKey { get; } // 0x0000000181B985A0-0x0000000181B988C0 
		public byte[] RawData { get; } // 0x0000000181B988C0-0x0000000181B98940 
		public string SerialNumber { get; } // 0x0000000181475250-0x0000000181475270 
		public Oid SignatureAlgorithm { get; } // 0x0000000181B98940-0x0000000181B989D0 
		public X500DistinguishedName SubjectName { get; } // 0x0000000181B989D0-0x0000000181B98A50 
		public string Thumbprint { get; } // 0x0000000181B98A50-0x0000000181B98A80 
		public int Version { get; } // 0x0000000181B98A80-0x0000000181B98AF0 
		internal new X509Certificate2Impl Impl { get; } // 0x0000000181B982C0-0x0000000181B98340 
	
		// Constructors
		public X509Certificate2(); // 0x0000000181B97E90-0x0000000181B97EA0
		public X509Certificate2(byte[] rawData); // 0x0000000181B97D40-0x0000000181B97E70
		public X509Certificate2(byte[] rawData, string password); // 0x0000000181B97D20-0x0000000181B97D30
		internal X509Certificate2(X509Certificate2Impl impl); // 0x0000000181B97E80-0x0000000181B97E90
		public X509Certificate2(string fileName); // 0x0000000181B97E70-0x0000000181B97E80
		public X509Certificate2(X509Certificate certificate); // 0x0000000181B97D30-0x0000000181B97D40
		protected X509Certificate2(SerializationInfo info, StreamingContext context); // 0x0000000181B97EA0-0x0000000181B97F00
	
		// Methods
		public override void Reset(); // 0x0000000181B96EE0-0x0000000181B96FB0
		public static X509ContentType GetCertContentType(byte[] rawData); // 0x0000000181B96DF0-0x0000000181B96E90
		public string GetNameInfo(X509NameType nameType, bool forIssuer); // 0x0000000181B96E90-0x0000000181B96EE0
		public override string ToString(); // 0x0000000181B97CD0-0x0000000181B97CE0
		public override string ToString(bool verbose); // 0x0000000181B96FB0-0x0000000181B97CD0
		public bool Verify(); // 0x0000000181B97CE0-0x0000000181B97D20
		private static X509Extension CreateCustomExtensionIfAny(Oid oid); // 0x0000000181B96B20-0x0000000181B96DF0
	}
}
