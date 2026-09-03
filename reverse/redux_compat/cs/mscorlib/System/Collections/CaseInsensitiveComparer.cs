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

namespace System.Collections
{
	[Serializable]
	public class CaseInsensitiveComparer : IComparer // TypeDefIndex: 3506
	{
		// Fields
		private CompareInfo _compareInfo; // 0x10
	
		// Properties
		public static CaseInsensitiveComparer Default { get; } // 0x0000000181592190-0x0000000181592290 
	
		// Constructors
		public CaseInsensitiveComparer(); // 0x0000000181592070-0x00000001815920F0
		public CaseInsensitiveComparer(CultureInfo culture); // 0x00000001815920F0-0x0000000181592190
	
		// Methods
		public int Compare(object a, object b); // 0x0000000181591E30-0x0000000181592070
	}
}
