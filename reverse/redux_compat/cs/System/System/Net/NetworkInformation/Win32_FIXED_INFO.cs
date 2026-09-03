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
	internal struct Win32_FIXED_INFO // TypeDefIndex: 9195
	{
		// Fields
		public string HostName; // 0x00
		public string DomainName; // 0x08
		public IntPtr CurrentDnsServer; // 0x10
		public Win32_IP_ADDR_STRING DnsServerList; // 0x18
		public NetBiosNodeType NodeType; // 0x38
		public string ScopeId; // 0x40
		public uint EnableRouting; // 0x48
		public uint EnableProxy; // 0x4C
		public uint EnableDns; // 0x50
	}
}
