/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsPkcs12 : MonoBtlsObject // TypeDefIndex: 8597
	{
		// Fields
		private MonoBtlsKey privateKey; // 0x20
	
		// Properties
		internal new BoringPkcs12Handle Handle { get; } // 0x000000018181A3C0-0x000000018181A440 
		public int Count { get; } // 0x000000018181A320-0x000000018181A3C0 
		public bool HasPrivateKey { get; } // 0x000000018181A440-0x000000018181A4E0 
	
		// Nested types
		internal class BoringPkcs12Handle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8598
		{
			// Constructors
			public BoringPkcs12Handle(IntPtr handle); // 0x000000018180FBD0-0x000000018180FBE0
	
			// Methods
			protected override bool ReleaseHandle(); // 0x000000018180FC60-0x000000018180FCE0
		}
	
		// Constructors
		internal MonoBtlsPkcs12(); // 0x000000018181A240-0x000000018181A320
	
		// Methods
		private static extern void mono_btls_pkcs12_free(IntPtr handle); // 0x000000018181A4E0-0x000000018181A560
		private static extern IntPtr mono_btls_pkcs12_new(); // 0x000000018181A860-0x000000018181A8D0
		private static extern int mono_btls_pkcs12_get_count(IntPtr handle); // 0x000000018181A5F0-0x000000018181A670
		private static extern IntPtr mono_btls_pkcs12_get_cert(IntPtr Handle, int index); // 0x000000018181A560-0x000000018181A5F0
		private static unsafe extern int mono_btls_pkcs12_import(IntPtr chain, void* data, int len, SafePasswordHandle password); // 0x000000018181A770-0x000000018181A860
		private static extern int mono_btls_pkcs12_has_private_key(IntPtr pkcs12); // 0x000000018181A6F0-0x000000018181A770
		private static extern IntPtr mono_btls_pkcs12_get_private_key(IntPtr pkcs12); // 0x000000018181A670-0x000000018181A6F0
		public MonoBtlsX509 GetCertificate(int index); // 0x0000000181819CB0-0x0000000181819EB0
		public void Import(byte[] buffer, SafePasswordHandle password); // 0x000000018181A0D0-0x000000018181A240
		public MonoBtlsKey GetPrivateKey(); // 0x0000000181819EB0-0x000000018181A0D0
	}
}
