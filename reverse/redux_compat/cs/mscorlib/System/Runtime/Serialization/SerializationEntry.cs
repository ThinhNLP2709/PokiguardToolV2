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

namespace System.Runtime.Serialization
{
	[IsReadOnly]
	public struct SerializationEntry // TypeDefIndex: 3016
	{
		// Fields
		private readonly string _name; // 0x00
		private readonly object _value; // 0x08
		private readonly Type _type; // 0x10
	
		// Properties
		public object Value { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public string Name { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal SerializationEntry(string entryName, object entryValue, Type entryType); // 0x0000000180F466A0-0x0000000180F466F0
	}
}
