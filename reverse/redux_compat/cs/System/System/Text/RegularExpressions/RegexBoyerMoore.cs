/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexBoyerMoore // TypeDefIndex: 8704
	{
		// Fields
		public readonly int[] Positive; // 0x10
		public readonly int[] NegativeASCII; // 0x18
		public readonly int[][] NegativeUnicode; // 0x20
		public readonly string Pattern; // 0x28
		public readonly int LowASCII; // 0x30
		public readonly int HighASCII; // 0x34
		public readonly bool RightToLeft; // 0x38
		public readonly bool CaseInsensitive; // 0x39
		private readonly CultureInfo _culture; // 0x40
	
		// Constructors
		public RegexBoyerMoore(string pattern, bool caseInsensitive, bool rightToLeft, CultureInfo culture); // 0x0000000181B61800-0x0000000181B61D70
	
		// Methods
		private bool MatchPattern(string text, int index); // 0x0000000181B61390-0x0000000181B614D0
		public bool IsMatch(string text, int index, int beglimit, int endlimit); // 0x0000000181B61320-0x0000000181B61390
		public int Scan(string text, int index, int beglimit, int endlimit); // 0x0000000181B614D0-0x0000000181B61800
	}
}
