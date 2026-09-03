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
	internal class MonoBtlsX509Name : MonoBtlsObject // TypeDefIndex: 8629
	{
		// Properties
		internal new BoringX509NameHandle Handle { get; } // 0x0000000181B4E150-0x0000000181B4E1D0 
	
		// Nested types
		internal class BoringX509NameHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8630
		{
			// Fields
			private bool dontFree; // 0x20
	
			// Constructors
			internal BoringX509NameHandle(IntPtr handle, bool ownsHandle); // 0x0000000181B41870-0x0000000181B418A0
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B417E0-0x0000000181B41870
		}
	
		// Constructors
		internal MonoBtlsX509Name(BoringX509NameHandle handle); // 0x0000000180E027D0-0x0000000180E027E0
	
		// Methods
		private static extern long mono_btls_x509_name_hash(IntPtr handle); // 0x0000000181B4E5E0-0x0000000181B4E660
		private static extern int mono_btls_x509_name_get_entry_count(IntPtr handle); // 0x0000000181B4E2F0-0x0000000181B4E370
		private static extern MonoBtlsX509NameEntryType mono_btls_x509_name_get_entry_type(IntPtr name, int index); // 0x0000000181B4E4B0-0x0000000181B4E540
		private static extern int mono_btls_x509_name_get_entry_oid(IntPtr name, int index, IntPtr buffer, int size); // 0x0000000181B4E410-0x0000000181B4E4B0
		private static extern int mono_btls_x509_name_get_entry_oid_data(IntPtr name, int index, out IntPtr data); // 0x0000000181B4E370-0x0000000181B4E410
		private static extern int mono_btls_x509_name_get_entry_value(IntPtr name, int index, out int tag, out IntPtr str); // 0x0000000181B4E540-0x0000000181B4E5E0
		private static unsafe extern IntPtr mono_btls_x509_name_from_data(void* data, int len, int use_canon_enc); // 0x0000000181B4E250-0x0000000181B4E2F0
		private static extern void mono_btls_x509_name_free(IntPtr handle); // 0x0000000181B4E1D0-0x0000000181B4E250
		public long GetHash(); // 0x0000000181B4E0B0-0x0000000181B4E150
		public int GetEntryCount(); // 0x0000000181B4D940-0x0000000181B4D9E0
		public MonoBtlsX509NameEntryType GetEntryType(int index); // 0x0000000181B4DD90-0x0000000181B4DE80
		public string GetEntryOid(int index); // 0x0000000181B4DB30-0x0000000181B4DD90
		public byte[] GetEntryOidData(int index); // 0x0000000181B4D9E0-0x0000000181B4DB30
		public string GetEntryValue(int index, out int tag); // 0x0000000181B4DE80-0x0000000181B4E0B0
		public static MonoBtlsX509Name CreateFromData(byte[] data, bool use_canon_enc); // 0x0000000181B4D7B0-0x0000000181B4D940
	}
}
