/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class TlsStream : NetworkStream // TypeDefIndex: 9000
	{
		// Fields
		private SslStream _sslStream; // 0x48
		private string _host; // 0x50
		private X509CertificateCollection _clientCertificates; // 0x58
	
		// Constructors
		public TlsStream(NetworkStream stream, Socket socket, string host, X509CertificateCollection clientCertificates); // 0x0000000181BF5340-0x0000000181BF5430
	
		// Methods
		public void AuthenticateAsClient(); // 0x0000000181BF4F00-0x0000000181BF5040
		public IAsyncResult BeginAuthenticateAsClient(AsyncCallback asyncCallback, object state); // 0x0000000181BF5040-0x0000000181BF5190
		public void EndAuthenticateAsClient(IAsyncResult asyncResult); // 0x0000000181BF5250-0x0000000181BF5280
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181BF51D0-0x0000000181BF5210
		public override void EndWrite(IAsyncResult result); // 0x0000000181BF52B0-0x0000000181BF52E0
		public override void Write(byte[] buffer, int offset, int size); // 0x0000000181BF5310-0x0000000181BF5340
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181BF52E0-0x0000000181BF5310
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181BF5190-0x0000000181BF51D0
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181BF5280-0x0000000181BF52B0
		public override void Close(); // 0x0000000181BF5210-0x0000000181BF5250
	}
}
