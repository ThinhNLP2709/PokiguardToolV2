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
	internal sealed class ValueFixup // TypeDefIndex: 3110
	{
		// Fields
		internal ValueFixupEnum valueFixupEnum; // 0x10
		internal Array arrayObj; // 0x18
		internal int[] indexMap; // 0x20
		internal object header; // 0x28
		internal object memberObject; // 0x30
		internal static MemberInfo valueInfo; // 0x00
		internal ReadObjectInfo objectInfo; // 0x38
		internal string memberName; // 0x40
	
		// Constructors
		internal ValueFixup(Array arrayObj, int[] indexMap); // 0x000000018151C5F0-0x000000018151C650
		internal ValueFixup(object memberObject, string memberName, ReadObjectInfo objectInfo); // 0x000000018151C650-0x000000018151C6D0
	
		// Methods
		internal void Fixup(ParseRecord record, ParseRecord parent); // 0x000000018151C2C0-0x000000018151C5F0
	}
}
