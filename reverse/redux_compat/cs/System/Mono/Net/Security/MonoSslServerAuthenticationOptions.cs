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
	internal sealed class MonoSslServerAuthenticationOptions : MonoSslAuthenticationOptions // TypeDefIndex: 8569
	{
		// Fields
		[CompilerGenerated]
		private readonly SslServerAuthenticationOptions _Options_k__BackingField; // 0x18
	
		// Properties
		public SslServerAuthenticationOptions Options { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override bool ServerMode { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool AllowRenegotiation { get; } // 0x000000018181D020-0x000000018181D040 
		public override X509RevocationMode CertificateRevocationCheckMode { set; } // 0x000000018181D300-0x000000018181D320
		public override EncryptionPolicy EncryptionPolicy { set; } // 0x000000018181D3A0-0x000000018181D3C0
		public override SslProtocols EnabledSslProtocols { get; set; } // 0x000000018181D2A0-0x000000018181D2C0 0x000000018181D380-0x000000018181D3A0
		public override bool ClientCertificateRequired { get; set; } // 0x000000018181D240-0x000000018181D260 0x000000018181D320-0x000000018181D340
		public override string TargetHost { get; set; } // 0x000000018181D2C0-0x000000018181D300 0x000000018181D3C0-0x000000018181D400
		public override X509Certificate ServerCertificate { get; set; } // 0x0000000180E6D010-0x0000000180E6D030 0x0000000181777F80-0x0000000181777FB0
		public override X509CertificateCollection ClientCertificates { get; set; } // 0x000000018181D260-0x000000018181D2A0 0x000000018181D340-0x000000018181D380
	
		// Constructors
		public MonoSslServerAuthenticationOptions(); // 0x000000018181D1D0-0x000000018181D240
	}
}
