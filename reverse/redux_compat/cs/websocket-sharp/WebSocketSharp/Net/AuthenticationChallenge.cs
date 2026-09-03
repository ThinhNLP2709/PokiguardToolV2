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
	internal class AuthenticationChallenge : AuthenticationBase // TypeDefIndex: 13302
	{
		// Properties
		public string Domain { get; } // 0x0000000182605240-0x0000000182605290 
		public string Stale { get; } // 0x0000000182605290-0x00000001826052E0 
	
		// Constructors
		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters); // 0x00000001806F4520-0x00000001806F4560
		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm); // 0x00000001826050E0-0x0000000182605240
	
		// Methods
		internal static AuthenticationChallenge CreateBasicChallenge(string realm); // 0x0000000182604B50-0x0000000182604BB0
		internal static AuthenticationChallenge CreateDigestChallenge(string realm); // 0x0000000182604BB0-0x0000000182604C10
		internal static AuthenticationChallenge Parse(string value); // 0x0000000182604C10-0x0000000182604DB0
		internal override string ToBasicString(); // 0x0000000182604DB0-0x0000000182604E20
		internal override string ToDigestString(); // 0x0000000182604E20-0x00000001826050E0
	}
}
