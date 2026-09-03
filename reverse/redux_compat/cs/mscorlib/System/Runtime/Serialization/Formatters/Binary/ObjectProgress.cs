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
	internal sealed class ObjectProgress // TypeDefIndex: 3090
	{
		// Fields
		internal static int opRecordIdCount; // 0x00
		internal bool isInitial; // 0x10
		internal int count; // 0x14
		internal BinaryTypeEnum expectedType; // 0x18
		internal object expectedTypeInformation; // 0x20
		internal string name; // 0x28
		internal InternalObjectTypeE objectTypeEnum; // 0x30
		internal InternalMemberTypeE memberTypeEnum; // 0x34
		internal InternalMemberValueE memberValueEnum; // 0x38
		internal Type dtType; // 0x40
		internal int numItems; // 0x48
		internal BinaryTypeEnum binaryTypeEnum; // 0x4C
		internal object typeInformation; // 0x50
		internal int nullCount; // 0x58
		internal int memberLength; // 0x5C
		internal BinaryTypeEnum[] binaryTypeEnumA; // 0x60
		internal object[] typeInformationA; // 0x68
		internal string[] memberNames; // 0x70
		internal Type[] memberTypes; // 0x78
		internal ParseRecord pr; // 0x80
	
		// Constructors
		internal ObjectProgress(); // 0x00000001814F6410-0x00000001814F6490
		static ObjectProgress(); // 0x00000001814F63D0-0x00000001814F6410
	
		// Methods
		internal void Init(); // 0x00000001814F6300-0x00000001814F63D0
		internal void ArrayCountIncrement(int value); // 0x00000001814F6190-0x00000001814F61A0
		internal bool GetNext(out BinaryTypeEnum outBinaryTypeEnum, out object outTypeInformation); // 0x00000001814F61A0-0x00000001814F6300
	}
}
