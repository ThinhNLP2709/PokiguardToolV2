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
	internal class MonoBtlsBio : MonoBtlsObject // TypeDefIndex: 8581
	{
		// Properties
		protected internal new BoringBioHandle Handle { get; } // 0x0000000181816250-0x00000001818162D0 
	
		// Nested types
		protected internal class BoringBioHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8582
		{
			// Constructors
			public BoringBioHandle(IntPtr handle); // 0x000000018180FBD0-0x000000018180FBE0
	
			// Methods
			protected override bool ReleaseHandle(); // 0x000000018180FB30-0x000000018180FBD0
		}
	
		// Constructors
		internal MonoBtlsBio(BoringBioHandle handle); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		private static extern void mono_btls_bio_free(IntPtr handle); // 0x00000001818162D0-0x0000000181816350
	}
}
