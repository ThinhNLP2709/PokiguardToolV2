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
	internal class MonoBtlsX509 : MonoBtlsObject // TypeDefIndex: 8615
	{
		// Properties
		internal new BoringX509Handle Handle { get; } // 0x0000000181B522A0-0x0000000181B52320 
	
		// Nested types
		internal class BoringX509Handle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8616
		{
			// Constructors
			public BoringX509Handle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B41640-0x0000000181B416D0
			public IntPtr StealHandle(); // 0x0000000181B416D0-0x0000000181B416E0
		}
	
		// Constructors
		internal MonoBtlsX509(BoringX509Handle handle); // 0x0000000180E027D0-0x0000000180E027E0
	
		// Methods
		private static extern IntPtr mono_btls_x509_up_ref(IntPtr handle); // 0x0000000181B52680-0x0000000181B52700
		private static extern IntPtr mono_btls_x509_from_data(IntPtr data, int len, MonoBtlsX509Format format); // 0x0000000181B524C0-0x0000000181B52560
		private static extern IntPtr mono_btls_x509_get_subject_name(IntPtr handle); // 0x0000000181B52600-0x0000000181B52680
		private static extern int mono_btls_x509_get_raw_data(IntPtr handle, IntPtr bio, MonoBtlsX509Format format); // 0x0000000181B52560-0x0000000181B52600
		private static extern int mono_btls_x509_cmp(IntPtr a, IntPtr b); // 0x0000000181B523B0-0x0000000181B52440
		private static extern void mono_btls_x509_free(IntPtr handle); // 0x0000000181B52440-0x0000000181B524C0
		private static extern int mono_btls_x509_add_explicit_trust(IntPtr handle, MonoBtlsX509TrustKind kind); // 0x0000000181B52320-0x0000000181B523B0
		internal MonoBtlsX509 Copy(); // 0x0000000181B51910-0x0000000181B51A40
		public static MonoBtlsX509 LoadFromData(byte[] buffer, MonoBtlsX509Format format); // 0x0000000181B51FB0-0x0000000181B522A0
		public MonoBtlsX509Name GetSubjectName(); // 0x0000000181B51E70-0x0000000181B51FB0
		public long GetSubjectNameHash(); // 0x0000000181B51C50-0x0000000181B51E70
		public byte[] GetRawData(MonoBtlsX509Format format); // 0x0000000181B51A40-0x0000000181B51C50
		public static int Compare(MonoBtlsX509 a, MonoBtlsX509 b); // 0x0000000181B51840-0x0000000181B51910
		public void AddExplicitTrust(MonoBtlsX509TrustKind kind); // 0x0000000181B51750-0x0000000181B51840
	}
}
