/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	internal class EraInfo // TypeDefIndex: 3428
	{
		// Fields
		internal int era; // 0x10
		internal long ticks; // 0x18
		internal int yearOffset; // 0x20
		internal int minEraYear; // 0x24
		internal int maxEraYear; // 0x28
		[OptionalField(VersionAdded = 4)]
		internal string eraName; // 0x30
		[OptionalField(VersionAdded = 4)]
		internal string abbrevEraName; // 0x38
		[OptionalField(VersionAdded = 4)]
		internal string englishEraName; // 0x40
	
		// Constructors
		internal EraInfo(int era, int startYear, int startMonth, int startDay, int yearOffset, int minEraYear, int maxEraYear); // 0x00000001815843E0-0x00000001815844C0
		internal EraInfo(int era, int startYear, int startMonth, int startDay, int yearOffset, int minEraYear, int maxEraYear, string eraName, string abbrevEraName, string englishEraName); // 0x00000001815842C0-0x00000001815843E0
	}
}
