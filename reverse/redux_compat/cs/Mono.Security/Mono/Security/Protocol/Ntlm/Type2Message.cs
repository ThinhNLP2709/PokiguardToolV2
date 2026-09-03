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
	public class Type2Message : MessageBase // TypeDefIndex: 13859
	{
		// Fields
		private byte[] _nonce; // 0x18
		private string _targetName; // 0x20
		private byte[] _targetInfo; // 0x28
	
		// Properties
		public byte[] Nonce { get; } // 0x000000018142AAD0-0x000000018142AB50 
		public string TargetName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public byte[] TargetInfo { get; } // 0x000000018142AB50-0x000000018142ABD0 
	
		// Constructors
		public Type2Message(byte[] message); // 0x000000018142AA20-0x000000018142AAD0
	
		// Methods
		~Type2Message(); // 0x000000018142A8D0-0x000000018142A950
		protected override void Decode(byte[] message); // 0x000000018142A740-0x000000018142A8D0
		public override byte[] GetBytes(); // 0x000000018142A950-0x000000018142AA20
	}
}
