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

namespace System.Net
{
	public class IPHostEntry // TypeDefIndex: 9039
	{
		// Fields
		private string hostName; // 0x10
		private string[] aliases; // 0x18
		private IPAddress[] addressList; // 0x20
		internal bool isTrustedHost; // 0x28
	
		// Properties
		public string HostName { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string[] Aliases { set; } // 0x00000001802FAF70-0x00000001802FAF80
		public IPAddress[] AddressList { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public IPHostEntry(); // 0x0000000181BF2EE0-0x0000000181BF2EF0
	}
}
