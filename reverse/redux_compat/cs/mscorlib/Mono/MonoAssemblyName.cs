/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono
{
	internal struct MonoAssemblyName // TypeDefIndex: 2086
	{
		// Fields
		internal IntPtr name; // 0x00
		internal IntPtr culture; // 0x08
		internal IntPtr hash_value; // 0x10
		internal IntPtr public_key; // 0x18
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte public_key_token[0]; // 0x20
		internal uint hash_alg; // 0x34
		internal uint hash_len; // 0x38
		internal uint flags; // 0x3C
		internal ushort major; // 0x40
		internal ushort minor; // 0x42
		internal ushort build; // 0x44
		internal ushort revision; // 0x46
		internal ushort arch; // 0x48
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _public_key_token_e__FixedBuffer // TypeDefIndex: 2087
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	}
}
