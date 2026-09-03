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

namespace System.Collections.Generic
{
	[Serializable]
	internal sealed class InternalStringComparer : EqualityComparer<string> // TypeDefIndex: 3621
	{
		// Constructors
		public InternalStringComparer(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override int GetHashCode(string obj); // 0x0000000180CA27D0-0x0000000180CA2800
		public override bool Equals(string x, string y); // 0x00000001815AE510-0x00000001815AE540
		internal override int IndexOf(string[] array, string value, int startIndex, int count); // 0x00000001815AE540-0x00000001815AE5D0
	}
}
