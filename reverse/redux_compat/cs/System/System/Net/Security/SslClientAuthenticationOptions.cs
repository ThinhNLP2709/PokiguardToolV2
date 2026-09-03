/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Security
{
	public class SslClientAuthenticationOptions // TypeDefIndex: 9244
	{
		// Fields
		private EncryptionPolicy _encryptionPolicy; // 0x10
		private X509RevocationMode _checkCertificateRevocation; // 0x14
		private SslProtocols _enabledSslProtocols; // 0x18
		private bool _allowRenegotiation; // 0x1C
		[CompilerGenerated]
		private string _TargetHost_k__BackingField; // 0x20
		[CompilerGenerated]
		private X509CertificateCollection _ClientCertificates_k__BackingField; // 0x28
	
		// Properties
		public bool AllowRenegotiation { get; } // 0x0000000180E38E30-0x0000000180E38E40 
		public string TargetHost { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public X509CertificateCollection ClientCertificates { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public X509RevocationMode CertificateRevocationCheckMode { set; } // 0x0000000181B36640-0x0000000181B366E0
		public EncryptionPolicy EncryptionPolicy { set; } // 0x0000000181B366E0-0x0000000181B36780
		public SslProtocols EnabledSslProtocols { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public SslClientAuthenticationOptions(); // 0x0000000181B36630-0x0000000181B36640
	}
}
