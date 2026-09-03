/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsX509StoreCtx : MonoBtlsObject // TypeDefIndex: 8634
	{
		// Fields
		private int? verifyResult; // 0x20
	
		// Properties
		internal new BoringX509StoreCtxHandle Handle { get; } // 0x0000000181B4F140-0x0000000181B4F1C0 
		public int VerifyResult { get; } // 0x0000000181B4F1C0-0x0000000181B4F220 
	
		// Nested types
		internal class BoringX509StoreCtxHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8635
		{
			// Fields
			private bool dontFree; // 0x20
	
			// Constructors
			internal BoringX509StoreCtxHandle(IntPtr handle, bool ownsHandle = true /* Metadata: 0x0069DD57 */); // 0x0000000181B41870-0x0000000181B418A0
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B418A0-0x0000000181B41930
		}
	
		// Constructors
		internal MonoBtlsX509StoreCtx(); // 0x0000000181B4F030-0x0000000181B4F110
		internal MonoBtlsX509StoreCtx(int preverify_ok, IntPtr store_ctx); // 0x0000000181B4EEE0-0x0000000181B4F030
		internal MonoBtlsX509StoreCtx(BoringX509StoreCtxHandle ptr, int? verifyResult); // 0x0000000181B4F110-0x0000000181B4F140
	
		// Methods
		private static extern IntPtr mono_btls_x509_store_ctx_new(); // 0x0000000181B4F550-0x0000000181B4F5C0
		private static extern IntPtr mono_btls_x509_store_ctx_from_ptr(IntPtr ctx); // 0x0000000181B4F2A0-0x0000000181B4F320
		private static extern MonoBtlsX509Error mono_btls_x509_store_ctx_get_error(IntPtr handle, out IntPtr error_string); // 0x0000000181B4F3A0-0x0000000181B4F430
		private static extern IntPtr mono_btls_x509_store_ctx_get_chain(IntPtr handle); // 0x0000000181B4F320-0x0000000181B4F3A0
		private static extern int mono_btls_x509_store_ctx_init(IntPtr handle, IntPtr store, IntPtr chain); // 0x0000000181B4F4B0-0x0000000181B4F550
		private static extern int mono_btls_x509_store_ctx_set_param(IntPtr handle, IntPtr param); // 0x0000000181B4F5C0-0x0000000181B4F650
		private static extern int mono_btls_x509_store_ctx_verify_cert(IntPtr handle); // 0x0000000181B4F6D0-0x0000000181B4F750
		private static extern IntPtr mono_btls_x509_store_ctx_get_untrusted(IntPtr handle); // 0x0000000181B4F430-0x0000000181B4F4B0
		private static extern IntPtr mono_btls_x509_store_ctx_up_ref(IntPtr handle); // 0x0000000181B4F650-0x0000000181B4F6D0
		private static extern void mono_btls_x509_store_ctx_free(IntPtr handle); // 0x0000000181B4F220-0x0000000181B4F2A0
		private static BoringX509StoreCtxHandle Create_internal(IntPtr store_ctx); // 0x0000000181B4E7B0-0x0000000181B4E8C0
		public MonoBtlsX509Error GetError(); // 0x0000000181B4E9F0-0x0000000181B4EAA0
		public MonoBtlsX509Chain GetChain(); // 0x0000000181B4E8C0-0x0000000181B4E9F0
		public MonoBtlsX509Chain GetUntrusted(); // 0x0000000181B4EAA0-0x0000000181B4EBD0
		public void Initialize(MonoBtlsX509Store store, MonoBtlsX509Chain chain); // 0x0000000181B4EBD0-0x0000000181B4ED10
		public void SetVerifyParam(MonoBtlsX509VerifyParam param); // 0x0000000181B4ED10-0x0000000181B4EE10
		public int Verify(); // 0x0000000181B4EE10-0x0000000181B4EEE0
		public MonoBtlsX509StoreCtx Copy(); // 0x0000000181B4E660-0x0000000181B4E7B0
	}
}
