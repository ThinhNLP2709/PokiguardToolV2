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
	internal class MonoBtlsX509Chain : MonoBtlsObject // TypeDefIndex: 8617
	{
		// Properties
		internal new BoringX509ChainHandle Handle { get; } // 0x0000000181B4B810-0x0000000181B4B890 
		public int Count { get; } // 0x0000000181B4B770-0x0000000181B4B810 
	
		// Nested types
		internal class BoringX509ChainHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8618
		{
			// Constructors
			public BoringX509ChainHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B415C0-0x0000000181B41640
		}
	
		// Constructors
		public MonoBtlsX509Chain(); // 0x0000000181B4B6A0-0x0000000181B4B770
		internal MonoBtlsX509Chain(BoringX509ChainHandle handle); // 0x0000000180E027D0-0x0000000180E027E0
	
		// Methods
		private static extern IntPtr mono_btls_x509_chain_new(); // 0x0000000181B4BAB0-0x0000000181B4BB20
		private static extern int mono_btls_x509_chain_get_count(IntPtr handle); // 0x0000000181B4BA30-0x0000000181B4BAB0
		private static extern IntPtr mono_btls_x509_chain_get_cert(IntPtr Handle, int index); // 0x0000000181B4B9A0-0x0000000181B4BA30
		private static extern int mono_btls_x509_chain_add_cert(IntPtr chain, IntPtr x509); // 0x0000000181B4B890-0x0000000181B4B920
		private static extern IntPtr mono_btls_x509_chain_up_ref(IntPtr handle); // 0x0000000181B4BB20-0x0000000181B4BBA0
		private static extern void mono_btls_x509_chain_free(IntPtr handle); // 0x0000000181B4B920-0x0000000181B4B9A0
		public MonoBtlsX509 GetCertificate(int index); // 0x0000000181B4B510-0x0000000181B4B6A0
		public void AddCertificate(MonoBtlsX509 x509); // 0x0000000181B4B320-0x0000000181B4B3E0
		internal MonoBtlsX509Chain Copy(); // 0x0000000181B4B3E0-0x0000000181B4B510
	}
}
