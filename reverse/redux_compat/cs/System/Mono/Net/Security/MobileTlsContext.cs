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
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal abstract class MobileTlsContext : IDisposable // TypeDefIndex: 8565
	{
		// Fields
		private ChainValidationHelper certificateValidator; // 0x10
		[CompilerGenerated]
		private readonly MonoSslAuthenticationOptions _Options_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly MobileAuthenticatedStream _Parent_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly bool _IsServer_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly string _TargetHost_k__BackingField; // 0x30
		[CompilerGenerated]
		private readonly string _ServerName_k__BackingField; // 0x38
		[CompilerGenerated]
		private readonly bool _AskForClientCertificate_k__BackingField; // 0x40
		[CompilerGenerated]
		private readonly SslProtocols _EnabledProtocols_k__BackingField; // 0x44
		[CompilerGenerated]
		private readonly X509CertificateCollection _ClientCertificates_k__BackingField; // 0x48
		[CompilerGenerated]
		private X509Certificate _LocalServerCertificate_k__BackingField; // 0x50
	
		// Properties
		internal MonoSslAuthenticationOptions Options { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal MobileAuthenticatedStream Parent { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public MonoTlsSettings Settings { get; } // 0x0000000181814DD0-0x0000000181814DF0 
		public abstract bool IsAuthenticated { get; }
		public bool IsServer { [CompilerGenerated] get; } // 0x0000000180327270-0x0000000180327280 
		internal string TargetHost { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
		protected string ServerName { [CompilerGenerated] get; } // 0x00000001803272A0-0x00000001803272B0 
		protected bool AskForClientCertificate { [CompilerGenerated] get; } // 0x00000001803B1170-0x00000001803B1180 
		protected SslProtocols EnabledProtocols { [CompilerGenerated] get; } // 0x000000018033D780-0x000000018033D790 
		protected X509CertificateCollection ClientCertificates { [CompilerGenerated] get; } // 0x00000001803272B0-0x00000001803272C0 
		internal X509Certificate LocalServerCertificate { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		internal abstract X509Certificate LocalClientCertificate { get; }
		public abstract X509Certificate2 RemoteCertificate { get; }
	
		// Constructors
		protected MobileTlsContext(MobileAuthenticatedStream parent, MonoSslAuthenticationOptions options); // 0x0000000181814B20-0x0000000181814DD0
	
		// Methods
		protected void GetProtocolVersions(out TlsProtocolCode? min, out TlsProtocolCode? max); // 0x0000000181814200-0x00000001818142E0
		public abstract void StartHandshake();
		public abstract bool ProcessHandshake();
		public abstract void FinishHandshake();
		public abstract void Flush();
		public abstract ValueTuple<int, bool> Read(byte[] buffer, int offset, int count);
		public abstract ValueTuple<int, bool> Write(byte[] buffer, int offset, int count);
		public abstract void Shutdown();
		public abstract bool PendingRenegotiation();
		protected bool ValidateCertificate(X509Certificate2 leaf, X509Chain chain); // 0x0000000181814AC0-0x0000000181814B20
		protected X509Certificate SelectServerCertificate(string serverIdentity); // 0x0000000181814820-0x0000000181814AC0
		protected X509Certificate SelectClientCertificate(string[] acceptableIssuers); // 0x00000001818142E0-0x0000000181814820
		public abstract void Renegotiate();
		public void Dispose(); // 0x0000000181814110-0x0000000181814180
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		~MobileTlsContext(); // 0x0000000181814180-0x0000000181814200
	}
}
