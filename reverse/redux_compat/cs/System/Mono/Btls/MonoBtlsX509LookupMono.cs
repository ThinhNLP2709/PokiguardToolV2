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
	internal abstract class MonoBtlsX509LookupMono : MonoBtlsObject // TypeDefIndex: 8624
	{
		// Fields
		private GCHandle gch; // 0x20
		private IntPtr instance; // 0x28
		private BySubjectFunc bySubjectFunc; // 0x30
		private IntPtr bySubjectFuncPtr; // 0x38
		private MonoBtlsX509Lookup lookup; // 0x40
	
		// Properties
		internal new BoringX509LookupMonoHandle Handle { get; } // 0x0000000181B4C870-0x0000000181B4C8F0 
	
		// Nested types
		internal class BoringX509LookupMonoHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8625
		{
			// Constructors
			public BoringX509LookupMonoHandle(IntPtr handle); // 0x0000000181B41520-0x0000000181B41530
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181B41760-0x0000000181B417E0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BySubjectFunc(IntPtr instance, IntPtr name, out IntPtr x509_ptr); // TypeDefIndex: 8626; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		internal MonoBtlsX509LookupMono(); // 0x0000000181B4C5F0-0x0000000181B4C870
	
		// Methods
		private static extern IntPtr mono_btls_x509_lookup_mono_new(); // 0x0000000181B4CA10-0x0000000181B4CA80
		private static extern void mono_btls_x509_lookup_mono_init(IntPtr handle, IntPtr instance, IntPtr by_subject_func); // 0x0000000181B4C970-0x0000000181B4CA10
		private static extern int mono_btls_x509_lookup_mono_free(IntPtr handle); // 0x0000000181B4C8F0-0x0000000181B4C970
		internal void Install(MonoBtlsX509Lookup lookup); // 0x0000000181B4C2F0-0x0000000181B4C350
		protected void AddCertificate(MonoBtlsX509 certificate); // 0x0000000181B4C130-0x0000000181B4C250
		protected abstract MonoBtlsX509 OnGetBySubject(MonoBtlsX509Name name);
		[MonoPInvokeCallback(typeof(BySubjectFunc))]
		private static int OnGetBySubject(IntPtr instance, IntPtr name_ptr, out IntPtr x509_ptr); // 0x0000000181B4C350-0x0000000181B4C5F0
		protected override void Close(); // 0x0000000181B4C250-0x0000000181B4C2F0
	}
}
