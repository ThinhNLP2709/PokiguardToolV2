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
	public class ServerSslConfiguration // TypeDefIndex: 13308
	{
		// Fields
		private bool _checkCertRevocation; // 0x10
		private bool _clientCertRequired; // 0x11
		private RemoteCertificateValidationCallback _clientCertValidationCallback; // 0x18
		private SslProtocols _enabledSslProtocols; // 0x20
		private X509Certificate2 _serverCert; // 0x28
	
		// Properties
		public bool CheckCertificateRevocation { get; set; } // 0x00000001825D8650-0x00000001825D8660 0x00000001804C2E20-0x00000001804C2E30
		public bool ClientCertificateRequired { get; set; } // 0x000000018261E500-0x000000018261E510 0x00000001815C0340-0x00000001815C0350
		public RemoteCertificateValidationCallback ClientCertificateValidationCallback { get; set; } // 0x000000018261E510-0x000000018261E590 0x00000001802FAF70-0x00000001802FAF80
		public SslProtocols EnabledSslProtocols { get; set; } // 0x00000001825EE1B0-0x00000001825EE1C0 0x0000000180E332D0-0x0000000180E332E0
		public X509Certificate2 ServerCertificate { get; set; } // 0x00000001825EE1C0-0x00000001825EE1D0 0x000000018033E840-0x000000018033E850
	
		// Constructors
		public ServerSslConfiguration(); // 0x000000018261E4E0-0x000000018261E500
		public ServerSslConfiguration(ServerSslConfiguration configuration); // 0x000000018261E430-0x000000018261E4E0
	
		// Methods
		private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors); // 0x00000001825FCB20-0x00000001825FCB30
	}
}
