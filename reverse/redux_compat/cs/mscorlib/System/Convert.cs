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
	public static class Convert // TypeDefIndex: 2227
	{
		// Fields
		private static readonly sbyte[] s_decodingMap; // 0x00
		internal static readonly Type[] ConvertTypes; // 0x08
		private static readonly Type EnumType; // 0x10
		internal static readonly char[] base64Table; // 0x18
		public static readonly object DBNull; // 0x20
	
		// Constructors
		static Convert(); // 0x000000018156A370-0x000000018156ACD0
	
		// Methods
		private static bool TryDecodeFromUtf16(ReadOnlySpan<char> utf16, Span<byte> bytes, out int consumed, out int written); // 0x0000000181569AC0-0x0000000181569DD0
		private static int Decode(ref char encodedChars, ref sbyte decodingMap); // 0x00000001815633B0-0x0000000181563410
		private static void WriteThreeLowOrderBytes(ref byte destination, int value); // 0x000000018156A350-0x000000018156A370
		public static TypeCode GetTypeCode(object value); // 0x0000000181564110-0x0000000181564180
		public static object ChangeType(object value, TypeCode typeCode, IFormatProvider provider); // 0x0000000181562AB0-0x0000000181562F50
		internal static object DefaultToType(IConvertible value, Type targetType, IFormatProvider provider); // 0x0000000181563410-0x0000000181563B20
		public static object ChangeType(object value, Type conversionType); // 0x00000001815623D0-0x0000000181562460
		public static object ChangeType(object value, Type conversionType, IFormatProvider provider); // 0x0000000181562460-0x0000000181562AB0
		private static void ThrowCharOverflowException(); // 0x0000000181564200-0x0000000181564250
		private static void ThrowByteOverflowException(); // 0x00000001815641B0-0x0000000181564200
		private static void ThrowSByteOverflowException(); // 0x0000000181564340-0x0000000181564390
		private static void ThrowInt16OverflowException(); // 0x0000000181564250-0x00000001815642A0
		private static void ThrowUInt16OverflowException(); // 0x0000000181564390-0x00000001815643E0
		private static void ThrowInt32OverflowException(); // 0x00000001815642A0-0x00000001815642F0
		private static void ThrowUInt32OverflowException(); // 0x00000001815643E0-0x0000000181564430
		private static void ThrowInt64OverflowException(); // 0x00000001815642F0-0x0000000181564340
		private static void ThrowUInt64OverflowException(); // 0x0000000181564430-0x0000000181564480
		public static bool ToBoolean(object value); // 0x0000000181564FF0-0x0000000181565090
		public static bool ToBoolean(object value, IFormatProvider provider); // 0x0000000181564F30-0x0000000181564FE0
		[CLSCompliant(false)]
		public static bool ToBoolean(sbyte value); // 0x0000000181564F20-0x0000000181564F30
		public static bool ToBoolean(byte value); // 0x0000000181564F20-0x0000000181564F30
		public static bool ToBoolean(short value); // 0x00000001815650E0-0x00000001815650F0
		[CLSCompliant(false)]
		public static bool ToBoolean(ushort value); // 0x00000001815650E0-0x00000001815650F0
		public static bool ToBoolean(int value); // 0x0000000181564FE0-0x0000000181564FF0
		[CLSCompliant(false)]
		public static bool ToBoolean(uint value); // 0x0000000181564FE0-0x0000000181564FF0
		public static bool ToBoolean(long value); // 0x0000000181564F10-0x0000000181564F20
		[CLSCompliant(false)]
		public static bool ToBoolean(ulong value); // 0x0000000181564F10-0x0000000181564F20
		public static bool ToBoolean(string value); // 0x0000000181565090-0x00000001815650D0
		public static bool ToBoolean(string value, IFormatProvider provider); // 0x0000000181565090-0x00000001815650D0
		public static bool ToBoolean(float value); // 0x00000001815650D0-0x00000001815650E0
		public static bool ToBoolean(double value); // 0x00000001815650F0-0x0000000181565110
		public static bool ToBoolean(decimal value); // 0x0000000181565110-0x0000000181565190
		public static char ToChar(object value); // 0x0000000181565B80-0x0000000181565C20
		public static char ToChar(object value, IFormatProvider provider); // 0x0000000181565E10-0x0000000181565EC0
		[CLSCompliant(false)]
		public static char ToChar(sbyte value); // 0x0000000181565DC0-0x0000000181565E10
		public static char ToChar(byte value); // 0x0000000180815D60-0x0000000180815D70
		public static char ToChar(short value); // 0x0000000181565D10-0x0000000181565D60
		[CLSCompliant(false)]
		public static char ToChar(ushort value); // 0x0000000181565B10-0x0000000181565B20
		public static char ToChar(int value); // 0x0000000181565EC0-0x0000000181565F20
		[CLSCompliant(false)]
		public static char ToChar(uint value); // 0x0000000181565D60-0x0000000181565DC0
		public static char ToChar(long value); // 0x0000000181565B20-0x0000000181565B80
		[CLSCompliant(false)]
		public static char ToChar(ulong value); // 0x00000001815659F0-0x0000000181565A50
		public static char ToChar(string value); // 0x0000000181565C20-0x0000000181565D10
		public static char ToChar(string value, IFormatProvider provider); // 0x0000000181565A50-0x0000000181565B10
		[CLSCompliant(false)]
		public static sbyte ToSByte(object value); // 0x0000000181567B60-0x0000000181567C00
		[CLSCompliant(false)]
		public static sbyte ToSByte(object value, IFormatProvider provider); // 0x0000000181568170-0x0000000181568220
		[CLSCompliant(false)]
		public static sbyte ToSByte(bool value); // 0x0000000181564F20-0x0000000181564F30
		[CLSCompliant(false)]
		public static sbyte ToSByte(char value); // 0x0000000181568060-0x00000001815680C0
		[CLSCompliant(false)]
		public static sbyte ToSByte(byte value); // 0x0000000181568120-0x0000000181568170
		[CLSCompliant(false)]
		public static sbyte ToSByte(short value); // 0x0000000181567FA0-0x0000000181568000
		[CLSCompliant(false)]
		public static sbyte ToSByte(ushort value); // 0x0000000181567DA0-0x0000000181567E00
		[CLSCompliant(false)]
		public static sbyte ToSByte(int value); // 0x0000000181568000-0x0000000181568060
		[CLSCompliant(false)]
		public static sbyte ToSByte(uint value); // 0x0000000181567C00-0x0000000181567C50
		[CLSCompliant(false)]
		public static sbyte ToSByte(long value); // 0x0000000181567C50-0x0000000181567CB0
		[CLSCompliant(false)]
		public static sbyte ToSByte(ulong value); // 0x00000001815680C0-0x0000000181568120
		[CLSCompliant(false)]
		public static sbyte ToSByte(float value); // 0x0000000181567CB0-0x0000000181567D90
		[CLSCompliant(false)]
		public static sbyte ToSByte(double value); // 0x0000000181567AC0-0x0000000181567B60
		[CLSCompliant(false)]
		public static sbyte ToSByte(decimal value); // 0x0000000181567E00-0x0000000181567E80
		[CLSCompliant(false)]
		public static sbyte ToSByte(string value, IFormatProvider provider); // 0x0000000181567D90-0x0000000181567DA0
		public static byte ToByte(object value); // 0x00000001815658C0-0x0000000181565960
		public static byte ToByte(object value, IFormatProvider provider); // 0x0000000181565330-0x00000001815653E0
		public static byte ToByte(bool value); // 0x0000000181564F20-0x0000000181564F30
		public static byte ToByte(char value); // 0x0000000181565560-0x00000001815655C0
		[CLSCompliant(false)]
		public static byte ToByte(sbyte value); // 0x0000000181565810-0x0000000181565860
		public static byte ToByte(short value); // 0x00000001815651F0-0x0000000181565250
		[CLSCompliant(false)]
		public static byte ToByte(ushort value); // 0x0000000181565860-0x00000001815658C0
		public static byte ToByte(int value); // 0x00000001815655C0-0x0000000181565620
		[CLSCompliant(false)]
		public static byte ToByte(uint value); // 0x00000001815656B0-0x0000000181565710
		public static byte ToByte(long value); // 0x0000000181565500-0x0000000181565560
		[CLSCompliant(false)]
		public static byte ToByte(ulong value); // 0x0000000181565190-0x00000001815651F0
		public static byte ToByte(float value); // 0x0000000181565250-0x0000000181565330
		public static byte ToByte(double value); // 0x0000000181565460-0x0000000181565500
		public static byte ToByte(decimal value); // 0x00000001815653E0-0x0000000181565460
		public static byte ToByte(string value); // 0x0000000181565960-0x00000001815659F0
		public static byte ToByte(string value, IFormatProvider provider); // 0x0000000181565620-0x00000001815656B0
		public static short ToInt16(object value); // 0x0000000181566E90-0x0000000181566F30
		public static short ToInt16(object value, IFormatProvider provider); // 0x0000000181566A20-0x0000000181566AD0
		public static short ToInt16(bool value); // 0x00000001815669B0-0x00000001815669C0
		public static short ToInt16(char value); // 0x0000000181566D20-0x0000000181566D80
		[CLSCompliant(false)]
		public static short ToInt16(sbyte value); // 0x0000000181566D80-0x0000000181566D90
		public static short ToInt16(byte value); // 0x0000000180815D60-0x0000000180815D70
		[CLSCompliant(false)]
		public static short ToInt16(ushort value); // 0x00000001815669C0-0x0000000181566A20
		public static short ToInt16(int value); // 0x0000000181566F30-0x0000000181566F90
		[CLSCompliant(false)]
		public static short ToInt16(uint value); // 0x0000000181566F90-0x0000000181566FF0
		public static short ToInt16(long value); // 0x0000000181566AD0-0x0000000181566B30
		[CLSCompliant(false)]
		public static short ToInt16(ulong value); // 0x0000000181566B30-0x0000000181566B90
		public static short ToInt16(float value); // 0x0000000181566DB0-0x0000000181566E90
		public static short ToInt16(double value); // 0x0000000181566FF0-0x0000000181567090
		public static short ToInt16(decimal value); // 0x0000000181566CA0-0x0000000181566D20
		public static short ToInt16(string value, IFormatProvider provider); // 0x0000000181566D90-0x0000000181566DB0
		[CLSCompliant(false)]
		public static ushort ToUInt16(object value); // 0x0000000181568BD0-0x0000000181568C70
		[CLSCompliant(false)]
		public static ushort ToUInt16(object value, IFormatProvider provider); // 0x0000000181568B20-0x0000000181568BD0
		[CLSCompliant(false)]
		public static ushort ToUInt16(bool value); // 0x00000001815669B0-0x00000001815669C0
		[CLSCompliant(false)]
		public static ushort ToUInt16(char value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static ushort ToUInt16(sbyte value); // 0x0000000181568980-0x00000001815689D0
		[CLSCompliant(false)]
		public static ushort ToUInt16(byte value); // 0x0000000180815D60-0x0000000180815D70
		[CLSCompliant(false)]
		public static ushort ToUInt16(short value); // 0x0000000181568AD0-0x0000000181568B20
		[CLSCompliant(false)]
		public static ushort ToUInt16(int value); // 0x0000000181568C70-0x0000000181568CD0
		[CLSCompliant(false)]
		public static ushort ToUInt16(uint value); // 0x0000000181568D30-0x0000000181568D90
		[CLSCompliant(false)]
		public static ushort ToUInt16(long value); // 0x0000000181568A50-0x0000000181568AB0
		[CLSCompliant(false)]
		public static ushort ToUInt16(ulong value); // 0x0000000181568CD0-0x0000000181568D30
		[CLSCompliant(false)]
		public static ushort ToUInt16(float value); // 0x0000000181568E30-0x0000000181568F10
		[CLSCompliant(false)]
		public static ushort ToUInt16(double value); // 0x0000000181568D90-0x0000000181568E30
		[CLSCompliant(false)]
		public static ushort ToUInt16(decimal value); // 0x00000001815689D0-0x0000000181568A50
		[CLSCompliant(false)]
		public static ushort ToUInt16(string value, IFormatProvider provider); // 0x0000000181568AB0-0x0000000181568AD0
		public static int ToInt32(object value); // 0x0000000181567390-0x0000000181567430
		public static int ToInt32(object value, IFormatProvider provider); // 0x00000001815671D0-0x0000000181567280
		public static int ToInt32(bool value); // 0x00000001815669B0-0x00000001815669C0
		public static int ToInt32(char value); // 0x0000000181565B10-0x0000000181565B20
		public static int ToInt32(byte value); // 0x0000000180815D60-0x0000000180815D70
		public static int ToInt32(short value); // 0x0000000181567380-0x0000000181567390
		[CLSCompliant(false)]
		public static int ToInt32(ushort value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static int ToInt32(uint value); // 0x0000000181567170-0x00000001815671D0
		public static int ToInt32(int value); // 0x0000000180815D70-0x0000000180815D80
		public static int ToInt32(long value); // 0x0000000181567430-0x0000000181567490
		[CLSCompliant(false)]
		public static int ToInt32(ulong value); // 0x00000001815670B0-0x0000000181567110
		public static int ToInt32(float value); // 0x0000000181567110-0x0000000181567170
		public static int ToInt32(double value); // 0x0000000181567280-0x0000000181567380
		public static int ToInt32(decimal value); // 0x0000000181567490-0x0000000181567510
		public static int ToInt32(string value, IFormatProvider provider); // 0x0000000181567090-0x00000001815670B0
		[CLSCompliant(false)]
		public static uint ToUInt32(object value); // 0x0000000181569110-0x00000001815691B0
		[CLSCompliant(false)]
		public static uint ToUInt32(object value, IFormatProvider provider); // 0x0000000181569400-0x00000001815694B0
		[CLSCompliant(false)]
		public static uint ToUInt32(bool value); // 0x00000001815669B0-0x00000001815669C0
		[CLSCompliant(false)]
		public static uint ToUInt32(char value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static uint ToUInt32(sbyte value); // 0x0000000181569390-0x00000001815693E0
		[CLSCompliant(false)]
		public static uint ToUInt32(byte value); // 0x0000000180815D60-0x0000000180815D70
		[CLSCompliant(false)]
		public static uint ToUInt32(short value); // 0x0000000181568F10-0x0000000181568F60
		[CLSCompliant(false)]
		public static uint ToUInt32(ushort value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static uint ToUInt32(int value); // 0x00000001815690C0-0x0000000181569110
		[CLSCompliant(false)]
		public static uint ToUInt32(long value); // 0x0000000181569270-0x00000001815692D0
		[CLSCompliant(false)]
		public static uint ToUInt32(ulong value); // 0x0000000181569060-0x00000001815690C0
		[CLSCompliant(false)]
		public static uint ToUInt32(float value); // 0x0000000181568F60-0x0000000181569060
		[CLSCompliant(false)]
		public static uint ToUInt32(double value); // 0x00000001815692D0-0x0000000181569390
		[CLSCompliant(false)]
		public static uint ToUInt32(decimal value); // 0x00000001815694B0-0x0000000181569530
		[CLSCompliant(false)]
		public static uint ToUInt32(string value, IFormatProvider provider); // 0x00000001815693E0-0x0000000181569400
		public static long ToInt64(object value); // 0x00000001815679C0-0x0000000181567A60
		public static long ToInt64(object value, IFormatProvider provider); // 0x00000001815677E0-0x0000000181567890
		public static long ToInt64(bool value); // 0x0000000181567AB0-0x0000000181567AC0
		public static long ToInt64(char value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static long ToInt64(sbyte value); // 0x00000001815678C0-0x00000001815678D0
		public static long ToInt64(byte value); // 0x0000000180815D60-0x0000000180815D70
		public static long ToInt64(short value); // 0x00000001815677D0-0x00000001815677E0
		[CLSCompliant(false)]
		public static long ToInt64(ushort value); // 0x0000000181565B10-0x0000000181565B20
		public static long ToInt64(int value); // 0x00000001815678B0-0x00000001815678C0
		[CLSCompliant(false)]
		public static long ToInt64(uint value); // 0x0000000180815D70-0x0000000180815D80
		[CLSCompliant(false)]
		public static long ToInt64(ulong value); // 0x00000001815678D0-0x0000000181567930
		public static long ToInt64(float value); // 0x0000000181567690-0x0000000181567750
		public static long ToInt64(double value); // 0x0000000181567930-0x00000001815679C0
		public static long ToInt64(decimal value); // 0x0000000181567750-0x00000001815677D0
		public static long ToInt64(string value); // 0x0000000181567A60-0x0000000181567AB0
		public static long ToInt64(string value, IFormatProvider provider); // 0x0000000181567890-0x00000001815678B0
		[CLSCompliant(false)]
		public static ulong ToUInt64(object value); // 0x0000000181569750-0x00000001815697F0
		[CLSCompliant(false)]
		public static ulong ToUInt64(object value, IFormatProvider provider); // 0x00000001815696A0-0x0000000181569750
		[CLSCompliant(false)]
		public static ulong ToUInt64(bool value); // 0x00000001815669B0-0x00000001815669C0
		[CLSCompliant(false)]
		public static ulong ToUInt64(char value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static ulong ToUInt64(sbyte value); // 0x0000000181569530-0x0000000181569580
		[CLSCompliant(false)]
		public static ulong ToUInt64(byte value); // 0x0000000180815D60-0x0000000180815D70
		[CLSCompliant(false)]
		public static ulong ToUInt64(short value); // 0x0000000181569950-0x00000001815699B0
		[CLSCompliant(false)]
		public static ulong ToUInt64(ushort value); // 0x0000000181565B10-0x0000000181565B20
		[CLSCompliant(false)]
		public static ulong ToUInt64(int value); // 0x00000001815695A0-0x00000001815695F0
		[CLSCompliant(false)]
		public static ulong ToUInt64(uint value); // 0x0000000180815D70-0x0000000180815D80
		[CLSCompliant(false)]
		public static ulong ToUInt64(long value); // 0x00000001815699B0-0x0000000181569A00
		[CLSCompliant(false)]
		public static ulong ToUInt64(float value); // 0x00000001815697F0-0x00000001815698D0
		[CLSCompliant(false)]
		public static ulong ToUInt64(double value); // 0x00000001815695F0-0x00000001815696A0
		[CLSCompliant(false)]
		public static ulong ToUInt64(decimal value); // 0x00000001815698D0-0x0000000181569950
		[CLSCompliant(false)]
		public static ulong ToUInt64(string value, IFormatProvider provider); // 0x0000000181569580-0x00000001815695A0
		public static float ToSingle(object value); // 0x00000001815682C0-0x0000000181568360
		public static float ToSingle(object value, IFormatProvider provider); // 0x0000000181568440-0x00000001815684F0
		[CLSCompliant(false)]
		public static float ToSingle(sbyte value); // 0x0000000181568360-0x0000000181568370
		public static float ToSingle(byte value); // 0x0000000181568230-0x0000000181568240
		public static float ToSingle(short value); // 0x0000000181568240-0x0000000181568250
		[CLSCompliant(false)]
		public static float ToSingle(ushort value); // 0x0000000181568220-0x0000000181568230
		public static float ToSingle(int value); // 0x0000000181568430-0x0000000181568440
		[CLSCompliant(false)]
		public static float ToSingle(uint value); // 0x00000001815682A0-0x00000001815682B0
		public static float ToSingle(long value); // 0x00000001815682B0-0x00000001815682C0
		[CLSCompliant(false)]
		public static float ToSingle(ulong value); // 0x0000000181568390-0x00000001815683C0
		public static float ToSingle(double value); // 0x00000001815684F0-0x0000000181568500
		public static float ToSingle(decimal value); // 0x00000001815683C0-0x0000000181568420
		public static float ToSingle(string value); // 0x0000000181568250-0x00000001815682A0
		public static float ToSingle(string value, IFormatProvider provider); // 0x0000000181568370-0x0000000181568390
		public static float ToSingle(bool value); // 0x0000000181568420-0x0000000181568430
		public static double ToDouble(object value); // 0x0000000181566810-0x00000001815668B0
		public static double ToDouble(object value, IFormatProvider provider); // 0x00000001815668B0-0x0000000181566960
		[CLSCompliant(false)]
		public static double ToDouble(sbyte value); // 0x0000000181566720-0x0000000181566730
		public static double ToDouble(byte value); // 0x0000000181566800-0x0000000181566810
		public static double ToDouble(short value); // 0x00000001815669A0-0x00000001815669B0
		[CLSCompliant(false)]
		public static double ToDouble(ushort value); // 0x0000000181566790-0x00000001815667A0
		public static double ToDouble(int value); // 0x0000000181566730-0x0000000181566740
		[CLSCompliant(false)]
		public static double ToDouble(uint value); // 0x0000000181566960-0x0000000181566970
		public static double ToDouble(long value); // 0x0000000181566740-0x0000000181566750
		[CLSCompliant(false)]
		public static double ToDouble(ulong value); // 0x0000000181566760-0x0000000181566790
		public static double ToDouble(float value); // 0x0000000181566970-0x0000000181566980
		public static double ToDouble(double value); // 0x00000001802E76C0-0x00000001802E76D0
		public static double ToDouble(decimal value); // 0x00000001815667A0-0x0000000181566800
		public static double ToDouble(string value, IFormatProvider provider); // 0x0000000181566980-0x00000001815669A0
		public static double ToDouble(bool value); // 0x0000000181566750-0x0000000181566760
		public static decimal ToDecimal(object value, IFormatProvider provider); // 0x00000001815661E0-0x00000001815662F0
		[CLSCompliant(false)]
		public static decimal ToDecimal(sbyte value); // 0x0000000181566440-0x00000001815664B0
		public static decimal ToDecimal(byte value); // 0x0000000181566100-0x0000000181566170
		public static decimal ToDecimal(short value); // 0x00000001815663D0-0x0000000181566440
		[CLSCompliant(false)]
		public static decimal ToDecimal(ushort value); // 0x00000001815664B0-0x0000000181566520
		public static decimal ToDecimal(int value); // 0x00000001815662F0-0x0000000181566360
		[CLSCompliant(false)]
		public static decimal ToDecimal(uint value); // 0x0000000181566600-0x0000000181566670
		public static decimal ToDecimal(long value); // 0x0000000181566170-0x00000001815661E0
		[CLSCompliant(false)]
		public static decimal ToDecimal(ulong value); // 0x0000000181566520-0x0000000181566590
		public static decimal ToDecimal(float value); // 0x0000000181566090-0x0000000181566100
		public static decimal ToDecimal(double value); // 0x0000000181566590-0x0000000181566600
		public static decimal ToDecimal(string value, IFormatProvider provider); // 0x0000000181566670-0x0000000181566720
		public static decimal ToDecimal(bool value); // 0x0000000181566360-0x00000001815663D0
		public static DateTime ToDateTime(object value, IFormatProvider provider); // 0x0000000181565F20-0x0000000181566000
		public static DateTime ToDateTime(string value, IFormatProvider provider); // 0x0000000181566000-0x0000000181566090
		public static string ToString(object value, IFormatProvider provider); // 0x0000000181568590-0x00000001815686F0
		public static string ToString(char value, IFormatProvider provider); // 0x0000000181568830-0x0000000181568880
		public static string ToString(int value, IFormatProvider provider); // 0x0000000181568780-0x00000001815687A0
		public static byte ToByte(string value, int fromBase); // 0x0000000181565710-0x0000000181565810
		[CLSCompliant(false)]
		public static sbyte ToSByte(string value, int fromBase); // 0x0000000181567E80-0x0000000181567FA0
		public static short ToInt16(string value, int fromBase); // 0x0000000181566B90-0x0000000181566CA0
		[CLSCompliant(false)]
		public static ushort ToUInt16(string value, int fromBase); // 0x0000000181568880-0x0000000181568980
		public static int ToInt32(string value, int fromBase); // 0x0000000181567510-0x00000001815675D0
		[CLSCompliant(false)]
		public static uint ToUInt32(string value, int fromBase); // 0x00000001815691B0-0x0000000181569270
		public static long ToInt64(string value, int fromBase); // 0x00000001815675D0-0x0000000181567690
		[CLSCompliant(false)]
		public static ulong ToUInt64(string value, int fromBase); // 0x0000000181569A00-0x0000000181569AC0
		public static string ToString(byte value, int toBase); // 0x0000000181568500-0x0000000181568590
		public static string ToString(int value, int toBase); // 0x00000001815686F0-0x0000000181568780
		public static string ToString(long value, int toBase); // 0x00000001815687A0-0x0000000181568830
		public static string ToBase64String(byte[] inArray); // 0x0000000181564CE0-0x0000000181564DA0
		public static string ToBase64String(byte[] inArray, int offset, int length); // 0x0000000181564DA0-0x0000000181564E20
		public static string ToBase64String(byte[] inArray, int offset, int length, Base64FormattingOptions options); // 0x0000000181564930-0x0000000181564B60
		public static string ToBase64String(ReadOnlySpan<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None /* Metadata: 0x0064E2DC */); // 0x0000000181564B60-0x0000000181564CE0
		public static int ToBase64CharArray(byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut); // 0x0000000181564480-0x0000000181564510
		public static int ToBase64CharArray(byte[] inArray, int offsetIn, int length, char[] outArray, int offsetOut, Base64FormattingOptions options); // 0x0000000181564510-0x0000000181564930
		private static unsafe int ConvertToBase64Array(char* outChars, byte* inData, int offset, int length, bool insertLineBreaks); // 0x0000000181562F50-0x00000001815632A0
		private static int ToBase64_CalculateAndValidateOutputLength(int inputLength, bool insertLineBreaks); // 0x0000000181564E20-0x0000000181564F10
		public static byte[] FromBase64String(string s); // 0x0000000181563F90-0x0000000181564050
		public static bool TryFromBase64Chars(ReadOnlySpan<char> chars, Span<byte> bytes, out int bytesWritten); // 0x0000000181569DD0-0x000000018156A350
		private static void CopyToTempBufferWithoutWhiteSpace(ReadOnlySpan<char> chars, Span<char> tempBuffer, out int consumed, out int charsWritten); // 0x00000001815632A0-0x00000001815633B0
		public static byte[] FromBase64CharArray(char[] inArray, int offset, int length); // 0x0000000181563B20-0x0000000181563D80
		private static unsafe byte[] FromBase64CharPtr(char* inputPtr, int inputLength); // 0x0000000181563D80-0x0000000181563F90
		private static unsafe int FromBase64_ComputeResultLength(char* inputPtr, int inputLength); // 0x0000000181564050-0x0000000181564110
	
		// Extension methods
		private static bool IsSpace(this char c); // 0x0000000181564180-0x00000001815641B0
	}
}
