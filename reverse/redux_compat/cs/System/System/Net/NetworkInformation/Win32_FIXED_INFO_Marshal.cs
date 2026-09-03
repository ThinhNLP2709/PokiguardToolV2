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

namespace System.Net.NetworkInformation
{
	internal struct Win32_FIXED_INFO_Marshal // TypeDefIndex: 9196
	{
		// Fields
		public unsafe fixed /* 0x00000000-0x00000000 */ byte HostName[0]; // 0x00
		public unsafe fixed /* 0x00000000-0x00000000 */ byte DomainName[0]; // 0x84
		public IntPtr CurrentDnsServer; // 0x108
		public Win32_IP_ADDR_STRING DnsServerList; // 0x110
		public NetBiosNodeType NodeType; // 0x130
		public unsafe fixed /* 0x00000000-0x00000000 */ byte ScopeId[0]; // 0x134
		public uint EnableRouting; // 0x238
		public uint EnableProxy; // 0x23C
		public uint EnableDns; // 0x240
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _HostName_e__FixedBuffer // TypeDefIndex: 9197
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _DomainName_e__FixedBuffer // TypeDefIndex: 9198
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _ScopeId_e__FixedBuffer // TypeDefIndex: 9199
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	}
}
