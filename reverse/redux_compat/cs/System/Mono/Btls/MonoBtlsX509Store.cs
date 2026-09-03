/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsX509Store : MonoBtlsObject // TypeDefIndex: 8632
	{
		// Fields
		private Dictionary<IntPtr, MonoBtlsX509Lookup> lookupHash; // 0x20
	
		// Properties
		internal new BoringX509StoreHandle Handle { get; } // 0x0000000181B50770-0x0000000181B507F0 
	
		// Nested types
		internal class BoringX509StoreHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8633
		{
			// Constructors
			public BoringX509StoreHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B41930-0x0000000181B419B0
		}
	
		// Constructors
		internal MonoBtlsX509Store(); // 0x0000000181B50530-0x0000000181B50640
		internal MonoBtlsX509Store(MonoBtlsSslCtx.BoringSslCtxHandle ctx); // 0x0000000181B50640-0x0000000181B50770
	
		// Methods
		private static extern IntPtr mono_btls_x509_store_new(); // 0x0000000181B50980-0x0000000181B509F0
		private static extern IntPtr mono_btls_x509_store_from_ssl_ctx(IntPtr handle); // 0x0000000181B50900-0x0000000181B50980
		private static extern int mono_btls_x509_store_add_cert(IntPtr handle, IntPtr x509); // 0x0000000181B507F0-0x0000000181B50880
		private static extern void mono_btls_x509_store_free(IntPtr handle); // 0x0000000181B50880-0x0000000181B50900
		private static BoringX509StoreHandle Create_internal(); // 0x0000000181B50430-0x0000000181B50530
		private static BoringX509StoreHandle Create_internal(MonoBtlsSslCtx.BoringSslCtxHandle ctx); // 0x0000000181B50310-0x0000000181B50430
		public void AddCertificate(MonoBtlsX509 x509); // 0x0000000181B4FD80-0x0000000181B4FE80
		public MonoBtlsX509Lookup AddLookup(MonoBtlsX509LookupType type); // 0x0000000181B4FFA0-0x0000000181B50170
		public void AddDirectoryLookup(string dir, MonoBtlsX509FileType type); // 0x0000000181B4FF50-0x0000000181B4FFA0
		public void AddCollection(X509CertificateCollection collection, MonoBtlsX509TrustKind trust); // 0x0000000181B4FE80-0x0000000181B4FF50
		protected override void Close(); // 0x0000000181B50170-0x0000000181B50310
	}
}
