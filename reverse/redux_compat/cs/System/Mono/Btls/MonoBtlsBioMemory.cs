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
	internal class MonoBtlsBioMemory : MonoBtlsBio // TypeDefIndex: 8583
	{
		// Constructors
		public MonoBtlsBioMemory(); // 0x0000000181815020-0x0000000181815100
	
		// Methods
		private static extern IntPtr mono_btls_bio_mem_new(); // 0x0000000181815190-0x0000000181815200
		private static extern int mono_btls_bio_mem_get_data(IntPtr handle, out IntPtr data); // 0x0000000181815100-0x0000000181815190
		public byte[] GetData(); // 0x0000000181814DF0-0x0000000181815020
	}
}
