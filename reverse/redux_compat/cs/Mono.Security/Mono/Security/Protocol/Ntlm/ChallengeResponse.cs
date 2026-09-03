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
	[Obsolete("Use of this API is highly discouraged, it selects legacy-mode LM/NTLM authentication, which sends your password in very weak encryption over the wire even if the server supports the more secure NTLMv2 / NTLMv2 Session. You need to use the new `Type3Message (Type2Message)\' constructor to use the more secure NTLMv2 / NTLMv2 Session authentication modes. These require the Type 2 message from the server to compute the response.")]
	public class ChallengeResponse : IDisposable // TypeDefIndex: 13852
	{
		// Fields
		private static byte[] magic; // 0x00
		private static byte[] nullEncMagic; // 0x08
		private bool _disposed; // 0x10
		private byte[] _challenge; // 0x18
		private byte[] _lmpwd; // 0x20
		private byte[] _ntpwd; // 0x28
	
		// Properties
		public string Password { set; } // 0x00000001814036A0-0x0000000181403A60
		public byte[] Challenge { set; } // 0x0000000181403550-0x00000001814036A0
		public byte[] LM { get; } // 0x0000000181403470-0x00000001814034E0 
		public byte[] NT { get; } // 0x00000001814034E0-0x0000000181403550 
	
		// Constructors
		public ChallengeResponse(); // 0x00000001814033F0-0x0000000181403470
		public ChallengeResponse(string password, byte[] challenge); // 0x0000000181403220-0x00000001814033F0
		static ChallengeResponse(); // 0x0000000181403140-0x0000000181403220
	
		// Methods
		~ChallengeResponse(); // 0x0000000181402AA0-0x0000000181402BC0
		public void Dispose(); // 0x0000000181402970-0x0000000181402A20
		private void Dispose(bool disposing); // 0x0000000181402A20-0x0000000181402AA0
		private byte[] GetResponse(byte[] pwd); // 0x0000000181402BC0-0x0000000181402E10
		private byte[] PrepareDESKey(byte[] key56bits, int position); // 0x0000000181402F60-0x0000000181403140
		private byte[] PasswordToKey(string password, int position); // 0x0000000181402E10-0x0000000181402F60
	}
}
