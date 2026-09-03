/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Protocol.Ntlm
{
	public class Type1Message : MessageBase // TypeDefIndex: 13858
	{
		// Fields
		private string _host; // 0x18
		private string _domain; // 0x20
	
		// Properties
		public string Domain { set; } // 0x000000018142A640-0x000000018142A6C0
		public string Host { set; } // 0x000000018142A6C0-0x000000018142A740
	
		// Constructors
		public Type1Message(); // 0x000000018142A5B0-0x000000018142A640
	
		// Methods
		protected override void Decode(byte[] message); // 0x000000018142A1E0-0x000000018142A300
		public override byte[] GetBytes(); // 0x000000018142A300-0x000000018142A5B0
	}
}
