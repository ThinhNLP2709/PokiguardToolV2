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
	internal sealed class Converter // TypeDefIndex: 3091
	{
		// Fields
		private static int primitiveTypeEnumLength; // 0x00
		private static Type[] typeA; // 0x08
		private static Type[] arrayTypeA; // 0x10
		private static string[] valueA; // 0x18
		private static TypeCode[] typeCodeA; // 0x20
		private static InternalPrimitiveTypeE[] codeA; // 0x28
		internal static Type typeofISerializable; // 0x30
		internal static Type typeofString; // 0x38
		internal static Type typeofConverter; // 0x40
		internal static Type typeofBoolean; // 0x48
		internal static Type typeofByte; // 0x50
		internal static Type typeofChar; // 0x58
		internal static Type typeofDecimal; // 0x60
		internal static Type typeofDouble; // 0x68
		internal static Type typeofInt16; // 0x70
		internal static Type typeofInt32; // 0x78
		internal static Type typeofInt64; // 0x80
		internal static Type typeofSByte; // 0x88
		internal static Type typeofSingle; // 0x90
		internal static Type typeofTimeSpan; // 0x98
		internal static Type typeofDateTime; // 0xA0
		internal static Type typeofUInt16; // 0xA8
		internal static Type typeofUInt32; // 0xB0
		internal static Type typeofUInt64; // 0xB8
		internal static Type typeofObject; // 0xC0
		internal static Type typeofSystemVoid; // 0xC8
		internal static Assembly urtAssembly; // 0xD0
		internal static string urtAssemblyString; // 0xD8
		internal static Type typeofTypeArray; // 0xE0
		internal static Type typeofObjectArray; // 0xE8
		internal static Type typeofStringArray; // 0xF0
		internal static Type typeofBooleanArray; // 0xF8
		internal static Type typeofByteArray; // 0x100
		internal static Type typeofCharArray; // 0x108
		internal static Type typeofDecimalArray; // 0x110
		internal static Type typeofDoubleArray; // 0x118
		internal static Type typeofInt16Array; // 0x120
		internal static Type typeofInt32Array; // 0x128
		internal static Type typeofInt64Array; // 0x130
		internal static Type typeofSByteArray; // 0x138
		internal static Type typeofSingleArray; // 0x140
		internal static Type typeofTimeSpanArray; // 0x148
		internal static Type typeofDateTimeArray; // 0x150
		internal static Type typeofUInt16Array; // 0x158
		internal static Type typeofUInt32Array; // 0x160
		internal static Type typeofUInt64Array; // 0x168
		internal static Type typeofMarshalByRefObject; // 0x170
	
		// Constructors
		static Converter(); // 0x00000001814F2BB0-0x00000001814F3640
	
		// Methods
		internal static InternalPrimitiveTypeE ToCode(Type type); // 0x00000001814F2440-0x00000001814F2520
		internal static bool IsWriteAsByteArray(InternalPrimitiveTypeE code); // 0x00000001814F2320-0x00000001814F2390
		internal static int TypeLength(InternalPrimitiveTypeE code); // 0x00000001814F2B20-0x00000001814F2BB0
		internal static Type ToArrayType(InternalPrimitiveTypeE code); // 0x00000001814F2390-0x00000001814F2440
		private static void InitTypeA(); // 0x00000001814F1610-0x00000001814F1C60
		private static void InitArrayTypeA(); // 0x00000001814F0DE0-0x00000001814F1440
		internal static Type ToType(InternalPrimitiveTypeE code); // 0x00000001814F2A70-0x00000001814F2B20
		internal static Array CreatePrimitiveArray(InternalPrimitiveTypeE code, int length); // 0x00000001814F0B30-0x00000001814F0D10
		internal static bool IsPrimitiveArray(Type type, out object typeInformation); // 0x00000001814F2170-0x00000001814F2320
		private static void InitValueA(); // 0x00000001814F1E10-0x00000001814F2170
		internal static string ToComType(InternalPrimitiveTypeE code); // 0x00000001814F2520-0x00000001814F25D0
		private static void InitTypeCodeA(); // 0x00000001814F1C60-0x00000001814F1E10
		internal static TypeCode ToTypeCode(InternalPrimitiveTypeE code); // 0x00000001814F2830-0x00000001814F2A70
		private static void InitCodeA(); // 0x00000001814F1440-0x00000001814F1610
		internal static InternalPrimitiveTypeE ToPrimitiveTypeEnum(TypeCode typeCode); // 0x00000001814F25D0-0x00000001814F2830
		internal static object FromString(string value, InternalPrimitiveTypeE code); // 0x00000001814F0D10-0x00000001814F0DE0
	}
}
