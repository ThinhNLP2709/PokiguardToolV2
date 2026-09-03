/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public class ClientSslConfiguration // TypeDefIndex: 13307
	{
		// Fields
		private bool _checkCertRevocation; // 0x10
		private LocalCertificateSelectionCallback _clientCertSelectionCallback; // 0x18
		private X509CertificateCollection _clientCerts; // 0x20
		private SslProtocols _enabledSslProtocols; // 0x28
		private RemoteCertificateValidationCallback _serverCertValidationCallback; // 0x30
		private string _targetHost; // 0x38
	
		// Properties
		public bool CheckCertificateRevocation { get; set; } // 0x00000001825D8650-0x00000001825D8660 0x00000001804C2E20-0x00000001804C2E30
		public X509CertificateCollection ClientCertificates { get; set; } // 0x00000001825DE400-0x00000001825DE410 0x000000018033E830-0x000000018033E840
		public LocalCertificateSelectionCallback ClientCertificateSelectionCallback { get; set; } // 0x00000001826191E0-0x0000000182619260 0x00000001802FAF70-0x00000001802FAF80
		public SslProtocols EnabledSslProtocols { get; set; } // 0x0000000182612DA0-0x0000000182612DB0 0x0000000180378100-0x0000000180378110
		public RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; } // 0x0000000182619260-0x00000001826192E0 0x0000000180378110-0x0000000180378120
		public string TargetHost { get; set; } // 0x00000001825EE1D0-0x00000001825EE1E0 0x00000001826192E0-0x00000001826193B0
	
		// Constructors
		public ClientSslConfiguration(string targetHost); // 0x0000000182619020-0x0000000182619110
		public ClientSslConfiguration(ClientSslConfiguration configuration); // 0x0000000182619110-0x00000001826191D0
	
		// Methods
		private static X509Certificate defaultSelectClientCertificate(object sender, string targetHost, X509CertificateCollection clientCertificates, X509Certificate serverCertificate, string[] acceptableIssuers); // 0x00000001826191D0-0x00000001826191E0
		private static bool defaultValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors); // 0x00000001825FCB20-0x00000001825FCB30
	}
}
