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
using Mono.Util;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal class UnityTlsContext : MobileTlsContext // TypeDefIndex: 8538
	{
		// Fields
		private unsafe UnityTls.unitytls_tlsctx* tlsContext; // 0x58
		private unsafe UnityTls.unitytls_x509list* requestedClientCertChain; // 0x60
		private unsafe UnityTls.unitytls_key* requestedClientKey; // 0x68
		private UnityTls.unitytls_tlsctx_read_callback readCallback; // 0x70
		private UnityTls.unitytls_tlsctx_write_callback writeCallback; // 0x78
		private UnityTls.unitytls_tlsctx_certificate_callback certificateCallback; // 0x80
		private UnityTls.unitytls_tlsctx_x509verify_callback verifyCallback; // 0x88
		private X509Certificate localClientCertificate; // 0x90
		private X509Certificate2 remoteCertificate; // 0x98
		private MonoTlsConnectionInfo connectioninfo; // 0xA0
		private bool isAuthenticated; // 0xA8
		private bool hasContext; // 0xA9
		private bool closedGraceful; // 0xAA
		private byte[] writeBuffer; // 0xB0
		private byte[] readBuffer; // 0xB8
		private GCHandle handle; // 0xC0
		private Exception lastException; // 0xC8
	
		// Properties
		public override bool IsAuthenticated { get; } // 0x0000000181773D00-0x0000000181773D10 
		internal override X509Certificate LocalClientCertificate { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public override X509Certificate2 RemoteCertificate { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public UnityTlsContext(MobileAuthenticatedStream parent, MonoSslAuthenticationOptions options); // 0x00000001818259E0-0x00000001818265B0
	
		// Methods
		private static unsafe void ExtractNativeKeyAndChainFromManagedCertificate(X509Certificate cert, UnityTls.unitytls_errorstate* errorState, out UnityTls.unitytls_x509list* nativeCertChain, out UnityTls.unitytls_key* nativeKey); // 0x0000000181823EB0-0x00000001818241F0
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override ValueTuple<int, bool> Read(byte[] buffer, int offset, int count); // 0x0000000181824A90-0x0000000181824C90
		public override ValueTuple<int, bool> Write(byte[] buffer, int offset, int count); // 0x00000001818257F0-0x00000001818259E0
		public override void Renegotiate(); // 0x0000000181824C90-0x0000000181824CD0
		public override bool PendingRenegotiation(); // 0x00000001802E7840-0x00000001802E7850
		public override void Shutdown(); // 0x0000000181824CD0-0x0000000181824E10
		protected override void Dispose(bool disposing); // 0x0000000181823D40-0x0000000181823EB0
		public override void StartHandshake(); // 0x0000000181824E10-0x0000000181825060
		public override bool ProcessHandshake(); // 0x0000000181824380-0x00000001818246B0
		public override void FinishHandshake(); // 0x00000001818241F0-0x0000000181824380
		[MonoPInvokeCallback(typeof(UnityTls.unitytls_tlsctx_write_callback))]
		private static unsafe IntPtr WriteCallback(void* userData, byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState); // 0x00000001818256B0-0x00000001818257F0
		private unsafe IntPtr WriteCallback(byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState); // 0x00000001818254B0-0x00000001818256B0
		[MonoPInvokeCallback(typeof(UnityTls.unitytls_tlsctx_read_callback))]
		private static unsafe IntPtr ReadCallback(void* userData, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState); // 0x00000001818246B0-0x00000001818247F0
		private unsafe IntPtr ReadCallback(byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState); // 0x00000001818247F0-0x0000000181824A90
		[MonoPInvokeCallback(typeof(UnityTls.unitytls_tlsctx_x509verify_callback))]
		private static unsafe UnityTls.unitytls_x509verify_result VerifyCallback(void* userData, UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_errorstate* errorState); // 0x0000000181825390-0x00000001818254B0
		private unsafe UnityTls.unitytls_x509verify_result VerifyCallback(UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_errorstate* errorState); // 0x0000000181825060-0x0000000181825390
		[MonoPInvokeCallback(typeof(UnityTls.unitytls_tlsctx_certificate_callback))]
		private static unsafe void CertificateCallback(void* userData, UnityTls.unitytls_tlsctx* ctx, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509name* caList, IntPtr caListLen, UnityTls.unitytls_x509list_ref* chain, UnityTls.unitytls_key_ref* key, UnityTls.unitytls_errorstate* errorState); // 0x0000000181823C00-0x0000000181823D40
		private unsafe void CertificateCallback(UnityTls.unitytls_tlsctx* ctx, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509name* caList, IntPtr caListLen, UnityTls.unitytls_x509list_ref* chain, UnityTls.unitytls_key_ref* key, UnityTls.unitytls_errorstate* errorState); // 0x00000001818238B0-0x0000000181823C00
	}
}
