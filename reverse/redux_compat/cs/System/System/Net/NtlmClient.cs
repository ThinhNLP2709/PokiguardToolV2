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
	internal class NtlmClient : IAuthenticationModule // TypeDefIndex: 9143
	{
		// Fields
		private IAuthenticationModule authObject; // 0x10
	
		// Properties
		public string AuthenticationType { get; } // 0x0000000181B11900-0x0000000181B11930 
	
		// Constructors
		public NtlmClient(); // 0x0000000181B11890-0x0000000181B11900
	
		// Methods
		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials); // 0x0000000181B117B0-0x0000000181B11890
		public Authorization PreAuthenticate(WebRequest webRequest, ICredentials credentials); // 0x00000001802E7860-0x00000001802E7870
	}
}
