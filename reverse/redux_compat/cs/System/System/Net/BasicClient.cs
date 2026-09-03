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
	internal class BasicClient : IAuthenticationModule // TypeDefIndex: 9111
	{
		// Properties
		public string AuthenticationType { get; } // 0x0000000181BFB880-0x0000000181BFB8B0 
	
		// Constructors
		public BasicClient(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials); // 0x0000000181BFB400-0x0000000181BFB4B0
		private static byte[] GetBytes(string str); // 0x0000000181BFB4B0-0x0000000181BFB560
		private static Authorization InternalAuthenticate(WebRequest webRequest, ICredentials credentials); // 0x0000000181BFB560-0x0000000181BFB860
		public Authorization PreAuthenticate(WebRequest webRequest, ICredentials credentials); // 0x0000000181BFB860-0x0000000181BFB880
	}
}
