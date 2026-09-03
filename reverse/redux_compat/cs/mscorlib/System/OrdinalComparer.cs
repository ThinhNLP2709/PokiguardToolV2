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

namespace System
{
	[Serializable]
	public class OrdinalComparer : StringComparer // TypeDefIndex: 2340
	{
		// Fields
		private readonly bool _ignoreCase; // 0x10
	
		// Constructors
		internal OrdinalComparer(bool ignoreCase); // 0x00000001816173C0-0x0000000181617420
	
		// Methods
		public override int Compare(string x, string y); // 0x0000000181617190-0x00000001816171E0
		public override bool Equals(string x, string y); // 0x00000001816171E0-0x0000000181617250
		public override int GetHashCode(string obj); // 0x00000001816172D0-0x0000000181617360
		public override bool Equals(object obj); // 0x0000000181617250-0x00000001816172D0
		public override int GetHashCode(); // 0x0000000181617360-0x00000001816173C0
	}
}
