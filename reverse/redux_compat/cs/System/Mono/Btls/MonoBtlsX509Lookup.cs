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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsX509Lookup : MonoBtlsObject // TypeDefIndex: 8622
	{
		// Fields
		private MonoBtlsX509Store store; // 0x20
		private MonoBtlsX509LookupType type; // 0x28
		private List<MonoBtlsX509LookupMono> monoLookups; // 0x30
	
		// Properties
		internal new BoringX509LookupHandle Handle { get; } // 0x0000000181B4D470-0x0000000181B4D4F0 
	
		// Nested types
		internal class BoringX509LookupHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8623
		{
			// Constructors
			public BoringX509LookupHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B416E0-0x0000000181B41760
		}
	
		// Constructors
		internal MonoBtlsX509Lookup(MonoBtlsX509Store store, MonoBtlsX509LookupType type); // 0x0000000181B4D300-0x0000000181B4D470
	
		// Methods
		private static extern IntPtr mono_btls_x509_lookup_new(IntPtr store, MonoBtlsX509LookupType type); // 0x0000000181B4D6A0-0x0000000181B4D730
		private static extern int mono_btls_x509_lookup_add_dir(IntPtr handle, IntPtr dir, MonoBtlsX509FileType type); // 0x0000000181B4D4F0-0x0000000181B4D590
		private static extern int mono_btls_x509_lookup_add_mono(IntPtr handle, IntPtr monoLookup); // 0x0000000181B4D590-0x0000000181B4D620
		private static extern void mono_btls_x509_lookup_free(IntPtr handle); // 0x0000000181B4D620-0x0000000181B4D6A0
		private static extern IntPtr mono_btls_x509_lookup_peek_lookup(IntPtr handle); // 0x0000000181B4D730-0x0000000181B4D7B0
		private static BoringX509LookupHandle Create_internal(MonoBtlsX509Store store, MonoBtlsX509LookupType type); // 0x0000000181B4D130-0x0000000181B4D260
		internal IntPtr GetNativeLookup(); // 0x0000000181B4D260-0x0000000181B4D300
		public void AddDirectory(string dir, MonoBtlsX509FileType type); // 0x0000000181B4CB90-0x0000000181B4CD60
		internal void AddMono(MonoBtlsX509LookupMono monoLookup); // 0x0000000181B4CD60-0x0000000181B4CFD0
		internal void AddCertificate(MonoBtlsX509 certificate); // 0x0000000181B4CA80-0x0000000181B4CB90
		protected override void Close(); // 0x0000000181B4CFD0-0x0000000181B4D130
	}
}
