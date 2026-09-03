/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public class HttpDigestIdentity : GenericIdentity // TypeDefIndex: 13293
	{
		// Fields
		private NameValueCollection _parameters; // 0x88
	
		// Properties
		public string Algorithm { get; } // 0x0000000182607EA0-0x0000000182607EF0 
		public string Cnonce { get; } // 0x0000000182607EF0-0x0000000182607F40 
		public string Nc { get; } // 0x0000000182607F40-0x0000000182607F90 
		public string Nonce { get; } // 0x0000000182607F90-0x0000000182607FE0 
		public string Opaque { get; } // 0x0000000182607FE0-0x0000000182608030 
		public string Qop { get; } // 0x0000000182608030-0x0000000182608080 
		public string Realm { get; } // 0x0000000182608080-0x00000001826080D0 
		public string Response { get; } // 0x00000001826080D0-0x0000000182608120 
		public string Uri { get; } // 0x0000000182608120-0x0000000182608170 
	
		// Constructors
		internal HttpDigestIdentity(NameValueCollection parameters); // 0x0000000182607E10-0x0000000182607EA0
	
		// Methods
		internal bool IsValid(string password, string realm, string method, string entity); // 0x0000000182607CB0-0x0000000182607E10
	}
}
