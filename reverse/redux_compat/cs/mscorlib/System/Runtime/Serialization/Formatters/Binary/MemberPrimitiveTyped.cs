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

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class MemberPrimitiveTyped // TypeDefIndex: 3081
	{
		// Fields
		internal InternalPrimitiveTypeE primitiveTypeEnum; // 0x10
		internal object value; // 0x18
	
		// Constructors
		internal MemberPrimitiveTyped(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Set(InternalPrimitiveTypeE primitiveTypeEnum, object value); // 0x00000001814EDE70-0x00000001814EDE90
		public void Write(__BinaryWriter sout); // 0x00000001814F3E70-0x00000001814F3EF0
		public void Read(__BinaryParser input); // 0x00000001814F3E20-0x00000001814F3E70
		public void Dump(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
