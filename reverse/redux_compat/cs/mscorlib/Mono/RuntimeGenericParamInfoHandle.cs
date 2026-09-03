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

namespace Mono
{
	internal struct RuntimeGenericParamInfoHandle // TypeDefIndex: 2076
	{
		// Fields
		private unsafe RuntimeStructs.GenericParamInfo* value; // 0x00
	
		// Properties
		internal Type[] Constraints { get; } // 0x00000001814331F0-0x0000000181433340 
		internal GenericParameterAttributes Attributes { get; } // 0x0000000181433340-0x0000000181433360 
	
		// Constructors
		internal unsafe RuntimeGenericParamInfoHandle(IntPtr ptr); // 0x0000000181432FE0-0x0000000181433000
	
		// Methods
		private Type[] GetConstraints(); // 0x00000001814331F0-0x0000000181433340
		private int GetConstraintsCount(); // 0x00000001814331C0-0x00000001814331F0
	}
}
