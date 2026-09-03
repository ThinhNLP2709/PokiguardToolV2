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
	internal class MonoBtlsSslCtx : MonoBtlsObject // TypeDefIndex: 8606
	{
		// Fields
		private NativeVerifyFunc verifyFunc; // 0x20
		private NativeSelectFunc selectFunc; // 0x28
		private NativeServerNameFunc serverNameFunc; // 0x30
		private IntPtr verifyFuncPtr; // 0x38
		private IntPtr selectFuncPtr; // 0x40
		private IntPtr serverNameFuncPtr; // 0x48
		private MonoBtlsVerifyCallback verifyCallback; // 0x50
		private MonoBtlsSelectCallback selectCallback; // 0x58
		private MonoBtlsServerNameCallback serverNameCallback; // 0x60
		private MonoBtlsX509Store store; // 0x68
		private GCHandle instance; // 0x70
		private IntPtr instancePtr; // 0x78
	
		// Properties
		internal new BoringSslCtxHandle Handle { get; } // 0x0000000181B47BB0-0x0000000181B47C30 
		public MonoBtlsX509Store CertificateStore { get; } // 0x0000000180316960-0x0000000180316970 
	
		// Nested types
		internal class BoringSslCtxHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8607
		{
			// Constructors
			public BoringSslCtxHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B414A0-0x0000000181B41520
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeVerifyFunc(IntPtr instance, int preverify_ok, IntPtr ctx); // TypeDefIndex: 8608; 0x0000000180A72B30-0x0000000180A72B50
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeSelectFunc(IntPtr instance, int count, IntPtr sizes, IntPtr data); // TypeDefIndex: 8609; 0x000000018043A200-0x000000018043A220
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int NativeServerNameFunc(IntPtr instance); // TypeDefIndex: 8610; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public MonoBtlsSslCtx(); // 0x0000000181B47610-0x0000000181B476E0
		internal MonoBtlsSslCtx(BoringSslCtxHandle handle); // 0x0000000181B476E0-0x0000000181B47BB0
	
		// Methods
		private static extern IntPtr mono_btls_ssl_ctx_new(); // 0x0000000181B47D40-0x0000000181B47DB0
		private static extern int mono_btls_ssl_ctx_free(IntPtr handle); // 0x0000000181B47C30-0x0000000181B47CB0
		private static extern void mono_btls_ssl_ctx_initialize(IntPtr handle, IntPtr instance); // 0x0000000181B47CB0-0x0000000181B47D40
		private static extern void mono_btls_ssl_ctx_set_cert_verify_callback(IntPtr handle, IntPtr func, int cert_required); // 0x0000000181B47E40-0x0000000181B47EE0
		private static extern void mono_btls_ssl_ctx_set_cert_select_callback(IntPtr handle, IntPtr func); // 0x0000000181B47DB0-0x0000000181B47E40
		private static extern void mono_btls_ssl_ctx_set_min_version(IntPtr handle, int version); // 0x0000000181B480B0-0x0000000181B48140
		private static extern void mono_btls_ssl_ctx_set_max_version(IntPtr handle, int version); // 0x0000000181B48020-0x0000000181B480B0
		private static extern int mono_btls_ssl_ctx_set_ciphers(IntPtr handle, int count, IntPtr data, int allow_unsupported); // 0x0000000181B47EE0-0x0000000181B47F80
		private static extern int mono_btls_ssl_ctx_set_verify_param(IntPtr handle, IntPtr param); // 0x0000000181B481D0-0x0000000181B48260
		private static extern int mono_btls_ssl_ctx_set_client_ca_list(IntPtr handle, int count, IntPtr sizes, IntPtr data); // 0x0000000181B47F80-0x0000000181B48020
		private static extern void mono_btls_ssl_ctx_set_server_name_callback(IntPtr handle, IntPtr func); // 0x0000000181B48140-0x0000000181B481D0
		private int VerifyCallback(bool preverify_ok, MonoBtlsX509StoreCtx ctx); // 0x0000000181B475E0-0x0000000181B47610
		[MonoPInvokeCallback(typeof(NativeVerifyFunc))]
		private static int NativeVerifyCallback(IntPtr instance, int preverify_ok, IntPtr store_ctx); // 0x0000000181B466B0-0x0000000181B46A10
		[MonoPInvokeCallback(typeof(NativeSelectFunc))]
		private static int NativeSelectCallback(IntPtr instance, int count, IntPtr sizes, IntPtr data); // 0x0000000181B463F0-0x0000000181B46570
		private static string[] CopyIssuers(int count, IntPtr sizesPtr, IntPtr dataPtr); // 0x0000000181B45F60-0x0000000181B463F0
		public void SetVerifyCallback(MonoBtlsVerifyCallback callback, bool client_cert_required); // 0x0000000181B473F0-0x0000000181B474D0
		public void SetSelectCallback(MonoBtlsSelectCallback callback); // 0x0000000181B47270-0x0000000181B47330
		public void SetMinVersion(int version); // 0x0000000181B471C0-0x0000000181B47270
		public void SetMaxVersion(int version); // 0x0000000181B47110-0x0000000181B471C0
		public void SetCiphers(short[] ciphers, bool allow_unsupported); // 0x0000000181B46A10-0x0000000181B46C60
		public void SetVerifyParam(MonoBtlsX509VerifyParam param); // 0x0000000181B474D0-0x0000000181B475E0
		public void SetClientCertificateIssuers(string[] acceptableIssuers); // 0x0000000181B46C60-0x0000000181B47110
		public void SetServerNameCallback(MonoBtlsServerNameCallback callback); // 0x0000000181B47330-0x0000000181B473F0
		[MonoPInvokeCallback(typeof(NativeServerNameFunc))]
		private static int NativeServerNameCallback(IntPtr instance); // 0x0000000181B46570-0x0000000181B466B0
		protected override void Close(); // 0x0000000181B45F10-0x0000000181B45F60
	}
}
