/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Mono.Net.Security;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Security
{
	public class SslStream : AuthenticatedStream // TypeDefIndex: 9254
	{
		// Fields
		private MobileTlsProvider provider; // 0x38
		private MonoTlsSettings settings; // 0x40
		private RemoteCertificateValidationCallback validationCallback; // 0x48
		private LocalCertificateSelectionCallback selectionCallback; // 0x50
		private MobileAuthenticatedStream impl; // 0x58
		private bool explicitSettings; // 0x60
	
		// Properties
		internal MobileAuthenticatedStream Impl { get; } // 0x0000000181B377C0-0x0000000181B37830 
		internal string InternalTargetHost { get; } // 0x0000000181B37830-0x0000000181B378A0 
		public override bool IsAuthenticated { get; } // 0x0000000181B378A0-0x0000000181B37920 
		public virtual X509Certificate LocalCertificate { get; } // 0x0000000181B379A0-0x0000000181B37A10 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanRead { get; } // 0x0000000181B37760-0x0000000181B37790 
		public override bool CanTimeout { get; } // 0x0000000181813C10-0x0000000181813C40 
		public override bool CanWrite { get; } // 0x0000000181B37790-0x0000000181B377C0 
		public override int ReadTimeout { get; set; } // 0x0000000181B37A90-0x0000000181B37B10 0x0000000181B37BF0-0x0000000181B37C70
		public override int WriteTimeout { get; set; } // 0x0000000181B37B10-0x0000000181B37B90 0x0000000181B37C70-0x0000000181B37CF0
		public override long Length { get; } // 0x0000000181B37920-0x0000000181B379A0 
		public override long Position { get; set; } // 0x0000000181B37A10-0x0000000181B37A90 0x0000000181B37B90-0x0000000181B37BF0
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass21_0 // TypeDefIndex: 9255
		{
			// Fields
			public LocalCertificateSelectionCallback callback; // 0x10
			public SslStream __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal X509Certificate _SetAndVerifySelectionCallback_b__0(string t, X509CertificateCollection lc, X509Certificate rc, string[] ai); // 0x0000000181B3EBF0-0x0000000181B3EC40
		}
	
		// Constructors
		public SslStream(Stream innerStream, bool leaveInnerStreamOpen, RemoteCertificateValidationCallback userCertificateValidationCallback); // 0x0000000181B37520-0x0000000181B37540
		public SslStream(Stream innerStream, bool leaveInnerStreamOpen, RemoteCertificateValidationCallback userCertificateValidationCallback, LocalCertificateSelectionCallback userCertificateSelectionCallback); // 0x0000000181B37540-0x0000000181B37760
		internal SslStream(Stream innerStream, bool leaveInnerStreamOpen, MonoTlsProvider provider, MonoTlsSettings settings); // 0x0000000181B373B0-0x0000000181B37520
	
		// Methods
		private static MobileTlsProvider GetProvider(); // 0x0000000181B36DC0-0x0000000181B36E30
		private void SetAndVerifyValidationCallback(RemoteCertificateValidationCallback callback); // 0x0000000181B37140-0x0000000181B37230
		private void SetAndVerifySelectionCallback(LocalCertificateSelectionCallback callback); // 0x0000000181B36F90-0x0000000181B37140
		public virtual void AuthenticateAsClient(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181B36960-0x0000000181B369E0
		public virtual IAsyncResult BeginAuthenticateAsClient(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation, AsyncCallback asyncCallback, object asyncState); // 0x0000000181B36A60-0x0000000181B36B00
		public virtual void EndAuthenticateAsClient(IAsyncResult asyncResult); // 0x0000000181475360-0x0000000181475370
		public virtual void AuthenticateAsServer(X509Certificate serverCertificate, bool clientCertificateRequired, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181B369E0-0x0000000181B36A60
		public virtual Task AuthenticateAsClientAsync(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation); // 0x0000000181B368E0-0x0000000181B36960
		public override void SetLength(long value); // 0x0000000181B37230-0x0000000181B372B0
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181B36F30-0x0000000181B36F90
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x0000000181B36D90-0x0000000181B36DC0
		public override void Flush(); // 0x0000000181812060-0x0000000181812090
		private void CheckDisposed(); // 0x0000000181B36C20-0x0000000181B36C90
		protected override void Dispose(bool disposing); // 0x0000000181B36C90-0x0000000181B36D50
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000181B36EB0-0x0000000181B36F30
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181B37330-0x0000000181B373B0
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181B36E30-0x0000000181B36EB0
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181B372B0-0x0000000181B37330
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181B36B00-0x0000000181B36B90
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181B36D50-0x0000000181B36D90
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181B36B90-0x0000000181B36C20
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181475360-0x0000000181475370
	}
}
