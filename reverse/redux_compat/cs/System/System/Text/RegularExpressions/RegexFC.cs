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
	internal sealed class RegexFC // TypeDefIndex: 8711
	{
		// Fields
		private RegexCharClass _cc; // 0x10
		public bool _nullable; // 0x18
		[CompilerGenerated]
		private bool _CaseInsensitive_k__BackingField; // 0x19
	
		// Properties
		public bool CaseInsensitive { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
	
		// Constructors
		public RegexFC(bool nullable); // 0x0000000181B6B7A0-0x0000000181B6B820
		public RegexFC(char ch, bool not, bool nullable, bool caseInsensitive); // 0x0000000181B6B6A0-0x0000000181B6B7A0
		public RegexFC(string charClass, bool nullable, bool caseInsensitive); // 0x0000000181B6B820-0x0000000181B6B8F0
	
		// Methods
		public bool AddFC(RegexFC fc, bool concatenate); // 0x0000000181B6B4D0-0x0000000181B6B560
		public string GetFirstChars(CultureInfo culture); // 0x0000000181B6B560-0x0000000181B6B6A0
	}
}
