/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public abstract class StringComparer : IComparer, IEqualityComparer, IComparer<string>, IEqualityComparer<string> // TypeDefIndex: 2338
	{
		// Fields
		private static readonly CultureAwareComparer s_invariantCulture; // 0x00
		private static readonly CultureAwareComparer s_invariantCultureIgnoreCase; // 0x08
		private static readonly OrdinalCaseSensitiveComparer s_ordinal; // 0x10
		private static readonly OrdinalIgnoreCaseComparer s_ordinalIgnoreCase; // 0x18
	
		// Properties
		public static StringComparer InvariantCultureIgnoreCase { get; } // 0x000000018161E3F0-0x000000018161E440 
		public static StringComparer Ordinal { get; } // 0x000000018161E490-0x000000018161E4E0 
		public static StringComparer OrdinalIgnoreCase { get; } // 0x000000018161E440-0x000000018161E490 
	
		// Constructors
		protected StringComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static StringComparer(); // 0x000000018161E1E0-0x000000018161E3F0
	
		// Methods
		public static StringComparer Create(CultureInfo culture, bool ignoreCase); // 0x000000018161E000-0x000000018161E0C0
		public int Compare(object x, object y); // 0x000000018161DEA0-0x000000018161E000
		public new bool Equals(object x, object y); // 0x000000018161E0C0-0x000000018161E130
		public int GetHashCode(object obj); // 0x000000018161E130-0x000000018161E1E0
		public abstract int Compare(string x, string y);
		public abstract bool Equals(string x, string y);
		public abstract int GetHashCode(string obj);
	}
}
