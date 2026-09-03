/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Http
{
	internal class NtlmClient : IAuthenticationModule // TypeDefIndex: 8579
	{
		// Fields
		private static readonly ConditionalWeakTable<HttpWebRequest, NtlmSession> cache; // 0x00
	
		// Properties
		public string AuthenticationType { get; } // 0x000000018181F220-0x000000018181F250 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8580
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static ConditionalWeakTable<HttpWebRequest, NtlmSession> __9__1_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181823840-0x00000001818238B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal NtlmSession _Authenticate_b__1_0(HttpWebRequest x); // 0x0000000181823610-0x0000000181823660
		}
	
		// Constructors
		public NtlmClient(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static NtlmClient(); // 0x000000018181F1A0-0x000000018181F220
	
		// Methods
		public Authorization Authenticate(string challenge, WebRequest webRequest, ICredentials credentials); // 0x000000018181EE20-0x000000018181F1A0
		public Authorization PreAuthenticate(WebRequest webRequest, ICredentials credentials); // 0x00000001802E7860-0x00000001802E7870
	}
}
