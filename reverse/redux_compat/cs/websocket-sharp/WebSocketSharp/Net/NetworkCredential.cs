/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public class NetworkCredential // TypeDefIndex: 13294
	{
		// Fields
		private string _domain; // 0x10
		private static readonly string[] _noRoles; // 0x00
		private string _password; // 0x18
		private string[] _roles; // 0x20
		private string _username; // 0x28
	
		// Properties
		public string Domain { get; internal set; } // 0x0000000182612780-0x00000001826127A0 0x00000001803780D0-0x00000001803780E0
		public string Password { get; internal set; } // 0x0000000181571840-0x0000000181571860 0x00000001802FAF70-0x00000001802FAF80
		public string[] Roles { get; internal set; } // 0x00000001826127A0-0x0000000182612800 0x000000018033E830-0x000000018033E840
		public string Username { get; internal set; } // 0x00000001825EE1C0-0x00000001825EE1D0 0x000000018033E840-0x000000018033E850
	
		// Constructors
		static NetworkCredential(); // 0x00000001826124B0-0x0000000182612520
		public NetworkCredential(string username, string password); // 0x0000000182612520-0x0000000182612650
		public NetworkCredential(string username, string password, string domain, params string[] roles); // 0x0000000182612650-0x0000000182612780
	}
}
