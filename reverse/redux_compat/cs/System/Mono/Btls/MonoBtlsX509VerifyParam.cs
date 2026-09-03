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
	internal class MonoBtlsX509VerifyParam : MonoBtlsObject // TypeDefIndex: 8639
	{
		// Properties
		internal new BoringX509VerifyParamHandle Handle { get; } // 0x0000000181B513A0-0x0000000181B51420 
		public bool CanModify { get; } // 0x0000000181B51300-0x0000000181B513A0 
	
		// Nested types
		internal class BoringX509VerifyParamHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8640
		{
			// Constructors
			public BoringX509VerifyParamHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B419B0-0x0000000181B41A30
		}
	
		// Constructors
		internal MonoBtlsX509VerifyParam(BoringX509VerifyParamHandle handle); // 0x0000000180E027D0-0x0000000180E027E0
	
		// Methods
		private static extern IntPtr mono_btls_x509_verify_param_copy(IntPtr handle); // 0x0000000181B514A0-0x0000000181B51520
		private static extern IntPtr mono_btls_x509_verify_param_lookup(IntPtr name); // 0x0000000181B515A0-0x0000000181B51620
		private static extern int mono_btls_x509_verify_param_can_modify(IntPtr param); // 0x0000000181B51420-0x0000000181B514A0
		private static extern int mono_btls_x509_verify_param_set_host(IntPtr handle, IntPtr name, int namelen); // 0x0000000181B51620-0x0000000181B516C0
		private static extern int mono_btls_x509_verify_param_set_time(IntPtr handle, long time); // 0x0000000181B516C0-0x0000000181B51750
		private static extern void mono_btls_x509_verify_param_free(IntPtr handle); // 0x0000000181B51520-0x0000000181B515A0
		public MonoBtlsX509VerifyParam Copy(); // 0x0000000181B509F0-0x0000000181B50B20
		public static MonoBtlsX509VerifyParam GetSslClient(); // 0x0000000181B50B20-0x0000000181B50B60
		public static MonoBtlsX509VerifyParam GetSslServer(); // 0x0000000181B50B60-0x0000000181B50BA0
		public static MonoBtlsX509VerifyParam Lookup(string name, bool fail = false /* Metadata: 0x0069DD68 */); // 0x0000000181B50BA0-0x0000000181B50E70
		private void WantToModify(); // 0x0000000181B51210-0x0000000181B51300
		public void SetHost(string name); // 0x0000000181B50E70-0x0000000181B51060
		public void SetTime(DateTime time); // 0x0000000181B51060-0x0000000181B51210
	}
}
