/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Mono.Net.Security;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsContext : MobileTlsContext, IMonoBtlsBioMono // TypeDefIndex: 8590
	{
		// Fields
		private X509Certificate2 remoteCertificate; // 0x58
		private X509Certificate clientCertificate; // 0x60
		private X509CertificateImplBtls nativeServerCertificate; // 0x68
		private X509CertificateImplBtls nativeClientCertificate; // 0x70
		private MonoBtlsSslCtx ctx; // 0x78
		private MonoBtlsSsl ssl; // 0x80
		private MonoBtlsBio bio; // 0x88
		private MonoBtlsBio errbio; // 0x90
		private MonoTlsConnectionInfo connectionInfo; // 0x98
		private bool certificateValidated; // 0xA0
		private bool isAuthenticated; // 0xA1
		private bool connected; // 0xA2
	
		// Properties
		public override bool IsAuthenticated { get; } // 0x00000001817273A0-0x00000001817273B0 
		internal override X509Certificate LocalClientCertificate { get; } // 0x0000000180333260-0x0000000180333490 
		public override X509Certificate2 RemoteCertificate { get; } // 0x00000001802F4000-0x00000001802F4010 
	
		// Constructors
		public MonoBtlsContext(MobileAuthenticatedStream parent, MonoSslAuthenticationOptions options); // 0x00000001818186A0-0x00000001818186F0
	
		// Methods
		private static X509CertificateImplBtls GetPrivateCertificate(X509Certificate certificate); // 0x0000000181816A90-0x0000000181816CD0
		private int VerifyCallback(MonoBtlsX509StoreCtx storeCtx); // 0x00000001818181F0-0x0000000181818430
		private int SelectCallback(string[] acceptableIssuers); // 0x0000000181817BE0-0x0000000181817CB0
		private int ServerNameCallback(); // 0x0000000181817CB0-0x0000000181817D20
		public override void StartHandshake(); // 0x0000000181818090-0x00000001818181F0
		private void SetPrivateCertificate(X509CertificateImplBtls privateCert); // 0x0000000181817D20-0x0000000181818030
		private static Exception GetException(MonoBtlsSslError status); // 0x0000000181816580-0x00000001818169A0
		public override bool ProcessHandshake(); // 0x00000001818177E0-0x00000001818178D0
		private MonoBtlsSslError DoProcessHandshake(); // 0x00000001818164C0-0x0000000181816520
		public override void FinishHandshake(); // 0x0000000181816520-0x0000000181816540
		private void InitializeConnection(); // 0x0000000181816D60-0x0000000181817540
		private void GetPeerCertificate(); // 0x00000001818169A0-0x0000000181816A90
		private void InitializeSession(); // 0x0000000181817540-0x0000000181817750
		private static TlsProtocols GetProtocol(TlsProtocolCode protocol); // 0x0000000181816CD0-0x0000000181816D60
		public override void Flush(); // 0x0000000181816540-0x0000000181816580
		public override ValueTuple<int, bool> Read(byte[] buffer, int offset, int size); // 0x00000001818178D0-0x0000000181817BA0
		public override ValueTuple<int, bool> Write(byte[] buffer, int offset, int size); // 0x0000000181818430-0x00000001818186A0
		public override void Renegotiate(); // 0x0000000181817BA0-0x0000000181817BE0
		public override void Shutdown(); // 0x0000000181818030-0x0000000181818090
		public override bool PendingRenegotiation(); // 0x00000001818177B0-0x00000001818177E0
		private void Dispose<T>(ref ref T disposable)
			where T : class, IDisposable;
		protected override void Dispose(bool disposing); // 0x0000000181816350-0x00000001818164C0
		int IMonoBtlsBioMono.Read(byte[] buffer, int offset, int size, out bool wantMore); // 0x0000000181817750-0x0000000181817780
		bool IMonoBtlsBioMono.Write(byte[] buffer, int offset, int size); // 0x0000000181817780-0x00000001818177B0
		void IMonoBtlsBioMono.Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		void IMonoBtlsBioMono.Close(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
