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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal struct ParsingInfo // TypeDefIndex: 2263
	{
		// Fields
		internal Calendar calendar; // 0x00
		internal int dayOfWeek; // 0x08
		internal DateTimeParse.TM timeMark; // 0x0C
		internal bool fUseHour12; // 0x10
		internal bool fUseTwoDigitYear; // 0x11
		internal bool fAllowInnerWhite; // 0x12
		internal bool fAllowTrailingWhite; // 0x13
		internal bool fCustomNumberParser; // 0x14
		internal DateTimeParse.MatchNumberDelegate parseNumberDelegate; // 0x18
	
		// Methods
		internal void Init(); // 0x000000018160E7B0-0x000000018160E7C0
	}
}
