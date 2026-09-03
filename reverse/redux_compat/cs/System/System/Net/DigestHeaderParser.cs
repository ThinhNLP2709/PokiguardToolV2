/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class DigestHeaderParser // TypeDefIndex: 9119
	{
		// Fields
		private string header; // 0x10
		private int length; // 0x18
		private int pos; // 0x1C
		private static string[] keywords; // 0x00
		private string[] values; // 0x20
	
		// Properties
		public string Realm { get; } // 0x00000001815518B0-0x00000001815518E0 
		public string Opaque { get; } // 0x00000001815517C0-0x00000001815517F0 
		public string Nonce { get; } // 0x0000000181551820-0x0000000181551850 
		public string Algorithm { get; } // 0x0000000181551850-0x0000000181551880 
		public string QOP { get; } // 0x0000000181551880-0x00000001815518B0 
	
		// Constructors
		public DigestHeaderParser(string header); // 0x0000000181C06510-0x0000000181C065D0
		static DigestHeaderParser(); // 0x0000000181C063C0-0x0000000181C06510
	
		// Methods
		public bool Parse(); // 0x0000000181C06180-0x0000000181C06350
		private void SkipWhitespace(); // 0x0000000181C06350-0x0000000181C063C0
		private string GetKey(); // 0x0000000181C05E20-0x0000000181C05F00
		private bool GetKeywordAndValue(out string key, out string value); // 0x0000000181C05F00-0x0000000181C06180
	}
}
