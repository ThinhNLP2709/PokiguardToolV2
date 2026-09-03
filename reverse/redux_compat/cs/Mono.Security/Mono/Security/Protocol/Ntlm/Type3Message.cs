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
	public class Type3Message : MessageBase // TypeDefIndex: 13860
	{
		// Fields
		private NtlmAuthLevel _level; // 0x18
		private byte[] _challenge; // 0x20
		private string _host; // 0x28
		private string _domain; // 0x30
		private string _username; // 0x38
		private string _password; // 0x40
		private Type2Message _type2; // 0x48
		private byte[] _lm; // 0x50
		private byte[] _nt; // 0x58
	
		// Properties
		public string Domain { set; } // 0x000000018142BAA0-0x000000018142BB20
		public string Password { set; } // 0x0000000180378120-0x0000000180378130
		public string Username { set; } // 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public Type3Message(Type2Message type2); // 0x000000018142B840-0x000000018142BAA0
	
		// Methods
		~Type3Message(); // 0x000000018142AFA0-0x000000018142B070
		protected override void Decode(byte[] message); // 0x000000018142AC40-0x000000018142AF10
		private string DecodeString(byte[] buffer, int offset, int len); // 0x000000018142ABD0-0x000000018142AC40
		private byte[] EncodeString(string text); // 0x000000018142AF10-0x000000018142AFA0
		public override byte[] GetBytes(); // 0x000000018142B070-0x000000018142B840
	}
}
