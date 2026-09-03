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
using System.Security.Cryptography;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	internal abstract class X509Certificate2Impl : X509CertificateImpl // TypeDefIndex: 8779
	{
		// Properties
		public abstract IEnumerable<X509Extension> Extensions { get; }
		public abstract string FriendlyName { set; }
		public abstract X500DistinguishedName IssuerName { get; }
		public abstract AsymmetricAlgorithm PrivateKey { get; set; }
		public abstract string SignatureAlgorithm { get; }
		public abstract X500DistinguishedName SubjectName { get; }
		public abstract int Version { get; }
		internal abstract X509CertificateImplCollection IntermediateCertificates { get; }
	
		// Constructors
		protected X509Certificate2Impl(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public abstract string GetNameInfo(X509NameType nameType, bool forIssuer);
		public abstract bool Verify(X509Certificate2 thisCertificate);
		public abstract void AppendPrivateKeyInfo(StringBuilder sb);
	}
}
