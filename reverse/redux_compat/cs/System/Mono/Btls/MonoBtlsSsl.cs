/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Util;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsSsl : MonoBtlsObject // TypeDefIndex: 8603
	{
		// Fields
		private MonoBtlsBio bio; // 0x20
		private PrintErrorsCallbackFunc printErrorsFunc; // 0x28
		private IntPtr printErrorsFuncPtr; // 0x30
	
		// Properties
		internal new BoringSslHandle Handle { get; } // 0x0000000181B49CA0-0x0000000181B49D20 
	
		// Nested types
		internal class BoringSslHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8604
		{
			// Constructors
			public BoringSslHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B41530-0x0000000181B415C0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int PrintErrorsCallbackFunc(IntPtr str, IntPtr len, IntPtr ctx); // TypeDefIndex: 8605; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		public MonoBtlsSsl(MonoBtlsSslCtx ctx); // 0x0000000181B49A50-0x0000000181B49CA0
	
		// Methods
		private static extern void mono_btls_ssl_destroy(IntPtr handle); // 0x0000000181B49F30-0x0000000181B49FB0
		private static extern IntPtr mono_btls_ssl_new(IntPtr handle); // 0x0000000181B4A2C0-0x0000000181B4A340
		private static extern int mono_btls_ssl_use_certificate(IntPtr handle, IntPtr x509); // 0x0000000181B4A7B0-0x0000000181B4A840
		private static extern int mono_btls_ssl_use_private_key(IntPtr handle, IntPtr key); // 0x0000000181B4A840-0x0000000181B4A8D0
		private static extern int mono_btls_ssl_add_chain_certificate(IntPtr handle, IntPtr x509); // 0x0000000181B49DA0-0x0000000181B49E30
		private static extern int mono_btls_ssl_accept(IntPtr handle); // 0x0000000181B49D20-0x0000000181B49DA0
		private static extern int mono_btls_ssl_connect(IntPtr handle); // 0x0000000181B49EB0-0x0000000181B49F30
		private static extern int mono_btls_ssl_handshake(IntPtr handle); // 0x0000000181B4A240-0x0000000181B4A2C0
		private static extern void mono_btls_ssl_close(IntPtr handle); // 0x0000000181B49E30-0x0000000181B49EB0
		private static extern int mono_btls_ssl_shutdown(IntPtr handle); // 0x0000000181B4A730-0x0000000181B4A7B0
		private static extern void mono_btls_ssl_set_quiet_shutdown(IntPtr handle, int mode); // 0x0000000181B4A580-0x0000000181B4A610
		private static extern void mono_btls_ssl_set_bio(IntPtr handle, IntPtr bio); // 0x0000000181B4A4F0-0x0000000181B4A580
		private static extern int mono_btls_ssl_read(IntPtr handle, IntPtr data, int len); // 0x0000000181B4A3D0-0x0000000181B4A470
		private static extern int mono_btls_ssl_write(IntPtr handle, IntPtr data, int len); // 0x0000000181B4A8D0-0x0000000181B4A970
		private static extern int mono_btls_ssl_get_error(IntPtr handle, int ret_code); // 0x0000000181B4A030-0x0000000181B4A0C0
		private static extern int mono_btls_ssl_get_version(IntPtr handle); // 0x0000000181B4A1C0-0x0000000181B4A240
		private static extern int mono_btls_ssl_get_cipher(IntPtr handle); // 0x0000000181B49FB0-0x0000000181B4A030
		private static extern IntPtr mono_btls_ssl_get_peer_certificate(IntPtr handle); // 0x0000000181B4A0C0-0x0000000181B4A140
		private static extern void mono_btls_ssl_print_errors_cb(IntPtr func, IntPtr ctx); // 0x0000000181B4A340-0x0000000181B4A3D0
		private static extern int mono_btls_ssl_set_server_name(IntPtr handle, IntPtr name); // 0x0000000181B4A6A0-0x0000000181B4A730
		private static extern IntPtr mono_btls_ssl_get_server_name(IntPtr handle); // 0x0000000181B4A140-0x0000000181B4A1C0
		private static extern void mono_btls_ssl_set_renegotiate_mode(IntPtr handle, int mode); // 0x0000000181B4A610-0x0000000181B4A6A0
		private static extern int mono_btls_ssl_renegotiate_pending(IntPtr handle); // 0x0000000181B4A470-0x0000000181B4A4F0
		private static BoringSslHandle Create_internal(MonoBtlsSslCtx ctx); // 0x0000000181B485A0-0x0000000181B486D0
		public void SetBio(MonoBtlsBio bio); // 0x0000000181B490B0-0x0000000181B491A0
		private Exception ThrowError([CallerMemberName] string callerName = null); // 0x0000000181B497A0-0x0000000181B49940
		private MonoBtlsSslError GetError(int ret_code); // 0x0000000181B487B0-0x0000000181B48830
		public void SetCertificate(MonoBtlsX509 x509); // 0x0000000181B491A0-0x0000000181B492A0
		public void SetPrivateKey(MonoBtlsKey key); // 0x0000000181B492A0-0x0000000181B493A0
		public void AddIntermediateCertificate(MonoBtlsX509 x509); // 0x0000000181B48320-0x0000000181B48420
		public MonoBtlsSslError Accept(); // 0x0000000181B48260-0x0000000181B48320
		public MonoBtlsSslError Connect(); // 0x0000000181B484E0-0x0000000181B485A0
		public MonoBtlsSslError Handshake(); // 0x0000000181B48C50-0x0000000181B48D10
		[MonoPInvokeCallback(typeof(PrintErrorsCallbackFunc))]
		private static int PrintErrorsCallback(IntPtr str, IntPtr len, IntPtr ctx); // 0x0000000181B48D10-0x0000000181B48E30
		public string GetErrors(); // 0x0000000181B48830-0x0000000181B489C0
		public void PrintErrors(); // 0x0000000181B48E30-0x0000000181B48F10
		public MonoBtlsSslError Read(IntPtr data, ref int dataSize); // 0x0000000181B48F10-0x0000000181B49010
		public MonoBtlsSslError Write(IntPtr data, ref int dataSize); // 0x0000000181B49940-0x0000000181B49A50
		public int GetVersion(); // 0x0000000181B48BB0-0x0000000181B48C50
		public int GetCipher(); // 0x0000000181B486D0-0x0000000181B487B0
		public MonoBtlsX509 GetPeerCertificate(); // 0x0000000181B489C0-0x0000000181B48AE0
		public void SetServerName(string name); // 0x0000000181B494F0-0x0000000181B496D0
		public string GetServerName(); // 0x0000000181B48AE0-0x0000000181B48BB0
		public void Shutdown(); // 0x0000000181B496D0-0x0000000181B497A0
		public void SetQuietShutdown(); // 0x0000000181B493A0-0x0000000181B49440
		protected override void Close(); // 0x0000000181B48420-0x0000000181B484E0
		public void SetRenegotiateMode(MonoBtlsSslRenegotiateMode mode); // 0x0000000181B49440-0x0000000181B494F0
		public bool RenegotiatePending(); // 0x0000000181B49010-0x0000000181B490B0
	}
}
