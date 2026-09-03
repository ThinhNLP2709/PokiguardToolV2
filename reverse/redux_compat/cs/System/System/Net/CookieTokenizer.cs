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
	internal class CookieTokenizer // TypeDefIndex: 9084
	{
		// Fields
		private bool m_eofCookie; // 0x10
		private int m_index; // 0x14
		private int m_length; // 0x18
		private string m_name; // 0x20
		private bool m_quoted; // 0x28
		private int m_start; // 0x2C
		private CookieToken m_token; // 0x30
		private int m_tokenLength; // 0x34
		private string m_tokenStream; // 0x38
		private string m_value; // 0x40
		private static RecognizedAttribute[] RecognizedAttributes; // 0x00
		private static RecognizedAttribute[] RecognizedServerAttributes; // 0x08
	
		// Properties
		internal bool EndOfCookie { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		internal bool Eof { get; } // 0x0000000181C02450-0x0000000181C02460 
		internal string Name { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		internal bool Quoted { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		internal CookieToken Token { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		internal string Value { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Nested types
		private struct RecognizedAttribute // TypeDefIndex: 9085
		{
			// Fields
			private string m_name; // 0x00
			private CookieToken m_token; // 0x08
	
			// Properties
			internal CookieToken Token { get; } // 0x0000000180732D20-0x0000000180732D30 
	
			// Constructors
			internal RecognizedAttribute(string name, CookieToken token); // 0x0000000180DEFF80-0x0000000180DEFFB0
	
			// Methods
			internal bool IsEqualTo(string value); // 0x0000000181C11070-0x0000000181C11090
		}
	
		// Constructors
		internal CookieTokenizer(string tokenStream); // 0x0000000181C02400-0x0000000181C02450
		static CookieTokenizer(); // 0x0000000181C01E50-0x0000000181C02400
	
		// Methods
		internal string Extract(); // 0x0000000181C016B0-0x0000000181C01710
		internal CookieToken FindNext(bool ignoreComma, bool ignoreEquals); // 0x0000000181C01710-0x0000000181C01960
		internal CookieToken Next(bool first, bool parseResponseCookies); // 0x0000000181C01960-0x0000000181C01BC0
		internal void Reset(); // 0x0000000181C01BC0-0x0000000181C01C20
		internal CookieToken TokenFromName(bool parseResponseCookies); // 0x0000000181C01C20-0x0000000181C01E50
	}
}
