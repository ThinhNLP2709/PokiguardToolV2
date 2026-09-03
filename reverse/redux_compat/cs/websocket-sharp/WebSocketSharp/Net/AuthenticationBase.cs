/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal abstract class AuthenticationBase // TypeDefIndex: 13305
	{
		// Fields
		private AuthenticationSchemes _scheme; // 0x10
		internal NameValueCollection Parameters; // 0x18
	
		// Properties
		public string Algorithm { get; } // 0x00000001826049B0-0x0000000182604A00 
		public string Nonce { get; } // 0x0000000182604A00-0x0000000182604A50 
		public string Opaque { get; } // 0x0000000182604A50-0x0000000182604AA0 
		public string Qop { get; } // 0x0000000182604AA0-0x0000000182604AF0 
		public string Realm { get; } // 0x0000000182604AF0-0x0000000182604B40 
		public AuthenticationSchemes Scheme { get; } // 0x0000000182604B40-0x0000000182604B50 
	
		// Constructors
		protected AuthenticationBase(AuthenticationSchemes scheme, NameValueCollection parameters); // 0x00000001806F4520-0x00000001806F4560
	
		// Methods
		internal static string CreateNonceValue(); // 0x0000000182604400-0x0000000182604550
		internal static NameValueCollection ParseParameters(string value); // 0x0000000182604550-0x0000000182604950
		internal abstract string ToBasicString();
		internal abstract string ToDigestString();
		public override string ToString(); // 0x0000000182604950-0x00000001826049B0
	}
}
