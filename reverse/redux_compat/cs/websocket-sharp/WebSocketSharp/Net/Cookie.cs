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
	[Serializable]
	public sealed class Cookie // TypeDefIndex: 13269
	{
		// Fields
		private string _comment; // 0x10
		private Uri _commentUri; // 0x18
		private bool _discard; // 0x20
		private string _domain; // 0x28
		private static readonly int[] _emptyPorts; // 0x00
		private DateTime _expires; // 0x30
		private bool _httpOnly; // 0x38
		private string _name; // 0x40
		private string _path; // 0x48
		private string _port; // 0x50
		private int[] _ports; // 0x58
		private static readonly char[] _reservedCharsForValue; // 0x08
		private string _sameSite; // 0x60
		private bool _secure; // 0x68
		private DateTime _timeStamp; // 0x70
		private string _value; // 0x78
		private int _version; // 0x80
	
		// Properties
		internal bool ExactDomain { get; } // 0x00000001825F1C50-0x00000001825F1CA0 
		internal int MaxAge { get; set; } // 0x00000001825F1D60-0x00000001825F1E80 0x00000001825F2140-0x00000001825F21E0
		internal int[] Ports { get; } // 0x00000001825F1E90-0x00000001825F1EF0 
		internal string SameSite { get; set; } // 0x00000001825F1EF0-0x00000001825F1F00 0x00000001803780F0-0x0000000180378100
		public string Comment { get; internal set; } // 0x00000001825D8700-0x00000001825D8710 0x00000001803780D0-0x00000001803780E0
		public Uri CommentUri { get; internal set; } // 0x00000001825D8710-0x00000001825D8720 0x00000001802FAF70-0x00000001802FAF80
		public bool Discard { get; internal set; } // 0x00000001825F1C40-0x00000001825F1C50 0x00000001813C7380-0x00000001813C7390
		public string Domain { get; set; } // 0x00000001825EE1C0-0x00000001825EE1D0 0x00000001825F2060-0x00000001825F20A0
		public bool Expired { get; set; } // 0x00000001825F1CA0-0x00000001825F1D40 0x00000001825F20A0-0x00000001825F2140
		public DateTime Expires { get; set; } // 0x00000001825F1D40-0x00000001825F1D50 0x000000018172A4B0-0x000000018172A4C0
		public bool HttpOnly { get; set; } // 0x00000001825F1D50-0x00000001825F1D60 0x00000001804763A0-0x00000001804763B0
		public string Name { get; set; } // 0x00000001825E8A60-0x00000001825E8A70 0x00000001825F21E0-0x00000001825F23D0
		public string Path { get; set; } // 0x00000001825E8B00-0x00000001825E8B10 0x00000001825F23D0-0x00000001825F2410
		public string Port { get; internal set; } // 0x00000001825F1E80-0x00000001825F1E90 0x00000001825F2410-0x00000001825F24A0
		public bool Secure { get; set; } // 0x00000001825F1F00-0x00000001825F1F10 0x0000000180B262C0-0x0000000180B262D0
		public DateTime TimeStamp { get; } // 0x00000001825F1F10-0x00000001825F1F20 
		public string Value { get; set; } // 0x00000001825F1F20-0x00000001825F1F30 0x00000001825F24A0-0x00000001825F25E0
		public int Version { get; internal set; } // 0x00000001825F1F30-0x00000001825F1F40 0x00000001825F25E0-0x00000001825F25F0
	
		// Constructors
		static Cookie(); // 0x00000001825F1780-0x00000001825F1860
		internal Cookie(); // 0x00000001825F1860-0x00000001825F18B0
		public Cookie(string name, string value); // 0x00000001825F18E0-0x00000001825F1910
		public Cookie(string name, string value, string path); // 0x00000001825F18B0-0x00000001825F18E0
		public Cookie(string name, string value, string path, string domain); // 0x00000001825F1910-0x00000001825F1C40
	
		// Methods
		private static int hash(int i, int j, int k, int l, int m); // 0x00000001825F1F40-0x00000001825F1F90
		private void init(string name, string value, string path, string domain); // 0x00000001825F1F90-0x00000001825F2060
		private string toResponseStringVersion0(); // 0x00000001825F25F0-0x00000001825F2870
		private string toResponseStringVersion1(); // 0x00000001825F2870-0x00000001825F2CD0
		private static bool tryCreatePorts(string value, out int[] result); // 0x00000001825F2CD0-0x00000001825F2EA0
		internal bool EqualsWithoutValue(Cookie cookie); // 0x00000001825F0FC0-0x00000001825F1070
		internal bool EqualsWithoutValueAndVersion(Cookie cookie); // 0x00000001825F0F30-0x00000001825F0FC0
		internal string ToRequestString(Uri uri); // 0x00000001825F1370-0x00000001825F1660
		internal string ToResponseString(); // 0x00000001825F1660-0x00000001825F16B0
		internal static bool TryCreate(string name, string value, out Cookie result); // 0x00000001825F16C0-0x00000001825F1780
		public override bool Equals(object comparand); // 0x00000001825F1070-0x00000001825F1180
		public override int GetHashCode(); // 0x00000001825F1180-0x00000001825F1370
		public override string ToString(); // 0x00000001825F16B0-0x00000001825F16C0
	}
}
