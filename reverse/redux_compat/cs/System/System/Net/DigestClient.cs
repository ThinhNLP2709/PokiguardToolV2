/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class DigestClient : IAuthenticationModule // TypeDefIndex: 9121
	{
		// Fields
		private static readonly Hashtable cache; // 0x00
	
		// Properties
		private static Hashtable Cache { get; } // 0x0000000181C05CD0-0x0000000181C05E20 
		public string AuthenticationType { get; } // 0x0000000181C05CA0-0x0000000181C05CD0 
	
		// Constructors
		public DigestClient(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static DigestClient(); // 0x0000000181C05C20-0x0000000181C05CA0
	
		// Methods
		private static void CheckExpired(int count); // 0x0000000181C05330-0x0000000181C05A80
		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials); // 0x0000000181C04FF0-0x0000000181C05330
		public Authorization PreAuthenticate(WebRequest webRequest, ICredentials credentials); // 0x0000000181C05A80-0x0000000181C05C20
	}
}
