/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security
{
	internal class Uri // TypeDefIndex: 2122
	{
		// Fields
		private bool isUnixFilePath; // 0x10
		private string source; // 0x18
		private string scheme; // 0x20
		private string host; // 0x28
		private int port; // 0x30
		private string path; // 0x38
		private string query; // 0x40
		private string fragment; // 0x48
		private string userinfo; // 0x50
		private bool isUnc; // 0x58
		private bool isOpaquePart; // 0x59
		private bool userEscaped; // 0x5A
		private string cachedToString; // 0x60
		private string cachedLocalPath; // 0x68
		private int cachedHashCode; // 0x70
		private bool reduce; // 0x74
		private static readonly string hexUpperChars; // 0x00
		public static readonly string SchemeDelimiter; // 0x08
		public static readonly string UriSchemeFile; // 0x10
		public static readonly string UriSchemeFtp; // 0x18
		public static readonly string UriSchemeGopher; // 0x20
		public static readonly string UriSchemeHttp; // 0x28
		public static readonly string UriSchemeHttps; // 0x30
		public static readonly string UriSchemeMailto; // 0x38
		public static readonly string UriSchemeNews; // 0x40
		public static readonly string UriSchemeNntp; // 0x48
		private static UriScheme[] schemes; // 0x50
	
		// Properties
		public string AbsolutePath { get; } // 0x00000001803272A0-0x00000001803272B0 
		public bool IsFile { get; } // 0x00000001814417C0-0x0000000181441830 
		public bool IsUnc { get; } // 0x0000000181424750-0x0000000181424760 
		public string LocalPath { get; } // 0x0000000181441830-0x0000000181441B80 
	
		// Nested types
		private struct UriScheme // TypeDefIndex: 2123
		{
			// Fields
			public string scheme; // 0x00
			public string delimiter; // 0x08
			public int defaultPort; // 0x10
	
			// Constructors
			public UriScheme(string s, string d, int p); // 0x0000000180F46760-0x0000000180F467B0
		}
	
		// Constructors
		public Uri(string uriString); // 0x00000001814417B0-0x00000001814417C0
		public Uri(string uriString, bool dontEscape); // 0x00000001814415D0-0x00000001814417B0
		static Uri(); // 0x0000000181440F60-0x00000001814415D0
	
		// Methods
		public override bool Equals(object comparant); // 0x000000018143D9C0-0x000000018143DBD0
		public override int GetHashCode(); // 0x000000018143E210-0x000000018143E310
		public string GetLeftPart(UriPartial part); // 0x000000018143E310-0x000000018143E740
		public static int FromHex(char digit); // 0x000000018143E020-0x000000018143E0C0
		public static string HexEscape(char character); // 0x000000018143EA80-0x000000018143EBE0
		public static char HexUnescape(string pattern, ref int index); // 0x000000018143EBE0-0x000000018143EF60
		public static bool IsHexDigit(char digit); // 0x000000018143EF60-0x000000018143EF90
		public static bool IsHexEncoding(string pattern, int index); // 0x000000018143EF90-0x000000018143F0A0
		public override string ToString(); // 0x0000000181440CC0-0x0000000181440DD0
		protected static string EscapeString(string str); // 0x000000018143DFC0-0x000000018143E020
		internal static string EscapeString(string str, bool escapeReserved, bool escapeHex, bool escapeBrackets); // 0x000000018143DBD0-0x000000018143DFC0
		protected void Parse(); // 0x000000018143F740-0x000000018143F830
		protected string Unescape(string str); // 0x0000000181440F50-0x0000000181440F60
		internal string Unescape(string str, bool excludeSharp); // 0x0000000181440DD0-0x0000000181440F50
		private void ParseAsWindowsUNC(string uriString); // 0x000000018143F550-0x000000018143F740
		private void ParseAsWindowsAbsoluteFilePath(string uriString); // 0x000000018143F3B0-0x000000018143F550
		private void ParseAsUnixAbsoluteFilePath(string uriString); // 0x000000018143F200-0x000000018143F3B0
		private void Parse(string uriString); // 0x000000018143F830-0x0000000181440A00
		private static string Reduce(string path); // 0x0000000181440A00-0x0000000181440CC0
		internal static string GetSchemeDelimiter(string scheme); // 0x000000018143E910-0x000000018143EA80
		internal static int GetDefaultPort(string scheme); // 0x000000018143E0C0-0x000000018143E210
		private string GetOpaqueWiseSchemeDelimiter(); // 0x000000018143E740-0x000000018143E910
		private static bool IsPredefinedScheme(string scheme); // 0x000000018143F0A0-0x000000018143F200
	}
}
