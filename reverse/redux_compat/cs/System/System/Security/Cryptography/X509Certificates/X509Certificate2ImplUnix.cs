/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Internal.Cryptography.Pal;
using Microsoft.Win32.SafeHandles;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal abstract class X509Certificate2ImplUnix : X509Certificate2Impl // TypeDefIndex: 8781
	{
		// Fields
		private bool readCertData; // 0x10
		private CertificateData certData; // 0x18
	
		// Properties
		public sealed override string KeyAlgorithm { get; } // 0x0000000181B967E0-0x0000000181B96800 
		public sealed override byte[] KeyAlgorithmParameters { get; } // 0x0000000181B967C0-0x0000000181B967E0 
		public sealed override byte[] PublicKeyValue { get; } // 0x0000000181B968C0-0x0000000181B968E0 
		public sealed override byte[] SerialNumber { get; } // 0x0000000181B96900-0x0000000181B96920 
		public sealed override string SignatureAlgorithm { get; } // 0x0000000181B96920-0x0000000181B96940 
		public sealed override string FriendlyName { set; } // 0x0000000181B96AA0-0x0000000181B96B20
		public sealed override int Version { get; } // 0x0000000181B96A80-0x0000000181B96AA0 
		public sealed override X500DistinguishedName SubjectName { get; } // 0x0000000181B96940-0x0000000181B96960 
		public sealed override X500DistinguishedName IssuerName { get; } // 0x0000000181B96770-0x0000000181B96790 
		public sealed override string Subject { get; } // 0x0000000181B96960-0x0000000181B96990 
		public sealed override string Issuer { get; } // 0x0000000181B96790-0x0000000181B967C0 
		public sealed override byte[] RawData { get; } // 0x0000000181B968E0-0x0000000181B96900 
		public sealed override byte[] Thumbprint { get; } // 0x0000000181B96990-0x0000000181B96A80 
		public sealed override IEnumerable<X509Extension> Extensions { get; } // 0x0000000181B96750-0x0000000181B96770 
		public sealed override DateTime NotAfter { get; } // 0x0000000181B96800-0x0000000181B96860 
		public sealed override DateTime NotBefore { get; } // 0x0000000181B96860-0x0000000181B968C0 
	
		// Constructors
		protected X509Certificate2ImplUnix(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		private void EnsureCertData(); // 0x0000000181B96020-0x0000000181B96130
		protected abstract byte[] GetRawCertData();
		public sealed override string GetNameInfo(X509NameType nameType, bool forIssuer); // 0x0000000181B96710-0x0000000181B96750
		public sealed override void AppendPrivateKeyInfo(StringBuilder sb); // 0x0000000181B95F90-0x0000000181B96020
		public sealed override byte[] Export(X509ContentType contentType, SafePasswordHandle password); // 0x0000000181B96590-0x0000000181B96710
		private byte[] ExportPkcs12(SafePasswordHandle password); // 0x0000000181B96130-0x0000000181B96190
		private byte[] ExportPkcs12(string password); // 0x0000000181B96190-0x0000000181B96590
	}
}
