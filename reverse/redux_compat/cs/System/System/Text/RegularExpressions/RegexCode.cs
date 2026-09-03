/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	internal sealed class RegexCode // TypeDefIndex: 8709
	{
		// Fields
		public readonly int[] Codes; // 0x10
		public readonly string[] Strings; // 0x18
		public readonly int TrackCount; // 0x20
		public readonly Hashtable Caps; // 0x28
		public readonly int CapSize; // 0x30
		public readonly RegexPrefix? FCPrefix; // 0x38
		public readonly RegexBoyerMoore BMPrefix; // 0x50
		public readonly int Anchors; // 0x58
		public readonly bool RightToLeft; // 0x5C
	
		// Constructors
		public RegexCode(int[] codes, List<string> stringlist, int trackcount, Hashtable caps, int capsize, RegexBoyerMoore bmPrefix, RegexPrefix? fcPrefix, int anchors, bool rightToLeft); // 0x0000000181B69BC0-0x0000000181B69CC0
	
		// Methods
		public static bool OpcodeBacktracks(int Op); // 0x0000000181B69B60-0x0000000181B69BC0
	}
}
