/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal sealed class MonoSslClientAuthenticationOptions : MonoSslAuthenticationOptions // TypeDefIndex: 8568
	{
		// Fields
		[CompilerGenerated]
		private readonly SslClientAuthenticationOptions _Options_k__BackingField; // 0x18
	
		// Properties
		public SslClientAuthenticationOptions Options { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override bool ServerMode { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool AllowRenegotiation { get; } // 0x000000018181D020-0x000000018181D040 
		public override X509RevocationMode CertificateRevocationCheckMode { set; } // 0x000000018181D0C0-0x000000018181D0E0
		public override EncryptionPolicy EncryptionPolicy { set; } // 0x000000018181D170-0x000000018181D190
		public override SslProtocols EnabledSslProtocols { get; set; } // 0x00000001814EA450-0x00000001814EA470 0x000000018181D150-0x000000018181D170
		public override string TargetHost { get; set; } // 0x0000000180E6D010-0x0000000180E6D030 0x0000000181777F80-0x0000000181777FB0
		public override bool ClientCertificateRequired { get; set; } // 0x000000018181D040-0x000000018181D080 0x000000018181D0E0-0x000000018181D120
		public override X509CertificateCollection ClientCertificates { get; set; } // 0x0000000181778050-0x0000000181778070 0x000000018181D120-0x000000018181D150
		public override X509Certificate ServerCertificate { get; set; } // 0x000000018181D080-0x000000018181D0C0 0x000000018181D190-0x000000018181D1D0
	
		// Constructors
		public MonoSslClientAuthenticationOptions(); // 0x000000018181CFB0-0x000000018181D020
	}
}
