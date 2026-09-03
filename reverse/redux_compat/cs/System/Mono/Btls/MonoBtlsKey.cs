/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsKey : MonoBtlsObject // TypeDefIndex: 8593
	{
		// Properties
		internal new BoringKeyHandle Handle { get; } // 0x00000001818191F0-0x0000000181819270 
	
		// Nested types
		internal class BoringKeyHandle : MonoBtlsObject.MonoBtlsHandle // TypeDefIndex: 8594
		{
			// Constructors
			internal BoringKeyHandle(IntPtr handle); // 0x000000018180FBD0-0x000000018180FBE0
	
			// Methods
			protected override bool ReleaseHandle(); // 0x000000018180FBE0-0x000000018180FC60
		}
	
		// Constructors
		internal MonoBtlsKey(BoringKeyHandle handle); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		private static extern IntPtr mono_btls_key_new(); // 0x0000000181819440-0x00000001818194B0
		private static extern void mono_btls_key_free(IntPtr handle); // 0x0000000181819310-0x0000000181819390
		private static extern IntPtr mono_btls_key_up_ref(IntPtr handle); // 0x00000001818194B0-0x0000000181819530
		private static extern int mono_btls_key_get_bytes(IntPtr handle, out IntPtr data, out int size, int include_private_bits); // 0x0000000181819390-0x0000000181819440
		private static extern int mono_btls_key_assign_rsa_private_key(IntPtr handle, byte[] der, int der_length); // 0x0000000181819270-0x0000000181819310
		public byte[] GetBytes(bool include_private_bits); // 0x0000000181819030-0x00000001818191F0
		public MonoBtlsKey Copy(); // 0x0000000181818CE0-0x0000000181818E30
		public static MonoBtlsKey CreateFromRSAPrivateKey(RSA privateKey); // 0x0000000181818E30-0x0000000181819030
	}
}
