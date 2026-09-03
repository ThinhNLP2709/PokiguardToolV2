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
	[Obsolete("Please use StringComparer instead.")]
	public class CaseInsensitiveHashCodeProvider : IHashCodeProvider // TypeDefIndex: 3507
	{
		// Fields
		private readonly CompareInfo _compareInfo; // 0x10
	
		// Properties
		public static CaseInsensitiveHashCodeProvider Default { get; } // 0x00000001815923F0-0x00000001815924A0 
	
		// Constructors
		public CaseInsensitiveHashCodeProvider(); // 0x0000000181592070-0x00000001815920F0
		public CaseInsensitiveHashCodeProvider(CultureInfo culture); // 0x0000000181592350-0x00000001815923F0
	
		// Methods
		public int GetHashCode(object obj); // 0x0000000181592290-0x0000000181592350
	}
}
