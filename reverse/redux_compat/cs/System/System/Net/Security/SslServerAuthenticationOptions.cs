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
	public class SslServerAuthenticationOptions // TypeDefIndex: 9245
	{
		// Fields
		private X509RevocationMode _checkCertificateRevocation; // 0x10
		private SslProtocols _enabledSslProtocols; // 0x14
		private EncryptionPolicy _encryptionPolicy; // 0x18
		private bool _allowRenegotiation; // 0x1C
		[CompilerGenerated]
		private bool _ClientCertificateRequired_k__BackingField; // 0x1D
		[CompilerGenerated]
		private X509Certificate _ServerCertificate_k__BackingField; // 0x20
	
		// Properties
		public bool AllowRenegotiation { get; } // 0x0000000180E38E30-0x0000000180E38E40 
		public bool ClientCertificateRequired { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B36780-0x0000000181B36790 0x0000000181B36830-0x0000000181B36840
		public X509Certificate ServerCertificate { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public SslProtocols EnabledSslProtocols { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public X509RevocationMode CertificateRevocationCheckMode { set; } // 0x0000000181B36790-0x0000000181B36830
		public EncryptionPolicy EncryptionPolicy { set; } // 0x0000000181B36840-0x0000000181B368E0
	
		// Constructors
		public SslServerAuthenticationOptions(); // 0x0000000181B36630-0x0000000181B36640
	}
}
