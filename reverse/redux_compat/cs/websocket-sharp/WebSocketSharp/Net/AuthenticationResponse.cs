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
	internal class AuthenticationResponse : AuthenticationBase // TypeDefIndex: 13303
	{
		// Fields
		private uint _nonceCount; // 0x20
	
		// Properties
		internal uint NonceCount { get; } // 0x0000000182606900-0x0000000182606910 
		public string Cnonce { get; } // 0x0000000182606860-0x00000001826068B0 
		public string Nc { get; } // 0x00000001826068B0-0x0000000182606900 
		public string Password { get; } // 0x0000000182606910-0x0000000182606960 
		public string Response { get; } // 0x0000000182606960-0x00000001826069B0 
		public string Uri { get; } // 0x00000001826069B0-0x0000000182606A00 
		public string UserName { get; } // 0x0000000182606A00-0x0000000182606A50 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13304
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<string, bool> __9__24_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182614E50-0x0000000182614EC0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _initAsDigest_b__24_0(string qop); // 0x0000000182614D90-0x0000000182614DF0
		}
	
		// Constructors
		private AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters); // 0x00000001806F4520-0x00000001806F4560
		internal AuthenticationResponse(NetworkCredential credentials); // 0x00000001826065F0-0x0000000182606670
		internal AuthenticationResponse(AuthenticationChallenge challenge, NetworkCredential credentials, uint nonceCount); // 0x0000000182606480-0x00000001826064C0
		internal AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters, NetworkCredential credentials, uint nonceCount); // 0x00000001826064C0-0x00000001826065F0
	
		// Methods
		private static string createA1(string username, string password, string realm); // 0x0000000182606670-0x00000001826066E0
		private static string createA1(string username, string password, string realm, string nonce, string cnonce); // 0x00000001826066E0-0x00000001826067A0
		private static string createA2(string method, string uri); // 0x0000000182606810-0x0000000182606860
		private static string createA2(string method, string uri, string entity); // 0x00000001826067A0-0x0000000182606810
		private static string hash(string value); // 0x0000000182606A50-0x0000000182606B80
		private void initAsDigest(); // 0x0000000182606B80-0x0000000182606E90
		internal static string CreateRequestDigest(NameValueCollection parameters); // 0x00000001826052E0-0x00000001826058A0
		internal static AuthenticationResponse Parse(string value); // 0x0000000182605A30-0x0000000182605D70
		internal static NameValueCollection ParseBasicCredentials(string value); // 0x00000001826058A0-0x0000000182605A30
		internal override string ToBasicString(); // 0x0000000182605D70-0x0000000182605E90
		internal override string ToDigestString(); // 0x0000000182605E90-0x00000001826062F0
		public IIdentity ToIdentity(); // 0x00000001826062F0-0x0000000182606480
	}
}
