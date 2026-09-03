/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class DigestSession // TypeDefIndex: 9120
	{
		// Fields
		private static RandomNumberGenerator rng; // 0x00
		private DateTime lastUse; // 0x10
		private int _nc; // 0x18
		private HashAlgorithm hash; // 0x20
		private DigestHeaderParser parser; // 0x28
		private string _cnonce; // 0x30
	
		// Properties
		public string Algorithm { get; } // 0x0000000181C07540-0x0000000181C07580 
		public string Realm { get; } // 0x0000000181C07740-0x0000000181C07780 
		public string Nonce { get; } // 0x0000000181C07680-0x0000000181C076C0 
		public string Opaque { get; } // 0x0000000181C076C0-0x0000000181C07700 
		public string QOP { get; } // 0x0000000181C07700-0x0000000181C07740 
		public string CNonce { get; } // 0x0000000181C07580-0x0000000181C07680 
		public DateTime LastUse { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		static DigestSession(); // 0x0000000181C07480-0x0000000181C074E0
		public DigestSession(); // 0x0000000181C074E0-0x0000000181C07540
	
		// Methods
		public bool Parse(string challenge); // 0x0000000181C06F50-0x0000000181C07110
		private string HashToHexString(string toBeHashed); // 0x0000000181C06DF0-0x0000000181C06F50
		private string HA1(string username, string password); // 0x0000000181C06B90-0x0000000181C06CF0
		private string HA2(HttpWebRequest webRequest); // 0x0000000181C06CF0-0x0000000181C06DF0
		private string Response(string username, string password, HttpWebRequest webRequest); // 0x0000000181C07110-0x0000000181C07480
		public Authorization Authenticate(WebRequest webRequest, ICredentials credentials); // 0x0000000181C065D0-0x0000000181C06B90
	}
}
