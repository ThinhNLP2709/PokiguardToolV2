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

namespace System.Resources
{
	internal struct ResourceLocator // TypeDefIndex: 3265
	{
		// Fields
		internal object _value; // 0x00
		internal int _dataPos; // 0x08
	
		// Properties
		internal int DataPosition { get; } // 0x0000000180732D20-0x0000000180732D30 
		internal object Value { get; set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
	
		// Constructors
		internal ResourceLocator(int dataPos, object value); // 0x00000001815046D0-0x00000001815046E0
	
		// Methods
		internal static bool CanCache(ResourceTypeCode value); // 0x0000000181513490-0x00000001815134A0
	}
}
