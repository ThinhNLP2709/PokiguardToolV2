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
	public class AuthenticationManager // TypeDefIndex: 9110
	{
		// Fields
		private static ArrayList modules; // 0x00
		private static object locker; // 0x08
		private static ICredentialPolicy credential_policy; // 0x10
	
		// Constructors
		static AuthenticationManager(); // 0x0000000181BFB340-0x0000000181BFB3E0
	
		// Methods
		private static void EnsureModules(); // 0x0000000181BFACD0-0x0000000181BFAF50
		public static Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials); // 0x0000000181BFA7E0-0x0000000181BFA940
		private static Authorization DoAuthenticate(string challenge, WebRequest request, ICredentials credentials); // 0x0000000181BFA940-0x0000000181BFACD0
		public static Authorization PreAuthenticate(WebRequest request, ICredentials credentials); // 0x0000000181BFAF50-0x0000000181BFB340
	}
}
