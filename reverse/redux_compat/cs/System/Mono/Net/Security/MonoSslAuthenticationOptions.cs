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
	internal abstract class MonoSslAuthenticationOptions // TypeDefIndex: 8567
	{
		// Fields
		[CompilerGenerated]
		private ServerCertSelectionCallback _ServerCertSelectionDelegate_k__BackingField; // 0x10
	
		// Properties
		public abstract bool ServerMode { get; }
		public abstract bool AllowRenegotiation { get; }
		public abstract SslProtocols EnabledSslProtocols { get; set; }
		public abstract EncryptionPolicy EncryptionPolicy { set; }
		public abstract X509RevocationMode CertificateRevocationCheckMode { set; }
		public abstract string TargetHost { get; set; }
		public abstract X509Certificate ServerCertificate { get; set; }
		public abstract X509CertificateCollection ClientCertificates { get; set; }
		public abstract bool ClientCertificateRequired { get; set; }
		internal ServerCertSelectionCallback ServerCertSelectionDelegate { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		protected MonoSslAuthenticationOptions(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
