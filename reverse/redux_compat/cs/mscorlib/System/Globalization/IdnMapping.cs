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

namespace System.Globalization
{
	public sealed class IdnMapping // TypeDefIndex: 3453
	{
		// Fields
		private bool allow_unassigned; // 0x10
		private bool use_std3; // 0x11
		private Punycode puny; // 0x18
	
		// Constructors
		public IdnMapping(); // 0x000000018159B010-0x000000018159B0B0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181599F80-0x000000018159A000
		public override int GetHashCode(); // 0x000000018159A1F0-0x000000018159A210
		public string GetAscii(string unicode); // 0x000000018159A000-0x000000018159A0D0
		public string GetAscii(string unicode, int index, int count); // 0x000000018159A0D0-0x000000018159A1F0
		private string Convert(string input, int index, int count, bool toAscii); // 0x0000000181599D90-0x0000000181599F80
		private string ToAscii(string s, int offset); // 0x000000018159A540-0x000000018159A8A0
		private void VerifyLength(string s, int offset); // 0x000000018159AA90-0x000000018159ABC0
		private string NamePrep(string s, int offset); // 0x000000018159A400-0x000000018159A540
		private void VerifyProhibitedCharacters(string s, int offset); // 0x000000018159ABC0-0x000000018159ADC0
		private void VerifyStd3AsciiRules(string s, int offset); // 0x000000018159ADC0-0x000000018159B010
		public string GetUnicode(string ascii); // 0x000000018159A330-0x000000018159A400
		public string GetUnicode(string ascii, int index, int count); // 0x000000018159A210-0x000000018159A330
		private string ToUnicode(string s, int offset); // 0x000000018159A8A0-0x000000018159AA90
	}
}
